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
using AsyncClassLibrary;

namespace PrimeNumsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PrimeNumberCalc primeCalc = new PrimeNumberCalc();
        public int numCount { get; set; } = 0;

        public MainWindow()
        {
            InitializeComponent();
            CountTxtBlk.DataContext = this;
        }

        private async void CalcBTN_Click(object sender, RoutedEventArgs e)
        {
            int num = int.Parse(NumInputTB.Text);
            NumInputTB.Clear();
            var result = await primeCalc.FindPrimeNumbersAsync(num);
            AnswerTxtBlk.Text = result.ToString();
        }

        private void CountBTN_Click(object sender, RoutedEventArgs e)
        {
            numCount++;
            CountTxtBlk.Text = numCount.ToString();
            if (numCount >= 100)
                CountTxtBlk.FontSize = 100;
        }
    }
}
