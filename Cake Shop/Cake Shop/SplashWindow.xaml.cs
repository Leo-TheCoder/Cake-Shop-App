using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for SplashWindow.xaml
    /// </summary>
    public partial class SplashWindow : Window
    {

        private System.Timers.Timer _timer;
        private int timer = 0;
        private int watingTime = 300;   //500 -> 6s
        private Random _rng = new Random();

        private string[] listOfTips = new string[]
        {
            "Đặt một chiếc bánh hoa quả dưới gối trước khi ngủ để mơ về người bạn sẽ cưới.",
            "Đặt một chiếc bánh hoa quả dưới gối trước khi ngủ để mơ về người bạn sẽ cưới.",
            "Đặt một chiếc bánh hoa quả dưới gối trước khi ngủ để mơ về người bạn sẽ cưới.",
            "Đặt một chiếc bánh hoa quả dưới gối trước khi ngủ để mơ về người bạn sẽ cưới.",
            "Đặt một chiếc bánh hoa quả dưới gối trước khi ngủ để mơ về người bạn sẽ cưới.",
            "Đặt một chiếc bánh hoa quả dưới gối trước khi ngủ để mơ về người bạn sẽ cưới.",

        };

        private string[] listOfBackground = new string[]
        {
            "Images/SplashScreen01.jpg",
            "Images/SplashScreen02.jpg",
            "Images/SplashScreen03.jpg",
            "Images/SplashScreen04.jpg",
            "Images/SplashScreen05.jpg",
            "Images/SplashScreen06.jpg",
        };

        public SplashWindow()
        {
            InitializeComponent();

            var value = ConfigurationManager.AppSettings["SplashWindow"];
            var showSplash = bool.Parse(value);

            if (showSplash == false)
            {
                var main = new MainWindow();
                main.Show();

                this.Close();
            }
            _timer = new System.Timers.Timer(1);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int index = _rng.Next(listOfTips.Length);
            Tip.Text = listOfTips[index];

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri($"{listOfBackground[index]}", UriKind.Relative);
            bitmapImage.EndInit();

            BackgroundSplashScreen.Source = bitmapImage;

            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();

        }

        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (timer > watingTime)
                {
                    _timer.Stop();

                    var main = new MainWindow();
                    main.Show();
                    this.Close();
                }
                else
                {
                    timer += 1;
                    Console.WriteLine(timer);
                    ProgressBarSplashScreen.Value = (double)timer / watingTime * 100;
                }

            });
        }



        private void SplashScreenCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["SplashWindow"].Value = "true";
            config.Save(ConfigurationSaveMode.Minimal);
        }

        private void SplashScreenCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["SplashWindow"].Value = "false";
            config.Save(ConfigurationSaveMode.Minimal);
        }
    }
}

