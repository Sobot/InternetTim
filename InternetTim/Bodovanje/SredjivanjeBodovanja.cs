namespace InternetTim.Bodovanje
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;

    public class SredjivanjeBodovanja : Form
    {
        private TextBox ALO;
        private TextBox B92;
        private TextBox BLIC;
        private TextBox BLICODGOVOR;
        private string[] Bodovi = new string[500];
        private Button button1;
        private IContainer components = null;
        private TextBox DANAS;
        private TextBox DUPLIKAT;
        private TextBox DUZINA100;
        private TextBox DUZINA200;
        private TextBox DUZINA300;
        private TextBox DUZINA400;
        private TextBox DUZINA500;
        private TextBox GRAMATICKEGRESKE;
        private string[] Ime = new string[500];
        private TextBox KOMENTARPRVI;
        private TextBox KOMENTARUPRVIH10;
        private TextBox KURIR;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label2;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox MODERATORSKAOCENA1;
        private TextBox MODERATORSKAOCENA2;
        private TextBox MODERATORSKAOCENA3;
        private TextBox MODERATORSKAOCENA4;
        private TextBox MODERATORSKAOCENA5;
        private TextBox NEOBJAVLJENIH10;
        private TextBox NOVOSTI;
        private TextBox ORIGINALNI;
        private TextBox OSTALO;
        private TextBox POLITIKA;
        private TextBox RTS;
        private TextBox TELEGRAF;
        private TextBox VESTPRIORITET;

        public SredjivanjeBodovanja()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                foreach (Control control in base.Controls)
                {
                    if (control is TextBox)
                    {
                        int index = 0;
                        foreach (string str in this.Ime)
                        {
                            if (str == null)
                            {
                                break;
                            }
                            if (control.Name == str)
                            {
                                if (control.Text != this.Bodovi[index])
                                {
                                    WebClient client = new WebClient();
                                    string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Bodovanje/UpdatePointByName.php?";
                                    address = (address + "Name=" + control.Name) + "&Bodovi=" + control.Text;
                                    string str3 = client.DownloadString(address);
                                }
                                break;
                            }
                            index++;
                        }
                    }
                }
                MessageBox.Show("Gotovo snimanje", "INFO");
                this.Ucitavanje();
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(SredjivanjeBodovanja));
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.label6 = new Label();
            this.label7 = new Label();
            this.label8 = new Label();
            this.label9 = new Label();
            this.label10 = new Label();
            this.label11 = new Label();
            this.BLIC = new TextBox();
            this.B92 = new TextBox();
            this.KURIR = new TextBox();
            this.NOVOSTI = new TextBox();
            this.RTS = new TextBox();
            this.DANAS = new TextBox();
            this.POLITIKA = new TextBox();
            this.TELEGRAF = new TextBox();
            this.ALO = new TextBox();
            this.OSTALO = new TextBox();
            this.label12 = new Label();
            this.label13 = new Label();
            this.label14 = new Label();
            this.label15 = new Label();
            this.label16 = new Label();
            this.label17 = new Label();
            this.label18 = new Label();
            this.label19 = new Label();
            this.label20 = new Label();
            this.label21 = new Label();
            this.label22 = new Label();
            this.label23 = new Label();
            this.label24 = new Label();
            this.label25 = new Label();
            this.label26 = new Label();
            this.GRAMATICKEGRESKE = new TextBox();
            this.VESTPRIORITET = new TextBox();
            this.DUZINA100 = new TextBox();
            this.DUZINA200 = new TextBox();
            this.DUZINA300 = new TextBox();
            this.DUZINA400 = new TextBox();
            this.DUZINA500 = new TextBox();
            this.DUPLIKAT = new TextBox();
            this.KOMENTARPRVI = new TextBox();
            this.KOMENTARUPRVIH10 = new TextBox();
            this.BLICODGOVOR = new TextBox();
            this.MODERATORSKAOCENA1 = new TextBox();
            this.NEOBJAVLJENIH10 = new TextBox();
            this.ORIGINALNI = new TextBox();
            this.button1 = new Button();
            this.MODERATORSKAOCENA2 = new TextBox();
            this.MODERATORSKAOCENA3 = new TextBox();
            this.MODERATORSKAOCENA4 = new TextBox();
            this.MODERATORSKAOCENA5 = new TextBox();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.ForeColor = Color.Red;
            this.label1.Location = new Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x160, 0x18);
            this.label1.TabIndex = 0;
            this.label1.Text = "POČETNO BODOVANJE KOMENTARA";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(0x76, 0x24);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x2d, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "BLIC";
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.Location = new Point(0x76, 0xb0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x41, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "DANAS";
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.Location = new Point(0x76, 0x94);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x29, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "RTS";
            this.label5.AutoSize = true;
            this.label5.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label5.Location = new Point(0x76, 120);
            this.label5.Name = "label5";
            this.label5.Size = new Size(80, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "NOVOSTI";
            this.label6.AutoSize = true;
            this.label6.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label6.Location = new Point(0x76, 0x5c);
            this.label6.Name = "label6";
            this.label6.Size = new Size(60, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "KURIR";
            this.label7.AutoSize = true;
            this.label7.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label7.Location = new Point(0x76, 0x40);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x26, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "B92";
            this.label8.AutoSize = true;
            this.label8.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label8.Location = new Point(0x76, 0xe8);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x5f, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "TELEGRAF";
            this.label9.AutoSize = true;
            this.label9.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label9.Location = new Point(0x76, 0xcc);
            this.label9.Name = "label9";
            this.label9.Size = new Size(80, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "POLITIKA";
            this.label10.AutoSize = true;
            this.label10.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label10.Location = new Point(0x76, 260);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x29, 20);
            this.label10.TabIndex = 9;
            this.label10.Text = "ALO";
            this.label11.AutoSize = true;
            this.label11.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label11.Location = new Point(0x76, 0x120);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x49, 20);
            this.label11.TabIndex = 10;
            this.label11.Text = "OSTALO";
            this.BLIC.BackColor = Color.LightGreen;
            this.BLIC.Location = new Point(12, 0x24);
            this.BLIC.Name = "BLIC";
            this.BLIC.Size = new Size(100, 20);
            this.BLIC.TabIndex = 11;
            this.BLIC.TextAlign = HorizontalAlignment.Center;
            this.B92.BackColor = Color.LightGreen;
            this.B92.Location = new Point(12, 0x40);
            this.B92.Name = "B92";
            this.B92.Size = new Size(100, 20);
            this.B92.TabIndex = 12;
            this.B92.TextAlign = HorizontalAlignment.Center;
            this.KURIR.BackColor = Color.LightGreen;
            this.KURIR.Location = new Point(12, 0x5c);
            this.KURIR.Name = "KURIR";
            this.KURIR.Size = new Size(100, 20);
            this.KURIR.TabIndex = 13;
            this.KURIR.TextAlign = HorizontalAlignment.Center;
            this.NOVOSTI.BackColor = Color.LightGreen;
            this.NOVOSTI.Location = new Point(12, 120);
            this.NOVOSTI.Name = "NOVOSTI";
            this.NOVOSTI.Size = new Size(100, 20);
            this.NOVOSTI.TabIndex = 14;
            this.NOVOSTI.TextAlign = HorizontalAlignment.Center;
            this.RTS.BackColor = Color.LightGreen;
            this.RTS.Location = new Point(12, 0x94);
            this.RTS.Name = "RTS";
            this.RTS.Size = new Size(100, 20);
            this.RTS.TabIndex = 15;
            this.RTS.TextAlign = HorizontalAlignment.Center;
            this.DANAS.BackColor = Color.LightGreen;
            this.DANAS.Location = new Point(12, 0xb0);
            this.DANAS.Name = "DANAS";
            this.DANAS.Size = new Size(100, 20);
            this.DANAS.TabIndex = 0x10;
            this.DANAS.TextAlign = HorizontalAlignment.Center;
            this.POLITIKA.BackColor = Color.LightGreen;
            this.POLITIKA.Location = new Point(12, 0xcc);
            this.POLITIKA.Name = "POLITIKA";
            this.POLITIKA.Size = new Size(100, 20);
            this.POLITIKA.TabIndex = 0x11;
            this.POLITIKA.TextAlign = HorizontalAlignment.Center;
            this.TELEGRAF.BackColor = Color.LightGreen;
            this.TELEGRAF.Location = new Point(12, 0xe8);
            this.TELEGRAF.Name = "TELEGRAF";
            this.TELEGRAF.Size = new Size(100, 20);
            this.TELEGRAF.TabIndex = 0x12;
            this.TELEGRAF.TextAlign = HorizontalAlignment.Center;
            this.ALO.BackColor = Color.LightGreen;
            this.ALO.Location = new Point(12, 260);
            this.ALO.Name = "ALO";
            this.ALO.Size = new Size(100, 20);
            this.ALO.TabIndex = 0x13;
            this.ALO.TextAlign = HorizontalAlignment.Center;
            this.OSTALO.BackColor = Color.LightGreen;
            this.OSTALO.Location = new Point(12, 0x120);
            this.OSTALO.Name = "OSTALO";
            this.OSTALO.Size = new Size(100, 20);
            this.OSTALO.TabIndex = 20;
            this.OSTALO.TextAlign = HorizontalAlignment.Center;
            this.label12.AutoSize = true;
            this.label12.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label12.Location = new Point(0x76, 0x155);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0xbb, 20);
            this.label12.TabIndex = 0x15;
            this.label12.Text = "GRAMATIČKE GREŠKE";
            this.label13.AutoSize = true;
            this.label13.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label13.ForeColor = Color.Red;
            this.label13.Location = new Point(12, 0x13a);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0xe3, 0x18);
            this.label13.TabIndex = 0x16;
            this.label13.Text = "DODATNO BODOVANJE";
            this.label14.AutoSize = true;
            this.label14.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label14.Location = new Point(0x76, 0x171);
            this.label14.Name = "label14";
            this.label14.Size = new Size(140, 20);
            this.label14.TabIndex = 0x17;
            this.label14.Text = "VEST PRIORITET";
            this.label15.AutoSize = true;
            this.label15.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label15.Location = new Point(0x76, 0x18d);
            this.label15.Name = "label15";
            this.label15.Size = new Size(0x102, 20);
            this.label15.TabIndex = 0x18;
            this.label15.Text = "KOMENTAR DUŽI OD 100 SLOVA";
            this.label16.AutoSize = true;
            this.label16.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label16.Location = new Point(0x76, 0x1a9);
            this.label16.Name = "label16";
            this.label16.Size = new Size(0x102, 20);
            this.label16.TabIndex = 0x19;
            this.label16.Text = "KOMENTAR DUŽI OD 200 SLOVA";
            this.label17.AutoSize = true;
            this.label17.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label17.Location = new Point(0x76, 0x1c5);
            this.label17.Name = "label17";
            this.label17.Size = new Size(0x102, 20);
            this.label17.TabIndex = 0x1a;
            this.label17.Text = "KOMENTAR DUŽI OD 300 SLOVA";
            this.label18.AutoSize = true;
            this.label18.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label18.Location = new Point(0x76, 0x1e1);
            this.label18.Name = "label18";
            this.label18.Size = new Size(0x102, 20);
            this.label18.TabIndex = 0x1b;
            this.label18.Text = "KOMENTAR DUŽI OD 400 SLOVA";
            this.label19.AutoSize = true;
            this.label19.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label19.Location = new Point(0x76, 0x1fd);
            this.label19.Name = "label19";
            this.label19.Size = new Size(0x102, 20);
            this.label19.TabIndex = 0x1c;
            this.label19.Text = "KOMENTAR DUŽI OD 500 SLOVA";
            this.label20.AutoSize = true;
            this.label20.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label20.Location = new Point(0x76, 0x219);
            this.label20.Name = "label20";
            this.label20.Size = new Size(0x57, 20);
            this.label20.TabIndex = 0x1d;
            this.label20.Text = "DUPLIKAT";
            this.label21.AutoSize = true;
            this.label21.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label21.Location = new Point(0x76, 0x235);
            this.label21.Name = "label21";
            this.label21.Size = new Size(0x15b, 20);
            this.label21.TabIndex = 30;
            this.label21.Text = "KOMENTAR NA PRVOM MESTU NA VESTIMA";
            this.label22.AutoSize = true;
            this.label22.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label22.Location = new Point(0x76, 0x251);
            this.label22.Name = "label22";
            this.label22.Size = new Size(0x123, 20);
            this.label22.TabIndex = 0x1f;
            this.label22.Text = "KOMENTAR U PRVIH 10 NA VESTIMA";
            this.label23.AutoSize = true;
            this.label23.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label23.Location = new Point(0x76, 0x26d);
            this.label23.Name = "label23";
            this.label23.Size = new Size(0x105, 20);
            this.label23.TabIndex = 0x20;
            this.label23.Text = "BLIC - ODGOVOR NA KOMENTAR";
            this.label24.AutoSize = true;
            this.label24.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label24.Location = new Point(0x21e, 0x289);
            this.label24.Name = "label24";
            this.label24.Size = new Size(0xcd, 20);
            this.label24.TabIndex = 0x21;
            this.label24.Text = "MODERATORSKA OCENA";
            this.label25.AutoSize = true;
            this.label25.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label25.Location = new Point(0x76, 0x2a5);
            this.label25.Name = "label25";
            this.label25.Size = new Size(0x196, 20);
            this.label25.TabIndex = 0x22;
            this.label25.Text = "BROJ NE OBJAVLJENIH KOMENTARA ZA SVAKIH 10";
            this.label26.AutoSize = true;
            this.label26.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label26.Location = new Point(0x76, 0x2c1);
            this.label26.Name = "label26";
            this.label26.Size = new Size(0xc4, 20);
            this.label26.TabIndex = 0x23;
            this.label26.Text = "ORIGINALNI KOMENTAR";
            this.GRAMATICKEGRESKE.BackColor = Color.Salmon;
            this.GRAMATICKEGRESKE.Location = new Point(12, 0x155);
            this.GRAMATICKEGRESKE.Name = "GRAMATICKEGRESKE";
            this.GRAMATICKEGRESKE.Size = new Size(100, 20);
            this.GRAMATICKEGRESKE.TabIndex = 0x24;
            this.GRAMATICKEGRESKE.TextAlign = HorizontalAlignment.Center;
            this.VESTPRIORITET.BackColor = Color.LightGreen;
            this.VESTPRIORITET.Location = new Point(12, 0x171);
            this.VESTPRIORITET.Name = "VESTPRIORITET";
            this.VESTPRIORITET.Size = new Size(100, 20);
            this.VESTPRIORITET.TabIndex = 0x25;
            this.VESTPRIORITET.TextAlign = HorizontalAlignment.Center;
            this.DUZINA100.BackColor = Color.LightGreen;
            this.DUZINA100.Location = new Point(12, 0x18d);
            this.DUZINA100.Name = "DUZINA100";
            this.DUZINA100.Size = new Size(100, 20);
            this.DUZINA100.TabIndex = 0x26;
            this.DUZINA100.TextAlign = HorizontalAlignment.Center;
            this.DUZINA200.BackColor = Color.LightGreen;
            this.DUZINA200.Location = new Point(12, 0x1a9);
            this.DUZINA200.Name = "DUZINA200";
            this.DUZINA200.Size = new Size(100, 20);
            this.DUZINA200.TabIndex = 0x27;
            this.DUZINA200.TextAlign = HorizontalAlignment.Center;
            this.DUZINA300.BackColor = Color.LightGreen;
            this.DUZINA300.Location = new Point(12, 0x1c5);
            this.DUZINA300.Name = "DUZINA300";
            this.DUZINA300.Size = new Size(100, 20);
            this.DUZINA300.TabIndex = 40;
            this.DUZINA300.TextAlign = HorizontalAlignment.Center;
            this.DUZINA400.BackColor = Color.LightGreen;
            this.DUZINA400.Location = new Point(12, 0x1e1);
            this.DUZINA400.Name = "DUZINA400";
            this.DUZINA400.Size = new Size(100, 20);
            this.DUZINA400.TabIndex = 0x29;
            this.DUZINA400.TextAlign = HorizontalAlignment.Center;
            this.DUZINA500.BackColor = Color.LightGreen;
            this.DUZINA500.Location = new Point(12, 0x1fd);
            this.DUZINA500.Name = "DUZINA500";
            this.DUZINA500.Size = new Size(100, 20);
            this.DUZINA500.TabIndex = 0x2a;
            this.DUZINA500.TextAlign = HorizontalAlignment.Center;
            this.DUPLIKAT.BackColor = Color.Salmon;
            this.DUPLIKAT.Location = new Point(12, 0x219);
            this.DUPLIKAT.Name = "DUPLIKAT";
            this.DUPLIKAT.Size = new Size(100, 20);
            this.DUPLIKAT.TabIndex = 0x2b;
            this.DUPLIKAT.TextAlign = HorizontalAlignment.Center;
            this.KOMENTARPRVI.BackColor = Color.LightGreen;
            this.KOMENTARPRVI.Location = new Point(12, 0x235);
            this.KOMENTARPRVI.Name = "KOMENTARPRVI";
            this.KOMENTARPRVI.Size = new Size(100, 20);
            this.KOMENTARPRVI.TabIndex = 0x2c;
            this.KOMENTARPRVI.TextAlign = HorizontalAlignment.Center;
            this.KOMENTARUPRVIH10.BackColor = Color.LightGreen;
            this.KOMENTARUPRVIH10.Location = new Point(12, 0x251);
            this.KOMENTARUPRVIH10.Name = "KOMENTARUPRVIH10";
            this.KOMENTARUPRVIH10.Size = new Size(100, 20);
            this.KOMENTARUPRVIH10.TabIndex = 0x2d;
            this.KOMENTARUPRVIH10.TextAlign = HorizontalAlignment.Center;
            this.BLICODGOVOR.BackColor = Color.LightGreen;
            this.BLICODGOVOR.Location = new Point(12, 0x26d);
            this.BLICODGOVOR.Name = "BLICODGOVOR";
            this.BLICODGOVOR.Size = new Size(100, 20);
            this.BLICODGOVOR.TabIndex = 0x2e;
            this.BLICODGOVOR.TextAlign = HorizontalAlignment.Center;
            this.MODERATORSKAOCENA1.BackColor = Color.Red;
            this.MODERATORSKAOCENA1.Location = new Point(12, 0x289);
            this.MODERATORSKAOCENA1.Name = "MODERATORSKAOCENA1";
            this.MODERATORSKAOCENA1.Size = new Size(100, 20);
            this.MODERATORSKAOCENA1.TabIndex = 0x2f;
            this.MODERATORSKAOCENA1.TextAlign = HorizontalAlignment.Center;
            this.NEOBJAVLJENIH10.BackColor = Color.LightGreen;
            this.NEOBJAVLJENIH10.Location = new Point(12, 0x2a5);
            this.NEOBJAVLJENIH10.Name = "NEOBJAVLJENIH10";
            this.NEOBJAVLJENIH10.Size = new Size(100, 20);
            this.NEOBJAVLJENIH10.TabIndex = 0x30;
            this.NEOBJAVLJENIH10.TextAlign = HorizontalAlignment.Center;
            this.ORIGINALNI.BackColor = Color.LightGreen;
            this.ORIGINALNI.Location = new Point(12, 0x2c1);
            this.ORIGINALNI.Name = "ORIGINALNI";
            this.ORIGINALNI.Size = new Size(100, 20);
            this.ORIGINALNI.TabIndex = 0x31;
            this.ORIGINALNI.TextAlign = HorizontalAlignment.Center;
            this.button1.Cursor = Cursors.Hand;
            this.button1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.button1.Location = new Point(12, 0x2db);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x37c, 0x2c);
            this.button1.TabIndex = 50;
            this.button1.Text = "SNIMI PODATKE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.MODERATORSKAOCENA2.BackColor = Color.LightSalmon;
            this.MODERATORSKAOCENA2.Location = new Point(0x76, 0x289);
            this.MODERATORSKAOCENA2.Name = "MODERATORSKAOCENA2";
            this.MODERATORSKAOCENA2.Size = new Size(100, 20);
            this.MODERATORSKAOCENA2.TabIndex = 0x33;
            this.MODERATORSKAOCENA2.TextAlign = HorizontalAlignment.Center;
            this.MODERATORSKAOCENA3.BackColor = Color.White;
            this.MODERATORSKAOCENA3.Location = new Point(0xe0, 0x289);
            this.MODERATORSKAOCENA3.Name = "MODERATORSKAOCENA3";
            this.MODERATORSKAOCENA3.Size = new Size(100, 20);
            this.MODERATORSKAOCENA3.TabIndex = 0x34;
            this.MODERATORSKAOCENA3.TextAlign = HorizontalAlignment.Center;
            this.MODERATORSKAOCENA4.BackColor = Color.LightGreen;
            this.MODERATORSKAOCENA4.Location = new Point(330, 0x289);
            this.MODERATORSKAOCENA4.Name = "MODERATORSKAOCENA4";
            this.MODERATORSKAOCENA4.Size = new Size(100, 20);
            this.MODERATORSKAOCENA4.TabIndex = 0x35;
            this.MODERATORSKAOCENA4.TextAlign = HorizontalAlignment.Center;
            this.MODERATORSKAOCENA5.BackColor = Color.Chartreuse;
            this.MODERATORSKAOCENA5.Location = new Point(0x1b4, 0x289);
            this.MODERATORSKAOCENA5.Name = "MODERATORSKAOCENA5";
            this.MODERATORSKAOCENA5.Size = new Size(100, 20);
            this.MODERATORSKAOCENA5.TabIndex = 0x36;
            this.MODERATORSKAOCENA5.TextAlign = HorizontalAlignment.Center;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(0x394, 0x313);
            base.Controls.Add(this.MODERATORSKAOCENA5);
            base.Controls.Add(this.MODERATORSKAOCENA4);
            base.Controls.Add(this.MODERATORSKAOCENA3);
            base.Controls.Add(this.MODERATORSKAOCENA2);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.ORIGINALNI);
            base.Controls.Add(this.NEOBJAVLJENIH10);
            base.Controls.Add(this.MODERATORSKAOCENA1);
            base.Controls.Add(this.BLICODGOVOR);
            base.Controls.Add(this.KOMENTARUPRVIH10);
            base.Controls.Add(this.KOMENTARPRVI);
            base.Controls.Add(this.DUPLIKAT);
            base.Controls.Add(this.DUZINA500);
            base.Controls.Add(this.DUZINA400);
            base.Controls.Add(this.DUZINA300);
            base.Controls.Add(this.DUZINA200);
            base.Controls.Add(this.DUZINA100);
            base.Controls.Add(this.VESTPRIORITET);
            base.Controls.Add(this.GRAMATICKEGRESKE);
            base.Controls.Add(this.label26);
            base.Controls.Add(this.label25);
            base.Controls.Add(this.label24);
            base.Controls.Add(this.label23);
            base.Controls.Add(this.label22);
            base.Controls.Add(this.label21);
            base.Controls.Add(this.label20);
            base.Controls.Add(this.label19);
            base.Controls.Add(this.label18);
            base.Controls.Add(this.label17);
            base.Controls.Add(this.label16);
            base.Controls.Add(this.label15);
            base.Controls.Add(this.label14);
            base.Controls.Add(this.label13);
            base.Controls.Add(this.label12);
            base.Controls.Add(this.OSTALO);
            base.Controls.Add(this.ALO);
            base.Controls.Add(this.TELEGRAF);
            base.Controls.Add(this.POLITIKA);
            base.Controls.Add(this.DANAS);
            base.Controls.Add(this.RTS);
            base.Controls.Add(this.NOVOSTI);
            base.Controls.Add(this.KURIR);
            base.Controls.Add(this.B92);
            base.Controls.Add(this.BLIC);
            base.Controls.Add(this.label11);
            base.Controls.Add(this.label10);
            base.Controls.Add(this.label9);
            base.Controls.Add(this.label8);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "SredjivanjeBodovanja";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Bodovanje";
            base.Shown += new EventHandler(this.SredjivanjeBodovanja_Shown);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void SredjivanjeBodovanja_Shown(object sender, EventArgs e)
        {
            this.Ucitavanje();
        }

        private void Ucitavanje()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Array.Clear(this.Ime, 0, 500);
                Array.Clear(this.Bodovi, 0, 500);
                WebClient client = new WebClient();
                JsonTextReader reader = new JsonTextReader(new StringReader(client.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Bodovanje/GetAllPoints.php")));
                int num = 0;
                int index = 0;
                while (reader.Read())
                {
                    if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                    {
                        switch (num)
                        {
                            case 0:
                                this.Ime[index] = reader.Value.ToString().Replace(" ", "");
                                break;

                            case 1:
                                this.Bodovi[index] = reader.Value.ToString();
                                break;
                        }
                        num++;
                        if (num == 2)
                        {
                            num = 0;
                            index++;
                        }
                    }
                }
                foreach (Control control in base.Controls)
                {
                    if (control is TextBox)
                    {
                        int num3 = 0;
                        foreach (string str2 in this.Ime)
                        {
                            if (str2 == null)
                            {
                                break;
                            }
                            if (control.Name == str2)
                            {
                                control.Text = this.Bodovi[num3];
                                break;
                            }
                            num3++;
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
}

