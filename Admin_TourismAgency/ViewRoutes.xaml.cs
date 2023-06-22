using System.Linq;
using System.Windows;

namespace Admin_TourismAgency
{
    /// <summary>
    /// Логика взаимодействия для ViewRoutes.xaml
    /// </summary>
    public partial class ViewRoutes : Window
    {
        public ViewRoutes()
        {
            InitializeComponent();

            // вытаскиваем БД -> вытаскивам маршруты из БД -> запись в таблицу _DataGrid
            _DataGrid.ItemsSource = (new TourismAgencyEntities()).МАРШРУТЫ.ToList();
        }
    }
}
