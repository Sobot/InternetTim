namespace InternetTim.Dozvole
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;

    public class VidljivostOpcija : Form
    {
        private Button button1;
        private Button button2;
        private IContainer components = null;
        private string[] Id = new string[0xbb8];
        private string[] Ime = new string[0xbb8];
        private Label label1;
        private Label label2;
        private Label label3;
        private ListBox listBox1;
        private ListBox listBox2;
        private ListBox listBox3;
        private string[] Nivo = new string[0xbb8];
        private string[] Opstina = new string[0xbb8];
        private string[] Prezime = new string[0xbb8];
        private string[] PrivremeniId = new string[0xbb8];
        private string[] PrivremeniNivo = new string[0xbb8];
        private int stanje = 0;
        private TextBox textBox1;

        public VidljivostOpcija()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listBox2.SelectedIndex != -1)
                {
                    this.listBox3.Items.Add(this.listBox2.SelectedItem.ToString());
                    WebClient client = new WebClient();
                    string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/NivoKorisnika/UpdateUserPermit.php?";
                    address = address + "&Id=" + this.PrivremeniId[this.listBox1.SelectedIndex];
                    string str2 = this.KreiranjeN();
                    address = address + "&Nivo=" + str2;
                    string str3 = client.DownloadString(address);
                    this.Nivo[this.listBox1.SelectedIndex] = str2;
                    this.PrivremeniNivo[this.listBox1.SelectedIndex] = str2;
                    MessageBox.Show("GOTOVO", "INFO");
                }
                else
                {
                    MessageBox.Show("Izaberi dozvolu", "INFO");
                }
            }
            catch
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listBox3.SelectedIndex != -1)
                {
                    this.listBox3.Items.Remove(this.listBox3.SelectedItem);
                    WebClient client = new WebClient();
                    string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/NivoKorisnika/UpdateUserPermit.php?";
                    address = address + "&Id=" + this.PrivremeniId[this.listBox1.SelectedIndex];
                    string str2 = this.KreiranjeN();
                    address = address + "&Nivo=" + str2;
                    string str3 = client.DownloadString(address);
                    this.Nivo[this.listBox1.SelectedIndex] = str2;
                    this.PrivremeniNivo[this.listBox1.SelectedIndex] = str2;
                    MessageBox.Show("GOTOVO", "INFO");
                }
                else
                {
                    MessageBox.Show("Izaberi dozvolu za izbacivanje", "INFO");
                }
            }
            catch
            {
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(VidljivostOpcija));
            this.listBox1 = new ListBox();
            this.label1 = new Label();
            this.listBox2 = new ListBox();
            this.label2 = new Label();
            this.listBox3 = new ListBox();
            this.label3 = new Label();
            this.button1 = new Button();
            this.button2 = new Button();
            this.textBox1 = new TextBox();
            base.SuspendLayout();
            this.listBox1.BackColor = Color.Beige;
            this.listBox1.ForeColor = Color.Green;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new Point(12, 0x19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new Size(300, 0x274);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new EventHandler(this.listBox1_SelectedIndexChanged);
            this.label1.AutoSize = true;
            this.label1.ForeColor = Color.White;
            this.label1.Location = new Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x2e, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Korisnici";
            this.listBox2.BackColor = Color.Moccasin;
            this.listBox2.ForeColor = Color.Red;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Items.AddRange(new object[] { 
                "Komande", "Dozvole za program", "Spajanje korisnika", "Bodovanje", "Blokada programa", "Izveštaji", "Obaveštenja > Pošalji poruku", "Obaveštenja > Dozvole za slanje", "Obaveštenja > Poruke na serveru", "Radne grupe", "Radne grupe > Komentari", "Radne grupe > Komentari [ADMIN]", "Radne grupe > Komentari > Opštinski izveštaji", "Radne grupe > Komentari > Gramatičke greške", "Radne grupe > Komentari > Dozvole za izveštaje", "Radne grupe > Komentari > Pričaonica", 
                "Radne grupe > Glasanje na komentare", "Radne grupe > Glasanje na komentare > Unos proxy servera", "Radne grupe >Twitter"
             });
            this.listBox2.Location = new Point(0x28b, 0x19);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new Size(0x13b, 0x274);
            this.listBox2.TabIndex = 2;
            this.label2.AutoSize = true;
            this.label2.ForeColor = Color.White;
            this.label2.Location = new Point(0x288, 9);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x2e, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dozvole";
            this.listBox3.BackColor = Color.Thistle;
            this.listBox3.ForeColor = Color.Purple;
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new Point(0x144, 0x49);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new Size(0x13b, 0x12f);
            this.listBox3.TabIndex = 4;
            this.label3.AutoSize = true;
            this.label3.ForeColor = Color.White;
            this.label3.Location = new Point(0x141, 0x39);
            this.label3.Name = "label3";
            this.label3.Size = new Size(140, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dozvole izabranog korisnika";
            this.button1.Cursor = Cursors.Hand;
            this.button1.Location = new Point(0x144, 0x17e);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x13b, 0x39);
            this.button1.TabIndex = 6;
            this.button1.Text = "DODAJ DOZVOLU";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.button2.Cursor = Cursors.Hand;
            this.button2.Location = new Point(0x144, 0x1bd);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x13b, 0x39);
            this.button2.TabIndex = 7;
            this.button2.Text = "OBRIŠI DOZVOLU";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.textBox1.Location = new Point(0x41, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0xf7, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Olive;
            base.ClientSize = new Size(0x3d1, 0x295);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.listBox3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.listBox2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.listBox1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "VidljivostOpcija";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Glavne dozvole za opcije";
            base.Shown += new EventHandler(this.VidljivostOpcija_Shown);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private string KreiranjeN()
        {
            string str = "";
            foreach (string str2 in this.listBox3.Items)
            {
                switch (str2)
                {
                    case "Dozvole za program":
                        str = str + "A";
                        break;

                    case "Obaveštenja > Pošalji poruku":
                        str = str + "P";
                        break;

                    case "Obaveštenja > Dozvole za slanje":
                        str = str + "S";
                        break;

                    case "Obaveštenja > Poruke na serveru":
                        str = str + "N";
                        break;

                    case "Radne grupe":
                        str = str + "R";
                        break;

                    case "Radne grupe > Komentari":
                        str = str + "K";
                        break;

                    case "Radne grupe > Komentari [ADMIN]":
                        str = str + "F";
                        break;

                    case "Blokada programa":
                        str = str + "B";
                        break;

                    case "Izveštaji":
                        str = str + "I";
                        break;

                    case "Radne grupe > Komentari > Gramatičke greške":
                        str = str + "G";
                        break;

                    case "Bodovanje":
                        str = str + "Q";
                        break;

                    case "Radne grupe > Glasanje na komentare":
                        str = str + "W";
                        break;

                    case "Radne grupe > Komentari > Dozvole za izveštaje":
                        str = str + "E";
                        break;

                    case "Radne grupe > Komentari > Opštinski izveštaji":
                        str = str + "T";
                        break;

                    case "Spajanje korisnika":
                        str = str + "Y";
                        break;

                    case "Komande":
                        str = str + "U";
                        break;

                    case "Radne grupe >Twitter":
                        str = str + "O";
                        break;

                    case "Radne grupe > Glasanje na komentare > Unos proxy servera":
                        str = str + "M";
                        break;

                    case "Radne grupe > Komentari > Pričaonica":
                        str = str + "X";
                        break;
                }
            }
            return str;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listBox3.Items.Clear();
            int selectedIndex = this.listBox1.SelectedIndex;
            if (this.PrivremeniNivo[selectedIndex].Contains("A"))
            {
                this.listBox3.Items.Add("Dozvole za program");
            }
            if (this.PrivremeniNivo[selectedIndex].Contains("P"))
            {
                this.listBox3.Items.Add("Obaveštenja > Pošalji poruku");
            }
            if (this.PrivremeniNivo[selectedIndex].Contains("S"))
            {
                this.listBox3.Items.Add("Obaveštenja > Dozvole za slanje");
            }
            if (this.PrivremeniNivo[selectedIndex].Contains("N"))
            {
                this.listBox3.Items.Add("Obaveštenja > Poruke na serveru");
            }
            if (this.PrivremeniNivo[selectedIndex].Contains("R"))
            {
                this.listBox3.Items.Add("Radne grupe");
            }
            if (this.PrivremeniNivo[selectedIndex].Contains("K"))
            {
                this.listBox3.Items.Add("Radne grupe > Komentari");
            }
            if (this.PrivremeniNivo[selectedIndex].Contains("F"))
            {
                this.listBox3.Items.Add("Radne grupe > Komentari [ADMIN]");
            }
            if (this.PrivremeniNivo[selectedIndex].Contains("B"))
            {
                this.listBox3.Items.Add("Blokada programa");
            }
            if (this.PrivremeniNivo[selectedIndex].Contains("I"))
            {
                this.listBox3.Items.Add("Izveštaji");
            }
            if (this.PrivremeniNivo[selectedIndex].Contains("G"))
            {
                this.listBox3.Items.Add("Radne grupe > Komentari > Gramatičke greške");
            }
            if (this.PrivremeniNivo[selectedIndex].Contains("Q"))
            {
                this.listBox3.Items.Add("Bodovanje");
            }
            if (this.PrivremeniNivo[selectedIndex].Contains("W"))
            {
                this.listBox3.Items.Add("Radne grupe > Glasanje na komentare");
            }
            if (this.PrivremeniNivo[selectedIndex].Contains("E"))
            {
                this.listBox3.Items.Add("Radne grupe > Komentari > Dozvole za izveštaje");
            }
            if (this.PrivremeniNivo[selectedIndex].Contains("T"))
            {
                this.listBox3.Items.Add("Radne grupe > Komentari > Opštinski izveštaji");
            }
            if (this.PrivremeniNivo[selectedIndex].Contains("Y"))
            {
                this.listBox3.Items.Add("Spajanje korisnika");
            }
            if (this.PrivremeniNivo[selectedIndex].Contains("U"))
            {
                this.listBox3.Items.Add("Komande");
            }
            if (this.PrivremeniNivo[selectedIndex].Contains("O"))
            {
                this.listBox3.Items.Add("Radne grupe >Twitter");
            }
            if (this.PrivremeniNivo[selectedIndex].Contains("M"))
            {
                this.listBox3.Items.Add("Radne grupe > Glasanje na komentare > Unos proxy servera");
            }
            if (this.PrivremeniNivo[selectedIndex].Contains("X"))
            {
                this.listBox3.Items.Add("Radne grupe > Komentari > Pričaonica");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            int index = 0;
            Array.Clear(this.PrivremeniId, 0, 0xbb8);
            Array.Clear(this.PrivremeniNivo, 0, 0xbb8);
            for (int i = 0; i < 0xbb8; i++)
            {
                try
                {
                    if (this.Ime[i] == null)
                    {
                        break;
                    }
                    if (this.Ime[i].ToLower().Contains(this.textBox1.Text.ToLower()) || this.Prezime[i].ToLower().Contains(this.textBox1.Text.ToLower()))
                    {
                        this.listBox1.Items.Add(this.Ime[i] + " " + this.Prezime[i] + " - " + this.Opstina[i]);
                        this.PrivremeniId[index] = this.Id[i];
                        this.PrivremeniNivo[index] = this.Nivo[i];
                        index++;
                    }
                }
                catch
                {
                    break;
                }
            }
        }

        private void Ucitavanje()
        {
            try
            {
                Array.Clear(this.Id, 0, 0xbb8);
                Array.Clear(this.Ime, 0, 0xbb8);
                Array.Clear(this.Prezime, 0, 0xbb8);
                Array.Clear(this.Opstina, 0, 0xbb8);
                Array.Clear(this.Nivo, 0, 0xbb8);
                this.stanje = 0;
                Array.Clear(this.PrivremeniId, 0, 0xbb8);
                Array.Clear(this.PrivremeniNivo, 0, 0xbb8);
                this.listBox1.Items.Clear();
                WebClient client = new WebClient();
                string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/NivoKorisnika/GetUsersInfoAll3.php?";
                address = address + "Id=sdf";
                JsonTextReader reader = new JsonTextReader(new StringReader(client.DownloadString(address)));
                int num = 0;
                while (reader.Read())
                {
                    if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                    {
                        switch (num)
                        {
                            case 0:
                                this.Id[this.stanje] = reader.Value.ToString();
                                this.PrivremeniId[this.stanje] = reader.Value.ToString();
                                break;

                            case 1:
                                this.Ime[this.stanje] = reader.Value.ToString();
                                break;

                            case 2:
                                this.Prezime[this.stanje] = reader.Value.ToString();
                                break;

                            case 3:
                                this.Opstina[this.stanje] = reader.Value.ToString();
                                break;

                            case 4:
                                this.Nivo[this.stanje] = reader.Value.ToString();
                                this.PrivremeniNivo[this.stanje] = reader.Value.ToString();
                                break;
                        }
                        num++;
                        if (num == 5)
                        {
                            num = 0;
                            this.stanje++;
                        }
                    }
                }
                int index = 0;
                foreach (string str3 in this.Id)
                {
                    if (str3 == null)
                    {
                        return;
                    }
                    this.listBox1.Items.Add(this.Ime[index] + " " + this.Prezime[index] + " - " + this.Opstina[index]);
                    index++;
                }
            }
            catch
            {
            }
        }

        private void VidljivostOpcija_Shown(object sender, EventArgs e)
        {
            this.Ucitavanje();
        }
    }
}

