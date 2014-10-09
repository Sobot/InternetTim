namespace InternetTim.Komentari
{
    using GemBox.Spreadsheet;
    using HtmlAgilityPack;
    using InternetTim.Properties;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Media;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using System.Threading;
    using System.Web;
    using System.Windows.Forms;

    public class AktuelniZadaci : Form
    {
        private int AdminListe = 0;
        private int AktivacijaFokusFlow = 0;
        private int AktivacijaFokusFlow2 = 0;
        private Button AzurirajPromeniNaslov;
        private BackgroundWorker AzuriranjeBrojaKorisnika;
        private BackgroundWorker backgroundWorkerProveraKomentara;
        private string[] Bodovi = new string[500];
        private Button button1;
        private Button button3;
        private ComboBox comboBox1;
        private IContainer components = null;
        private Button DodajKomentar;
        private GroupBox FilterZaPretragu;
        private int Flow1stanje = -1;
        private int Flow2stanje = -1;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private string[] GGIspravka = new string[0x1388];
        private string[] GGReci = new string[0x1388];
        private Button KomentarisaloKorisnika1;
        private Button KomentarisaloKorisnika2;
        private Button MiniVerzijaProzora;
        private int MKbroj = 0;
        private string[] MKDatumUnosaKomentara = new string[0x1f40];
        private int[] MKExcelRowNumber = new int[0x1f40];
        private string[] MKIdKomentara = new string[0x1f40];
        private string[] MKNapomenaKomentara = new string[0x1f40];
        private string[] MKObjavljeni = new string[0x1f40];
        private string[] MKUrlVesti = new string[0x1f40];
        private string[] MKVestiID = new string[0x1f40];
        private string[] MojiKomentari = new string[0x1f40];
        public string NivoKorisnika = "";
        private Button NovaVest;
        private Button ObjavljenoKomentara1;
        private Button ObjavljenoKomentara2;
        private Button ObrisiVest;
        private Panel panel1;
        private Panel panelGornjiMeni;
        private Panel panelMiniVesti;
        public string PersonalID = "";
        private int PKrun = 120;
        private System.Windows.Forms.Timer PocetniTimer;
        private int PocetnoUcitavanje = 0;
        private Button PokazivacVremenaProvera;
        private int PokrenutaProveraKomentara = 0;
        private Button Poruke;
        private Button PoslatoKomentara1;
        private Button PoslatoKomentara2;
        private Button PostaviNaVrh;
        private Button PostaviPrioritet;
        private Button PrijaviPoslatKomentar;
        private System.Windows.Forms.Timer PrikazivanjeObjavljenihKomentara;
        private string[] PriKomeTimer = new string[0x1f40];
        private MiniVest Privremena = new MiniVest();
        private ProgressBar progressBar1;
        private int PrvaUcitavanja = 0;
        private string putanjaFolder = "";
        private int RedovanKrug = 0;
        private System.Windows.Forms.Timer RedovnoAzuriranje;
        private RichTextBox richTextBox1;
        private Button SelektovanBrojKomentara;
        private Button SelektovanNaslov;
        private int SkidanjeKorisnika = 0;
        private BackgroundWorker SkidanjePodatakaVesti;
        private int SkidanjeVesti = 0;
        private DateTime Skraj = new DateTime();
        private Button SnimljeneAdminPromene;
        private DateTime Spocetak = new DateTime();
        private Button StanjeKomentara;
        private int StanjeVesti = 12;
        private TabControl tabControl1;
        private TableLayoutPanel tableLayoutPanel1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ToolTip toolTip1;
        private Button TrenutnoKorisnika;
        private string[] VestiId = new string[300];
        private string[] VestiNaslov = new string[300];
        private string[] VestiPrioritet = new string[300];
        private string[] VestiSlika = new string[300];
        private string[] VestiUrl = new string[300];
        private Button VratiIzaProzor;
        private Button VratiMiniPrikaz;
        private Button VratiPrioritet;
        private System.Windows.Forms.Timer VratiZabranu;
        private int ZabraniUbacivanjeVesti = 0;
        private System.Windows.Forms.Timer ZakasneloAzuriranjeTeksta;
        private int ZAT = 0;

        public AktuelniZadaci()
        {
            this.InitializeComponent();
            SpreadsheetInfo.SetLicense("EQU1-4YRI-KEYA-HERE");
        }

        private void AktuelniZadaci_Load(object sender, EventArgs e)
        {
            base.Size = new Size(base.Width, 80);
            base.Location = new Point(base.Location.X, Screen.PrimaryScreen.WorkingArea.Height - 80);
        }

        private void AktuelniZadaci_Shown(object sender, EventArgs e)
        {
            this.Spocetak = DateTime.Now;
            try
            {
                string str2;
                Cursor.Current = Cursors.WaitCursor;
                string pathRoot = Path.GetPathRoot(Environment.SystemDirectory);
                this.putanjaFolder = pathRoot + "InternetTim";
                try
                {
                    str2 = this.putanjaFolder + @"\Vpic\MKB";
                    if (!Directory.Exists(str2))
                    {
                        Directory.CreateDirectory(str2).Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                        ExcelFile file = new ExcelFile();
                        file.Worksheets.Add("Data");
                        file.SaveXls(str2 + @"\pos.jpg");
                        ExcelFile file2 = new ExcelFile();
                        file2.Worksheets.Add("Data");
                        file2.SaveXls(str2 + @"\obj.jpg");
                    }
                }
                catch
                {
                }
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
                try
                {
                    str2 = this.putanjaFolder + @"\Vpic\MKB";
                    ExcelFile file3 = new ExcelFile();
                    file3.LoadXls(str2 + @"\pos.jpg");
                    int count = file3.Worksheets[0].Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        try
                        {
                            foreach (string str4 in this.VestiId)
                            {
                                if (str4 == null)
                                {
                                    continue;
                                }
                                if (file3.Worksheets[0].Rows[i].Cells[2].Value.ToString() == str4)
                                {
                                    this.MojiKomentari[this.MKbroj] = file3.Worksheets[0].Rows[i].Cells[0].Value.ToString();
                                    this.MKUrlVesti[this.MKbroj] = file3.Worksheets[0].Rows[i].Cells[1].Value.ToString();
                                    this.MKObjavljeni[this.MKbroj] = file3.Worksheets[0].Rows[i].Cells[3].Value.ToString();
                                    this.MKVestiID[this.MKbroj] = str4;
                                    try
                                    {
                                        this.MKNapomenaKomentara[this.MKbroj] = file3.Worksheets[0].Rows[i].Cells[4].Value.ToString();
                                    }
                                    catch
                                    {
                                        this.MKNapomenaKomentara[this.MKbroj] = " ";
                                    }
                                    try
                                    {
                                        this.MKDatumUnosaKomentara[this.MKbroj] = file3.Worksheets[0].Rows[i].Cells[5].Value.ToString();
                                    }
                                    catch
                                    {
                                        this.MKDatumUnosaKomentara[this.MKbroj] = "??.??.???? - ??:??h";
                                    }
                                    try
                                    {
                                        this.MKIdKomentara[this.MKbroj] = file3.Worksheets[0].Rows[i].Cells[6].Value.ToString();
                                    }
                                    catch
                                    {
                                        this.MKIdKomentara[this.MKbroj] = "0";
                                    }
                                    this.MKExcelRowNumber[this.MKbroj] = i;
                                    this.MKbroj++;
                                    continue;
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    WebClient client2 = new WebClient();
                    JsonTextReader reader2 = new JsonTextReader(new StringReader(client2.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Bodovanje/GetAllPoints.php")));
                    int num4 = 0;
                    int index = 0;
                    while (reader2.Read())
                    {
                        if ((reader2.Value != null) && (reader2.Value.ToString() != "Korisnik"))
                        {
                            if (num4 == 1)
                            {
                                this.Bodovi[index] = reader2.Value.ToString();
                            }
                            num4++;
                            if (num4 == 2)
                            {
                                num4 = 0;
                                index++;
                            }
                        }
                    }
                }
                catch
                {
                }
            }
            catch
            {
            }
            try
            {
                new SoundPlayer(Resources.UcitavanjeVestiZvuk).Play();
            }
            catch (Exception exception)
            {
                this.PosaljiMail("CODE: AktuelniZadaci_Shown - SoundPlayer simpleSound\n\n" + exception.ToString());
            }
            this.progressBar1.Maximum = this.PocetnoUcitavanje;
            this.PocetniTimer.Enabled = true;
            this.PocetniTimer.Start();
            Cursor.Current = Cursors.Default;
        }

        private void AzurirajPromeniNaslov_Click(object sender, EventArgs e)
        {
            try
            {
                this.Privremena.OsveziNaslovVesti(this.PersonalID);
            }
            catch
            {
            }
        }

        private void AzuriranjeBrojaKorisnika_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                string str = client.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/InsertUserOnlineStatus.php?Id=" + e.Argument.ToString()).Replace("\r\n", "");
                e.Result = str;
            }
            catch
            {
            }
        }

        private void AzuriranjeBrojaKorisnika_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.TrenutnoKorisnika.Text = "Korisnika: " + e.Result.ToString();
            }
            catch
            {
                this.TrenutnoKorisnika.Text = "Korisnika: ??";
            }
            this.TrenutnoKorisnika.BackColor = Color.White;
            this.SkidanjeKorisnika = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.comboBox1.Visible = false;
            if (this.tabControl1.SelectedIndex == 0)
            {
                this.flowLayoutPanel1.Focus();
            }
            else
            {
                this.flowLayoutPanel2.Focus();
            }
            try
            {
                MiniVest vest;
                string str = this.comboBox1.SelectedItem.ToString();
                string uslov = "";
                switch (str)
                {
                    case "BLIC":
                        uslov = "blic.rs";
                        break;

                    case "B92":
                        uslov = "b92.net";
                        break;

                    case "KURIR":
                        uslov = "kurir-info.rs";
                        break;

                    case "NOVOSTI":
                        uslov = "novosti.rs";
                        break;

                    case "RTS":
                        uslov = "rts.rs";
                        break;

                    case "TELEGRAF":
                        uslov = "telegraf.rs";
                        break;

                    case "DANAS":
                        uslov = "danas.rs";
                        break;

                    case "POLITIKA":
                        uslov = "politika.rs";
                        break;

                    case "ALO":
                        uslov = "alo.rs";
                        break;
                }
                foreach (Control control in this.flowLayoutPanel1.Controls)
                {
                    vest = new MiniVest();
                    vest = (MiniVest) control;
                    vest.Saktivanje(uslov);
                }
                foreach (Control control in this.flowLayoutPanel2.Controls)
                {
                    vest = new MiniVest();
                    ((MiniVest) control).Saktivanje(uslov);
                }
            }
            catch
            {
            }
            Cursor.Current = Cursors.Default;
            this.comboBox1.Visible = true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DodajKomentar_Click(object sender, EventArgs e)
        {
            if (this.Privremena.UzmiOriginalID() != "99999")
            {
                MojaSugestija sugestija = new MojaSugestija();
                sugestija.FormClosed += new FormClosedEventHandler(this.sug_FormClosed);
                sugestija.PersonalIDS = this.PersonalID;
                sugestija.IdVesti = this.Privremena.UzmiOriginalID();
                sugestija.Show();
            }
            else
            {
                MessageBox.Show("Pokušajte malo kasnije da pošaljete komentar, trenutno se vrši ažuriranje vesti", "INFO");
            }
        }

        private void flowLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            this.flowLayoutPanel1.Focus();
        }

        private void flowLayoutPanel1_MouseEnter(object sender, EventArgs e)
        {
            if (this.AktivacijaFokusFlow == 0)
            {
                this.flowLayoutPanel1.Focus();
            }
        }

        private void flowLayoutPanel2_MouseClick(object sender, MouseEventArgs e)
        {
            this.flowLayoutPanel2.Focus();
        }

        private void flowLayoutPanel2_MouseEnter(object sender, EventArgs e)
        {
            if (this.AktivacijaFokusFlow2 == 0)
            {
                this.flowLayoutPanel2.Focus();
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(AktuelniZadaci));
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.panelMiniVesti = new Panel();
            this.tabControl1 = new TabControl();
            this.tabPage1 = new TabPage();
            this.flowLayoutPanel1 = new FlowLayoutPanel();
            this.tabPage2 = new TabPage();
            this.flowLayoutPanel2 = new FlowLayoutPanel();
            this.panelGornjiMeni = new Panel();
            this.SnimljeneAdminPromene = new Button();
            this.AzurirajPromeniNaslov = new Button();
            this.PokazivacVremenaProvera = new Button();
            this.TrenutnoKorisnika = new Button();
            this.FilterZaPretragu = new GroupBox();
            this.comboBox1 = new ComboBox();
            this.PostaviNaVrh = new Button();
            this.MiniVerzijaProzora = new Button();
            this.Poruke = new Button();
            this.VratiPrioritet = new Button();
            this.PostaviPrioritet = new Button();
            this.ObrisiVest = new Button();
            this.NovaVest = new Button();
            this.VratiMiniPrikaz = new Button();
            this.VratiIzaProzor = new Button();
            this.progressBar1 = new ProgressBar();
            this.panel1 = new Panel();
            this.DodajKomentar = new Button();
            this.button1 = new Button();
            this.StanjeKomentara = new Button();
            this.PrijaviPoslatKomentar = new Button();
            this.KomentarisaloKorisnika1 = new Button();
            this.KomentarisaloKorisnika2 = new Button();
            this.PoslatoKomentara1 = new Button();
            this.PoslatoKomentara2 = new Button();
            this.ObjavljenoKomentara1 = new Button();
            this.ObjavljenoKomentara2 = new Button();
            this.button3 = new Button();
            this.SelektovanBrojKomentara = new Button();
            this.SelektovanNaslov = new Button();
            this.richTextBox1 = new RichTextBox();
            this.toolTip1 = new ToolTip(this.components);
            this.PocetniTimer = new System.Windows.Forms.Timer(this.components);
            this.RedovnoAzuriranje = new System.Windows.Forms.Timer(this.components);
            this.VratiZabranu = new System.Windows.Forms.Timer(this.components);
            this.ZakasneloAzuriranjeTeksta = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorkerProveraKomentara = new BackgroundWorker();
            this.PrikazivanjeObjavljenihKomentara = new System.Windows.Forms.Timer(this.components);
            this.AzuriranjeBrojaKorisnika = new BackgroundWorker();
            this.SkidanjePodatakaVesti = new BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelMiniVesti.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panelGornjiMeni.SuspendLayout();
            this.FilterZaPretragu.SuspendLayout();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.tableLayoutPanel1.BackColor = Color.White;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 230f));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            this.tableLayoutPanel1.Controls.Add(this.panelMiniVesti, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelGornjiMeni, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 1, 2);
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Location = new Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 172f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            this.tableLayoutPanel1.Size = new Size(0x310, 0x2f9);
            this.tableLayoutPanel1.TabIndex = 0;
            this.panelMiniVesti.Controls.Add(this.tabControl1);
            this.panelMiniVesti.Dock = DockStyle.Fill;
            this.panelMiniVesti.Location = new Point(0, 60);
            this.panelMiniVesti.Margin = new Padding(0);
            this.panelMiniVesti.Name = "panelMiniVesti";
            this.tableLayoutPanel1.SetRowSpan(this.panelMiniVesti, 2);
            this.panelMiniVesti.Size = new Size(230, 0x2bd);
            this.panelMiniVesti.TabIndex = 0;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Cursor = Cursors.Hand;
            this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.ItemSize = new Size(0x70, 20);
            this.tabControl1.Location = new Point(0, 0);
            this.tabControl1.Margin = new Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size(230, 0x2bd);
            this.tabControl1.SizeMode = TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabPage1.BackColor = Color.White;
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.ForeColor = Color.Black;
            this.tabPage1.Location = new Point(4, 0x18);
            this.tabPage1.Margin = new Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new Size(0xde, 0x2a1);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "  PRIORITETI  ";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Cursor = Cursors.Default;
            this.flowLayoutPanel1.Dock = DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = FlowDirection.BottomUp;
            this.flowLayoutPanel1.Location = new Point(0, 0);
            this.flowLayoutPanel1.Margin = new Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new Size(0xde, 0x2a1);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            this.flowLayoutPanel1.MouseClick += new MouseEventHandler(this.flowLayoutPanel1_MouseClick);
            this.flowLayoutPanel1.MouseEnter += new EventHandler(this.flowLayoutPanel1_MouseEnter);
            this.tabPage2.BackColor = Color.White;
            this.tabPage2.Controls.Add(this.flowLayoutPanel2);
            this.tabPage2.Location = new Point(4, 0x18);
            this.tabPage2.Margin = new Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new Size(0xde, 0x2a1);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "  AKTUELNO  ";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BackColor = Color.White;
            this.flowLayoutPanel2.Cursor = Cursors.Arrow;
            this.flowLayoutPanel2.Dock = DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = FlowDirection.BottomUp;
            this.flowLayoutPanel2.Location = new Point(0, 0);
            this.flowLayoutPanel2.Margin = new Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new Size(0xde, 0x2a1);
            this.flowLayoutPanel2.TabIndex = 1;
            this.flowLayoutPanel2.WrapContents = false;
            this.flowLayoutPanel2.MouseClick += new MouseEventHandler(this.flowLayoutPanel2_MouseClick);
            this.flowLayoutPanel2.MouseEnter += new EventHandler(this.flowLayoutPanel2_MouseEnter);
            this.panelGornjiMeni.BackColor = Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.panelGornjiMeni, 2);
            this.panelGornjiMeni.Controls.Add(this.SnimljeneAdminPromene);
            this.panelGornjiMeni.Controls.Add(this.AzurirajPromeniNaslov);
            this.panelGornjiMeni.Controls.Add(this.PokazivacVremenaProvera);
            this.panelGornjiMeni.Controls.Add(this.TrenutnoKorisnika);
            this.panelGornjiMeni.Controls.Add(this.FilterZaPretragu);
            this.panelGornjiMeni.Controls.Add(this.PostaviNaVrh);
            this.panelGornjiMeni.Controls.Add(this.MiniVerzijaProzora);
            this.panelGornjiMeni.Controls.Add(this.Poruke);
            this.panelGornjiMeni.Controls.Add(this.VratiPrioritet);
            this.panelGornjiMeni.Controls.Add(this.PostaviPrioritet);
            this.panelGornjiMeni.Controls.Add(this.ObrisiVest);
            this.panelGornjiMeni.Controls.Add(this.NovaVest);
            this.panelGornjiMeni.Controls.Add(this.VratiMiniPrikaz);
            this.panelGornjiMeni.Controls.Add(this.VratiIzaProzor);
            this.panelGornjiMeni.Controls.Add(this.progressBar1);
            this.panelGornjiMeni.Dock = DockStyle.Fill;
            this.panelGornjiMeni.Location = new Point(0, 0);
            this.panelGornjiMeni.Margin = new Padding(0);
            this.panelGornjiMeni.Name = "panelGornjiMeni";
            this.panelGornjiMeni.Size = new Size(0x310, 60);
            this.panelGornjiMeni.TabIndex = 1;
            this.SnimljeneAdminPromene.BackColor = Color.White;
            this.SnimljeneAdminPromene.BackgroundImage = Resources.camera;
            this.SnimljeneAdminPromene.BackgroundImageLayout = ImageLayout.Stretch;
            this.SnimljeneAdminPromene.Cursor = Cursors.Hand;
            this.SnimljeneAdminPromene.FlatAppearance.BorderColor = Color.White;
            this.SnimljeneAdminPromene.FlatStyle = FlatStyle.Flat;
            this.SnimljeneAdminPromene.Location = new Point(0x121, 0x1d);
            this.SnimljeneAdminPromene.Margin = new Padding(0);
            this.SnimljeneAdminPromene.Name = "SnimljeneAdminPromene";
            this.SnimljeneAdminPromene.Size = new Size(0x1c, 0x1c);
            this.SnimljeneAdminPromene.TabIndex = 15;
            this.SnimljeneAdminPromene.TextAlign = ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.SnimljeneAdminPromene, "Administratorske promene na vestima");
            this.SnimljeneAdminPromene.UseVisualStyleBackColor = false;
            this.SnimljeneAdminPromene.Visible = false;
            this.SnimljeneAdminPromene.Click += new EventHandler(this.SnimljeneAdminPromene_Click);
            this.AzurirajPromeniNaslov.BackColor = Color.White;
            this.AzurirajPromeniNaslov.BackgroundImage = Resources.edit;
            this.AzurirajPromeniNaslov.BackgroundImageLayout = ImageLayout.Stretch;
            this.AzurirajPromeniNaslov.Cursor = Cursors.Hand;
            this.AzurirajPromeniNaslov.FlatAppearance.BorderColor = Color.White;
            this.AzurirajPromeniNaslov.FlatStyle = FlatStyle.Flat;
            this.AzurirajPromeniNaslov.Location = new Point(0x121, 2);
            this.AzurirajPromeniNaslov.Margin = new Padding(0);
            this.AzurirajPromeniNaslov.Name = "AzurirajPromeniNaslov";
            this.AzurirajPromeniNaslov.Size = new Size(0x1c, 0x1c);
            this.AzurirajPromeniNaslov.TabIndex = 14;
            this.AzurirajPromeniNaslov.TextAlign = ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.AzurirajPromeniNaslov, "Ažuriraj naslov vesti");
            this.AzurirajPromeniNaslov.UseVisualStyleBackColor = false;
            this.AzurirajPromeniNaslov.Visible = false;
            this.AzurirajPromeniNaslov.Click += new EventHandler(this.AzurirajPromeniNaslov_Click);
            this.PokazivacVremenaProvera.BackColor = Color.White;
            this.PokazivacVremenaProvera.BackgroundImage = Resources.timepic3;
            this.PokazivacVremenaProvera.BackgroundImageLayout = ImageLayout.Stretch;
            this.PokazivacVremenaProvera.Cursor = Cursors.Hand;
            this.PokazivacVremenaProvera.FlatAppearance.BorderColor = Color.SteelBlue;
            this.PokazivacVremenaProvera.FlatAppearance.BorderSize = 2;
            this.PokazivacVremenaProvera.FlatAppearance.MouseOverBackColor = Color.FromArgb(0xff, 0xe0, 0xc0);
            this.PokazivacVremenaProvera.FlatStyle = FlatStyle.Flat;
            this.PokazivacVremenaProvera.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.PokazivacVremenaProvera.Location = new Point(0x24a, 2);
            this.PokazivacVremenaProvera.Name = "PokazivacVremenaProvera";
            this.PokazivacVremenaProvera.Padding = new Padding(2, 5, 0, 0);
            this.PokazivacVremenaProvera.Size = new Size(0x38, 0x38);
            this.PokazivacVremenaProvera.TabIndex = 13;
            this.PokazivacVremenaProvera.Text = "60";
            this.toolTip1.SetToolTip(this.PokazivacVremenaProvera, "Odbrojavanje do provere komentara.\r\nKlikom miša aktivirate proveru odmah.");
            this.PokazivacVremenaProvera.UseVisualStyleBackColor = false;
            this.PokazivacVremenaProvera.Visible = false;
            this.PokazivacVremenaProvera.Click += new EventHandler(this.PokazivacVremenaProvera_Click);
            this.TrenutnoKorisnika.FlatAppearance.BorderColor = Color.SteelBlue;
            this.TrenutnoKorisnika.FlatAppearance.BorderSize = 2;
            this.TrenutnoKorisnika.FlatStyle = FlatStyle.Flat;
            this.TrenutnoKorisnika.Location = new Point(0x288, 30);
            this.TrenutnoKorisnika.Name = "TrenutnoKorisnika";
            this.TrenutnoKorisnika.Size = new Size(0x85, 0x19);
            this.TrenutnoKorisnika.TabIndex = 12;
            this.TrenutnoKorisnika.Text = "Korisnika: 0";
            this.toolTip1.SetToolTip(this.TrenutnoKorisnika, "U zadnjih 10 minuta korisnika prisutno.");
            this.TrenutnoKorisnika.UseVisualStyleBackColor = true;
            this.TrenutnoKorisnika.Visible = false;
            this.TrenutnoKorisnika.Click += new EventHandler(this.TrenutnoKorisnika_Click);
            this.FilterZaPretragu.Controls.Add(this.comboBox1);
            this.FilterZaPretragu.Location = new Point(0x80, 3);
            this.FilterZaPretragu.Name = "FilterZaPretragu";
            this.FilterZaPretragu.Size = new Size(0x66, 0x36);
            this.FilterZaPretragu.TabIndex = 11;
            this.FilterZaPretragu.TabStop = false;
            this.FilterZaPretragu.Text = "FILTER";
            this.FilterZaPretragu.Visible = false;
            this.comboBox1.Cursor = Cursors.Hand;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] { "SVE", "BLIC", "B92", "KURIR", "NOVOSTI", "RTS", "DANAS", "TELEGRAF", "POLITIKA", "ALO" });
            this.comboBox1.Location = new Point(5, 0x1b);
            this.comboBox1.Margin = new Padding(0);
            this.comboBox1.MaxDropDownItems = 11;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(0x5b, 0x15);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
            this.PostaviNaVrh.BackColor = Color.White;
            this.PostaviNaVrh.BackgroundImage = Resources.up;
            this.PostaviNaVrh.BackgroundImageLayout = ImageLayout.Stretch;
            this.PostaviNaVrh.Cursor = Cursors.Hand;
            this.PostaviNaVrh.FlatAppearance.BorderColor = Color.White;
            this.PostaviNaVrh.FlatStyle = FlatStyle.Flat;
            this.PostaviNaVrh.Location = new Point(0x42, 3);
            this.PostaviNaVrh.Name = "PostaviNaVrh";
            this.PostaviNaVrh.Size = new Size(0x38, 0x38);
            this.PostaviNaVrh.TabIndex = 8;
            this.PostaviNaVrh.TextAlign = ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.PostaviNaVrh, "Postavi prozor da bude ispred svih drugih programa");
            this.PostaviNaVrh.UseVisualStyleBackColor = false;
            this.PostaviNaVrh.Visible = false;
            this.PostaviNaVrh.Click += new EventHandler(this.PostaviNaVrh_Click);
            this.MiniVerzijaProzora.BackColor = Color.White;
            this.MiniVerzijaProzora.BackgroundImage = Resources.forward;
            this.MiniVerzijaProzora.BackgroundImageLayout = ImageLayout.Stretch;
            this.MiniVerzijaProzora.Cursor = Cursors.Hand;
            this.MiniVerzijaProzora.FlatAppearance.BorderColor = Color.White;
            this.MiniVerzijaProzora.FlatStyle = FlatStyle.Flat;
            this.MiniVerzijaProzora.Location = new Point(3, 3);
            this.MiniVerzijaProzora.Name = "MiniVerzijaProzora";
            this.MiniVerzijaProzora.Size = new Size(0x38, 0x38);
            this.MiniVerzijaProzora.TabIndex = 6;
            this.MiniVerzijaProzora.TextAlign = ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.MiniVerzijaProzora, "Mini prikaz vesti");
            this.MiniVerzijaProzora.UseVisualStyleBackColor = false;
            this.MiniVerzijaProzora.Visible = false;
            this.MiniVerzijaProzora.Click += new EventHandler(this.MiniVerzijaProzora_Click);
            this.Poruke.BackColor = Color.White;
            this.Poruke.Cursor = Cursors.Hand;
            this.Poruke.FlatAppearance.BorderColor = Color.SteelBlue;
            this.Poruke.FlatAppearance.BorderSize = 2;
            this.Poruke.FlatStyle = FlatStyle.Flat;
            this.Poruke.Location = new Point(0x288, 3);
            this.Poruke.Name = "Poruke";
            this.Poruke.Size = new Size(0x85, 0x19);
            this.Poruke.TabIndex = 4;
            this.toolTip1.SetToolTip(this.Poruke, "Zadnje ažuriranje vesti");
            this.Poruke.UseVisualStyleBackColor = false;
            this.Poruke.Visible = false;
            this.Poruke.Click += new EventHandler(this.Poruke_Click);
            this.VratiPrioritet.BackColor = Color.White;
            this.VratiPrioritet.BackgroundImage = Resources.image;
            this.VratiPrioritet.BackgroundImageLayout = ImageLayout.Stretch;
            this.VratiPrioritet.Cursor = Cursors.Hand;
            this.VratiPrioritet.FlatAppearance.BorderColor = Color.White;
            this.VratiPrioritet.FlatStyle = FlatStyle.Flat;
            this.VratiPrioritet.Location = new Point(0x105, 0x1d);
            this.VratiPrioritet.Margin = new Padding(0);
            this.VratiPrioritet.Name = "VratiPrioritet";
            this.VratiPrioritet.Size = new Size(0x1c, 0x1c);
            this.VratiPrioritet.TabIndex = 2;
            this.VratiPrioritet.TextAlign = ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.VratiPrioritet, "Postavi odabranu vest za AKTUELNU");
            this.VratiPrioritet.UseVisualStyleBackColor = false;
            this.VratiPrioritet.Visible = false;
            this.VratiPrioritet.Click += new EventHandler(this.VratiPrioritet_Click);
            this.PostaviPrioritet.BackColor = Color.White;
            this.PostaviPrioritet.BackgroundImage = Resources.SlikaPrioritet;
            this.PostaviPrioritet.BackgroundImageLayout = ImageLayout.Stretch;
            this.PostaviPrioritet.Cursor = Cursors.Hand;
            this.PostaviPrioritet.FlatAppearance.BorderColor = Color.White;
            this.PostaviPrioritet.FlatStyle = FlatStyle.Flat;
            this.PostaviPrioritet.Location = new Point(0x105, 2);
            this.PostaviPrioritet.Margin = new Padding(0);
            this.PostaviPrioritet.Name = "PostaviPrioritet";
            this.PostaviPrioritet.Size = new Size(0x1c, 0x1c);
            this.PostaviPrioritet.TabIndex = 1;
            this.PostaviPrioritet.TextAlign = ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.PostaviPrioritet, "Postavi odabranu vest za PRIORITET");
            this.PostaviPrioritet.UseVisualStyleBackColor = false;
            this.PostaviPrioritet.Visible = false;
            this.PostaviPrioritet.Click += new EventHandler(this.PostaviPrioritet_Click);
            this.ObrisiVest.BackColor = Color.White;
            this.ObrisiVest.BackgroundImage = Resources.remove;
            this.ObrisiVest.BackgroundImageLayout = ImageLayout.Stretch;
            this.ObrisiVest.Cursor = Cursors.Hand;
            this.ObrisiVest.FlatAppearance.BorderColor = Color.White;
            this.ObrisiVest.FlatStyle = FlatStyle.Flat;
            this.ObrisiVest.Location = new Point(0xe9, 0x1d);
            this.ObrisiVest.Margin = new Padding(0);
            this.ObrisiVest.Name = "ObrisiVest";
            this.ObrisiVest.Size = new Size(0x1c, 0x1c);
            this.ObrisiVest.TabIndex = 3;
            this.ObrisiVest.TextAlign = ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.ObrisiVest, "Obriši izabranu vest");
            this.ObrisiVest.UseVisualStyleBackColor = false;
            this.ObrisiVest.Visible = false;
            this.ObrisiVest.Click += new EventHandler(this.ObrisiVest_Click);
            this.NovaVest.BackColor = Color.White;
            this.NovaVest.BackgroundImage = Resources.dodaj;
            this.NovaVest.BackgroundImageLayout = ImageLayout.Stretch;
            this.NovaVest.Cursor = Cursors.Hand;
            this.NovaVest.FlatAppearance.BorderColor = Color.White;
            this.NovaVest.FlatStyle = FlatStyle.Flat;
            this.NovaVest.Location = new Point(0xe9, 2);
            this.NovaVest.Margin = new Padding(0);
            this.NovaVest.Name = "NovaVest";
            this.NovaVest.Size = new Size(0x1c, 0x1c);
            this.NovaVest.TabIndex = 0;
            this.NovaVest.TextAlign = ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.NovaVest, "Unos novih vesti");
            this.NovaVest.UseVisualStyleBackColor = false;
            this.NovaVest.Visible = false;
            this.NovaVest.Click += new EventHandler(this.NovaVest_Click);
            this.VratiMiniPrikaz.BackColor = Color.White;
            this.VratiMiniPrikaz.BackgroundImage = Resources.move;
            this.VratiMiniPrikaz.BackgroundImageLayout = ImageLayout.Stretch;
            this.VratiMiniPrikaz.Cursor = Cursors.Hand;
            this.VratiMiniPrikaz.FlatAppearance.BorderColor = Color.White;
            this.VratiMiniPrikaz.FlatStyle = FlatStyle.Flat;
            this.VratiMiniPrikaz.Location = new Point(4, 2);
            this.VratiMiniPrikaz.Name = "VratiMiniPrikaz";
            this.VratiMiniPrikaz.Size = new Size(0x38, 0x38);
            this.VratiMiniPrikaz.TabIndex = 7;
            this.VratiMiniPrikaz.TextAlign = ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.VratiMiniPrikaz, "Vrati u normalan prikaz vesti");
            this.VratiMiniPrikaz.UseVisualStyleBackColor = false;
            this.VratiMiniPrikaz.Visible = false;
            this.VratiMiniPrikaz.Click += new EventHandler(this.VratiMiniPrikaz_Click);
            this.VratiIzaProzor.BackColor = Color.White;
            this.VratiIzaProzor.BackgroundImage = Resources.down;
            this.VratiIzaProzor.BackgroundImageLayout = ImageLayout.Stretch;
            this.VratiIzaProzor.Cursor = Cursors.Hand;
            this.VratiIzaProzor.FlatAppearance.BorderColor = Color.White;
            this.VratiIzaProzor.FlatStyle = FlatStyle.Flat;
            this.VratiIzaProzor.Location = new Point(0x41, 2);
            this.VratiIzaProzor.Name = "VratiIzaProzor";
            this.VratiIzaProzor.Size = new Size(0x38, 0x38);
            this.VratiIzaProzor.TabIndex = 9;
            this.VratiIzaProzor.TextAlign = ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.VratiIzaProzor, "Vrati prozor u normalan prikaz u odnosu na druge programe");
            this.VratiIzaProzor.UseVisualStyleBackColor = false;
            this.VratiIzaProzor.Visible = false;
            this.VratiIzaProzor.Click += new EventHandler(this.VratiIzaProzor_Click);
            this.progressBar1.Cursor = Cursors.WaitCursor;
            this.progressBar1.Dock = DockStyle.Fill;
            this.progressBar1.Location = new Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new Size(0x310, 60);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 5;
            this.toolTip1.SetToolTip(this.progressBar1, "Početno učitavanje");
            this.panel1.Controls.Add(this.DodajKomentar);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.StanjeKomentara);
            this.panel1.Controls.Add(this.PrijaviPoslatKomentar);
            this.panel1.Controls.Add(this.KomentarisaloKorisnika1);
            this.panel1.Controls.Add(this.KomentarisaloKorisnika2);
            this.panel1.Controls.Add(this.PoslatoKomentara1);
            this.panel1.Controls.Add(this.PoslatoKomentara2);
            this.panel1.Controls.Add(this.ObjavljenoKomentara1);
            this.panel1.Controls.Add(this.ObjavljenoKomentara2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.SelektovanBrojKomentara);
            this.panel1.Controls.Add(this.SelektovanNaslov);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(230, 60);
            this.panel1.Margin = new Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x22a, 0xac);
            this.panel1.TabIndex = 2;
            this.DodajKomentar.BackColor = Color.White;
            this.DodajKomentar.BackgroundImage = Resources.dodaj;
            this.DodajKomentar.BackgroundImageLayout = ImageLayout.Stretch;
            this.DodajKomentar.Cursor = Cursors.Hand;
            this.DodajKomentar.FlatAppearance.BorderSize = 0;
            this.DodajKomentar.FlatStyle = FlatStyle.Flat;
            this.DodajKomentar.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.DodajKomentar.Location = new Point(0x20e, 0x93);
            this.DodajKomentar.Name = "DodajKomentar";
            this.DodajKomentar.Size = new Size(0x16, 0x16);
            this.DodajKomentar.TabIndex = 4;
            this.toolTip1.SetToolTip(this.DodajKomentar, "Dodaj smernicu");
            this.DodajKomentar.UseVisualStyleBackColor = false;
            this.DodajKomentar.Click += new EventHandler(this.DodajKomentar_Click);
            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.button1.Location = new Point(3, 0x90);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x224, 0x1c);
            this.button1.TabIndex = 3;
            this.button1.Text = "Smernice (komentari i dodatne informacije)";
            this.button1.UseVisualStyleBackColor = true;
            this.StanjeKomentara.BackColor = Color.Pink;
            this.StanjeKomentara.Cursor = Cursors.Hand;
            this.StanjeKomentara.FlatAppearance.BorderSize = 2;
            this.StanjeKomentara.FlatAppearance.MouseOverBackColor = Color.Thistle;
            this.StanjeKomentara.FlatStyle = FlatStyle.Flat;
            this.StanjeKomentara.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.StanjeKomentara.Location = new Point(0x18c, 100);
            this.StanjeKomentara.Name = "StanjeKomentara";
            this.StanjeKomentara.Size = new Size(0x92, 0x25);
            this.StanjeKomentara.TabIndex = 12;
            this.StanjeKomentara.Text = "Stanje poslatih komentara";
            this.toolTip1.SetToolTip(this.StanjeKomentara, "Prijavite komentar koji ste poslali za ovu vest.\r\nOvde prijavljujete objavljene i poslate komentare.\r\nProgram će na svakih 15 minuta da proverava poslate\r\nkomentare da li su objavljeni.");
            this.StanjeKomentara.UseVisualStyleBackColor = false;
            this.StanjeKomentara.Click += new EventHandler(this.StanjeKomentara_Click);
            this.PrijaviPoslatKomentar.BackColor = Color.Lavender;
            this.PrijaviPoslatKomentar.Cursor = Cursors.Hand;
            this.PrijaviPoslatKomentar.FlatAppearance.BorderSize = 2;
            this.PrijaviPoslatKomentar.FlatAppearance.MouseOverBackColor = Color.Thistle;
            this.PrijaviPoslatKomentar.FlatStyle = FlatStyle.Flat;
            this.PrijaviPoslatKomentar.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.PrijaviPoslatKomentar.Location = new Point(0x18c, 0x3b);
            this.PrijaviPoslatKomentar.Name = "PrijaviPoslatKomentar";
            this.PrijaviPoslatKomentar.Size = new Size(0x92, 0x25);
            this.PrijaviPoslatKomentar.TabIndex = 11;
            this.PrijaviPoslatKomentar.Text = "Prijavi poslat komentar";
            this.toolTip1.SetToolTip(this.PrijaviPoslatKomentar, "Prijavite komentar koji ste poslali za ovu vest.\r\nOvde prijavljujete objavljene i poslate komentare.\r\nProgram će na svakih 15 minuta da proverava poslate\r\nkomentare da li su objavljeni.");
            this.PrijaviPoslatKomentar.UseVisualStyleBackColor = false;
            this.PrijaviPoslatKomentar.Click += new EventHandler(this.PrijaviPoslatKomentar_Click);
            this.KomentarisaloKorisnika1.BackColor = Color.LightSteelBlue;
            this.KomentarisaloKorisnika1.FlatAppearance.BorderSize = 2;
            this.KomentarisaloKorisnika1.FlatStyle = FlatStyle.Flat;
            this.KomentarisaloKorisnika1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.KomentarisaloKorisnika1.Location = new Point(300, 0x3b);
            this.KomentarisaloKorisnika1.Name = "KomentarisaloKorisnika1";
            this.KomentarisaloKorisnika1.Size = new Size(90, 40);
            this.KomentarisaloKorisnika1.TabIndex = 10;
            this.KomentarisaloKorisnika1.Text = "Komentarisalo korisnika";
            this.toolTip1.SetToolTip(this.KomentarisaloKorisnika1, "Ukupan broj korisnika koji je slalo komentare na ovu vest");
            this.KomentarisaloKorisnika1.UseVisualStyleBackColor = false;
            this.KomentarisaloKorisnika1.Click += new EventHandler(this.KomentarisaloKorisnika1_Click);
            this.KomentarisaloKorisnika2.FlatAppearance.BorderSize = 2;
            this.KomentarisaloKorisnika2.FlatStyle = FlatStyle.Flat;
            this.KomentarisaloKorisnika2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.KomentarisaloKorisnika2.Location = new Point(300, 0x61);
            this.KomentarisaloKorisnika2.Name = "KomentarisaloKorisnika2";
            this.KomentarisaloKorisnika2.Size = new Size(90, 40);
            this.KomentarisaloKorisnika2.TabIndex = 9;
            this.KomentarisaloKorisnika2.Text = "0";
            this.toolTip1.SetToolTip(this.KomentarisaloKorisnika2, "Ukupan broj korisnika koji je slalo komentare na ovu vest");
            this.KomentarisaloKorisnika2.UseVisualStyleBackColor = true;
            this.KomentarisaloKorisnika2.Click += new EventHandler(this.KomentarisaloKorisnika1_Click);
            this.PoslatoKomentara1.BackColor = Color.PaleTurquoise;
            this.PoslatoKomentara1.FlatAppearance.BorderSize = 2;
            this.PoslatoKomentara1.FlatStyle = FlatStyle.Flat;
            this.PoslatoKomentara1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.PoslatoKomentara1.Location = new Point(0xcc, 0x3b);
            this.PoslatoKomentara1.Name = "PoslatoKomentara1";
            this.PoslatoKomentara1.Size = new Size(90, 40);
            this.PoslatoKomentara1.TabIndex = 8;
            this.PoslatoKomentara1.Text = "Poslato komentara";
            this.toolTip1.SetToolTip(this.PoslatoKomentara1, "Ukupan broj komentara koji su naši korisnici prijavili da su poslali");
            this.PoslatoKomentara1.UseVisualStyleBackColor = false;
            this.PoslatoKomentara1.Click += new EventHandler(this.PoslatoKomentara1_Click);
            this.PoslatoKomentara2.FlatAppearance.BorderSize = 2;
            this.PoslatoKomentara2.FlatStyle = FlatStyle.Flat;
            this.PoslatoKomentara2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.PoslatoKomentara2.Location = new Point(0xcc, 0x61);
            this.PoslatoKomentara2.Name = "PoslatoKomentara2";
            this.PoslatoKomentara2.Size = new Size(90, 40);
            this.PoslatoKomentara2.TabIndex = 7;
            this.PoslatoKomentara2.Text = "0";
            this.toolTip1.SetToolTip(this.PoslatoKomentara2, "Ukupan broj komentara koji su naši korisnici prijavili da su poslali");
            this.PoslatoKomentara2.UseVisualStyleBackColor = true;
            this.PoslatoKomentara2.Click += new EventHandler(this.PoslatoKomentara1_Click);
            this.ObjavljenoKomentara1.BackColor = Color.PowderBlue;
            this.ObjavljenoKomentara1.FlatAppearance.BorderSize = 2;
            this.ObjavljenoKomentara1.FlatStyle = FlatStyle.Flat;
            this.ObjavljenoKomentara1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.ObjavljenoKomentara1.Location = new Point(0x6c, 0x3b);
            this.ObjavljenoKomentara1.Name = "ObjavljenoKomentara1";
            this.ObjavljenoKomentara1.Size = new Size(90, 40);
            this.ObjavljenoKomentara1.TabIndex = 6;
            this.ObjavljenoKomentara1.Text = "Objavljeno komentara";
            this.toolTip1.SetToolTip(this.ObjavljenoKomentara1, "Ukupan broj komentara koji su prijavili naši korisnici");
            this.ObjavljenoKomentara1.UseVisualStyleBackColor = false;
            this.ObjavljenoKomentara1.Click += new EventHandler(this.ObjavljenoKomentara1_Click);
            this.ObjavljenoKomentara2.FlatAppearance.BorderSize = 2;
            this.ObjavljenoKomentara2.FlatStyle = FlatStyle.Flat;
            this.ObjavljenoKomentara2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.ObjavljenoKomentara2.Location = new Point(0x6c, 0x61);
            this.ObjavljenoKomentara2.Name = "ObjavljenoKomentara2";
            this.ObjavljenoKomentara2.Size = new Size(90, 40);
            this.ObjavljenoKomentara2.TabIndex = 5;
            this.ObjavljenoKomentara2.Text = "0";
            this.toolTip1.SetToolTip(this.ObjavljenoKomentara2, "Ukupan broj komentara koji su prijavili naši korisnici");
            this.ObjavljenoKomentara2.UseVisualStyleBackColor = true;
            this.ObjavljenoKomentara2.Click += new EventHandler(this.ObjavljenoKomentara1_Click);
            this.button3.BackColor = Color.SkyBlue;
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = FlatStyle.Flat;
            this.button3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.button3.Location = new Point(12, 0x3b);
            this.button3.Name = "button3";
            this.button3.Size = new Size(90, 40);
            this.button3.TabIndex = 2;
            this.button3.Text = "Ukupno komentara";
            this.toolTip1.SetToolTip(this.button3, "Ukupan broj komentara na vesti");
            this.button3.UseVisualStyleBackColor = false;
            this.SelektovanBrojKomentara.FlatAppearance.BorderSize = 2;
            this.SelektovanBrojKomentara.FlatStyle = FlatStyle.Flat;
            this.SelektovanBrojKomentara.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.SelektovanBrojKomentara.Location = new Point(12, 0x61);
            this.SelektovanBrojKomentara.Name = "SelektovanBrojKomentara";
            this.SelektovanBrojKomentara.Size = new Size(90, 40);
            this.SelektovanBrojKomentara.TabIndex = 1;
            this.SelektovanBrojKomentara.Text = "0";
            this.toolTip1.SetToolTip(this.SelektovanBrojKomentara, "Ukupan broj komentara na vesti");
            this.SelektovanBrojKomentara.UseVisualStyleBackColor = true;
            this.SelektovanNaslov.BackColor = Color.DarkSlateGray;
            this.SelektovanNaslov.Cursor = Cursors.Hand;
            this.SelektovanNaslov.FlatAppearance.BorderColor = Color.SteelBlue;
            this.SelektovanNaslov.FlatAppearance.BorderSize = 4;
            this.SelektovanNaslov.FlatStyle = FlatStyle.Flat;
            this.SelektovanNaslov.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.SelektovanNaslov.ForeColor = Color.White;
            this.SelektovanNaslov.Location = new Point(3, 0);
            this.SelektovanNaslov.Margin = new Padding(3, 6, 3, 3);
            this.SelektovanNaslov.Name = "SelektovanNaslov";
            this.SelektovanNaslov.Size = new Size(0x224, 0x34);
            this.SelektovanNaslov.TabIndex = 0;
            this.SelektovanNaslov.Text = "NASLOV";
            this.toolTip1.SetToolTip(this.SelektovanNaslov, "Klikni ovde da otvoriš vesti u svom pretraživaču");
            this.SelektovanNaslov.UseVisualStyleBackColor = false;
            this.SelektovanNaslov.Click += new EventHandler(this.SelektovanNaslov_Click);
            this.richTextBox1.BackColor = Color.White;
            this.richTextBox1.Dock = DockStyle.Fill;
            this.richTextBox1.Location = new Point(0xe9, 0xeb);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new Size(0x224, 0x20b);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            this.richTextBox1.LinkClicked += new LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            this.toolTip1.BackColor = Color.White;
            this.PocetniTimer.Interval = 500;
            this.PocetniTimer.Tick += new EventHandler(this.timer1_Tick);
            this.RedovnoAzuriranje.Interval = 0x7530;
            this.RedovnoAzuriranje.Tick += new EventHandler(this.RedovnoAzuriranje_Tick);
            this.VratiZabranu.Interval = 0x4e20;
            this.VratiZabranu.Tick += new EventHandler(this.VratiZabranu_Tick);
            this.ZakasneloAzuriranjeTeksta.Interval = 0x3e8;
            this.ZakasneloAzuriranjeTeksta.Tick += new EventHandler(this.ZakasneloAzuriranjeTeksta_Tick);
            this.PrikazivanjeObjavljenihKomentara.Interval = 0x1f40;
            this.PrikazivanjeObjavljenihKomentara.Tick += new EventHandler(this.PrikazivanjeObjavljenihKomentara_Tick);
            this.AzuriranjeBrojaKorisnika.DoWork += new DoWorkEventHandler(this.AzuriranjeBrojaKorisnika_DoWork);
            this.AzuriranjeBrojaKorisnika.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.AzuriranjeBrojaKorisnika_RunWorkerCompleted);
            this.SkidanjePodatakaVesti.DoWork += new DoWorkEventHandler(this.SkidanjePodatakaVesti_DoWork);
            this.SkidanjePodatakaVesti.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.SkidanjePodatakaVesti_RunWorkerCompleted);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            base.ClientSize = new Size(0x310, 0x2f9);
            base.Controls.Add(this.tableLayoutPanel1);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "AktuelniZadaci";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Vesti";
            base.Load += new EventHandler(this.AktuelniZadaci_Load);
            base.Shown += new EventHandler(this.AktuelniZadaci_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelMiniVesti.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panelGornjiMeni.ResumeLayout(false);
            this.FilterZaPretragu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void kom_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.PrijaviPoslatKomentar.Visible = true;
        }

        private void kom_GlavniKomentar(object sender, UnosKomentara.PosaljiNazadKomentar e)
        {
            try
            {
                string[] dobijenKomentar = e.DobijenKomentar;
                string str = dobijenKomentar[0];
                string str2 = dobijenKomentar[1];
                string str3 = dobijenKomentar[2];
                string str4 = dobijenKomentar[3];
                string str5 = dobijenKomentar[4];
                string str6 = this.Privremena.UzmiOriginalLink();
                this.Privremena.ImaKomentara(1, "PLUS");
                this.MojiKomentari[this.MKbroj] = str;
                this.MKUrlVesti[this.MKbroj] = str6;
                this.MKObjavljeni[this.MKbroj] = "NE";
                this.MKVestiID[this.MKbroj] = str2;
                this.MKNapomenaKomentara[this.MKbroj] = str3;
                this.MKDatumUnosaKomentara[this.MKbroj] = str4;
                this.MKIdKomentara[this.MKbroj] = str5;
                ExcelFile file = new ExcelFile();
                file.LoadXls(this.putanjaFolder + @"\Vpic\MKB\pos.jpg");
                int count = file.Worksheets[0].Rows.Count;
                this.MKExcelRowNumber[this.MKbroj] = count;
                this.MKbroj++;
                file.Worksheets[0].Rows[count].Cells[0].Value = str;
                file.Worksheets[0].Rows[count].Cells[1].Value = str6;
                file.Worksheets[0].Rows[count].Cells[2].Value = str2;
                file.Worksheets[0].Rows[count].Cells[3].Value = "NE";
                file.Worksheets[0].Rows[count].Cells[4].Value = str3;
                file.Worksheets[0].Rows[count].Cells[5].Value = str4;
                file.Worksheets[0].Rows[count].Cells[6].Value = str5;
                file.SaveXls(this.putanjaFolder + @"\Vpic\MKB\pos.jpg");
                this.OsveziChat();
                int index = 0;
                foreach (string str7 in this.GGReci)
                {
                    if (str7 == null)
                    {
                        return;
                    }
                    if (str.Contains(" " + str7 + " ") || str.StartsWith(str7 + " "))
                    {
                        GGPrikaz prikaz = new GGPrikaz();
                        string str8 = "";
                        string str9 = (str8 + "U prijavljenom komentaru postoje gramatičke greške\r\n\r\n") + str + "\r\n\r\n";
                        str8 = (str9 + "Pronađena greška je u reči:" + str7 + " ,a potrebno je da bude:" + this.GGIspravka[index] + "\r\n") + "Komentari sa gramatičkim greškama će biti manje bodovani.";
                        prikaz.tekst = str8;
                        prikaz.Show();
                    }
                    index++;
                }
            }
            catch (Exception exception)
            {
                this.PosaljiMail("CODE: kom_GlavniKomentar \n\n" + exception.ToString());
                MessageBox.Show("Dogodila se greška prilikom snimanja u lokalnu bazu, proverite da li imate ovaj komentar u programu, ako ne ponovite ga.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void KomentarisaloKorisnika1_Click(object sender, EventArgs e)
        {
            if (this.AdminListe == 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                this.button1.Text = "Korisnici koji su prijavili poslat komentar";
                this.button1.BackColor = Color.LightSteelBlue;
                this.DodajKomentar.Visible = false;
                try
                {
                    string s = new WebClient().DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/GetUsersSendCommentFromId.php?Id=" + this.Privremena.UzmiOriginalID());
                    this.richTextBox1.Text = "";
                    JsonTextReader reader = new JsonTextReader(new StringReader(s));
                    int num = 0;
                    while (reader.Read())
                    {
                        if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                        {
                            if (num == 0)
                            {
                                this.richTextBox1.Text = this.richTextBox1.Text + "\r\n" + reader.Value.ToString();
                            }
                            num++;
                            if (num == 1)
                            {
                                num = 0;
                            }
                        }
                    }
                }
                catch
                {
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void link_GlavniLink(object sender, LinkKaVestima.PosaljiNazadLink e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.ZabraniUbacivanjeVesti = 1;
            this.VratiZabranu.Enabled = true;
            this.VratiZabranu.Start();
            try
            {
                WebClient client = new WebClient();
                string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/InsertNewNews.php?";
                address = (address + "Id=" + this.PersonalID) + "&ur=" + e.DobijenLink.Replace("&", "[[]]");
                string str2 = client.DownloadString(address);
                if (str2.Contains("OKET"))
                {
                    try
                    {
                        WebClient client2 = new WebClient();
                        string str3 = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/GetIdFromUrl.php?";
                        str3 = str3 + "&ur=" + e.DobijenLink.Replace("&", "[[]]");
                        string str4 = client2.DownloadString(str3);
                        string id = this.VestiId[this.PocetnoUcitavanje] = str4.Replace("\r\n", "");
                        this.PocetnoUcitavanje++;
                        this.NapraviVest(id, e.DobijenLink, 1, "", "", "NE");
                    }
                    catch (Exception exception)
                    {
                        this.PosaljiMail("CODE: link_GlavniLink - GetIdFromUrl\n\n" + exception.ToString());
                    }
                }
                else if (str2.Contains("GRESKA"))
                {
                    MessageBox.Show("Ova vest je već ubačena u program.\nAko ovu vest ne vidite u programu probajte da ažurirate vesti.\nAko i dalje nema vesti ugasite i upalite program.\n\n\nSigurni ste da ova vest ne postoji u programu, prijavite nepravilnost u opciji programa PRIJAVI PROBLEM.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Dogodila se neka greška, pokušajte kasnije ili restartujte program.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                this.AktivacijaFokusFlow = 0;
                this.AktivacijaFokusFlow2 = 0;
            }
            catch (Exception exception2)
            {
                MessageBox.Show("Dogodila se neka greška, pokušajte kasnije ili restartujte program.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.PosaljiMail("CODE: link_GlavniLink\n\n" + exception2.ToString());
            }
            Cursor.Current = Cursors.Default;
        }

        private void MiniVerzijaProzora_Click(object sender, EventArgs e)
        {
            base.Size = new Size(0xec, Screen.PrimaryScreen.WorkingArea.Height);
            base.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 0xec, 0);
            this.MiniVerzijaProzora.Visible = false;
            this.VratiMiniPrikaz.Visible = true;
        }

        private void NapraviVest(string id, string link, int start, string naslov, string slika, string prio)
        {
            try
            {
                MiniVest vest = new MiniVest();
                vest.Pocetak(id, link, start, naslov, slika, this.PersonalID);
                vest.WasClicked += new EventHandler<EventArgs>(this.nova_WasClicked);
                if (prio.Contains("DA"))
                {
                    this.flowLayoutPanel1.Controls.Add(vest);
                }
                else
                {
                    this.flowLayoutPanel2.Controls.Add(vest);
                }
            }
            catch
            {
            }
        }

        private void nova_WasClicked(object sender, EventArgs e)
        {
            try
            {
                this.Privremena.OznaciKontroluZuto();
            }
            catch
            {
            }
            this.Privremena = (MiniVest) sender;
            this.SelektovanNaslov.Text = this.Privremena.UzmiNaslovVesti();
            this.SelektovanBrojKomentara.Text = "0";
            this.SelektovanBrojKomentara.Text = this.Privremena.UzmiBrojKomentara();
            this.Privremena.OznaciKontroluZuto();
            this.Privremena.OsveziBrojKomentara();
            string str = this.Privremena.UzmiOriginalLink();
            if ((((str.Contains("b92.net") || str.Contains("blic.rs")) || (str.Contains("kurir-info.rs") || str.Contains("politika.rs"))) || ((str.Contains("alo.rs") || str.Contains("telegraf.rs")) || (str.Contains("danas.rs") || str.Contains("rts.rs")))) || str.Contains("novosti.rs"))
            {
                if (this.PokrenutaProveraKomentara == 0)
                {
                    this.PrijaviPoslatKomentar.Visible = true;
                    this.StanjeKomentara.Visible = true;
                }
            }
            else
            {
                this.PrijaviPoslatKomentar.Visible = false;
                this.StanjeKomentara.Visible = false;
            }
            if (this.Privremena.UzmiOriginalID() != "99999")
            {
                this.OsveziChat();
            }
            else
            {
                this.richTextBox1.Text = "";
            }
            this.ZakasneloAzuriranjeTeksta.Enabled = true;
            this.ZakasneloAzuriranjeTeksta.Start();
            this.DodajKomentar.Visible = true;
            this.button1.Text = "Smernice (kako treba komentarisati)";
            this.button1.BackColor = Color.White;
        }

        private void NovaVest_Click(object sender, EventArgs e)
        {
            LinkKaVestima vestima = new LinkKaVestima();
            vestima.GlavniLink += new EventHandler<LinkKaVestima.PosaljiNazadLink>(this.link_GlavniLink);
            this.AktivacijaFokusFlow = 1;
            this.AktivacijaFokusFlow2 = 1;
            vestima.Show();
        }

        private void ObjavljenoKomentara1_Click(object sender, EventArgs e)
        {
            if (this.AdminListe != 1)
            {
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            this.button1.Text = "Objavljeni komentari naših korisnika";
            this.button1.BackColor = Color.PowderBlue;
            this.DodajKomentar.Visible = false;
            int num = int.Parse(this.ObjavljenoKomentara2.Text);
            int num2 = 0;
            int num3 = 0;
            this.richTextBox1.Text = "";
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    try
                    {
                        if (num <= num3)
                        {
                            goto Label_024A;
                        }
                        WebClient client = new WebClient();
                        JsonTextReader reader = new JsonTextReader(new StringReader(client.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/GetPublishCommentsFromId2.php?Id=" + this.Privremena.UzmiOriginalID() + "&Start=" + num2.ToString() + "&End=30")));
                        int num5 = 0;
                        while (reader.Read())
                        {
                            if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                            {
                                switch (num5)
                                {
                                    case 0:
                                    {
                                        string text = "\r\n" + reader.Value.ToString() + "\r\n";
                                        int textLength = this.richTextBox1.TextLength;
                                        this.richTextBox1.AppendText(text);
                                        this.richTextBox1.SelectionStart = textLength;
                                        this.richTextBox1.SelectionLength = text.Length;
                                        this.richTextBox1.SelectionColor = Color.Blue;
                                        break;
                                    }
                                    case 1:
                                        this.richTextBox1.AppendText(reader.Value.ToString().Replace("[[]]", "&") + "\r\n------------------------------------------------------------------------------------------------------------------------");
                                        break;
                                }
                                num5++;
                                if (num5 == 2)
                                {
                                    num5 = 0;
                                }
                            }
                        }
                        num2 += 30;
                        num3 += 30;
                    }
                    catch
                    {
                        goto Label_024A;
                    }
                }
            }
            catch
            {
            }
        Label_024A:
            Cursor.Current = Cursors.Default;
        }

        private void ObrisiVest_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni da želite da obrišete izabranu vest?", "POTVRDA", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    try
                    {
                        WebClient client = new WebClient();
                        NameValueCollection data = new NameValueCollection();
                        data["IAMIdKorisnika"] = this.PersonalID;
                        data["IAMUrlVesti"] = this.Privremena.UzmiOriginalLink();
                        data["IAMNaslovVesti"] = this.Privremena.UzmiNaslovVesti();
                        data["IAMAkcija"] = "Brisanje vesti";
                        client.Encoding = Encoding.UTF8;
                        byte[] bytes = client.UploadValues("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/InsertNewHistoryAdmin.php", "POST", data);
                        if (Encoding.UTF8.GetString(bytes).Contains("OKET"))
                        {
                        }
                    }
                    catch
                    {
                    }
                    WebClient client2 = new WebClient();
                    string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/DeleteNewsById.php?";
                    address = address + "Id=" + this.Privremena.UzmiOriginalID();
                    if (client2.DownloadString(address).Contains("OKET"))
                    {
                        if (this.tabControl1.SelectedIndex == 0)
                        {
                            this.flowLayoutPanel1.Controls.RemoveAt(this.flowLayoutPanel1.Controls.GetChildIndex(this.Privremena));
                        }
                        else
                        {
                            this.flowLayoutPanel2.Controls.RemoveAt(this.flowLayoutPanel2.Controls.GetChildIndex(this.Privremena));
                        }
                        MessageBox.Show("Uspešno obrisana vest", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Dogodila se neka greška, pokušajte ponovo ili restartujte program.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void OsveziChat()
        {
            WebClient client;
            JsonTextReader reader;
            int num;
            Cursor.Current = Cursors.WaitCursor;
            this.richTextBox1.Text = "";
            try
            {
                client = new WebClient();
                reader = new JsonTextReader(new StringReader(client.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/GetSugestFromId.php?IdV=" + this.Privremena.UzmiOriginalID())));
                num = 0;
                while (reader.Read())
                {
                    if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                    {
                        switch (num)
                        {
                            case 0:
                            {
                                string text = "\r\n" + reader.Value.ToString() + "\r\n";
                                int textLength = this.richTextBox1.TextLength;
                                this.richTextBox1.AppendText(text);
                                this.richTextBox1.SelectionStart = textLength;
                                this.richTextBox1.SelectionLength = text.Length;
                                this.richTextBox1.SelectionColor = Color.Red;
                                break;
                            }
                            case 1:
                                this.richTextBox1.AppendText(reader.Value.ToString().Replace("[[]]", "&") + "\r\n------------------------------------------------------------------------------------------------------------------------");
                                break;
                        }
                        num++;
                        if (num == 2)
                        {
                            num = 0;
                        }
                    }
                }
            }
            catch
            {
            }
            try
            {
                client = new WebClient();
                reader = new JsonTextReader(new StringReader(client.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/GetStatsNewsById.php?IdVesti=" + this.Privremena.UzmiOriginalID())));
                num = 0;
                while (reader.Read())
                {
                    if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                    {
                        switch (num)
                        {
                            case 0:
                                this.ObjavljenoKomentara2.Text = reader.Value.ToString();
                                break;

                            case 1:
                                this.PoslatoKomentara2.Text = reader.Value.ToString();
                                break;

                            case 2:
                                this.KomentarisaloKorisnika2.Text = reader.Value.ToString();
                                break;
                        }
                        num++;
                        if (num == 3)
                        {
                            num = 0;
                        }
                    }
                }
            }
            catch
            {
            }
            Cursor.Current = Cursors.Default;
        }

        private void PokazivacVremenaProvera_Click(object sender, EventArgs e)
        {
            DoWorkEventHandler handler = null;
            if (this.PokrenutaProveraKomentara == 0)
            {
                this.PokrenutaProveraKomentara = 1;
                this.PrijaviPoslatKomentar.Visible = false;
                this.StanjeKomentara.Visible = false;
                this.PokazivacVremenaProvera.FlatAppearance.BorderSize = 5;
                this.PokazivacVremenaProvera.FlatAppearance.BorderColor = Color.Red;
                this.PokazivacVremenaProvera.Text = "0";
                this.SrediUcitavanje();
                BackgroundWorker worker = new BackgroundWorker {
                    WorkerReportsProgress = true
                };
                if (handler == null)
                {
                    handler = (obj, r) => this.WorkerDoWork(this.MojiKomentari, this.MKObjavljeni, this.MKUrlVesti, r, obj);
                }
                worker.DoWork += handler;
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
                worker.ProgressChanged += new ProgressChangedEventHandler(this.worker_ProgressChanged);
                worker.RunWorkerAsync();
            }
        }

        private void Poruke_Click(object sender, EventArgs e)
        {
            if (this.SkidanjeVesti == 0)
            {
                this.Poruke.BackColor = Color.Red;
                this.SkidanjeVesti = 1;
                this.SkidanjePodatakaVesti.RunWorkerAsync();
            }
        }

        public void PosaljiMail(string PorukaZaEmail)
        {
            try
            {
                string machineName = Environment.MachineName;
                string str2 = "";
                str2 = (str2 + machineName + "\n\n") + "Poruka iz programa: " + PorukaZaEmail;
                MailAddress from = new MailAddress("slanjeizvestajaitreports@gmail.com", machineName);
                MailAddress to = new MailAddress("gledovic83@open.telekom.rs", "za report");
                string password = "warcraft83";
                string str4 = "";
                str4 = "SkyNet Error";
                string str5 = str2;
                SmtpClient client = new SmtpClient {
                    Host = "smtp.gmail.com",
                    Port = 0x24b,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(from.Address, password),
                    Timeout = 0x4e20
                };
                MailMessage message2 = new MailMessage(from, to) {
                    Subject = str4,
                    Body = str5
                };
                using (MailMessage message = message2)
                {
                    client.Send(message);
                }
            }
            catch
            {
            }
        }

        private void PoslatoKomentara1_Click(object sender, EventArgs e)
        {
            if (this.AdminListe != 1)
            {
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            this.button1.Text = "Poslati komentari naših korisnika";
            this.button1.BackColor = Color.PaleTurquoise;
            this.DodajKomentar.Visible = false;
            int num = int.Parse(this.PoslatoKomentara2.Text);
            int num2 = 0;
            int num3 = 0;
            this.richTextBox1.Text = "";
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    try
                    {
                        if (num <= num3)
                        {
                            goto Label_024A;
                        }
                        WebClient client = new WebClient();
                        JsonTextReader reader = new JsonTextReader(new StringReader(client.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/GetCommentsFromId2.php?Id=" + this.Privremena.UzmiOriginalID() + "&Start=" + num2.ToString() + "&End=30")));
                        int num5 = 0;
                        while (reader.Read())
                        {
                            if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                            {
                                switch (num5)
                                {
                                    case 0:
                                    {
                                        string text = "\r\n" + reader.Value.ToString() + "\r\n";
                                        int textLength = this.richTextBox1.TextLength;
                                        this.richTextBox1.AppendText(text);
                                        this.richTextBox1.SelectionStart = textLength;
                                        this.richTextBox1.SelectionLength = text.Length;
                                        this.richTextBox1.SelectionColor = Color.Blue;
                                        break;
                                    }
                                    case 1:
                                        this.richTextBox1.AppendText(reader.Value.ToString().Replace("[[]]", "&") + "\r\n------------------------------------------------------------------------------------------------------------------------");
                                        break;
                                }
                                num5++;
                                if (num5 == 2)
                                {
                                    num5 = 0;
                                }
                            }
                        }
                        num2 += 30;
                        num3 += 30;
                    }
                    catch
                    {
                        goto Label_024A;
                    }
                }
            }
            catch
            {
            }
        Label_024A:
            Cursor.Current = Cursors.Default;
        }

        private void PostaviNaVrh_Click(object sender, EventArgs e)
        {
            base.TopMost = true;
            this.PostaviNaVrh.Visible = false;
            this.VratiIzaProzor.Visible = true;
        }

        private void PostaviPrioritet_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (MessageBox.Show("Da li želite da odabranu vest postavite kao PRIORITET?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    int num = 0;
                    foreach (Control control in this.flowLayoutPanel1.Controls)
                    {
                        if (control == this.Privremena)
                        {
                            num = 1;
                        }
                    }
                    if (num == 0)
                    {
                        WebClient client = new WebClient();
                        string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/UpdateNewsPriority.php?";
                        address = (address + "Id=" + this.Privremena.UzmiOriginalID()) + "&Prioritet=DA";
                        if (client.DownloadString(address).Contains("OKET"))
                        {
                            try
                            {
                                WebClient client2 = new WebClient();
                                NameValueCollection data = new NameValueCollection();
                                data["IAMIdKorisnika"] = this.PersonalID;
                                data["IAMUrlVesti"] = this.Privremena.UzmiOriginalLink();
                                data["IAMNaslovVesti"] = this.Privremena.UzmiNaslovVesti();
                                data["IAMAkcija"] = "Ubačena VEST u PRIORITET";
                                client2.Encoding = Encoding.UTF8;
                                byte[] bytes = client2.UploadValues("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/InsertNewHistoryAdmin.php", "POST", data);
                                if (Encoding.UTF8.GetString(bytes).Contains("OKET"))
                                {
                                }
                            }
                            catch
                            {
                            }
                            this.NapraviVest(this.Privremena.UzmiOriginalID(), this.Privremena.UzmiOriginalLink(), 0, this.Privremena.UzmiNaslovVesti(), this.Privremena.UzmiSliku(), "DA");
                            this.flowLayoutPanel2.Controls.RemoveAt(this.flowLayoutPanel2.Controls.GetChildIndex(this.Privremena));
                            this.Flow1stanje = this.flowLayoutPanel1.Controls.Count - 1;
                            this.Flow2stanje = this.flowLayoutPanel2.Controls.Count - 1;
                        }
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Odabrana vest je već prioritet", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Dogodila se neka greška, pokušajte ponovo ili restartujte program.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Cursor.Current = Cursors.Default;
        }

        private void PrijaviPoslatKomentar_Click(object sender, EventArgs e)
        {
            this.PrijaviPoslatKomentar.Visible = false;
            try
            {
                string str = this.Privremena.UzmiOriginalID();
                string str2 = this.Privremena.UzmiOriginalLink();
                UnosKomentara komentara = new UnosKomentara();
                komentara.GlavniKomentar += new EventHandler<UnosKomentara.PosaljiNazadKomentar>(this.kom_GlavniKomentar);
                komentara.FormClosed += new FormClosedEventHandler(this.kom_FormClosed);
                komentara.PersonalID = this.PersonalID;
                komentara.VestiID = str;
                komentara.Show();
            }
            catch
            {
                MessageBox.Show("Dogodila se greška, da li ste izabrali vest na koju šaljete komentar.", "INFO");
                this.PrijaviPoslatKomentar.Visible = true;
            }
        }

        private void PrikazivanjeObjavljenihKomentara_Tick(object sender, EventArgs e)
        {
            this.PrikazivanjeObjavljenihKomentara.Stop();
            this.PrikazivanjeObjavljenihKomentara.Enabled = false;
            try
            {
                int index = 0;
                int num2 = 0;
                foreach (string str in this.MKObjavljeni)
                {
                    if (str == null)
                    {
                        break;
                    }
                    try
                    {
                        if ((str == "NE") && (this.PriKomeTimer[index].Length > 3))
                        {
                            decimal num3 = 0M;
                            int num4 = 0;
                            try
                            {
                                int num5 = 0;
                                if (this.MKUrlVesti[index].Contains("blic.rs"))
                                {
                                    num3 += decimal.Parse(this.Bodovi[0]);
                                    num5 = 1;
                                    if (this.PriKomeTimer[index].Contains("BLICODGOVOR"))
                                    {
                                        this.PriKomeTimer[index] = this.PriKomeTimer[index].Replace("BLICODGOVOR", "");
                                        num3 += decimal.Parse(this.Bodovi[20]);
                                    }
                                }
                                if (this.MKUrlVesti[index].Contains("b92.net"))
                                {
                                    num3 += decimal.Parse(this.Bodovi[1]);
                                    num5 = 1;
                                }
                                if (this.MKUrlVesti[index].Contains("kurir-info.rs"))
                                {
                                    num3 += decimal.Parse(this.Bodovi[2]);
                                    num5 = 1;
                                }
                                if (this.MKUrlVesti[index].Contains("novosti.rs"))
                                {
                                    num3 += decimal.Parse(this.Bodovi[3]);
                                    num5 = 1;
                                }
                                if (this.MKUrlVesti[index].Contains("rts.rs"))
                                {
                                    num3 += decimal.Parse(this.Bodovi[4]);
                                    num5 = 1;
                                }
                                if (this.MKUrlVesti[index].Contains("danas.rs"))
                                {
                                    num3 += decimal.Parse(this.Bodovi[5]);
                                    num5 = 1;
                                }
                                if (this.MKUrlVesti[index].Contains("politika.rs"))
                                {
                                    num3 += decimal.Parse(this.Bodovi[6]);
                                    num5 = 1;
                                }
                                if (this.MKUrlVesti[index].Contains("telegraf.rs"))
                                {
                                    num3 += decimal.Parse(this.Bodovi[7]);
                                    num5 = 1;
                                }
                                if (this.MKUrlVesti[index].Contains("alo.rs"))
                                {
                                    num3 += decimal.Parse(this.Bodovi[8]);
                                    num5 = 1;
                                }
                                if (num5 == 0)
                                {
                                    num3 += decimal.Parse(this.Bodovi[9]);
                                }
                                if (this.MojiKomentari[index].Length > 100)
                                {
                                    num3 += decimal.Parse(this.Bodovi[12]);
                                }
                                if (this.MojiKomentari[index].Length > 200)
                                {
                                    num3 += decimal.Parse(this.Bodovi[13]);
                                }
                                if (this.MojiKomentari[index].Length > 300)
                                {
                                    num3 += decimal.Parse(this.Bodovi[14]);
                                }
                                if (this.MojiKomentari[index].Length > 400)
                                {
                                    num3 += decimal.Parse(this.Bodovi[15]);
                                }
                                if (this.MojiKomentari[index].Length > 500)
                                {
                                    num3 += decimal.Parse(this.Bodovi[0x10]);
                                }
                                int num6 = 0;
                                foreach (string str2 in this.GGReci)
                                {
                                    if (str2 == null)
                                    {
                                        break;
                                    }
                                    if (this.MojiKomentari[index].Contains(" " + str2 + " ") || this.MojiKomentari[index].StartsWith(str2 + " "))
                                    {
                                        num3 -= decimal.Parse(this.Bodovi[10]);
                                        break;
                                    }
                                    num6++;
                                }
                                if (num3.ToString().Contains(",") || (num3 > 5M))
                                {
                                    num3 /= 100M;
                                }
                                WebClient client = new WebClient();
                                string address = "";
                                if (this.MKIdKomentara[index] == "0")
                                {
                                    address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/UpdateNewsCommentPublish4.php?";
                                    address = ((((((address + "Id=" + this.PersonalID) + "&VestiID=" + this.MKVestiID[index]) + "&Komentar=" + this.MojiKomentari[index].Replace("&", "[[]]")) + "&Bodovi1=" + num3.ToString().Replace(",", ".")) + "&VPrioritet=" + this.Bodovi[11]) + "&Duplikat=" + this.Bodovi[0x11]) + "&Original=" + this.Bodovi[0x1b];
                                }
                                else
                                {
                                    address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/UpdateNewsCommentPublish5.php?";
                                    address = (((address + "Id=" + this.PersonalID) + "&VestiID=" + this.MKVestiID[index]) + "&Komentar=" + this.MKIdKomentara[index]) + "&Bodovi1=" + num3.ToString().Replace(",", ".");
                                }
                                string str4 = client.DownloadString(address);
                                if (!str4.Contains("OKET"))
                                {
                                    num4 = 1;
                                    this.PosaljiMail("CODE: PrikazivanjeObjavljenihKomentara_Tick - Greska kod prijave bodova za komentar\n\n" + str4);
                                }
                            }
                            catch (Exception exception)
                            {
                                num4 = 1;
                                this.PosaljiMail("CODE: PrikazivanjeObjavljenihKomentara_Tick - Glavna greska kod prijave bodova za objavljeni komentar u bazu\n\n" + exception.ToString());
                            }
                            try
                            {
                                if (num4 == 0)
                                {
                                    ExcelFile file = new ExcelFile();
                                    file.LoadXls(this.putanjaFolder + @"\Vpic\MKB\obj.jpg");
                                    int count = file.Worksheets[0].Rows.Count;
                                    file.Worksheets[0].Rows[count].Cells[0].Value = this.PriKomeTimer[index];
                                    file.Worksheets[0].Rows[count].Cells[1].Value = this.MKUrlVesti[index];
                                    file.SaveXls(this.putanjaFolder + @"\Vpic\MKB\obj.jpg");
                                }
                            }
                            catch (Exception exception2)
                            {
                                this.PosaljiMail("CODE: PrikazivanjeObjavljenihKomentara_Tick - Snimanje komentara u objavljene\n\n" + exception2.ToString());
                            }
                            try
                            {
                                if (num4 == 0)
                                {
                                    ExcelFile file2 = new ExcelFile();
                                    file2.LoadXls(this.putanjaFolder + @"\Vpic\MKB\pos.jpg");
                                    file2.Worksheets[0].Rows[this.MKExcelRowNumber[index]].Cells[3].Value = "DA";
                                    file2.SaveXls(this.putanjaFolder + @"\Vpic\MKB\pos.jpg");
                                }
                            }
                            catch (Exception exception3)
                            {
                                this.PosaljiMail("CODE: PrikazivanjeObjavljenihKomentara_Tick - Snimanje komentara u poslate\n\n" + exception3.ToString());
                            }
                            if (num4 == 0)
                            {
                                this.MKObjavljeni[index] = "DA";
                                try
                                {
                                    new ObjavljenKomentarPrikaz { tekst = this.MKUrlVesti[index] + "\r\n\r\n" + this.PriKomeTimer[index] + "\r\n\r\n\r\nKomentar trenutno vredi " + num3.ToString() + " bodova.\r\nOvo nisu trajni bodovi za komentar.Naknadno će se izvršiti dodatne analize koje će dodati ili oduzeti bodove komentaru." }.Show();
                                    num2++;
                                    this.PrikazivanjeObjavljenihKomentara.Enabled = true;
                                    this.PrikazivanjeObjavljenihKomentara.Start();
                                }
                                catch (Exception exception4)
                                {
                                    this.PosaljiMail("CODE: PrikazivanjeObjavljenihKomentara_Tick - Prikaz objavljenog komentara korisniku\n\n" + exception4.ToString());
                                    num2 = 0;
                                }
                            }
                            else
                            {
                                num2 = 0;
                            }
                            break;
                        }
                    }
                    catch
                    {
                    }
                    index++;
                }
                if (num2 == 0)
                {
                    try
                    {
                        MiniVest vest;
                        string str5;
                        int num8;
                        int num9;
                        int num10;
                        string str7;
                        string str8;
                        foreach (Control control in this.flowLayoutPanel2.Controls)
                        {
                            vest = new MiniVest();
                            vest = (MiniVest) control;
                            str5 = vest.UzmiOriginalID();
                            num8 = 0;
                            num9 = 0;
                            num10 = 0;
                            foreach (string str6 in this.MKObjavljeni)
                            {
                                if (str6 == null)
                                {
                                    break;
                                }
                                if (this.MKVestiID[num8] == str5)
                                {
                                    num9++;
                                }
                                if ((this.MKVestiID[num8] == str5) && (str6 == "NE"))
                                {
                                    num10++;
                                }
                                num8++;
                            }
                            if (num9 > 0)
                            {
                                if (num10 == 0)
                                {
                                    str7 = num9.ToString() + " / " + num9.ToString();
                                    vest.ImaKomentara(2, str7);
                                }
                                else
                                {
                                    int num13 = num9 - num10;
                                    str8 = num13.ToString() + " / " + num9.ToString();
                                    vest.ImaKomentara(1, str8);
                                }
                            }
                        }
                        foreach (Control control2 in this.flowLayoutPanel1.Controls)
                        {
                            vest = new MiniVest();
                            vest = (MiniVest) control2;
                            str5 = vest.UzmiOriginalID();
                            num8 = 0;
                            num9 = 0;
                            num10 = 0;
                            foreach (string str6 in this.MKObjavljeni)
                            {
                                if (str6 == null)
                                {
                                    break;
                                }
                                if (this.MKVestiID[num8] == str5)
                                {
                                    num9++;
                                }
                                if ((this.MKVestiID[num8] == str5) && (str6 == "NE"))
                                {
                                    num10++;
                                }
                                num8++;
                            }
                            if (num9 > 0)
                            {
                                if (num10 == 0)
                                {
                                    str7 = num9.ToString() + " / " + num9.ToString();
                                    vest.ImaKomentara(2, str7);
                                }
                                else
                                {
                                    str8 = ((num9 - num10)).ToString() + " / " + num9.ToString();
                                    vest.ImaKomentara(1, str8);
                                }
                            }
                        }
                    }
                    catch (Exception exception5)
                    {
                        this.PosaljiMail("CODE: PrikazivanjeObjavljenihKomentara_Tick - Azuriranje broja tvojih komentara na vestima\n\n" + exception5.ToString());
                    }
                    this.PokrenutaProveraKomentara = 0;
                    this.PKrun = this.RedovanKrug + 120;
                    this.PokazivacVremenaProvera.Text = ((this.PKrun - this.RedovanKrug) / 2).ToString();
                    this.PokazivacVremenaProvera.FlatAppearance.BorderSize = 2;
                    this.PokazivacVremenaProvera.FlatAppearance.BorderColor = Color.SteelBlue;
                    this.progressBar1.Visible = false;
                    if (this.NivoKorisnika.Contains("F"))
                    {
                        this.NovaVest.Visible = true;
                        this.ObrisiVest.Visible = true;
                        this.PostaviPrioritet.Visible = true;
                        this.VratiPrioritet.Visible = true;
                        this.AzurirajPromeniNaslov.Visible = true;
                        this.SnimljeneAdminPromene.Visible = true;
                        this.AdminListe = 1;
                    }
                    this.Poruke.Visible = true;
                    this.TrenutnoKorisnika.Visible = true;
                    this.MiniVerzijaProzora.Visible = true;
                    this.PostaviNaVrh.Visible = true;
                    this.FilterZaPretragu.Visible = true;
                    this.PokazivacVremenaProvera.Visible = true;
                    try
                    {
                        string str9 = this.Privremena.UzmiOriginalLink();
                        if ((((str9.Contains("b92.net") || str9.Contains("blic.rs")) || (str9.Contains("kurir-info.rs") || str9.Contains("politika.rs"))) || ((str9.Contains("alo.rs") || str9.Contains("telegraf.rs")) || (str9.Contains("danas.rs") || str9.Contains("rts.rs")))) || str9.Contains("novosti.rs"))
                        {
                            if (this.PokrenutaProveraKomentara == 0)
                            {
                                this.PrijaviPoslatKomentar.Visible = true;
                                this.StanjeKomentara.Visible = true;
                            }
                        }
                        else
                        {
                            this.PrijaviPoslatKomentar.Visible = false;
                            this.StanjeKomentara.Visible = false;
                        }
                    }
                    catch
                    {
                        this.PrijaviPoslatKomentar.Visible = false;
                        this.StanjeKomentara.Visible = false;
                    }
                }
            }
            catch (Exception exception6)
            {
                this.PosaljiMail("CODE: PrikazivanjeObjavljenihKomentara_Tick - Glavni CATCH skroz dole\n\n" + exception6.ToString());
            }
        }

        private void RedovnoAzuriranje_Tick(object sender, EventArgs e)
        {
            DoWorkEventHandler handler = null;
            this.RedovnoAzuriranje.Stop();
            this.RedovnoAzuriranje.Enabled = false;
            if (((this.RedovanKrug >= this.StanjeVesti) && (this.ZabraniUbacivanjeVesti == 0)) && (this.PokrenutaProveraKomentara == 0))
            {
                this.StanjeVesti += 12;
                this.RedovnoAzuriranje.Interval = 0x7530;
                try
                {
                    if (this.SkidanjeKorisnika == 0)
                    {
                        this.SkidanjeKorisnika = 1;
                        this.TrenutnoKorisnika.BackColor = Color.Red;
                        this.AzuriranjeBrojaKorisnika.RunWorkerAsync(this.PersonalID);
                    }
                }
                catch
                {
                }
                try
                {
                    if (this.SkidanjeVesti == 0)
                    {
                        this.Poruke.BackColor = Color.Red;
                        this.SkidanjeVesti = 1;
                        this.SkidanjePodatakaVesti.RunWorkerAsync();
                    }
                }
                catch
                {
                }
            }
            if ((this.RedovanKrug >= this.PKrun) && (this.PokrenutaProveraKomentara == 0))
            {
                this.PKrun += 120;
                int num = (this.PKrun - this.RedovanKrug) / 2;
                this.PokazivacVremenaProvera.Text = num.ToString();
                this.PokrenutaProveraKomentara = 1;
                this.PokazivacVremenaProvera.FlatAppearance.BorderSize = 5;
                this.PokazivacVremenaProvera.FlatAppearance.BorderColor = Color.Red;
                this.PrijaviPoslatKomentar.Visible = false;
                this.StanjeKomentara.Visible = false;
                try
                {
                    this.SrediUcitavanje();
                    BackgroundWorker worker = new BackgroundWorker {
                        WorkerReportsProgress = true
                    };
                    if (handler == null)
                    {
                        handler = (obj, r) => this.WorkerDoWork(this.MojiKomentari, this.MKObjavljeni, this.MKUrlVesti, r, obj);
                    }
                    worker.DoWork += handler;
                    worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
                    worker.ProgressChanged += new ProgressChangedEventHandler(this.worker_ProgressChanged);
                    worker.RunWorkerAsync();
                }
                catch
                {
                }
            }
            else if (this.PokrenutaProveraKomentara == 0)
            {
                this.PokazivacVremenaProvera.Text = ((this.PKrun - this.RedovanKrug) / 2).ToString();
            }
            else
            {
                this.PokazivacVremenaProvera.Text = "0";
            }
            try
            {
                if (this.PokrenutaProveraKomentara == 0)
                {
                    MiniVest vest;
                    if (this.Flow1stanje < 0)
                    {
                        this.Flow1stanje = this.flowLayoutPanel1.Controls.Count - 1;
                    }
                    else
                    {
                        try
                        {
                            vest = new MiniVest();
                            vest = (MiniVest) this.flowLayoutPanel1.Controls[this.Flow1stanje];
                            vest.OsveziBrojKomentara();
                        }
                        catch
                        {
                        }
                        this.Flow1stanje--;
                    }
                    if (this.Flow2stanje < 0)
                    {
                        this.Flow2stanje = this.flowLayoutPanel2.Controls.Count - 1;
                    }
                    else
                    {
                        try
                        {
                            vest = new MiniVest();
                            ((MiniVest) this.flowLayoutPanel2.Controls[this.Flow2stanje]).OsveziBrojKomentara();
                        }
                        catch
                        {
                        }
                        this.Flow2stanje--;
                    }
                }
            }
            catch
            {
            }
            this.RedovanKrug++;
            this.RedovnoAzuriranje.Enabled = true;
            this.RedovnoAzuriranje.Start();
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                Process.Start(e.LinkText);
            }
            catch
            {
            }
        }

        private void SelektovanNaslov_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Privremena.UzmiOriginalLink().Contains("*"))
                {
                    Process.Start(this.Privremena.UzmiOriginalLink().Split(new char[] { '*' })[0]);
                }
                else
                {
                    Process.Start(this.Privremena.UzmiOriginalLink());
                }
            }
            catch
            {
            }
        }

        private void SkidanjePodatakaVesti_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                JsonTextReader reader = new JsonTextReader(new StringReader(client.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/GetAllNews.php")));
                int num = 0;
                int index = 0;
                string[] strArray = new string[300];
                string[] strArray2 = new string[300];
                string[] strArray3 = new string[300];
                string[] strArray4 = new string[300];
                string[] strArray5 = new string[300];
                string[] strArray6 = new string[300];
                while (reader.Read())
                {
                    if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                    {
                        switch (num)
                        {
                            case 0:
                                strArray2[index] = reader.Value.ToString();
                                break;

                            case 1:
                                strArray[index] = reader.Value.ToString().Replace("[[]]", "&");
                                break;

                            case 2:
                                strArray3[index] = reader.Value.ToString();
                                break;

                            case 3:
                                strArray4[index] = reader.Value.ToString();
                                break;

                            case 4:
                                strArray5[index] = reader.Value.ToString();
                                break;
                        }
                        num++;
                        if (num == 5)
                        {
                            index++;
                            num = 0;
                        }
                    }
                }
                string[] strArray7 = new string[0x1388];
                int num3 = 0;
                foreach (string str2 in strArray2)
                {
                    if (str2 == null)
                    {
                        break;
                    }
                    strArray7[num3] = str2;
                    strArray7[num3 + 0x3e8] = strArray[num3];
                    strArray7[num3 + 0x7d0] = strArray3[num3];
                    strArray7[num3 + 0xbb8] = strArray4[num3];
                    strArray7[num3 + 0xfa0] = strArray5[num3];
                    num3++;
                }
                e.Result = strArray7;
            }
            catch
            {
            }
        }

        private void SkidanjePodatakaVesti_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                MiniVest vest;
                string str7;
                int num8;
                int index = 0;
                string[] strArray = new string[300];
                string[] strArray2 = new string[300];
                string[] strArray3 = new string[300];
                string[] strArray4 = new string[300];
                string[] strArray5 = new string[300];
                string[] strArray6 = new string[300];
                string[] result = (string[]) e.Result;
                foreach (string str in result)
                {
                    if (str == null)
                    {
                        break;
                    }
                    strArray2[index] = str;
                    strArray[index] = result[index + 0x3e8];
                    strArray3[index] = result[index + 0x7d0];
                    strArray4[index] = result[index + 0xbb8];
                    strArray5[index] = result[index + 0xfa0];
                    index++;
                }
                int num2 = 0;
                string[] strArray8 = new string[300];
                foreach (string str2 in this.VestiId)
                {
                    if (str2 == null)
                    {
                        break;
                    }
                    strArray8[num2] = "OBRISI";
                    num2++;
                }
                int num3 = 0;
                foreach (string str3 in strArray2)
                {
                    if (str3 == null)
                    {
                        break;
                    }
                    strArray6[num3] = "NEMA";
                    int num4 = 0;
                    foreach (string str4 in this.VestiId)
                    {
                        if (str4 == null)
                        {
                            break;
                        }
                        if (str3 == str4)
                        {
                            strArray8[num4] = "OK";
                            strArray6[num3] = "IMA";
                            break;
                        }
                        num4++;
                    }
                    num3++;
                }
                int num5 = 0;
                foreach (string str5 in strArray8)
                {
                    if (str5 == null)
                    {
                        break;
                    }
                    if (str5 == "OBRISI")
                    {
                        foreach (Control control in this.flowLayoutPanel1.Controls)
                        {
                            vest = new MiniVest();
                            vest = (MiniVest) control;
                            if (this.VestiId[num5] == vest.UzmiOriginalID())
                            {
                                this.flowLayoutPanel1.Controls.RemoveAt(this.flowLayoutPanel1.Controls.GetChildIndex(vest));
                                break;
                            }
                        }
                        foreach (Control control in this.flowLayoutPanel2.Controls)
                        {
                            vest = new MiniVest();
                            vest = (MiniVest) control;
                            if (this.VestiId[num5] == vest.UzmiOriginalID())
                            {
                                this.flowLayoutPanel2.Controls.RemoveAt(this.flowLayoutPanel2.Controls.GetChildIndex(vest));
                                break;
                            }
                        }
                    }
                    num5++;
                }
                int num6 = 0;
                int num7 = 0;
                foreach (string str6 in strArray6)
                {
                    switch (str6)
                    {
                        case null:
                            goto Label_0448;

                        case "NEMA":
                            this.NapraviVest(strArray2[num6], strArray[num6], 0, strArray4[num6], strArray5[num6], strArray3[num6]);
                            this.VestiId[this.PocetnoUcitavanje] = strArray2[num6];
                            this.PocetnoUcitavanje++;
                            num7++;
                            break;
                    }
                    num6++;
                }
            Label_0448:
                if (num7 != 0)
                {
                    this.Flow1stanje = 0;
                    this.Flow2stanje = 0;
                }
                foreach (Control control in this.flowLayoutPanel1.Controls)
                {
                    vest = new MiniVest();
                    vest = (MiniVest) control;
                    str7 = vest.UzmiOriginalID();
                    num8 = 0;
                    foreach (string str8 in strArray2)
                    {
                        if (str8 == null)
                        {
                            break;
                        }
                        if (str8 == str7)
                        {
                            if (strArray3[num8] != "DA")
                            {
                                this.NapraviVest(strArray2[num8], strArray[num8], 0, strArray4[num8], strArray5[num8], "NE");
                                this.flowLayoutPanel1.Controls.RemoveAt(this.flowLayoutPanel1.Controls.GetChildIndex(vest));
                            }
                            else
                            {
                                vest.PromeniNaslovVesti(strArray4[num8]);
                            }
                            break;
                        }
                        num8++;
                    }
                }
                foreach (Control control2 in this.flowLayoutPanel2.Controls)
                {
                    vest = new MiniVest();
                    vest = (MiniVest) control2;
                    str7 = vest.UzmiOriginalID();
                    num8 = 0;
                    foreach (string str8 in strArray2)
                    {
                        if (str8 == null)
                        {
                            break;
                        }
                        if (str8 == str7)
                        {
                            if (strArray3[num8] == "DA")
                            {
                                this.NapraviVest(strArray2[num8], strArray[num8], 0, strArray4[num8], strArray5[num8], "NE");
                                this.flowLayoutPanel2.Controls.RemoveAt(this.flowLayoutPanel2.Controls.GetChildIndex(vest));
                            }
                            else
                            {
                                vest.PromeniNaslovVesti(strArray4[num8]);
                            }
                            break;
                        }
                        num8++;
                    }
                }
            }
            catch (Exception exception)
            {
                this.PosaljiMail("CODE: SkidanjePodatakaVesti_RunWorkerCompleted\n\n" + exception.ToString());
            }
            Cursor.Current = Cursors.Default;
            this.Poruke.BackColor = Color.White;
            this.Poruke.Text = DateTime.Now.ToLongTimeString();
            this.SkidanjeVesti = 0;
        }

        private void SnimljeneAdminPromene_Click(object sender, EventArgs e)
        {
            new IstorijaAdminPromena().Show();
        }

        private void SrediUcitavanje()
        {
            int num = 0;
            foreach (string str in this.MKObjavljeni)
            {
                if (str == null)
                {
                    break;
                }
                num++;
            }
            if (this.NivoKorisnika.Contains("F"))
            {
                this.NovaVest.Visible = false;
                this.ObrisiVest.Visible = false;
                this.PostaviPrioritet.Visible = false;
                this.VratiPrioritet.Visible = false;
                this.AzurirajPromeniNaslov.Visible = false;
                this.SnimljeneAdminPromene.Visible = false;
            }
            this.Poruke.Visible = false;
            this.TrenutnoKorisnika.Visible = false;
            this.MiniVerzijaProzora.Visible = false;
            this.PostaviNaVrh.Visible = false;
            this.FilterZaPretragu.Visible = false;
            this.PokazivacVremenaProvera.Visible = false;
            this.progressBar1.Maximum = num;
            this.progressBar1.Value = 0;
            this.progressBar1.Visible = true;
        }

        private void StanjeKomentara_Click(object sender, EventArgs e)
        {
            try
            {
                new StanjePoslatihKomentara { MojiKomentari = this.MojiKomentari, MKVestiID = this.MKVestiID, MKObjavljeni = this.MKObjavljeni, IDVesti = this.Privremena.UzmiOriginalID(), MKNapomenaKomentara = this.MKNapomenaKomentara, MKDatumUnosaKomentara = this.MKDatumUnosaKomentara }.Show();
            }
            catch
            {
            }
        }

        private void sug_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.OsveziChat();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0)
            {
                this.flowLayoutPanel1.Focus();
            }
            else
            {
                this.flowLayoutPanel2.Focus();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.PocetniTimer.Stop();
                this.PocetniTimer.Enabled = false;
                if (this.VestiUrl[this.PrvaUcitavanja] == null)
                {
                    this.RedovnoAzuriranje.Enabled = true;
                    this.RedovnoAzuriranje.Start();
                    this.progressBar1.Visible = false;
                    this.toolTip1.SetToolTip(this.progressBar1, "Provera komentara u toku");
                    if (this.NivoKorisnika.Contains("F"))
                    {
                        this.NovaVest.Visible = true;
                        this.ObrisiVest.Visible = true;
                        this.PostaviPrioritet.Visible = true;
                        this.VratiPrioritet.Visible = true;
                        this.AzurirajPromeniNaslov.Visible = true;
                        this.SnimljeneAdminPromene.Visible = true;
                        this.AdminListe = 1;
                    }
                    this.Poruke.Visible = true;
                    this.TrenutnoKorisnika.Visible = true;
                    this.MiniVerzijaProzora.Visible = true;
                    this.PostaviNaVrh.Visible = true;
                    this.FilterZaPretragu.Visible = true;
                    this.PokazivacVremenaProvera.Visible = true;
                    this.Skraj = DateTime.Now;
                    TimeSpan span = (TimeSpan) (this.Skraj - this.Spocetak);
                    this.Poruke.Text = Math.Round((decimal) span.TotalSeconds, 2).ToString() + "s";
                    try
                    {
                        WebClient client = new WebClient();
                        string str = client.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/InsertUserOnlineStatus.php?Id=" + this.PersonalID).Replace("\r\n", "");
                        this.TrenutnoKorisnika.Text = "Korisnika: " + str;
                    }
                    catch
                    {
                    }
                    try
                    {
                        MiniVest vest;
                        string str2;
                        int num2;
                        int num3;
                        int num4;
                        string str4;
                        string str5;
                        foreach (Control control in this.flowLayoutPanel2.Controls)
                        {
                            vest = new MiniVest();
                            vest = (MiniVest) control;
                            str2 = vest.UzmiOriginalID();
                            num2 = 0;
                            num3 = 0;
                            num4 = 0;
                            foreach (string str3 in this.MKObjavljeni)
                            {
                                if (str3 == null)
                                {
                                    break;
                                }
                                if (this.MKVestiID[num2] == str2)
                                {
                                    num3++;
                                }
                                if ((this.MKVestiID[num2] == str2) && (str3 == "NE"))
                                {
                                    num4++;
                                }
                                num2++;
                            }
                            if (num3 > 0)
                            {
                                if (num4 == 0)
                                {
                                    str4 = num3.ToString() + " / " + num3.ToString();
                                    vest.ImaKomentara(2, str4);
                                }
                                else
                                {
                                    int num9 = num3 - num4;
                                    str5 = num9.ToString() + " / " + num3.ToString();
                                    vest.ImaKomentara(1, str5);
                                }
                            }
                        }
                        foreach (Control control2 in this.flowLayoutPanel1.Controls)
                        {
                            vest = new MiniVest();
                            vest = (MiniVest) control2;
                            str2 = vest.UzmiOriginalID();
                            num2 = 0;
                            num3 = 0;
                            num4 = 0;
                            foreach (string str3 in this.MKObjavljeni)
                            {
                                if (str3 == null)
                                {
                                    break;
                                }
                                if (this.MKVestiID[num2] == str2)
                                {
                                    num3++;
                                }
                                if ((this.MKVestiID[num2] == str2) && (str3 == "NE"))
                                {
                                    num4++;
                                }
                                num2++;
                            }
                            if (num3 > 0)
                            {
                                if (num4 == 0)
                                {
                                    str4 = num3.ToString() + " / " + num3.ToString();
                                    vest.ImaKomentara(2, str4);
                                }
                                else
                                {
                                    str5 = ((num3 - num4)).ToString() + " / " + num3.ToString();
                                    vest.ImaKomentara(1, str5);
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        WebClient client2 = new WebClient();
                        JsonTextReader reader = new JsonTextReader(new StringReader(client2.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/GramatickeGreske/GetAllErrors.php")));
                        int num5 = 0;
                        int index = 0;
                        while (reader.Read())
                        {
                            if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                            {
                                switch (num5)
                                {
                                    case 1:
                                        this.GGReci[index] = reader.Value.ToString();
                                        break;

                                    case 2:
                                        this.GGIspravka[index] = reader.Value.ToString();
                                        break;
                                }
                                num5++;
                                if (num5 == 3)
                                {
                                    num5 = 0;
                                    index++;
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                    base.MinimizeBox = true;
                    int height = Screen.PrimaryScreen.WorkingArea.Height;
                    base.Location = new Point(base.Location.X, 10);
                    base.Size = new Size(base.Width, height - 30);
                    try
                    {
                        this.Privremena = (MiniVest) this.flowLayoutPanel1.Controls[this.flowLayoutPanel1.Controls.Count - 1];
                        this.SelektovanNaslov.Text = this.Privremena.UzmiNaslovVesti();
                        this.SelektovanBrojKomentara.Text = "0";
                        this.SelektovanBrojKomentara.Text = this.Privremena.UzmiBrojKomentara();
                        this.Privremena.OznaciKontroluZuto();
                        this.Privremena.OsveziBrojKomentara();
                        string str7 = this.Privremena.UzmiOriginalLink();
                        if ((((str7.Contains("b92.net") || str7.Contains("blic.rs")) || (str7.Contains("kurir-info.rs") || str7.Contains("politika.rs"))) || ((str7.Contains("alo.rs") || str7.Contains("telegraf.rs")) || (str7.Contains("danas.rs") || str7.Contains("rts.rs")))) || str7.Contains("novosti.rs"))
                        {
                            if (this.PokrenutaProveraKomentara == 0)
                            {
                                this.PrijaviPoslatKomentar.Visible = true;
                                this.StanjeKomentara.Visible = true;
                            }
                        }
                        else
                        {
                            this.PrijaviPoslatKomentar.Visible = false;
                            this.StanjeKomentara.Visible = false;
                        }
                        if (this.Privremena.UzmiOriginalID() != "99999")
                        {
                            this.OsveziChat();
                        }
                        else
                        {
                            this.richTextBox1.Text = "";
                        }
                        this.ZakasneloAzuriranjeTeksta.Enabled = true;
                        this.ZakasneloAzuriranjeTeksta.Start();
                        this.DodajKomentar.Visible = true;
                        this.button1.Text = "Smernice (kako treba komentarisati)";
                        this.button1.BackColor = Color.White;
                    }
                    catch
                    {
                    }
                }
                else
                {
                    if (System.IO.File.Exists(this.putanjaFolder + @"\Vpic\" + this.VestiId[this.PrvaUcitavanja] + ".jpg"))
                    {
                        this.NapraviVest(this.VestiId[this.PrvaUcitavanja], this.VestiUrl[this.PrvaUcitavanja], 0, this.VestiNaslov[this.PrvaUcitavanja], this.putanjaFolder + @"\Vpic\" + this.VestiId[this.PrvaUcitavanja] + ".jpg", this.VestiPrioritet[this.PrvaUcitavanja]);
                        this.PocetniTimer.Interval = 250;
                    }
                    else
                    {
                        this.NapraviVest(this.VestiId[this.PrvaUcitavanja], this.VestiUrl[this.PrvaUcitavanja], 0, this.VestiNaslov[this.PrvaUcitavanja], this.VestiSlika[this.PrvaUcitavanja], this.VestiPrioritet[this.PrvaUcitavanja]);
                        this.PocetniTimer.Interval = 600;
                    }
                    this.PrvaUcitavanja++;
                    this.progressBar1.PerformStep();
                    this.PocetniTimer.Enabled = true;
                    this.PocetniTimer.Start();
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception exception)
            {
                this.PosaljiMail("CODE: timer1_Tick\n\n" + exception.ToString());
            }
        }

        private void TrenutnoKorisnika_Click(object sender, EventArgs e)
        {
            if (this.SkidanjeKorisnika == 0)
            {
                this.SkidanjeKorisnika = 1;
                this.TrenutnoKorisnika.BackColor = Color.Red;
                this.AzuriranjeBrojaKorisnika.RunWorkerAsync(this.PersonalID);
            }
        }

        private void VratiIzaProzor_Click(object sender, EventArgs e)
        {
            base.TopMost = false;
            this.VratiIzaProzor.Visible = false;
            this.PostaviNaVrh.Visible = true;
        }

        private void VratiMiniPrikaz_Click(object sender, EventArgs e)
        {
            base.Size = new Size(790, Screen.PrimaryScreen.WorkingArea.Height - 30);
            base.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - base.Size.Width, 10);
            this.MiniVerzijaProzora.Visible = true;
            this.VratiMiniPrikaz.Visible = false;
        }

        private void VratiPrioritet_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Da li želite da odabranu vest vratite na AKTUELNU grupu?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    int num = 0;
                    foreach (Control control in this.flowLayoutPanel2.Controls)
                    {
                        if (control == this.Privremena)
                        {
                            num = 1;
                        }
                    }
                    if (num == 0)
                    {
                        WebClient client = new WebClient();
                        string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/UpdateNewsPriority.php?";
                        address = (address + "Id=" + this.Privremena.UzmiOriginalID()) + "&Prioritet=NE";
                        if (client.DownloadString(address).Contains("OKET"))
                        {
                            try
                            {
                                WebClient client2 = new WebClient();
                                NameValueCollection data = new NameValueCollection();
                                data["IAMIdKorisnika"] = this.PersonalID;
                                data["IAMUrlVesti"] = this.Privremena.UzmiOriginalLink();
                                data["IAMNaslovVesti"] = this.Privremena.UzmiNaslovVesti();
                                data["IAMAkcija"] = "Izbačena VEST iz PRIORITETA";
                                client2.Encoding = Encoding.UTF8;
                                byte[] bytes = client2.UploadValues("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/InsertNewHistoryAdmin.php", "POST", data);
                                if (Encoding.UTF8.GetString(bytes).Contains("OKET"))
                                {
                                }
                            }
                            catch
                            {
                            }
                            this.NapraviVest(this.Privremena.UzmiOriginalID(), this.Privremena.UzmiOriginalLink(), 0, this.Privremena.UzmiNaslovVesti(), this.Privremena.UzmiSliku(), "NE");
                            this.flowLayoutPanel1.Controls.RemoveAt(this.flowLayoutPanel1.Controls.GetChildIndex(this.Privremena));
                            this.Flow1stanje = this.flowLayoutPanel1.Controls.Count - 1;
                            this.Flow2stanje = this.flowLayoutPanel2.Controls.Count - 1;
                        }
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Odabrana vest je već u grupi aktuelno", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Dogodila se neka greška, pokušajte ponovo ili restartujte program.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Cursor.Current = Cursors.Default;
        }

        private void VratiZabranu_Tick(object sender, EventArgs e)
        {
            this.VratiZabranu.Stop();
            this.VratiZabranu.Enabled = false;
            this.ZabraniUbacivanjeVesti = 0;
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.PerformStep();
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.PriKomeTimer = (string[]) e.Result;
            }
            catch (Exception exception)
            {
                this.PosaljiMail("CODE: worker_RunWorkerCompleted\n\n" + exception.ToString());
            }
            this.PrikazivanjeObjavljenihKomentara.Enabled = true;
            this.PrikazivanjeObjavljenihKomentara.Start();
        }

        private void WorkerDoWork(string[] Komentari, string[] Objavljen, string[] URL, DoWorkEventArgs e, object sender)
        {
            try
            {
                string[] strArray = new string[0x1f40];
                int index = 0;
                string[] strArray2 = new string[500];
                strArray2[0] = "’";
                strArray2[1] = "'";
                strArray2[2] = ",";
                strArray2[3] = "،";
                strArray2[4] = "、";
                strArray2[5] = "‒";
                strArray2[6] = "–";
                strArray2[7] = "—";
                strArray2[8] = "―";
                strArray2[9] = "…";
                strArray2[10] = ".";
                strArray2[11] = ".";
                strArray2[12] = "!";
                strArray2[13] = ".";
                strArray2[14] = "‐";
                strArray2[15] = "-";
                strArray2[0x10] = "?";
                strArray2[0x11] = "‘";
                strArray2[0x12] = "’";
                strArray2[0x13] = "“";
                strArray2[20] = "”";
                strArray2[0x15] = "'";
                strArray2[0x16] = "'";
                strArray2[0x17] = ";";
                strArray2[0x18] = "/";
                strArray2[0x19] = "⁄";
                strArray2[0x1a] = "\x00b7";
                strArray2[0x1b] = " ";
                strArray2[0x1c] = " ";
                strArray2[0x1d] = " ";
                strArray2[30] = "•";
                strArray2[0x1f] = "^";
                strArray2[0x20] = "″";
                strArray2[0x21] = "′";
                strArray2[0x22] = "″";
                strArray2[0x23] = "‴";
                strArray2[0x24] = "_";
                strArray2[0x25] = @"\";
                strArray2[0x26] = "&#8230";
                strArray2[0x27] = "…";
                strArray2[40] = "&#039";
                strArray2[0x29] = "'";
                strArray2[0x2a] = "&#8220";
                strArray2[0x2b] = "&#8221";
                strArray2[0x2c] = ".";
                strArray2[0x2d] = "\n";
                strArray2[0x2e] = " ";
                strArray2[0x2f] = "<br>";
                strArray2[0x30] = "\r";
                strArray2[0x31] = "\x00a0";
                strArray2[50] = "&#8230";
                strArray2[0x33] = "…";
                strArray2[0x34] = "&#039";
                strArray2[0x35] = "&#8217";
                strArray2[0x36] = "'";
                strArray2[0x37] = "&#8220";
                strArray2[0x38] = "&#8221";
                strArray2[0x39] = @"\";
                strArray2[0x3a] = ".";
                strArray2[0x3b] = "&#8211";
                strArray2[60] = "-";
                strArray2[0x3d] = "–";
                strArray2[0x3e] = "“";
                strArray2[0x3f] = "”";
                strArray2[0x40] = "\r";
                strArray2[0x41] = "\n";
                strArray2[0x42] = "\t";
                strArray2[0x43] = ".";
                strArray2[0x44] = "<";
                strArray2[0x45] = ">";
                strArray2[70] = "…";
                strArray2[0x47] = " ";
                strArray2[0x48] = "\x00a0";
                strArray2[0x49] = "&nbsp";
                strArray2[0x4a] = "&hellip";
                strArray2[0x4b] = "&lt";
                strArray2[0x4c] = "&amp";
                strArray2[0x4d] = "&gt";
                strArray2[0x4e] = ".";
                strArray2[0x4f] = "…";
                char[] chArray = new char[500];
                chArray[0] = '"';
                chArray[1] = '"';
                chArray[2] = '"';
                chArray[3] = '"';
                chArray[4] = '"';
                string str = "";
                Thread.Sleep(0x7d0);
                foreach (string str2 in URL)
                {
                    if (str2 == null)
                    {
                        break;
                    }
                    if (Objavljen[index] == "DA")
                    {
                        index++;
                        (sender as BackgroundWorker).ReportProgress(1);
                        Thread.Sleep(200);
                    }
                    else
                    {
                        try
                        {
                            string innerText;
                            string str6;
                            string str7;
                            string str8;
                            string str14;
                            string str15;
                            char[] chArray2;
                            int num8;
                            string str19;
                            string str32;
                            string str33;
                            string address = str2;
                            string[] strArray3 = str2.Split(new char[] { '=' });
                            string[] strArray4 = str2.Split(new char[] { '/' });
                            if (address.Contains("www.b92.net"))
                            {
                                try
                                {
                                    if (address.Contains("www.b92.net/eng/news"))
                                    {
                                        address = "http://www.b92.net/eng/news/comments.php?nav_id=" + strArray3[strArray3.Length - 1];
                                    }
                                    else
                                    {
                                        address = "http://www.b92.net/info/komentari.php?nav_id=" + strArray3[strArray3.Length - 1];
                                    }
                                }
                                catch
                                {
                                }
                            }
                            if (!(!address.Contains("www.blic.rs") || address.Contains("komentari")))
                            {
                                address = address + "/komentari#vas-komentar";
                            }
                            if (!(!address.Contains("www.kurir-info.rs") || address.Contains("komentari")))
                            {
                                address = strArray4[0] + "//" + strArray4[2] + "/komentari/" + strArray4[strArray4.Length - 1];
                                str = "/komentari/" + strArray4[strArray4.Length - 1];
                            }
                            if (!(!address.Contains("www.alo.rs") || address.Contains("komentari")))
                            {
                                address = strArray4[0] + "//" + strArray4[2] + "/" + strArray4[3] + "/" + strArray4[4] + "/" + strArray4[5] + "/komentari/" + strArray4[6];
                            }
                            if (!(!address.Contains("www.telegraf.rs/") || address.Contains("komentari")))
                            {
                                address = address + "/komentari/svi";
                            }
                            string html = "";
                            using (WebClient client = new WebClient())
                            {
                                if (address.Contains("b92.net"))
                                {
                                    client.Encoding = Encoding.GetEncoding(0x4e2);
                                }
                                else
                                {
                                    client.Encoding = Encoding.UTF8;
                                }
                                html = client.DownloadString(address);
                                client.Dispose();
                            }
                            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                            document.LoadHtml(html);
                            if (address.Contains("b92.net"))
                            {
                                try
                                {
                                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@id='tab-comments-h-tab']"))
                                    {
                                        for (int i = 0; i <= (node.ChildNodes[0].ChildNodes[3].ChildNodes.Count - 1); i++)
                                        {
                                            string[] strArray5;
                                            string str10;
                                            int num4;
                                            int num5;
                                            string[] strArray8;
                                            int num6;
                                            innerText = node.ChildNodes[0].ChildNodes[3].ChildNodes[i].InnerText;
                                            str6 = Komentari[index];
                                            str7 = str6.Substring(str6.Length - 20, 20);
                                            try
                                            {
                                                str6 = str6.Remove(30, str6.Length - 30);
                                            }
                                            catch
                                            {
                                            }
                                            str8 = innerText;
                                            str8 = str8.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                            if (str8.Contains("&#"))
                                            {
                                                strArray5 = str8.Split(new char[] { ';' });
                                                foreach (string str9 in strArray5)
                                                {
                                                    try
                                                    {
                                                        str10 = HttpUtility.HtmlDecode(str9 + ";");
                                                        str8 = str8.Replace(str9 + ";", str10);
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                            }
                                            str6 = str6.Replace("(", "");
                                            str7 = str7.Replace("(", "");
                                            foreach (char ch in chArray)
                                            {
                                                if (ch == '\0')
                                                {
                                                    break;
                                                }
                                                str8 = str8.Replace(ch, ' ');
                                                str6 = str6.Replace(ch, ' ');
                                                str7 = str7.Replace(ch, ' ');
                                            }
                                            foreach (string str11 in strArray2)
                                            {
                                                if (str11 == null)
                                                {
                                                    break;
                                                }
                                                str8 = str8.Replace(str11, "");
                                                str6 = str6.Replace(str11, "");
                                                str7 = str7.Replace(str11, "");
                                            }
                                            string[] strArray6 = str8.Split(new char[] { '(' });
                                            string[] strArray7 = new string[10];
                                            int num3 = 0;
                                            string str12 = "";
                                            foreach (string str13 in strArray6)
                                            {
                                                if (str13.Contains("Linkkomentara"))
                                                {
                                                    break;
                                                }
                                                str12 = str12 + str13;
                                                strArray7[num3] = str12;
                                                num3++;
                                            }
                                            str6 = str6.Replace(" ", "");
                                            str7 = str7.Replace(" ", "");
                                            if (str12.StartsWith(str6) && str12.EndsWith(str7))
                                            {
                                                try
                                                {
                                                    str14 = node.ChildNodes[0].ChildNodes[3].ChildNodes[i].InnerText.Replace("# Link komentara", "").Replace("&nbsp;", "").Replace("&hellip;", "").Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("Šta je ovo", "").Replace("# Comment link", "").Replace("What's this?", "");
                                                    try
                                                    {
                                                        str14 = str14.Replace("Preporučujem (0)", "");
                                                        num4 = 1;
                                                        while (num4 < 0x5dc)
                                                        {
                                                            if (str14.Contains("Preporučujem (+"))
                                                            {
                                                                str14 = str14.Replace("Preporučujem (+" + num4.ToString() + ")", "");
                                                            }
                                                            else
                                                            {
                                                                goto Label_0A8E;
                                                            }
                                                            num4++;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                    }
                                                Label_0A8E:;
                                                    try
                                                    {
                                                        str14 = str14.Replace("Ne preporučujem (0)", "");
                                                        num5 = 1;
                                                        while (num5 < 0x5dc)
                                                        {
                                                            if (str14.Contains("Ne preporučujem (-"))
                                                            {
                                                                str14 = str14.Replace("Ne preporučujem (-" + num5.ToString() + ")", "");
                                                            }
                                                            else
                                                            {
                                                                goto Label_0B07;
                                                            }
                                                            num5++;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                    }
                                                Label_0B07:;
                                                    try
                                                    {
                                                        str14 = str14.Replace("Recommend (0)", "");
                                                        num4 = 1;
                                                        while (num4 < 0x5dc)
                                                        {
                                                            if (str14.Contains("Recommend (+"))
                                                            {
                                                                str14 = str14.Replace("Recommend (+" + num4.ToString() + ")", "");
                                                            }
                                                            else
                                                            {
                                                                goto Label_0B80;
                                                            }
                                                            num4++;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                    }
                                                Label_0B80:;
                                                    try
                                                    {
                                                        str14 = str14.Replace("Poor comment (0)", "");
                                                        num5 = 1;
                                                        while (num5 < 0x5dc)
                                                        {
                                                            if (str14.Contains("Poor comment (-"))
                                                            {
                                                                str14 = str14.Replace("Poor comment (-" + num5.ToString() + ")", "");
                                                            }
                                                            else
                                                            {
                                                                goto Label_0BF9;
                                                            }
                                                            num5++;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                    }
                                                Label_0BF9:;
                                                    strArray8 = str14.Replace("\r\n", "").Split(new char[] { '(' });
                                                    str15 = "";
                                                    num6 = 0;
                                                    foreach (string str16 in strArray8)
                                                    {
                                                        if (num6 == (strArray8.Length - 1))
                                                        {
                                                            str15 = str15 + "\r\n(" + str16;
                                                        }
                                                        else
                                                        {
                                                            str15 = str15 + str16;
                                                        }
                                                        num6++;
                                                    }
                                                    if (str15.StartsWith("\t"))
                                                    {
                                                        str15 = str15.Remove(0, 1);
                                                    }
                                                    if (str15.Contains("&#"))
                                                    {
                                                        strArray5 = str15.Split(new char[] { ';' });
                                                        foreach (string str9 in strArray5)
                                                        {
                                                            try
                                                            {
                                                                str10 = HttpUtility.HtmlDecode(str9 + ";");
                                                                str15 = str15.Replace(str9 + ";", str10);
                                                            }
                                                            catch
                                                            {
                                                            }
                                                        }
                                                    }
                                                    strArray[index] = str15;
                                                    break;
                                                }
                                                catch
                                                {
                                                }
                                            }
                                            else if ((num3 > 1) && str12.StartsWith(str6))
                                            {
                                                for (int j = 0; j < 10; j++)
                                                {
                                                    if ((strArray7[j] == null) && (j > 0))
                                                    {
                                                        break;
                                                    }
                                                    foreach (char ch in chArray)
                                                    {
                                                        if (ch == '\0')
                                                        {
                                                            break;
                                                        }
                                                        strArray7[j] = strArray7[j].Replace(ch, ' ');
                                                    }
                                                    foreach (string str11 in strArray2)
                                                    {
                                                        if (str11 == null)
                                                        {
                                                            break;
                                                        }
                                                        strArray7[j] = strArray7[j].Replace(str11, "");
                                                    }
                                                    if (strArray7[j].StartsWith(str6) && strArray7[j].EndsWith(str7))
                                                    {
                                                        try
                                                        {
                                                            str14 = node.ChildNodes[0].ChildNodes[3].ChildNodes[i].InnerText.Replace("# Link komentara", "").Replace("&nbsp;", "").Replace("&hellip;", "").Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("Šta je ovo", "").Replace("# Comment link", "").Replace("What's this?", "");
                                                            try
                                                            {
                                                                str14 = str14.Replace("Preporučujem (0)", "");
                                                                num4 = 1;
                                                                while (num4 < 0x5dc)
                                                                {
                                                                    if (str14.Contains("Preporučujem (+"))
                                                                    {
                                                                        str14 = str14.Replace("Preporučujem (+" + num4.ToString() + ")", "");
                                                                    }
                                                                    else
                                                                    {
                                                                        goto Label_0FAA;
                                                                    }
                                                                    num4++;
                                                                }
                                                            }
                                                            catch
                                                            {
                                                            }
                                                        Label_0FAA:;
                                                            try
                                                            {
                                                                str14 = str14.Replace("Ne preporučujem (0)", "");
                                                                num5 = 1;
                                                                while (num5 < 0x5dc)
                                                                {
                                                                    if (str14.Contains("Ne preporučujem (-"))
                                                                    {
                                                                        str14 = str14.Replace("Ne preporučujem (-" + num5.ToString() + ")", "");
                                                                    }
                                                                    else
                                                                    {
                                                                        goto Label_1023;
                                                                    }
                                                                    num5++;
                                                                }
                                                            }
                                                            catch
                                                            {
                                                            }
                                                        Label_1023:;
                                                            try
                                                            {
                                                                str14 = str14.Replace("Recommend (0)", "");
                                                                for (num4 = 1; num4 < 0x5dc; num4++)
                                                                {
                                                                    if (str14.Contains("Recommend (+"))
                                                                    {
                                                                        str14 = str14.Replace("Recommend (+" + num4.ToString() + ")", "");
                                                                    }
                                                                    else
                                                                    {
                                                                        goto Label_109C;
                                                                    }
                                                                }
                                                            }
                                                            catch
                                                            {
                                                            }
                                                        Label_109C:;
                                                            try
                                                            {
                                                                str14 = str14.Replace("Poor comment (0)", "");
                                                                for (num5 = 1; num5 < 0x5dc; num5++)
                                                                {
                                                                    if (str14.Contains("Poor comment (-"))
                                                                    {
                                                                        str14 = str14.Replace("Poor comment (-" + num5.ToString() + ")", "");
                                                                    }
                                                                    else
                                                                    {
                                                                        goto Label_1115;
                                                                    }
                                                                }
                                                            }
                                                            catch
                                                            {
                                                            }
                                                        Label_1115:;
                                                            strArray8 = str14.Replace("\r\n", "").Split(new char[] { '(' });
                                                            str15 = "";
                                                            num6 = 0;
                                                            foreach (string str16 in strArray8)
                                                            {
                                                                if (num6 == (strArray8.Length - 1))
                                                                {
                                                                    str15 = str15 + "\r\n(" + str16;
                                                                }
                                                                else
                                                                {
                                                                    str15 = str15 + str16;
                                                                }
                                                                num6++;
                                                            }
                                                            if (str15.StartsWith("\t"))
                                                            {
                                                                str15 = str15.Remove(0, 1);
                                                            }
                                                            if (str15.Contains("&#"))
                                                            {
                                                                strArray5 = str15.Split(new char[] { ';' });
                                                                foreach (string str9 in strArray5)
                                                                {
                                                                    try
                                                                    {
                                                                        str10 = HttpUtility.HtmlDecode(str9 + ";");
                                                                        str15 = str15.Replace(str9 + ";", str10);
                                                                    }
                                                                    catch
                                                                    {
                                                                    }
                                                                }
                                                            }
                                                            strArray[index] = str15;
                                                            break;
                                                        }
                                                        catch
                                                        {
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                catch
                                {
                                }
                            }
                            if (address.Contains("blic.rs"))
                            {
                                try
                                {
                                    string str17 = "";
                                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='comm_text']"))
                                    {
                                        innerText = node.InnerText;
                                        str6 = Komentari[index];
                                        str7 = str6.Substring(str6.Length - 20, 20);
                                        innerText = innerText.Replace("&quot;", "");
                                        try
                                        {
                                            str6 = str6.Remove(30, str6.Length - 30);
                                        }
                                        catch
                                        {
                                        }
                                        if (innerText.StartsWith("@"))
                                        {
                                            chArray2 = innerText.ToCharArray();
                                            num8 = 0;
                                            foreach (char ch2 in chArray2)
                                            {
                                                if (ch2 == ':')
                                                {
                                                    innerText = innerText.Remove(0, num8 + 2);
                                                    str17 = "BLICODGOVOR";
                                                    break;
                                                }
                                                num8++;
                                            }
                                        }
                                        foreach (char ch in chArray)
                                        {
                                            if (ch == '\0')
                                            {
                                                break;
                                            }
                                            innerText = innerText.Replace(ch, ' ');
                                            str6 = str6.Replace(ch, ' ');
                                            str7 = str7.Replace(ch, ' ');
                                        }
                                        foreach (string str11 in strArray2)
                                        {
                                            if (str11 == null)
                                            {
                                                break;
                                            }
                                            innerText = innerText.Replace(str11, "");
                                            str6 = str6.Replace(str11, "");
                                            str7 = str7.Replace(str11, "");
                                        }
                                        innerText = innerText.Replace("&#039;", "");
                                        str6 = str6.Replace("'", "");
                                        str7 = str7.Replace("'", "");
                                        innerText = innerText.Replace('"', ' ');
                                        str6 = str6.Replace('"', ' ');
                                        str7 = str7.Replace('"', ' ');
                                        innerText = innerText.Replace(@"\", "");
                                        str6 = str6.Replace(@"\", "");
                                        str7 = str7.Replace(@"\", "");
                                        innerText = innerText.Replace("&sbquo;", "").Replace(',', ' ');
                                        str6 = str6.Replace(',', ' ');
                                        str7 = str7.Replace(',', ' ');
                                        innerText = innerText.Replace('‚', ' ');
                                        str6 = str6.Replace('‚', ' ');
                                        str7 = str7.Replace('‚', ' ');
                                        innerText = innerText.Replace("&ldquo;", "").Replace("“", "");
                                        str6 = str6.Replace("“", "");
                                        str7 = str7.Replace("“", "");
                                        innerText = innerText.Replace("“", "");
                                        str6 = str6.Replace("“", "");
                                        str7 = str7.Replace("“", "");
                                        innerText = innerText.Replace(" ", "");
                                        str6 = str6.Replace(" ", "");
                                        str7 = str7.Replace(" ", "");
                                        if ((innerText.Contains(str6) && innerText.StartsWith(str6)) && innerText.EndsWith(str7))
                                        {
                                            str15 = "";
                                            try
                                            {
                                                string str18 = node.InnerText.Replace("&quot;", "").Replace("&sbquo;", ",").Replace("&ldquo;", ",");
                                                if (node.ParentNode.ChildNodes[3].ChildNodes[3].ChildNodes[1].InnerHtml != "")
                                                {
                                                    str15 = node.ParentNode.ChildNodes[3].ChildNodes[3].ChildNodes[1].InnerHtml + "\r\n" + node.ParentNode.ChildNodes[3].ChildNodes[3].ChildNodes[4].InnerHtml + "\r\n" + node.ParentNode.ChildNodes[3].ChildNodes[3].ChildNodes[7].InnerHtml + "\r\n" + str18;
                                                }
                                                else
                                                {
                                                    str15 = node.ParentNode.ChildNodes[3].ChildNodes[3].ChildNodes[3].InnerHtml + "\r\n" + node.ParentNode.ChildNodes[3].ChildNodes[3].ChildNodes[6].InnerHtml + "\r\n" + node.ParentNode.ChildNodes[3].ChildNodes[3].ChildNodes[9].InnerHtml + "\r\n" + str18;
                                                }
                                                strArray[index] = str15 + str17;
                                                goto Label_1BEB;
                                            }
                                            catch
                                            {
                                                try
                                                {
                                                    if (node.ParentNode.ChildNodes[3].ChildNodes[5].ChildNodes[1].InnerHtml != "")
                                                    {
                                                        if (node.ParentNode.ChildNodes[3].ChildNodes[5].ChildNodes[1].InnerHtml.Contains("<span class="))
                                                        {
                                                            str15 = node.ParentNode.ChildNodes[3].ChildNodes[5].ChildNodes[1].InnerText + "\r\n" + node.ParentNode.ChildNodes[3].ChildNodes[5].ChildNodes[4].InnerHtml + "\r\n" + node.ParentNode.ChildNodes[5].InnerText;
                                                        }
                                                        else
                                                        {
                                                            str15 = node.ParentNode.ChildNodes[3].ChildNodes[5].ChildNodes[1].InnerHtml + "\r\n" + node.ParentNode.ChildNodes[3].ChildNodes[5].ChildNodes[4].InnerHtml + "\r\n" + node.ParentNode.ChildNodes[5].InnerText;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        str15 = node.ParentNode.ChildNodes[3].ChildNodes[5].ChildNodes[3].InnerHtml + "\r\n" + node.ParentNode.ChildNodes[3].ChildNodes[5].ChildNodes[6].InnerHtml + "\r\n" + node.ParentNode.ChildNodes[5].InnerText;
                                                    }
                                                    str15 = str15.Replace("&quot;", "").Replace("&sbquo;", ",").Replace("&ldquo;", ",");
                                                    strArray[index] = str15 + str17;
                                                    goto Label_1BEB;
                                                }
                                                catch
                                                {
                                                }
                                            }
                                        }
                                    }
                                }
                                catch
                                {
                                }
                            }
                        Label_1BEB:
                            if (address.Contains("kurir-info"))
                            {
                                try
                                {
                                    string str20;
                                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//p[@itemprop='commentText']"))
                                    {
                                        innerText = node.InnerText;
                                        str6 = Komentari[index];
                                        str7 = str6.Substring(str6.Length - 20, 20);
                                        try
                                        {
                                            str6 = str6.Remove(30, str6.Length - 30);
                                        }
                                        catch
                                        {
                                        }
                                        str8 = innerText;
                                        str8 = str8.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                        str6 = str6.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                        str7 = str7.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                        str8 = str8.Replace(" ", "");
                                        str6 = str6.Replace(" ", "");
                                        str7 = str7.Replace(" ", "");
                                        if (str8.StartsWith(str6) && str8.EndsWith(str7))
                                        {
                                            try
                                            {
                                                str14 = node.InnerText;
                                                str19 = node.ParentNode.ChildNodes[1].InnerText;
                                                str20 = node.ParentNode.ChildNodes[3].InnerText;
                                                str14 = str14.Replace("\r\n", "");
                                                strArray[index] = str20 + "\r\n" + str19 + "\r\n" + str14;
                                                break;
                                            }
                                            catch
                                            {
                                            }
                                        }
                                    }
                                    try
                                    {
                                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//a[@href='" + str + "?page=2']"))
                                        {
                                            string str21;
                                            if (node.InnerHtml.Contains("stranica"))
                                            {
                                                continue;
                                            }
                                            using (WebClient client2 = new WebClient())
                                            {
                                                client2.Encoding = Encoding.UTF8;
                                                str21 = client2.DownloadString(address + "?page=2");
                                                client2.Dispose();
                                            }
                                            HtmlAgilityPack.HtmlDocument document2 = new HtmlAgilityPack.HtmlDocument();
                                            document2.LoadHtml(str21);
                                            foreach (HtmlNode node2 in (IEnumerable<HtmlNode>) document2.DocumentNode.SelectNodes("//p[@itemprop='commentText']"))
                                            {
                                                innerText = node2.InnerText;
                                                str6 = Komentari[index];
                                                str7 = str6.Substring(str6.Length - 20, 20);
                                                try
                                                {
                                                    str6 = str6.Remove(30, str6.Length - 30);
                                                }
                                                catch
                                                {
                                                }
                                                str8 = innerText;
                                                str8 = str8.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                                str6 = str6.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                                str7 = str7.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                                str8 = str8.Replace(" ", "");
                                                str6 = str6.Replace(" ", "");
                                                str7 = str7.Replace(" ", "");
                                                if (str8.StartsWith(str6) && str8.EndsWith(str7))
                                                {
                                                    try
                                                    {
                                                        str14 = node2.InnerText;
                                                        str19 = node2.ParentNode.ChildNodes[1].InnerText;
                                                        str20 = node2.ParentNode.ChildNodes[3].InnerText;
                                                        str14 = str14.Replace("\r\n", "");
                                                        strArray[index] = str20 + "\r\n" + str19 + "\r\n" + str14;
                                                        break;
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                            }
                                            try
                                            {
                                                foreach (HtmlNode node3 in (IEnumerable<HtmlNode>) document2.DocumentNode.SelectNodes("//a[@href='" + str + "?page=3']"))
                                                {
                                                    string str22;
                                                    if (node3.InnerHtml.Contains("stranica"))
                                                    {
                                                        continue;
                                                    }
                                                    using (WebClient client3 = new WebClient())
                                                    {
                                                        client3.Encoding = Encoding.UTF8;
                                                        str22 = client3.DownloadString(address + "?page=3");
                                                        client3.Dispose();
                                                    }
                                                    HtmlAgilityPack.HtmlDocument document3 = new HtmlAgilityPack.HtmlDocument();
                                                    document3.LoadHtml(str22);
                                                    foreach (HtmlNode node4 in (IEnumerable<HtmlNode>) document3.DocumentNode.SelectNodes("//p[@itemprop='commentText']"))
                                                    {
                                                        innerText = node4.InnerText;
                                                        str6 = Komentari[index];
                                                        str7 = str6.Substring(str6.Length - 20, 20);
                                                        try
                                                        {
                                                            str6 = str6.Remove(30, str6.Length - 30);
                                                        }
                                                        catch
                                                        {
                                                        }
                                                        str8 = innerText;
                                                        str8 = str8.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                                        str6 = str6.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                                        str7 = str7.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                                        str8 = str8.Replace(" ", "");
                                                        str6 = str6.Replace(" ", "");
                                                        str7 = str7.Replace(" ", "");
                                                        if (str8.StartsWith(str6) && str8.EndsWith(str7))
                                                        {
                                                            try
                                                            {
                                                                str14 = node4.InnerText;
                                                                str19 = node4.ParentNode.ChildNodes[1].InnerText;
                                                                str20 = node4.ParentNode.ChildNodes[3].InnerText;
                                                                str14 = str14.Replace("\r\n", "");
                                                                strArray[index] = str20 + "\r\n" + str19 + "\r\n" + str14;
                                                                break;
                                                            }
                                                            catch
                                                            {
                                                            }
                                                        }
                                                    }
                                                    try
                                                    {
                                                        foreach (HtmlNode node5 in (IEnumerable<HtmlNode>) document3.DocumentNode.SelectNodes("//a[@href='" + str + "?page=4']"))
                                                        {
                                                            if (!node5.InnerHtml.Contains("stranica"))
                                                            {
                                                                string str23;
                                                                using (WebClient client4 = new WebClient())
                                                                {
                                                                    client4.Encoding = Encoding.UTF8;
                                                                    str23 = client4.DownloadString(address + "?page=4");
                                                                    client4.Dispose();
                                                                }
                                                                HtmlAgilityPack.HtmlDocument document4 = new HtmlAgilityPack.HtmlDocument();
                                                                document4.LoadHtml(str23);
                                                                foreach (HtmlNode node6 in (IEnumerable<HtmlNode>) document4.DocumentNode.SelectNodes("//p[@itemprop='commentText']"))
                                                                {
                                                                    innerText = node6.InnerText;
                                                                    str6 = Komentari[index];
                                                                    str7 = str6.Substring(str6.Length - 20, 20);
                                                                    try
                                                                    {
                                                                        str6 = str6.Remove(30, str6.Length - 30);
                                                                    }
                                                                    catch
                                                                    {
                                                                    }
                                                                    str8 = innerText;
                                                                    str8 = str8.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                                                    str6 = str6.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                                                    str7 = str7.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                                                    str8 = str8.Replace(" ", "");
                                                                    str6 = str6.Replace(" ", "");
                                                                    str7 = str7.Replace(" ", "");
                                                                    if (str8.StartsWith(str6) && str8.EndsWith(str7))
                                                                    {
                                                                        try
                                                                        {
                                                                            str14 = node6.InnerText;
                                                                            str19 = node6.ParentNode.ChildNodes[1].InnerText;
                                                                            str20 = node6.ParentNode.ChildNodes[3].InnerText;
                                                                            str14 = str14.Replace("\r\n", "");
                                                                            strArray[index] = str20 + "\r\n" + str19 + "\r\n" + str14;
                                                                            break;
                                                                        }
                                                                        catch
                                                                        {
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                            }
                                            catch
                                            {
                                            }
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                                catch
                                {
                                }
                            }
                            if (address.Contains("politika.rs"))
                            {
                                try
                                {
                                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//li[@class='comments']"))
                                    {
                                        string[] strArray9 = node.InnerHtml.Split(new char[] { '"' });
                                        foreach (string str24 in strArray9)
                                        {
                                            string str25 = str24.Replace("amp;", "").Replace("new_review", "list_reviews");
                                            if (str25.Contains("politika.rs"))
                                            {
                                                string str26 = "";
                                                using (WebClient client5 = new WebClient())
                                                {
                                                    client5.Encoding = Encoding.UTF8;
                                                    str26 = client5.DownloadString(str25);
                                                    client5.Dispose();
                                                }
                                                HtmlAgilityPack.HtmlDocument document5 = new HtmlAgilityPack.HtmlDocument();
                                                document5.LoadHtml(str26);
                                                foreach (HtmlNode node7 in (IEnumerable<HtmlNode>) document5.DocumentNode.SelectNodes("//div[@class='review']"))
                                                {
                                                    string str27 = node7.ChildNodes[3].InnerText;
                                                    string str28 = Komentari[index];
                                                    string str29 = str28.Remove(20, str28.Length - 20);
                                                    str7 = str28.Substring(str28.Length - 20, 20);
                                                    str29 = str29.Replace(" ", "");
                                                    str7 = str7.Replace(" ", "");
                                                    str27 = str27.Replace(" ", "");
                                                    str29 = str29.Replace("\n", "");
                                                    str7 = str7.Replace("\n", "");
                                                    str27 = str27.Replace("\n", "");
                                                    str29 = str29.Replace("\r", "");
                                                    str7 = str7.Replace("\r", "");
                                                    str27 = str27.Replace("\r", "");
                                                    str29 = str29.Replace("\t", "");
                                                    str7 = str7.Replace("\t", "");
                                                    str27 = str27.Replace("\t", "");
                                                    str29 = str29.Replace("&quot;", "");
                                                    str7 = str7.Replace("&quot;", "");
                                                    str27 = str27.Replace("&quot;", "");
                                                    str29 = str29.Replace(".", "");
                                                    str7 = str7.Replace(".", "");
                                                    str27 = str27.Replace(".", "");
                                                    str29 = str29.Replace("\"", "");
                                                    str7 = str7.Replace("\"", "");
                                                    str27 = str27.Replace("\"", "");
                                                    if (str27.StartsWith(str29) && str27.EndsWith(str7))
                                                    {
                                                        string str30 = node7.ChildNodes[1].InnerText.Replace("&nbsp;", " ");
                                                        string str31 = node7.ChildNodes[3].InnerText.Replace("&quot;", "");
                                                        strArray[index] = str30 + "\r\n" + str31;
                                                        break;
                                                    }
                                                }
                                                break;
                                            }
                                        }
                                    }
                                }
                                catch
                                {
                                }
                            }
                            if (address.Contains("alo.rs"))
                            {
                                try
                                {
                                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//p[@class='CommentListComment']"))
                                    {
                                        innerText = node.InnerText;
                                        str6 = Komentari[index];
                                        str7 = str6.Substring(str6.Length - 20, 20);
                                        innerText = innerText.Replace("&quot;", "");
                                        try
                                        {
                                            str6 = str6.Remove(30, str6.Length - 30);
                                        }
                                        catch
                                        {
                                        }
                                        if (innerText.StartsWith("@"))
                                        {
                                            chArray2 = innerText.ToCharArray();
                                            num8 = 0;
                                            foreach (char ch2 in chArray2)
                                            {
                                                if (ch2 == ':')
                                                {
                                                    innerText = innerText.Remove(0, num8 + 2);
                                                    break;
                                                }
                                                num8++;
                                            }
                                        }
                                        innerText = innerText.Replace("&#039;", "");
                                        str6 = str6.Replace("'", "");
                                        str7 = str7.Replace("'", "");
                                        innerText = innerText.Replace('"', ' ');
                                        str6 = str6.Replace('"', ' ');
                                        str7 = str7.Replace('"', ' ');
                                        innerText = innerText.Replace(@"\", "");
                                        str6 = str6.Replace(@"\", "");
                                        str7 = str7.Replace(@"\", "");
                                        innerText = innerText.Replace(" ", "");
                                        str6 = str6.Replace(" ", "");
                                        str7 = str7.Replace(" ", "");
                                        innerText = innerText.Replace("*", "");
                                        str6 = str6.Replace("*", "");
                                        str7 = str7.Replace("*", "");
                                        innerText = innerText.Replace("\n", "");
                                        str6 = str6.Replace("\n", "");
                                        str7 = str7.Replace("\n", "");
                                        innerText = innerText.Replace("\r", "");
                                        str6 = str6.Replace("\r", "");
                                        str7 = str7.Replace("\r", "");
                                        innerText = innerText.Replace("\t", "");
                                        str6 = str6.Replace("\t", "");
                                        str7 = str7.Replace("\t", "");
                                        if ((innerText.Contains(str6) && innerText.StartsWith(str6)) && innerText.EndsWith(str7))
                                        {
                                            str32 = node.PreviousSibling.PreviousSibling.ChildNodes[0].InnerText.Replace("\r\n", "");
                                            str19 = node.PreviousSibling.PreviousSibling.ChildNodes[1].InnerText;
                                            strArray[index] = str32 + "  " + str19 + "\r\n" + node.InnerText;
                                            goto Label_2EF8;
                                        }
                                    }
                                }
                                catch
                                {
                                }
                            }
                        Label_2EF8:
                            if (address.Contains("telegraf.rs"))
                            {
                                try
                                {
                                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//time"))
                                    {
                                        innerText = "";
                                        int num9 = 0;
                                        while (num9 < node.ParentNode.ChildNodes.Count)
                                        {
                                            if (!(!(node.ParentNode.ChildNodes[num9].Name == "p") || node.ParentNode.ChildNodes[num9].InnerText.Contains("@")))
                                            {
                                                innerText = innerText + node.ParentNode.ChildNodes[num9].InnerText;
                                            }
                                            num9++;
                                        }
                                        str6 = Komentari[index];
                                        str7 = str6.Substring(str6.Length - 20, 20);
                                        innerText = innerText.Replace("&quot;", "");
                                        try
                                        {
                                            str6 = str6.Remove(30, str6.Length - 30);
                                        }
                                        catch
                                        {
                                        }
                                        if (innerText.StartsWith("@"))
                                        {
                                            chArray2 = innerText.ToCharArray();
                                            num8 = 0;
                                            foreach (char ch2 in chArray2)
                                            {
                                                if (ch2 == ':')
                                                {
                                                    innerText = innerText.Remove(0, num8 + 2);
                                                    break;
                                                }
                                                num8++;
                                            }
                                        }
                                        foreach (char ch in chArray)
                                        {
                                            if (ch == '\0')
                                            {
                                                break;
                                            }
                                            innerText = innerText.Replace(ch, ' ');
                                            str6 = str6.Replace(ch, ' ');
                                            str7 = str7.Replace(ch, ' ');
                                        }
                                        foreach (string str11 in strArray2)
                                        {
                                            if (str11 == null)
                                            {
                                                break;
                                            }
                                            innerText = innerText.Replace(str11, "");
                                            str6 = str6.Replace(str11, "");
                                            str7 = str7.Replace(str11, "");
                                        }
                                        if ((innerText.Contains(str6) && innerText.StartsWith(str6)) && innerText.EndsWith(str7))
                                        {
                                            str32 = node.ParentNode.ChildNodes[1].InnerText;
                                            str19 = node.ParentNode.ChildNodes[3].InnerText;
                                            str33 = "";
                                            for (num9 = 0; num9 < node.ParentNode.ChildNodes.Count; num9++)
                                            {
                                                if (!(!(node.ParentNode.ChildNodes[num9].Name == "p") || node.ParentNode.ChildNodes[num9].InnerText.Contains("@")))
                                                {
                                                    str33 = str33 + node.ParentNode.ChildNodes[num9].InnerText;
                                                }
                                            }
                                            str33 = str33.Replace("&#8221;", "").Replace("&#8230;", "…").Replace("&#8220;", "").Replace("&#8211;", "").Replace("&#8217;", "");
                                            strArray[index] = str32 + "  " + str19 + "\r\n" + str33;
                                            goto Label_332D;
                                        }
                                    }
                                }
                                catch
                                {
                                }
                            }
                        Label_332D:
                            if (address.Contains("rts.rs"))
                            {
                                try
                                {
                                    string innerHtml;
                                    int num10 = 0;
                                    try
                                    {
                                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='comEven test last']"))
                                        {
                                            num10++;
                                        }
                                    }
                                    catch
                                    {
                                        num10 = 1;
                                    }
                                    if (num10 == 1)
                                    {
                                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//table[@class='commentHead']"))
                                        {
                                            innerText = node.NextSibling.NextSibling.NextSibling.NextSibling.InnerHtml;
                                            str6 = Komentari[index];
                                            str7 = str6.Substring(str6.Length - 20, 20);
                                            innerText = innerText.Replace("&quot;", "");
                                            try
                                            {
                                                str6 = str6.Remove(30, str6.Length - 30);
                                            }
                                            catch
                                            {
                                            }
                                            if (innerText.StartsWith("@"))
                                            {
                                                chArray2 = innerText.ToCharArray();
                                                num8 = 0;
                                                foreach (char ch2 in chArray2)
                                                {
                                                    if (ch2 == ':')
                                                    {
                                                        innerText = innerText.Remove(0, num8 + 2);
                                                        break;
                                                    }
                                                    num8++;
                                                }
                                            }
                                            foreach (char ch in chArray)
                                            {
                                                if (ch == '\0')
                                                {
                                                    break;
                                                }
                                                innerText = innerText.Replace(ch, ' ');
                                                str6 = str6.Replace(ch, ' ');
                                                str7 = str7.Replace(ch, ' ');
                                            }
                                            foreach (string str11 in strArray2)
                                            {
                                                if (str11 == null)
                                                {
                                                    break;
                                                }
                                                innerText = innerText.Replace(str11, "");
                                                str6 = str6.Replace(str11, "");
                                                str7 = str7.Replace(str11, "");
                                            }
                                            if ((innerText.Contains(str6) && innerText.StartsWith(str6)) && innerText.EndsWith(str7))
                                            {
                                                innerHtml = node.NextSibling.NextSibling.InnerHtml;
                                                str32 = node.ChildNodes[1].ChildNodes[1].ChildNodes[2].InnerHtml.Replace(" ", "").Replace("\r", "").Replace("\n", "");
                                                str19 = node.ChildNodes[1].ChildNodes[1].ChildNodes[0].InnerHtml.Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("&nbsp;", "");
                                                str33 = node.NextSibling.NextSibling.NextSibling.NextSibling.InnerHtml.Replace("&#8221;", "").Replace("&#8230;", "…").Replace("&#8220;", "").Replace("<br>", "");
                                                strArray[index] = str32 + "  " + str19 + "\r\n" + innerHtml + "\r\n" + str33;
                                                goto Label_3C41;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        address = strArray4[0] + "//" + strArray4[2] + "/" + strArray4[3] + "/" + strArray4[4] + "/" + strArray4[5] + "/comments/" + strArray4[7] + "/" + strArray4[8] + "/" + strArray4[9] + "/" + strArray4[10];
                                        string str35 = "";
                                        using (WebClient client6 = new WebClient())
                                        {
                                            client6.Encoding = Encoding.UTF8;
                                            str35 = client6.DownloadString(address);
                                            client6.Dispose();
                                        }
                                        HtmlAgilityPack.HtmlDocument document6 = new HtmlAgilityPack.HtmlDocument();
                                        document6.LoadHtml(str35);
                                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document6.DocumentNode.SelectNodes("//table[@class='commentHead']"))
                                        {
                                            innerText = node.NextSibling.NextSibling.NextSibling.NextSibling.InnerHtml;
                                            str6 = Komentari[index];
                                            str7 = str6.Substring(str6.Length - 20, 20);
                                            innerText = innerText.Replace("&quot;", "");
                                            try
                                            {
                                                str6 = str6.Remove(30, str6.Length - 30);
                                            }
                                            catch
                                            {
                                            }
                                            if (innerText.StartsWith("@"))
                                            {
                                                chArray2 = innerText.ToCharArray();
                                                num8 = 0;
                                                foreach (char ch2 in chArray2)
                                                {
                                                    if (ch2 == ':')
                                                    {
                                                        innerText = innerText.Remove(0, num8 + 2);
                                                        break;
                                                    }
                                                    num8++;
                                                }
                                            }
                                            foreach (char ch in chArray)
                                            {
                                                if (ch == '\0')
                                                {
                                                    break;
                                                }
                                                innerText = innerText.Replace(ch, ' ');
                                                str6 = str6.Replace(ch, ' ');
                                                str7 = str7.Replace(ch, ' ');
                                            }
                                            foreach (string str11 in strArray2)
                                            {
                                                if (str11 == null)
                                                {
                                                    break;
                                                }
                                                innerText = innerText.Replace(str11, "");
                                                str6 = str6.Replace(str11, "");
                                                str7 = str7.Replace(str11, "");
                                            }
                                            if ((innerText.Contains(str6) && innerText.StartsWith(str6)) && innerText.EndsWith(str7))
                                            {
                                                innerHtml = node.NextSibling.NextSibling.InnerHtml;
                                                str32 = node.ChildNodes[1].ChildNodes[1].ChildNodes[2].InnerHtml.Replace(" ", "").Replace("\r", "").Replace("\n", "");
                                                str19 = node.ChildNodes[1].ChildNodes[1].ChildNodes[0].InnerHtml.Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("&nbsp;", "");
                                                str33 = node.NextSibling.NextSibling.NextSibling.NextSibling.InnerHtml.Replace("&#8221;", "").Replace("&#8230;", "…").Replace("&#8220;", "").Replace("<br>", "");
                                                strArray[index] = str32 + "  " + str19 + "\r\n" + innerHtml + "\r\n" + str33;
                                                goto Label_3C41;
                                            }
                                        }
                                    }
                                }
                                catch
                                {
                                }
                            }
                        Label_3C41:
                            if (address.Contains("novosti.rs"))
                            {
                                try
                                {
                                    NameValueCollection data = new NameValueCollection();
                                    string str36 = "";
                                    str36 = address.Split(new char[] { ':' })[2].Substring(0, 6);
                                    data["async"] = "true";
                                    data["item_id"] = str36;
                                    data["type"] = "article";
                                    data["order"] = "time";
                                    data["offset"] = "0";
                                    data["limit"] = "900";
                                    string str37 = "http://www.novosti.rs/php/comments/list.php";
                                    byte[] bytes = new WebClient().UploadValues(str37, "POST", data);
                                    string str38 = Encoding.UTF8.GetString(bytes);
                                    HtmlAgilityPack.HtmlDocument document7 = new HtmlAgilityPack.HtmlDocument();
                                    document7.LoadHtml(str38);
                                    foreach (HtmlNode node8 in (IEnumerable<HtmlNode>) document7.DocumentNode.SelectNodes("//div[@class='commentInfo']"))
                                    {
                                        innerText = node8.NextSibling.NextSibling.InnerHtml;
                                        str6 = Komentari[index];
                                        str7 = str6.Substring(str6.Length - 20, 20);
                                        innerText = innerText.Replace("&quot;", "");
                                        try
                                        {
                                            str6 = str6.Remove(30, str6.Length - 30);
                                        }
                                        catch
                                        {
                                        }
                                        innerText = innerText.Replace("&#039;", "").Replace("'", "");
                                        str6 = str6.Replace("'", "");
                                        str7 = str7.Replace("'", "");
                                        innerText = innerText.Replace('"', ' ');
                                        str6 = str6.Replace('"', ' ');
                                        str7 = str7.Replace('"', ' ');
                                        innerText = innerText.Replace(@"\", "");
                                        str6 = str6.Replace(@"\", "");
                                        str7 = str7.Replace(@"\", "");
                                        innerText = innerText.Replace(" ", "");
                                        str6 = str6.Replace(" ", "");
                                        str7 = str7.Replace(" ", "");
                                        innerText = innerText.Replace("*", "");
                                        str6 = str6.Replace("*", "");
                                        str7 = str7.Replace("*", "");
                                        innerText = innerText.Replace("\n", "");
                                        str6 = str6.Replace("\n", "");
                                        str7 = str7.Replace("\n", "");
                                        innerText = innerText.Replace("\r", "");
                                        str6 = str6.Replace("\r", "");
                                        str7 = str7.Replace("\r", "");
                                        innerText = innerText.Replace("\t", "");
                                        str6 = str6.Replace("\t", "");
                                        str7 = str7.Replace("\t", "");
                                        innerText = innerText.Replace("</p>", "").Replace("<p>", "");
                                        if ((innerText.Contains(str6) && innerText.StartsWith(str6)) && innerText.EndsWith(str7))
                                        {
                                            str32 = node8.ChildNodes[1].InnerHtml;
                                            str19 = node8.ChildNodes[2].InnerHtml;
                                            string str39 = node8.NextSibling.NextSibling.InnerHtml.Replace("</p>", "").Replace("<p>", "");
                                            strArray[index] = str32 + "  " + str19 + "\r\n" + str39;
                                            goto Label_40A7;
                                        }
                                    }
                                }
                                catch
                                {
                                }
                            }
                        Label_40A7:
                            if (address.Contains("danas.rs"))
                            {
                                try
                                {
                                    WebClient client8 = new WebClient();
                                    string str40 = client8.DownloadString(address);
                                    string str41 = "";
                                    str41 = address.Split(new char[] { '=' })[1];
                                    WebClient client9 = new WebClient();
                                    string str42 = client8.ResponseHeaders.GetValues("Set-Cookie").GetValue(0).ToString();
                                    client9.Headers.Set(HttpRequestHeader.Cookie, str42);
                                    client9.Encoding = Encoding.UTF8;
                                    string str43 = client9.DownloadString("http://www.danas.rs/asp/news/comment_ajax.asp?news_type=0&news_id=" + str41 + "&all_comments=1");
                                    HtmlAgilityPack.HtmlDocument document8 = new HtmlAgilityPack.HtmlDocument();
                                    document8.LoadHtml(str43);
                                    foreach (HtmlNode node9 in (IEnumerable<HtmlNode>) document8.DocumentNode.SelectNodes("//p[@class='autorKomentara']"))
                                    {
                                        innerText = node9.NextSibling.NextSibling.NextSibling.NextSibling.InnerHtml;
                                        str6 = Komentari[index];
                                        str7 = str6.Substring(str6.Length - 20, 20);
                                        innerText = innerText.Replace("&quot;", "");
                                        try
                                        {
                                            str6 = str6.Remove(30, str6.Length - 30);
                                        }
                                        catch
                                        {
                                        }
                                        innerText = innerText.Replace("&#8230;", "").Replace("…", "");
                                        str6 = str6.Replace("…", "");
                                        str7 = str7.Replace("…", "");
                                        innerText = innerText.Replace("&#039;", "").Replace("'", "");
                                        str6 = str6.Replace("'", "");
                                        str7 = str7.Replace("'", "");
                                        innerText = innerText.Replace("&#8220;", "").Replace("&#8221;", "").Replace('"', ' ');
                                        str6 = str6.Replace('"', ' ');
                                        str7 = str7.Replace('"', ' ');
                                        innerText = innerText.Replace(@"\", "");
                                        str6 = str6.Replace(@"\", "");
                                        str7 = str7.Replace(@"\", "");
                                        innerText = innerText.Replace(".", "");
                                        str6 = str6.Replace(".", "");
                                        str7 = str7.Replace(".", "");
                                        innerText = innerText.Replace(" ", "");
                                        str6 = str6.Replace(" ", "");
                                        str7 = str7.Replace(" ", "");
                                        innerText = innerText.Replace("\n", "");
                                        str6 = str6.Replace("\n", "");
                                        str7 = str7.Replace("\n", "");
                                        innerText = innerText.Replace("\r", "");
                                        str6 = str6.Replace("\r", "");
                                        str7 = str7.Replace("\r", "");
                                        innerText = innerText.Replace("\t", "");
                                        str6 = str6.Replace("\t", "");
                                        str7 = str7.Replace("\t", "");
                                        innerText = innerText.Replace("<br>", "");
                                        str6 = str6.Replace("<br>", "");
                                        str7 = str7.Replace("<br>", "");
                                        if ((innerText.Contains(str6) && innerText.StartsWith(str6)) && innerText.EndsWith(str7))
                                        {
                                            str32 = node9.ChildNodes[1].InnerHtml;
                                            str19 = node9.ChildNodes[2].InnerHtml.Replace("|", "").Replace(" ", "");
                                            str33 = node9.NextSibling.NextSibling.NextSibling.NextSibling.InnerHtml.Replace("&#8221;", "").Replace("&#8230;", "…").Replace("&#8220;", "").Replace("<br>", "").Replace("\n", "").Replace("\r", "").Replace("\t", "");
                                            strArray[index] = str32 + "  " + str19 + "\r\n" + str33;
                                            goto Label_45F5;
                                        }
                                    }
                                }
                                catch
                                {
                                }
                            }
                        Label_45F5:
                            Thread.Sleep(0x7d0);
                        }
                        catch
                        {
                        }
                        index++;
                        (sender as BackgroundWorker).ReportProgress(1);
                    }
                }
                e.Result = strArray;
            }
            catch
            {
            }
        }

        private void ZakasneloAzuriranjeTeksta_Tick(object sender, EventArgs e)
        {
            this.ZakasneloAzuriranjeTeksta.Stop();
            this.ZakasneloAzuriranjeTeksta.Enabled = false;
            try
            {
                this.SelektovanBrojKomentara.Text = this.Privremena.UzmiBrojKomentara();
            }
            catch
            {
            }
            if (this.ZAT > 4)
            {
                this.ZAT = 0;
            }
            else
            {
                this.ZAT++;
                this.ZakasneloAzuriranjeTeksta.Enabled = true;
                this.ZakasneloAzuriranjeTeksta.Start();
            }
        }
    }
}

