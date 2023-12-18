using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using Frontend.Models;
using Frontend.Views.Paginas;
using Frontend.Entidades;
using static System.Runtime.InteropServices.JavaScript.JSType;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;
using Frontend.CapturarDatos;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace Frontend.Views;

public partial class VistaPrincipal : ContentPage
{
    string api = "https://webapiciclica.azurewebsites.net/api/";
    string LocalApi = "https://localhost:44365/api/";

    #region BindableProperty
    public static readonly BindableProperty SelectedDateProperty = BindableProperty.Create(
        nameof(SelectedDate),
        typeof(DateTime),
        declaringType: typeof(VistaPrincipal),
        defaultBindingMode: BindingMode.TwoWay,
        defaultValue: DateTime.Now,
        propertyChanged: SelectedDatePropertyChanged
        );
    private static void SelectedDatePropertyChanged(BindableObject bindable, object oldValue, object newValue) 
    {
        var controls = (VistaPrincipal)bindable;
        if (newValue != null) 
        {
            var newDate = (DateTime)newValue;

            if (controls._tempDate.Month == newDate.Month && controls._tempDate.Year == newDate.Year) 
            {
                var currentDate = controls.Dates.Where(f => f.Date == newDate.Date).FirstOrDefault();
                if (currentDate != null)
                {
                    controls.Dates.ToList().ForEach(f => f.IsCurrentDate = false);
                    currentDate.IsCurrentDate = true;
                }
            }
            else
            {
                controls.BindDates(newDate);
            }  
        }
    }
    public DateTime SelectedDate
    {
        get => (DateTime)GetValue(SelectedDateProperty);
        set => SetValue(SelectedDateProperty, value);
    }

    private DateTime _tempDate;
    #endregion
    public ObservableCollection<CalendarModel> Dates { get; set; } = new ObservableCollection<CalendarModel>();
    public VistaPrincipal()
    {
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-ES");
        InitializeComponent();
        BindDates(DateTime.Now);
        NavigationPage.SetHasNavigationBar(this, false);

        // Obtener la lista de Consejos desde la variable global
        var consejosMostrar = ObtenerDatosAEnviar.consejos;

        // Asignar la lista al origen de datos del CollectionView
        Pesta�aConsej.ItemsSource = consejosMostrar;
    }
    private void BindDates(DateTime date)
    {
        Dates.Clear();
        int daysCount = DateTime.DaysInMonth(date.Year, date.Month);

        for (int day = 1; day <= daysCount; day++)
        {
            Dates.Add(new CalendarModel
            {
                Date = new DateTime(date.Year, date.Month, day)
            });
        }

        var selectedDate = Dates.Where(f => f.Date.Date == SelectedDate.Date).FirstOrDefault();
        if (selectedDate != null) 
        {
            selectedDate.IsCurrentDate = true;
            _tempDate = selectedDate.Date;
        }
    }

    #region Commands
    public ICommand CurrentDateCommand => new Command<CalendarModel>((currentDate) =>
    {
        _tempDate = currentDate.Date;
        SelectedDate = currentDate.Date;
    });

    public ICommand NextMonthCommand => new Command(() =>
    {
        _tempDate = _tempDate.AddMonths(1);
        BindDates(_tempDate);
    });

    public ICommand PreviousMonthCommand => new Command(() =>
    {
        _tempDate = _tempDate.AddMonths(-1);
        BindDates(_tempDate);
    });

    #endregion

    private void BTN_RegistroDiario_Clicked(object sender, EventArgs e)
    {
       
    }

    private void BTN_RegistroCiclo_Clicked(object sender, EventArgs e)
    {
       
    }
    private async void BTN_SaludSexual_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (ObtenerDatosAEnviar.Session == null)
            {
                await DisplayAlert("Advertencia", "No hay una session", "Ok");
                await Navigation.PushAsync(new LogCiclica());
            }
            else
            {
                // Crear la solicitud para la API
                ReqObtenerAnticonceptivos reqObtenerAnticonceptivo = new ReqObtenerAnticonceptivos();
                reqObtenerAnticonceptivo.session = ObtenerDatosAEnviar.Session;

                // Crear una instancia del cliente de la API
                var jsonContent = new StringContent(JsonConvert.SerializeObject(reqObtenerAnticonceptivo), Encoding.UTF8, "application/json");
                HttpClient httpClient = new HttpClient();

                // Llamar al m�todo de la API y esperar la respuesta
                var response = await httpClient.PostAsync(api + "Anticonceptivos/obtenerAnticonceptivos", jsonContent);
                // Verificar el resultado de la API
                if (response.IsSuccessStatusCode)
                {
                    ResObtenerAnticonceptivos resObtenerAnticonceptivos = new ResObtenerAnticonceptivos();
                    var responseContent = await response.Content.ReadAsStringAsync();
                    resObtenerAnticonceptivos = JsonConvert.DeserializeObject<ResObtenerAnticonceptivos>(responseContent);
                    if (resObtenerAnticonceptivos.errorCode == 0 && resObtenerAnticonceptivos.resultado == true)
                    {
                        ObtenerDatosAEnviar.anticonceptivos = resObtenerAnticonceptivos.ListaDeAnticoncepDatos;
                        await Navigation.PushAsync(new PagObtenerElMetodoAnticoncepEnUso());
                    }
                    else if (resObtenerAnticonceptivos.errorCode == 22)
                    {
                        ObtenerDatosAEnviar.anticonceptivos = resObtenerAnticonceptivos.ListaDeAnticoncepDatos;
                        await Navigation.PushAsync(new MetodosAnticonceptivos());
                    }
                    else if (resObtenerAnticonceptivos.errorCode == 23)
                    {
                        ObtenerDatosAEnviar.anticonceptivos = resObtenerAnticonceptivos.ListaDeAnticoncepDatos;
                        await Navigation.PushAsync(new MetodosAnticonceptivos());
                    }
                }
                else
                {
                    // La llamada a la API no fue exitosa, puedes manejar el error seg�n tus necesidades
                    await DisplayAlert("NO HUBO RESPUESTA", "", "Ok");
                }
            }
            
        }
        catch (Exception ex)
        {
            // Manejar cualquier excepci�n inesperada
            Console.WriteLine($"Error: {ex.Message}");
            await DisplayAlert("Error", "Error interno", "OK");
        }
        //Navigation.PushAsync(new MetodosAnticonceptivos());
    }

    private void BTN_HistorialCicloMenstual_Clicked(object sender, EventArgs e)
    {
    }

    private void BTN_OcultarConsejo_Clicked(object sender, EventArgs e)
    {
        Pesta�aConsejos.IsVisible = false;
    }
}