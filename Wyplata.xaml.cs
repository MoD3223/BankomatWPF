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
        int x = 0;
        public Wyplata()
        {
            InitializeComponent();
        }


        private void btnPowrot_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.NavS.GoBack();
        }

        private void btnZatwierdz_Click(object sender, RoutedEventArgs e)
        {

            if (x == 0)
            {

            }
            else
            {
                Log.log = MainWindow.Start(x, Log.log);
                //
                if (String.IsNullOrEmpty(Log.log))
                {
                    MainWindow.NavS.Navigate(new Uri("Blad.xaml", UriKind.Relative));
                    Log.log = $"Blad przy wyplacaniu pieniedzy. Probowano wyplacic {x}PLN.";
                    Log.ZapiszLog("Blad", MainWindow.DzisiejszaData() + $" {Log.log} Sprawdz stan banknotow!");
                }
                else
                {

                    Log.ZapiszLog("Wyplata",$"{MainWindow.DzisiejszaData()} Wyplacono {x}PLN {Log.log}");
                    MainWindow.SaveDictionaryToLog();
                    MainWindow.NavS.Navigate(new Uri("Sukces.xaml", UriKind.Relative));
                }
            }


        }

        private void btn10Up_Click(object sender, RoutedEventArgs e)
        {
            x += 10;
            
            txtBoxKwota.Text = x.ToString() + " PLN";
        }

        private void btn10Down_Click(object sender, RoutedEventArgs e)
        {
            x -= 10;
            SprawdzZero();
            txtBoxKwota.Text = x.ToString() + " PLN";
        }

        private void btn20Down_Click(object sender, RoutedEventArgs e)
        {
            x -= 20;
            SprawdzZero();
            txtBoxKwota.Text = x.ToString() + " PLN";
        }

        private void btn50Down_Click(object sender, RoutedEventArgs e)
        {
            x -= 50;
            SprawdzZero();
            txtBoxKwota.Text = x.ToString() + " PLN";
        }

        private void btn100Down_Click(object sender, RoutedEventArgs e)
        {
            x -= 100;
            SprawdzZero();
            txtBoxKwota.Text = x.ToString() + " PLN";
        }

        private void btn200Down_Click(object sender, RoutedEventArgs e)
        {
            x -= 200;
            SprawdzZero();
            txtBoxKwota.Text = x.ToString() + " PLN";
        }

        private void btn500Down_Click(object sender, RoutedEventArgs e)
        {
            x -= 500;
            SprawdzZero();
            txtBoxKwota.Text = x.ToString() + " PLN";
        }

        private void btn20Up_Click(object sender, RoutedEventArgs e)
        {
            x += 20;
            txtBoxKwota.Text = x.ToString() + " PLN";
        }

        private void btn50Up_Click(object sender, RoutedEventArgs e)
        {
            x += 50;
            txtBoxKwota.Text = x.ToString() + " PLN";
        }

        private void btn100Up_Click(object sender, RoutedEventArgs e)
        {
            x += 100;
            txtBoxKwota.Text = x.ToString() + " PLN";
        }

        private void btn200Up_Click(object sender, RoutedEventArgs e)
        {
            x += 200;
            txtBoxKwota.Text = x.ToString() + " PLN";
        }

        private void btn500Up_Click(object sender, RoutedEventArgs e)
        {
            x += 500;
            txtBoxKwota.Text = x.ToString() + " PLN";
        }

        private void SprawdzZero()
        {
            if (x < 0)
            {
                x = 0;
            }
        }
    }
}
