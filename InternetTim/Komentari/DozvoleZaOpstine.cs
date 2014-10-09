namespace InternetTim.Komentari
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;

    public class DozvoleZaOpstine : Form
    {
        private IContainer components = null;
        private Button dodaj;
        private int Gbroj = 0;
        private string[] Ime = new string[0x7d0];
        private string[] Korisnik = new string[0x7d0];
        private Label label1;
        private Label label2;
        private Label label3;
        private ListBox listBox1;
        private ListBox listBox2;
        private ListBox listBox3;
        private Button obrisi;
        private string[] Opstina = new string[0x7d0];
        private string[] Prezime = new string[0x7d0];

        public DozvoleZaOpstine()
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

        private void dodaj_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                WebClient client = new WebClient();
                if (client.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/DozvoleZaIzvestaje/InsertNewRegionToUser.php?Id=" + this.Korisnik[this.listBox1.SelectedIndex] + "&Opstina=" + this.listBox2.SelectedItem.ToString()).Contains("OKET"))
                {
                    this.listBox3.Items.Add(this.listBox2.SelectedItem.ToString());
                }
                Cursor.Current = Cursors.Default;
            }
            catch
            {
            }
        }

        private void DozvoleZaOpstine_Shown(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                WebClient client = new WebClient();
                JsonTextReader reader = new JsonTextReader(new StringReader(client.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Obavestenja/GetUsersInfo2.php?Id=123456789asd")));
                int num = 0;
                while (reader.Read())
                {
                    if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                    {
                        switch (num)
                        {
                            case 0:
                                this.Korisnik[this.Gbroj] = reader.Value.ToString();
                                break;

                            case 1:
                                this.Ime[this.Gbroj] = reader.Value.ToString();
                                break;

                            case 2:
                                this.Prezime[this.Gbroj] = reader.Value.ToString();
                                break;

                            case 3:
                                this.Opstina[this.Gbroj] = reader.Value.ToString();
                                break;
                        }
                        num++;
                        if (num == 4)
                        {
                            this.Gbroj++;
                            num = 0;
                        }
                    }
                }
                string str2 = "";
                this.listBox2.Items.Add(" Sve opštine");
                for (int i = 0; i < this.Gbroj; i++)
                {
                    this.listBox1.Items.Add(this.Ime[i] + " " + this.Prezime[i] + " - " + this.Opstina[i]);
                    if (!str2.Contains(this.Opstina[i]))
                    {
                        str2 = str2 + " " + this.Opstina[i];
                        this.listBox2.Items.Add(this.Opstina[i]);
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch
            {
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(DozvoleZaOpstine));
            this.listBox1 = new ListBox();
            this.label1 = new Label();
            this.listBox2 = new ListBox();
            this.listBox3 = new ListBox();
            this.dodaj = new Button();
            this.obrisi = new Button();
            this.label2 = new Label();
            this.label3 = new Label();
            base.SuspendLayout();
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new Point(12, 0x1a);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new Size(0x131, 0x25a);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new EventHandler(this.listBox1_SelectedIndexChanged);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x2e, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Korisnici";
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new Point(0x28b, 0x1a);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new Size(0x121, 0x25a);
            this.listBox2.TabIndex = 2;
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new Point(0x143, 0x2c);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new Size(0x142, 0x1e5);
            this.listBox3.TabIndex = 3;
            this.dodaj.Location = new Point(0x144, 0x218);
            this.dodaj.Name = "dodaj";
            this.dodaj.Size = new Size(0x141, 0x29);
            this.dodaj.TabIndex = 4;
            this.dodaj.Text = "DODAJ OPŠTINU";
            this.dodaj.UseVisualStyleBackColor = true;
            this.dodaj.Click += new EventHandler(this.dodaj_Click);
            this.obrisi.Location = new Point(0x143, 0x247);
            this.obrisi.Name = "obrisi";
            this.obrisi.Size = new Size(0x141, 0x29);
            this.obrisi.TabIndex = 5;
            this.obrisi.Text = "OBRIŠI OPŠTINU";
            this.obrisi.UseVisualStyleBackColor = true;
            this.obrisi.Click += new EventHandler(this.obrisi_Click);
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(350, 7);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x110, 0x18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Definisanje dozvola za izveštaje";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(370, 0x1c);
            this.label3.Name = "label3";
            this.label3.Size = new Size(230, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Lista dozvoljenih opština za izabranog korisnika";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(0x3b8, 0x27a);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.obrisi);
            base.Controls.Add(this.dodaj);
            base.Controls.Add(this.listBox3);
            base.Controls.Add(this.listBox2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.listBox1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "DozvoleZaOpstine";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Dozvole za izveštaje";
            base.Shown += new EventHandler(this.DozvoleZaOpstine_Shown);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string s = new WebClient().DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/DozvoleZaIzvestaje/GetRegionsForUser.php?Id=" + this.Korisnik[this.listBox1.SelectedIndex]);
                this.listBox3.Items.Clear();
                JsonTextReader reader = new JsonTextReader(new StringReader(s));
                int num = 0;
                while (reader.Read())
                {
                    if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                    {
                        if (num == 0)
                        {
                            this.listBox3.Items.Add(reader.Value.ToString());
                        }
                        num++;
                        if (num == 1)
                        {
                            num = 0;
                        }
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch
            {
            }
        }

        private void obrisi_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string str = new WebClient().DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/DozvoleZaIzvestaje/DeleteRegionFromUser.php?Id=" + this.Korisnik[this.listBox1.SelectedIndex] + "&Opstina=" + this.listBox3.SelectedItem.ToString());
                this.listBox3.Items.Remove(this.listBox3.SelectedItem.ToString());
                Cursor.Current = Cursors.Default;
            }
            catch
            {
            }
        }
    }
}

