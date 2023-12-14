using Frontend.CapturarDatos;
using Frontend.Entidades;
using Frontend.Models;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;

namespace Frontend.Views.Paginas;

public partial class MetodosAnticonceptivos : ContentPage
{
    public List<Anticonceptivos> ListaAnticonceptivos { get; set; } = new List<Anticonceptivos>
    {
        new Anticonceptivos { Anti_Concep_ID = 1, Anti_Concep_Nombre = "Pastillas anticonceptivas", Anti_Concep_Imagen = "pastillas_anticonceptivas.png" },
        new Anticonceptivos { Anti_Concep_ID = 2, Anti_Concep_Nombre = "Inyeccion", Anti_Concep_Imagen = "inyeccion.png" },
        new Anticonceptivos { Anti_Concep_ID = 3, Anti_Concep_Nombre = "DIU", Anti_Concep_Imagen = "diu.png" },
        new Anticonceptivos { Anti_Concep_ID = 4, Anti_Concep_Nombre = "Parche", Anti_Concep_Imagen = "parche.png" },
        new Anticonceptivos { Anti_Concep_ID = 5, Anti_Concep_Nombre = "Implante", Anti_Concep_Imagen = "implante.png" },
        new Anticonceptivos { Anti_Concep_ID = 6, Anti_Concep_Nombre = "Anillo", Anti_Concep_Imagen = "anillo.png" },
    };
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
        var clickedButton = (ImageButton)sender;
        int anticonceptivoId = 1;
        var anticonceptivo = ListaAnticonceptivos.FirstOrDefault(a => a.Anti_Concep_ID == anticonceptivoId);

        // Almacena el ID y la ruta de la imagen en las variables globales
        ObtenerDatosAEnviar.IdAnticoncep = anticonceptivo.Anti_Concep_ID;
        ObtenerDatosAEnviar.ImagenAnticoncep = anticonceptivo.Anti_Concep_Imagen;

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