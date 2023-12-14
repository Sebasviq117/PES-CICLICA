namespace Frontend.Views.Paginas;

using Frontend.Models;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;
public partial class PagHistorialAnticoncep : ContentPage
{
	public List<ListaHistorial> listaHistorials { get; set; }
	public PagHistorialAnticoncep()
	{
		InitializeComponent();
		this.listaHistorials = new List<ListaHistorial>()
		{
			new ListaHistorial()
			{
				Nombre = "Pastillas Anticonceptivas",
                Imagen = "pastillas_anticonceptivas.png",
				FechaInicio = null,
				FechaFinal = null
            },
            new ListaHistorial()
            {
                Nombre = "Inyeccion",
                Imagen = "inyeccion.png",
                FechaInicio = null,
                FechaFinal = null
            },
            new ListaHistorial()
            {
                Nombre = "DIU",
                Imagen = "diu.png",
                FechaInicio = null,
                FechaFinal = null
            },
            new ListaHistorial()
            {
                Nombre = "Parche",
                Imagen = "parche.png",
                FechaInicio = null,
                FechaFinal = null
            },
            new ListaHistorial()
            {
                Nombre = "Implante",
                Imagen = "implante.png",
                FechaInicio = null,
                FechaFinal = null
            }
        };

        this.BindingContext = this;
	}

    private void BTN_RegresarDeHistorial_Clicked(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }
}