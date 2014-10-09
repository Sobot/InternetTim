namespace InternetTim.Komentari
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class StanjePoslatihKomentara : Form
    {
        private IContainer components = null;
        public string IDVesti = "";
        public string[] MKDatumUnosaKomentara = new string[0x1f40];
        public string[] MKNapomenaKomentara = new string[0x1f40];
        public string[] MKObjavljeni = new string[0x1f40];
        public string[] MKVestiID = new string[0x1f40];
        public string[] MojiKomentari = new string[0x1f40];
        private TextBox textBox1;

        public StanjePoslatihKomentara()
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(StanjePoslatihKomentara));
            this.textBox1 = new TextBox();
            base.SuspendLayout();
            this.textBox1.Dock = DockStyle.Fill;
            this.textBox1.Location = new Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = ScrollBars.Vertical;
            this.textBox1.Size = new Size(760, 0x29b);
            this.textBox1.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(760, 0x29b);
            base.Controls.Add(this.textBox1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "StanjePoslatihKomentara";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Stanje komentara";
            base.Shown += new EventHandler(this.StanjePoslatihKomentara_Shown);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void StanjePoslatihKomentara_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                int index = 0;
                int num2 = 0;
                foreach (string str in this.MojiKomentari)
                {
                    if (str == null)
                    {
                        break;
                    }
                    if (this.MKVestiID[index] == this.IDVesti)
                    {
                        if (this.MKObjavljeni[index] == "DA")
                        {
                            this.textBox1.Text = this.textBox1.Text + "\r\n\r\n>>>>>>>>>>>>>>>>>>>>>>>>>>>> KOMENTAR JE OBJAVLJEN <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\r\n";
                        }
                        else
                        {
                            this.textBox1.Text = this.textBox1.Text + "\r\n\r\n--------------------------- KOMENTAR NIJE OBJAVLJEN -----------------------------\r\n";
                        }
                        this.textBox1.Text = this.textBox1.Text + "Vreme unosa komentara: " + this.MKDatumUnosaKomentara[index] + "\r\n";
                        this.textBox1.Text = this.textBox1.Text + "Napomena: " + this.MKNapomenaKomentara[index] + "\r\n\r\n";
                        this.textBox1.Text = this.textBox1.Text + this.MojiKomentari[index] + "\r\n\r\n";
                        num2++;
                    }
                    index++;
                }
                if (num2 == 0)
                {
                    this.textBox1.Text = this.textBox1.Text + "\r\n\r\nNEMATE PRIJAVLJENIH KOMENTARA ZA OVU VEST";
                }
            }
            catch
            {
            }
            Cursor.Current = Cursors.Default;
        }
    }
}

