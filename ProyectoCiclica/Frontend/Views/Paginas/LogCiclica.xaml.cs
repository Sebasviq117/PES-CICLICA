using Frontend.Entidades;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Frontend.Views;

public partial class LogCiclica : ContentPage
{
    string api = "https://webapiciclica.azurewebsites.net/api/";

    public LogCiclica()
	{
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }
    private void BtnRegistrar_Clicked(object sender, EventArgs e)
    {
      Navigation.PushAsync(new RegCiclica());
    }
    private async void Btn_Ingresar_Clicked(object sender, EventArgs e)
    {
        
        if(string.IsNullOrEmpty(LoginCorreo.Text) || string.IsNullOrEmpty(LoginContrase�a.Text))
        {
            await DisplayAlert("Advertencia","Ingresa el Correo y contrase�a", "Ok");
            return;
        }else
        {
            ReqLoginUsuario reqLoginUsuario = new ReqLoginUsuario();
            reqLoginUsuario.userLog = new Login();
            reqLoginUsuario.userLog.correo = LoginCorreo.Text;
            reqLoginUsuario.userLog.contrasena = LoginContrase�a.Text;
            var jsonContent = new StringContent(JsonConvert.SerializeObject(reqLoginUsuario), Encoding.UTF8, "application/json");
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync(api + "usuario/loginUsuario", jsonContent);

            if(response.IsSuccessStatusCode) {
                ResLoginUsuario resLoginUsuario = new ResLoginUsuario();
                var responseContent = await response.Content.ReadAsStringAsync();
                resLoginUsuario = JsonConvert.DeserializeObject<ResLoginUsuario>(responseContent);
                if (resLoginUsuario.resultado)
                {
                    // En LogCiclica despu�s de la autenticaci�n exitosa
                    Application.Current.MainPage = new AppShell();

                }
                else
                {
                    await DisplayAlert("Advertencia", "Correo y contrase�a incorrectos", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Advertencia", "Error de conexion", "Ok");
            }
        }
        
    }
}