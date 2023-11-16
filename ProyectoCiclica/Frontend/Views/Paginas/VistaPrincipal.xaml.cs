using System.Globalization;

namespace Frontend.Views;

public partial class VistaPrincipal : ContentPage
{
	public VistaPrincipal()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private void ImageButton_calendario(object sender, EventArgs e)
    {

    }

    private void ImageButton_tienda(object sender, EventArgs e)
    {

    }

    private void CalendarView_DateSelectionChanged(object sender, EventArgs e)
    {
        DisplayAlert("Date change", Calendar.CurrentEra.ToString(), "Ok");
    }
}