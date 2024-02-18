using Microsoft.Win32;
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

namespace WPFTestApp
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public int redValue;
        public int greenValue;
        public int blueValue;
        public MainWindow mainWindow;
        public Window1(MainWindow mainWindow)
        {
            this.InitializeComponent();
            this.mainWindow = mainWindow;
            this.Owner = mainWindow;
            this.ShowDialog();
            //this.DialogResult = true;
            //this.DragMove();
        }
        public Window1()
        {
            InitializeComponent();
        }
        private void LockedButtons(object sender, EventArgs e)
        {
            if (textBox1 != null && textBox2 != null && textBox3 != null)
            {
            if (!int.TryParse(textBox1.Text, out int result1) || !int.TryParse(textBox2.Text, out int result2) || !int.TryParse(textBox3.Text, out int result3) || result1 < 0 || result1 > 255 || result2 < 0 || result2 > 255 || result3 < 0 || result3 > 255)
            {
                OK.IsEnabled = false; // Недоступность кнопки "ОК"
                Change.IsEnabled = false; // Недоступность кнопки "Применить"
            }
            else
            {
                OK.IsEnabled = true; // Доступность кнопки "ОК"
                Change.IsEnabled = true; // Доступность кнопки "Применить"
            }
            }
        }

        private void d(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                redValue = int.Parse(textBox1.Text);
                greenValue = int.Parse(textBox2.Text);
                blueValue = int.Parse(textBox3.Text);
                Color color = Color.FromRgb((byte)redValue, (byte)greenValue, (byte)blueValue);
                // Изменяем цвет первого окна
                SolidColorBrush brush = new SolidColorBrush(color);
                mainWindow.Background = brush;
                //this.DialogResult=false;
            }
            else if (e.Key == Key.Escape)
            {
                Color color = Color.FromRgb(0, 0, 200);
                // Изменяем цвет первого окна
                SolidColorBrush brush = new SolidColorBrush(color);
                mainWindow.Background = brush;
            }
                this.Close();
        }

        void OK_Click(object sender, EventArgs e)
        {
            redValue = int.Parse(textBox1.Text);
            greenValue = int.Parse(textBox2.Text);
            blueValue = int.Parse(textBox3.Text);
            Color color = Color.FromRgb((byte)redValue, (byte)greenValue, (byte)blueValue);
            // Изменяем цвет первого окна
            SolidColorBrush brush = new SolidColorBrush(color);
            mainWindow.Background = brush;
            //this.DialogResult=false;
            this.Close();
        }
        void Cancel_Click(object sender, EventArgs e)
        {
            //this.DialogResult=false;
            this.Close();
        }
        void Change_Click(object sender, EventArgs e)
        {
            redValue = int.Parse(textBox1.Text);
            greenValue = int.Parse(textBox2.Text);
            blueValue = int.Parse(textBox3.Text);
            Color color = Color.FromRgb((byte)redValue, (byte)greenValue, (byte)blueValue);
            // Изменяем цвет первого окна
            SolidColorBrush brush = new SolidColorBrush(color);
            mainWindow.Background = brush;
        }
    }
}
