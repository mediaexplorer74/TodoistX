using System;
using System.Threading.Tasks;
using Todoist.Net;
using Todoist.Net.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace kUMTE_2018
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddProjectPage : ContentPage
	{
		public AddProjectPage ()
		{
			InitializeComponent ();
		}

	    private async Task AddProjectButton_OnClicked(object sender, EventArgs e)
	    {
	        if (string.IsNullOrEmpty(TitleEntry.Text))
	        {
	            await DisplayAlert
					(
					"Error", 
					"Cannot add project with empty title", 
					"Ok"
					);
                return;
            }

	        using (var client = new TodoistClient(ProjectBrowsePage.AuthKey))
	        {
	            await client.Projects.AddAsync(new Project(TitleEntry.Text));
	        }

	        await DisplayAlert
				(
				"Success", 
				$"Project {TitleEntry.Text} successfully added", 
				"Ok");

	        await Navigation.PopAsync();
	    }
	}
}