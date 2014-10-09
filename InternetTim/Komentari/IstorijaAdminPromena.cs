namespace InternetTim.Komentari
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;

    public class IstorijaAdminPromena : Form
    {
        private IContainer components = null;
        private RichTextBox richTextBox1;

        public IstorijaAdminPromena()
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(IstorijaAdminPromena));
            this.richTextBox1 = new RichTextBox();
            base.SuspendLayout();
            this.richTextBox1.Dock = DockStyle.Fill;
            this.richTextBox1.Location = new Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new Size(0x2e8, 0x1d7);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x2e8, 0x1d7);
            base.Controls.Add(this.richTextBox1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "IstorijaAdminPromena";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Istorija vesti";
            base.Shown += new EventHandler(this.IstorijaAdminPromena_Shown);
            base.ResumeLayout(false);
        }

        private void IstorijaAdminPromena_Shown(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                JsonTextReader reader = new JsonTextReader(new StringReader(client.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/GetAllAdminHistory.php")));
                int num = 0;
                while (reader.Read())
                {
                    if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                    {
                        switch (num)
                        {
                            case 0:
                            {
                                string text = "Korisnik: ";
                                int length = this.richTextBox1.Text.Length;
                                this.richTextBox1.AppendText(text);
                                this.richTextBox1.Select(length, text.Length);
                                this.richTextBox1.SelectionColor = Color.Green;
                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                                string str3 = reader.Value.ToString() + "\n";
                                int start = this.richTextBox1.Text.Length;
                                this.richTextBox1.AppendText(str3);
                                this.richTextBox1.Select(start, str3.Length);
                                this.richTextBox1.SelectionColor = Color.Blue;
                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f);
                                break;
                            }
                            case 1:
                            {
                                string str4 = "Naslov vesti: ";
                                int num4 = this.richTextBox1.Text.Length;
                                this.richTextBox1.AppendText(str4);
                                this.richTextBox1.Select(num4, str4.Length);
                                this.richTextBox1.SelectionColor = Color.Green;
                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                                string str5 = reader.Value.ToString() + "\n";
                                int num5 = this.richTextBox1.Text.Length;
                                this.richTextBox1.AppendText(str5);
                                this.richTextBox1.Select(num5, str5.Length);
                                this.richTextBox1.SelectionColor = Color.Blue;
                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f);
                                break;
                            }
                            case 2:
                            {
                                string str6 = "Link vesti: ";
                                int num6 = this.richTextBox1.Text.Length;
                                this.richTextBox1.AppendText(str6);
                                this.richTextBox1.Select(num6, str6.Length);
                                this.richTextBox1.SelectionColor = Color.Green;
                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                                string str7 = reader.Value.ToString() + "\n";
                                int num7 = this.richTextBox1.Text.Length;
                                this.richTextBox1.AppendText(str7);
                                this.richTextBox1.Select(num7, str7.Length);
                                this.richTextBox1.SelectionColor = Color.Blue;
                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f);
                                break;
                            }
                            case 3:
                            {
                                string str8 = "Akcija korisnika: ";
                                int num8 = this.richTextBox1.Text.Length;
                                this.richTextBox1.AppendText(str8);
                                this.richTextBox1.Select(num8, str8.Length);
                                this.richTextBox1.SelectionColor = Color.Green;
                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                                string str9 = reader.Value.ToString() + "\n";
                                int num9 = this.richTextBox1.Text.Length;
                                this.richTextBox1.AppendText(str9);
                                this.richTextBox1.Select(num9, str9.Length);
                                this.richTextBox1.SelectionColor = Color.Blue;
                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f);
                                break;
                            }
                            case 4:
                            {
                                string str10 = "Datum: ";
                                int num10 = this.richTextBox1.Text.Length;
                                this.richTextBox1.AppendText(str10);
                                this.richTextBox1.Select(num10, str10.Length);
                                this.richTextBox1.SelectionColor = Color.Green;
                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                                string str11 = reader.Value.ToString() + "\n";
                                int num11 = this.richTextBox1.Text.Length;
                                this.richTextBox1.AppendText(str11);
                                this.richTextBox1.Select(num11, str11.Length);
                                this.richTextBox1.SelectionColor = Color.Blue;
                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f);
                                break;
                            }
                            case 5:
                            {
                                string str12 = "Vreme: ";
                                int num12 = this.richTextBox1.Text.Length;
                                this.richTextBox1.AppendText(str12);
                                this.richTextBox1.Select(num12, str12.Length);
                                this.richTextBox1.SelectionColor = Color.Green;
                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                                string str13 = reader.Value.ToString() + "\n\n\n";
                                int num13 = this.richTextBox1.Text.Length;
                                this.richTextBox1.AppendText(str13);
                                this.richTextBox1.Select(num13, str13.Length);
                                this.richTextBox1.SelectionColor = Color.Blue;
                                this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 10f);
                                break;
                            }
                        }
                        num++;
                        if (num == 6)
                        {
                            num = 0;
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

