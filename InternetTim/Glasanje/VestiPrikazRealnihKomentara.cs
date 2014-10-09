namespace InternetTim.Glasanje
{
    using HtmlAgilityPack;
    using Infragistics.Win;
    using Infragistics.Win.UltraWinTabControl;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Web;
    using System.Windows.Forms;

    public class VestiPrikazRealnihKomentara : Form
    {
        private int aktivirajAzuriranje = 0x17;
        private CheckBox AktivirajFiletriBodovi;
        private Button AzurirajSad;
        private int brojvreme = 0;
        private ColorDialog colorDialog1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private IContainer components = null;
        private string[] Evidencija2233 = new string[0x3e8];
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel10;
        private FlowLayoutPanel flowLayoutPanel11;
        private FlowLayoutPanel flowLayoutPanel12;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel4;
        private FlowLayoutPanel flowLayoutPanel5;
        private FlowLayoutPanel flowLayoutPanel6;
        private FlowLayoutPanel flowLayoutPanel7;
        private FlowLayoutPanel flowLayoutPanel8;
        private FlowLayoutPanel flowLayoutPanel9;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Button IzaberiBoju;
        private Button IzbaciJedanIzdvojeni;
        private Button IzbaciSveIzdvojene;
        private CheckBox KomentariBezOdgovora;
        private Label label1;
        private Label label2;
        private Button LevoDesno;
        public string LINK = "";
        public string NASLOV = "";
        private CheckBox OdgovoriNaKomentare;
        private int ogranicenjeenter = 0;
        private Panel panel1;
        private PictureBox pictureBox1;
        private int pozicija = 0;
        private PrikazPojedinacnogKomentara Privremeno = new PrikazPojedinacnogKomentara();
        private ProgressBar progressBar1;
        private CheckBox Prvih10Komentara;
        private BackgroundWorker SkidanjeKomentara;
        public Image SLIKA = null;
        private Button StaviUIzdvojeniTab;
        private CheckBox taskbarpokazi;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private System.Windows.Forms.Timer UcitavanjeKom;
        private UltraTabControl ultraTabControl1;
        private UltraTabPageControl ultraTabPageControl1;
        private UltraTabPageControl ultraTabPageControl10;
        private UltraTabPageControl ultraTabPageControl11;
        private UltraTabPageControl ultraTabPageControl12;
        private UltraTabPageControl ultraTabPageControl2;
        private UltraTabPageControl ultraTabPageControl3;
        private UltraTabPageControl ultraTabPageControl4;
        private UltraTabPageControl ultraTabPageControl5;
        private UltraTabPageControl ultraTabPageControl6;
        private UltraTabPageControl ultraTabPageControl7;
        private UltraTabPageControl ultraTabPageControl8;
        private UltraTabPageControl ultraTabPageControl9;
        private UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private int VisinaProzora = 0;

        public event EventHandler<PosaljiBrisanjeGlasanja> KomandaBrisanjeGlasanja;

        public event EventHandler<PosaljiNazadKomentar> KomandaGlasaj;

        public event EventHandler<PosaljiKomentar> KomandaKomentari;

        public VestiPrikazRealnihKomentara()
        {
            this.InitializeComponent();
        }

        protected virtual void AktivirajBrisanjeGlasanja(string text)
        {
            EventHandler<PosaljiBrisanjeGlasanja> komandaBrisanjeGlasanja = this.KomandaBrisanjeGlasanja;
            if (komandaBrisanjeGlasanja != null)
            {
                PosaljiBrisanjeGlasanja e = new PosaljiBrisanjeGlasanja(text);
                komandaBrisanjeGlasanja(this, e);
            }
        }

        protected virtual void AktivirajSlanjeKomande(string[] text)
        {
            EventHandler<PosaljiNazadKomentar> komandaGlasaj = this.KomandaGlasaj;
            if (komandaGlasaj != null)
            {
                PosaljiNazadKomentar e = new PosaljiNazadKomentar(text);
                komandaGlasaj(this, e);
            }
        }

        protected virtual void AktivirajSlanjeKomentara(string text)
        {
            EventHandler<PosaljiKomentar> komandaKomentari = this.KomandaKomentari;
            if (komandaKomentari != null)
            {
                PosaljiKomentar e = new PosaljiKomentar(text);
                komandaKomentari(this, e);
            }
        }

        public void AzurirajKomentareNaKojeSeGlasa(string[] poda)
        {
            this.Evidencija2233 = poda;
        }

        private void AzurirajSad_Click(object sender, EventArgs e)
        {
            if (this.ogranicenjeenter == 0)
            {
                this.ogranicenjeenter = 1;
                this.UcitavanjeKom.Stop();
                this.UcitavanjeKom.Enabled = false;
                this.AzurirajSad.Visible = false;
                this.AktivirajSlanjeKomentara("OKET");
                this.SkidanjeKomentara.RunWorkerAsync(this.LINK);
                this.ultraTabControl1.Focus();
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
            this.components = new Container();
            UltraTab tab = new UltraTab();
            UltraTab tab2 = new UltraTab();
            UltraTab tab3 = new UltraTab();
            UltraTab tab4 = new UltraTab();
            UltraTab tab5 = new UltraTab();
            UltraTab tab6 = new UltraTab();
            UltraTab tab7 = new UltraTab();
            UltraTab tab8 = new UltraTab();
            UltraTab tab9 = new UltraTab();
            UltraTab tab10 = new UltraTab();
            UltraTab tab11 = new UltraTab();
            UltraTab tab12 = new UltraTab();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(VestiPrikazRealnihKomentara));
            this.ultraTabPageControl1 = new UltraTabPageControl();
            this.flowLayoutPanel1 = new FlowLayoutPanel();
            this.ultraTabPageControl2 = new UltraTabPageControl();
            this.flowLayoutPanel2 = new FlowLayoutPanel();
            this.ultraTabPageControl3 = new UltraTabPageControl();
            this.flowLayoutPanel3 = new FlowLayoutPanel();
            this.ultraTabPageControl4 = new UltraTabPageControl();
            this.flowLayoutPanel4 = new FlowLayoutPanel();
            this.ultraTabPageControl5 = new UltraTabPageControl();
            this.flowLayoutPanel5 = new FlowLayoutPanel();
            this.ultraTabPageControl6 = new UltraTabPageControl();
            this.flowLayoutPanel6 = new FlowLayoutPanel();
            this.ultraTabPageControl7 = new UltraTabPageControl();
            this.flowLayoutPanel7 = new FlowLayoutPanel();
            this.ultraTabPageControl8 = new UltraTabPageControl();
            this.flowLayoutPanel8 = new FlowLayoutPanel();
            this.ultraTabPageControl9 = new UltraTabPageControl();
            this.flowLayoutPanel9 = new FlowLayoutPanel();
            this.ultraTabPageControl10 = new UltraTabPageControl();
            this.flowLayoutPanel10 = new FlowLayoutPanel();
            this.ultraTabPageControl11 = new UltraTabPageControl();
            this.flowLayoutPanel11 = new FlowLayoutPanel();
            this.ultraTabPageControl12 = new UltraTabPageControl();
            this.flowLayoutPanel12 = new FlowLayoutPanel();
            this.IzbaciJedanIzdvojeni = new Button();
            this.IzbaciSveIzdvojene = new Button();
            this.panel1 = new Panel();
            this.label2 = new Label();
            this.IzaberiBoju = new Button();
            this.LevoDesno = new Button();
            this.groupBox4 = new GroupBox();
            this.StaviUIzdvojeniTab = new Button();
            this.pictureBox1 = new PictureBox();
            this.groupBox3 = new GroupBox();
            this.AzurirajSad = new Button();
            this.label1 = new Label();
            this.trackBar2 = new TrackBar();
            this.taskbarpokazi = new CheckBox();
            this.groupBox2 = new GroupBox();
            this.comboBox3 = new ComboBox();
            this.comboBox2 = new ComboBox();
            this.comboBox1 = new ComboBox();
            this.AktivirajFiletriBodovi = new CheckBox();
            this.groupBox1 = new GroupBox();
            this.Prvih10Komentara = new CheckBox();
            this.OdgovoriNaKomentare = new CheckBox();
            this.KomentariBezOdgovora = new CheckBox();
            this.trackBar1 = new TrackBar();
            this.UcitavanjeKom = new System.Windows.Forms.Timer(this.components);
            this.SkidanjeKomentara = new BackgroundWorker();
            this.ultraTabControl1 = new UltraTabControl();
            this.ultraTabSharedControlsPage1 = new UltraTabSharedControlsPage();
            this.progressBar1 = new ProgressBar();
            this.colorDialog1 = new ColorDialog();
            this.ultraTabPageControl1.SuspendLayout();
            this.ultraTabPageControl2.SuspendLayout();
            this.ultraTabPageControl3.SuspendLayout();
            this.ultraTabPageControl4.SuspendLayout();
            this.ultraTabPageControl5.SuspendLayout();
            this.ultraTabPageControl6.SuspendLayout();
            this.ultraTabPageControl7.SuspendLayout();
            this.ultraTabPageControl8.SuspendLayout();
            this.ultraTabPageControl9.SuspendLayout();
            this.ultraTabPageControl10.SuspendLayout();
            this.ultraTabPageControl11.SuspendLayout();
            this.ultraTabPageControl12.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            this.groupBox3.SuspendLayout();
            this.trackBar2.BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.trackBar1.BeginInit();
            ((ISupportInitialize) this.ultraTabControl1).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            base.SuspendLayout();
            this.ultraTabPageControl1.Controls.Add(this.flowLayoutPanel1);
            this.ultraTabPageControl1.Location = new Point(1, 20);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new Size(0x278, 0x282);
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Dock = DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutPanel1.Font = new Font("Microsoft Sans Serif", 8.25f);
            this.flowLayoutPanel1.Location = new Point(0, 0);
            this.flowLayoutPanel1.Margin = new Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new Size(0x278, 0x282);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            this.ultraTabPageControl2.Controls.Add(this.flowLayoutPanel2);
            this.ultraTabPageControl2.Location = new Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new Size(0x278, 0x282);
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BorderStyle = BorderStyle.Fixed3D;
            this.flowLayoutPanel2.Dock = DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutPanel2.Font = new Font("Microsoft Sans Serif", 8.25f);
            this.flowLayoutPanel2.Location = new Point(0, 0);
            this.flowLayoutPanel2.Margin = new Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new Size(0x278, 0x282);
            this.flowLayoutPanel2.TabIndex = 2;
            this.flowLayoutPanel2.WrapContents = false;
            this.ultraTabPageControl3.Controls.Add(this.flowLayoutPanel3);
            this.ultraTabPageControl3.Location = new Point(-10000, -10000);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new Size(0x278, 0x282);
            this.flowLayoutPanel3.AutoScroll = true;
            this.flowLayoutPanel3.BorderStyle = BorderStyle.Fixed3D;
            this.flowLayoutPanel3.Dock = DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutPanel3.Font = new Font("Microsoft Sans Serif", 8.25f);
            this.flowLayoutPanel3.Location = new Point(0, 0);
            this.flowLayoutPanel3.Margin = new Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new Size(0x278, 0x282);
            this.flowLayoutPanel3.TabIndex = 2;
            this.flowLayoutPanel3.WrapContents = false;
            this.ultraTabPageControl4.Controls.Add(this.flowLayoutPanel4);
            this.ultraTabPageControl4.Location = new Point(-10000, -10000);
            this.ultraTabPageControl4.Name = "ultraTabPageControl4";
            this.ultraTabPageControl4.Size = new Size(0x278, 0x282);
            this.flowLayoutPanel4.AutoScroll = true;
            this.flowLayoutPanel4.BorderStyle = BorderStyle.Fixed3D;
            this.flowLayoutPanel4.Dock = DockStyle.Fill;
            this.flowLayoutPanel4.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutPanel4.Font = new Font("Microsoft Sans Serif", 8.25f);
            this.flowLayoutPanel4.Location = new Point(0, 0);
            this.flowLayoutPanel4.Margin = new Padding(0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new Size(0x278, 0x282);
            this.flowLayoutPanel4.TabIndex = 2;
            this.flowLayoutPanel4.WrapContents = false;
            this.ultraTabPageControl5.Controls.Add(this.flowLayoutPanel5);
            this.ultraTabPageControl5.Location = new Point(-10000, -10000);
            this.ultraTabPageControl5.Name = "ultraTabPageControl5";
            this.ultraTabPageControl5.Size = new Size(0x278, 0x282);
            this.flowLayoutPanel5.AutoScroll = true;
            this.flowLayoutPanel5.BorderStyle = BorderStyle.Fixed3D;
            this.flowLayoutPanel5.Dock = DockStyle.Fill;
            this.flowLayoutPanel5.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutPanel5.Font = new Font("Microsoft Sans Serif", 8.25f);
            this.flowLayoutPanel5.Location = new Point(0, 0);
            this.flowLayoutPanel5.Margin = new Padding(0);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new Size(0x278, 0x282);
            this.flowLayoutPanel5.TabIndex = 2;
            this.flowLayoutPanel5.WrapContents = false;
            this.ultraTabPageControl6.Controls.Add(this.flowLayoutPanel6);
            this.ultraTabPageControl6.Location = new Point(-10000, -10000);
            this.ultraTabPageControl6.Name = "ultraTabPageControl6";
            this.ultraTabPageControl6.Size = new Size(0x278, 0x282);
            this.flowLayoutPanel6.AutoScroll = true;
            this.flowLayoutPanel6.BorderStyle = BorderStyle.Fixed3D;
            this.flowLayoutPanel6.Dock = DockStyle.Fill;
            this.flowLayoutPanel6.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutPanel6.Font = new Font("Microsoft Sans Serif", 8.25f);
            this.flowLayoutPanel6.Location = new Point(0, 0);
            this.flowLayoutPanel6.Margin = new Padding(0);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new Size(0x278, 0x282);
            this.flowLayoutPanel6.TabIndex = 2;
            this.flowLayoutPanel6.WrapContents = false;
            this.ultraTabPageControl7.Controls.Add(this.flowLayoutPanel7);
            this.ultraTabPageControl7.Location = new Point(-10000, -10000);
            this.ultraTabPageControl7.Name = "ultraTabPageControl7";
            this.ultraTabPageControl7.Size = new Size(0x278, 0x282);
            this.flowLayoutPanel7.AutoScroll = true;
            this.flowLayoutPanel7.BorderStyle = BorderStyle.Fixed3D;
            this.flowLayoutPanel7.Dock = DockStyle.Fill;
            this.flowLayoutPanel7.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutPanel7.Font = new Font("Microsoft Sans Serif", 8.25f);
            this.flowLayoutPanel7.Location = new Point(0, 0);
            this.flowLayoutPanel7.Margin = new Padding(0);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new Size(0x278, 0x282);
            this.flowLayoutPanel7.TabIndex = 2;
            this.flowLayoutPanel7.WrapContents = false;
            this.ultraTabPageControl8.Controls.Add(this.flowLayoutPanel8);
            this.ultraTabPageControl8.Location = new Point(-10000, -10000);
            this.ultraTabPageControl8.Name = "ultraTabPageControl8";
            this.ultraTabPageControl8.Size = new Size(0x278, 0x282);
            this.flowLayoutPanel8.AutoScroll = true;
            this.flowLayoutPanel8.BorderStyle = BorderStyle.Fixed3D;
            this.flowLayoutPanel8.Dock = DockStyle.Fill;
            this.flowLayoutPanel8.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutPanel8.Font = new Font("Microsoft Sans Serif", 8.25f);
            this.flowLayoutPanel8.Location = new Point(0, 0);
            this.flowLayoutPanel8.Margin = new Padding(0);
            this.flowLayoutPanel8.Name = "flowLayoutPanel8";
            this.flowLayoutPanel8.Size = new Size(0x278, 0x282);
            this.flowLayoutPanel8.TabIndex = 2;
            this.flowLayoutPanel8.WrapContents = false;
            this.ultraTabPageControl9.Controls.Add(this.flowLayoutPanel9);
            this.ultraTabPageControl9.Location = new Point(-10000, -10000);
            this.ultraTabPageControl9.Name = "ultraTabPageControl9";
            this.ultraTabPageControl9.Size = new Size(0x278, 0x282);
            this.flowLayoutPanel9.AutoScroll = true;
            this.flowLayoutPanel9.BorderStyle = BorderStyle.Fixed3D;
            this.flowLayoutPanel9.Dock = DockStyle.Fill;
            this.flowLayoutPanel9.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutPanel9.Font = new Font("Microsoft Sans Serif", 8.25f);
            this.flowLayoutPanel9.Location = new Point(0, 0);
            this.flowLayoutPanel9.Margin = new Padding(0);
            this.flowLayoutPanel9.Name = "flowLayoutPanel9";
            this.flowLayoutPanel9.Size = new Size(0x278, 0x282);
            this.flowLayoutPanel9.TabIndex = 2;
            this.flowLayoutPanel9.WrapContents = false;
            this.ultraTabPageControl10.Controls.Add(this.flowLayoutPanel10);
            this.ultraTabPageControl10.Location = new Point(-10000, -10000);
            this.ultraTabPageControl10.Name = "ultraTabPageControl10";
            this.ultraTabPageControl10.Size = new Size(0x278, 0x282);
            this.flowLayoutPanel10.AutoScroll = true;
            this.flowLayoutPanel10.BorderStyle = BorderStyle.Fixed3D;
            this.flowLayoutPanel10.Dock = DockStyle.Fill;
            this.flowLayoutPanel10.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutPanel10.Font = new Font("Microsoft Sans Serif", 8.25f);
            this.flowLayoutPanel10.Location = new Point(0, 0);
            this.flowLayoutPanel10.Margin = new Padding(0);
            this.flowLayoutPanel10.Name = "flowLayoutPanel10";
            this.flowLayoutPanel10.Size = new Size(0x278, 0x282);
            this.flowLayoutPanel10.TabIndex = 2;
            this.flowLayoutPanel10.WrapContents = false;
            this.ultraTabPageControl11.Controls.Add(this.flowLayoutPanel11);
            this.ultraTabPageControl11.Location = new Point(-10000, -10000);
            this.ultraTabPageControl11.Name = "ultraTabPageControl11";
            this.ultraTabPageControl11.Size = new Size(0x278, 0x282);
            this.flowLayoutPanel11.AutoScroll = true;
            this.flowLayoutPanel11.BorderStyle = BorderStyle.Fixed3D;
            this.flowLayoutPanel11.Dock = DockStyle.Fill;
            this.flowLayoutPanel11.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutPanel11.Font = new Font("Microsoft Sans Serif", 8.25f);
            this.flowLayoutPanel11.Location = new Point(0, 0);
            this.flowLayoutPanel11.Margin = new Padding(0);
            this.flowLayoutPanel11.Name = "flowLayoutPanel11";
            this.flowLayoutPanel11.Size = new Size(0x278, 0x282);
            this.flowLayoutPanel11.TabIndex = 2;
            this.flowLayoutPanel11.WrapContents = false;
            this.ultraTabPageControl12.Controls.Add(this.flowLayoutPanel12);
            this.ultraTabPageControl12.Controls.Add(this.IzbaciJedanIzdvojeni);
            this.ultraTabPageControl12.Controls.Add(this.IzbaciSveIzdvojene);
            this.ultraTabPageControl12.Location = new Point(-10000, -10000);
            this.ultraTabPageControl12.Name = "ultraTabPageControl12";
            this.ultraTabPageControl12.Size = new Size(0x278, 0x282);
            this.flowLayoutPanel12.AutoScroll = true;
            this.flowLayoutPanel12.BorderStyle = BorderStyle.Fixed3D;
            this.flowLayoutPanel12.Dock = DockStyle.Fill;
            this.flowLayoutPanel12.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutPanel12.Font = new Font("Microsoft Sans Serif", 8.25f);
            this.flowLayoutPanel12.Location = new Point(0, 0);
            this.flowLayoutPanel12.Margin = new Padding(0);
            this.flowLayoutPanel12.Name = "flowLayoutPanel12";
            this.flowLayoutPanel12.Size = new Size(0x278, 0x254);
            this.flowLayoutPanel12.TabIndex = 3;
            this.flowLayoutPanel12.WrapContents = false;
            this.IzbaciJedanIzdvojeni.Cursor = Cursors.Hand;
            this.IzbaciJedanIzdvojeni.Dock = DockStyle.Bottom;
            this.IzbaciJedanIzdvojeni.Location = new Point(0, 0x254);
            this.IzbaciJedanIzdvojeni.Name = "IzbaciJedanIzdvojeni";
            this.IzbaciJedanIzdvojeni.Size = new Size(0x278, 0x17);
            this.IzbaciJedanIzdvojeni.TabIndex = 5;
            this.IzbaciJedanIzdvojeni.Text = "IZBACI ODABRANI KOMENTAR IZ IZDVOJENIH";
            this.IzbaciJedanIzdvojeni.UseVisualStyleBackColor = true;
            this.IzbaciJedanIzdvojeni.Click += new EventHandler(this.IzbaciJedanIzdvojeni_Click);
            this.IzbaciSveIzdvojene.Cursor = Cursors.Hand;
            this.IzbaciSveIzdvojene.Dock = DockStyle.Bottom;
            this.IzbaciSveIzdvojene.Location = new Point(0, 0x26b);
            this.IzbaciSveIzdvojene.Name = "IzbaciSveIzdvojene";
            this.IzbaciSveIzdvojene.Size = new Size(0x278, 0x17);
            this.IzbaciSveIzdvojene.TabIndex = 4;
            this.IzbaciSveIzdvojene.Text = "IZBACI SVE IZ IZDVOJENIH";
            this.IzbaciSveIzdvojene.UseVisualStyleBackColor = true;
            this.IzbaciSveIzdvojene.Click += new EventHandler(this.IzbaciSveIzdvojene_Click);
            this.panel1.BackColor = Color.DarkGray;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.IzaberiBoju);
            this.panel1.Controls.Add(this.LevoDesno);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.taskbarpokazi);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Dock = DockStyle.Left;
            this.panel1.Location = new Point(0, 8);
            this.panel1.Margin = new Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(200, 0x297);
            this.panel1.TabIndex = 0;
            this.label2.AutoSize = true;
            this.label2.BackColor = Color.Gold;
            this.label2.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(7, 11);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x1d, 0x1f);
            this.label2.TabIndex = 9;
            this.label2.Text = "0";
            this.IzaberiBoju.BackColor = Color.White;
            this.IzaberiBoju.Cursor = Cursors.Hand;
            this.IzaberiBoju.FlatStyle = FlatStyle.Flat;
            this.IzaberiBoju.Location = new Point(0x98, 0x87);
            this.IzaberiBoju.Name = "IzaberiBoju";
            this.IzaberiBoju.Size = new Size(0x19, 0x19);
            this.IzaberiBoju.TabIndex = 8;
            this.IzaberiBoju.UseVisualStyleBackColor = false;
            this.IzaberiBoju.Click += new EventHandler(this.IzaberiBoju_Click);
            this.LevoDesno.Cursor = Cursors.Hand;
            this.LevoDesno.Dock = DockStyle.Right;
            this.LevoDesno.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.LevoDesno.Location = new Point(180, 0);
            this.LevoDesno.Margin = new Padding(0);
            this.LevoDesno.Name = "LevoDesno";
            this.LevoDesno.Size = new Size(20, 0x297);
            this.LevoDesno.TabIndex = 0;
            this.LevoDesno.Text = "<";
            this.LevoDesno.UseVisualStyleBackColor = true;
            this.LevoDesno.Click += new EventHandler(this.LevoDesno_Click);
            this.groupBox4.Controls.Add(this.StaviUIzdvojeniTab);
            this.groupBox4.Location = new Point(4, 0x209);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(0xad, 0x2f);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Izdvojeni komentari";
            this.StaviUIzdvojeniTab.Location = new Point(11, 20);
            this.StaviUIzdvojeniTab.Name = "StaviUIzdvojeniTab";
            this.StaviUIzdvojeniTab.Size = new Size(0x9b, 0x17);
            this.StaviUIzdvojeniTab.TabIndex = 0;
            this.StaviUIzdvojeniTab.Text = "Stavi odabrani u izdvojeni tab";
            this.StaviUIzdvojeniTab.UseVisualStyleBackColor = true;
            this.StaviUIzdvojeniTab.Click += new EventHandler(this.StaviUIzdvojeniTab_Click);
            this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            this.pictureBox1.Location = new Point(3, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0xae, 0x77);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.groupBox3.Controls.Add(this.AzurirajSad);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.trackBar2);
            this.groupBox3.Location = new Point(4, 0x1a2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0xad, 0x60);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ažuriranje komentara";
            this.AzurirajSad.Location = new Point(9, 0x44);
            this.AzurirajSad.Name = "AzurirajSad";
            this.AzurirajSad.Size = new Size(0x9d, 0x17);
            this.AzurirajSad.TabIndex = 2;
            this.AzurirajSad.Text = "AŽURIRAJ SAD";
            this.AzurirajSad.UseVisualStyleBackColor = true;
            this.AzurirajSad.Visible = false;
            this.AzurirajSad.Click += new EventHandler(this.AzurirajSad_Click);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(8, 0x33);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Na svakih 4 minuta.";
            this.trackBar2.LargeChange = 0;
            this.trackBar2.Location = new Point(6, 0x13);
            this.trackBar2.Minimum = 1;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new Size(160, 0x2d);
            this.trackBar2.TabIndex = 0;
            this.trackBar2.Value = 4;
            this.trackBar2.Scroll += new EventHandler(this.trackBar2_Scroll);
            this.taskbarpokazi.AutoSize = true;
            this.taskbarpokazi.Checked = true;
            this.taskbarpokazi.CheckState = CheckState.Checked;
            this.taskbarpokazi.Location = new Point(10, 0xa5);
            this.taskbarpokazi.Name = "taskbarpokazi";
            this.taskbarpokazi.Size = new Size(0x3d, 0x11);
            this.taskbarpokazi.TabIndex = 4;
            this.taskbarpokazi.Text = "taskbar";
            this.taskbarpokazi.UseVisualStyleBackColor = true;
            this.taskbarpokazi.CheckedChanged += new EventHandler(this.taskbarpokazi_CheckedChanged);
            this.groupBox2.Controls.Add(this.comboBox3);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.AktivirajFiletriBodovi);
            this.groupBox2.Location = new Point(4, 0x11e);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0xad, 0x7d);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FILTERI - bodovi";
            this.comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] { 
                "0", "10", "20", "30", "40", "50", "100", "200", "300", "400", "500", "1000", "1500", "2000", "3000", "4000", 
                "5000"
             });
            this.comboBox3.Location = new Point(6, 0x5d);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new Size(160, 0x15);
            this.comboBox3.TabIndex = 4;
            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] { "JEDNAKO", "MANJE OD", "VEĆE OD" });
            this.comboBox2.Location = new Point(7, 0x44);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new Size(160, 0x15);
            this.comboBox2.TabIndex = 3;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] { "PLUS", "MINUS", "PLUS i MINUS" });
            this.comboBox1.Location = new Point(7, 0x2b);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(160, 0x15);
            this.comboBox1.TabIndex = 2;
            this.AktivirajFiletriBodovi.AutoSize = true;
            this.AktivirajFiletriBodovi.Location = new Point(7, 0x13);
            this.AktivirajFiletriBodovi.Name = "AktivirajFiletriBodovi";
            this.AktivirajFiletriBodovi.Size = new Size(0x79, 0x11);
            this.AktivirajFiletriBodovi.TabIndex = 1;
            this.AktivirajFiletriBodovi.Text = "aktiviraj filteri bodovi";
            this.AktivirajFiletriBodovi.UseVisualStyleBackColor = true;
            this.groupBox1.Controls.Add(this.Prvih10Komentara);
            this.groupBox1.Controls.Add(this.OdgovoriNaKomentare);
            this.groupBox1.Controls.Add(this.KomentariBezOdgovora);
            this.groupBox1.Location = new Point(4, 0xbf);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0xad, 0x59);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTERI - osnovni";
            this.Prvih10Komentara.AutoSize = true;
            this.Prvih10Komentara.Location = new Point(7, 0x42);
            this.Prvih10Komentara.Name = "Prvih10Komentara";
            this.Prvih10Komentara.Size = new Size(0x75, 0x11);
            this.Prvih10Komentara.TabIndex = 2;
            this.Prvih10Komentara.Text = "prvih 20 komentara";
            this.Prvih10Komentara.UseVisualStyleBackColor = true;
            this.OdgovoriNaKomentare.AutoSize = true;
            this.OdgovoriNaKomentare.Location = new Point(7, 0x2b);
            this.OdgovoriNaKomentare.Name = "OdgovoriNaKomentare";
            this.OdgovoriNaKomentare.Size = new Size(0x87, 0x11);
            this.OdgovoriNaKomentare.TabIndex = 1;
            this.OdgovoriNaKomentare.Text = "odgovori na komentare";
            this.OdgovoriNaKomentare.UseVisualStyleBackColor = true;
            this.KomentariBezOdgovora.AutoSize = true;
            this.KomentariBezOdgovora.Location = new Point(7, 20);
            this.KomentariBezOdgovora.Name = "KomentariBezOdgovora";
            this.KomentariBezOdgovora.Size = new Size(140, 0x11);
            this.KomentariBezOdgovora.TabIndex = 0;
            this.KomentariBezOdgovora.Text = "komentari bez odgovora";
            this.KomentariBezOdgovora.UseVisualStyleBackColor = true;
            this.trackBar1.LargeChange = 20;
            this.trackBar1.Location = new Point(3, 0x84);
            this.trackBar1.Maximum = 400;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new Size(0x8f, 0x2d);
            this.trackBar1.SmallChange = 20;
            this.trackBar1.TabIndex = 1;
            this.trackBar1.TickFrequency = 40;
            this.trackBar1.Scroll += new EventHandler(this.trackBar1_Scroll);
            this.UcitavanjeKom.Interval = 0x2710;
            this.UcitavanjeKom.Tick += new EventHandler(this.UcitavanjeKom_Tick);
            this.SkidanjeKomentara.DoWork += new DoWorkEventHandler(this.SkidanjeKomentara_DoWork);
            this.SkidanjeKomentara.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.SkidanjeKomentara_RunWorkerCompleted);
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl2);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl3);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl4);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl5);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl6);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl7);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl8);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl9);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl10);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl11);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl12);
            this.ultraTabControl1.Dock = DockStyle.Fill;
            this.ultraTabControl1.Font = new Font("Arial Narrow", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.ultraTabControl1.Location = new Point(200, 8);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new Size(0x27a, 0x297);
            this.ultraTabControl1.Style = UltraTabControlStyle.Flat;
            this.ultraTabControl1.TabIndex = 1;
            tab.TabPage = this.ultraTabPageControl1;
            tab.Text = "1 - 150";
            tab2.TabPage = this.ultraTabPageControl2;
            tab2.Text = "150 - 300";
            tab2.Visible = false;
            tab3.TabPage = this.ultraTabPageControl3;
            tab3.Text = "300 - 450";
            tab3.Visible = false;
            tab4.TabPage = this.ultraTabPageControl4;
            tab4.Text = "450 - 600";
            tab4.Visible = false;
            tab5.TabPage = this.ultraTabPageControl5;
            tab5.Text = "600 - 750";
            tab5.Visible = false;
            tab6.TabPage = this.ultraTabPageControl6;
            tab6.Text = "750 - 900";
            tab6.Visible = false;
            tab7.TabPage = this.ultraTabPageControl7;
            tab7.Text = "900 - 1050";
            tab7.Visible = false;
            tab8.TabPage = this.ultraTabPageControl8;
            tab8.Text = "1050 - 1200";
            tab8.Visible = false;
            tab9.TabPage = this.ultraTabPageControl9;
            tab9.Text = "1200 - 1350";
            tab9.Visible = false;
            tab10.TabPage = this.ultraTabPageControl10;
            tab10.Text = "1350 - 1500";
            tab10.Visible = false;
            tab11.TabPage = this.ultraTabPageControl11;
            tab11.Text = "1500 - 1650";
            tab11.Visible = false;
            appearance.BackColor = Color.FromArgb(0, 0xc0, 0);
            appearance.BackColor2 = Color.FromArgb(0xc0, 0xff, 0xc0);
            appearance.BackGradientStyle = GradientStyle.Vertical;
            tab12.Appearance = appearance;
            appearance2.BackColor = Color.Green;
            tab12.ClientAreaAppearance = appearance2;
            tab12.TabPage = this.ultraTabPageControl12;
            tab12.Text = "Izdvojeni";
            this.ultraTabControl1.Tabs.AddRange(new UltraTab[] { tab, tab2, tab3, tab4, tab5, tab6, tab7, tab8, tab9, tab10, tab11, tab12 });
            this.ultraTabSharedControlsPage1.Location = new Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new Size(0x278, 0x282);
            this.progressBar1.Dock = DockStyle.Top;
            this.progressBar1.Location = new Point(0, 0);
            this.progressBar1.Maximum = 0x17;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new Size(0x342, 8);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 2;
            this.colorDialog1.Color = Color.White;
            base.AcceptButton = this.AzurirajSad;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(0x342, 0x29f);
            base.Controls.Add(this.ultraTabControl1);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.progressBar1);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            this.MinimumSize = new Size(500, 500);
            base.Name = "VestiPrikazRealnihKomentara";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Komentari";
            base.Shown += new EventHandler(this.VestiPrikazRealnihKomentara_Shown);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl2.ResumeLayout(false);
            this.ultraTabPageControl3.ResumeLayout(false);
            this.ultraTabPageControl4.ResumeLayout(false);
            this.ultraTabPageControl5.ResumeLayout(false);
            this.ultraTabPageControl6.ResumeLayout(false);
            this.ultraTabPageControl7.ResumeLayout(false);
            this.ultraTabPageControl8.ResumeLayout(false);
            this.ultraTabPageControl9.ResumeLayout(false);
            this.ultraTabPageControl10.ResumeLayout(false);
            this.ultraTabPageControl11.ResumeLayout(false);
            this.ultraTabPageControl12.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((ISupportInitialize) this.pictureBox1).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.trackBar2.EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.trackBar1.EndInit();
            ((ISupportInitialize) this.ultraTabControl1).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void IzaberiBoju_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = this.colorDialog1.Color;
                this.IzaberiBoju.BackColor = color;
                this.flowLayoutPanel1.BackColor = color;
                this.flowLayoutPanel2.BackColor = color;
                this.flowLayoutPanel3.BackColor = color;
                this.flowLayoutPanel4.BackColor = color;
                this.flowLayoutPanel5.BackColor = color;
                this.flowLayoutPanel6.BackColor = color;
                this.flowLayoutPanel7.BackColor = color;
                this.flowLayoutPanel8.BackColor = color;
                this.flowLayoutPanel9.BackColor = color;
                this.flowLayoutPanel10.BackColor = color;
                this.flowLayoutPanel11.BackColor = color;
            }
        }

        private void IzbaciJedanIzdvojeni_Click(object sender, EventArgs e)
        {
            try
            {
                this.flowLayoutPanel12.Controls.Remove(this.Privremeno);
            }
            catch
            {
            }
        }

        private void IzbaciSveIzdvojene_Click(object sender, EventArgs e)
        {
            this.flowLayoutPanel12.Controls.Clear();
        }

        private void LevoDesno_Click(object sender, EventArgs e)
        {
            if (this.pozicija == 0)
            {
                this.pozicija = 1;
                this.panel1.Size = new Size(20, this.panel1.Size.Height);
                this.LevoDesno.Text = ">";
                base.Size = new Size(base.Size.Width - 180, base.Size.Height);
            }
            else
            {
                this.pozicija = 0;
                this.panel1.Size = new Size(200, this.panel1.Size.Height);
                this.LevoDesno.Text = "<";
                base.Size = new Size(840, base.Size.Height);
            }
        }

        private void novi_IdKomentaraWasClicked(object sender, EventArgs e)
        {
            this.Privremeno = (PrikazPojedinacnogKomentara) sender;
            this.AktivirajBrisanjeGlasanja(this.Privremeno.IdKomentara);
        }

        private void novi_MinusWasClicked(object sender, EventArgs e)
        {
            this.brojvreme = 1;
            this.progressBar1.Value = 1;
            this.Privremeno = (PrikazPojedinacnogKomentara) sender;
            int brojMinus = this.Privremeno.BrojMinus;
            string str = DateTime.Now.Day.ToString();
            if (str.Length == 1)
            {
                str = "0" + str;
            }
            string str2 = DateTime.Now.Month.ToString();
            if (str2.Length == 1)
            {
                str2 = "0" + str2;
            }
            string str3 = DateTime.Now.Year.ToString().Replace("20", "");
            string str4 = str + "-" + str2 + "-" + str3;
            int realanMinus = this.Privremeno.RealanMinus;
            string str5 = realanMinus.ToString();
            string[] text = new string[] { "down#" + this.Privremeno.IdKomentara + "#" + this.LINK, this.Privremeno.IdKomentara, brojMinus.ToString(), realanMinus.ToString() };
            this.AktivirajSlanjeKomande(text);
        }

        private void novi_PlusWasClicked(object sender, EventArgs e)
        {
            this.brojvreme = 1;
            this.progressBar1.Value = 1;
            this.Privremeno = (PrikazPojedinacnogKomentara) sender;
            int brojPlus = this.Privremeno.BrojPlus;
            string str = DateTime.Now.Day.ToString();
            if (str.Length == 1)
            {
                str = "0" + str;
            }
            string str2 = DateTime.Now.Month.ToString();
            if (str2.Length == 1)
            {
                str2 = "0" + str2;
            }
            string str3 = DateTime.Now.Year.ToString().Replace("20", "");
            string str4 = str + "-" + str2 + "-" + str3;
            int realanPlus = this.Privremeno.RealanPlus;
            string str5 = realanPlus.ToString();
            string[] text = new string[] { "up#" + this.Privremeno.IdKomentara + "#" + this.LINK, this.Privremeno.IdKomentara, brojPlus.ToString(), realanPlus.ToString() };
            this.AktivirajSlanjeKomande(text);
        }

        private void novi_WasClicked(object sender, EventArgs e)
        {
            try
            {
                this.Privremeno.SkiniBoju();
            }
            catch
            {
            }
            this.Privremeno = (PrikazPojedinacnogKomentara) sender;
            this.Privremeno.OznaciKontrolu();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData == Keys.Enter) && (this.ogranicenjeenter == 0))
            {
                this.ogranicenjeenter = 1;
                this.UcitavanjeKom.Stop();
                this.UcitavanjeKom.Enabled = false;
                this.AzurirajSad.Visible = false;
                this.AktivirajSlanjeKomentara("OKET");
                this.SkidanjeKomentara.RunWorkerAsync(this.LINK);
                this.ultraTabControl1.Focus();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SkidanjeKomentara_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string innerText;
                int num2;
                int num3;
                string[] strArray = new string[0x7530];
                int index = 0;
                string str = e.Argument.ToString();
                string address = str;
                string[] strArray2 = str.Split(new char[] { '=' });
                string[] strArray3 = str.Split(new char[] { '/' });
                if (!(!address.Contains("www.blic.rs") || address.Contains("komentari")))
                {
                    address = address + "/komentari#vas-komentar";
                }
                if (address.Contains("www.b92.net"))
                {
                    try
                    {
                        if (address.Contains("www.b92.net/eng/news"))
                        {
                            address = "http://www.b92.net/eng/news/comments.php?nav_id=" + strArray2[strArray2.Length - 1];
                        }
                        else
                        {
                            address = "http://www.b92.net/info/komentari.php?nav_id=" + strArray2[strArray2.Length - 1];
                        }
                    }
                    catch
                    {
                    }
                }
                string str3 = "";
                if (!(!address.Contains("www.kurir-info.rs") || address.Contains("komentari")))
                {
                    address = strArray3[0] + "//" + strArray3[2] + "/komentari/" + strArray3[strArray3.Length - 1];
                    str3 = "/komentari/" + strArray3[strArray3.Length - 1];
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
                if (address.Contains("blic.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='comm_text']"))
                        {
                            string str7;
                            innerText = "";
                            num2 = 0;
                            num3 = 0;
                            strArray[index] = node.ParentNode.Id;
                            index++;
                            try
                            {
                                str7 = "";
                                string[] strArray4 = node.ParentNode.OuterHtml.Split(new char[] { '>' });
                                int num4 = 0;
                                foreach (string str8 in strArray4)
                                {
                                    if (str8.Contains("vote_p"))
                                    {
                                        try
                                        {
                                            num2 = int.Parse(strArray4[num4 + 1].Replace("</span", ""));
                                            strArray[index] = num2.ToString();
                                            index++;
                                        }
                                        catch
                                        {
                                        }
                                    }
                                    if (str8.Contains("vote_n"))
                                    {
                                        try
                                        {
                                            num3 = int.Parse(strArray4[num4 + 1].Replace("</span", ""));
                                            strArray[index] = num3.ToString();
                                            index++;
                                            break;
                                        }
                                        catch
                                        {
                                        }
                                    }
                                    num4++;
                                }
                                string str11 = node.InnerText.Replace("&quot;", "").Replace("&sbquo;", ",").Replace("&ldquo;", ",");
                                if (node.ParentNode.ChildNodes[3].ChildNodes[3].ChildNodes[1].InnerHtml != "")
                                {
                                    try
                                    {
                                        str7 = node.ParentNode.ChildNodes[3].ChildNodes[3].ChildNodes[1].InnerHtml + "  -  " + node.ParentNode.ChildNodes[3].ChildNodes[3].ChildNodes[4].InnerHtml;
                                        innerText = str11;
                                    }
                                    catch
                                    {
                                    }
                                }
                                else
                                {
                                    str7 = node.ParentNode.ChildNodes[3].ChildNodes[3].ChildNodes[3].InnerHtml + "  -  " + node.ParentNode.ChildNodes[3].ChildNodes[3].ChildNodes[6].InnerHtml;
                                    innerText = str11;
                                }
                                strArray[index] = str7;
                                index++;
                                strArray[index] = innerText;
                                index++;
                            }
                            catch
                            {
                                try
                                {
                                    str7 = "";
                                    if (node.ParentNode.ChildNodes[3].ChildNodes[5].ChildNodes[1].InnerHtml != "")
                                    {
                                        if (node.ParentNode.ChildNodes[3].ChildNodes[5].ChildNodes[1].InnerHtml.Contains("<span class="))
                                        {
                                            str7 = node.ParentNode.ChildNodes[3].ChildNodes[5].ChildNodes[1].InnerText + "  -  " + node.ParentNode.ChildNodes[3].ChildNodes[5].ChildNodes[4].InnerHtml;
                                            innerText = node.ParentNode.ChildNodes[5].InnerText;
                                        }
                                        else
                                        {
                                            str7 = node.ParentNode.ChildNodes[3].ChildNodes[5].ChildNodes[1].InnerHtml + "  -  " + node.ParentNode.ChildNodes[3].ChildNodes[5].ChildNodes[4].InnerHtml;
                                            innerText = node.ParentNode.ChildNodes[5].InnerText;
                                        }
                                    }
                                    else
                                    {
                                        str7 = node.ParentNode.ChildNodes[3].ChildNodes[5].ChildNodes[3].InnerHtml + "  -  " + node.ParentNode.ChildNodes[3].ChildNodes[5].ChildNodes[6].InnerHtml;
                                        innerText = node.ParentNode.ChildNodes[5].InnerText;
                                    }
                                    innerText = innerText.Replace("&quot;", "").Replace("&sbquo;", ",").Replace("&ldquo;", ",");
                                    if (innerText != "")
                                    {
                                        strArray[index] = str7;
                                        index++;
                                        strArray[index] = innerText;
                                        index++;
                                    }
                                }
                                catch
                                {
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                if (address.Contains("b92.net"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@id='tab-comments-h-tab']"))
                        {
                            for (int i = 0; i <= (node.ChildNodes[0].ChildNodes[3].ChildNodes.Count - 1); i++)
                            {
                                string[] strArray5;
                                string str15;
                                string str12 = node.ChildNodes[0].ChildNodes[3].ChildNodes[i].InnerText;
                                if (node.ChildNodes[0].ChildNodes[3].ChildNodes[i].Id.Length < 3)
                                {
                                    break;
                                }
                                strArray[index] = node.ChildNodes[0].ChildNodes[3].ChildNodes[i].Id;
                                index++;
                                string str13 = str12;
                                if (str13.Contains("&#"))
                                {
                                    strArray5 = str13.Split(new char[] { ';' });
                                    foreach (string str14 in strArray5)
                                    {
                                        try
                                        {
                                            str15 = HttpUtility.HtmlDecode(str14 + ";");
                                            str13 = str13.Replace(str14 + ";", str15);
                                        }
                                        catch
                                        {
                                        }
                                    }
                                }
                                string[] strArray6 = str13.Split(new char[] { '(' });
                                string[] strArray7 = new string[10];
                                int num6 = 0;
                                string str16 = "";
                                foreach (string str17 in strArray6)
                                {
                                    if (str17.Contains("Link komentara"))
                                    {
                                        break;
                                    }
                                    strArray7[num6] = str16 + str17;
                                    num6++;
                                }
                                try
                                {
                                    int num7;
                                    int num8;
                                    string str18 = node.ChildNodes[0].ChildNodes[3].ChildNodes[i].InnerText.Replace("# Link komentara", "").Replace("&nbsp;", "").Replace("&hellip;", "").Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("Šta je ovo", "").Replace("# Comment link", "").Replace("What's this?", "");
                                    try
                                    {
                                        if (str18.Contains("Preporučujem ("))
                                        {
                                            num2 = 0;
                                            str18 = str18.Replace("Preporučujem (0)", "");
                                            num7 = 1;
                                            while (num7 < 0x5dc)
                                            {
                                                if (str18.Contains("Preporučujem (+"))
                                                {
                                                    str18 = str18.Replace("Preporučujem (+" + num7.ToString() + ")", "");
                                                    num2++;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                                num7++;
                                            }
                                            strArray[index] = num2.ToString();
                                            index++;
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    try
                                    {
                                        if (str18.Contains("Ne preporučujem ("))
                                        {
                                            num3 = 0;
                                            str18 = str18.Replace("Ne preporučujem (0)", "");
                                            num8 = 1;
                                            while (num8 < 0x5dc)
                                            {
                                                if (str18.Contains("Ne preporučujem (-"))
                                                {
                                                    str18 = str18.Replace("Ne preporučujem (-" + num8.ToString() + ")", "");
                                                    num3++;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                                num8++;
                                            }
                                            strArray[index] = num3.ToString();
                                            index++;
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    try
                                    {
                                        if (str18.Contains("Recommend ("))
                                        {
                                            num2 = 0;
                                            str18 = str18.Replace("Recommend (0)", "");
                                            for (num7 = 1; num7 < 0x5dc; num7++)
                                            {
                                                if (str18.Contains("Recommend (+"))
                                                {
                                                    str18 = str18.Replace("Recommend (+" + num7.ToString() + ")", "");
                                                    num2++;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            strArray[index] = num2.ToString();
                                            index++;
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    try
                                    {
                                        if (str18.Contains("Poor comment ("))
                                        {
                                            num3 = 0;
                                            str18 = str18.Replace("Poor comment (0)", "");
                                            for (num8 = 1; num8 < 0x5dc; num8++)
                                            {
                                                if (str18.Contains("Poor comment (-"))
                                                {
                                                    str18 = str18.Replace("Poor comment (-" + num8.ToString() + ")", "");
                                                    num3++;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            strArray[index] = num3.ToString();
                                            index++;
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    string oldValue = "";
                                    string str20 = "";
                                    int num9 = 0;
                                    for (int j = 0; j < node.ChildNodes[0].ChildNodes[3].ChildNodes[i].ChildNodes.Count; j++)
                                    {
                                        if (node.ChildNodes[0].ChildNodes[3].ChildNodes[i].ChildNodes[j].Name == "span")
                                        {
                                            if (num9 == 0)
                                            {
                                                oldValue = node.ChildNodes[0].ChildNodes[3].ChildNodes[i].ChildNodes[j].InnerText;
                                                num9 = 1;
                                            }
                                            else
                                            {
                                                str20 = node.ChildNodes[0].ChildNodes[3].ChildNodes[i].ChildNodes[j].InnerText;
                                            }
                                        }
                                    }
                                    strArray[index] = oldValue + " - " + str20;
                                    index++;
                                    string[] strArray8 = str18.Replace("\r\n", "").Split(new char[] { '(' });
                                    innerText = "";
                                    int num11 = 0;
                                    foreach (string str21 in strArray8)
                                    {
                                        if (num11 == (strArray8.Length - 1))
                                        {
                                            innerText = innerText + "\r\n(" + str21;
                                        }
                                        else
                                        {
                                            innerText = innerText + str21;
                                        }
                                        num11++;
                                    }
                                    if (innerText.StartsWith("\t"))
                                    {
                                        innerText = innerText.Remove(0, 1);
                                    }
                                    if (innerText.Contains("&#"))
                                    {
                                        strArray5 = innerText.Split(new char[] { ';' });
                                        foreach (string str14 in strArray5)
                                        {
                                            try
                                            {
                                                str15 = HttpUtility.HtmlDecode(str14 + ";");
                                                innerText = innerText.Replace(str14 + ";", str15);
                                            }
                                            catch
                                            {
                                            }
                                        }
                                    }
                                    strArray[index] = innerText.Replace(oldValue, "").Replace(str20, "").Replace("(, )", "");
                                    index++;
                                }
                                catch
                                {
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                if (address.Contains("kurir-info"))
                {
                    try
                    {
                        string str22;
                        string str23;
                        string str24;
                        string str25;
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//p[@itemprop='commentText']"))
                        {
                            try
                            {
                                strArray[index] = node.ParentNode.ChildNodes[9].Attributes[0].Value;
                                index++;
                                str22 = node.ParentNode.ChildNodes[7].ChildNodes[1].InnerText.Replace("Preporučujem (", "").Replace(")&nbsp;", "");
                                strArray[index] = str22;
                                index++;
                                str23 = node.ParentNode.ChildNodes[7].ChildNodes[5].InnerText.Replace("Ne Preporučujem (", "").Replace(")&nbsp;", "");
                                strArray[index] = str23;
                                index++;
                                str24 = node.ParentNode.ChildNodes[1].InnerText;
                                str25 = node.ParentNode.ChildNodes[3].InnerText;
                                strArray[index] = str25 + " - " + str24;
                                index++;
                                strArray[index] = node.InnerText;
                                index++;
                            }
                            catch
                            {
                            }
                        }
                        try
                        {
                            foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//a[@href='" + str3 + "?page=2']"))
                            {
                                if (!node.InnerHtml.Contains("stranica"))
                                {
                                    string str26;
                                    using (WebClient client2 = new WebClient())
                                    {
                                        client2.Encoding = Encoding.UTF8;
                                        str26 = client2.DownloadString(address + "?page=2");
                                        client2.Dispose();
                                    }
                                    HtmlAgilityPack.HtmlDocument document2 = new HtmlAgilityPack.HtmlDocument();
                                    document2.LoadHtml(str26);
                                    foreach (HtmlNode node2 in (IEnumerable<HtmlNode>) document2.DocumentNode.SelectNodes("//p[@itemprop='commentText']"))
                                    {
                                        try
                                        {
                                            strArray[index] = node2.ParentNode.ChildNodes[9].Attributes[0].Value;
                                            index++;
                                            str22 = node2.ParentNode.ChildNodes[7].ChildNodes[1].InnerText.Replace("Preporučujem (", "").Replace(")&nbsp;", "");
                                            strArray[index] = str22;
                                            index++;
                                            str23 = node2.ParentNode.ChildNodes[7].ChildNodes[5].InnerText.Replace("Ne Preporučujem (", "").Replace(")&nbsp;", "");
                                            strArray[index] = str23;
                                            index++;
                                            str24 = node2.ParentNode.ChildNodes[1].InnerText;
                                            str25 = node2.ParentNode.ChildNodes[3].InnerText;
                                            strArray[index] = str25 + " - " + str24;
                                            index++;
                                            strArray[index] = node2.InnerText;
                                            index++;
                                        }
                                        catch
                                        {
                                        }
                                    }
                                    try
                                    {
                                        foreach (HtmlNode node3 in (IEnumerable<HtmlNode>) document2.DocumentNode.SelectNodes("//a[@href='" + str3 + "?page=3']"))
                                        {
                                            if (!node3.InnerHtml.Contains("stranica"))
                                            {
                                                string str27;
                                                using (WebClient client3 = new WebClient())
                                                {
                                                    client3.Encoding = Encoding.UTF8;
                                                    str27 = client3.DownloadString(address + "?page=3");
                                                    client3.Dispose();
                                                }
                                                HtmlAgilityPack.HtmlDocument document3 = new HtmlAgilityPack.HtmlDocument();
                                                document3.LoadHtml(str27);
                                                foreach (HtmlNode node4 in (IEnumerable<HtmlNode>) document3.DocumentNode.SelectNodes("//p[@itemprop='commentText']"))
                                                {
                                                    try
                                                    {
                                                        strArray[index] = node4.ParentNode.ChildNodes[9].Attributes[0].Value;
                                                        index++;
                                                        str22 = node4.ParentNode.ChildNodes[7].ChildNodes[1].InnerText.Replace("Preporučujem (", "").Replace(")&nbsp;", "");
                                                        strArray[index] = str22;
                                                        index++;
                                                        str23 = node4.ParentNode.ChildNodes[7].ChildNodes[5].InnerText.Replace("Ne Preporučujem (", "").Replace(")&nbsp;", "");
                                                        strArray[index] = str23;
                                                        index++;
                                                        str24 = node4.ParentNode.ChildNodes[1].InnerText;
                                                        str25 = node4.ParentNode.ChildNodes[3].InnerText;
                                                        strArray[index] = str25 + " - " + str24;
                                                        index++;
                                                        strArray[index] = node4.InnerText;
                                                        index++;
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                                try
                                                {
                                                    foreach (HtmlNode node5 in (IEnumerable<HtmlNode>) document3.DocumentNode.SelectNodes("//a[@href='" + str3 + "?page=4']"))
                                                    {
                                                        if (!node5.InnerHtml.Contains("stranica"))
                                                        {
                                                            string str28;
                                                            using (WebClient client4 = new WebClient())
                                                            {
                                                                client4.Encoding = Encoding.UTF8;
                                                                str28 = client4.DownloadString(address + "?page=4");
                                                                client4.Dispose();
                                                            }
                                                            HtmlAgilityPack.HtmlDocument document4 = new HtmlAgilityPack.HtmlDocument();
                                                            document4.LoadHtml(str28);
                                                            foreach (HtmlNode node6 in (IEnumerable<HtmlNode>) document4.DocumentNode.SelectNodes("//p[@itemprop='commentText']"))
                                                            {
                                                                try
                                                                {
                                                                    strArray[index] = node6.ParentNode.ChildNodes[9].Attributes[0].Value;
                                                                    index++;
                                                                    strArray[index] = node6.ParentNode.ChildNodes[7].ChildNodes[1].InnerText.Replace("Preporučujem (", "").Replace(")&nbsp;", "");
                                                                    index++;
                                                                    strArray[index] = node6.ParentNode.ChildNodes[7].ChildNodes[5].InnerText.Replace("Ne Preporučujem (", "").Replace(")&nbsp;", "");
                                                                    index++;
                                                                    str24 = node6.ParentNode.ChildNodes[1].InnerText;
                                                                    str25 = node6.ParentNode.ChildNodes[3].InnerText;
                                                                    strArray[index] = str25 + " - " + str24;
                                                                    index++;
                                                                    strArray[index] = node6.InnerText;
                                                                    index++;
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
                                        }
                                    }
                                    catch
                                    {
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
                }
                e.Result = strArray;
            }
            catch
            {
            }
        }

        private void SkidanjeKomentara_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int num3;
            Cursor.Current = Cursors.WaitCursor;
            int num = 0;
            try
            {
                this.flowLayoutPanel1.Controls.Clear();
                this.flowLayoutPanel2.Controls.Clear();
                this.flowLayoutPanel3.Controls.Clear();
                this.flowLayoutPanel4.Controls.Clear();
                this.flowLayoutPanel5.Controls.Clear();
                this.flowLayoutPanel6.Controls.Clear();
                this.flowLayoutPanel7.Controls.Clear();
                this.flowLayoutPanel8.Controls.Clear();
                this.flowLayoutPanel9.Controls.Clear();
                this.flowLayoutPanel10.Controls.Clear();
                string[] result = (string[]) e.Result;
                int num2 = 0;
                for (num3 = 0; num3 < 0x4e20; num3 += 5)
                {
                    if (result[num3] == null)
                    {
                        break;
                    }
                    num++;
                    PrikazPojedinacnogKomentara komentara = new PrikazPojedinacnogKomentara();
                    foreach (Control control in this.flowLayoutPanel12.Controls)
                    {
                        komentara = (PrikazPojedinacnogKomentara) control;
                        if (result[num3] == komentara.IdKomentara)
                        {
                            int pl = 0;
                            try
                            {
                                pl = int.Parse(result[num3 + 1]);
                            }
                            catch
                            {
                            }
                            int mi = 0;
                            try
                            {
                                mi = int.Parse(result[num3 + 2]);
                            }
                            catch
                            {
                            }
                            komentara.AzurirajPreporucujem(pl, mi);
                            komentara.Utoku(2);
                            foreach (string str in this.Evidencija2233)
                            {
                                if (str == null)
                                {
                                    break;
                                }
                                if (str.Contains(result[num3]))
                                {
                                    if (str.EndsWith("#0"))
                                    {
                                        komentara.Utoku(0);
                                    }
                                    else
                                    {
                                        komentara.Utoku(1);
                                    }
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    if (((!this.KomentariBezOdgovora.Checked || !result[num3 + 4].StartsWith("@")) && (!this.OdgovoriNaKomentare.Checked || result[num3 + 4].StartsWith("@"))) && (!this.Prvih10Komentara.Checked || (num2 <= 0x13)))
                    {
                        if (this.AktivirajFiletriBodovi.Checked)
                        {
                            if (this.comboBox1.SelectedIndex == 0)
                            {
                                if (this.comboBox2.SelectedIndex == 0)
                                {
                                    try
                                    {
                                        if (int.Parse(this.comboBox3.SelectedItem.ToString()) != int.Parse(result[num3 + 1]))
                                        {
                                            continue;
                                        }
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                }
                                if (this.comboBox2.SelectedIndex == 1)
                                {
                                    try
                                    {
                                        if (int.Parse(this.comboBox3.SelectedItem.ToString()) < int.Parse(result[num3 + 1]))
                                        {
                                            continue;
                                        }
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                }
                                if (this.comboBox2.SelectedIndex == 2)
                                {
                                    try
                                    {
                                        if (int.Parse(this.comboBox3.SelectedItem.ToString()) > int.Parse(result[num3 + 1]))
                                        {
                                            continue;
                                        }
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                }
                            }
                            if (this.comboBox1.SelectedIndex == 1)
                            {
                                if (this.comboBox2.SelectedIndex == 0)
                                {
                                    try
                                    {
                                        if (int.Parse(this.comboBox3.SelectedItem.ToString()) != int.Parse(result[num3 + 2]))
                                        {
                                            continue;
                                        }
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                }
                                if (this.comboBox2.SelectedIndex == 1)
                                {
                                    try
                                    {
                                        if (int.Parse(this.comboBox3.SelectedItem.ToString()) < int.Parse(result[num3 + 2]))
                                        {
                                            continue;
                                        }
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                }
                                if (this.comboBox2.SelectedIndex == 2)
                                {
                                    try
                                    {
                                        if (int.Parse(this.comboBox3.SelectedItem.ToString()) > int.Parse(result[num3 + 2]))
                                        {
                                            continue;
                                        }
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                }
                            }
                            if (this.comboBox1.SelectedIndex == 2)
                            {
                                if (this.comboBox2.SelectedIndex == 0)
                                {
                                    try
                                    {
                                        if ((int.Parse(this.comboBox3.SelectedItem.ToString()) != int.Parse(result[num3 + 1])) || (int.Parse(this.comboBox3.SelectedItem.ToString()) != int.Parse(result[num3 + 2])))
                                        {
                                            continue;
                                        }
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                }
                                if (this.comboBox2.SelectedIndex == 1)
                                {
                                    try
                                    {
                                        if ((int.Parse(this.comboBox3.SelectedItem.ToString()) < int.Parse(result[num3 + 1])) || (int.Parse(this.comboBox3.SelectedItem.ToString()) < int.Parse(result[num3 + 2])))
                                        {
                                            continue;
                                        }
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                }
                                if (this.comboBox2.SelectedIndex == 2)
                                {
                                    try
                                    {
                                        if ((int.Parse(this.comboBox3.SelectedItem.ToString()) > int.Parse(result[num3 + 1])) || (int.Parse(this.comboBox3.SelectedItem.ToString()) > int.Parse(result[num3 + 2])))
                                        {
                                            continue;
                                        }
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                }
                            }
                        }
                        PrikazPojedinacnogKomentara komentara2 = new PrikazPojedinacnogKomentara();
                        int height = 90;
                        try
                        {
                            string[] strArray2 = result[num3 + 4].Split(new char[] { ' ' });
                            height += strArray2.Length;
                            foreach (string str2 in strArray2)
                            {
                                if (str2.Length > 6)
                                {
                                    height += 2;
                                }
                                if (this.LINK.Contains("b92.net") && str2.Contains("\r"))
                                {
                                    height += 20;
                                }
                            }
                        }
                        catch
                        {
                        }
                        komentara2.Size = new Size(komentara2.Width, height);
                        int plustekst = 0;
                        try
                        {
                            plustekst = int.Parse(result[num3 + 1]);
                        }
                        catch
                        {
                        }
                        int minustekst = 0;
                        try
                        {
                            minustekst = int.Parse(result[num3 + 2]);
                        }
                        catch
                        {
                        }
                        try
                        {
                            komentara2.Pocetak(result[num3 + 4], result[num3 + 3], plustekst, minustekst, result[num3]);
                            komentara2.IdKomentara = result[num3];
                            komentara2.WasClicked += new EventHandler<EventArgs>(this.novi_WasClicked);
                            komentara2.MinusWasClicked += new EventHandler<EventArgs>(this.novi_MinusWasClicked);
                            komentara2.PlusWasClicked += new EventHandler<EventArgs>(this.novi_PlusWasClicked);
                            komentara2.IdKomentaraWasClicked += new EventHandler<EventArgs>(this.novi_IdKomentaraWasClicked);
                            foreach (string str in this.Evidencija2233)
                            {
                                if (str == null)
                                {
                                    break;
                                }
                                if (str.Contains(result[num3]))
                                {
                                    if (str.EndsWith("#0"))
                                    {
                                        komentara2.Utoku(0);
                                    }
                                    else
                                    {
                                        komentara2.Utoku(1);
                                    }
                                    break;
                                }
                            }
                            if (num2 < 150)
                            {
                                this.flowLayoutPanel1.Controls.Add(komentara2);
                            }
                            else if ((num2 > 0x95) && (num2 < 300))
                            {
                                this.flowLayoutPanel2.Controls.Add(komentara2);
                            }
                            else if ((num2 > 0x12b) && (num2 < 450))
                            {
                                this.flowLayoutPanel3.Controls.Add(komentara2);
                            }
                            else if ((num2 > 0x1c1) && (num2 < 600))
                            {
                                this.flowLayoutPanel4.Controls.Add(komentara2);
                            }
                            else if ((num2 > 0x257) && (num2 < 750))
                            {
                                this.flowLayoutPanel5.Controls.Add(komentara2);
                            }
                            else if ((num2 > 0x2ed) && (num2 < 900))
                            {
                                this.flowLayoutPanel6.Controls.Add(komentara2);
                            }
                            else if ((num2 > 0x383) && (num2 < 0x41a))
                            {
                                this.flowLayoutPanel7.Controls.Add(komentara2);
                            }
                            else if ((num2 > 0x419) && (num2 < 0x4b0))
                            {
                                this.flowLayoutPanel8.Controls.Add(komentara2);
                            }
                            else if ((num2 > 0x4af) && (num2 < 0x546))
                            {
                                this.flowLayoutPanel9.Controls.Add(komentara2);
                            }
                            else if ((num2 > 0x545) && (num2 < 0x5dc))
                            {
                                this.flowLayoutPanel10.Controls.Add(komentara2);
                            }
                            else if ((num2 > 0x5db) && (num2 < 0x672))
                            {
                                this.flowLayoutPanel11.Controls.Add(komentara2);
                            }
                            num2++;
                        }
                        catch
                        {
                        }
                    }
                }
                if (num2 > 0x95)
                {
                    this.ultraTabControl1.Tabs[1].Visible = true;
                }
                else
                {
                    this.ultraTabControl1.Tabs[1].Visible = false;
                }
                if (num2 > 0x12b)
                {
                    this.ultraTabControl1.Tabs[2].Visible = true;
                }
                else
                {
                    this.ultraTabControl1.Tabs[2].Visible = false;
                }
                if (num2 > 0x1c1)
                {
                    this.ultraTabControl1.Tabs[3].Visible = true;
                }
                else
                {
                    this.ultraTabControl1.Tabs[3].Visible = false;
                }
                if (num2 > 0x257)
                {
                    this.ultraTabControl1.Tabs[4].Visible = true;
                }
                else
                {
                    this.ultraTabControl1.Tabs[4].Visible = false;
                }
                if (num2 > 0x2ed)
                {
                    this.ultraTabControl1.Tabs[5].Visible = true;
                }
                else
                {
                    this.ultraTabControl1.Tabs[5].Visible = false;
                }
                if (num2 > 0x383)
                {
                    this.ultraTabControl1.Tabs[6].Visible = true;
                }
                else
                {
                    this.ultraTabControl1.Tabs[6].Visible = false;
                }
                if (num2 > 0x419)
                {
                    this.ultraTabControl1.Tabs[7].Visible = true;
                }
                else
                {
                    this.ultraTabControl1.Tabs[7].Visible = false;
                }
                if (num2 > 0x4af)
                {
                    this.ultraTabControl1.Tabs[8].Visible = true;
                }
                else
                {
                    this.ultraTabControl1.Tabs[8].Visible = false;
                }
                if (num2 > 0x545)
                {
                    this.ultraTabControl1.Tabs[9].Visible = true;
                }
                else
                {
                    this.ultraTabControl1.Tabs[9].Visible = false;
                }
                if (num2 > 0x5db)
                {
                    this.ultraTabControl1.Tabs[10].Visible = true;
                }
                else
                {
                    this.ultraTabControl1.Tabs[10].Visible = false;
                }
            }
            catch
            {
            }
            this.label2.Text = num.ToString();
            this.brojvreme = 0;
            this.progressBar1.Value = 0;
            this.UcitavanjeKom.Enabled = true;
            this.UcitavanjeKom.Start();
            this.AzurirajSad.Visible = true;
            try
            {
                PrikazPojedinacnogKomentara activeControl = new PrikazPojedinacnogKomentara();
                for (num3 = 0; num3 < this.ultraTabControl1.Tabs.Count; num3++)
                {
                    if (this.ultraTabControl1.Tabs[num3].Active)
                    {
                        FlowLayoutPanel panel = (FlowLayoutPanel) this.ultraTabControl1.Tabs[num3].TabPage.Controls[0];
                        foreach (Control control2 in panel.Controls)
                        {
                            activeControl = (PrikazPojedinacnogKomentara) control2;
                            if (activeControl.IdKomentara == this.Privremeno.IdKomentara)
                            {
                                panel.ScrollControlIntoView(activeControl);
                                activeControl.OznaciKontrolu();
                                this.Privremeno = activeControl;
                                if (panel.VerticalScroll.Value > 500)
                                {
                                    panel.VerticalScroll.Value = (panel.VerticalScroll.Value + (panel.Size.Height / 2)) + (activeControl.Size.Height / 2);
                                }
                                break;
                            }
                        }
                        goto Label_0FB2;
                    }
                }
            }
            catch
            {
            }
        Label_0FB2:
            this.ogranicenjeenter = 0;
            Cursor.Current = Cursors.Default;
        }

        private void StaviUIzdvojeniTab_Click(object sender, EventArgs e)
        {
            try
            {
                PrikazPojedinacnogKomentara privremeno = new PrikazPojedinacnogKomentara();
                privremeno = this.Privremeno;
                this.flowLayoutPanel12.Controls.Add(privremeno);
                this.ultraTabControl1.Tabs[11].Active = true;
            }
            catch
            {
            }
        }

        private void taskbarpokazi_CheckedChanged(object sender, EventArgs e)
        {
            if (this.taskbarpokazi.Checked)
            {
                base.ShowInTaskbar = true;
            }
            else
            {
                base.ShowInTaskbar = false;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            base.Size = new Size(base.Width, this.VisinaProzora + this.trackBar1.Value);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            this.aktivirajAzuriranje = (this.trackBar2.Value * 6) - 1;
            this.brojvreme = 0;
            this.label1.Text = "Na svakih " + this.trackBar2.Value.ToString() + " minuta.";
            this.progressBar1.Value = 0;
            this.progressBar1.Maximum = (this.trackBar2.Value * 6) - 1;
        }

        private void UcitavanjeKom_Tick(object sender, EventArgs e)
        {
            if ((this.brojvreme == this.aktivirajAzuriranje) && (this.ogranicenjeenter == 0))
            {
                this.ogranicenjeenter = 1;
                this.UcitavanjeKom.Stop();
                this.UcitavanjeKom.Enabled = false;
                this.AzurirajSad.Visible = false;
                this.AktivirajSlanjeKomentara("OKET");
                this.SkidanjeKomentara.RunWorkerAsync(this.LINK);
            }
            else
            {
                this.progressBar1.PerformStep();
                this.brojvreme++;
            }
        }

        private void VestiPrikazRealnihKomentara_Shown(object sender, EventArgs e)
        {
            try
            {
                this.VisinaProzora = base.Size.Height;
                this.Text = this.NASLOV;
                this.pictureBox1.BackgroundImage = this.SLIKA;
                this.ogranicenjeenter = 1;
                this.AktivirajSlanjeKomentara("OKET");
                this.SkidanjeKomentara.RunWorkerAsync(this.LINK);
            }
            catch
            {
                MessageBox.Show("Dogodila se neka greska, pokusajte ponovo ili restartujte program.", "INFO");
                base.Close();
            }
        }

        public class PosaljiBrisanjeGlasanja : EventArgs
        {
            private readonly string KomentarK23;

            public PosaljiBrisanjeGlasanja(string adviseText)
            {
                this.KomentarK23 = adviseText;
            }

            public string DobijenKomentar2
            {
                get
                {
                    return this.KomentarK23;
                }
            }
        }

        public class PosaljiKomentar : EventArgs
        {
            private readonly string KomentarK2;

            public PosaljiKomentar(string adviseText)
            {
                this.KomentarK2 = adviseText;
            }

            public string DobijenKomentar2
            {
                get
                {
                    return this.KomentarK2;
                }
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

