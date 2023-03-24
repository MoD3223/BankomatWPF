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
    /// Interaction logic for Haslo.xaml
    /// </summary>
    public partial class Haslo : Page
    {
        public Haslo()
        {
            InitializeComponent();
            txtBoxHaslo.TextAlignment = TextAlignment.Right;
        }
        int x = 0;
        private void Bledy()
        {
            if (x<3)
            {
                x += 1;
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void btnPowrot_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.NavS.GoBack();
        }

        public void UsunLitery()
        {
            String tekst;
            tekst = txtBoxHaslo.Text.ToString();
            tekst = Regex.Replace(tekst, "[^0-9]", "");
            txtBoxHaslo.Text = tekst;
        }

        private void txtBoxHaslo_TextChanged(object sender, TextChangedEventArgs e)
        {
            UsunLitery();
            txtBoxHaslo.SelectionStart = txtBoxHaslo.Text.Length;
        }

        private void btnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if (txtBoxHaslo.Text == "1111")
            {
                txtBoxHaslo.Text = String.Empty;
                Log.ZapiszLog("Logowanie", $"{MainWindow.DzisiejszaData()} Udana proba zalogowania");
                MainWindow.NavS.Navigate(new Uri("PanelAdministracyjny.xaml", UriKind.Relative));
            }
            else
            {
                txtBoxHaslo.Text = String.Empty;
                Log.log = $"Nieudana proba logowania, pozostalo prob {3-x}";
                Log.ZapiszLog("Logowanie", $"{MainWindow.DzisiejszaData()} {Log.log}");
                Log.log = String.Empty;
                Bledy();
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            txtBoxHaslo.Text += 1;
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            txtBoxHaslo.Text += 2;
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            txtBoxHaslo.Text += 3;
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            txtBoxHaslo.Text += 4;
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            txtBoxHaslo.Text += 5;
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            txtBoxHaslo.Text += 6;
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            txtBoxHaslo.Text += 7;
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            txtBoxHaslo.Text += 8;
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            txtBoxHaslo.Text += 9;
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            txtBoxHaslo.Text += 0;
        }

        private void btnCofnij_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtBoxHaslo.Text))
            {

            }
            else
            {
               txtBoxHaslo.Text = txtBoxHaslo.Text.Substring(0, txtBoxHaslo.Text.Length-1);
            }
        }
    }
}
