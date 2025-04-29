using MainApp.Models.Users;
using MainApp.Services.Navigation;
using MainApp.Services.Settings;
using MainApp.Services.Users;

namespace MainApp.Views;

public partial class LoginView : ContentPage
{
    private readonly IUserService _userService;
    private readonly ISettingsService _settingsService;
    private readonly INavigationService _navigationService;
    public LoginView(ISettingsService settingsService, IUserService userService, INavigationService navigationService)
    {
        _navigationService = navigationService;
        _userService = userService;
        _settingsService = settingsService;
        InitializeComponent();
    }

    private async void Login_Clicked(object sender, EventArgs e)
    {
        var auth = new UserAuth()
        {
            Username = Username.Text,
            Password = Password.Text,
            ExpiresInMins = 30
        };

        var response = await _userService.Authenticate(auth);

        if (response == null)
            DisplayAlert("Login de Usu�rio", "Usu�rio ou senha inv�lidos", "Ok!");
        else
        {
            _settingsService.AuthAccessToken = response.AccessToken;

            DisplayAlert("Login de Usu�rio", string.Format("Usu�rio {0} logado com sucesso", response.FirstName), "Ok!");

            await _navigationService.NavigationAsync("//Main/MainPage");
        }
    }
}