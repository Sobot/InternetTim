namespace InternetTim.Komentari
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class UnosKomentara : Form
    {
        private Button button1;
        private IContainer components = null;
        private Label label1;
        private Label label2;
        public string PersonalID = "";
        private TextBox textBox1;
        private TextBox textBox2;
        public string VestiID = "";

        public event EventHandler<PosaljiNazadKomentar> GlavniKomentar;

        public UnosKomentara()
        {
            this.InitializeComponent();
        }

        protected virtual void AktivirajSlanjeLinka(string[] text)
        {
            EventHandler<PosaljiNazadKomentar> glavniKomentar = this.GlavniKomentar;
            if (glavniKomentar != null)
            {
                PosaljiNazadKomentar e = new PosaljiNazadKomentar(text);
                glavniKomentar(this, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (this.textBox1.Text.Length > 30)
                {
                    WebClient client = new WebClient();
                    string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/InsertNewComment3.php?";
                    address = ((address + "Id=" + this.PersonalID) + "&IdVesti=" + this.VestiID) + "&Komentar=" + this.textBox1.Text.Replace("&", "[[]]");
                    string str2 = client.DownloadString(address);
                    if (str2.Contains("OKET") || str2.Contains("IMAKOMENTAR"))
                    {
                        Cursor.Current = Cursors.Default;
                        if (str2.Contains("OKET"))
                        {
                            MessageBox.Show("Uspešno prijavljen komentar.", "POTVRDA");
                        }
                        if (str2.Contains("IMAKOMENTAR"))
                        {
                            MessageBox.Show("Neko je već prijavio ovaj komentar kao njegov.\nVaš komentar je takođe sačuvan.\nStrogo je zabranjeno prisvajanje tuđih komentara.\nPronađeni duplikat će biti analiziran.", "UPOZORENJE");
                        }
                        string str3 = str2.Replace("OKET", "").Replace("IMAKOMENTAR", "").Replace("\r\n", "");
                        string[] text = new string[10];
                        text[0] = this.textBox1.Text;
                        text[1] = this.VestiID;
                        text[2] = this.textBox2.Text;
                        text[3] = DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString() + " - " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + "h";
                        text[4] = str3;
                        this.AktivirajSlanjeLinka(text);
                        base.Close();
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Greška prilikom prijavljivanja komentara, pokušajte kasnije ili restartujte program.", "INFO");
                        base.Close();
                    }
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Komentar je previše kratak, minimalno mora da ima bar 30 slova.", "INFO");
                    base.Close();
                }
            }
            catch
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Dogodila se greška, proverite internet.", "INFO");
                base.Close();
            }
            Cursor.Current = Cursors.Default;
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
            this.textBox1 = new TextBox();
            this.button1 = new Button();
            this.textBox2 = new TextBox();
            this.label1 = new Label();
            this.label2 = new Label();
            base.SuspendLayout();
            this.textBox1.Location = new Point(12, 0x19);
            this.textBox1.MaxLength = 0x640;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(470, 0x110);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
            this.button1.Cursor = Cursors.Hand;
            this.button1.Dock = DockStyle.Bottom;
            this.button1.FlatAppearance.BorderColor = Color.Gray;
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.FlatAppearance.MouseDownBackColor = Color.Red;
            this.button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(0xff, 0xc0, 0xc0);
            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.button1.Location = new Point(0, 0x160);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x1ee, 0x27);
            this.button1.TabIndex = 1;
            this.button1.Text = "POTVRDI PODATKE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.textBox2.Location = new Point(13, 320);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(0x1d5, 20);
            this.textBox2.TabIndex = 2;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 0x130);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x144, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "NAPOMENA - upiši neku napomenu za ovaj komentar u polje ispod";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0xf9, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "KOMENTAR - kopiraj tekst komentara u polje ispod";
            base.AcceptButton = this.button1;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.SandyBrown;
            base.ClientSize = new Size(0x1ee, 0x187);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.textBox2);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.button1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Name = "UnosKomentara";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Kopirajte tekst komentara koji ste poslali";
            base.TopMost = true;
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Contains("- See more at: http://www.danas.rs"))
            {
                int num = this.textBox1.Text.LastIndexOf('-');
                this.textBox1.Text = this.textBox1.Text.Remove(num - 1, (this.textBox1.Text.Length - num) + 1);
            }
        }

        public class PosaljiNazadKomentar : EventArgs
        {
            private readonly string[] KomentarK;

            public PosaljiNazadKomentar(string[] adviseText)
            {
                this.KomentarK = adviseText;
            }

            public string[] DobijenKomentar
            {
                get
                {
                    return this.KomentarK;
                }
            }
        }
    }
}

