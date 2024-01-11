namespace Vulcanizare.MAUI.Views;

public partial class AppointmentPage : ContentPage
{
    public AppointmentPage()
    {
        InitializeComponent();
    }

    private async void OnAddAppointmentClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddAppointmentPage());
    }
}