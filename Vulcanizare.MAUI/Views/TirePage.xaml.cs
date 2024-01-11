using Microsoft.Toolkit.Mvvm.Input;
using Vulcanizare.MAUI.ViewModels;

namespace Vulcanizare.MAUI.Views;

public partial class TirePage : ContentPage
{
	TirePageViewModel tirePageVewModel;
	public TirePage()
	{
		InitializeComponent();
		this.BindingContext = tirePageVewModel = new TirePageViewModel(Navigation);

	}

	protected override void OnAppearing()
	{
        base.OnAppearing();
        tirePageVewModel.OnAppearing();
    }
}