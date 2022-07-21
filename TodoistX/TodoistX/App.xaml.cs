using System;
using System.IO;
using System.Linq;
using TodoistX.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace TodoistX
{
	public partial class App : Application
	{
	    public static string AppDataDir = string.Empty;
	    public static string AppDataDbString = string.Empty;
        public App ()
		{
			InitializeComponent();

			MainPage = new MainPage();
		}
	    public App(string appDataDir)
	    {
	        InitializeComponent();
	        AppDataDir = appDataDir;
	        AppDataDbString = Path.Combine(App.AppDataDir, AppSetting.DbFileName);
	        InitializeDb();
            MainPage = new NavigationPage(new MainPage());
	    }

	    private void InitializeDb()
	    {
	        using (var conn = new SQLiteConnection(AppDataDbString))
	        {
	            conn.CreateTable<AppSetting>();

	            var data = conn.Table<AppSetting>();
	            
				if (!data.Any())
	            {
	                var d = new AppSetting()
	                {
                          //AppName = "TodoistX",
                          //Author = "Jaroslav Langer",
                          //AuthKey = "2f6421653f8eb04e42492f94615d6b32daf343bc"
                            AppName = "TodoistX",
                            Author = " Media Explorer",
                            AuthKey = "xxxxxx" // paste your Access Token here
                        };

	                conn.Insert(d);
	            }
	        }

        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
