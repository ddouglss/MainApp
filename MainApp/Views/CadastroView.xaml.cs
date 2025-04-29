using MainApp.Models.Users;
using MainApp.Services.Navigation;
using MainApp.Services.Users;

namespace MainApp.Views
{
    [QueryProperty(nameof(Route), "route")]
    public partial class CadastroView : ContentPage
    {
        public string Route { get; set; }
        public const double MyFontSizeApp = 14;
        private readonly IUserService _userService; 
        private readonly INavigationService _navigationService;

        public CadastroView(IUserService userService, INavigationService navigationService)
        {
            InitializeComponent();
            _navigationService = navigationService;
            _userService = userService ?? throw new ArgumentNullException(nameof(userService)); 
        }

        private async void Cadastrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var nome = NomeEntry.Text?.Split(' ') ?? new string[0];

                var user = new User
                {
                    FirstName = nome.Length > 0 ? nome.First() : string.Empty,
                    LastName = nome.Length > 1 ? nome.Last() : SobrenomeEntry.Text ?? string.Empty,
                    Username = UsernameEntry.Text ?? string.Empty,
                    Password = PasswordEntry.Text ?? string.Empty,
                    BirthDate = DataNascimento.Date.ToShortDateString(),
                    Gender = Genero.SelectedItem?.ToString() ?? "Indefinido",
                    ExpiresInMins = 30
                };

                // Cálculo automático da idade
                user.Age = CalcularIdade(DataNascimento.Date);

                // Chamando o serviço para adicionar o usuário
                var userResult = await _userService.Add(user);

                // Verificando se o usuário foi realmente salvo
                if (userResult != null)
                {
                    await DisplayAlert("Cadastro de Usuário",
                        $"Cadastro de {userResult.FirstName} realizado com sucesso!",
                        "Ok!");

                    if (!string.IsNullOrEmpty(Route))
                    {
                        await Shell.Current.GoToAsync(Route);
                    }
                }
                else
                {
                    await DisplayAlert("Erro", "Não foi possível cadastrar o usuário. Tente novamente.", "Ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Ocorreu um erro: {ex.Message}", "Ok");
            }
        }


        private void DataNascimento_DateSelected(object sender, DateChangedEventArgs e)
        {
            IdadeEntry.Text = CalcularIdade(DataNascimento.Date).ToString();
        }

        static int CalcularIdade(DateTime dataNascimento)
        {
            var hoje = DateTime.Today;
            int idade = hoje.Year - dataNascimento.Year;
            return (hoje < dataNascimento.AddYears(idade)) ? idade - 1 : idade;
        }
    }

    [AcceptEmptyServiceProvider]
    public class GlobalFontSizeExtension : IMarkupExtension
    {
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return DeviceInfo.Platform == DevicePlatform.Android ? 18 : CadastroView.MyFontSizeApp;
        }
    }
}
