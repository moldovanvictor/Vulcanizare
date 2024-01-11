using Vulcanizare.MAUI.ViewModels;
using Vulcanizare.MAUI.Views;

namespace Vulcanizare.MAUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<HomePage>();
		builder.Services.AddSingleton<LoginPage>();
		builder.Services.AddSingleton<ContactPage>();
		builder.Services.AddSingleton<AboutPage>();

		builder.Services.AddSingleton<LoginPageViewModel>();
		builder.Services.AddSingleton<TirePageViewModel>();
		builder.Services.AddSingleton<AddTirePageViewModel>();

		return builder.Build();
	}
}
