using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using Frontend.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Frontend.Views;

public partial class VistaPrincipal : ContentPage
{
    #region BindableProperty
    public static readonly BindableProperty SelectedDateProperty = BindableProperty.Create(
        nameof(SelectedDate),
        typeof(DateTime),
        declaringType: typeof(VistaPrincipal),
        defaultBindingMode: BindingMode.TwoWay,
        defaultValue: DateTime.Now
        );
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

    private void ImageButton_calendario(object sender, EventArgs e)
    {

    }

    private void ImageButton_tienda(object sender, EventArgs e)
    {

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
        Dates.ToList().ForEach(f => f.IsCurrentDate = false);
        currentDate.IsCurrentDate = true; 
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
}