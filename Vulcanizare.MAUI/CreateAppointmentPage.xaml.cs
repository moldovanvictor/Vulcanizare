using Vulcanizare.MAUI.Models;

namespace Vulcanizare.MAUI;

public partial class CreateAppointmentPage : ContentPage
{
	public CreateAppointmentPage()
	{
		InitializeComponent();
	}

    private void OnCreateAppointmentClicked(object sender, EventArgs e)
    {
        var appointment = new Appointment
        {
            UserId = int.Parse(UserIdEntry.Text),
            TireId = int.Parse(TireIdEntry.Text),
            AppointmentDate = AppointmentDatePicker.Date,
            ServiceType = ServiceTypeEntry.Text,
            ServiceDuration = int.Parse(ServiceDurationEntry.Text),
            Status = StatusEntry.Text,
            Comment = CommentEntry.Text,
            ServicePrice = decimal.Parse(ServicePriceEntry.Text)
        };

        // TODO: Add code to save the appointment
    }
}