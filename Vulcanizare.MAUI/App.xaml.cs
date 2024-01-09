using Vulcanizare.MAUI.Models;

namespace Vulcanizare.MAUI;

public partial class App : Application
{
	public static UserInfo UserInfo;
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
