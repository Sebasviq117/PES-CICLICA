using Frontend.CapturarDatos;
using Frontend.Entidades;
using Frontend.Models;
using Newtonsoft.Json;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;
using System.Text;

namespace Frontend.Views.Paginas;

public partial class PagObtenerElMetodoAnticoncepEnUso : ContentPage
{
    string api = "https://webapiciclica.azurewebsites.net/api/";
    string LocalApi = "https://localhost:44365/api/";

    private ListaHistorial viewModel;
	public PagObtenerElMetodoAnticoncepEnUso()
	{
		InitializeComponent();
        viewModel = new ListaHistorial();
        BindingContext = viewModel;

        // Asigna el ID del anticonceptivo
        int idAnticonceptivo = ObtenerDatosAEnviar.IdAnticoncep;
        viewModel.Imagen = viewModel.ObtenerRutaImagen(idAnticonceptivo);
    }
    private void BTN_RegresarDelMetodoEnUso_Clicked(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }

    private async void BTN_SuspenderMetodo_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (ObtenerDatosAEnviar.Session == null)
            {
                await DisplayAlert("Advertencia", "No hay una session", "Ok");
                return;
            }
            else
            {
                ReqActualizarNotificaciones reqActualizarNotificaciones = new ReqActualizarNotificaciones();
                reqActualizarNotificaciones.session = ObtenerDatosAEnviar.Session;

                var jsonContent = new StringContent(JsonConvert.SerializeObject(reqActualizarNotificaciones), Encoding.UTF8, "application/json");
                HttpClient httpClient = new HttpClient();
                var response = await httpClient.PostAsync(api + "Notificaciones/actualizarNotificaciones", jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    ResActualizarNotificaciones resActualziarNotificaciones = new ResActualizarNotificaciones();
                    var responseContent = await response.Content.ReadAsStringAsync();
                    resActualziarNotificaciones = JsonConvert.DeserializeObject<ResActualizarNotificaciones>(responseContent);
                    if (resActualziarNotificaciones.errorCode == 0 && resActualziarNotificaciones.resultado == true)
                    {
                        await DisplayAlert("EXITO", "El metodo fue suspendido", "Ok");
                        await Navigation.PushAsync(new MetodosAnticonceptivos());
                    }
                    else if (resActualziarNotificaciones.errorCode == 22)
                    {
                        await Navigation.PushAsync(new MetodosAnticonceptivos());
                    }
                }
                else
                {
                    await DisplayAlert("NO HUBO RESPUESTA", "", "Ok");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            await DisplayAlert("Error", "Error interno", "OK");
        }
        
        //Navigation.PushAsync(new MetodosAnticonceptivos());
    }
}