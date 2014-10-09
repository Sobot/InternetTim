namespace InternetTim.Komentari
{
    using InternetTim.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class DodatnaVest : Form
    {
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private IContainer components = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private string slika = "";
        private TextBox textBox1;

        public event EventHandler<PosaljiNazadSlika> GlavnaSlika;

        public DodatnaVest()
        {
            this.InitializeComponent();
        }

        protected virtual void AktivirajSlanjeSlika(string text)
        {
            EventHandler<PosaljiNazadSlika> glavnaSlika = this.GlavnaSlika;
            if (glavnaSlika != null)
            {
                PosaljiNazadSlika e = new PosaljiNazadSlika(text);
                glavnaSlika(this, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.SlikeGranice();
            this.button1.FlatAppearance.BorderSize = 5;
            this.slika = "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.SlikeGranice();
            this.button2.FlatAppearance.BorderSize = 5;
            this.slika = "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.SlikeGranice();
            this.button3.FlatAppearance.BorderSize = 5;
            this.slika = "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.SlikeGranice();
            this.button4.FlatAppearance.BorderSize = 5;
            this.slika = "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.AktivirajSlanjeSlika(this.slika + "*" + this.textBox1.Text.Replace("*", ""));
            base.Close();
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
            this.label1 = new Label();
            this.textBox1 = new TextBox();
            this.label2 = new Label();
            this.label3 = new Label();
            this.button1 = new Button();
            this.button2 = new Button();
            this.button3 = new Button();
            this.button4 = new Button();
            this.button5 = new Button();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(0xbd, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x1fd, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "                                  Link koji ste kopirali nije sa \r\nBLIC , B92 , KURIR , NOVOSTI, DANAS, TELEGRAF, POLITIKA, RTS";
            this.textBox1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.textBox1.Location = new Point(13, 0x6d);
            this.textBox1.MaxLength = 150;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x326, 0x1a);
            this.textBox1.TabIndex = 1;
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(12, 0x56);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x97, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Napišite naslov vesti";
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.Location = new Point(12, 0xac);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0xab, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Odaberite sliku za vesti";
            this.button1.BackgroundImage = Resources.facebook;
            this.button1.BackgroundImageLayout = ImageLayout.Stretch;
            this.button1.Cursor = Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = Color.FromArgb(0xff, 0x80, 0);
            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.Location = new Point(0x3e, 0xd0);
            this.button1.Name = "button1";
            this.button1.Size = new Size(150, 100);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.button2.BackgroundImage = Resources.twitter;
            this.button2.BackgroundImageLayout = ImageLayout.Stretch;
            this.button2.Cursor = Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = Color.FromArgb(0xff, 0x80, 0);
            this.button2.FlatStyle = FlatStyle.Flat;
            this.button2.Location = new Point(0xef, 0xd0);
            this.button2.Name = "button2";
            this.button2.Size = new Size(150, 100);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.button3.BackgroundImage = Resources.youtube;
            this.button3.BackgroundImageLayout = ImageLayout.Stretch;
            this.button3.Cursor = Cursors.Hand;
            this.button3.FlatAppearance.BorderColor = Color.FromArgb(0xff, 0x80, 0);
            this.button3.FlatStyle = FlatStyle.Flat;
            this.button3.Location = new Point(0x19e, 0xd0);
            this.button3.Name = "button3";
            this.button3.Size = new Size(150, 100);
            this.button3.TabIndex = 6;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(this.button3_Click);
            this.button4.BackgroundImage = Resources.newssrbija;
            this.button4.BackgroundImageLayout = ImageLayout.Stretch;
            this.button4.Cursor = Cursors.Hand;
            this.button4.FlatAppearance.BorderColor = Color.FromArgb(0xff, 0x80, 0);
            this.button4.FlatStyle = FlatStyle.Flat;
            this.button4.Location = new Point(0x251, 0xd0);
            this.button4.Name = "button4";
            this.button4.Size = new Size(150, 100);
            this.button4.TabIndex = 7;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new EventHandler(this.button4_Click);
            this.button5.Cursor = Cursors.Hand;
            this.button5.Dock = DockStyle.Bottom;
            this.button5.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.button5.Location = new Point(0, 0x17e);
            this.button5.Name = "button5";
            this.button5.Size = new Size(0x33f, 0x38);
            this.button5.TabIndex = 8;
            this.button5.Text = "POTVRDI";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new EventHandler(this.button5_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(0x33f, 0x1b6);
            base.Controls.Add(this.button5);
            base.Controls.Add(this.button4);
            base.Controls.Add(this.button3);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.label1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Name = "DodatnaVest";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Nepoznata vest";
            base.TopMost = true;
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void SlikeGranice()
        {
            this.button1.FlatAppearance.BorderSize = 1;
            this.button2.FlatAppearance.BorderSize = 1;
            this.button3.FlatAppearance.BorderSize = 1;
            this.button4.FlatAppearance.BorderSize = 1;
        }

        public class PosaljiNazadSlika : EventArgs
        {
            private readonly string BrojIP;

            public PosaljiNazadSlika(string adviseText)
            {
                this.BrojIP = adviseText;
            }

            public string DobijenaSlika
            {
                get
                {
                    return this.BrojIP;
                }
            }
        }
    }
}

