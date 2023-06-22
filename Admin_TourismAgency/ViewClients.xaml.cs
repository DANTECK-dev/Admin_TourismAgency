using System.Linq;
using System.Windows;

namespace Admin_TourismAgency
{
    /// <summary>
    /// Логика взаимодействия для ViewClients.xaml
    /// </summary>
    public partial class ViewClients : Window
    {
        public ViewClients()
        {
            InitializeComponent();

            // вытаскиваем БД -> вытаскиваем клиентов из БД -> запись в таблицу _DataGrid
            _DataGrid.ItemsSource = (new TourismAgencyEntities()).КЛИЕНТЫ.ToList();
        }
    }
}
