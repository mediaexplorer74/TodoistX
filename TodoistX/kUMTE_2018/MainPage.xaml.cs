using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace kUMTE_2018
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetCurrentLocationAsync();
        }
        private void Setting_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingPage());
        }

        private void Browse_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProjectBrowsePage());
        }

        public async Task GetCurrentLocationAsync()
        {
            if (!CrossGeolocator.IsSupported)
            {
                await DisplayAlert
                    (
                    "Error", 
                    "This device doesn not support Location service", 
                    "Ok"
                    );

                return;
            }                
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await DisplayAlert
                            (
                            "Need location", 
                            "Gunna need that location", 
                            "OK"
                            );
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync
                        (Permission.Location);

                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Location))
                        status = results[Permission.Location];
                }
                if (status == PermissionStatus.Granted)
                {
                    var results = await CrossGeolocator.Current.GetPositionAsync
                        (TimeSpan.FromSeconds(10));

                    CoordLabel.Text = "Lat: " + results.Latitude 
                        + " Long: " + results.Longitude;
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert
                        (
                        "Location Denied", 
                        "Can not continue, try again.", 
                        "OK"
                        );
                }
            }
            catch (Exception ex)
            {
                CoordLabel.Text = "Error: " + ex;
            }
        }
    }
}
