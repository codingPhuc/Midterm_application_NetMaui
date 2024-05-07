using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MidtermProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject.ViewModel
{
    public partial class SignUpViewModel : ObservableObject
    {
        [ObservableProperty]
        string name = "";
        [ObservableProperty]
        string email = "";
        [ObservableProperty]
        string password = "";
        [ObservableProperty]
        string confirmPassword = "";
        public SignUpViewModel()
        {

        }
        [RelayCommand]
        public async Task SignUp()
        {   
            string message = await NoteManagement.RegisterAccount(Name, Email, Password);
            if (String.IsNullOrEmpty(message) )
            {
                await App.Current.MainPage.DisplayAlert("Success", "Sign up successful!", "OK");

                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", message, "OK");
            }
          
        }
        [RelayCommand] 
        public async Task SignIn()
        {
            await Shell.Current.GoToAsync("SignIn");
        }


    }
}
