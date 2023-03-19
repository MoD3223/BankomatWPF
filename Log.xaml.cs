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
using System.IO;
using System.Xml.Linq;
using System.Xml;

namespace BankomatWPF
{
    /// <summary>
    /// Logika interakcji dla klasy Log.xaml
    /// </summary>
    public partial class Log : Page
    {


        public static string log = String.Empty;
        
        public Log()
        {
            InitializeComponent();
        }

        public static void ZapiszLog(string nazwa,string text)
        {
            XmlNode logNode = MainWindow.doc.SelectSingleNode("/Root/Log");
            XmlNode entryNode = MainWindow.doc.CreateElement(nazwa);
            entryNode.InnerText = text;
            logNode.AppendChild(entryNode);
            MainWindow.doc.Save("Log.xml");
        }

        private void btnPowrot_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.NavS.GoBack();
        }

        private void btnWyczysc_Click(object sender, RoutedEventArgs e)
        {
            string filePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Log.xml");
            MainWindow.doc.RemoveAll();
            MainWindow.StworzPlik(MainWindow.doc);
            MainWindow.doc.Load("Log.xml");
        }

        private void btnPokaz_Click(object sender, RoutedEventArgs e)
        {
            string folderPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            System.Diagnostics.Process.Start(folderPath);
        }
    }
}
