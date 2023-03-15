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
using System.IO;
using System.Xml.Linq;

namespace BankomatWPF
{
    /// <summary>
    /// Logika interakcji dla klasy Log.xaml
    /// </summary>
    public partial class Log : Page
    {




        public static XDocument xmlDokument = XDocument.Load("Log.xml");
        public static XElement largeTextElement = xmlDokument.Element("Log");
        
        public Log()
        {
            InitializeComponent();
        }

        public void ZapiszLog()
        {
            Log.xmlDokument.Save("Log.xml");
        }

        private void btnPowrot_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.NavS.GoBack();
        }

        private void btnWyczysc_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
