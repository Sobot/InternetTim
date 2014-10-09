namespace InternetTim.Zastita
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class PotvrdaGlavneSifre : Form
    {
        private Button button1;
        private IContainer components = null;
        public string glavnasifra = "";
        private MaskedTextBox maskedTextBox1;

        public PotvrdaGlavneSifre()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = this.maskedTextBox1.Text;
            if (("DA" + text) == this.glavnasifra)
            {
                this.Text = "OK";
                base.Close();
            }
            else
            {
                MessageBox.Show("Pogrešna šifra", "INFO");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.maskedTextBox1 = new MaskedTextBox();
            this.button1 = new Button();
            base.SuspendLayout();
            this.maskedTextBox1.Font = new Font("Microsoft Sans Serif", 27.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.maskedTextBox1.Location = new Point(12, 12);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.PasswordChar = '?';
            this.maskedTextBox1.Size = new Size(0x1c9, 0x31);
            this.maskedTextBox1.TabIndex = 0;
            this.button1.Cursor = Cursors.Hand;
            this.button1.Location = new Point(13, 0x44);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x1c8, 0x2f);
            this.button1.TabIndex = 1;
            this.button1.Text = "POTVRDI";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Red;
            base.ClientSize = new Size(0x1e1, 0x80);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.maskedTextBox1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Name = "PotvrdaGlavneSifre";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Unos sifre";
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

