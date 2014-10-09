namespace InternetTim.Glasanje
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Threading;
    using System.Windows.Forms;

    public class ProveraProxyServera : Form
    {
        private string[] adrese = new string[0x2710];
        private BackgroundWorker backgroundWorker1;
        private IContainer components = null;
        private int ImaGresku = 0;
        private System.Windows.Forms.Timer KrajProvere;
        private Label label1;
        private Label label2;
        private Label label3;
        private string MojaIp = "";
        private string[] portovi = new string[0x2710];
        private int potvrdjeni = 0;
        private ProgressBar progressBar1;
        private Button ProveraServeraIzBaze;
        private int stanje = 0;
        private TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private int trenutnirun = 0;
        private Button UcitajKingsProxyServere;
        private Button UnosServera;
        private int zavrsilo = 0;

        public ProveraProxyServera()
        {
            this.InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] strArray = e.Argument.ToString().Split(new char[] { '*' });
            int num = 0;
            foreach (string str2 in strArray)
            {
                if (str2.Contains("."))
                {
                    string[] strArray2 = str2.Split(new char[] { ':' });
                    try
                    {
                        WebClient client = new WebClient();
                        string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Glasanje/InsertNewProxyServer.php?";
                        address = (address + "IPadresa=" + strArray2[0]) + "&IPport=" + strArray2[1];
                        if (client.DownloadString(address).Contains("OKET"))
                        {
                        }
                        this.backgroundWorker1.ReportProgress(1);
                        Thread.Sleep(250);
                    }
                    catch
                    {
                    }
                }
                num++;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.PerformStep();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Gotovo ubacivanje podataka u bazu", "INFO");
            this.textBox1.Text = "";
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
            this.components = new Container();
            this.textBox1 = new TextBox();
            this.UnosServera = new Button();
            this.UcitajKingsProxyServere = new Button();
            this.ProveraServeraIzBaze = new Button();
            this.progressBar1 = new ProgressBar();
            this.backgroundWorker1 = new BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new Label();
            this.KrajProvere = new System.Windows.Forms.Timer(this.components);
            this.label2 = new Label();
            this.label3 = new Label();
            base.SuspendLayout();
            this.textBox1.Location = new Point(12, 0x76);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = ScrollBars.Vertical;
            this.textBox1.Size = new Size(0x337, 0x18b);
            this.textBox1.TabIndex = 0;
            this.UnosServera.Location = new Point(12, 0x207);
            this.UnosServera.Name = "UnosServera";
            this.UnosServera.Size = new Size(0x337, 0x17);
            this.UnosServera.TabIndex = 1;
            this.UnosServera.Text = "Unos servera";
            this.UnosServera.UseVisualStyleBackColor = true;
            this.UnosServera.Click += new EventHandler(this.UnosServera_Click);
            this.UcitajKingsProxyServere.Location = new Point(12, 0x59);
            this.UcitajKingsProxyServere.Name = "UcitajKingsProxyServere";
            this.UcitajKingsProxyServere.Size = new Size(0xb3, 0x17);
            this.UcitajKingsProxyServere.TabIndex = 2;
            this.UcitajKingsProxyServere.Text = "Ucitaj kings proxy servere";
            this.UcitajKingsProxyServere.UseVisualStyleBackColor = true;
            this.UcitajKingsProxyServere.Click += new EventHandler(this.UcitajKingsProxyServere_Click);
            this.ProveraServeraIzBaze.Location = new Point(0xc5, 0x2d);
            this.ProveraServeraIzBaze.Name = "ProveraServeraIzBaze";
            this.ProveraServeraIzBaze.Size = new Size(0xb3, 0x43);
            this.ProveraServeraIzBaze.TabIndex = 3;
            this.ProveraServeraIzBaze.Text = "Pokreni proveru servera iz baze";
            this.ProveraServeraIzBaze.UseVisualStyleBackColor = true;
            this.ProveraServeraIzBaze.Click += new EventHandler(this.ProveraServeraIzBaze_Click);
            this.progressBar1.Location = new Point(13, 0x223);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new Size(0x336, 0x17);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 4;
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.timer1.Interval = 300;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x17e, 0x52);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x1f, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "OK - ";
            this.KrajProvere.Interval = 0x2710;
            this.KrajProvere.Tick += new EventHandler(this.KrajProvere_Tick);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x17e, 0x63);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x26, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "BAD - ";
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label3.Location = new Point(0x17e, 0x2d);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x54, 0x25);
            this.label3.TabIndex = 7;
            this.label3.Text = "00%";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(0x34f, 0x23f);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.progressBar1);
            base.Controls.Add(this.ProveraServeraIzBaze);
            base.Controls.Add(this.UcitajKingsProxyServere);
            base.Controls.Add(this.UnosServera);
            base.Controls.Add(this.textBox1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Name = "ProveraProxyServera";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Provera proxy servera";
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void KrajProvere_Tick(object sender, EventArgs e)
        {
            this.KrajProvere.Stop();
            this.KrajProvere.Enabled = false;
            if (this.zavrsilo == this.stanje)
            {
                string str = new WebClient().DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Glasanje/DeleteProxyZero.php");
                string str2 = new WebClient().DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Glasanje/DeletyOff48hServers.php");
                MessageBox.Show("Gotova provera servera", "INFO");
                this.textBox1.Text = "";
            }
            else
            {
                this.KrajProvere.Enabled = true;
                this.KrajProvere.Start();
            }
        }

        private void novi_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] strArray = e.Argument.ToString().Split(new char[] { ':' });
            try
            {
                WebClient client = new WebClient();
                WebProxy proxy = new WebProxy(strArray[0], int.Parse(strArray[1]));
                client.Proxy = proxy;
                string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Glasanje/InsertProxyOnlineStatus2.php?IPadresa=" + strArray[0] + "&IPport=" + strArray[1] + "&CompareIPadresa=" + this.MojaIp;
                string str2 = client.DownloadString(address);
                e.Result = e.Argument.ToString() + " - OK";
            }
            catch
            {
                e.Result = e.Argument.ToString() + " - BAD";
            }
        }

        private void novi_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text + "  -  " + e.Result.ToString();
            this.progressBar1.PerformStep();
            this.zavrsilo++;
            if (e.Result.ToString().Contains("OK"))
            {
                this.potvrdjeni++;
                this.label1.Text = "OK - " + this.potvrdjeni.ToString();
            }
            else
            {
                this.ImaGresku++;
                this.label2.Text = "BAD - " + this.ImaGresku.ToString();
            }
            decimal d = this.potvrdjeni / this.zavrsilo;
            d *= 100M;
            this.label3.Text = Math.Round(d, 2).ToString() + "%";
        }

        private void ProveraServeraIzBaze_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string str = new WebClient().DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Glasanje/GetMyIP.php");
                this.MojaIp = str.Replace("\r\n", "");
                this.stanje = 0;
                Array.Clear(this.adrese, 0, 0x2710);
                Array.Clear(this.portovi, 0, 0x2710);
                this.progressBar1.Value = 0;
                WebClient client2 = new WebClient();
                JsonTextReader reader = new JsonTextReader(new StringReader(client2.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Glasanje/GetAllServers.php")));
                int num = 0;
                while (reader.Read())
                {
                    if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                    {
                        switch (num)
                        {
                            case 0:
                                this.adrese[this.stanje] = reader.Value.ToString();
                                break;

                            case 1:
                                this.portovi[this.stanje] = reader.Value.ToString();
                                break;
                        }
                        num++;
                        if (num == 2)
                        {
                            this.stanje++;
                            num = 0;
                        }
                    }
                }
                this.progressBar1.Maximum = this.stanje;
                this.potvrdjeni = 0;
                this.zavrsilo = 0;
                this.trenutnirun = 0;
                this.textBox1.Text = "";
                this.timer1.Enabled = true;
                this.timer1.Start();
            }
            catch
            {
            }
            Cursor.Current = Cursors.Default;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.timer1.Enabled = false;
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(this.novi_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.novi_RunWorkerCompleted);
            worker.RunWorkerAsync(this.adrese[this.trenutnirun] + ":" + this.portovi[this.trenutnirun]);
            this.trenutnirun++;
            if (this.trenutnirun < this.stanje)
            {
                this.timer1.Enabled = true;
                this.timer1.Start();
            }
            else
            {
                this.KrajProvere.Enabled = true;
                this.KrajProvere.Start();
            }
        }

        private void UcitajKingsProxyServere_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.textBox1.Text = "";
            try
            {
                WebClient client = new WebClient();
                string address = "http://kingproxies.com/api/v1/proxies.json?key=97b486abe6e5743fdbfcaf1626abc8&limit=500&supports=post&type=anonymous,elite&protocols=http,https";
                JsonTextReader reader = new JsonTextReader(new StringReader(client.DownloadString(address)));
                int num2 = 0;
                while (reader.Read())
                {
                    if (reader.Value != null)
                    {
                        if (reader.Value.ToString().Contains("."))
                        {
                            this.textBox1.Text = this.textBox1.Text + reader.Value.ToString();
                            num2 = 1;
                        }
                        else
                        {
                            int num;
                            if (int.TryParse(reader.Value.ToString(), out num) && (num2 == 1))
                            {
                                this.textBox1.Text = this.textBox1.Text + ":" + reader.Value.ToString() + "\r\n";
                                num2 = 0;
                                continue;
                            }
                        }
                    }
                }
            }
            catch
            {
                Cursor.Current = Cursors.Default;
            }
            Cursor.Current = Cursors.Default;
        }

        private void UnosServera_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string argument = this.textBox1.Text.Replace("\r\n", "*");
            int length = argument.Split(new char[] { '*' }).Length;
            this.progressBar1.Maximum = length;
            this.progressBar1.Value = 0;
            this.backgroundWorker1.RunWorkerAsync(argument);
        }
    }
}

