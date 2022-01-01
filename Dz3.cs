using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace wasp_academy3
{
    public class NumberBox : UIElement
    {
        private TextBox text = new TextBox();
        private Button up = new Button() { Content = "+" };
        private Button down = new Button() { Content = "-" };
        private double high;
        private double wide;
        private int value;
        private Thickness margin;
        private bool flag;

        public int Value
        {
            get => value;
            set
            {
                flag = true;
                text.Text = value.ToString();
                this.value = value;
                ChangeValue();
            }
        }

        public double Height
        {
            get => high;
            set
            {
                high = value;
                text.Height = value; up.Height = down.Height = value / 2;
            }
        }

        public double Width
        {
            get => wide;
            set
            {
                wide = value;
                text.Width = value / 3 * 2;
                up.Width = down.Width = value / 3;
            }
        }

        public Thickness Margin
        {
            get => margin;
            set
            {
                margin = value;
                text.Margin = value;
                value.Left += text.Width + up.Width;
                value.Top -= up.Height;
                up.Margin = value;
                value.Top += up.Height + down.Height;
                down.Margin = value;
            }
        }

        public Brush Foreground
        {
            set
            {
                text.Foreground = value;
                up.Foreground = value;
                down.Foreground = value;
            }
        }

        public Brush Background
        {
            set
            {
                text.Background = value;
                up.Background = value;
                down.Background = value;
            }
        }

        public NumberBox()
        {
            text.TextChanged += ValidateNumbers;
            up.Click += IncreaseValue;
            down.Click += DecreaseValue;
        }

        private void DecreaseValue(object sender, RoutedEventArgs e)
        {
            Value--;
        }

        private void IncreaseValue(object sender, RoutedEventArgs e)
        {
            Value++;
        }

        private void ValidateNumbers(object sender, TextChangedEventArgs e)
        {
            if (flag)
            {
                flag = false;
                return;
            }
            if (!text.Text.All(x => char.IsDigit(x)))
            {
                flag = true;
                text.Text = value.ToString();
            }
            else if (!int.TryParse(text.Text, out value))
            {
                value = 0;
            }
        }

        protected override void OnVisualParentChanged(DependencyObject oldParent)
        {
            base.OnVisualParentChanged(oldParent);
            Grid grid = VisualParent as Grid;
            grid.Children.Add(text);
            grid.Children.Add(up);
            grid.Children.Add(down);
        }

        public readonly RoutedEvent ValueChange = EventManager.RegisterRoutedEvent("ValueChanged", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(NumberBox));

        public event RoutedEventHandler ValueChanged
        {
            add => AddHandler(ValueChange, value);
            remove => RemoveHandler(ValueChange, value);
        }

        private void ChangeValue() => RaiseEvent(new RoutedEventArgs(ValueChange, this));
    }
}
