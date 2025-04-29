using MainApp.Services.Settings;

namespace MainApp.Services.Navigation
{
    public class NavigationService(ISettingsService settingsService) : INavigationService
    {
        private readonly ISettingsService _settingsService = settingsService;
        public Task InitializeAsync()
        {
            var route = "home";
            if (!string.IsNullOrEmpty(_settingsService.AuthAccessToken))
                route = "//Main/MainPage";

            return NavigationAsync(route);
        }

        public Task NavigationAsync(string route)
        {
            return Shell.Current.GoToAsync(route);
        }
    }
}
