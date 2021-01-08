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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cake_Shop
{
    /// <summary>
    /// Interaction logic for AddCakeWindow.xaml
    /// </summary>
    public partial class AddCakeWindow : Window
    {
        private DTO_Cake newCake = new DTO_Cake();

        public List<DTO_CakeType> CakeTypeList = BUS_CakeType.Instance.GetAllTypes();
        public AddCakeWindow(int cakeId)
        {
            InitializeComponent();
            this.DataContext = newCake;
            newCake.CakeId = cakeId;
            ComboBox_CakeType.ItemsSource = CakeTypeList;
        }

        private void Button_AddAvatar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a picture";
            openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
          "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
          "Portable Network Graphic (*.png)|*.png";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BitmapImage img = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
                newCake.CakeAvatar = openFileDialog.FileName;
                AvatarImg.Source = img;
                AvatarImg.Visibility = Visibility.Visible;
                Button_RemoveAvatar.Visibility = Visibility.Visible;
                Button_AddAvatar.Visibility = Visibility.Hidden;
            }
        }

        private void Button_RemoveAvatar_Click(object sender, RoutedEventArgs e)
        {
            AvatarImg.Source = null;
            newCake.CakeAvatar = null;
            AvatarImg.Visibility = Visibility.Hidden;
            Button_RemoveAvatar.Visibility = Visibility.Hidden;
            Button_AddAvatar.Visibility = Visibility.Visible;
        }

        private void Button_AddCake_Click(object sender, RoutedEventArgs e)
        {
            BUS_Cake.Instance.AddCake(newCake);
        }
    }
}
