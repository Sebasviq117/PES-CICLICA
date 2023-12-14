using Frontend.CapturarDatos;
using Frontend.Entidades;
using Frontend.Models;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;

namespace Frontend.Views.Paginas;

public partial class MetodosAnticonceptivos : ContentPage
{
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
        // Asigna un valor entero al ImageButton
        int valor = 1;

        // Almacena el valor en la clase estática
        ObtenerDatosAEnviar.IdAnticoncep = valor;

        // Continua con el registro
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

    private void BTN_HistorialAnticonceptivo_Clicked(object sender, EventArgs e)
    {
        // Pasa a la pagina de Mostrar el Historial
        Navigation.PushAsync(new PagHistorialAnticoncep());
    }
}