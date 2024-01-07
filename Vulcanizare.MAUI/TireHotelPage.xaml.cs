using Vulcanizare.MAUI.Models;

namespace Vulcanizare.MAUI;

public partial class TireHotelPage : ContentPage
{
    public TireHotelPage()
    {
        InitializeComponent();
    }

    private void OnCheckTireStatusClicked(object sender, EventArgs e)
    {
        var tireHotel = new TireHotel
        {
            UserId = int.Parse(UserIdEntry.Text),
            TireStatus = TireStatusEntry.Text
        };

        // TODO: Add code to check the tire status
    }
}