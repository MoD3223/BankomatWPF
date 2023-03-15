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

namespace BankomatWPF
{
    /// <summary>
    /// Interaction logic for GlowneOkno.xaml
    /// </summary>
    public partial class GlowneOkno : Page
    {
        public static int zmiana = 0;
        public GlowneOkno()
        {
            InitializeComponent();

        }

        private void btnWplata_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnWyplata_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.NavS.Navigate(new Uri("Wyplata.xaml", UriKind.Relative));
        }

        private void btnStanKonta_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLog_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPanel_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow.NavS.Navigate(new Uri("PanelAdministracyjny.xaml", UriKind.Relative));
        }
    }
}
