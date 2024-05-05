using MidtermProject.ViewModel;

namespace MidtermProject;

public partial class SignUp : ContentPage
{
	public SignUp()
	{
		InitializeComponent();

		BindingContext = new SignUpViewModel();
	}
}