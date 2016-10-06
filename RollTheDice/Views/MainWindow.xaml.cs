using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
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
using RollTheDice.ViewModels;

namespace RollTheDice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetDice(7);
            this.DataContext = new MainWindowViewModel();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            ThreadPool.QueueUserWorkItem((o) =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    Dispatcher.Invoke((Action)(() => SetDice(rnd.Next(1, 7))));
                    Thread.Sleep(100 + 10 * i);
                }
            });
        }

        private void SetDice(int rollResult)
        {
            switch (rollResult)
            {
                case 1:
                    OneOne.Visibility = Visibility.Hidden;
                    ThreeOne.Visibility = Visibility.Hidden;
                    OneTwo.Visibility = Visibility.Hidden;
                    TwoTwo.Visibility = Visibility.Visible;
                    ThreeTwo.Visibility = Visibility.Hidden;
                    OneThree.Visibility = Visibility.Hidden;
                    ThreeThree.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    OneOne.Visibility = Visibility.Visible;
                    ThreeOne.Visibility = Visibility.Hidden;
                    OneTwo.Visibility = Visibility.Hidden;
                    TwoTwo.Visibility = Visibility.Hidden;
                    OneThree.Visibility = Visibility.Hidden;
                    ThreeTwo.Visibility = Visibility.Hidden;
                    ThreeThree.Visibility = Visibility.Visible;
                    break;
                case 3:
                    OneOne.Visibility = Visibility.Visible;
                    ThreeOne.Visibility = Visibility.Hidden;
                    OneTwo.Visibility = Visibility.Hidden;
                    TwoTwo.Visibility = Visibility.Visible;
                    ThreeTwo.Visibility = Visibility.Hidden;
                    OneThree.Visibility = Visibility.Hidden;
                    ThreeThree.Visibility = Visibility.Visible;
                    break;
                case 4:
                    OneOne.Visibility = Visibility.Visible;
                    ThreeOne.Visibility = Visibility.Visible;
                    OneTwo.Visibility = Visibility.Hidden;
                    TwoTwo.Visibility = Visibility.Hidden;
                    OneThree.Visibility = Visibility.Visible;
                    ThreeTwo.Visibility = Visibility.Hidden;
                    ThreeThree.Visibility = Visibility.Visible;
                    break;
                case 5:
                    OneOne.Visibility = Visibility.Visible;
                    ThreeOne.Visibility = Visibility.Visible;
                    OneTwo.Visibility = Visibility.Hidden;
                    TwoTwo.Visibility = Visibility.Visible;
                    OneThree.Visibility = Visibility.Visible;
                    ThreeTwo.Visibility = Visibility.Hidden;
                    ThreeThree.Visibility = Visibility.Visible;
                    break;
                case 6:
                    OneOne.Visibility = Visibility.Visible;
                    ThreeOne.Visibility = Visibility.Visible;
                    OneTwo.Visibility = Visibility.Visible;
                    TwoTwo.Visibility = Visibility.Hidden;
                    ThreeTwo.Visibility = Visibility.Visible;
                    OneThree.Visibility = Visibility.Visible;
                    ThreeThree.Visibility = Visibility.Visible;
                    break;
                default:
                    OneOne.Visibility = Visibility.Hidden;
                    ThreeOne.Visibility = Visibility.Hidden;
                    OneTwo.Visibility = Visibility.Hidden;
                    TwoTwo.Visibility = Visibility.Hidden;
                    ThreeTwo.Visibility = Visibility.Hidden;
                    OneThree.Visibility = Visibility.Hidden;
                    ThreeThree.Visibility = Visibility.Hidden;
                    break;
            }
        }
    }
}
