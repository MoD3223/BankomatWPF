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
    /// Logika interakcji dla klasy Wplata.xaml
    /// </summary>
    public partial class Wplata : Page
    {
        public Wplata()
        {
            InitializeComponent();
        }

        int x10 = 0;
        int x20 = 0;
        int x50 = 0;
        int x100 = 0;
        int x200 = 0;
        int x500 = 0;

        private string DoTekstu(int x)
        {
            if (x < 0)
            {
                x = 0; //Sprawdzic czy nadpisuje
                return "x" + 0;
            }


            return "x" + x;
        }



        private void btnPowrot_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.NavS.Navigate(new Uri("GlowneOkno.xaml", UriKind.Relative));
        }

        private void btn10Up_Click(object sender, RoutedEventArgs e)
        {
            x10 += 1;
            txt10Wplata.Text = DoTekstu(x10);
        }

        private void btn10Down_Click(object sender, RoutedEventArgs e)
        {
            x10 -= 1;
            txt10Wplata.Text = DoTekstu(x10);
        }

        private void btn20Up_Click(object sender, RoutedEventArgs e)
        {
            x20 += 1;
            txt20Wplata.Text = DoTekstu(x20);
        }

        private void btn50Up_Click(object sender, RoutedEventArgs e)
        {
            x50 += 1;
            txt50Wplata.Text = DoTekstu(x50);
        }

        private void btn20Down_Click(object sender, RoutedEventArgs e)
        {
            x20 -= 1;
            txt20Wplata.Text = DoTekstu(x20);
        }

        private void btn50Down_Click(object sender, RoutedEventArgs e)
        {
            x50 -= 1;
            txt50Wplata.Text = DoTekstu(x50);
        }

        private void btn100Up_Click(object sender, RoutedEventArgs e)
        {
            x100 += 1;
            txt100Wplata.Text = DoTekstu(x100);
        }

        private void btn100Down_Click(object sender, RoutedEventArgs e)
        {
            x100 -= 1;
            txt100Wplata.Text = DoTekstu(x100);
        }

        private void btn200Up_Click(object sender, RoutedEventArgs e)
        {
            x200 += 1;
            txt200Wplata.Text = DoTekstu(x200);
        }

        private void btn200Down_Click(object sender, RoutedEventArgs e)
        {
            x200 -= 1;
            txt200Wplata.Text = DoTekstu(x200);
        }

        private void btn500Up_Click(object sender, RoutedEventArgs e)
        {
            x500 += 1;
            txt500Wplata.Text = DoTekstu(x500);
        }

        private void btn500Down_Click(object sender, RoutedEventArgs e)
        {
            x500 -= 1;
            txt500Wplata.Text = DoTekstu(x500);
        }

        private void btnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.banknoty[10] += x10;
            MainWindow.banknoty[20] += x20;
            MainWindow.banknoty[50] += x50;
            MainWindow.banknoty[100] += x100;
            MainWindow.banknoty[200] += x200;
            MainWindow.banknoty[500] += x500;

            if (x10 == 0 && x20 == 0 && x50 == 0 && x100 == 0 && x200 == 0 && x500 == 0)
            {
                //Nic
            }
            else
            {
                Log.log = $"Wplacono {x10}x10PLN, {x20}x20PLN, {x50}x50PLN, {x100}x100PLN, {x200}x200PLN, {x500}x500 PLN";
                Log.ZapiszLog("Wplata", $"{MainWindow.DzisiejszaData()} {Log.log}");
                MainWindow.SaveDictionaryToLog();
                MainWindow.NavS.Navigate(new Uri("Sukces.xaml", UriKind.Relative));
            }


        }
    }
}
