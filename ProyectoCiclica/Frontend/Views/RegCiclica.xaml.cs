namespace Frontend.Views;

public partial class RegCiclica : ContentPage
{
	public RegCiclica()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private void ButtonIniciarSesion(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}