namespace InternetTim.Obavestenja
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;

    public class PodesavanjeOpstina : Form
    {
        private Button button1;
        private Button button2;
        private IContainer components = null;
        private int Gbroj = 0;
        private string[] Ime = new string[0x7d0];
        private string[] Korisnik = new string[0x7d0];
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ListBox listBox1;
        private ListBox listBox2;
        private ListBox listBox3;
        private string[] Opstina = new string[0x7d0];
        private string[] Prezime = new string[0x7d0];

        public PodesavanjeOpstina()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string str = new WebClient().DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Obavestenja/DeleteRegionFromUser.php?Id=" + this.Korisnik[this.listBox1.SelectedIndex] + "&Opstina=" + this.listBox3.SelectedItem.ToString());
                this.listBox3.Items.Remove(this.listBox3.SelectedItem.ToString());
                Cursor.Current = Cursors.Default;
            }
            catch
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                WebClient client = new WebClient();
                if (client.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Obavestenja/InsertNewRegionToUser.php?Id=" + this.Korisnik[this.listBox1.SelectedIndex] + "&Opstina=" + this.listBox2.SelectedItem.ToString()).Contains("OKET"))
                {
                    this.listBox3.Items.Add(this.listBox2.SelectedItem.ToString());
                }
                Cursor.Current = Cursors.Default;
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(PodesavanjeOpstina));
            this.listBox1 = new ListBox();
            this.label1 = new Label();
            this.listBox2 = new ListBox();
            this.label2 = new Label();
            this.listBox3 = new ListBox();
            this.label3 = new Label();
            this.button1 = new Button();
            this.button2 = new Button();
            this.label4 = new Label();
            base.SuspendLayout();
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new Point(12, 30);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new Size(340, 0x281);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new EventHandler(this.listBox1_SelectedIndexChanged);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x2e, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Korisnici";
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new Point(0x2f2, 30);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new Size(0xe4, 0x281);
            this.listBox2.Sorted = true;
            this.listBox2.TabIndex = 2;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x2ef, 9);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x2b, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Opštine";
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new Point(0x19c, 0x67);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new Size(0x11f, 0x1d8);
            this.listBox3.Sorted = true;
            this.listBox3.TabIndex = 4;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x199, 0x57);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x11f, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Opštine na koje izabrani korisnik može da šalje obaveštenja";
            this.button1.Cursor = Cursors.Hand;
            this.button1.Location = new Point(0x19c, 0x247);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x11f, 0x1f);
            this.button1.TabIndex = 6;
            this.button1.Text = "Obriši opštinu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.button2.Cursor = Cursors.Hand;
            this.button2.Location = new Point(0x19c, 620);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x11f, 0x1f);
            this.button2.TabIndex = 7;
            this.button2.Text = "Ubaci opštinu koju ste odabrali na desnoj listi (Opštine)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.Location = new Point(0x161, 0x35);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x18b, 0x19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Uređenje dozvola za slanje obaveštenja";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.NavajoWhite;
            base.ClientSize = new Size(0x3e1, 0x2a6);
            base.Controls.Add(this.label4);
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
            base.Name = "PodesavanjeOpstina";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Opštine slanje";
            base.Shown += new EventHandler(this.PodesavanjeOpstina_Shown);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string s = new WebClient().DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Obavestenja/GetRegionsForUser.php?Id=" + this.Korisnik[this.listBox1.SelectedIndex]);
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

        private void PodesavanjeOpstina_Shown(object sender, EventArgs e)
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
    }
}

