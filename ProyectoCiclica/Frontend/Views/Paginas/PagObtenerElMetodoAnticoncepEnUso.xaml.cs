namespace Frontend.Views.Paginas;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;

public partial class PagObtenerElMetodoAnticoncepEnUso : ContentPage
{
	public PagObtenerElMetodoAnticoncepEnUso()
	{
		InitializeComponent();
	}

    private void BTN_RegresarDelMetodoEnUso_Clicked(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }

    private void BTN_SuspenderMetodo_Clicked(object sender, EventArgs e)
    {

    }
}