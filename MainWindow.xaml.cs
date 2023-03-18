using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;

namespace BankomatWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    {
        public static NavigationService NavS => ((MainWindow)Application.Current.MainWindow).MainFrame.NavigationService;
        public static XmlDocument doc = new XmlDocument();
        public MainWindow()
        {
            InitializeComponent();
            NavS.Navigate(new Uri("GlowneOkno.xaml",UriKind.Relative));

            
            if (!File.Exists("Log.xml"))
            {

                XmlDeclaration xmlDecl = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(xmlDecl);

                XmlElement rootElem = doc.CreateElement("Root");
                doc.AppendChild(rootElem);

                XmlElement banknotyElem = doc.CreateElement("BanknotyXML");
                rootElem.AppendChild(banknotyElem);

                AddNumberElement(doc, banknotyElem, "number1", "500,10");
                AddNumberElement(doc, banknotyElem, "number2", "200,10");
                AddNumberElement(doc, banknotyElem, "number3", "100,10");
                AddNumberElement(doc, banknotyElem, "number4", "50,10");
                AddNumberElement(doc, banknotyElem, "number5", "20,10");
                AddNumberElement(doc, banknotyElem, "number6", "10,10");

                XmlElement logElem = doc.CreateElement("Log");
                rootElem.AppendChild(logElem);


                doc.Save("Log.xml");
            }
            else
            {
                doc.Load("Log.xml");
            }
            LoadDictionaryFromLog();
        }
        public static string DzisiejszaData()
        {
            return DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        }

        public static Dictionary<int, int> banknoty = new Dictionary<int, int>()
        {
            //celowo zostawione puste!
        };



        public static void LoadDictionaryFromLog()
        {
            XmlNodeList nodes = doc.SelectNodes("/Root//BanknotyXML/*");
            foreach (XmlNode node in nodes)
            {
                string[] values = node.InnerText.Split(',');
                int nominal = int.Parse(values[0].Trim());
                int count = int.Parse(values[1].Trim());
                banknoty.Add(nominal, count);
            }
        }

        public static void SaveDictionaryFromLog()
        {
            XmlNode banknotyElem = doc.SelectSingleNode("/Root/BanknotyXML");

            banknotyElem.SelectSingleNode("number1").InnerText = $"{500},{banknoty[500]}";
            banknotyElem.SelectSingleNode("number2").InnerText = $"{200},{banknoty[200]}";
            banknotyElem.SelectSingleNode("number3").InnerText = $"{100},{banknoty[100]}";
            banknotyElem.SelectSingleNode("number4").InnerText = $"{50},{banknoty[50]}";
            banknotyElem.SelectSingleNode("number5").InnerText = $"{20},{banknoty[20]}";
            banknotyElem.SelectSingleNode("number6").InnerText = $"{10},{banknoty[10]}";

            doc.Save("Log.xml");
        }


        private static void AddNumberElement(XmlDocument doc, XmlElement parentElem, string elemName, string elemValue)
        {
            XmlElement elem = doc.CreateElement(elemName);
            parentElem.AppendChild(elem);

            elem.InnerText = elemValue;
        }
        public static string Start(int doWyplacenia, string wyplataLog)
        {

            List<List<int>> possibleCombinations = GetPossibleCombinations(doWyplacenia, banknoty.Keys.ToList());

            List<int> bestCombination = FindBestCombination(possibleCombinations, banknoty);

            Updatebanknoty(bestCombination, banknoty);

            int liczba = 0;
            wyplataLog += "Wyplacono Banknoty:";
            foreach (int banknote in bestCombination)
            {
                liczba += 1;
                wyplataLog += $" {banknote} ";
            }

            if (liczba == 0)
            {
                wyplataLog = String.Empty;
            }
            return wyplataLog;
        }

        static List<List<int>> GetPossibleCombinations(int amount, List<int> denominations)
        {
            List<List<int>> possibleCombinations = new List<List<int>>();

            GetPossibleCombinationsRecursive(amount, denominations, new List<int>(), possibleCombinations);

            return possibleCombinations;
        }

        static void GetPossibleCombinationsRecursive(int amount, List<int> denominations, List<int> combination, List<List<int>> possibleCombinations)
        {
            if (amount == 0)
            {
                possibleCombinations.Add(combination);
                return;
            }

            if (denominations.Count == 0)
            {
                return;
            }

            int denomination = denominations[0];
            denominations.RemoveAt(0);

            int maxCount = amount / denomination;

            for (int i = maxCount; i >= 0; i--)
            {
                List<int> newCombination = new List<int>(combination);
                for (int j = 0; j < i; j++)
                {
                    newCombination.Add(denomination);
                }

                GetPossibleCombinationsRecursive(amount - i * denomination, new List<int>(denominations), newCombination, possibleCombinations);
            }

            denominations.Insert(0, denomination);
        }

        static List<int> FindBestCombination(List<List<int>> possibleCombinations, Dictionary<int, int> banknoty)
        {
            List<int> bestCombination = new List<int>();
            int bestScore = 0;

            foreach (List<int> combination in possibleCombinations)
            {
                int score = 0;
                bool hasAllDenominations = true;

                foreach (int denomination in combination.Distinct())
                {
                    if (banknoty.ContainsKey(denomination))
                    {
                        int count = combination.Count(x => x == denomination);
                        if (count <= banknoty[denomination])
                        {
                            score += count * (banknoty[denomination] - count + 1); // bias towards using more of the banknotes in stock
                        }
                        else
                        {
                            hasAllDenominations = false;
                            break;
                        }
                    }
                    else
                    {
                        hasAllDenominations = false;
                        break;
                    }
                }

                if (hasAllDenominations && score > bestScore)
                {
                    bestScore = score;
                    bestCombination = combination;
                }
            }

            return bestCombination;
        }


        static void Updatebanknoty(List<int> banknotes, Dictionary<int, int> banknoty)
        {
            foreach (int banknote in banknotes)
            {
                banknoty[banknote]--;
            }
        }



    }
}
