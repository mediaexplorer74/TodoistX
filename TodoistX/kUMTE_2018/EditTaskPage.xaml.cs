using System;
using System.Threading.Tasks;
using Todoist.Net;
using Todoist.Net.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace kUMTE_2018
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditTaskPage : ContentPage
	{
	    private readonly Item _item;

        public EditTaskPage ()
		{
			InitializeComponent ();
		}
	    
		public EditTaskPage(Item item)
	    {
	        InitializeComponent();
	        _item = item;

			ContentEntry.Text = _item.Content;

        }

        private async Task UpdateButton_OnClicked(object sender, EventArgs e)
        {
	        using (var client = new TodoistClient(ProjectBrowsePage.AuthKey))
	        {
				
				_item.Content = ContentEntry.Text;

				// Modify Task
                await client.Items.UpdateAsync(_item);
								
	        }

            await Navigation.PopAsync();
        }
	}
}