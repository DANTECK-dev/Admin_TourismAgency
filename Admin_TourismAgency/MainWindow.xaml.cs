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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Admin_TourismAgency
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _login = "RwNydpKbI@O{nk8V{7I|p2hW#%IzGxS?7fDA4R2dkb6R21rt3@Kq3KgJx8}fE2vc~VmVkKV0Q2%b?WyMSEAQSh$iqE~qkk1RH#q" +
            "jSS~5s1QXMpCN32A%$U|fLMTX$TbFG?PSasfzHkEJBeN~NEKPXE{{H$Qed$pe3ly2PnzT?L5WsGmFP}uOY*CQ0djBhO19Rx9HSkywg~xSQr47OP";
        string _password = "#I#lvGKDJMM%B2tbi4Hj}~aeNVwKB~N9~ltC$tlBiI{K|gg{1~~IlMH~nWq%}h#2*%@Xk}cg1e{Hh%EazDIjcU88v1tQYK$|" +
            "Yg@qkxB3{kG~|JV~*gRcefY$OXrOyPAn97ionSaz#VgL92~87pVjX{4G1pLgi||2C@0S$y#}dKrZ~2ai|msCnFbXwS8J1q7R2G8nB%apGtNbzv@" +
            "dtQ69b5fNMSAcFA1wO3vW$8mXNa5F6rDtHYTonmltRxanu8x?5eTYa$iLF4DFC72323LvIRbyN#K0q?|wHBdwyW#Y%2Oun@6Qd#YWMv}ldNj*fT";

        public MainWindow()
        {
            InitializeComponent();
            Login_G.Visibility = Visibility.Visible;
            Registered_G.Visibility = Visibility.Hidden;
            Login_TB.Text = "";
            Password_TB.Text = "";
        }

        private void Login_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Login_TB.Text == _login && Password_TB.Text == _password)
            {
                Login_G.Visibility = Visibility.Hidden;
                Registered_G.Visibility = Visibility.Visible;
            }
        }

        private void Password_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Login_TB.Text == _login && Password_TB.Text == _password)
            {
                Login_G.Visibility = Visibility.Hidden;
                Registered_G.Visibility = Visibility.Visible;
            }
        }

        private void OpenViewRoutes(object sender, RoutedEventArgs e)
        {
            ViewRoutes window = new ViewRoutes();
            window.Show();
        }

        private void OpenViewClients(object sender, RoutedEventArgs e)
        {
            ViewClients window = new ViewClients();
            window.Show();
        }

        private void OpenViewTrips(object sender, RoutedEventArgs e)
        {
            ViewTrips window = new ViewTrips();
            window.Show();
        }

        private void OpenEditRoutes(object sender, RoutedEventArgs e)
        {
            EditRoutes window = new EditRoutes();
            window.Show();
        }

        private void OpenEditClients(object sender, RoutedEventArgs e)
        {
            EditClients window = new EditClients();
            window.Show();
        }

        private void OpenEditTrips(object sender, RoutedEventArgs e)
        {
            EditTrips window = new EditTrips();
            window.Show();
        }

        private void OpenAddRoutes(object sender, RoutedEventArgs e)
        {
            AddRoutes window = new AddRoutes();
            window.Show();
        }

        private void OpenAddClients(object sender, RoutedEventArgs e)
        {
            AddClients window = new AddClients();
            window.Show();
        }

        private void OpenAddTrips(object sender, RoutedEventArgs e)
        {
            AddTrips window = new AddTrips();
            window.Show();
        }

        private void OpenDelRoutes(object sender, RoutedEventArgs e)
        {
            DelRoutes window = new DelRoutes();
            window.Show();
        }

        private void OpenDelClients(object sender, RoutedEventArgs e)
        {
            DelClients window = new DelClients();
            window.Show();
        }

        private void OpenDelTrips(object sender, RoutedEventArgs e)
        {
            DelTrips window = new DelTrips();
            window.Show();
        }
    }
}
