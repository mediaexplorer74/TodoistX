using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Todoist.Net.Tests; // !

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TodoistUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();         

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Todoist.Net.ITodoistClient client = TodoistClientFactory.Create();

            Todoist.Net.Models.Resources resources = null;

            Output.Items.Clear();


            try
            {
                resources = client.GetResourcesAsync().Result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
                Output.Items.Add("Error: " + ex.Message);

                return;
            }

            

            Debug.WriteLine("Notes Count: " + resources.Notes.Count.ToString());
            Debug.WriteLine("Projects Count: " + resources.Projects.Count.ToString());
            Debug.WriteLine("Reminders Count: " + resources.Reminders.Count.ToString());

            Output.Items.Add("Notes Count: " + resources.Notes.Count.ToString());
            Output.Items.Add("Projects Count: " + resources.Projects.Count.ToString());
            Output.Items.Add("Reminders Count: " + resources.Reminders.Count.ToString());

        }
    }
}
