using MidtermProject.ViewModel;

namespace MidtermProject;

public partial class SignIn : ContentPage
{	
	
	
	public SignIn()
	{
		InitializeComponent(); 

		BindingContext = new SignInViewModel();

	}
}