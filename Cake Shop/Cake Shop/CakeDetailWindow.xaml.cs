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
    /// Interaction logic for CakeDetailWindow.xaml
    /// </summary>
    public partial class CakeDetailWindow : Window
    {
        private int _cakeID;

        public delegate void RefreshScreen();
        public event RefreshScreen eventRefreshScreen;

        public CakeDetailWindow()
        {
            InitializeComponent();
        }

        public CakeDetailWindow(int id)
        {
            InitializeComponent();
            _cakeID = id;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DTO_Cake data = BUS_Cake.Instance.GetCakeByID(_cakeID);
            this.DataContext = data;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            EditCakeWindow edit = new EditCakeWindow(_cakeID);
            edit.ShowDialog();

            DTO_Cake data = BUS_Cake.Instance.GetCakeByID(_cakeID);
            this.DataContext = data;
            this.ShowDialog();

            eventRefreshScreen();
        }
       
    }
}
