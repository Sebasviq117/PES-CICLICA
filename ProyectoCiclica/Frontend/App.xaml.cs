using Frontend.Views;

namespace Frontend
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LogCiclica());
        }
    }
}