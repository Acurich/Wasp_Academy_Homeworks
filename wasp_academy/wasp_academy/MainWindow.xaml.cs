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

namespace wasp_academy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Поля для быстрого обащения к кнопкам и быстрой проверки изменения текста с возможностью откатить изменения.
        List<Button> buttons;
        string codeBuffer = "";
        bool flag = false;

        public MainWindow()
        {
            InitializeComponent();
            //Инициализируем список кнопок.
            buttons = new List<Button>() { ZeroKey, OneKey, TwoKey, ThreeKey, FourKey, FiveKey, SixKey, SevenKey, EightKey, NineKey, CancelKey, AcceptKey };
        }
        /// <summary>
        /// Обработчик нажатия кнопки 7.
        /// </summary>
        private void SevenKey_Click(object sender, RoutedEventArgs e)
        {
            Code.Text += "7";
        }
        /// <summary>
        /// Обработчик нажатия кнопки отмены.
        /// </summary>
        private void CancelKey_Click(object sender, RoutedEventArgs e)
        {
            Code.Text = "";
        }
        /// <summary>
        /// Обработчик нажатия кнопки 8.
        /// </summary>
        private void EightKey_Click(object sender, RoutedEventArgs e)
        {
            Code.Text += "8";
        }
        /// <summary>
        /// Обработчик нажатия кнопки 9.
        /// </summary>
        private void NineKey_Click(object sender, RoutedEventArgs e)
        {
            Code.Text += "9";
        }
        /// <summary>
        /// Обработчик нажатия кнопки 4.
        /// </summary>
        private void FourKey_Click(object sender, RoutedEventArgs e)
        {
            Code.Text += "4";
        }
        /// <summary>
        /// Обработчик нажатия кнопки 5.
        /// </summary>
        private void FiveKey_Click(object sender, RoutedEventArgs e)
        {
            Code.Text += "5";
        }
        /// <summary>
        /// Обработчик нажатия кнопки 6.
        /// </summary>
        private void SixKey_Click(object sender, RoutedEventArgs e)
        {
            Code.Text += "6";
        }
        /// <summary>
        /// Обработчик нажатия кнопки 1.
        /// </summary>
        private void OneKey_Click(object sender, RoutedEventArgs e)
        {
            Code.Text += "1";
        }
        /// <summary>
        /// Обработчик нажатия кнопки 2.
        /// </summary>
        private void TwoKey_Click(object sender, RoutedEventArgs e)
        {
            Code.Text += "2";
        }
        /// <summary>
        /// Обработчик нажатия кнопки 3.
        /// </summary>
        private void ThreeKey_Click(object sender, RoutedEventArgs e)
        {
            Code.Text += "3";
        }
        /// <summary>
        /// Обработчик нажатия кнопки 0.
        /// </summary>
        private void ZeroKey_Click(object sender, RoutedEventArgs e)
        {
            Code.Text += "0";
        }
        /// <summary>
        /// Обработчик нажатия кнопки проверки.
        /// </summary>
        private void AcceptKey_Click(object sender, RoutedEventArgs e)
        {
            if (Code.Text == "2314138")
            {
                Code.Text = "Success!";
                Code.Background = new SolidColorBrush(Color.FromArgb(0x87, 0x7E, 0xE0, 0x91));
                Code.IsEnabled = false;
                buttons.ForEach(x => x.IsEnabled = false);
            }
            else Code.Text = "";
        }
        /// <summary>
        /// Обработчик изенения текста (для быстрой проверки символов на цифры).
        /// </summary>
        private void Code_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (flag)
            {
                flag = false;
                return;
            }
            if (!(string.IsNullOrEmpty(Code?.Text) || Code.Text == "Success!" || Code.Text.All(x => char.IsDigit(x))))
            {
                flag = true;
                Code.Text = codeBuffer;
            }
            else codeBuffer = Code.Text;
        }
        /// <summary>
        /// Обработчик ввода (для проверки нажатия клавиши Enter).
        /// </summary>
        private void Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) AcceptKey_Click(sender, e);
        }
    }
}
