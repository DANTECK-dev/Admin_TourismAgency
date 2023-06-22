using System.Linq;
using System.Windows;

namespace Admin_TourismAgency
{
    /// <summary>
    /// Логика взаимодействия для ViewTrips.xaml
    /// </summary>
    public partial class ViewTrips : Window
    {
        public ViewTrips()
        {
            InitializeComponent();

            // вытаскиваем БД -> вытаскиваем поездки из БД -> запись в таблицу _DataGrid
            _DataGrid.ItemsSource = (new TourismAgencyEntities()).ПОЕЗДКИ.ToList();
        }
    }
}
