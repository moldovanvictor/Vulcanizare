using Vulcanizare.MAUI.ViewModels;
using Vulcanizare.MAUI.Views;

namespace Vulcanizare.MAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		this.BindingContext = new AppShellViewModel();
		Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
	}
}
