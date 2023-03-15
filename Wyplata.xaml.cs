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
            MainWindow.NavS.Navigate(new Uri("GlowneOkno.xaml", UriKind.Relative));
        }

        private void btnZatwierdz_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtBoxWyplata_TextChanged(object sender, TextChangedEventArgs e)
        {
            UsunLitery();
            int x = Int32.Parse(txtBoxWyplata.Text);
            
        }
    }
}
