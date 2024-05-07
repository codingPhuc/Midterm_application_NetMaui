using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MidtermProject.Data;

namespace MidtermProject.ViewModel
{
    public partial class SignInViewModel : ObservableObject
    {


        List<Dictionary<string, string>> users = new List<Dictionary<string, string>>
{
    new Dictionary<string, string>
    {
        { "Email", "user1@example.com" },
        { "Password", "password1" }
    },
    new Dictionary<string, string>
    {
        { "Email", "user2@example.com" },
        { "Password", "password2" }
    }
    // Add more dictionaries (users) here...
};
        [ObservableProperty]
        string email = "";
        [ObservableProperty]
        string password = ""; 
        public SignInViewModel()
        {

        }
        [RelayCommand]
        public async Task SignIn()
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                // One or more fields are empty. Display an error message:
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill in all fields.", "OK");
            }
            else
            {
                // Check if the email and password exist in the list of users
                
                var userExists =  await NoteManagement.SetAuthorizationKey(email, password);
                if (!userExists)
                {
                    // The email and password do not exist in the list of users. Display an error message:
                    await Application.Current.MainPage.DisplayAlert("Error", "Email and password are incorrect.", "OK");
                }
                else
                {
                    // The email and password exist in the list of users. Continue with the sign in process... 

                   
                    await Shell.Current.GoToAsync("MainPage");
                
                }
            }
        }

        [RelayCommand] 
        public async Task SignUp()
        {
            await Shell.Current.GoToAsync("SignUp");
        }

    }

   
   
}
