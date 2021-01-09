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
using LiveCharts;
using LiveCharts.Wpf;
using Cake_Shop_DTO;
using Cake_Shop_BUS;

namespace Cake_Shop
{
    /// <summary>
    /// Interaction logic for MonthlyStatistic.xaml
    /// </summary>
    public partial class MonthlyStatistic : UserControl
    {
        private List<Tuple<int, double>> monthlyIncomeList = new List<Tuple<int, double>>();

        public SeriesCollection SeriesCollection { get; set; }
        public List<string> tmpLabel = new List<string>();

        public string[] Labels { get; set; }

        public Func<double, string> Formatter { get; set; }
        public ChartValues<double> Profit = new ChartValues<double>();

        public MonthlyStatistic()
        {
            InitializeComponent();
        }



        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            monthlyIncomeList = BUS_CakeOrder.Instance.GetMonthlyIncome();

            Profit.Clear();
            tmpLabel.Clear();

            foreach (Tuple<int, double> item in monthlyIncomeList)
            {
                Profit.Add(item.Item2);
                tmpLabel.Add("Tháng " + item.Item1.ToString());
            }

            SeriesCollection = new SeriesCollection
            {
                 new ColumnSeries
                 {
                     Title = "Doanh thu",
                     Values = Profit
                 }
            };

            Labels = new string[tmpLabel.Count];

            for(int i = 0; i < tmpLabel.Count; i++)
            {
                Labels[i] = tmpLabel[i];
            }

            Formatter = value => value.ToString("N");
            DataContext = this;
        }
    }
}
