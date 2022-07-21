using System;
using TodoistX.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoistX
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingPage : ContentPage
	{
		public SettingPage ()
		{
			InitializeComponent ();
		}

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
	        using (var conn = new SQLiteConnection(App.AppDataDbString))
	        {
	            var item = conn.Get<AppSetting>(1);

	            AuthKeyEntry.Text = item.AuthKey;
	        }
        }

	    private void Button_OnClicked(object sender, EventArgs e)
	    {
	        using (var conn = new SQLiteConnection(App.AppDataDbString))
	        {
	            var item = conn.Get<AppSetting>(1);

	            item.AuthKey = AuthKeyEntry.Text;

	            conn.Update(item);
	        }

	        DisplayAlert
				(
				"Success", 
				"Your setting was successfully saved!", 
				"Ok"
				);
	    }
	}
}