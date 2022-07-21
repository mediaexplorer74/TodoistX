namespace TodoistX.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            
            var documentsPath = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            
            LoadApplication(new TodoistX.App(documentsPath));
        }
    }
}
