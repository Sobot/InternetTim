namespace InternetTim
{
    using GemBox.Spreadsheet;
    using InternetTim.Bodovanje;
    using InternetTim.Dozvole;
    using InternetTim.Glasanje;
    using InternetTim.Izvestaji;
    using InternetTim.Izvestaji.UzivoIzvestaji;
    using InternetTim.Komande;
    using InternetTim.Komentari;
    using InternetTim.NovaVerzija;
    using InternetTim.Obavestenja;
    using InternetTim.Problem;
    using InternetTim.Properties;
    using InternetTim.Registracija;
    using InternetTim.SpajanjeKorisnika;
    using InternetTim.Startovanje;
    using InternetTim.Zastita;
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;
    using System.Deployment.Application;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class GlavniProzor : Form
    {
        private ToolStripMenuItem aktuelniZadaciToolStripMenuItem;
        private int BLICPokreniGlasanje = 0;
        private ToolStripMenuItem bodovanjeToolStripMenuItem;
        private int BrojacPU = 0;
        private int BrojUcitavanje = 0;
        private int CeoSat = 60;
        private ToolStripMenuItem chatSlanjeKomentaraToolStripMenuItem;
        private IContainer components = null;
        private ToolStripMenuItem dozvoleZaIzvestajeToolStripMenuItem;
        private ToolStripMenuItem dozvoleZaProgramToolStripMenuItem;
        private ToolStripMenuItem dozvoleZaSlanjeToolStripMenuItem;
        private ToolStripMenuItem gAktuelniZadaciToolStripMenuItem;
        private ContextMenuStrip GlavneOpcije;
        private int GlavniBrojac = 0;
        private string GNivoKorisnika = "";
        private ToolStripMenuItem gramatickeGreskeToolStripMenuItem;
        private ToolStripMenuItem grupeZaRadToolStripMenuItem;
        private string GSifra = "";
        private ToolStripMenuItem izveštajiSlanjaToolStripMenuItem;
        private ToolStripMenuItem izveštajiToolStripMenuItem;
        private ToolStripMenuItem komandeToolStripMenuItem;
        private ToolStripMenuItem komentariToolStripMenuItem;
        private ToolStripMenuItem mojiKomentariToolStripMenuItem;
        private NotifyIcon notifyIcon1;
        private ToolStripMenuItem obaveštenjaToolStripMenuItem;
        private ToolStripMenuItem opcijeZaZastituToolStripMenuItem;
        private ToolStripMenuItem oProgramuToolStripMenuItem;
        public string OpstinaID = "000000";
        private ToolStripMenuItem opštinskiIzveštajiToolStripMenuItem;
        private ToolStripMenuItem OZUgasiProgram;
        public string PersonalID = "000000";
        private System.Windows.Forms.Timer PocetnoUcitavanje;
        private int PokreniGlasanje = 10;
        private ToolStripMenuItem pokreniGlasanjeToolStripMenuItem;
        private ContextMenuStrip PorukaOtvoriZastitu;
        private ContextMenuStrip PorukaUcitavanjePodataka;
        private ToolStripMenuItem porukeNaServeruToolStripMenuItem;
        private ToolStripMenuItem pošaljiPorukuToolStripMenuItem;
        private int PotrebanRestart = 0;
        private ToolStripMenuItem preporukaToolStripMenuItem;
        private ToolStripMenuItem prijaviProblemToolStripMenuItem;
        private ToolStripMenuItem primljenePorukeToolStripMenuItem;
        private int ProveraObavestenja = 0x23;
        private int ProveraObavestenjaOpstina = 0x2d;
        private string putanjaFolder = "";
        private System.Windows.Forms.Timer RedovnoUcitavanje;
        private ToolStripMenuItem spajanjeKorisnikaToolStripMenuItem;
        private ToolStripMenuItem spisakKorisnikaToolStripMenuItem;
        private SlikeUcitavanje sta = new SlikeUcitavanje();
        private ToolStripMenuItem statsKorisniciBrojPoslatihIObjavljenihToolStripMenuItem;
        private ToolStripMenuItem tnaloziToolStripMenuItem;
        private ToolStripMenuItem twitterToolStripMenuItem;
        private ToolStripMenuItem ubaciProxyIProveriToolStripMenuItem;
        private ToolStripMenuItem učitavanjePodatakaToolStripMenuItem;
        private ToolStripMenuItem ugasiProgramToolStripMenuItem;
        private ToolStripMenuItem ukucajteSifruToolStripMenuItem;
        private ToolStripMenuItem uzivoIzvestajiFullToolStripMenuItem;
        private string verzija = "00000";
        private ToolStripMenuItem vestiIStatistikaSlanjaToolStripMenuItem;
        private ToolStripMenuItem zadnjaAktivnostKorisnikaToolStripMenuItem;

        public GlavniProzor()
        {
            this.InitializeComponent();
            SpreadsheetInfo.SetLicense("EQU1-4YRI-KEYA-HERE");
        }

        private void ad_CheckForUpdateCompleted(object sender, CheckForUpdateCompletedEventArgs e)
        {
            try
            {
                if (e.UpdateAvailable)
                {
                    this.PotrebanRestart = 1;
                }
            }
            catch
            {
            }
        }

        private void akt_FormClosed(object sender, FormClosedEventArgs e)
        {
            base.Close();
        }

        private void aktuelniZadaciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelFile file = new ExcelFile();
                file.LoadXls(this.putanjaFolder + @"\vote.jpg");
                file.Worksheets[0].Cells[0].Value = "pokrenivesti";
                file.SaveXls(this.putanjaFolder + @"\vote.jpg");
                Process.Start("InternetTim.exe");
            }
            catch
            {
                MessageBox.Show("Dogodila se greška u programu, probajte ponovo ili restartujte program.", "INFO");
            }
        }

        private void bodovanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SredjivanjeBodovanja().Show();
        }

        private void chatSlanjeKomentaraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelFile file = new ExcelFile();
                file.LoadXls(this.putanjaFolder + @"\vote.jpg");
                file.Worksheets[0].Cells[0].Value = "pokrenichat1";
                file.SaveXls(this.putanjaFolder + @"\vote.jpg");
                Process.Start("InternetTim.exe");
            }
            catch
            {
                MessageBox.Show("Dogodila se greška u programu, probajte ponovo ili restartujte program.", "INFO");
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

        private void DoslaObavestenja()
        {
            try
            {
                string[] strArray;
                ExcelFile file = new ExcelFile();
                if (System.IO.File.Exists(this.putanjaFolder + @"\obav.jpg"))
                {
                    file.LoadXls(this.putanjaFolder + @"\obav.jpg");
                    strArray = new string[file.Worksheets[0].Rows.Count + 1];
                    for (int i = 0; i < file.Worksheets[0].Rows.Count; i++)
                    {
                        strArray[i] = file.Worksheets[0].Rows[i].Cells[0].Value.ToString();
                    }
                }
                else
                {
                    file.Worksheets.Add("Data");
                    strArray = new string[30];
                    file.SaveXls(this.putanjaFolder + @"\obav.jpg");
                }
                string s = new WebClient().DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Obavestenja/GetMessagesForAll.php");
                if (!s.Contains("NEMA PORUKA"))
                {
                    JsonTextReader reader = new JsonTextReader(new StringReader(s));
                    int num2 = 0;
                    string str2 = "";
                    string str3 = "";
                    string str4 = "";
                    while (reader.Read())
                    {
                        if ((reader.Value == null) || !(reader.Value.ToString() != "Korisnik"))
                        {
                            continue;
                        }
                        switch (num2)
                        {
                            case 0:
                                str4 = reader.Value.ToString();
                                break;

                            case 1:
                                str2 = reader.Value.ToString().Replace("[[]]", "&");
                                break;

                            case 2:
                                str3 = reader.Value.ToString().Replace("[[]]", "&");
                                break;
                        }
                        num2++;
                        if (num2 == 3)
                        {
                            int num3 = 0;
                            for (int j = 0; j < strArray.Length; j++)
                            {
                                try
                                {
                                    if (strArray[j] == str4)
                                    {
                                        num3++;
                                        break;
                                    }
                                }
                                catch
                                {
                                    break;
                                }
                            }
                            if (num3 == 0)
                            {
                                new PrikaziObavestenje { Naslov = str2, Tekst = str3 }.Show();
                                ExcelFile file2 = new ExcelFile();
                                file2.LoadXls(this.putanjaFolder + @"\obav.jpg");
                                int count = file2.Worksheets[0].Rows.Count;
                                file2.Worksheets[0].Rows[count].Cells[0].Value = str4;
                                file2.Worksheets[0].Rows[count].Cells[1].Value = str2;
                                file2.Worksheets[0].Rows[count].Cells[2].Value = str3;
                                if (count > 100)
                                {
                                    for (int k = 0; k < 30; k++)
                                    {
                                        file2.Worksheets[0].Rows[0].Delete();
                                    }
                                }
                                file2.SaveXls(this.putanjaFolder + @"\obav.jpg");
                            }
                            num2 = 0;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void DoslaObavestenjaOpstina()
        {
            try
            {
                string[] strArray;
                ExcelFile file = new ExcelFile();
                if (System.IO.File.Exists(this.putanjaFolder + @"\obav.jpg"))
                {
                    file.LoadXls(this.putanjaFolder + @"\obav.jpg");
                    strArray = new string[file.Worksheets[0].Rows.Count + 1];
                    for (int i = 0; i < file.Worksheets[0].Rows.Count; i++)
                    {
                        strArray[i] = file.Worksheets[0].Rows[i].Cells[0].Value.ToString();
                    }
                }
                else
                {
                    file.Worksheets.Add("Data");
                    strArray = new string[30];
                    file.SaveXls(this.putanjaFolder + @"\obav.jpg");
                }
                string s = new WebClient().DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Obavestenja/GetMessagesForRegion.php?Opstina=" + this.OpstinaID);
                if (!s.Contains("NEMA PORUKA"))
                {
                    JsonTextReader reader = new JsonTextReader(new StringReader(s));
                    int num2 = 0;
                    string str2 = "";
                    string str3 = "";
                    string str4 = "";
                    while (reader.Read())
                    {
                        if ((reader.Value == null) || !(reader.Value.ToString() != "Korisnik"))
                        {
                            continue;
                        }
                        switch (num2)
                        {
                            case 0:
                                str4 = reader.Value.ToString();
                                break;

                            case 1:
                                str2 = reader.Value.ToString().Replace("[[]]", "&");
                                break;

                            case 2:
                                str3 = reader.Value.ToString().Replace("[[]]", "&");
                                break;
                        }
                        num2++;
                        if (num2 == 3)
                        {
                            int num3 = 0;
                            for (int j = 0; j < strArray.Length; j++)
                            {
                                try
                                {
                                    if (strArray[j] == str4)
                                    {
                                        num3++;
                                        break;
                                    }
                                }
                                catch
                                {
                                    break;
                                }
                            }
                            if (num3 == 0)
                            {
                                new PrikaziObavestenje { Naslov = str2, Tekst = str3 }.Show();
                                ExcelFile file2 = new ExcelFile();
                                file2.LoadXls(this.putanjaFolder + @"\obav.jpg");
                                int count = file2.Worksheets[0].Rows.Count;
                                file2.Worksheets[0].Rows[count].Cells[0].Value = str4;
                                file2.Worksheets[0].Rows[count].Cells[1].Value = str2;
                                file2.Worksheets[0].Rows[count].Cells[2].Value = str3;
                                if (count > 100)
                                {
                                    for (int k = 0; k < 30; k++)
                                    {
                                        file2.Worksheets[0].Rows[0].Delete();
                                    }
                                }
                                file2.SaveXls(this.putanjaFolder + @"\obav.jpg");
                            }
                            num2 = 0;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void dozvoleZaIzvestajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new DozvoleZaOpstine().Show();
        }

        private void dozvoleZaProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new VidljivostOpcija().Show();
        }

        private void dozvoleZaSlanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PodesavanjeOpstina().Show();
        }

        private void glapokre_FormClosed(object sender, FormClosedEventArgs e)
        {
            base.Close();
        }

        private void GlavneOpcije_Opening(object sender, CancelEventArgs e)
        {
            this.GlavneOpcije.Show((int) ((((Screen.PrimaryScreen.WorkingArea.Width - this.GlavneOpcije.Size.Width) - this.komentariToolStripMenuItem.Size.Width) - this.aktuelniZadaciToolStripMenuItem.Size.Width) - 10), (int) ((Screen.PrimaryScreen.WorkingArea.Height - this.GlavneOpcije.Size.Height) - 10));
        }

        private void GlavniProzor_Load(object sender, EventArgs e)
        {
        }

        private void GlavniProzor_Shown(object sender, EventArgs e)
        {
            string pathRoot = Path.GetPathRoot(Environment.SystemDirectory);
            this.putanjaFolder = pathRoot + "InternetTim";
            if (!Directory.Exists(this.putanjaFolder))
            {
                Directory.CreateDirectory(this.putanjaFolder).Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }
            if (System.IO.File.Exists(this.putanjaFolder + @"\reg.jpg"))
            {
                ExcelFile file = new ExcelFile();
                file.LoadXls(this.putanjaFolder + @"\reg.jpg");
                this.PersonalID = file.Worksheets[0].Cells[0, 0].Value.ToString();
                this.OpstinaID = file.Worksheets[0].Cells[3, 0].Value.ToString();
                int num = 0;
                if (System.IO.File.Exists(this.putanjaFolder + @"\vote.jpg"))
                {
                    ExcelFile file2 = new ExcelFile();
                    file2.LoadXls(this.putanjaFolder + @"\vote.jpg");
                    try
                    {
                        switch (file2.Worksheets[0].Cells[0].Value.ToString())
                        {
                            case "pokreniglasanje":
                            {
                                num = 1;
                                UnosLinkaZaGlasanje glasanje = new UnosLinkaZaGlasanje {
                                    PersonalID = this.PersonalID
                                };
                                glasanje.FormClosed += new FormClosedEventHandler(this.GNK_FormClosed);
                                glasanje.Show();
                                file2.Worksheets[0].Cells[0].Value = "a";
                                file2.SaveXls(this.putanjaFolder + @"\vote.jpg");
                                break;
                            }
                            case "pokrenivesti":
                                try
                                {
                                    WebClient client = new WebClient();
                                    string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/NivoKorisnika/GetUsersInfoById.php?";
                                    address = address + "Id=" + this.PersonalID;
                                    JsonTextReader reader = new JsonTextReader(new StringReader(client.DownloadString(address)));
                                    int num2 = 0;
                                    string str5 = "";
                                    while (reader.Read())
                                    {
                                        if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                                        {
                                            if (num2 == 0)
                                            {
                                                str5 = reader.Value.ToString();
                                            }
                                            num2++;
                                            if (num2 == 1)
                                            {
                                                num2 = 0;
                                                break;
                                            }
                                        }
                                    }
                                    this.GNivoKorisnika = str5;
                                    num = 1;
                                    AktuelniZadaci zadaci = new AktuelniZadaci();
                                    zadaci.FormClosed += new FormClosedEventHandler(this.akt_FormClosed);
                                    zadaci.PersonalID = this.PersonalID;
                                    zadaci.NivoKorisnika = this.GNivoKorisnika;
                                    zadaci.Show();
                                    file2.Worksheets[0].Cells[0].Value = "a";
                                    file2.SaveXls(this.putanjaFolder + @"\vote.jpg");
                                }
                                catch
                                {
                                }
                                break;

                            case "pokrenichat1":
                            {
                                num = 1;
                                Chat1 chat = new Chat1 {
                                    PersonalID = this.PersonalID
                                };
                                chat.FormClosed += new FormClosedEventHandler(this.novichat_FormClosed);
                                chat.Show();
                                file2.Worksheets[0].Cells[0].Value = "a";
                                file2.SaveXls(this.putanjaFolder + @"\vote.jpg");
                                break;
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                else
                {
                    ExcelFile file3 = new ExcelFile();
                    file3.Worksheets.Add("Data");
                    file3.SaveXls(this.putanjaFolder + @"\vote.jpg");
                }
                if (((this.PersonalID != "000000") && (this.PersonalID.Length > 2)) && (num == 0))
                {
                    this.notifyIcon1.Visible = true;
                    this.PocetnoUcitavanje.Enabled = true;
                    this.PocetnoUcitavanje.Start();
                    this.UcitaSlika();
                }
                else
                {
                    this.notifyIcon1.Visible = false;
                }
            }
            else
            {
                this.PokreniRegistraciju();
            }
        }

        private void GNK_FormClosed(object sender, FormClosedEventArgs e)
        {
            base.Close();
        }

        private void gramatickeGreskeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GramatickeGreske().Show();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(GlavniProzor));
            this.notifyIcon1 = new NotifyIcon(this.components);
            this.PorukaUcitavanjePodataka = new ContextMenuStrip(this.components);
            this.učitavanjePodatakaToolStripMenuItem = new ToolStripMenuItem();
            this.GlavneOpcije = new ContextMenuStrip(this.components);
            this.komandeToolStripMenuItem = new ToolStripMenuItem();
            this.dozvoleZaProgramToolStripMenuItem = new ToolStripMenuItem();
            this.spajanjeKorisnikaToolStripMenuItem = new ToolStripMenuItem();
            this.bodovanjeToolStripMenuItem = new ToolStripMenuItem();
            this.izveštajiToolStripMenuItem = new ToolStripMenuItem();
            this.spisakKorisnikaToolStripMenuItem = new ToolStripMenuItem();
            this.zadnjaAktivnostKorisnikaToolStripMenuItem = new ToolStripMenuItem();
            this.statsKorisniciBrojPoslatihIObjavljenihToolStripMenuItem = new ToolStripMenuItem();
            this.uzivoIzvestajiFullToolStripMenuItem = new ToolStripMenuItem();
            this.vestiIStatistikaSlanjaToolStripMenuItem = new ToolStripMenuItem();
            this.grupeZaRadToolStripMenuItem = new ToolStripMenuItem();
            this.komentariToolStripMenuItem = new ToolStripMenuItem();
            this.aktuelniZadaciToolStripMenuItem = new ToolStripMenuItem();
            this.mojiKomentariToolStripMenuItem = new ToolStripMenuItem();
            this.izveštajiSlanjaToolStripMenuItem = new ToolStripMenuItem();
            this.opštinskiIzveštajiToolStripMenuItem = new ToolStripMenuItem();
            this.gramatickeGreskeToolStripMenuItem = new ToolStripMenuItem();
            this.dozvoleZaIzvestajeToolStripMenuItem = new ToolStripMenuItem();
            this.chatSlanjeKomentaraToolStripMenuItem = new ToolStripMenuItem();
            this.preporukaToolStripMenuItem = new ToolStripMenuItem();
            this.gAktuelniZadaciToolStripMenuItem = new ToolStripMenuItem();
            this.pokreniGlasanjeToolStripMenuItem = new ToolStripMenuItem();
            this.ubaciProxyIProveriToolStripMenuItem = new ToolStripMenuItem();
            this.twitterToolStripMenuItem = new ToolStripMenuItem();
            this.tnaloziToolStripMenuItem = new ToolStripMenuItem();
            this.obaveštenjaToolStripMenuItem = new ToolStripMenuItem();
            this.primljenePorukeToolStripMenuItem = new ToolStripMenuItem();
            this.pošaljiPorukuToolStripMenuItem = new ToolStripMenuItem();
            this.dozvoleZaSlanjeToolStripMenuItem = new ToolStripMenuItem();
            this.porukeNaServeruToolStripMenuItem = new ToolStripMenuItem();
            this.prijaviProblemToolStripMenuItem = new ToolStripMenuItem();
            this.opcijeZaZastituToolStripMenuItem = new ToolStripMenuItem();
            this.oProgramuToolStripMenuItem = new ToolStripMenuItem();
            this.ugasiProgramToolStripMenuItem = new ToolStripMenuItem();
            this.PocetnoUcitavanje = new System.Windows.Forms.Timer(this.components);
            this.RedovnoUcitavanje = new System.Windows.Forms.Timer(this.components);
            this.PorukaOtvoriZastitu = new ContextMenuStrip(this.components);
            this.ukucajteSifruToolStripMenuItem = new ToolStripMenuItem();
            this.OZUgasiProgram = new ToolStripMenuItem();
            this.PorukaUcitavanjePodataka.SuspendLayout();
            this.GlavneOpcije.SuspendLayout();
            this.PorukaOtvoriZastitu.SuspendLayout();
            base.SuspendLayout();
            this.notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
            this.notifyIcon1.BalloonTipText = "Startovanje aplikacije";
            this.notifyIcon1.BalloonTipTitle = "SkyNet";
            this.notifyIcon1.ContextMenuStrip = this.PorukaUcitavanjePodataka;
            this.notifyIcon1.Icon = (Icon) manager.GetObject("notifyIcon1.Icon");
            this.notifyIcon1.Text = "SkyNet";
            this.PorukaUcitavanjePodataka.Items.AddRange(new ToolStripItem[] { this.učitavanjePodatakaToolStripMenuItem });
            this.PorukaUcitavanjePodataka.Name = "PorukaUcitavanjePodataka";
            this.PorukaUcitavanjePodataka.Size = new Size(0xb6, 0x1a);
            this.učitavanjePodatakaToolStripMenuItem.BackColor = Color.Red;
            this.učitavanjePodatakaToolStripMenuItem.ForeColor = Color.White;
            this.učitavanjePodatakaToolStripMenuItem.Name = "učitavanjePodatakaToolStripMenuItem";
            this.učitavanjePodatakaToolStripMenuItem.Size = new Size(0xb5, 0x16);
            this.učitavanjePodatakaToolStripMenuItem.Text = "Učitavanje podataka";
            this.GlavneOpcije.Items.AddRange(new ToolStripItem[] { this.komandeToolStripMenuItem, this.dozvoleZaProgramToolStripMenuItem, this.spajanjeKorisnikaToolStripMenuItem, this.bodovanjeToolStripMenuItem, this.izveštajiToolStripMenuItem, this.grupeZaRadToolStripMenuItem, this.obaveštenjaToolStripMenuItem, this.prijaviProblemToolStripMenuItem, this.opcijeZaZastituToolStripMenuItem, this.oProgramuToolStripMenuItem, this.ugasiProgramToolStripMenuItem });
            this.GlavneOpcije.Name = "GlavneOpcije";
            this.GlavneOpcije.ShowImageMargin = false;
            this.GlavneOpcije.Size = new Size(0x9b, 0x10c);
            this.GlavneOpcije.Opening += new CancelEventHandler(this.GlavneOpcije_Opening);
            this.komandeToolStripMenuItem.BackColor = Color.SandyBrown;
            this.komandeToolStripMenuItem.Name = "komandeToolStripMenuItem";
            this.komandeToolStripMenuItem.Size = new Size(0x9a, 0x16);
            this.komandeToolStripMenuItem.Text = "Komande";
            this.komandeToolStripMenuItem.Visible = false;
            this.komandeToolStripMenuItem.Click += new EventHandler(this.komandeToolStripMenuItem_Click);
            this.dozvoleZaProgramToolStripMenuItem.BackColor = Color.Olive;
            this.dozvoleZaProgramToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.dozvoleZaProgramToolStripMenuItem.Name = "dozvoleZaProgramToolStripMenuItem";
            this.dozvoleZaProgramToolStripMenuItem.Size = new Size(0x9a, 0x16);
            this.dozvoleZaProgramToolStripMenuItem.Text = "Dozvole za program";
            this.dozvoleZaProgramToolStripMenuItem.Visible = false;
            this.dozvoleZaProgramToolStripMenuItem.Click += new EventHandler(this.dozvoleZaProgramToolStripMenuItem_Click);
            this.spajanjeKorisnikaToolStripMenuItem.BackColor = Color.Red;
            this.spajanjeKorisnikaToolStripMenuItem.Name = "spajanjeKorisnikaToolStripMenuItem";
            this.spajanjeKorisnikaToolStripMenuItem.Size = new Size(0x9a, 0x16);
            this.spajanjeKorisnikaToolStripMenuItem.Text = "Spajanje korisnika";
            this.spajanjeKorisnikaToolStripMenuItem.Visible = false;
            this.spajanjeKorisnikaToolStripMenuItem.Click += new EventHandler(this.spajanjeKorisnikaToolStripMenuItem_Click);
            this.bodovanjeToolStripMenuItem.BackColor = Color.Sienna;
            this.bodovanjeToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.bodovanjeToolStripMenuItem.Name = "bodovanjeToolStripMenuItem";
            this.bodovanjeToolStripMenuItem.Size = new Size(0x9a, 0x16);
            this.bodovanjeToolStripMenuItem.Text = "Bodovanje";
            this.bodovanjeToolStripMenuItem.Visible = false;
            this.bodovanjeToolStripMenuItem.Click += new EventHandler(this.bodovanjeToolStripMenuItem_Click);
            this.izveštajiToolStripMenuItem.BackColor = SystemColors.ButtonShadow;
            this.izveštajiToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.izveštajiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.spisakKorisnikaToolStripMenuItem, this.zadnjaAktivnostKorisnikaToolStripMenuItem, this.statsKorisniciBrojPoslatihIObjavljenihToolStripMenuItem, this.uzivoIzvestajiFullToolStripMenuItem });
            this.izveštajiToolStripMenuItem.Name = "izveštajiToolStripMenuItem";
            this.izveštajiToolStripMenuItem.Size = new Size(0x9a, 0x16);
            this.izveštajiToolStripMenuItem.Text = "Izveštaji";
            this.izveštajiToolStripMenuItem.Visible = false;
            this.spisakKorisnikaToolStripMenuItem.BackColor = Color.White;
            this.spisakKorisnikaToolStripMenuItem.Name = "spisakKorisnikaToolStripMenuItem";
            this.spisakKorisnikaToolStripMenuItem.Size = new Size(0x12f, 0x16);
            this.spisakKorisnikaToolStripMenuItem.Text = "Spisak korisnika";
            this.spisakKorisnikaToolStripMenuItem.Click += new EventHandler(this.spisakKorisnikaToolStripMenuItem_Click);
            this.zadnjaAktivnostKorisnikaToolStripMenuItem.BackColor = Color.White;
            this.zadnjaAktivnostKorisnikaToolStripMenuItem.Name = "zadnjaAktivnostKorisnikaToolStripMenuItem";
            this.zadnjaAktivnostKorisnikaToolStripMenuItem.Size = new Size(0x12f, 0x16);
            this.zadnjaAktivnostKorisnikaToolStripMenuItem.Text = "Zadnja aktivnost korisnika";
            this.zadnjaAktivnostKorisnikaToolStripMenuItem.Click += new EventHandler(this.zadnjaAktivnostKorisnikaToolStripMenuItem_Click);
            this.statsKorisniciBrojPoslatihIObjavljenihToolStripMenuItem.BackColor = Color.White;
            this.statsKorisniciBrojPoslatihIObjavljenihToolStripMenuItem.Name = "statsKorisniciBrojPoslatihIObjavljenihToolStripMenuItem";
            this.statsKorisniciBrojPoslatihIObjavljenihToolStripMenuItem.Size = new Size(0x12f, 0x16);
            this.statsKorisniciBrojPoslatihIObjavljenihToolStripMenuItem.Text = "[Od-Do] Prijavljeni - Objavljeni - Bodovanje";
            this.statsKorisniciBrojPoslatihIObjavljenihToolStripMenuItem.Click += new EventHandler(this.statsKorisniciBrojPoslatihIObjavljenihToolStripMenuItem_Click);
            this.uzivoIzvestajiFullToolStripMenuItem.BackColor = Color.Silver;
            this.uzivoIzvestajiFullToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.vestiIStatistikaSlanjaToolStripMenuItem });
            this.uzivoIzvestajiFullToolStripMenuItem.Name = "uzivoIzvestajiFullToolStripMenuItem";
            this.uzivoIzvestajiFullToolStripMenuItem.Size = new Size(0x12f, 0x16);
            this.uzivoIzvestajiFullToolStripMenuItem.Text = "Uživo izveštaji";
            this.vestiIStatistikaSlanjaToolStripMenuItem.BackColor = Color.White;
            this.vestiIStatistikaSlanjaToolStripMenuItem.Name = "vestiIStatistikaSlanjaToolStripMenuItem";
            this.vestiIStatistikaSlanjaToolStripMenuItem.Size = new Size(0xf9, 0x16);
            this.vestiIStatistikaSlanjaToolStripMenuItem.Text = "Vesti - statistika slanja komentara";
            this.vestiIStatistikaSlanjaToolStripMenuItem.Click += new EventHandler(this.vestiIStatistikaSlanjaToolStripMenuItem_Click);
            this.grupeZaRadToolStripMenuItem.BackColor = Color.White;
            this.grupeZaRadToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.grupeZaRadToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.komentariToolStripMenuItem, this.preporukaToolStripMenuItem, this.twitterToolStripMenuItem });
            this.grupeZaRadToolStripMenuItem.Name = "grupeZaRadToolStripMenuItem";
            this.grupeZaRadToolStripMenuItem.Size = new Size(0x9a, 0x16);
            this.grupeZaRadToolStripMenuItem.Text = "Radne grupe";
            this.grupeZaRadToolStripMenuItem.Visible = false;
            this.komentariToolStripMenuItem.BackColor = Color.White;
            this.komentariToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.komentariToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.aktuelniZadaciToolStripMenuItem, this.mojiKomentariToolStripMenuItem, this.izveštajiSlanjaToolStripMenuItem, this.opštinskiIzveštajiToolStripMenuItem, this.gramatickeGreskeToolStripMenuItem, this.dozvoleZaIzvestajeToolStripMenuItem, this.chatSlanjeKomentaraToolStripMenuItem });
            this.komentariToolStripMenuItem.Name = "komentariToolStripMenuItem";
            this.komentariToolStripMenuItem.Size = new Size(0xc2, 0x16);
            this.komentariToolStripMenuItem.Text = "Slanje komentara";
            this.komentariToolStripMenuItem.Visible = false;
            this.aktuelniZadaciToolStripMenuItem.BackColor = Color.White;
            this.aktuelniZadaciToolStripMenuItem.Name = "aktuelniZadaciToolStripMenuItem";
            this.aktuelniZadaciToolStripMenuItem.Size = new Size(0xb1, 0x16);
            this.aktuelniZadaciToolStripMenuItem.Text = "Aktuelni zadaci";
            this.aktuelniZadaciToolStripMenuItem.Click += new EventHandler(this.aktuelniZadaciToolStripMenuItem_Click);
            this.mojiKomentariToolStripMenuItem.BackColor = Color.White;
            this.mojiKomentariToolStripMenuItem.Name = "mojiKomentariToolStripMenuItem";
            this.mojiKomentariToolStripMenuItem.Size = new Size(0xb1, 0x16);
            this.mojiKomentariToolStripMenuItem.Text = "Moji komentari";
            this.mojiKomentariToolStripMenuItem.Visible = false;
            this.mojiKomentariToolStripMenuItem.Click += new EventHandler(this.mojiKomentariToolStripMenuItem_Click);
            this.izveštajiSlanjaToolStripMenuItem.BackColor = Color.White;
            this.izveštajiSlanjaToolStripMenuItem.Name = "izveštajiSlanjaToolStripMenuItem";
            this.izveštajiSlanjaToolStripMenuItem.Size = new Size(0xb1, 0x16);
            this.izveštajiSlanjaToolStripMenuItem.Text = "Izveštaji slanja";
            this.izveštajiSlanjaToolStripMenuItem.Click += new EventHandler(this.izveštajiSlanjaToolStripMenuItem_Click);
            this.opštinskiIzveštajiToolStripMenuItem.BackColor = Color.RosyBrown;
            this.opštinskiIzveštajiToolStripMenuItem.Name = "opštinskiIzveštajiToolStripMenuItem";
            this.opštinskiIzveštajiToolStripMenuItem.Size = new Size(0xb1, 0x16);
            this.opštinskiIzveštajiToolStripMenuItem.Text = "Opštinski izveštaji";
            this.opštinskiIzveštajiToolStripMenuItem.Visible = false;
            this.opštinskiIzveštajiToolStripMenuItem.Click += new EventHandler(this.opštinskiIzveštajiToolStripMenuItem_Click);
            this.gramatickeGreskeToolStripMenuItem.BackColor = Color.LightGray;
            this.gramatickeGreskeToolStripMenuItem.Name = "gramatickeGreskeToolStripMenuItem";
            this.gramatickeGreskeToolStripMenuItem.Size = new Size(0xb1, 0x16);
            this.gramatickeGreskeToolStripMenuItem.Text = "Gramatičke greške";
            this.gramatickeGreskeToolStripMenuItem.Visible = false;
            this.gramatickeGreskeToolStripMenuItem.Click += new EventHandler(this.gramatickeGreskeToolStripMenuItem_Click);
            this.dozvoleZaIzvestajeToolStripMenuItem.BackColor = Color.Silver;
            this.dozvoleZaIzvestajeToolStripMenuItem.Name = "dozvoleZaIzvestajeToolStripMenuItem";
            this.dozvoleZaIzvestajeToolStripMenuItem.Size = new Size(0xb1, 0x16);
            this.dozvoleZaIzvestajeToolStripMenuItem.Text = "Dozvole za izveštaje";
            this.dozvoleZaIzvestajeToolStripMenuItem.Visible = false;
            this.dozvoleZaIzvestajeToolStripMenuItem.Click += new EventHandler(this.dozvoleZaIzvestajeToolStripMenuItem_Click);
            this.chatSlanjeKomentaraToolStripMenuItem.BackColor = Color.Coral;
            this.chatSlanjeKomentaraToolStripMenuItem.Name = "chatSlanjeKomentaraToolStripMenuItem";
            this.chatSlanjeKomentaraToolStripMenuItem.Size = new Size(0xb1, 0x16);
            this.chatSlanjeKomentaraToolStripMenuItem.Text = "Pričaonica";
            this.chatSlanjeKomentaraToolStripMenuItem.Visible = false;
            this.chatSlanjeKomentaraToolStripMenuItem.Click += new EventHandler(this.chatSlanjeKomentaraToolStripMenuItem_Click);
            this.preporukaToolStripMenuItem.BackColor = Color.White;
            this.preporukaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.gAktuelniZadaciToolStripMenuItem, this.pokreniGlasanjeToolStripMenuItem, this.ubaciProxyIProveriToolStripMenuItem });
            this.preporukaToolStripMenuItem.Name = "preporukaToolStripMenuItem";
            this.preporukaToolStripMenuItem.Size = new Size(0xc2, 0x16);
            this.preporukaToolStripMenuItem.Text = "Glasanje na komentare";
            this.preporukaToolStripMenuItem.Visible = false;
            this.gAktuelniZadaciToolStripMenuItem.BackColor = Color.White;
            this.gAktuelniZadaciToolStripMenuItem.Name = "gAktuelniZadaciToolStripMenuItem";
            this.gAktuelniZadaciToolStripMenuItem.Size = new Size(0xad, 0x16);
            this.gAktuelniZadaciToolStripMenuItem.Text = "Aktuelni zadaci";
            this.gAktuelniZadaciToolStripMenuItem.Visible = false;
            this.pokreniGlasanjeToolStripMenuItem.BackColor = Color.White;
            this.pokreniGlasanjeToolStripMenuItem.Name = "pokreniGlasanjeToolStripMenuItem";
            this.pokreniGlasanjeToolStripMenuItem.Size = new Size(0xad, 0x16);
            this.pokreniGlasanjeToolStripMenuItem.Text = "Pokreni glasanje";
            this.pokreniGlasanjeToolStripMenuItem.Click += new EventHandler(this.pokreniGlasanjeToolStripMenuItem_Click);
            this.ubaciProxyIProveriToolStripMenuItem.BackColor = Color.LightCoral;
            this.ubaciProxyIProveriToolStripMenuItem.Name = "ubaciProxyIProveriToolStripMenuItem";
            this.ubaciProxyIProveriToolStripMenuItem.Size = new Size(0xad, 0x16);
            this.ubaciProxyIProveriToolStripMenuItem.Text = "Unos proxy servera";
            this.ubaciProxyIProveriToolStripMenuItem.Visible = false;
            this.ubaciProxyIProveriToolStripMenuItem.Click += new EventHandler(this.ubaciProxyIProveriToolStripMenuItem_Click);
            this.twitterToolStripMenuItem.BackColor = Color.White;
            this.twitterToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.tnaloziToolStripMenuItem });
            this.twitterToolStripMenuItem.Name = "twitterToolStripMenuItem";
            this.twitterToolStripMenuItem.Size = new Size(0xc2, 0x16);
            this.twitterToolStripMenuItem.Text = "Twitter";
            this.twitterToolStripMenuItem.Visible = false;
            this.tnaloziToolStripMenuItem.BackColor = Color.FromArgb(0x2a, 0x7b, 0xb3);
            this.tnaloziToolStripMenuItem.ForeColor = Color.White;
            this.tnaloziToolStripMenuItem.Image = InternetTim.Properties.Resources.twitterlogo2;
            this.tnaloziToolStripMenuItem.Name = "tnaloziToolStripMenuItem";
            this.tnaloziToolStripMenuItem.Size = new Size(0x6b, 0x16);
            this.tnaloziToolStripMenuItem.Text = "Nalozi";
            this.tnaloziToolStripMenuItem.Click += new EventHandler(this.tnaloziToolStripMenuItem_Click);
            this.obaveštenjaToolStripMenuItem.BackColor = Color.White;
            this.obaveštenjaToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.obaveštenjaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.primljenePorukeToolStripMenuItem, this.pošaljiPorukuToolStripMenuItem, this.dozvoleZaSlanjeToolStripMenuItem, this.porukeNaServeruToolStripMenuItem });
            this.obaveštenjaToolStripMenuItem.Name = "obaveštenjaToolStripMenuItem";
            this.obaveštenjaToolStripMenuItem.Size = new Size(0x9a, 0x16);
            this.obaveštenjaToolStripMenuItem.Text = "Obaveštenja";
            this.primljenePorukeToolStripMenuItem.BackColor = Color.White;
            this.primljenePorukeToolStripMenuItem.Name = "primljenePorukeToolStripMenuItem";
            this.primljenePorukeToolStripMenuItem.Size = new Size(0xa8, 0x16);
            this.primljenePorukeToolStripMenuItem.Text = "Primljene poruke";
            this.primljenePorukeToolStripMenuItem.Click += new EventHandler(this.primljenePorukeToolStripMenuItem_Click);
            this.pošaljiPorukuToolStripMenuItem.BackColor = Color.Gainsboro;
            this.pošaljiPorukuToolStripMenuItem.Name = "pošaljiPorukuToolStripMenuItem";
            this.pošaljiPorukuToolStripMenuItem.Size = new Size(0xa8, 0x16);
            this.pošaljiPorukuToolStripMenuItem.Text = "Pošalji poruku";
            this.pošaljiPorukuToolStripMenuItem.Visible = false;
            this.pošaljiPorukuToolStripMenuItem.Click += new EventHandler(this.pošaljiPorukuToolStripMenuItem_Click);
            this.dozvoleZaSlanjeToolStripMenuItem.BackColor = Color.LightGray;
            this.dozvoleZaSlanjeToolStripMenuItem.Name = "dozvoleZaSlanjeToolStripMenuItem";
            this.dozvoleZaSlanjeToolStripMenuItem.Size = new Size(0xa8, 0x16);
            this.dozvoleZaSlanjeToolStripMenuItem.Text = "Dozvole za slanje";
            this.dozvoleZaSlanjeToolStripMenuItem.Visible = false;
            this.dozvoleZaSlanjeToolStripMenuItem.Click += new EventHandler(this.dozvoleZaSlanjeToolStripMenuItem_Click);
            this.porukeNaServeruToolStripMenuItem.BackColor = Color.Silver;
            this.porukeNaServeruToolStripMenuItem.Name = "porukeNaServeruToolStripMenuItem";
            this.porukeNaServeruToolStripMenuItem.Size = new Size(0xa8, 0x16);
            this.porukeNaServeruToolStripMenuItem.Text = "Poruke na serveru";
            this.porukeNaServeruToolStripMenuItem.Visible = false;
            this.porukeNaServeruToolStripMenuItem.Click += new EventHandler(this.porukeNaServeruToolStripMenuItem_Click);
            this.prijaviProblemToolStripMenuItem.BackColor = Color.White;
            this.prijaviProblemToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.prijaviProblemToolStripMenuItem.Name = "prijaviProblemToolStripMenuItem";
            this.prijaviProblemToolStripMenuItem.Size = new Size(0x9a, 0x16);
            this.prijaviProblemToolStripMenuItem.Text = "Prijavi problem";
            this.prijaviProblemToolStripMenuItem.Click += new EventHandler(this.prijaviProblemToolStripMenuItem_Click);
            this.opcijeZaZastituToolStripMenuItem.Name = "opcijeZaZastituToolStripMenuItem";
            this.opcijeZaZastituToolStripMenuItem.Size = new Size(0x9a, 0x16);
            this.opcijeZaZastituToolStripMenuItem.Text = "Zaštita programa";
            this.opcijeZaZastituToolStripMenuItem.Click += new EventHandler(this.opcijeZaZastituToolStripMenuItem_Click);
            this.oProgramuToolStripMenuItem.BackColor = Color.White;
            this.oProgramuToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.oProgramuToolStripMenuItem.Name = "oProgramuToolStripMenuItem";
            this.oProgramuToolStripMenuItem.Size = new Size(0x9a, 0x16);
            this.oProgramuToolStripMenuItem.Text = "O programu";
            this.oProgramuToolStripMenuItem.Visible = false;
            this.oProgramuToolStripMenuItem.Click += new EventHandler(this.oProgramuToolStripMenuItem_Click);
            this.ugasiProgramToolStripMenuItem.BackColor = Color.White;
            this.ugasiProgramToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.ugasiProgramToolStripMenuItem.Name = "ugasiProgramToolStripMenuItem";
            this.ugasiProgramToolStripMenuItem.Size = new Size(0x9a, 0x16);
            this.ugasiProgramToolStripMenuItem.Text = "Ugasi program";
            this.ugasiProgramToolStripMenuItem.Visible = false;
            this.ugasiProgramToolStripMenuItem.Click += new EventHandler(this.ugasiProgramToolStripMenuItem_Click);
            this.PocetnoUcitavanje.Interval = 0x5dc;
            this.PocetnoUcitavanje.Tick += new EventHandler(this.PocetnoUcitavanje_Tick);
            this.RedovnoUcitavanje.Interval = 0xea60;
            this.RedovnoUcitavanje.Tick += new EventHandler(this.RedovnoUcitavanje_Tick);
            this.PorukaOtvoriZastitu.Items.AddRange(new ToolStripItem[] { this.ukucajteSifruToolStripMenuItem, this.OZUgasiProgram });
            this.PorukaOtvoriZastitu.Name = "PorukaOtvoriZastitu";
            this.PorukaOtvoriZastitu.Size = new Size(0x1cd, 0x70);
            this.ukucajteSifruToolStripMenuItem.BackColor = Color.Maroon;
            this.ukucajteSifruToolStripMenuItem.Font = new Font("Segoe UI", 27.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.ukucajteSifruToolStripMenuItem.ForeColor = Color.White;
            this.ukucajteSifruToolStripMenuItem.Name = "ukucajteSifruToolStripMenuItem";
            this.ukucajteSifruToolStripMenuItem.Size = new Size(460, 0x36);
            this.ukucajteSifruToolStripMenuItem.Text = "Otvori potvrdu za šifru";
            this.ukucajteSifruToolStripMenuItem.Click += new EventHandler(this.ukucajteSifruToolStripMenuItem_Click);
            this.OZUgasiProgram.Font = new Font("Segoe UI", 27.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.OZUgasiProgram.Name = "OZUgasiProgram";
            this.OZUgasiProgram.Size = new Size(460, 0x36);
            this.OZUgasiProgram.Text = "Ugasi program";
            this.OZUgasiProgram.Click += new EventHandler(this.OZUgasiProgram_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackgroundImage = InternetTim.Properties.Resources.web5;
            this.BackgroundImageLayout = ImageLayout.Center;
            base.ClientSize = new Size(250, 250);
            this.DoubleBuffered = true;
            base.FormBorderStyle = FormBorderStyle.None;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Location = new Point(-500, -500);
            base.Name = "GlavniProzor";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.Manual;
            this.Text = "Internet tim";
            base.TopMost = true;
            base.Load += new EventHandler(this.GlavniProzor_Load);
            base.Shown += new EventHandler(this.GlavniProzor_Shown);
            this.PorukaUcitavanjePodataka.ResumeLayout(false);
            this.GlavneOpcije.ResumeLayout(false);
            this.PorukaOtvoriZastitu.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void izveštajiSlanjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MojiIzvestajiSlanja { ID = this.PersonalID }.Show();
        }

        private void IzvrsiKomandu(string komanda)
        {
            string personalID;
            WebClient client2;
            string str5;
            string str6;
            if (komanda.StartsWith("SPAJANJE"))
            {
                try
                {
                    string str = komanda.Replace("\r", "");
                    str = komanda.Replace("\n", "");
                    str = komanda.Replace("SPAJANJE*", "");
                    WebClient client = new WebClient();
                    string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Komande/SpajanjeKorisnika.php?";
                    address = (address + "IdOriginal=" + this.PersonalID) + "&IdNovi=" + str;
                    if (client.DownloadString(address).Contains("OKET"))
                    {
                        personalID = this.PersonalID;
                        this.PersonalID = str;
                        ExcelFile file = new ExcelFile();
                        file.LoadXls(this.putanjaFolder + @"\reg.jpg");
                        file.Worksheets[0].Cells[0, 0].Value = this.PersonalID;
                        file.SaveXls(this.putanjaFolder + @"\reg.jpg");
                        client2 = new WebClient();
                        str5 = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Komande/DeleteCommandsById.php?";
                        str5 = str5 + "Id=" + personalID;
                        str6 = client2.DownloadString(str5);
                        try
                        {
                            Application.Restart();
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
            if (komanda == "SACUVANIKOMENTARIBRISANJE")
            {
                try
                {
                    string str7 = this.putanjaFolder + @"\Vpic\MKB";
                    ExcelFile file2 = new ExcelFile();
                    file2.LoadXls(str7 + @"\pos.jpg");
                    int count = file2.Worksheets[0].Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        try
                        {
                            file2.Worksheets[0].Rows[0].Delete();
                        }
                        catch
                        {
                        }
                    }
                    file2.SaveXls(str7 + @"\pos.jpg");
                    personalID = this.PersonalID;
                    client2 = new WebClient();
                    str5 = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Komande/DeleteCommandsById.php?";
                    str5 = str5 + "Id=" + personalID;
                    str6 = client2.DownloadString(str5);
                }
                catch
                {
                }
            }
        }

        private void komandeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UradiKomandu().Show();
        }

        private void mojiKomentariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BazaMojiKomentari().Show();
        }

        private void novichat_FormClosed(object sender, FormClosedEventArgs e)
        {
            base.Close();
        }

        private void opcijeZaZastituToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AktivacijaZastitePrograma programa = new AktivacijaZastitePrograma();
            programa.FormClosed += new FormClosedEventHandler(this.zasss_FormClosed);
            programa.PersonalID = this.PersonalID;
            programa.Show();
            this.notifyIcon1.Visible = false;
        }

        private void oProgramuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new InfoOProgramu { verzija = this.verzija }.Show();
        }

        private void opštinskiIzveštajiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new OpstinskiIzvestaji { ID = this.PersonalID }.Show();
        }

        private void OZUgasiProgram_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void PocetnoUcitavanje_Tick(object sender, EventArgs e)
        {
            ApplicationDeployment currentDeployment;
            WebClient client2;
            string str4;
            JsonTextReader reader;
            int num3;
            this.PocetnoUcitavanje.Stop();
            this.PocetnoUcitavanje.Enabled = false;
            int num = 0;
            if (this.BrojacPU == 1)
            {
                try
                {
                    if (ApplicationDeployment.IsNetworkDeployed)
                    {
                        currentDeployment = ApplicationDeployment.CurrentDeployment;
                        this.verzija = currentDeployment.CurrentVersion.ToString();
                        this.oProgramuToolStripMenuItem.Visible = true;
                        if (System.IO.File.Exists(this.putanjaFolder + @"\reg.jpg"))
                        {
                            ExcelFile file = new ExcelFile();
                            file.LoadXls(this.putanjaFolder + @"\reg.jpg");
                            try
                            {
                                if (file.Worksheets[0].Cells[0, 1].Value.ToString() != this.verzija)
                                {
                                    file.Worksheets[0].Cells[0, 1].Value = this.verzija;
                                    file.SaveXls(this.putanjaFolder + @"\reg.jpg");
                                    this.UbaciRegistry();
                                }
                            }
                            catch
                            {
                                file.Worksheets[0].Cells[0, 1].Value = this.verzija;
                                file.SaveXls(this.putanjaFolder + @"\reg.jpg");
                                this.UbaciRegistry();
                            }
                        }
                        else
                        {
                            ExcelFile file2 = new ExcelFile();
                            file2.Worksheets.Add("Data");
                            file2.Worksheets[0].Cells[0, 1].Value = this.verzija;
                            file2.SaveXls(this.putanjaFolder + @"\reg.jpg");
                            this.UbaciRegistry();
                        }
                    }
                }
                catch
                {
                    num++;
                }
            }
            if (this.BrojacPU == 2)
            {
                try
                {
                    if (this.verzija != "00000")
                    {
                        string str = new WebClient().DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/VerzijaPrograma/UserCurrentVersion.php?Id=" + this.PersonalID + "&Verzija=" + this.verzija);
                    }
                }
                catch
                {
                    num++;
                }
            }
            if (this.BrojacPU == 3)
            {
                this.DoslaObavestenja();
            }
            if (this.BrojacPU == 4)
            {
                try
                {
                    currentDeployment = ApplicationDeployment.CurrentDeployment;
                    currentDeployment.CheckForUpdateCompleted += new CheckForUpdateCompletedEventHandler(this.ad_CheckForUpdateCompleted);
                    currentDeployment.CheckForUpdateAsync();
                }
                catch
                {
                }
            }
            if (this.BrojacPU == 5)
            {
                this.DoslaObavestenjaOpstina();
            }
            if (this.BrojacPU == 6)
            {
                try
                {
                    string path = this.putanjaFolder + @"\Vpic";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path).Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                    }
                    else if (Directory.GetFiles(path).Length > 100)
                    {
                        int num2 = 0;
                        foreach (string str3 in Directory.GetFiles(path))
                        {
                            if (num2 > 0x1d)
                            {
                                goto Label_0377;
                            }
                            System.IO.File.Delete(str3);
                            num2++;
                        }
                    }
                }
                catch
                {
                }
            }
        Label_0377:
            if (this.BrojacPU == 7)
            {
                try
                {
                    client2 = new WebClient();
                    str4 = "http://198.199.126.105/ngledovic/Install/InternetTim/php/NivoKorisnika/GetUsersInfoById.php?";
                    str4 = str4 + "Id=" + this.PersonalID;
                    reader = new JsonTextReader(new StringReader(client2.DownloadString(str4)));
                    num3 = 0;
                    string str6 = "";
                    while (reader.Read())
                    {
                        if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                        {
                            if (num3 == 0)
                            {
                                str6 = reader.Value.ToString();
                            }
                            num3++;
                            if (num3 == 1)
                            {
                                num3 = 0;
                                break;
                            }
                        }
                    }
                    this.GNivoKorisnika = str6;
                    if (str6.Contains("A"))
                    {
                        this.dozvoleZaProgramToolStripMenuItem.Visible = true;
                    }
                    if (str6.Contains("P"))
                    {
                        this.pošaljiPorukuToolStripMenuItem.Visible = true;
                    }
                    if (str6.Contains("S"))
                    {
                        this.dozvoleZaSlanjeToolStripMenuItem.Visible = true;
                    }
                    if (str6.Contains("N"))
                    {
                        this.porukeNaServeruToolStripMenuItem.Visible = true;
                    }
                    if (str6.Contains("R"))
                    {
                        this.grupeZaRadToolStripMenuItem.Visible = true;
                    }
                    if (str6.Contains("K"))
                    {
                        this.komentariToolStripMenuItem.Visible = true;
                    }
                    if (System.IO.File.Exists(this.putanjaFolder + @"\Vpic\MKB\pos.jpg"))
                    {
                        this.mojiKomentariToolStripMenuItem.Visible = true;
                    }
                    if (str6.Contains("B"))
                    {
                        num = 650;
                    }
                    if (str6.Contains("I"))
                    {
                        this.izveštajiToolStripMenuItem.Visible = true;
                    }
                    if (str6.Contains("G"))
                    {
                        this.gramatickeGreskeToolStripMenuItem.Visible = true;
                    }
                    if (str6.Contains("Q"))
                    {
                        this.bodovanjeToolStripMenuItem.Visible = true;
                    }
                    if (str6.Contains("W"))
                    {
                        this.preporukaToolStripMenuItem.Visible = true;
                    }
                    if (str6.Contains("E"))
                    {
                        this.dozvoleZaIzvestajeToolStripMenuItem.Visible = true;
                    }
                    if (str6.Contains("T"))
                    {
                        this.opštinskiIzveštajiToolStripMenuItem.Visible = true;
                    }
                    if (str6.Contains("Y"))
                    {
                        this.spajanjeKorisnikaToolStripMenuItem.Visible = true;
                    }
                    if (str6.Contains("U"))
                    {
                        this.komandeToolStripMenuItem.Visible = true;
                    }
                    if (str6.Contains("O"))
                    {
                        this.twitterToolStripMenuItem.Visible = true;
                    }
                    if (str6.Contains("M"))
                    {
                        this.ubaciProxyIProveriToolStripMenuItem.Visible = true;
                    }
                    if (str6.Contains("X"))
                    {
                        this.chatSlanjeKomentaraToolStripMenuItem.Visible = true;
                    }
                }
                catch
                {
                    num++;
                }
                this.ugasiProgramToolStripMenuItem.Visible = true;
            }
            if (this.BrojacPU == 8)
            {
                try
                {
                    WebClient client3 = new WebClient();
                    string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Komande/GetCommandsById.php?";
                    address = address + "id=" + this.PersonalID;
                    string s = client3.DownloadString(address);
                    if (!s.Contains("GRESKA"))
                    {
                        reader = new JsonTextReader(new StringReader(s));
                        num3 = 0;
                        string komanda = "";
                        while (reader.Read())
                        {
                            if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                            {
                                if (num3 == 0)
                                {
                                    komanda = reader.Value.ToString();
                                }
                                num3++;
                                if (num3 == 1)
                                {
                                    num3 = 0;
                                }
                            }
                        }
                        this.IzvrsiKomandu(komanda);
                    }
                }
                catch
                {
                }
            }
            if (this.BrojacPU == 9)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    client2 = new WebClient();
                    str4 = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Zastita/GetUsersInfoById.php?";
                    str4 = str4 + "Id=" + this.PersonalID;
                    string str5 = client2.DownloadString(str4);
                    if (str5.StartsWith("DA"))
                    {
                        this.GSifra = str5.Replace("\r\n", "");
                    }
                }
                catch
                {
                    num++;
                }
            }
            if (num == 0)
            {
                if (this.BrojacPU < 10)
                {
                    this.sta.Text = this.BrojacPU.ToString();
                    this.PocetnoUcitavanje.Enabled = true;
                    this.PocetnoUcitavanje.Start();
                }
                else
                {
                    this.sta.Text = "20";
                    if (this.PotrebanRestart == 0)
                    {
                        ((ToolStripDropDownMenu) this.grupeZaRadToolStripMenuItem.DropDown).ShowImageMargin = false;
                        ((ToolStripDropDownMenu) this.komentariToolStripMenuItem.DropDown).ShowImageMargin = false;
                        ((ToolStripDropDownMenu) this.obaveštenjaToolStripMenuItem.DropDown).ShowImageMargin = false;
                        ((ToolStripDropDownMenu) this.izveštajiToolStripMenuItem.DropDown).ShowImageMargin = false;
                        ((ToolStripDropDownMenu) this.preporukaToolStripMenuItem.DropDown).ShowImageMargin = false;
                        this.notifyIcon1.Icon = InternetTim.Properties.Resources.OrbBullet;
                        if (this.GSifra.StartsWith("DA"))
                        {
                            this.notifyIcon1.ContextMenuStrip = this.PorukaOtvoriZastitu;
                        }
                        else
                        {
                            this.notifyIcon1.ContextMenuStrip = this.GlavneOpcije;
                        }
                        this.notifyIcon1.ShowBalloonTip(0xbb8, "SkyNet", "Aplikacija je spremna za rad", ToolTipIcon.Info);
                        base.Hide();
                        this.RedovnoUcitavanje.Enabled = true;
                        this.RedovnoUcitavanje.Start();
                    }
                    else
                    {
                        base.Close();
                    }
                }
            }
            else if (num == 650)
            {
                MessageBox.Show("Dogodila se greška prilikom startovanja programa, kontaktirajte kordinatora", "INFO");
                base.Close();
            }
            else if (this.BrojUcitavanje < 2)
            {
                this.BrojUcitavanje++;
                this.BrojacPU = 0;
                this.sta.Text = "R";
                this.PocetnoUcitavanje.Interval += 0x1770;
                this.PocetnoUcitavanje.Enabled = true;
                this.PocetnoUcitavanje.Start();
            }
            else
            {
                base.Close();
            }
            this.BrojacPU++;
        }

        private void POGLSI_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.notifyIcon1.Visible = true;
        }

        private void POGLSI_TextChanged(object sender, EventArgs e)
        {
            this.notifyIcon1.ContextMenuStrip = this.GlavneOpcije;
        }

        private void PokreniBlicGlasanjeSad()
        {
            try
            {
                string s = new WebClient().DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Glasanje/GetBlicGlasanje.php");
                if (!s.Contains("GRESKA"))
                {
                    JsonTextReader reader = new JsonTextReader(new StringReader(s));
                    int num = 0;
                    string str2 = "";
                    string str3 = "";
                    string str4 = "";
                    while (reader.Read())
                    {
                        if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                        {
                            switch (num)
                            {
                                case 0:
                                    str2 = reader.Value.ToString().Replace("[[]]", "&");
                                    break;

                                case 1:
                                    str3 = reader.Value.ToString();
                                    break;

                                case 2:
                                    str4 = reader.Value.ToString();
                                    break;
                            }
                            num++;
                            if (num == 3)
                            {
                                num = 0;
                            }
                        }
                    }
                    try
                    {
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

        private void pokreniGlasanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelFile file = new ExcelFile();
                file.LoadXls(this.putanjaFolder + @"\vote.jpg");
                file.Worksheets[0].Cells[0].Value = "pokreniglasanje";
                file.SaveXls(this.putanjaFolder + @"\vote.jpg");
                Process.Start("InternetTim.exe");
            }
            catch
            {
                MessageBox.Show("Dogodila se greška u programu, probajte ponovo ili restartujte program.", "INFO");
            }
        }

        private void PokreniRegistraciju()
        {
            PosaljiRegistraciju registraciju = new PosaljiRegistraciju();
            registraciju.FormClosed += new FormClosedEventHandler(this.regi_FormClosed);
            registraciju.Show();
        }

        private void porukeNaServeruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ObavestenjaSaServera().Show();
        }

        private void pošaljiPorukuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SlanjeObavestenja { ID = this.PersonalID }.Show();
        }

        private void prijaviProblemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PosaljiProblem().Show();
        }

        private void primljenePorukeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PrikazPorukaBaza { putanja = this.putanjaFolder }.Show();
        }

        private void RedovnoUcitavanje_Tick(object sender, EventArgs e)
        {
            this.RedovnoUcitavanje.Stop();
            this.RedovnoUcitavanje.Enabled = false;
            if (this.GlavniBrojac == this.CeoSat)
            {
                try
                {
                    string str = new WebClient().DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/ProveraRada/UserCheckRun2.php?Id=" + this.PersonalID);
                }
                catch
                {
                }
                this.CeoSat += 60;
            }
            if (this.GlavniBrojac == this.ProveraObavestenja)
            {
                this.DoslaObavestenja();
                this.ProveraObavestenja += 0x23;
            }
            if (this.GlavniBrojac == this.ProveraObavestenjaOpstina)
            {
                this.DoslaObavestenjaOpstina();
                this.ProveraObavestenjaOpstina += 0x41;
            }
            this.GlavniBrojac++;
            this.RedovnoUcitavanje.Enabled = true;
            this.RedovnoUcitavanje.Start();
        }

        private void regi_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ExcelFile file = new ExcelFile();
                file.LoadXls(this.putanjaFolder + @"\reg.jpg");
                this.PersonalID = file.Worksheets[0].Cells[0, 0].Value.ToString();
                this.OpstinaID = file.Worksheets[0].Cells[3, 0].Value.ToString();
                if ((this.PersonalID != "000000") && (this.PersonalID.Length > 2))
                {
                    this.notifyIcon1.Visible = true;
                    ExcelFile file2 = new ExcelFile();
                    file2.Worksheets.Add("Data");
                    file2.SaveXls(this.putanjaFolder + @"\vote.jpg");
                    this.PocetnoUcitavanje.Enabled = true;
                    this.PocetnoUcitavanje.Start();
                    this.UcitaSlika();
                }
                else
                {
                    Application.Restart();
                }
            }
            catch
            {
            }
        }

        private void spajanjeKorisnikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SKForma().Show();
        }

        private void spisakKorisnikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SpisakKorisnika().Show();
        }

        private void statsKorisniciBrojPoslatihIObjavljenihToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new OdDoPrijavljeniObjavljeni().Show();
        }

        private void tnaloziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TwitNalozi().Show();
        }

        private void ubaciProxyIProveriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ProveraProxyServera().Show();
        }

        private void UbaciRegistry()
        {
            try
            {
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (System.IO.File.Exists(folderPath + @"\SkyNet.appref-ms"))
                {
                    string str2 = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                    try
                    {
                        System.IO.File.Delete(str2 + @"\InternetTim.appref-ms");
                    }
                    catch
                    {
                    }
                    System.IO.File.Copy(folderPath + @"\SkyNet.appref-ms", str2 + @"\SkyNet.appref-ms", true);
                }
            }
            catch
            {
            }
        }

        private void UcitaSlika()
        {
            this.sta.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.sta.Size.Width, Screen.PrimaryScreen.WorkingArea.Height - this.sta.Size.Height);
            this.sta.Show();
        }

        private void ugasiProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void ukucajteSifruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PotvrdaGlavneSifre sifre = new PotvrdaGlavneSifre();
            sifre.TextChanged += new EventHandler(this.POGLSI_TextChanged);
            sifre.FormClosed += new FormClosedEventHandler(this.POGLSI_FormClosed);
            sifre.glavnasifra = this.GSifra;
            sifre.Show();
            this.notifyIcon1.Visible = false;
        }

        public void UpdateFormDisplay(Image backgroundImage)
        {
            IntPtr dC = API.GetDC(IntPtr.Zero);
            IntPtr hDC = API.CreateCompatibleDC(dC);
            IntPtr zero = IntPtr.Zero;
            IntPtr hObject = IntPtr.Zero;
            try
            {
                Bitmap bitmap = new Bitmap(backgroundImage);
                zero = bitmap.GetHbitmap(Color.FromArgb(0));
                hObject = API.SelectObject(hDC, zero);
                Size psize = bitmap.Size;
                Point pprSrc = new Point(0, 0);
                Point pptDst = new Point(base.Left, base.Top);
                API.BLENDFUNCTION pblend = new API.BLENDFUNCTION {
                    BlendOp = 0,
                    BlendFlags = 0,
                    SourceConstantAlpha = 0xff,
                    AlphaFormat = 1
                };
                API.UpdateLayeredWindow(base.Handle, dC, ref pptDst, ref psize, hDC, ref pprSrc, 0, ref pblend, 2);
                bitmap.Dispose();
                API.ReleaseDC(IntPtr.Zero, dC);
                if (zero != IntPtr.Zero)
                {
                    API.SelectObject(hDC, hObject);
                    API.DeleteObject(zero);
                }
                API.DeleteDC(hDC);
            }
            catch (Exception)
            {
            }
        }

        private void vestiIStatistikaSlanjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UzivoVestiStatsKomentari().Show();
        }

        private void zadnjaAktivnostKorisnikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ZadnjaAktivnostKorisnika().Show();
        }

        private void zasss_FormClosed(object sender, FormClosedEventArgs e)
        {
            base.Close();
        }

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x80000;
                return createParams;
            }
        }

        internal class API
        {
            public const byte AC_SRC_ALPHA = 1;
            public const byte AC_SRC_OVER = 0;
            public const int ULW_ALPHA = 2;

            [DllImport("gdi32.dll", SetLastError=true, ExactSpelling=true)]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
            [DllImport("gdi32.dll", SetLastError=true, ExactSpelling=true)]
            public static extern bool DeleteDC(IntPtr hdc);
            [DllImport("gdi32.dll", SetLastError=true, ExactSpelling=true)]
            public static extern bool DeleteObject(IntPtr hObject);
            [DllImport("user32.dll", SetLastError=true, ExactSpelling=true)]
            public static extern IntPtr GetDC(IntPtr hWnd);
            [DllImport("user32.dll", ExactSpelling=true)]
            public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
            [DllImport("gdi32.dll", ExactSpelling=true)]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
            [DllImport("user32.dll", SetLastError=true, ExactSpelling=true)]
            public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);

            [StructLayout(LayoutKind.Sequential, Pack=1)]
            public struct BLENDFUNCTION
            {
                public byte BlendOp;
                public byte BlendFlags;
                public byte SourceConstantAlpha;
                public byte AlphaFormat;
            }
        }
    }
}

