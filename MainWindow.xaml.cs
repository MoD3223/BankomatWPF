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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int[] banknoty = { 500, 200, 100, 50, 20, 10 };
        int[] liczbaBanknotow = { 10, 10, 10, 10 };
        int wyplata = 0;


        public void Bankomat()
        {
            wyplata = 1230;
            int[,] dp = new int[wyplata + 1, banknoty.Length];
            for (int i = 0; i < banknoty.Length; i++)
            {
                for (int j = 0; j <= wyplata; j++)
                {
                    dp[j, i] = j == 0 ? 0 : int.MaxValue;
                }
            }
            for (int i = 0; i < banknoty.Length; i++)
            {
                for (int j = 1; j <= wyplata; j++)
                {
                    int value = j - banknoty[i];
                    if (value >= 0 && dp[value, i] != int.MaxValue && dp[value, i] + 1 < dp[j, i])
                    {
                        dp[j, i] = dp[value, i] + 1;
                    }
                    if (i > 0 && dp[j, i - 1] < dp[j, i])
                    {
                        dp[j, i] = dp[j, i - 1];
                    }
                }
            }
            Console.WriteLine("Minimum number of banknoty needed: " + dp[wyplata, banknoty.Length - 1]);
            //Log
            Console.Write("Nominals used: ");
            int row = wyplata, col = banknoty.Length - 1;
            while (row > 0 || col > 0)
            {
                int value = row - banknoty[col];
                if (value >= 0 && dp[value, col] != int.MaxValue && dp[value, col] + 1 == dp[row, col])
                {
                    Console.Write(banknoty[col] + " ");
                    row = value;
                    liczbaBanknotow[col]--;
                }
                else
                {
                    int nextCol = col - 1;
                    while (nextCol >= 0 && (liczbaBanknotow[nextCol] == 0 || dp[row, nextCol] == int.MaxValue || dp[row, nextCol] >= dp[row, col]))
                    {
                        nextCol--;
                    }
                    if (nextCol >= 0)
                    {
                        Console.Write(banknoty[nextCol] + " ");
                        row -= banknoty[nextCol];
                        liczbaBanknotow[nextCol]--;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            //Koniec loga
        }
    }
}
