namespace Frontend.Views.Paginas;

using Frontend.Models;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;
using Frontend.Entidades;
using Frontend.CapturarDatos;
using Microsoft.Maui.Controls;

public partial class PagHistorialAnticoncep : ContentPage
{
	public PagHistorialAnticoncep()
	{
		InitializeComponent();

        // Obtener la lista de historialAnticoncep desde la variable global
        var historialAnticoncep = ObtenerDatosAEnviar.historialAnticoncep;

        foreach (var anticonceptivo in historialAnticoncep)
        {
            // Ajusta la l�gica de nombres de imagen seg�n tus necesidades
            anticonceptivo.RutaImagen = ObtenerRutaImagen(anticonceptivo.Anti_Concep_Nombre);
        }

        // Asignar la lista al origen de datos del CollectionView
        DatosDelHistorial.ItemsSource = historialAnticoncep;
    }
        // Funci�n para obtener la ruta de la imagen seg�n el nombre del anticonceptivo
    private string ObtenerRutaImagen(string nombreAnticonceptivo)
    {
        // Ajusta esto seg�n la l�gica de c�mo se asignan las rutas de las im�genes
        return $"Resourses/Images/{nombreAnticonceptivo.ToLower().Replace(" ", "_")}.png";
    }

    private void BTN_RegresarDeHistorial_Clicked(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }
}