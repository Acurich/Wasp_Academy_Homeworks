using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace finalwpf
{
    /// <summary>
    /// Класс для гистограммы.
    /// </summary>
    public class HorizontalBarGraph : UIElement
    {
        /// <summary>
        /// Внутренний список значений.
        /// </summary>
        private List<int> znacheniya;
        /// <summary>
        /// Внутренний список прямоугольников для отрисовки гистограммы.
        /// </summary>
        private List<Rectangle> otstupi;
        /// <summary>
        /// Внутреннее поле для хранения отступа (координат).
        /// </summary>
        private Thickness marg;
        /// <summary>
        /// Поле для хранения высоты.
        /// </summary>
        private double visota;
        /// <summary>
        /// Поле для хранения коэффициента ширины.
        /// </summary>
        private uint shirina;
        /// <summary>
        /// Список значений. Данные невозможно оперативно поменять, так как изменение данных в списке невозможно отследить.
        /// </summary>
        public List<int> Values
        {
            get { return new List<int>(znacheniya); }
            set { SetupOtstupi(value); }
        }
        /// <summary>
        /// Количество строк.
        /// </summary>
        public int Amountofotstupi => otstupi.Count;
        /// <summary>
        /// Отступы элемента.
        /// </summary>
        public Thickness Margin
        {
            get { return marg; }
            set { marg = value; UpdateOtstupi(); }
        }
        /// <summary>
        /// Высота элемента.
        /// </summary>
        public double Height
        {
            get { return visota; }
            set { visota = value; UpdateOtstupi(); }
        }
        /// <summary>
        /// Коэффициент ширины элемента.
        /// </summary>
        public uint WidthCoefficient
        {
            get { return shirina; }
            set { shirina = value; UpdateOtstupi(); }
        }
        /// <summary>
        /// Максимальное значение для одной строки.
        /// </summary>
        public int CapValue { get; set; }
        /// <summary>
        /// Если имеет значение true, то превышение лимита вызывает исключение.
        /// </summary>
        public bool IsHardCap { get; set; }
        /// <summary>
        /// Список основных цветов строк.
        /// </summary>
        public List<Brush> Colors => (from x in otstupi select x.Fill).ToList();
        /// <summary>
        /// Список цветов границ строк.
        /// </summary>
        public List<Brush> Borders => (from x in otstupi select x.Stroke).ToList();
        /// <summary>
        /// True, если есть проблемы со значением.
        /// </summary>
        public bool IsDecoy { get; set; }
        /// <summary>
        /// Поле события на изменение числа столбцов.
        /// </summary>
        public readonly RoutedEvent AmountofOtstupiChange = EventManager.RegisterRoutedEvent("AmonutOfRowsOtstupi", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(HorizontalBarGraph));
        /// <summary>
        /// Событие на изменение числа столбцов.
        /// </summary>
        public event RoutedEventHandler AmountOfRowsChanged
        {
            add
            {
                AddHandler(AmountofOtstupiChange, value);
            }
            remove
            {
                RemoveHandler(AmountofOtstupiChange, value);
            }
        }
        /// <summary>
        /// Поле события на достижение лимита одной из строк.
        /// </summary>
        public readonly RoutedEvent ReachCapValue = EventManager.RegisterRoutedEvent("ReachCapValue", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(HorizontalBarGraph));
        /// <summary>
        /// Событие на достижение лимита одной из строк.
        /// </summary>
        public event RoutedEventHandler CapValueReached
        {
            add
            {
                AddHandler(ReachCapValue, value);
            }
            remove
            {
                RemoveHandler(ReachCapValue, value);
            }
        }
        /// <summary>
        /// Создаёт новую гистограмму.
        /// </summary>
        public HorizontalBarGraph()
        {
            otstupi = new List<Rectangle>();
            znacheniya = new List<int>();
        }
        /// <summary>
        /// Метод настройки строк. Осуществляет синхронизацию их количества
        /// </summary>
        /// <param name="values">Новый полученный список значений.</param>
        private void SetupOtstupi(List<int> values)
        {
            if (values.Count != otstupi.Count)
            {
                otstupi.Clear();
                foreach (var value in values)
                {
                    ValidateCapValue(value);
                    otstupi.Add(new Rectangle() { Stroke = new SolidColorBrush(System.Windows.Media.Colors.Black) });
                }
                this.znacheniya = new List<int>(values);
                UpdateOtstupi();
                RaiseEvent(new RoutedEventArgs(AmountofOtstupiChange, null));
            }
            else
            {
                this.znacheniya = new List<int>(values);
                UpdateOtstupi();
            }
        }
        /// <summary>
        /// Метод обновления значений (ширины) строк.
        /// </summary>
        private void UpdateOtstupi()
        {
            Thickness margin = this.marg;
            int i = 0;
            foreach (var otstup in otstupi)
            {
                otstup.HorizontalAlignment = HorizontalAlignment.Left;
                otstup.VerticalAlignment = VerticalAlignment.Top;
                otstup.Height = visota / Amountofotstupi;
                margin.Top += otstup.Height + 5;
                otstup.Margin = margin;
                otstup.Width = znacheniya[i++] * WidthCoefficient;
            }
        }
        /// <summary>
        /// Метод для добавления прямоугольников на форму.
        /// </summary>
        /// <param name="oldParent"></param>
        protected override void OnVisualParentChanged(DependencyObject oldParent)
        {
            base.OnVisualParentChanged(oldParent);
            Grid grid = VisualParent as Grid;
            foreach (var otstup in otstupi) grid.Children.Add(otstup);
        }
        /// <summary>
        /// Проверка на превышение значения.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void ValidateCapValue(int value)
        {
            if (IsHardCap && value > CapValue) throw new ArgumentOutOfRangeException("value", "Cap value has been exceeded!");
            else if (value >= CapValue && CapValue != 0) RaiseEvent(new RoutedEventArgs(ReachCapValue, this));
        }
        /// <summary>
        /// Расставляет случайные цвета для столбцов.
        /// </summary>
        public void Recolor()
        {
            Random rand = new Random();
            foreach (var otstup in otstupi)
            {
                otstup.Stroke = new SolidColorBrush(Color.FromArgb((byte)rand.Next(0, 256), (byte)rand.Next(0, 256), (byte)rand.Next(0, 256), (byte)rand.Next(0, 256)));
                otstup.Fill = new SolidColorBrush(Color.FromArgb((byte)rand.Next(0, 256), (byte)rand.Next(0, 256), (byte)rand.Next(0, 256), (byte)rand.Next(0, 256)));
            }
        }
        /// <summary>
        /// Получает среднее значение среди значений.
        /// </summary>
        /// <returns></returns>
        public double GetAvg() => znacheniya.Average();//System.Linq
        /// <summary>
        /// Получает максимальное значение.
        /// </summary>
        /// <returns></returns>
        public int GetMax() => znacheniya.Max();//System.Linq
        /// <summary>
        /// Сортирует гистограмму по возрастанию (хотя на самом деле по убыванию, т.к. значения идут сверху-вниз).
        /// </summary>
        public void Sort()
        {
            if (!IsDecoy)
            {
                znacheniya.Sort();
                znacheniya.Reverse();
                SetupOtstupi(Values);
            }
        }
        /// <summary>
        /// Немного изменяет видимые прямоугольники по ширине.
        /// </summary>
        public void Reshuffle()
        {
            if (!IsDecoy)
            {
                var rand = new Random();
                foreach (var otstup in otstupi)
                {
                    otstup.Width += rand.Next(-20, 20);
                }
                IsDecoy = true;
            }
        }
        /// <summary>
        /// Нормализует прямоугольники.
        /// </summary>
        public void Correct()
        {
            if (IsDecoy)
            {
                SetupOtstupi(Values);
                IsDecoy = false;
            }
        }
    }
}