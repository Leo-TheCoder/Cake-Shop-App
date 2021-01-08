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

namespace Cake_Shop
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

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn thực sự muốn thoát?", "Thoát", MessageBoxButton.YesNo);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    {
                        this.Close();
                        break;
                    }
                default:
                    {
                        return;
                    }
            }
        }

        private void MinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ResizeWindow_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }
        }

        private void CakeListButton_Click(object sender, RoutedEventArgs e)
        {
            Grid.SetColumn(ActiveIndicator, 0);

            CakeListPage cakeList = new CakeListPage();
            MainFrame.Navigate(cakeList);
        }

        private void OrderListButton_Click(object sender, RoutedEventArgs e)
        {
            Grid.SetColumn(ActiveIndicator, 1);

            ViewOrderPage viewOrder = new ViewOrderPage();
            MainFrame.Navigate(viewOrder);
        }

        private void StatisticButton_Click(object sender, RoutedEventArgs e)
        {
            Grid.SetColumn(ActiveIndicator, 2);

            StatisticsPage staPage = new StatisticsPage();
            MainFrame.Navigate(staPage);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CakeListPage cakeList = new CakeListPage();
            MainFrame.Navigate(cakeList);
        }
    }
}
