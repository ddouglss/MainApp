using MainApp.Services.Navigation;

namespace MainApp
{
    public partial class App : Application
    {
        public App(INavigationService navigationService)
        {
            InitializeComponent();

            MainPage = new AppShell(navigationService);
        }
    }
}
