namespace kUMTE_2018.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            
            var documentsPath = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            
            LoadApplication(new kUMTE_2018.App(documentsPath));
        }
    }
}
