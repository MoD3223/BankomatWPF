﻿using System;
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
    /// Interaction logic for PanelAdministracyjny.xaml
    /// </summary>
    public partial class PanelAdministracyjny : Page
    {
        public PanelAdministracyjny()
        {
            InitializeComponent();
        }

        private void btnPowrot_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.NavS.GoBack();
        }

        private void btnZeruj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLog_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
