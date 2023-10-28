namespace Frontend.Views;

public partial class LogCiclica : ContentPage
{
	public LogCiclica()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }
    private void BtnRegistrar_Clicked(object sender, EventArgs e)
    {
      Navigation.PushAsync(new RegCiclica());
        
        //1.crear entidad
        //2.Crear la conexion con el api.json
        //3.Cerializar la entidad a json (Newtonsoft)
        //4.Ejecutar el json con el api
        //5.Recibir respuesta    
    }
}