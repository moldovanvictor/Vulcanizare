using Vulcanizare.MAUI.Models;

namespace Vulcanizare.MAUI;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Tire)BindingContext;
        await App.Database.SaveTireAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Tire)BindingContext;
        await App.Database.DeleteTireAsync(slist);
        await Navigation.PopAsync();
    }

}