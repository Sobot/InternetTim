namespace InternetTim.Izvestaji.UzivoIzvestaji
{
    using InternetTim.Properties;
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;

    public class UzivoVestiStatsKomentari : Form
    {
        private Button button1;
        private IContainer components = null;
        private FlowLayoutPanel flowLayoutPanel1;
        private int GledajVest = 0;
        private int MaxUcitanihVesti = 20;
        private int PocetnoUcitavanje = 0;
        private UVSvest PrivremenaVest;
        private int ProlazakKrozSveVesti = 5;
        private int PrvaUcitavanja = 2;
        private System.Windows.Forms.Timer timerPocetnoUcitavanje;
        private System.Windows.Forms.Timer timerSkroling;
        private int Ucitano = 0;
        private string[] VestiId = new string[300];
        private string[] VestiNaslov = new string[300];
        private string[] VestiPrioritet = new string[300];
        private string[] VestiSlika = new string[300];
        private string[] VestiUrl = new string[300];

        public UzivoVestiStatsKomentari()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.button1.Visible = false;
                base.FormBorderStyle = FormBorderStyle.None;
                base.WindowState = FormWindowState.Maximized;
                this.flowLayoutPanel1.Dock = DockStyle.Fill;
                this.SkidanjeVesti();
            }
            catch
            {
                base.Close();
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

        private void flowLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            base.Close();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.flowLayoutPanel1 = new FlowLayoutPanel();
            this.button1 = new Button();
            this.timerPocetnoUcitavanje = new System.Windows.Forms.Timer(this.components);
            this.timerSkroling = new System.Windows.Forms.Timer(this.components);
            base.SuspendLayout();
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackgroundImage = Resources.darkconcretewall;
            this.flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new Point(0x15, 320);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new Size(0x2ce, 0x145);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            this.flowLayoutPanel1.MouseClick += new MouseEventHandler(this.flowLayoutPanel1_MouseClick);
            this.button1.Cursor = Cursors.Hand;
            this.button1.Dock = DockStyle.Fill;
            this.button1.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.button1.Location = new Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new Size(420, 0xb9);
            this.button1.TabIndex = 1;
            this.button1.Text = "POSTAVI PROZOR NA MONITOR I KLIKNI OVDE DA AKTIVIRAS IZVEŠTAJ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.timerPocetnoUcitavanje.Interval = 0x3a98;
            this.timerPocetnoUcitavanje.Tick += new EventHandler(this.timerPocetnoUcitavanje_Tick);
            this.timerSkroling.Interval = 0x3a98;
            this.timerSkroling.Tick += new EventHandler(this.timerSkroling_Tick);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            base.ClientSize = new Size(420, 0xb9);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.flowLayoutPanel1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Name = "UzivoVestiStatsKomentari";
            base.ShowInTaskbar = false;
            this.Text = "Vesti";
            base.ResumeLayout(false);
        }

        private void NapraviVest(string id, string link, int start, string naslov, string slika, string prio)
        {
            try
            {
                int velicina = this.flowLayoutPanel1.Size.Height / 3;
                UVSvest svest = new UVSvest {
                    Size = new Size(this.flowLayoutPanel1.Size.Width - 40, (this.flowLayoutPanel1.Size.Height / 3) - 12)
                };
                svest.Pocetak(id, link, start, naslov, slika, velicina);
                this.flowLayoutPanel1.Controls.Add(svest);
                this.flowLayoutPanel1.ScrollControlIntoView(svest);
            }
            catch
            {
            }
        }

        private void SkidanjeVesti()
        {
            try
            {
                this.flowLayoutPanel1.Controls.Clear();
                this.PocetnoUcitavanje = 0;
                Array.Clear(this.VestiUrl, 0, 300);
                Array.Clear(this.VestiId, 0, 300);
                Array.Clear(this.VestiPrioritet, 0, 300);
                Array.Clear(this.VestiNaslov, 0, 300);
                Array.Clear(this.VestiSlika, 0, 300);
                this.ProlazakKrozSveVesti = 5;
                this.Ucitano = 0;
                this.GledajVest = 0;
                WebClient client = new WebClient();
                JsonTextReader reader = new JsonTextReader(new StringReader(client.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/GetAllNews.php")));
                int num = 0;
                while (reader.Read())
                {
                    if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                    {
                        switch (num)
                        {
                            case 0:
                                this.VestiId[this.PocetnoUcitavanje] = reader.Value.ToString();
                                break;

                            case 1:
                                this.VestiUrl[this.PocetnoUcitavanje] = reader.Value.ToString().Replace("[[]]", "&");
                                break;

                            case 2:
                                this.VestiPrioritet[this.PocetnoUcitavanje] = reader.Value.ToString();
                                break;

                            case 3:
                                this.VestiNaslov[this.PocetnoUcitavanje] = reader.Value.ToString();
                                break;

                            case 4:
                                this.VestiSlika[this.PocetnoUcitavanje] = reader.Value.ToString().Replace("[[]]", "&");
                                break;
                        }
                        num++;
                        if (num == 5)
                        {
                            this.PocetnoUcitavanje++;
                            num = 0;
                        }
                    }
                }
                this.PrvaUcitavanja = this.PocetnoUcitavanje - 1;
                this.timerPocetnoUcitavanje.Enabled = true;
                this.timerPocetnoUcitavanje.Start();
            }
            catch
            {
                base.Close();
            }
        }

        private void timerPocetnoUcitavanje_Tick(object sender, EventArgs e)
        {
            this.timerPocetnoUcitavanje.Stop();
            this.timerPocetnoUcitavanje.Enabled = false;
            if ((this.PrvaUcitavanja == -1) || (this.Ucitano > this.MaxUcitanihVesti))
            {
                this.timerSkroling.Enabled = true;
                this.timerSkroling.Start();
            }
            else
            {
                this.NapraviVest(this.VestiId[this.PrvaUcitavanja], this.VestiUrl[this.PrvaUcitavanja], 0, this.VestiNaslov[this.PrvaUcitavanja], this.VestiSlika[this.PrvaUcitavanja], this.VestiPrioritet[this.PrvaUcitavanja]);
                this.timerPocetnoUcitavanje.Enabled = true;
                this.timerPocetnoUcitavanje.Start();
            }
            this.PrvaUcitavanja--;
            this.Ucitano++;
        }

        private void timerSkroling_Tick(object sender, EventArgs e)
        {
            try
            {
                this.PrivremenaVest = (UVSvest) this.flowLayoutPanel1.Controls[this.GledajVest];
                this.PrivremenaVest.PokreniAzuriranje();
            }
            catch
            {
            }
            this.flowLayoutPanel1.ScrollControlIntoView(this.flowLayoutPanel1.Controls[this.GledajVest]);
            if (this.GledajVest == this.MaxUcitanihVesti)
            {
                this.GledajVest = -1;
                this.ProlazakKrozSveVesti--;
            }
            this.GledajVest++;
            if (this.ProlazakKrozSveVesti < 1)
            {
                this.timerSkroling.Stop();
                this.timerSkroling.Enabled = false;
                this.SkidanjeVesti();
            }
        }
    }
}

