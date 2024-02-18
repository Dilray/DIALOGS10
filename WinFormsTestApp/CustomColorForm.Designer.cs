using System.Windows.Forms;

namespace WinFormsTestApp
{
    partial class CustomColorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;



        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.OKbutton = new System.Windows.Forms.Button();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.Changebutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(592, 382);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(70, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyPress += textBox_KeyPress;
            this.textBox1.TextChanged += LockedButtons;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(668, 382);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(70, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.KeyPress += textBox_KeyPress;
            this.textBox2.TextChanged += LockedButtons;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(744, 382);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(70, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.KeyPress += textBox_KeyPress;
            this.textBox3.TextChanged += LockedButtons;
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(569, 481);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(86, 23);
            this.OKbutton.TabIndex = 3;
            this.OKbutton.Text = "OK";
            this.OKbutton.Click += ChangeBackgroundColorButtonClick1;
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Location = new System.Drawing.Point(661, 481);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(86, 23);
            this.Cancelbutton.TabIndex = 4;
            this.Cancelbutton.Text = "Отмена";
            this.Cancelbutton.Click += cancel;
            // 
            // Changebutton
            // 
            this.Changebutton.Location = new System.Drawing.Point(753, 481);
            this.Changebutton.Name = "Changebutton";
            this.Changebutton.Size = new System.Drawing.Size(86, 23);
            this.Changebutton.TabIndex = 5;
            this.Changebutton.Text = "Применить";
            this.Changebutton.Click += ChangeBackgroundColorButtonClick;
            // 
            // CustomColorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 555);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.Cancelbutton);
            this.Controls.Add(this.Changebutton);
            this.Name = "CustomColorForm";
            this.Text = "CustomColorForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}