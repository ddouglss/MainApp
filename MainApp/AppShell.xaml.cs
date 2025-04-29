using MainApp.Services.Navigation;
using MainApp.Views;

namespace MainApp
{
    public partial class AppShell : Shell
    {
        private readonly INavigationService _navigationService;
        public AppShell(INavigationService navigationService)
        {
            _navigationService = navigationService;
            InitializeRouting();
            InitializeComponent();
        }

        protected override async void OnHandlerChanged()
        {
            base.OnHandlerChanged();

            if (Handler is not null)
            {
                await _navigationService.InitializeAsync();
            }
        }

        public static void InitializeRouting()
        {
            Routing.RegisterRoute("cadastro", typeof(CadastroView));
            Routing.RegisterRoute("home", typeof(HomeView));
            Routing.RegisterRoute("login", typeof(LoginView));
        }
    }
}
