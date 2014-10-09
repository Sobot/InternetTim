namespace InternetTim.Komentari
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class LinkKaVestima : Form
    {
        private BackgroundWorker backgroundWorker1;
        private Button button1;
        private IContainer components = null;
        private ProgressBar progressBar1;
        private TextBox textBox1;

        public event EventHandler<PosaljiNazadLink> GlavniLink;

        public LinkKaVestima()
        {
            this.InitializeComponent();
        }

        protected virtual void AktivirajSlanjeLinka(string text)
        {
            EventHandler<PosaljiNazadLink> glavniLink = this.GlavniLink;
            if (glavniLink != null)
            {
                PosaljiNazadLink e = new PosaljiNazadLink(text);
                glavniLink(this, e);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                this.backgroundWorker1.ReportProgress(1);
                string str = client.DownloadString(e.Argument.ToString());
                this.backgroundWorker1.ReportProgress(1);
                if (str.Length > 300)
                {
                    string str2 = e.Argument.ToString();
                    this.backgroundWorker1.ReportProgress(1);
                    if ((((!str2.Contains("www.blic.rs") && !str2.Contains("b92.net")) && (!str2.Contains("kurir-info.rs") && !str2.Contains("novosti.rs"))) && ((!str2.Contains("danas.rs") && !str2.Contains("telegraf.rs")) && (!str2.Contains("politika.rs") && !str2.Contains("rts.rs")))) && !str2.Contains("alo.rs"))
                    {
                        if (str2.Contains("komentar"))
                        {
                            this.backgroundWorker1.ReportProgress(1);
                            e.Result = "GRESKA";
                        }
                        else
                        {
                            this.backgroundWorker1.ReportProgress(1);
                            e.Result = "OTVORI";
                        }
                    }
                    else if (!(str2.Contains("facebook") || str2.Contains("komentar")))
                    {
                        this.backgroundWorker1.ReportProgress(1);
                        e.Result = "DOBRO";
                    }
                    else
                    {
                        this.backgroundWorker1.ReportProgress(1);
                        e.Result = "GRESKA";
                    }
                }
            }
            catch
            {
                e.Result = "GRESKA";
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.PerformStep();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.ToString() == "OTVORI")
            {
                DodatnaVest vest = new DodatnaVest();
                vest.GlavnaSlika += new EventHandler<DodatnaVest.PosaljiNazadSlika>(this.ves_GlavnaSlika);
                vest.Show();
            }
            if (e.Result.ToString() == "GRESKA")
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Dogodila se greška.\nLink koji ste kopirali nije dobar.\n\nDa bi link bio dobar mora da zadovolji sledeće uslove:\n\n1. Link mora biti direktno sa tog portala ne sa fejsbuka.\n2. Link mora da bude link ka vestima a ne ka komentarima te vesti.\n3. Program prvo proveri da li vest postoji, proverite da li radi internet.\n4. Ako i dalje vidite da je link dobar prijavite ovaj problem u opciji programa PRIJAVI PROBLEM.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (e.Result.ToString() == "DOBRO")
            {
                this.AktivirajSlanjeLinka(this.textBox1.Text);
                base.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.progressBar1.Value = 0;
                this.backgroundWorker1.RunWorkerAsync(this.textBox1.Text);
            }
            catch
            {
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
            this.progressBar1 = new ProgressBar();
            this.backgroundWorker1 = new BackgroundWorker();
            base.SuspendLayout();
            this.textBox1.BackColor = Color.Lavender;
            this.textBox1.Dock = DockStyle.Top;
            this.textBox1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.textBox1.Location = new Point(0, 0);
            this.textBox1.MaxLength = 500;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x3e9, 0x1a);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Ovde kopiraj link vesti";
            this.button1.BackColor = Color.DarkSlateGray;
            this.button1.Cursor = Cursors.Hand;
            this.button1.Dock = DockStyle.Fill;
            this.button1.FlatAppearance.BorderColor = Color.SteelBlue;
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.FlatAppearance.MouseDownBackColor = Color.Red;
            this.button1.FlatAppearance.MouseOverBackColor = Color.Silver;
            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.button1.ForeColor = Color.White;
            this.button1.Location = new Point(0, 0x1a);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x3e9, 0x48);
            this.button1.TabIndex = 1;
            this.button1.Text = "POTVRDI LINK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.progressBar1.Dock = DockStyle.Bottom;
            this.progressBar1.Location = new Point(0, 0x62);
            this.progressBar1.Maximum = 4;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new Size(0x3e9, 0x18);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Value = 4;
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x3e9, 0x7a);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.progressBar1);
            base.Controls.Add(this.textBox1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Name = "LinkKaVestima";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Kopiraj link vesti";
            base.TopMost = true;
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void ves_GlavnaSlika(object sender, DodatnaVest.PosaljiNazadSlika e)
        {
            this.AktivirajSlanjeLinka(this.textBox1.Text + "*" + e.DobijenaSlika);
            base.Close();
        }

        public class PosaljiNazadLink : EventArgs
        {
            private readonly string BrojIP;

            public PosaljiNazadLink(string adviseText)
            {
                this.BrojIP = adviseText;
            }

            public string DobijenLink
            {
                get
                {
                    return this.BrojIP;
                }
            }
        }
    }
}

