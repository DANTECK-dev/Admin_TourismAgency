using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            _DataGrid.ItemsSource = (new TourismAgencyEntities()).ПОЕЗДКИ.ToList();
        }
    }
}
