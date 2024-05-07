

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MidtermProject.Data;


    public static class NoteManagement
{
    // TODO: Add fields for BaseAddress, Url, and authorizationKey
    static readonly string BaseAddress = "http://localhost:3000";
    static readonly string UrlAccount = $"{BaseAddress}/api/account/";
    static readonly string UrlNote = $"{BaseAddress}/api/note/";

/*    static readonly string BaseAddress = "http://localhost:3000";
    static readonly string Url = $"{BaseAddress}/api/account/";*/
    private static string authorizationKey;
    private static HttpClient client;



    public static async Task<bool>  SetAuthorizationKey(string email, string Enterpassword)
    {
        client = new HttpClient();

       
            // Create the request body
            var requestBody = new
            {
                user = email,
                password = Enterpassword
            };

            // Convert the request body to JSON
            var jsonRequestBody = JsonSerializer.Serialize(requestBody);
            // Convert the JSON to HttpContent
            var httpContent = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

            // Send a POST request
            var response = await client.PostAsync($"{UrlAccount}login", httpContent);

            // Ensure the request was successful 
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            
                // Get the response body
                var responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize the response body
                var result = JsonSerializer.Deserialize<Dictionary<string, string>>(responseBody);

                // Store the token
                authorizationKey = result["token"];



        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authorizationKey}");
        client.DefaultRequestHeaders.Add("Accept", "application/json");

        return true; 
       

    }

   

    public static async Task<IEnumerable<Note>> GetAll()
    {

        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            return new List<Note>();
        }

   
        var result = await client.GetStringAsync(UrlNote);

        // Parse the result string into a JSON object
        JsonDocument doc = JsonDocument.Parse(result);

        // Access the "data" property of the JSON object
        JsonElement data = doc.RootElement.GetProperty("data");

        // Deserialize the "data" property into a list of Note objects
        return JsonSerializer.Deserialize<List<Note>>(data.GetRawText(), new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        });

    }
    public static async Task<string> RegisterAccount(string name, string email,string password)
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return "no internet connection";

        client = new HttpClient();
        var note = new
        {
            user = email,
            password = password , 
            name = name
        };
        var jsonRequestBody = JsonSerializer.Serialize(note);
        // Convert the JSON to HttpContent
        var httpContent = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

        // Send a POST request
        var response = await client.PostAsync($"{UrlAccount}", httpContent);

        if (!response.IsSuccessStatusCode)
        {
            string responseContent = await response.Content.ReadAsStringAsync();

            JsonDocument doc = JsonDocument.Parse(responseContent); 
            JsonElement error = doc.RootElement.GetProperty("message");
            return  error.GetString() ;
        }

        return "";

    }


    public static async Task<Note> Add(string title, string content )
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return new Note();
        var note = new
        {
           title  = title   , 
           content = content  , 
        

        };
        var jsonRequestBody = JsonSerializer.Serialize(note);
        // Convert the JSON to HttpContent
        var httpContent = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

        // Send a POST request
        var response = await client.PostAsync($"{UrlNote}", httpContent);


        string responseContent = await response.Content.ReadAsStringAsync();

        JsonDocument doc = JsonDocument.Parse(responseContent);


        JsonElement data = doc.RootElement.GetProperty("data"); 
        return JsonSerializer.Deserialize<Note>(data.GetRawText(), new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        });

    }

    public static async Task Update(string title  , string content , int id)
    {

        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return;
        var note = new
        {
            title = title,
            content = content,


        };
        var jsonRequestBody = JsonSerializer.Serialize(note);
        // Convert the JSON to HttpContent
        var httpContent = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

        // Send a POST request
        var response = await client.PatchAsync($"{UrlNote}{id}", httpContent);




    }

    public static async Task Delete(int  id)
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return;
        var response = await client.DeleteAsync($"{UrlNote}{id}");

    }
}
