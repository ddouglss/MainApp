namespace MainApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Cadastrar_Clicked(object sender, EventArgs e)
        {
            var nome = NomeCompleto.Text;
            var data = DataNascimento.Date;
            var genro = Genero.SelectedItem;
            var idade = Idade.Text;

            DisplayAlert("Cadastro de Usuário", string.Format("Cadastro de Usuário {0} foi Realizado com Sucesso", nome), "Ok!");
        }

        private void DataNascimento_DateSelected(object sender, DateChangedEventArgs e)
        {
            var dataNascimento = DataNascimento.Date; 
            int idade = CalcularIdade(dataNascimento);
            Idade.Text = idade.ToString("D");
        }
        static int CalcularIdade(DateTime dataNascimento)
        {
            var dataAtual = DateTime.Today;
            int idade = dataAtual.Year - dataNascimento.Year;

            if (dataAtual < dataNascimento.AddYears(idade))
            {
                return idade--;
            }
            return idade;
        }
    }
}
