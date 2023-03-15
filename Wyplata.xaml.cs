using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logika interakcji dla klasy Wyplata.xaml
    /// </summary>
    public partial class Wyplata : Page
    {
        Decimal x;
        public Wyplata()
        {
            InitializeComponent();
        }

        private void UsunLitery()
        {
            String tekst;
            tekst = txtBoxWyplata.Text.ToString();
            tekst = Regex.Replace(tekst, "[^0-9]", "");
            txtBoxWyplata.Text = tekst;
            txtBoxWyplata.SelectionStart = txtBoxWyplata.Text.Length;
        }

        private void btnPowrot_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.NavS.GoBack();
        }

        private void btnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if (x%10 == 0)
            {

            }
            else
            {

            }
        }

        private void txtBoxWyplata_TextChanged(object sender, TextChangedEventArgs e)
        {
            UsunLitery();
            if (!Decimal.TryParse(txtBoxWyplata.Text,out x))
            {
                txtBoxWyplata.Text = String.Empty;
                MainWindow.NavS.Navigate(new Uri("Blad.xaml",UriKind.Relative));
            }
            else
            {
                x = Decimal.Parse(txtBoxWyplata.Text);
            }
            
        }
    }
}
