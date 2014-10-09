namespace InternetTim.Komande
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;

    public class UradiKomandu : Form
    {
        private Button button1;
        private IContainer components = null;
        private string[] Id = new string[0xbb8];
        private string[] Ime = new string[0xbb8];
        private Label label1;
        private Label label2;
        private ListBox listBox1;
        private ListBox listBox2;
        private string[] Nivo = new string[0xbb8];
        private string[] Opstina = new string[0xbb8];
        private string[] Prezime = new string[0xbb8];
        private int stanje = 0;

        public UradiKomandu()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((this.listBox1.SelectedIndex != -1) && (this.listBox2.SelectedIndex != -1))
                {
                    try
                    {
                        string str = "";
                        if (this.listBox2.SelectedItem.ToString() == "BRISANJE KOMENTARA KOJI SU LOKALNO SAČUVANI NA RAČUNARU KORISNIKA")
                        {
                            str = "SACUVANIKOMENTARIBRISANJE";
                        }
                        WebClient client = new WebClient();
                        string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Komande/InsertNewCommand.php?";
                        address = (address + "&id1=" + this.Id[this.listBox1.SelectedIndex]) + "&id2=" + str;
                        string str3 = client.DownloadString(address);
                        MessageBox.Show("POSLATA KOMANDA", "INFO");
                    }
                    catch
                    {
                    }
                }
                else
                {
                    MessageBox.Show("Izaberite korisnika i komandu", "INFO");
                }
            }
            catch
            {
                MessageBox.Show("Dogodila se greska, pokusajte ponovo ili restartujte program.", "INFO");
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
            this.listBox1 = new ListBox();
            this.listBox2 = new ListBox();
            this.button1 = new Button();
            this.label1 = new Label();
            this.label2 = new Label();
            base.SuspendLayout();
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new Point(12, 0x19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new Size(0x22c, 0x274);
            this.listBox1.TabIndex = 0;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Items.AddRange(new object[] { "BRISANJE KOMENTARA KOJI SU LOKALNO SAČUVANI NA RAČUNARU KORISNIKA" });
            this.listBox2.Location = new Point(0x23e, 0x19);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new Size(0x232, 0x274);
            this.listBox2.TabIndex = 1;
            this.button1.Cursor = Cursors.Hand;
            this.button1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.button1.Location = new Point(12, 0x293);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x464, 0x3d);
            this.button1.TabIndex = 2;
            this.button1.Text = "POŠALJI KOMANDU";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x2e, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Korisnici";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x23e, 6);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Komande";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x47c, 0x2dc);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.listBox2);
            base.Controls.Add(this.listBox1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Name = "UradiKomandu";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Komande";
            base.Shown += new EventHandler(this.UradiKomandu_Shown);
            base.ResumeLayout(false);
            base.PerformLayout();
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
                this.listBox1.Items.Clear();
                WebClient client = new WebClient();
                string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/NivoKorisnika/GetUsersInfoAll2.php?";
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

        private void UradiKomandu_Shown(object sender, EventArgs e)
        {
            this.Ucitavanje();
        }
    }
}

