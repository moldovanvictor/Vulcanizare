using Vulcanizare.MAUI.ViewModels;

namespace Vulcanizare.MAUI;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel loginPageViewModel)
	{
		InitializeComponent();
		this.BindingContext = loginPageViewModel;
	}
}