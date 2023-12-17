namespace Frontend.Views.Paginas;

using Frontend.Models;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;
using Frontend.Entidades;
using Frontend.CapturarDatos;

public partial class PagHistorialAnticoncep : ContentPage
{
	public PagHistorialAnticoncep()
	{
        var listaHistorials = ObtenerDatosAEnviar.historialAnticoncep;
		InitializeComponent();
		listaHistorials = new List<Notifi_Anticonceptivos>()
		{
			new Notifi_Anticonceptivos()
			{
				Anti_Concep_Nombre = "",
				Notifi_Start_Date = DateTime.Now,
				Notifi_Fecha_Final = DateTime.Today,
            },
        };

        this.BindingContext = this;
	}

    private void BTN_RegresarDeHistorial_Clicked(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }
}