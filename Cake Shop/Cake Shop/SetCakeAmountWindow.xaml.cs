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

namespace Cake_Shop
{
    /// <summary>
    /// Interaction logic for SetCakeAmountWindow.xaml
    /// </summary>
    public partial class SetCakeAmountWindow : Window
    {
        private int cakeID;
        public delegate void PassCakeToMain(int id, int amount);
        public event PassCakeToMain eventPassCakeToMain;
        public SetCakeAmountWindow()
        {
            InitializeComponent();
        }

        public SetCakeAmountWindow(int id)
        {
            InitializeComponent();
            cakeID = id;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string input = AmountTextBox.Text;
            int amount = 0;

            if(input.Length > 0)
            {
                try
                {
                    amount = int.Parse(input);
                }
                catch
                {
                    return;
                }
                eventPassCakeToMain(cakeID, amount);
                this.Close();
            }
            else
            {
                //do nothing tại có nhập gì đâu
            }
        }
    }
}
