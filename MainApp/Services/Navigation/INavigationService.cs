namespace MainApp.Services.Navigation
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task NavigationAsync(string route);
    }
}
