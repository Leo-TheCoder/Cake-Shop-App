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
        public CakeListPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<DTO_Cake> cakeList = new ObservableCollection<DTO_Cake>(BUS_Cake.Instance.GetAllCakes());

            CakeListView.ItemsSource = cakeList;
        }
    }
}
