using Vulcanizare.MAUI.Models;
using Vulcanizare.MAUI.Services.TireService;

namespace Vulcanizare.MAUI;

public partial class App : Application
{
	public static UserInfo UserInfo;
	public static TireService _tireService;

	public static TireService TireService
	{
        get
		{
            if (_tireService == null)
			{
                _tireService = new TireService(
					Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"TireDB.db3"));
            }
            return _tireService;
        }
    }	
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
