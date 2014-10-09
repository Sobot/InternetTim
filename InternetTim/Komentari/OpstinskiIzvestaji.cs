namespace InternetTim.Komentari
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;

    public class OpstinskiIzvestaji : Form
    {
        private string BodoviObjavljenKomentarDatum = "";
        private string BodoviObjavljenKomentarKorisnik = "";
        private CheckBox BodoviZaObjavljeneKomentare;
        private IContainer components = null;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private int glavnibroj = 0;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        public string ID = "";
        private CheckBox KoriscenjePorgrama;
        private string KoriscenjeProgramaDatum = "";
        private string KoriscenjeProgramaKorisnik = "";
        private int KoriscenjeProgramaPocetniTekst = 0;
        private Label label1;
        private Label label2;
        private ListBox listBox1;
        private Button NapraviIzvestaj;
        private CheckBox ObjavljeniKomentari;
        private string ObjavljenKomentarDatum = "";
        private string ObjavljenKomentarKorisnik = "";
        private decimal[] OdDoUkupnoBodova = new decimal[0x3e8];
        private string[] OpstineDozvoljene = new string[500];
        private ProgressBar progressBar1;
        private RichTextBox richTextBox1;
        private SplitContainer splitContainer1;
        private string[] SviDatumi = new string[500];
        private string[] SviKorisnici = new string[0x3e8];
        private string[] SviKorisniciImena = new string[0x3e8];
        private System.Windows.Forms.Timer timer1;
        private string[] UserID = new string[0x3e8];
        private string[] UserName = new string[0x3e8];

        public OpstinskiIzvestaji()
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
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(OpstinskiIzvestaji));
            this.splitContainer1 = new SplitContainer();
            this.groupBox2 = new GroupBox();
            this.listBox1 = new ListBox();
            this.groupBox3 = new GroupBox();
            this.BodoviZaObjavljeneKomentare = new CheckBox();
            this.ObjavljeniKomentari = new CheckBox();
            this.NapraviIzvestaj = new Button();
            this.groupBox1 = new GroupBox();
            this.label2 = new Label();
            this.dateTimePicker2 = new DateTimePicker();
            this.label1 = new Label();
            this.dateTimePicker1 = new DateTimePicker();
            this.richTextBox1 = new RichTextBox();
            this.progressBar1 = new ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.KoriscenjePorgrama = new CheckBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.splitContainer1.Dock = DockStyle.Fill;
            this.splitContainer1.FixedPanel = FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.NapraviIzvestaj);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1MinSize = 350;
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Panel2.Controls.Add(this.progressBar1);
            this.splitContainer1.Size = new Size(0x374, 0x2c7);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.TabIndex = 0;
            this.groupBox2.BackColor = Color.DarkGray;
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Dock = DockStyle.Fill;
            this.groupBox2.ForeColor = Color.White;
            this.groupBox2.Location = new Point(0, 0x4b);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(350, 0x1eb);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Korisnici";
            this.listBox1.BackColor = Color.DarkGray;
            this.listBox1.Dock = DockStyle.Fill;
            this.listBox1.ForeColor = Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new Point(3, 0x10);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = SelectionMode.MultiSimple;
            this.listBox1.Size = new Size(0x158, 0x1d8);
            this.listBox1.TabIndex = 0;
            this.groupBox3.BackColor = Color.DimGray;
            this.groupBox3.Controls.Add(this.KoriscenjePorgrama);
            this.groupBox3.Controls.Add(this.BodoviZaObjavljeneKomentare);
            this.groupBox3.Controls.Add(this.ObjavljeniKomentari);
            this.groupBox3.Dock = DockStyle.Bottom;
            this.groupBox3.ForeColor = Color.White;
            this.groupBox3.Location = new Point(0, 0x236);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(350, 0x6d);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Opcije";
            this.BodoviZaObjavljeneKomentare.AutoSize = true;
            this.BodoviZaObjavljeneKomentare.Location = new Point(6, 0x2a);
            this.BodoviZaObjavljeneKomentare.Name = "BodoviZaObjavljeneKomentare";
            this.BodoviZaObjavljeneKomentare.Size = new Size(0xb1, 0x11);
            this.BodoviZaObjavljeneKomentare.TabIndex = 1;
            this.BodoviZaObjavljeneKomentare.Text = "Bodovi za objavljene komentare";
            this.BodoviZaObjavljeneKomentare.UseVisualStyleBackColor = true;
            this.ObjavljeniKomentari.AutoSize = true;
            this.ObjavljeniKomentari.Location = new Point(6, 0x13);
            this.ObjavljeniKomentari.Name = "ObjavljeniKomentari";
            this.ObjavljeniKomentari.Size = new Size(0x79, 0x11);
            this.ObjavljeniKomentari.TabIndex = 0;
            this.ObjavljeniKomentari.Text = "Objavljeni komentari";
            this.ObjavljeniKomentari.UseVisualStyleBackColor = true;
            this.NapraviIzvestaj.BackColor = Color.Black;
            this.NapraviIzvestaj.Cursor = Cursors.Hand;
            this.NapraviIzvestaj.Dock = DockStyle.Bottom;
            this.NapraviIzvestaj.ForeColor = Color.White;
            this.NapraviIzvestaj.Location = new Point(0, 0x2a3);
            this.NapraviIzvestaj.Name = "NapraviIzvestaj";
            this.NapraviIzvestaj.Size = new Size(350, 0x24);
            this.NapraviIzvestaj.TabIndex = 3;
            this.NapraviIzvestaj.Text = "Napravi izveštaj";
            this.NapraviIzvestaj.UseVisualStyleBackColor = false;
            this.NapraviIzvestaj.Click += new EventHandler(this.NapraviIzvestaj_Click);
            this.groupBox1.BackColor = Color.Gainsboro;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Dock = DockStyle.Top;
            this.groupBox1.ForeColor = Color.White;
            this.groupBox1.Location = new Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(350, 0x4b);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vremenski period";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(7, 0x33);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x15, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Do";
            this.dateTimePicker2.Location = new Point(0x22, 0x2d);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new Size(0xe8, 20);
            this.dateTimePicker2.TabIndex = 2;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(7, 0x19);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x15, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Od";
            this.dateTimePicker1.Location = new Point(0x22, 0x13);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new Size(0xe8, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.richTextBox1.Dock = DockStyle.Fill;
            this.richTextBox1.Location = new Point(0, 0x17);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new Size(530, 0x2b0);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.progressBar1.Dock = DockStyle.Top;
            this.progressBar1.Location = new Point(0, 0);
            this.progressBar1.Maximum = 0;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new Size(530, 0x17);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 1;
            this.timer1.Interval = 0x7d0;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.KoriscenjePorgrama.AutoSize = true;
            this.KoriscenjePorgrama.Location = new Point(6, 0x41);
            this.KoriscenjePorgrama.Name = "KoriscenjePorgrama";
            this.KoriscenjePorgrama.Size = new Size(0x7a, 0x11);
            this.KoriscenjePorgrama.TabIndex = 2;
            this.KoriscenjePorgrama.Text = "Korišćenje programa";
            this.KoriscenjePorgrama.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(0x374, 0x2c7);
            base.Controls.Add(this.splitContainer1);
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "OpstinskiIzvestaji";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Opštinski izveštaji";
            base.Shown += new EventHandler(this.OpstinskiIzvestaji_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

        private void NapraviIzvestaj_Click(object sender, EventArgs e)
        {
            Array.Clear(this.SviDatumi, 0, 500);
            Array.Clear(this.SviKorisnici, 0, 0x3e8);
            Array.Clear(this.SviKorisniciImena, 0, 0x3e8);
            Array.Clear(this.OdDoUkupnoBodova, 0, 0x3e8);
            this.progressBar1.Maximum = 0;
            this.richTextBox1.Text = "";
            this.ObjavljenKomentarDatum = "";
            this.ObjavljenKomentarKorisnik = "";
            this.BodoviObjavljenKomentarDatum = "";
            this.BodoviObjavljenKomentarKorisnik = "";
            this.KoriscenjeProgramaDatum = "";
            this.KoriscenjeProgramaKorisnik = "";
            this.KoriscenjeProgramaPocetniTekst = 0;
            if (this.dateTimePicker1.Value >= this.dateTimePicker2.Value)
            {
                MessageBox.Show("Izabrali ste veći početni datum od krajnjeg datuma.", "INFO");
            }
            else
            {
                for (int i = 0; i < 350; i++)
                {
                    if (this.dateTimePicker1.Value > this.dateTimePicker2.Value)
                    {
                        break;
                    }
                    string str = this.dateTimePicker1.Value.Day.ToString();
                    if (str.Length == 1)
                    {
                        str = "0" + str;
                    }
                    string str2 = this.dateTimePicker1.Value.Month.ToString();
                    if (str2.Length == 1)
                    {
                        str2 = "0" + str2;
                    }
                    this.SviDatumi[i] = str + "." + str2 + "." + this.dateTimePicker1.Value.Year.ToString();
                    this.dateTimePicker1.Value = this.dateTimePicker1.Value.Date.AddDays(1.0);
                    this.progressBar1.Maximum++;
                }
                int index = 0;
                foreach (string str3 in this.listBox1.SelectedItems)
                {
                    this.SviKorisniciImena[index] = str3;
                    index++;
                }
                int num3 = 0;
                foreach (string str4 in this.SviKorisniciImena)
                {
                    if (str4 == null)
                    {
                        break;
                    }
                    int num4 = 0;
                    foreach (string str5 in this.UserName)
                    {
                        if (str5 == null)
                        {
                            break;
                        }
                        if (str5 == str4)
                        {
                            this.SviKorisnici[num3] = this.UserID[num4];
                            num3++;
                            break;
                        }
                        num4++;
                    }
                }
                this.progressBar1.Maximum *= num3 + 1;
                int num5 = 0;
                if (this.ObjavljeniKomentari.Checked)
                {
                    num5++;
                }
                if (this.BodoviZaObjavljeneKomentare.Checked)
                {
                    num5++;
                }
                if (this.KoriscenjePorgrama.Checked)
                {
                    num5++;
                }
                this.progressBar1.Maximum *= num5;
                this.timer1.Enabled = true;
                this.timer1.Start();
            }
        }

        private void OpstinskiIzvestaji_Shown(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                WebClient client = new WebClient();
                JsonTextReader reader = new JsonTextReader(new StringReader(client.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/OpstinskiIzvestaji/GetRegionsForUser.php?Id=" + this.ID)));
                int num = 0;
                int index = 0;
                while (reader.Read())
                {
                    if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                    {
                        if (num == 0)
                        {
                            this.OpstineDozvoljene[index] = reader.Value.ToString();
                            index++;
                        }
                        num++;
                        if (num == 1)
                        {
                            num = 0;
                        }
                    }
                }
                foreach (string str2 in this.OpstineDozvoljene)
                {
                    if (str2 == null)
                    {
                        break;
                    }
                    WebClient client2 = new WebClient();
                    JsonTextReader reader2 = new JsonTextReader(new StringReader(client2.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/OpstinskiIzvestaji/GetUsersInfoByRegions3.php?Opstina=" + str2)));
                    int num3 = 0;
                    while (reader2.Read())
                    {
                        if ((reader2.Value != null) && (reader2.Value.ToString() != "Korisnik"))
                        {
                            switch (num3)
                            {
                                case 0:
                                    this.UserID[this.glavnibroj] = reader2.Value.ToString();
                                    break;

                                case 1:
                                    this.UserName[this.glavnibroj] = reader2.Value.ToString();
                                    this.listBox1.Items.Add(this.UserName[this.glavnibroj]);
                                    break;
                            }
                            num3++;
                            if (num3 == 2)
                            {
                                num3 = 0;
                                this.glavnibroj++;
                            }
                        }
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch
            {
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int num2;
            int num3;
            WebClient client;
            JsonTextReader reader;
            int num4;
            decimal num6;
            decimal num7;
            string str13;
            int length;
            string str14;
            int num17;
            this.timer1.Stop();
            this.timer1.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            int num = 0;
            if (this.ObjavljeniKomentari.Checked)
            {
                foreach (string str in this.SviDatumi)
                {
                    if (str == null)
                    {
                        break;
                    }
                    if (!this.ObjavljenKomentarDatum.Contains(str))
                    {
                        num = 1;
                        num2 = 0;
                        num3 = 0;
                        foreach (string str2 in this.SviKorisnici)
                        {
                            if (str2 == null)
                            {
                                break;
                            }
                            if (!this.ObjavljenKomentarKorisnik.Contains(str2))
                            {
                                num = 1;
                                num2 = 1;
                                this.ObjavljenKomentarKorisnik = this.ObjavljenKomentarKorisnik + " - " + str2;
                                client = new WebClient();
                                reader = new JsonTextReader(new StringReader(client.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/GetCommForUserFromId3.php?Id=" + str2 + "&Datum=" + str)));
                                num4 = 0;
                                this.richTextBox1.AppendText("----------------------------------------------------------------------------------------------------------------------------------------------------------\n\n");
                                string text = "Objavljeni komentari za " + str + " - " + this.SviKorisniciImena[num3];
                                int textLength = this.richTextBox1.TextLength;
                                this.richTextBox1.AppendText(text);
                                this.richTextBox1.SelectionStart = textLength;
                                this.richTextBox1.SelectionLength = text.Length;
                                this.richTextBox1.SelectionColor = Color.Red;
                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 14f);
                                this.richTextBox1.AppendText("\n\n");
                                num6 = 0M;
                                num7 = 0M;
                                while (reader.Read())
                                {
                                    if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                                    {
                                        switch (num4)
                                        {
                                            case 0:
                                            {
                                                string str5 = "[" + str + "] " + this.SviKorisniciImena[num3] + "\nVEST - NASLOV I LINK\n";
                                                int start = this.richTextBox1.Text.Length;
                                                this.richTextBox1.AppendText(str5);
                                                this.richTextBox1.Select(start, str5.Length);
                                                this.richTextBox1.SelectionColor = Color.Green;
                                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                                                string str6 = reader.Value.ToString() + "\n";
                                                int num9 = this.richTextBox1.Text.Length;
                                                this.richTextBox1.AppendText(str6);
                                                this.richTextBox1.Select(num9, str6.Length);
                                                this.richTextBox1.SelectionColor = Color.Blue;
                                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f);
                                                break;
                                            }
                                            case 1:
                                            {
                                                string str7 = reader.Value.ToString().Replace("[[]]", "&") + "\n";
                                                int num10 = this.richTextBox1.Text.Length;
                                                this.richTextBox1.AppendText(str7);
                                                this.richTextBox1.Select(num10, str7.Length);
                                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f);
                                                num6 = 0M;
                                                break;
                                            }
                                            case 2:
                                            {
                                                string str8 = "KOMENTAR\n";
                                                int num11 = this.richTextBox1.Text.Length;
                                                this.richTextBox1.AppendText(str8);
                                                this.richTextBox1.Select(num11, str8.Length);
                                                this.richTextBox1.SelectionColor = Color.Green;
                                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                                                string str9 = reader.Value.ToString() + "\n";
                                                int num12 = this.richTextBox1.Text.Length;
                                                this.richTextBox1.AppendText(str9);
                                                this.richTextBox1.Select(num12, str9.Length);
                                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f);
                                                break;
                                            }
                                            case 3:
                                                num6 = decimal.Parse(reader.Value.ToString());
                                                break;

                                            case 4:
                                                num6 += decimal.Parse(reader.Value.ToString());
                                                break;

                                            case 5:
                                                num6 += decimal.Parse(reader.Value.ToString());
                                                break;

                                            case 6:
                                            {
                                                string str10 = "BODOVANJE\n";
                                                int num13 = this.richTextBox1.Text.Length;
                                                this.richTextBox1.AppendText(str10);
                                                this.richTextBox1.Select(num13, str10.Length);
                                                this.richTextBox1.SelectionColor = Color.Green;
                                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                                                num6 += decimal.Parse(reader.Value.ToString());
                                                if (num6.ToString().Contains(",") || (num6 > 5M))
                                                {
                                                    num6 /= 100M;
                                                }
                                                num7 += num6;
                                                this.richTextBox1.AppendText("Komentar vredi ");
                                                string str11 = num6.ToString() + " ";
                                                int num14 = this.richTextBox1.Text.Length;
                                                this.richTextBox1.AppendText(str11);
                                                this.richTextBox1.Select(num14, str11.Length);
                                                this.richTextBox1.SelectionColor = Color.Red;
                                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                                                string str12 = "bodova\n\n\n\n\n";
                                                int num15 = this.richTextBox1.Text.Length;
                                                this.richTextBox1.AppendText(str12);
                                                this.richTextBox1.Select(num15, str12.Length);
                                                this.richTextBox1.SelectionColor = Color.Black;
                                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f);
                                                break;
                                            }
                                        }
                                        num4++;
                                        if (num4 == 7)
                                        {
                                            num4 = 0;
                                        }
                                    }
                                }
                                str13 = "[" + this.SviKorisniciImena[num3] + "] Za " + str + " ukupno bodova ";
                                length = this.richTextBox1.Text.Length;
                                this.richTextBox1.AppendText(str13);
                                this.richTextBox1.Select(length, str13.Length);
                                this.richTextBox1.SelectionColor = Color.Green;
                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                                str14 = num7.ToString() + "\n";
                                num17 = this.richTextBox1.Text.Length;
                                this.richTextBox1.AppendText(str14);
                                this.richTextBox1.Select(num17, str14.Length);
                                this.richTextBox1.SelectionColor = Color.Red;
                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                                break;
                            }
                            num3++;
                        }
                        if (num2 == 0)
                        {
                            this.ObjavljenKomentarDatum = this.ObjavljenKomentarDatum + " - " + str;
                            this.ObjavljenKomentarKorisnik = "";
                        }
                        break;
                    }
                }
                this.timer1.Interval = 0xdac;
            }
            if (this.BodoviZaObjavljeneKomentare.Checked && (num == 0))
            {
                foreach (string str in this.SviDatumi)
                {
                    if (str == null)
                    {
                        break;
                    }
                    if (!this.BodoviObjavljenKomentarDatum.Contains(str))
                    {
                        num = 1;
                        num2 = 0;
                        num3 = 0;
                        foreach (string str2 in this.SviKorisnici)
                        {
                            if (str2 == null)
                            {
                                break;
                            }
                            if (!this.BodoviObjavljenKomentarKorisnik.Contains(str2))
                            {
                                num = 1;
                                num2 = 1;
                                this.BodoviObjavljenKomentarKorisnik = this.BodoviObjavljenKomentarKorisnik + " - " + str2;
                                client = new WebClient();
                                reader = new JsonTextReader(new StringReader(client.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/OpstinskiIzvestaji/GetCommForUserFromId3.php?Id=" + str2 + "&Datum=" + str)));
                                num4 = 0;
                                num6 = 0M;
                                num7 = 0M;
                                while (reader.Read())
                                {
                                    if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                                    {
                                        switch (num4)
                                        {
                                            case 0:
                                                num6 = decimal.Parse(reader.Value.ToString());
                                                break;

                                            case 1:
                                                num6 += decimal.Parse(reader.Value.ToString());
                                                break;

                                            case 2:
                                                num6 += decimal.Parse(reader.Value.ToString());
                                                break;

                                            case 3:
                                                num6 += decimal.Parse(reader.Value.ToString());
                                                if (num6.ToString().Contains(",") || (num6 > 5M))
                                                {
                                                    num6 /= 100M;
                                                }
                                                num7 += num6;
                                                break;
                                        }
                                        num4++;
                                        if (num4 == 4)
                                        {
                                            num4 = 0;
                                        }
                                    }
                                }
                                str13 = "[" + this.SviKorisniciImena[num3] + "] Za objavljene komentare dana " + str + " ukupno bodova ";
                                length = this.richTextBox1.Text.Length;
                                this.richTextBox1.AppendText(str13);
                                this.richTextBox1.Select(length, str13.Length);
                                this.richTextBox1.SelectionColor = Color.Black;
                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f);
                                this.OdDoUkupnoBodova[num3] += num7;
                                str14 = num7.ToString() + "\n";
                                num17 = this.richTextBox1.Text.Length;
                                this.richTextBox1.AppendText(str14);
                                this.richTextBox1.Select(num17, str14.Length);
                                this.richTextBox1.SelectionColor = Color.Red;
                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                                break;
                            }
                            num3++;
                        }
                        if (num2 == 0)
                        {
                            this.BodoviObjavljenKomentarDatum = this.BodoviObjavljenKomentarDatum + " - " + str;
                            this.BodoviObjavljenKomentarKorisnik = "";
                            this.richTextBox1.AppendText("\n");
                        }
                        break;
                    }
                }
                if (num == 0)
                {
                    int index = -1;
                    foreach (string str15 in this.SviDatumi)
                    {
                        if (str15 == null)
                        {
                            break;
                        }
                        index++;
                    }
                    int num19 = 0;
                    foreach (string str2 in this.SviKorisnici)
                    {
                        if (str2 == null)
                        {
                            break;
                        }
                        str13 = "[" + this.SviKorisniciImena[num19] + "] Za objavljene komentare od " + this.SviDatumi[0] + " do " + this.SviDatumi[index] + " ukupno bodova ";
                        length = this.richTextBox1.Text.Length;
                        this.richTextBox1.AppendText(str13);
                        this.richTextBox1.Select(length, str13.Length);
                        this.richTextBox1.SelectionColor = Color.Green;
                        this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 12f);
                        str14 = this.OdDoUkupnoBodova[num19].ToString() + "\n";
                        num17 = this.richTextBox1.Text.Length;
                        this.richTextBox1.AppendText(str14);
                        this.richTextBox1.Select(num17, str14.Length);
                        this.richTextBox1.SelectionColor = Color.Blue;
                        this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
                        num19++;
                    }
                }
            }
            if (this.KoriscenjePorgrama.Checked && (num == 0))
            {
                if (this.KoriscenjeProgramaPocetniTekst == 0)
                {
                    this.KoriscenjeProgramaPocetniTekst = 1;
                    str14 = "\n\nKorišćenje programa - ukupno sati rada programa na korisnikovom računaru.Postoji mogućnost da za jedan dan korisnik ima više od 24h upotrebe, a to je zato što korsnici koriste više računara koji su prijavljeni na jedno ime.\n\n";
                    num17 = this.richTextBox1.Text.Length;
                    this.richTextBox1.AppendText(str14);
                    this.richTextBox1.Select(num17, str14.Length);
                    this.richTextBox1.SelectionColor = Color.Red;
                    this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                }
                foreach (string str in this.SviDatumi)
                {
                    if (str == null)
                    {
                        break;
                    }
                    if (!this.KoriscenjeProgramaDatum.Contains(str))
                    {
                        num = 1;
                        num2 = 0;
                        num3 = 0;
                        foreach (string str2 in this.SviKorisnici)
                        {
                            if (str2 == null)
                            {
                                break;
                            }
                            if (!this.KoriscenjeProgramaKorisnik.Contains(str2))
                            {
                                num = 1;
                                num2 = 1;
                                this.KoriscenjeProgramaKorisnik = this.KoriscenjeProgramaKorisnik + " - " + str2;
                                client = new WebClient();
                                reader = new JsonTextReader(new StringReader(client.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/OpstinskiIzvestaji/GetUsageFromId.php?Id=" + str2 + "&Datum=" + str)));
                                num4 = 0;
                                string str16 = "0";
                                while (reader.Read())
                                {
                                    if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                                    {
                                        if (num4 == 0)
                                        {
                                            str16 = reader.Value.ToString();
                                        }
                                        num4++;
                                        if (num4 == 1)
                                        {
                                            num4 = 0;
                                        }
                                    }
                                }
                                str13 = "[" + this.SviKorisniciImena[num3] + "] Ukupno korišćenje programa dana " + str + " je ";
                                length = this.richTextBox1.Text.Length;
                                this.richTextBox1.AppendText(str13);
                                this.richTextBox1.Select(length, str13.Length);
                                this.richTextBox1.SelectionColor = Color.Black;
                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f);
                                str14 = str16 + "h\n";
                                num17 = this.richTextBox1.Text.Length;
                                this.richTextBox1.AppendText(str14);
                                this.richTextBox1.Select(num17, str14.Length);
                                this.richTextBox1.SelectionColor = Color.Red;
                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                                break;
                            }
                            num3++;
                        }
                        if (num2 == 0)
                        {
                            this.KoriscenjeProgramaDatum = this.KoriscenjeProgramaDatum + " - " + str;
                            this.KoriscenjeProgramaKorisnik = "";
                            this.richTextBox1.AppendText("\n");
                        }
                        break;
                    }
                }
                this.timer1.Interval = 0x7d0;
            }
            if (num == 1)
            {
                this.progressBar1.PerformStep();
                this.timer1.Enabled = true;
                this.timer1.Start();
            }
            else
            {
                MessageBox.Show("Izveštaj je gotov", "INFO");
            }
            Cursor.Current = Cursors.Default;
        }
    }
}

