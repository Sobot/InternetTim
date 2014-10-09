namespace InternetTim.Obavestenja
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;

    public class ObavestenjaSaServera : Form
    {
        private IContainer components = null;
        private Label label1;
        private ListBox listBox1;
        private Button ObrisiPoruku;
        private Button PrikaziPoruku;
        private string[] Sid = new string[0x1388];
        private int stanje = 0;

        public ObavestenjaSaServera()
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(ObavestenjaSaServera));
            this.listBox1 = new ListBox();
            this.PrikaziPoruku = new Button();
            this.ObrisiPoruku = new Button();
            this.label1 = new Label();
            base.SuspendLayout();
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new Point(12, 30);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.SelectionMode = SelectionMode.MultiSimple;
            this.listBox1.Size = new Size(0x3e9, 0x274);
            this.listBox1.TabIndex = 0;
            this.PrikaziPoruku.Cursor = Cursors.Hand;
            this.PrikaziPoruku.Location = new Point(12, 0x298);
            this.PrikaziPoruku.Name = "PrikaziPoruku";
            this.PrikaziPoruku.Size = new Size(0x1e5, 0x17);
            this.PrikaziPoruku.TabIndex = 1;
            this.PrikaziPoruku.Text = "Prikaži poruku";
            this.PrikaziPoruku.UseVisualStyleBackColor = true;
            this.PrikaziPoruku.Click += new EventHandler(this.PrikaziPoruku_Click);
            this.ObrisiPoruku.Cursor = Cursors.Hand;
            this.ObrisiPoruku.Location = new Point(0x210, 0x298);
            this.ObrisiPoruku.Name = "ObrisiPoruku";
            this.ObrisiPoruku.Size = new Size(0x1e5, 0x17);
            this.ObrisiPoruku.TabIndex = 2;
            this.ObrisiPoruku.Text = "Obriši poruku sa servera";
            this.ObrisiPoruku.UseVisualStyleBackColor = true;
            this.ObrisiPoruku.Click += new EventHandler(this.ObrisiPoruku_Click);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x153, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Datum > Ime korisnika - naslov poruke : za [Opština na koju je poslato]";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(0x402, 0x2b5);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.ObrisiPoruku);
            base.Controls.Add(this.PrikaziPoruku);
            base.Controls.Add(this.listBox1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "ObavestenjaSaServera";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Obaveštenja na serveru";
            base.Shown += new EventHandler(this.ObavestenjaSaServera_Shown);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void ObavestenjaSaServera_Shown(object sender, EventArgs e)
        {
            this.Ucitavanje();
        }

        private void ObrisiPoruku_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                foreach (int num in this.listBox1.SelectedIndices)
                {
                    try
                    {
                        string str = new WebClient().DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Obavestenja/DeleteMessagesById.php?Id=" + this.Sid[num]);
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Dogodila se greška, pokušajte kasnije ponovo.", "INFO");
                base.Close();
            }
            Cursor.Current = Cursors.Default;
            this.Ucitavanje();
        }

        private void PrikaziPoruku_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                foreach (int num in this.listBox1.SelectedIndices)
                {
                    try
                    {
                        string s = new WebClient().DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Obavestenja/GetMessagesById.php?Id=" + this.Sid[num]);
                        if (!s.Contains("NEMA PORUKA"))
                        {
                            JsonTextReader reader = new JsonTextReader(new StringReader(s));
                            int num2 = 0;
                            string str2 = "";
                            string str3 = "";
                            string str4 = "";
                            while (reader.Read())
                            {
                                if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                                {
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
                                        num2 = 0;
                                        new PrikaziObavestenje { Naslov = str2, Tekst = str3 }.Show();
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
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Dogodila se greška, pokušajte kasnije ponovo.", "INFO");
                base.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        private void Ucitavanje()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.listBox1.Items.Clear();
                this.stanje = 0;
                Array.Clear(this.Sid, 0, 0x1388);
                WebClient client = new WebClient();
                JsonTextReader reader = new JsonTextReader(new StringReader(client.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Obavestenja/GetMessagesFromServer.php")));
                int num = 0;
                string str2 = "";
                while (reader.Read())
                {
                    if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                    {
                        switch (num)
                        {
                            case 0:
                                this.Sid[this.stanje] = reader.Value.ToString();
                                this.stanje++;
                                break;

                            case 1:
                                str2 = reader.Value.ToString();
                                break;

                            case 2:
                                if (reader.Value.ToString() == "SSS")
                                {
                                    this.listBox1.Items.Add(str2 + "   : za [Sve opštine]");
                                }
                                else
                                {
                                    this.listBox1.Items.Add(str2 + "   : za [" + reader.Value.ToString() + "]");
                                }
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
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Dogodila se greška, pokušajte kasnije ponovo.", "INFO");
                base.Close();
            }
            Cursor.Current = Cursors.Default;
        }
    }
}

