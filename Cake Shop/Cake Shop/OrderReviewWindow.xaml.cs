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
using System.Windows.Shapes;
using Cake_Shop_DTO;
using Cake_Shop_BUS;

namespace Cake_Shop
{
    /// <summary>
    /// Interaction logic for OrderReviewWindow.xaml
    /// </summary>
    public partial class OrderReviewWindow : Window
    {
        private List<Tuple<int, int>> basket;
        private List<Tuple<DTO_Cake, int, double>> order = new List<Tuple<DTO_Cake, int, double>>();

        public OrderReviewWindow()
        {
            InitializeComponent();
        }

        public OrderReviewWindow(List<Tuple<int, int>> inBasket)
        {
            InitializeComponent();
            basket = inBasket;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach(var item in basket)
            {
                DTO_Cake tmpCake = BUS_Cake.Instance.GetCakeByID(item.Item1);
                Tuple<DTO_Cake, int, double> tmpTuple = new Tuple<DTO_Cake, int, double>(tmpCake, item.Item2, tmpCake.CakePrice*item.Item2);

                order.Add(tmpTuple);
            }

            OrderDetail.ItemsSource = order;
        }
    }
}
