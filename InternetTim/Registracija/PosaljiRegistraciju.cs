namespace InternetTim.Registracija
{
    using GemBox.Spreadsheet;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Net.Mail;
    using System.Windows.Forms;

    public class PosaljiRegistraciju : Form
    {
        private CheckBox checkBox1;
        private IContainer components = null;
        private TextBox KorisnikEmail;
        private TextBox KorisnikIme;
        private TextBox KorisnikMobilni;
        private ComboBox KorisnikOpstina;
        private TextBox KorisnikPrezime;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button Potvrdi;

        public PosaljiRegistraciju()
        {
            this.InitializeComponent();
            SpreadsheetInfo.SetLicense("EQU1-4YRI-KEYA-HERE");
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
            this.KorisnikOpstina = new ComboBox();
            this.label8 = new Label();
            this.label7 = new Label();
            this.Potvrdi = new Button();
            this.KorisnikMobilni = new TextBox();
            this.KorisnikEmail = new TextBox();
            this.KorisnikPrezime = new TextBox();
            this.KorisnikIme = new TextBox();
            this.label6 = new Label();
            this.label5 = new Label();
            this.label4 = new Label();
            this.label3 = new Label();
            this.label2 = new Label();
            this.label1 = new Label();
            this.checkBox1 = new CheckBox();
            base.SuspendLayout();
            this.KorisnikOpstina.DropDownHeight = 140;
            this.KorisnikOpstina.DropDownStyle = ComboBoxStyle.DropDownList;
            this.KorisnikOpstina.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.KorisnikOpstina.FormattingEnabled = true;
            this.KorisnikOpstina.IntegralHeight = false;
            this.KorisnikOpstina.Items.AddRange(new object[] { 
                "Ada", "Aleksandrovac", "Aleksinac", "Alibunar", "Apatin", "Aranđelovac", "Arilje", "Babušnica", "Bač", "Bačka Palanka", "Bačka Topola", "Bački Petrovac", "Bajina Bašta", "Batočina", "Bečej", "Bela Crkva", 
                "Bela Palanka", "Beočin", "Beograd-Barajevo", "Beograd-Čukarica", "Beograd-Grocka", "Beograd-Lazarevac", "Beograd-Mladenovac", "Beograd-Novi Beograd", "Beograd-Obrenovac", "Beograd-Palilula", "Beograd-Rakovica", "Beograd-Savski Venac", "Beograd-Sopot", "Beograd-Stari Grad", "Beograd-Surčin", "Beograd-Voždovac", 
                "Beograd-Vračar", "Beograd-Zemun", "Beograd-Zvezdara", "Blace", "Bogatić", "Bojnik", "Boljevac", "Bor", "Bosilegrad", "Brus", "Bujanovac", "Čačak", "Čajetina", "Ćićevac", "Čoka", "Crna Trava", 
                "Ćuprija", "Dečani", "Despotovac", "Dimitrovgrad", "Doljevac", "Gadžin Han", "Glogovac", "Gnjilane", "Golubac", "Gora", "Gornji Milanovac", "Inđija", "Irig", "Istok", "Ivanjica", "Jagodina", 
                "Kačanik", "Kanjiža", "Kikinda", "Kladovo", "Klina", "Knić", "Knjaževac", "Koceljeva", "Kosjerić", "Kosovo Polje", "Kosovska Kamenica", "Kosovska Mitrovica", "Kovačica", "Kovin", "Kragujevac - grad", "Kraljevo", 
                "Krupanj", "Kruševac", "Kučevo", "Kula", "Kuršumlija", "Lajkovac", "Lapovo", "Lebane", "Leposavić", "Leskovac", "Lipljan", "Ljig", "Ljubovija", "Loznica", "Lučani", "Majdanpek", 
                "Mali Iđoš", "Mali Zvornik", "Malo Crniće", "Medveđa", "Merošina", "Mionica", "Negotin", "Niš-Crveni Krst", "Niš-Grad", "Niš-Mediana", "Niš-Niška Banja", "Niš-Palilula", "Niš-Pantelej", "Nova Crnja", "Nova Varoš", "Novi Bečej", 
                "Novi Kneževac", "Novi Pazar", "Novi Sad - grad", "Novo Brdo", "Obilić", "Odžaci", "Opovo", "Orahovac", "Osečina", "Pančevo", "Paraćin", "Peć", "Pećinci", "Petrovac", "Pirot", "Plandište", 
                "Podujevo", "Požarevac", "Požega", "Preševo", "Priboj", "Prijepolje", "Priština - grad", "Prizren", "Prokuplje", "Rača", "Raška", "Ražanj", "Rekovac", "Ruma", "Šabac", "Sečanj", 
                "Senta", "Šid", "Sjenica", "Smederevo", "Smederevska Palanka", "Sokobanja", "Sombor", "Srbica", "Srbobran", "Sremska Mitrovica", "Sremski Karlovci", "Stara Pazova", "Štimlje", "Štrpce", "Subotica", "Surdulica", 
                "Suva Reka", "Svilajnac", "Svrljig", "Temerin", "Titel", "Topola", "Trgovište", "Trstenik", "Tutin", "Ub", "Uroševac", "Užice", "Valjevo", "Varvarin", "Velika Plana", "Veliko Gradište", 
                "Vitina", "Vladičin Han", "Vladimirci", "Vlasotince", "Vranje", "Vrbas", "Vrnjačka Banja", "Vršac", "Vučitrn", "Žabalj", "Žabari", "Žagubica", "Zaječar", "Žitište", "Žitorađa", "Zrenjanin", 
                "Zubin Potok", "Zvečan", "Đakovica"
             });
            this.KorisnikOpstina.Location = new Point(150, 0x9c);
            this.KorisnikOpstina.Name = "KorisnikOpstina";
            this.KorisnikOpstina.Size = new Size(0x16e, 0x20);
            this.KorisnikOpstina.TabIndex = 0x1c;
            this.label8.AutoSize = true;
            this.label8.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label8.Location = new Point(0x141, 0x30);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x8f, 0x18);
            this.label8.TabIndex = 0x1b;
            this.label8.Text = "Koristite latinicu.";
            this.label7.AutoSize = true;
            this.label7.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label7.Location = new Point(50, 0x30);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x114, 0x18);
            this.label7.TabIndex = 0x1a;
            this.label7.Text = "Sva polja moraju da se popune.";
            this.Potvrdi.Cursor = Cursors.Hand;
            this.Potvrdi.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Potvrdi.Location = new Point(150, 0x13a);
            this.Potvrdi.Name = "Potvrdi";
            this.Potvrdi.Size = new Size(0x16e, 0x37);
            this.Potvrdi.TabIndex = 0x19;
            this.Potvrdi.Text = "POTVRDI PODATKE";
            this.Potvrdi.UseVisualStyleBackColor = true;
            this.Potvrdi.Click += new EventHandler(this.Potvrdi_Click);
            this.KorisnikMobilni.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.KorisnikMobilni.Location = new Point(150, 0xe8);
            this.KorisnikMobilni.MaxLength = 40;
            this.KorisnikMobilni.Name = "KorisnikMobilni";
            this.KorisnikMobilni.Size = new Size(0x16e, 0x1d);
            this.KorisnikMobilni.TabIndex = 0x18;
            this.KorisnikEmail.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.KorisnikEmail.Location = new Point(150, 0xc2);
            this.KorisnikEmail.MaxLength = 40;
            this.KorisnikEmail.Name = "KorisnikEmail";
            this.KorisnikEmail.Size = new Size(0x16e, 0x1d);
            this.KorisnikEmail.TabIndex = 0x17;
            this.KorisnikPrezime.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.KorisnikPrezime.Location = new Point(150, 0x76);
            this.KorisnikPrezime.MaxLength = 40;
            this.KorisnikPrezime.Name = "KorisnikPrezime";
            this.KorisnikPrezime.Size = new Size(0x16e, 0x1d);
            this.KorisnikPrezime.TabIndex = 0x16;
            this.KorisnikIme.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.KorisnikIme.Location = new Point(150, 80);
            this.KorisnikIme.MaxLength = 40;
            this.KorisnikIme.Name = "KorisnikIme";
            this.KorisnikIme.Size = new Size(0x16e, 0x1d);
            this.KorisnikIme.TabIndex = 0x15;
            this.label6.AutoSize = true;
            this.label6.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label6.Location = new Point(7, 0xeb);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x89, 0x18);
            this.label6.TabIndex = 20;
            this.label6.Text = "Mobilni telefon:";
            this.label5.AutoSize = true;
            this.label5.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label5.Location = new Point(14, 0xc5);
            this.label5.Name = "label5";
            this.label5.Size = new Size(130, 0x18);
            this.label5.TabIndex = 0x13;
            this.label5.Text = "E-mail adresa:";
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.Location = new Point(0x41, 0x9f);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x4f, 0x18);
            this.label4.TabIndex = 0x12;
            this.label4.Text = "Opština:";
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.Location = new Point(60, 0x79);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x54, 0x18);
            this.label3.TabIndex = 0x11;
            this.label3.Text = "Prezime:";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(0x62, 0x53);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x2e, 0x18);
            this.label2.TabIndex = 0x10;
            this.label2.Text = "Ime:";
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 26.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(0x79, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x10c, 0x27);
            this.label1.TabIndex = 15;
            this.label1.Text = "REGISTRACIJA";
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.checkBox1.Location = new Point(0xb8, 0x10b);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(280, 0x18);
            this.checkBox1.TabIndex = 0x1d;
            this.checkBox1.Text = "Čekiraj ako si ranije koristio program";
            this.checkBox1.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(0x20e, 0x17d);
            base.Controls.Add(this.checkBox1);
            base.Controls.Add(this.KorisnikOpstina);
            base.Controls.Add(this.label8);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.Potvrdi);
            base.Controls.Add(this.KorisnikMobilni);
            base.Controls.Add(this.KorisnikEmail);
            base.Controls.Add(this.KorisnikPrezime);
            base.Controls.Add(this.KorisnikIme);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "PosaljiRegistraciju";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Registracija";
            base.TopMost = true;
            base.ResumeLayout(false);
            base.PerformLayout();
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

        private void Potvrdi_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                int num = 0;
                if (this.KorisnikIme.Text.Length < 3)
                {
                    Cursor.Current = Cursors.Default;
                    num = 1;
                    MessageBox.Show("Proverite da li ste ukucali dobro IME", "INFO");
                }
                if (this.KorisnikPrezime.Text.Length < 3)
                {
                    Cursor.Current = Cursors.Default;
                    num = 1;
                    MessageBox.Show("Proverite da li ste ukucali dobro PREZIME", "INFO");
                }
                if (this.KorisnikEmail.Text.Length < 3)
                {
                    Cursor.Current = Cursors.Default;
                    num = 1;
                    MessageBox.Show("Proverite da li ste ukucali dobro E-MAIL", "INFO");
                }
                if (this.KorisnikMobilni.Text.Length < 3)
                {
                    Cursor.Current = Cursors.Default;
                    num = 1;
                    MessageBox.Show("Proverite da li ste ukucali dobro MOBILNI TELEFON", "INFO");
                }
                if (this.KorisnikOpstina.Text.Length < 3)
                {
                    Cursor.Current = Cursors.Default;
                    num = 1;
                    MessageBox.Show("Proverite da li ste dobro odabrali OPŠTINU", "INFO");
                }
                if (num == 0)
                {
                    WebClient client = new WebClient();
                    string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Registracija/InsertNewUser3.php?";
                    string str2 = "S-";
                    str2 = ((((((str2 + DateTime.Now.Year.ToString() + "-") + DateTime.Now.Month.ToString() + "-") + DateTime.Now.Day.ToString() + "-") + DateTime.Now.Hour.ToString() + "-") + DateTime.Now.Minute.ToString() + "-") + DateTime.Now.Second.ToString() + "-") + DateTime.Now.Millisecond.ToString() + "-E";
                    address = ((((((address + "Id=" + str2) + "&Ime=" + this.KorisnikIme.Text) + "&Prezime=" + this.KorisnikPrezime.Text) + "&Opstina=" + this.KorisnikOpstina.Text) + "&Email=" + this.KorisnikEmail.Text) + "&Mobilni=" + this.KorisnikMobilni.Text) + "&Pc=" + Environment.MachineName;
                    if (client.DownloadString(address).Contains("OKET"))
                    {
                        string path = Path.GetPathRoot(Environment.SystemDirectory) + "InternetTim";
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path).Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                        }
                        ExcelFile file = new ExcelFile();
                        file.Worksheets.Add("InfoData");
                        file.Worksheets[0].Cells[0, 0].Value = str2;
                        file.Worksheets[0].Cells[1, 0].Value = this.KorisnikIme.Text;
                        file.Worksheets[0].Cells[2, 0].Value = this.KorisnikPrezime.Text;
                        file.Worksheets[0].Cells[3, 0].Value = this.KorisnikOpstina.Text;
                        file.Worksheets[0].Cells[4, 0].Value = this.KorisnikEmail.Text;
                        file.Worksheets[0].Cells[5, 0].Value = this.KorisnikMobilni.Text;
                        file.SaveXls(path + @"\reg.jpg");
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Uspešno ste se registrovali", "INFO");
                        if (this.checkBox1.Checked)
                        {
                            this.PosaljiMail("CODE: NOVA REGISTRACIJA\n\n" + this.KorisnikIme.Text + "\n" + this.KorisnikPrezime.Text + "\n" + this.KorisnikOpstina.Text + "\n" + Environment.MachineName);
                        }
                        base.Close();
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Greška u sistemu, proverite da li vam radi INTERNET", "INFO");
                        base.Close();
                    }
                }
            }
            catch
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Greška u sistemu, proverite da li vam radi INTERNET", "INFO");
                base.Close();
            }
        }
    }
}

