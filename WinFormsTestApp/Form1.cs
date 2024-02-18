using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTestApp
{
    public partial class Form1 : Form
    {
        private Button button;
        public Panel panel;
        public Form1()
        {
            InitializeComponent();
        }
        private void AdditionalButtonClick(object sender, EventArgs e)
        {
            // Дополнительная логика при нажатии кнопки
            CustomColorForm customColorForm = new CustomColorForm(this, panel);
            customColorForm.ShowDialog();
        }
    }
}