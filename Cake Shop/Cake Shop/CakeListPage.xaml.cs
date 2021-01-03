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

            MessageBox.Show($"{cake.CakeName}");
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
    }
}
