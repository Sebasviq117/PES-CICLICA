using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;
using Frontend.Entidades;
using Frontend.Models;
using Frontend.CapturarDatos;

namespace Frontend.Views.Paginas;


public partial class AnticoncepFechaYHora : ContentPage
{
	public AnticoncepFechaYHora()
	{
        InitializeComponent();
	}
    private void BTN_RegresarDeFechaYHora_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
    private void BTN_GuardarNotifi_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}