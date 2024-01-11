namespace Vulcanizare.MAUI.UserControl;

public partial class FlyoutHeaderControl : ContentView
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();
		if(App.UserInfo != null)
		{
            lblUserName.Text = "Logged In As: " + App.UserInfo.UserName;
			//lblUserEmail.Text = App.UserInfo.UserName;
        }
	}
}