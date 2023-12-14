using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using Frontend.Models;
using Frontend.Views.Paginas;
using static System.Runtime.InteropServices.JavaScript.JSType;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;

namespace Frontend.Views;

public partial class VistaPrincipal : ContentPage
{
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
        InitializeComponent();
        BindDates(DateTime.Now);
        NavigationPage.SetHasNavigationBar(this, false);
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
        Navigation.PushAsync(new RegCiclica());
    }

    private void BTN_RegistroCiclo_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RegCiclica());
    }

    private void BTN_SaludSexual_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MetodosAnticonceptivos());
    }

    private void BTN_HistorialCicloMenstual_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RegCiclica());
    }

    private void BTN_OcultarConsejo_Clicked(object sender, EventArgs e)
    {
        PestañaConsejos.IsVisible = false;
    }
}