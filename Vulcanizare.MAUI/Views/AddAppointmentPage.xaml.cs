namespace Vulcanizare.MAUI.Views;

public partial class AddAppointmentPage : ContentPage
{
    public AddAppointmentPage()
    {
        InitializeComponent();
    }

    private void OnSalveazaClicked(object sender, EventArgs e)
    {
        titluProgramare.Text = "";
        dataProgramare.Date = DateTime.Today;
        timpProgramare.Time = TimeSpan.FromHours(DateTime.Now.Hour);
        descriereProgramare.Text = "";
        alteDetalii.Text = "";
    }
}
