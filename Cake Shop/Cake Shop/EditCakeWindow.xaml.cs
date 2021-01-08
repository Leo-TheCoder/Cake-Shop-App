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
    /// Interaction logic for EditCakeWindow.xaml
    /// </summary>
    public partial class EditCakeWindow : Window
    {
        private int _cakeID;

        public EditCakeWindow()
        {
            InitializeComponent();
        }

        public EditCakeWindow(int id)
        {
            InitializeComponent();
            _cakeID = id;
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            string newName = CakeNameTextBox.Text;
            double newPrice;
            try
            {
                newPrice = double.Parse(CakePriceTextBox.Text);
            }
            catch
            {
                return;
            }

            DTO_CakeType selectedType = (DTO_CakeType)CakeTypePicker.SelectedItem;
            int newType = selectedType.CakeTypeId;

            BUS_Cake.Instance.UpdateCake(_cakeID, newName, newPrice, newType);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DTO_Cake data = BUS_Cake.Instance.GetCakeByID(_cakeID);
            List<DTO_CakeType> cakeType = BUS_CakeType.Instance.GetAllTypes();

            this.DataContext = data;
            CakeTypePicker.ItemsSource = cakeType;
            CakeTypePicker.DisplayMemberPath = "CakeTypeName";
            CakeTypePicker.SelectedIndex = 0;
        }
    }
}
