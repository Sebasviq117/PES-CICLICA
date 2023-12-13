namespace Frontend.Views.Paginas;

public partial class AnticoncepFechaYHora : ContentPage
{
	public AnticoncepFechaYHora()
	{
		InitializeComponent();
	}

    private void BTN_GuardarAnticoncep_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}