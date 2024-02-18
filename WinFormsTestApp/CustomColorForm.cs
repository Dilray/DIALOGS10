using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace WinFormsTestApp
{
    public partial class CustomColorForm : Form
    {
        public TextBox textBox1;
        public TextBox textBox2;
        public TextBox textBox3;
        public Button OKbutton;
        public Button Changebutton;
        public Button Cancelbutton;
        public Form1 form1;
        public Panel panel;
        //bool validInput = true;
        private void cancel(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeBackgroundColorButtonClick1(object sender, EventArgs e)
        {
            int red, green, blue;
            if (int.TryParse(this.textBox1.Text, out red) &&
                int.TryParse(this.textBox2.Text, out green) &&
                int.TryParse(this.textBox3.Text, out blue) &&
                red >= 0 && red <= 255 &&
                green >= 0 && green <= 255 &&
                blue >= 0 && blue <= 255)
            {
                form1.panel.BackColor = Color.FromArgb(red, green, blue);
            }
            else
                OKbutton.Enabled = Changebutton.Enabled = false;
            this.Close();
        }

        private void LockedButtons(object sender, EventArgs e)
        {
            int red, green, blue;
            if (!(int.TryParse(this.textBox1.Text, out red) &&
                int.TryParse(this.textBox2.Text, out green) &&
                int.TryParse(this.textBox3.Text, out blue) &&
                red >= 0 && red <= 255 &&
                green >= 0 && green <= 255 &&
                blue >= 0 && blue <= 255))
                OKbutton.Enabled = Changebutton.Enabled = false;
            else
                OKbutton.Enabled = Changebutton.Enabled = true;

        }

        private void ChangeBackgroundColorButtonClick(object sender, EventArgs e)
        {
            int red, green, blue;
            if (int.TryParse(this.textBox1.Text, out red) &&
                int.TryParse(this.textBox2.Text, out green) &&
                int.TryParse(this.textBox3.Text, out blue) &&
                red >= 0 && red <= 255 &&
                green >= 0 && green <= 255 &&
                blue >= 0 && blue <= 255)
            {
                form1.panel.BackColor = Color.FromArgb(red, green, blue);
            }
            else
                OKbutton.Enabled = Changebutton.Enabled = false;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                // Дополнительная логика
                //this.DialogResult = DialogResult.OK;
                int red, green, blue;
                if (int.TryParse(this.textBox1.Text, out red) &&
                    int.TryParse(this.textBox2.Text, out green) &&
                    int.TryParse(this.textBox3.Text, out blue) &&
                    red >= 0 && red <= 255 &&
                    green >= 0 && green <= 255 &&
                    blue >= 0 && blue <= 255)

                    form1.panel.BackColor = Color.FromArgb(red, green, blue);
                this.Close();
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                form1.panel.BackColor = Color.FromArgb(0, 0, 200);
                this.Close();
            }
            else
                OKbutton.Enabled = Changebutton.Enabled = false;
        } 

        public CustomColorForm()
        {
            InitializeComponent();
        }

        public CustomColorForm(Form1 form1, Panel panel)
        {
            InitializeComponent();
            this.form1 = form1;
            this.panel = panel;
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {

        }
    }
}