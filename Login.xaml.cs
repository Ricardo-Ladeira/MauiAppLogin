namespace MauiAppLogin;

public partial class Login : ContentPage
{
	int count = 0;

	public Login()
	{
		InitializeComponent();
}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Validate the user input
            if (string.IsNullOrWhiteSpace(txt_usuario.Text) || string.IsNullOrWhiteSpace(txt_senha.Text))
            {
                await DisplayAlert("Erro!", "Por favor, entre com o nome e senha de usuário", "OK");
                return;
            }
            List<DadosUsuario> lista_usuarios = new List<DadosUsuario>(){
                new DadosUsuario()
                {
                    Usuario = "admin",
                    Senha = "123"
                },
                new DadosUsuario() {
                    Usuario = "user",
                    Senha = "456"
                }
            };
            DadosUsuario dados_digitados = new DadosUsuario()
            {
                Usuario = txt_usuario.Text,
                Senha = txt_senha.Text
            };
            //LINQ
            if(lista_usuarios.Any(i=> (dados_digitados.Usuario == i.Usuario && dados_digitados.Senha == i.Senha)))
            {
                SecureStorage.Default.SetAsync("usuarios_logado", dados_digitados.Usuario );

                App.Current.MainPage = new Protegida();
            }
            else{
                throw new Exception("Usuário ou senha incorreta");
            }
        }
        catch(Exception ex)
        {
            await DisplayAlert("Erro!", ex.Message, "OK");
            return;
        }

            // Perform login logic here
            // ...

            // Navigate to the main page
            // Navigation.PushAsync(new MainPage());
        }
    }

