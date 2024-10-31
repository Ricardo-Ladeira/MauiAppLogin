namespace MauiAppLogin
{
public partial class App : Application
{
public App()
{
InitializeComponent();

		string? usuario_logado = null;

		Task.Run(async () =>
		{
			usuario_logado = await SecureStorage.Default.GetAsync("usuarios_logado");
            if (usuario_logado!= null)
            {
                MainPage = new Protegida();
		} else{
            MainPage = new Login();
        }
        });

MainPage = new Login();
}

} // Fecha classe
} // Fecha namespace