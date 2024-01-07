using Vulcanizare.MAUI.Data;

namespace Vulcanizare.MAUI
{
    public partial class App : Application
    {
        public static TireDatabase Database { get; private set; }

        public App()
        {
            Database = new TireDatabase(new RestService());

            var navigationPage = new NavigationPage(new ListEntryPage())
            {
                Title = "Tires",
                IconImageSource = "tires_icon.png" // replace with your icon file
            };
            var appointmentsPage = new NavigationPage(new CreateAppointmentPage())
            {
                Title = "Appointments",
                IconImageSource = "appointments_icon.png" // replace with your icon file
            };
            var tireHotelPage = new NavigationPage(new TireHotelPage())
            {
                Title = "Tire Hotel",
                IconImageSource = "tire_hotel_icon.png" // replace with your icon file
            };

            MainPage = new TabbedPage
            {
                Children =
                {
                    navigationPage,
                    appointmentsPage,
                    tireHotelPage
                }
            };
        }
    }
}