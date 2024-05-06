using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                // One or more fields are empty. Display an error message:
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill in all fields.", "OK");
            }
            else if (Password != ConfirmPassword)
            {
                // Passwords do not match. Display an error message:
                await Application.Current.MainPage.DisplayAlert("Error", "Passwords do not match.", "OK");
            }
            else
            {
                // All fields are filled. Continue with the sign up process...
              
                await Shell.Current.GoToAsync("SignIn");
            }
          
        }
        [RelayCommand] 
        public async Task SignIn()
        {
            await Shell.Current.GoToAsync("SignIn");
        }


    }
}
