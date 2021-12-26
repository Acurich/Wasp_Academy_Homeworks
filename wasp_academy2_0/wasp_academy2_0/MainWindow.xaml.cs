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
using System.Windows.Threading;

namespace wasp_academy
{
    public partial class MainWindow : Window
    {
        string pin = "228228";
        Color prav_color = Color.FromArgb(60, 0, 255, 0);
        Color neprav_color = Color.FromArgb(60, 255, 0, 0);
        Color normal_color = Color.FromArgb(100, 33, 33, 37);
        static int count = 0;
        DispatcherTimer time = new DispatcherTimer();
        Random rand = new Random();
        List<Button> buttons;
        public MainWindow()
        {
            InitializeComponent();
            buttons = new List<Button>() { nol, perv, vtor, tret, chetv, pat, shest, sem, vosem, devat, net, yes };
            time.Interval = TimeSpan.FromSeconds(rand.Next(3, 11) + rand.NextDouble());
            time.Tick += SwapButtons;
            time.Start();
        }
        private void SwapButtons(object sender, EventArgs e)
        {
            List<Button> btnToSwap = buttons.GetRange(0, 10);
            for (int i = 9; i >= 0; i--)
            {
                Button hoc = btnToSwap[rand.Next(0, i)];
                hoc.Background = new SolidColorBrush(Color.FromArgb((byte)rand.Next(100, 255), (byte)rand.Next(0, 200), (byte)rand.Next(0, 200), (byte)rand.Next(0, 200)));
                hoc.Content = i;
                btnToSwap.Remove(hoc);
            }
            time.Interval = TimeSpan.FromSeconds(rand.Next(3, 11) + rand.NextDouble());
        }
        private void Click(object sender, RoutedEventArgs e)
        {

            if (count != 1)
            {
                vvod.Text += (sender as Button).Content;
            }
        }

        private void Check(object sender, RoutedEventArgs e)
        {
            if (vvod.Text == pin && count != 1)
            {
                vvod.Text = "TRUE";
                vvod.Background = new SolidColorBrush(prav_color);
                vvod.IsReadOnly = true;
                count = 1;
            }
            else if (count != 1)
            {
                vvod.Background = new SolidColorBrush(neprav_color);
                vvod.Text = "ERROR";
                vvod.Text = null;
                vvod.Background = new SolidColorBrush(normal_color);
            }
        }
        private void KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if ((e.Key >= Key.D0) && (e.Key <= Key.D9)) e.Handled = false;
            if ((e.Key >= Key.NumPad0) && (e.Key <= Key.NumPad9)) e.Handled = false;
        }

    }
}


