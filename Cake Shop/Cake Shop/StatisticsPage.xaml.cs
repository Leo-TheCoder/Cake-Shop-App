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
using Cake_Shop_BUS;
using Cake_Shop_DTO;

namespace Cake_Shop
{
    /// <summary>
    /// Interaction logic for StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page
    {
        private SeriesCollection psc;
                
        public StatisticsPage()
        {
            InitializeComponent();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            

            LoadPieChartData();
        }

        private void LoadPieChartData()
        {
            List<Tuple<string, int>> cakeTypeSta = new List<Tuple<string, int>>();

            cakeTypeSta = BUS_CakeType.Instance.GetStatistic();

            psc = new SeriesCollection();
            foreach (var item in cakeTypeSta)
            {
                LiveCharts.Wpf.PieSeries tmpPie = new LiveCharts.Wpf.PieSeries
                {
                    Values = new LiveCharts.ChartValues<int> { item.Item2 },
                    Title = item.Item1,
                    DataLabels = true
                };
                psc.Add(tmpPie);
            }

            CakeTypePieChart.Series.Clear();

            foreach (var piece in psc)
            {
                CakeTypePieChart.Series.Add(piece);
            }
        }
    }
}
