using Frontend.CapturarDatos;
using Frontend.Entidades;
using Newtonsoft.Json;
using System.Text;
using Frontend.Models;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;

namespace Frontend.Views.Paginas;

public partial class MetodosAnticonceptivos : ContentPage
{
    string api = "https://webapiciclica.azurewebsites.net/api/";
    string LocalApi = "https://localhost:44365/api/";
    public MetodosAnticonceptivos()
	{
		InitializeComponent();
	}
    private void BTN_RegresarDeAnticonceptivos_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void BTN_PastillasAnticonceptivas_Clicked(object sender, EventArgs e)
    {
        // Asigno una variable igual al ID del anticonceptivo
        int anticonceptivoId = 1;

        // Almacena el ID en las variables globales
        ObtenerDatosAEnviar.IdAnticoncep = anticonceptivoId;

        // Almacena el ID de la imagen en en las variables globales
        ImageButton BTN_PastillasAnticonceptivas = (ImageButton)sender;
        string idDePastillasAnticonceptivas = BTN_PastillasAnticonceptivas.AutomationId;
        ObtenerDatosAEnviar.ImagenAnticoncep = idDePastillasAnticonceptivas;

        // Continua con la navegacion de paginas
        Navigation.PushAsync(new AnticoncepFechaYHora());
    }

    private void BTN_Inyeccion_Clicked(object sender, EventArgs e)
    {
        // Asigna un valor entero al ImageButton
        int valor = 2;

        // Almacena el valor en la clase estática
        ObtenerDatosAEnviar.IdAnticoncep = valor;

        // Continua con el registro
        Navigation.PushAsync(new AnticoncepFechaYHora());
    }

    private void BTN_Diu_Clicked(object sender, EventArgs e)
    {
        // Asigna un valor entero al ImageButton
        int valor = 3;

        // Almacena el valor en la clase estática
        ObtenerDatosAEnviar.IdAnticoncep = valor;

        // Continua con el registro
        Navigation.PushAsync(new AnticoncepFechaYHora());
    }

    private void BTN_Parche_Clicked(object sender, EventArgs e)
    {
        // Asigna un valor entero al ImageButton
        int valor = 4;

        // Almacena el valor en la clase estática
        ObtenerDatosAEnviar.IdAnticoncep = valor;

        // Continua con el registro
        Navigation.PushAsync(new AnticoncepFechaYHora());
    }

    private void BTN_Implante_Clicked(object sender, EventArgs e)
    {
        // Asigna un valor entero al ImageButton
        int valor = 5;

        // Almacena el valor en la clase estática
        ObtenerDatosAEnviar.IdAnticoncep = valor;

        // Continua con el registro
        Navigation.PushAsync(new AnticoncepFechaYHora());
    }

    private void BTN_Anillo_Clicked(object sender, EventArgs e)
    {
        // Asigna un valor entero al ImageButton
        int valor = 6;

        // Almacena el valor en la clase estática
        ObtenerDatosAEnviar.IdAnticoncep = valor;

        // Continua con el registro
        Navigation.PushAsync(new AnticoncepFechaYHora());
    }

    private async void BTN_HistorialAnticonceptivo_Clicked(object sender, EventArgs e)
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
                ReqHistorialAnticonceptivos reqHistorialAnticonceptivos = new ReqHistorialAnticonceptivos();
                reqHistorialAnticonceptivos.session = ObtenerDatosAEnviar.Session;

                var jsonContent = new StringContent(JsonConvert.SerializeObject(reqHistorialAnticonceptivos), Encoding.UTF8, "application/json");
                HttpClient httpClient = new HttpClient();
                var response = await httpClient.PostAsync(LocalApi + "Notifi_Anticonceptivos/historialAnticonceptivos", jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    ResHistorialAnticonceptivos resHistorialAnticonceptivos = new ResHistorialAnticonceptivos();
                    var responseContent = await response.Content.ReadAsStringAsync();
                    resHistorialAnticonceptivos = JsonConvert.DeserializeObject<ResHistorialAnticonceptivos>(responseContent);
                    if (resHistorialAnticonceptivos.errorCode == 0)
                    {
                        ObtenerDatosAEnviar.historialAnticoncep = resHistorialAnticonceptivos.HistorialAnticonceptivo;
                        await DisplayAlert("FUNCIONAAAAAAA", "", "Ok");
                        await Navigation.PushAsync(new PagHistorialAnticoncep());
                    }
                    else if (resHistorialAnticonceptivos.errorCode == 23)
                    {
                        await DisplayAlert("FUNCIONAAAAAAA", "Pero no hay registro", "Ok");
                        await Navigation.PushAsync(new MetodosAnticonceptivos());
                    }
                }
                else
                {
                    await DisplayAlert("LA API NO DIO RESPUESTA CORRECTA", "", "Ok");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            await DisplayAlert("Error", "Error interno", "OK");
        }
        
    }
}