namespace InternetTim.Obavestenja
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class PrikaziObavestenje : Form
    {
        private Button button1;
        private IContainer components = null;
        public string Naslov = "";
        private RichTextBox richTextBox1;
        public string Tekst = "";

        public PrikaziObavestenje()
        {
            this.InitializeComponent();
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
            this.button1 = new Button();
            this.richTextBox1 = new RichTextBox();
            base.SuspendLayout();
            this.button1.FlatAppearance.BorderColor = Color.DarkRed;
            this.button1.FlatAppearance.BorderSize = 5;
            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.button1.ForeColor = Color.Red;
            this.button1.Location = new Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new Size(770, 0x53);
            this.button1.TabIndex = 0;
            this.button1.Text = "Naslov";
            this.button1.UseVisualStyleBackColor = true;
            this.richTextBox1.Location = new Point(12, 0x65);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new Size(770, 0x1cf);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(0x31a, 0x240);
            base.Controls.Add(this.richTextBox1);
            base.Controls.Add(this.button1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Name = "PrikaziObavestenje";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "OBAVEŠTENJE";
            base.TopMost = true;
            base.Load += new EventHandler(this.PrikaziObavestenje_Load);
            base.ResumeLayout(false);
        }

        private void PrikaziObavestenje_Load(object sender, EventArgs e)
        {
            this.button1.Text = this.Naslov;
            this.richTextBox1.Rtf = this.Tekst;
        }
    }
}

