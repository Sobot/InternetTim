namespace InternetTim.Komentari
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;

    public class MojiIzvestajiSlanja : Form
    {
        private IContainer components = null;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        public string ID = "";
        private Label label1;
        private Label label2;
        private Label label3;
        private Panel panel1;
        private Button Potvrdi;
        private RichTextBox richTextBox1;

        public MojiIzvestajiSlanja()
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(MojiIzvestajiSlanja));
            this.panel1 = new Panel();
            this.Potvrdi = new Button();
            this.label3 = new Label();
            this.label2 = new Label();
            this.label1 = new Label();
            this.dateTimePicker2 = new DateTimePicker();
            this.dateTimePicker1 = new DateTimePicker();
            this.richTextBox1 = new RichTextBox();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.panel1.BackColor = Color.White;
            this.panel1.BorderStyle = BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.Potvrdi);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x374, 50);
            this.panel1.TabIndex = 0;
            this.Potvrdi.Cursor = Cursors.Hand;
            this.Potvrdi.Location = new Point(0x214, 4);
            this.Potvrdi.Name = "Potvrdi";
            this.Potvrdi.Size = new Size(0x4b, 0x27);
            this.Potvrdi.TabIndex = 5;
            this.Potvrdi.Text = "Potvrdi";
            this.Potvrdi.UseVisualStyleBackColor = true;
            this.Potvrdi.Click += new EventHandler(this.Potvrdi_Click);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0xf1, 0x1b);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x13, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "do";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(7, 0x1c);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x15, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Od";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x209, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Izaberite vremenski interval od datuma do datuma i kliknite na potvrdi.Program će napraviti tekstualni izveštaj.";
            this.dateTimePicker2.Location = new Point(0x10a, 0x16);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new Size(200, 20);
            this.dateTimePicker2.TabIndex = 1;
            this.dateTimePicker1.Location = new Point(0x22, 0x16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.richTextBox1.Dock = DockStyle.Fill;
            this.richTextBox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.richTextBox1.Location = new Point(0, 50);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new Size(0x374, 0x231);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.LinkClicked += new LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x374, 0x263);
            base.Controls.Add(this.richTextBox1);
            base.Controls.Add(this.panel1);
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            this.MinimumSize = new Size(700, 400);
            base.Name = "MojiIzvestajiSlanja";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Izveštaj slanja";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            base.ResumeLayout(false);
        }

        private void Potvrdi_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dateTimePicker1.Value < this.dateTimePicker2.Value)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    this.richTextBox1.Text = "";
                    string str = "";
                    string str2 = "";
                    decimal num = 0M;
                    try
                    {
                        for (int i = 0; i < 0x41; i++)
                        {
                            try
                            {
                                if (this.dateTimePicker1.Value > this.dateTimePicker2.Value)
                                {
                                    break;
                                }
                                string str3 = "";
                                string str4 = this.dateTimePicker1.Value.Day.ToString();
                                if (str4.Length == 1)
                                {
                                    str4 = "0" + str4;
                                }
                                string str5 = this.dateTimePicker1.Value.Month.ToString();
                                if (str5.Length == 1)
                                {
                                    str5 = "0" + str5;
                                }
                                str3 = str4 + "." + str5 + "." + this.dateTimePicker1.Value.Year.ToString();
                                if (i == 0)
                                {
                                    str = str3;
                                }
                                str2 = str3;
                                WebClient client = new WebClient();
                                JsonTextReader reader = new JsonTextReader(new StringReader(client.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/GetCommForUserFromId3.php?Id=" + this.ID + "&Datum=" + str3)));
                                int num3 = 0;
                                this.richTextBox1.AppendText("----------------------------------------------------------------------------------------------------------------------------------------------------------\n\n");
                                string str7 = "Objavljeni komentari za " + str3;
                                int textLength = this.richTextBox1.TextLength;
                                this.richTextBox1.AppendText(str7);
                                this.richTextBox1.SelectionStart = textLength;
                                this.richTextBox1.SelectionLength = str7.Length;
                                this.richTextBox1.SelectionColor = Color.Red;
                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 18f);
                                this.richTextBox1.AppendText("\n\n");
                                decimal num5 = 0M;
                                decimal num6 = 0M;
                                while (reader.Read())
                                {
                                    if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                                    {
                                        switch (num3)
                                        {
                                            case 0:
                                            {
                                                string str8 = "VEST - NASLOV I LINK\n";
                                                int num7 = this.richTextBox1.Text.Length;
                                                this.richTextBox1.AppendText(str8);
                                                this.richTextBox1.Select(num7, str8.Length);
                                                this.richTextBox1.SelectionColor = Color.Green;
                                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
                                                string str9 = reader.Value.ToString() + "\n";
                                                int num8 = this.richTextBox1.Text.Length;
                                                this.richTextBox1.AppendText(str9);
                                                this.richTextBox1.Select(num8, str9.Length);
                                                this.richTextBox1.SelectionColor = Color.Blue;
                                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f);
                                                break;
                                            }
                                            case 1:
                                            {
                                                string str10 = reader.Value.ToString().Replace("[[]]", "&") + "\n";
                                                int num9 = this.richTextBox1.Text.Length;
                                                this.richTextBox1.AppendText(str10);
                                                this.richTextBox1.Select(num9, str10.Length);
                                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f);
                                                num5 = 0M;
                                                break;
                                            }
                                            case 2:
                                            {
                                                string str11 = "KOMENTAR\n";
                                                int num10 = this.richTextBox1.Text.Length;
                                                this.richTextBox1.AppendText(str11);
                                                this.richTextBox1.Select(num10, str11.Length);
                                                this.richTextBox1.SelectionColor = Color.Green;
                                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
                                                string str12 = reader.Value.ToString() + "\n";
                                                int num11 = this.richTextBox1.Text.Length;
                                                this.richTextBox1.AppendText(str12);
                                                this.richTextBox1.Select(num11, str12.Length);
                                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f);
                                                break;
                                            }
                                            case 3:
                                                num5 = decimal.Parse(reader.Value.ToString());
                                                break;

                                            case 4:
                                                num5 += decimal.Parse(reader.Value.ToString());
                                                break;

                                            case 5:
                                                num5 += decimal.Parse(reader.Value.ToString());
                                                break;

                                            case 6:
                                            {
                                                string str13 = "BODOVANJE\n";
                                                int num12 = this.richTextBox1.Text.Length;
                                                this.richTextBox1.AppendText(str13);
                                                this.richTextBox1.Select(num12, str13.Length);
                                                this.richTextBox1.SelectionColor = Color.Green;
                                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
                                                num5 += decimal.Parse(reader.Value.ToString());
                                                if (num5.ToString().Contains(",") || (num5 > 5M))
                                                {
                                                    num5 /= 100M;
                                                }
                                                num6 += num5;
                                                this.richTextBox1.AppendText("Komentar vredi ");
                                                string str14 = num5.ToString() + " ";
                                                int num13 = this.richTextBox1.Text.Length;
                                                this.richTextBox1.AppendText(str14);
                                                this.richTextBox1.Select(num13, str14.Length);
                                                this.richTextBox1.SelectionColor = Color.Red;
                                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
                                                string str15 = "bodova\n\n\n\n\n";
                                                int num14 = this.richTextBox1.Text.Length;
                                                this.richTextBox1.AppendText(str15);
                                                this.richTextBox1.Select(num14, str15.Length);
                                                this.richTextBox1.SelectionColor = Color.Black;
                                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f);
                                                break;
                                            }
                                        }
                                        num3++;
                                        if (num3 == 7)
                                        {
                                            num3 = 0;
                                        }
                                    }
                                }
                                string str16 = "Za " + str3 + " ukupno bodova ";
                                int num15 = this.richTextBox1.Text.Length;
                                this.richTextBox1.AppendText(str16);
                                this.richTextBox1.Select(num15, str16.Length);
                                this.richTextBox1.SelectionColor = Color.Green;
                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
                                string str17 = num6.ToString() + "\n";
                                num += num6;
                                int num16 = this.richTextBox1.Text.Length;
                                this.richTextBox1.AppendText(str17);
                                this.richTextBox1.Select(num16, str17.Length);
                                this.richTextBox1.SelectionColor = Color.Red;
                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
                                this.dateTimePicker1.Value = this.dateTimePicker1.Value.Date.AddDays(1.0);
                            }
                            catch
                            {
                                break;
                            }
                        }
                        string text = "\n\n\nOd " + str + " do " + str2 + " imate bodova ";
                        int length = this.richTextBox1.Text.Length;
                        this.richTextBox1.AppendText(text);
                        this.richTextBox1.Select(length, text.Length);
                        this.richTextBox1.SelectionColor = Color.BlueViolet;
                        this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 18f, FontStyle.Bold);
                        string str19 = num.ToString() + "\n";
                        int start = this.richTextBox1.Text.Length;
                        this.richTextBox1.AppendText(str19);
                        this.richTextBox1.Select(start, str19.Length);
                        this.richTextBox1.SelectionColor = Color.Red;
                        this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 22f, FontStyle.Bold);
                    }
                    catch
                    {
                    }
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("Izabrali ste veći početni datum od krajnjeg datuma.", "INFO");
                }
            }
            catch
            {
                MessageBox.Show("Dogodila se greska, probajte ponovo ili restartujte program.", "INFO");
            }
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
    }
}

