namespace Vulcanizare.MAUI.Views;

public partial class ContactPage : ContentPage
{
	public ContactPage()
	{
		InitializeComponent();
	}

    private void OnTrimiteMesajClicked(object sender, EventArgs e)
    {
        nume.Text = "";
        email.Text = "";
        mesaj.Text = "";
    }
}