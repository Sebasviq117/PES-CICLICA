using Frontend.Entidades.Response;
using Frontend.Servicios;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Frontend.Views;

public partial class LogCiclica : ContentPage
{
    readonly IngresarUsuarioService _IngresarUsuarioService = new LoginService();
	public LogCiclica()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }
    private void BtnRegistrar_Clicked(object sender, EventArgs e)
    {
      Navigation.PushAsync(new RegCiclica());
        
        //1.crear entidad
        //2.Crear la conexion con el api.json
        //3.Cerializar la entidad a json (Newtonsoft)
        //4.Ejecutar el json con el api
        //5.Recibir respuesta    
    }

    private async void Btn_Ingresar_Clicked(object sender, EventArgs e)
    {
        string UserCorreo = LoginCorreo.Text;
        string UserContrase�a = LoginContrase�a.Text;
        if(UserCorreo == null || UserContrase�a == null)
        {
            await DisplayAlert("Advertencia","Ingresa el Correo y contrase�a", "Ok");
            return;
        }
        ResLoginUsuario loginApi = await _IngresarUsuarioService.Login(UserCorreo, UserContrase�a);
        if (loginApi != null)
        {
            await Navigation.PushAsync(new VistaPrincipal());
        }
        else
        {
            await DisplayAlert("Advertencia", "Correo y contrase�a incorrectos", "Ok");
        }
    }
}