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
using System.Collections.ObjectModel;
using Cake_Shop_DTO;
using Cake_Shop_BUS;

namespace Cake_Shop
{
    /// <summary>
    /// Interaction logic for CakeListPage.xaml
    /// </summary>
    public partial class CakeListPage : Page
    {

        private List<DTO_Cake> listAllCake;

        public static List<Tuple<int, int>> basket = new List<Tuple<int, int>>();

        private ObservableCollection<DTO_Cake> cakeList;
        public CakeListPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listAllCake = BUS_Cake.Instance.GetAllCakes();
            cakeList = new ObservableCollection<DTO_Cake>(listAllCake);

            CakeListView.ItemsSource = cakeList;
        }

        private void AddCake_Click(object sender, RoutedEventArgs e)
        {
            DTO_Cake cake = (DTO_Cake)CakeListView.SelectedItem;

            //MessageBox.Show($"{cake.CakeName}");
            SetCakeAmountWindow setAmount = new SetCakeAmountWindow(cake.CakeId);
            setAmount.eventPassCakeToMain += SetAmount_eventPassCakeToMain;
            setAmount.ShowDialog();

        }

        private void SetAmount_eventPassCakeToMain(int id, int amount)
        {
            Tuple<int, int> item = new Tuple<int, int>(id, amount);

            foreach (Tuple<int, int> part in basket)
            {
                if (part.Item1 == item.Item1)
                {
                    amount += part.Item2;
                    basket.Remove(part);
                    break;
                }
            }

            Tuple<int, int> toAdd = new Tuple<int, int>(id, amount);
            basket.Add(toAdd);

            AmountBorder.Visibility = Visibility.Visible;
            Amount.Text = basket.Count().ToString();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            String searching = SearchBox.Text;
            List<DTO_Cake> searchCakeByName = BUS_Cake.Instance.GetSearchCakeByName(searching.Trim());
            if(searchCakeByName.Count > 0)
            {
                ObservableCollection<DTO_Cake> searchList = new ObservableCollection<DTO_Cake>(searchCakeByName);
                CakeListView.ItemsSource = searchList;
            }
            else
            {
                CakeListView.ItemsSource = cakeList;
            }
            
        }

        private void ShowCakeDetail(object sender, MouseButtonEventArgs e)
        {
            DTO_Cake cake = (DTO_Cake)CakeListView.SelectedItem;

            //MessageBox.Show($"{cake.CakeName}");
            CakeDetailWindow cakeDetail = new CakeDetailWindow(cake.CakeId);
            cakeDetail.ShowDialog();
        }

        private void WatchBasket_Click(object sender, RoutedEventArgs e)
        {
            if(basket.Count > 0)
            {
                OrderReviewWindow review = new OrderReviewWindow(basket);
                review.eventPassCakeToRemove += Review_eventPassCakeToRemove;
                review.ShowDialog();
            }
        }

        private void Review_eventPassCakeToRemove(int id)
        {
            foreach (Tuple<int, int> part in basket)
            {
                if (part.Item1 == id)
                {
                    basket.Remove(part);
                    break;
                }
            }

            if(basket.Count == 0)
            {
                AmountBorder.Visibility = Visibility.Collapsed;
            }
            else
            {
                Amount.Text = basket.Count().ToString();
            }

        }
    }
}
