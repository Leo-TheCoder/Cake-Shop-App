using Cake_Shop_BUS;
using Cake_Shop_DTO;
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
    /// Interaction logic for ViewOrderPage.xaml
    /// </summary>
    public partial class ViewOrderPage : Page
    {
        private List<DTO_CakeOrder> _orderList;
        public ViewOrderPage()
        {
            InitializeComponent();
            this.DataContext = this;
            OrderList = BUS_CakeOrder.Instance.GetAllOrders();
        }

        public List<DTO_CakeOrder> OrderList { get => _orderList; set => _orderList = value; }

        private void DataGridOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //change item source of grid
            DTO_CakeOrder selectedOrder = (DTO_CakeOrder)DataGridOrders.SelectedItem;
            DataGridSpecificOrder.ItemsSource = selectedOrder.OrderCakeList;
        }
    }
}
