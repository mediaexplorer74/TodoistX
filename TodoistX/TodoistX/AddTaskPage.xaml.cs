using System;
using System.Threading.Tasks;
using Todoist.Net;
using Todoist.Net.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoistX
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddTaskPage : ContentPage
	{
	    private readonly Project _project;
        public AddTaskPage ()
		{
			InitializeComponent ();
		}
	    public AddTaskPage(Project item)
	    {
	        InitializeComponent();
	        _project = item;
	    }

        private async Task AddButton_OnClicked(object sender, EventArgs e)
        {
	        using (var client = new TodoistClient(ProjectBrowsePage.AuthKey))
	        {
				// Add Task
	            await client.Items.AddAsync(new Item(ContentEntry.Text, _project.Id));
	        }

            await Navigation.PopAsync();
        }
	}
}