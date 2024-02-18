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
namespace WPFTestApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Window1 win1 = new Window1();
        public MainWindow()
        {
            InitializeComponent();
        }
        public void ChangeColor(Color color)
        {
            SolidColorBrush brush = new SolidColorBrush(color);
            this.Background = brush;
        }
        //public MainWindow(Color color)
        //{
        //    InitializeComponent();
        //    SolidColorBrush brush = new SolidColorBrush(color);
        //    this.Background = brush;
        //    //this.Show();
        //    this.Activate();
        //}
        void button1_Click(object sender, EventArgs e)
        {
            //InitializeComponent();
            Window1 win1 = new Window1(this);
        }
    }
}
