using Vulcanizare.MAUI.ViewModels;
using Vulcanizare.MAUI.Models;

namespace Vulcanizare.MAUI.Views;

public partial class AddTirePage : ContentPage
{
	public Tire Tire { get; set;} 
	public AddTirePage()
	{
		InitializeComponent();
		this.BindingContext = new AddTirePageViewModel();
	}

    public AddTirePage(Tire tire)
    {
        InitializeComponent();
        this.BindingContext = new AddTirePageViewModel();
 
		if(tire != null)
		{
			((AddTirePageViewModel)BindingContext).Tire = tire;
		}
	}
}