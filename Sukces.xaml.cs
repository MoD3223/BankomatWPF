using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Sukces.xaml
    /// </summary>
    public partial class Sukces : Page
    {
        public Sukces()
        {
            InitializeComponent();
            txtLog.Text = Log.log;
        }

        private void btnPowrot_Click(object sender, RoutedEventArgs e)
        {
            Log.log = String.Empty;
            MainWindow.NavS.GoBack();
        }
    }
}
