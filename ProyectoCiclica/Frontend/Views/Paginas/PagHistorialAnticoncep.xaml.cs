namespace Frontend.Views.Paginas;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;
public partial class PagHistorialAnticoncep : ContentPage
{
	public PagHistorialAnticoncep()
	{
		InitializeComponent();
	}

    private void BTN_RegresarDeHistorial_Clicked(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }
}