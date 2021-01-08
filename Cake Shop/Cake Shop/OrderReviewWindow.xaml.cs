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
        private double total = 0;

        public delegate void PassCakeToRemove(int id);
        public event PassCakeToRemove eventPassCakeToRemove;

        public delegate void ClearBasket();
        public event ClearBasket eventClearBasket;

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
                total += tmpTuple.Item3;

                order.Add(tmpTuple);
            }

            OrderDetail.ItemsSource = order;
            TotalTextBlock.Text = total.ToString();
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            int id = BUS_CakeOrder.Instance.GetAmount() + 1;
            BUS_CakeOrder.Instance.AddOrder(id);

            foreach (var item in order)
            {
                BUS_CakeOrder.Instance.AddOrderDetail(id, item.Item1.CakeId, item.Item2, item.Item1.CakePrice);
            }
            order.Clear();
            eventClearBasket();
            this.Close();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            Tuple<DTO_Cake, int, double> item = (Tuple<DTO_Cake, int, double>)OrderDetail.SelectedItem;

            if(item == null)
            {
                return;
            }
            else
            {
                int id = item.Item1.CakeId;
                foreach(Tuple<DTO_Cake, int, double> cake in order)
                {
                    if(cake.Item1.CakeId == id)
                    {
                        eventPassCakeToRemove(id);
                        order.Remove(cake);

                        total -= cake.Item3;
                        TotalTextBlock.Text = total.ToString();
                        OrderDetail.Items.Refresh();
                        break;
                    }
                }

                if(order.Count == 0)
                {
                    Order.IsEnabled = false;
                    Remove.IsEnabled = false;
                }
            }

        }
    }
}
