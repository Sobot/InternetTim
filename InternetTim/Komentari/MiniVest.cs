namespace InternetTim.Komentari
{
    using HtmlAgilityPack;
    using InternetTim.Properties;
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows.Forms;

    public class MiniVest : UserControl
    {
        private BackgroundWorker backgroundWorker1;
        private Label BrojKomentara;
        private IContainer components = null;
        public string GlavniID = "99999";
        private string LinkZaProveru = "";
        private Button Naslov;
        private string NaslovZaUpdate = "";
        public int Otvaranje = 0;
        private Panel panel1;
        private string PerID;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Button PrikazBrojevaMojihKomentara;
        private string SlikaZaUpdate = "";
        private System.Windows.Forms.Timer timer1;
        private int ZutaBoja = 0;

        public event EventHandler<EventArgs> WasClicked;

        public MiniVest()
        {
            this.InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int num;
                string str3;
                string str5;
                string argument = (string) e.Argument;
                string html = "";
                using (WebClient client = new WebClient())
                {
                    if (argument.Contains("b92.net"))
                    {
                        client.Encoding = Encoding.GetEncoding(0x4e2);
                    }
                    else
                    {
                        client.Encoding = Encoding.UTF8;
                    }
                    html = client.DownloadString(argument);
                    client.Dispose();
                }
                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(html);
                if (argument.Contains("b92.net"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//span[@class='comment-number']"))
                        {
                            e.Result = node.InnerText;
                            goto Label_0109;
                        }
                    }
                    catch
                    {
                        e.Result = "0";
                    }
                }
            Label_0109:
                if (argument.Contains("blic.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='article_info']"))
                        {
                            num = 0;
                            while (num < node.ChildNodes[1].ChildNodes.Count)
                            {
                                if (node.ChildNodes[1].ChildNodes[num].InnerText.Contains("Komentara"))
                                {
                                    str3 = node.ChildNodes[1].ChildNodes[num].InnerText.Replace("Komentara", "").Replace(":", "").Replace(" ", "");
                                    e.Result = str3;
                                    break;
                                }
                                num++;
                            }
                            goto Label_0252;
                        }
                    }
                    catch
                    {
                        e.Result = "0";
                    }
                }
            Label_0252:
                if (argument.Contains("kurir-info.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//section[@class='comments_module']"))
                        {
                            str3 = node.ChildNodes[1].ChildNodes[1].InnerText.Replace("(", "").Replace(")", "").Replace("Komentari", "").Replace(" ", "");
                            e.Result = str3;
                            goto Label_0345;
                        }
                    }
                    catch
                    {
                        e.Result = "0";
                    }
                }
            Label_0345:
                if (argument.Contains("novosti.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='articleInfo']"))
                        {
                            num = 0;
                            while (num < node.ChildNodes.Count)
                            {
                                if (node.ChildNodes[num].InnerText.Contains("Komentara"))
                                {
                                    str3 = node.ChildNodes[num].InnerText.Replace("\t", "").Replace("\r", "").Replace("\n", "").Replace(":", "").Replace("Komentara", "").Replace(" ", "");
                                    if (str3.Length > 3)
                                    {
                                        e.Result = "0";
                                    }
                                    else
                                    {
                                        e.Result = str3;
                                    }
                                    break;
                                }
                                num++;
                            }
                            goto Label_04CE;
                        }
                    }
                    catch
                    {
                        e.Result = "0";
                    }
                }
            Label_04CE:
                if (argument.Contains("danas.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='komentari']"))
                        {
                            num = 0;
                            while (num < node.ChildNodes.Count)
                            {
                                if (node.ChildNodes[num].InnerText.Contains("Komentari"))
                                {
                                    str3 = node.ChildNodes[num].InnerText.Replace("(", "").Replace(")", "").Replace("\t", "").Replace("\r", "").Replace("\n", "").Replace(":", "").Replace("Komentari", "").Replace(" ", "");
                                    if (str3.Length > 3)
                                    {
                                        e.Result = "0";
                                    }
                                    else
                                    {
                                        e.Result = str3;
                                    }
                                    break;
                                }
                                num++;
                            }
                            goto Label_067D;
                        }
                    }
                    catch
                    {
                        e.Result = "0";
                    }
                }
            Label_067D:
                if (argument.Contains("politika.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='article_info']"))
                        {
                            string[] strArray = node.InnerHtml.Split(new char[] { '>' });
                            foreach (string str4 in strArray)
                            {
                                if (str4.Contains("komentari") || str4.Contains("коментари"))
                                {
                                    str3 = str4;
                                    str3 = str3.Replace("</a", "").Replace("(", "").Replace(")", "").Replace("\t", "").Replace("\r", "").Replace("\n", "").Replace(":", "").Replace("komentari", "").Replace("коментари", "").Replace(" ", "");
                                    e.Result = str3;
                                    break;
                                }
                            }
                            goto Label_083E;
                        }
                    }
                    catch
                    {
                        e.Result = "0";
                    }
                }
            Label_083E:
                if (argument.Contains("rts.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//td[@class='commentRight']"))
                        {
                            for (int i = 0; i < node.ChildNodes.Count; i++)
                            {
                                if (node.ChildNodes[i].Name.Contains("span"))
                                {
                                    str5 = node.ChildNodes[i].InnerText.Replace(" ", "");
                                    e.Result = str5;
                                    break;
                                }
                            }
                            goto Label_093A;
                        }
                    }
                    catch
                    {
                        e.Result = "0";
                    }
                }
            Label_093A:
                if (argument.Contains("telegraf.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='block-comments']"))
                        {
                            str5 = node.InnerText.Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("Ukupno", "").Replace("komentara", "").Replace("Pošaljite", "").Replace("Vaš", "").Replace("komentari", "").Replace("komentar", "").Replace("Svi", "").Replace(@"\...", "");
                            e.Result = str5;
                            goto Label_0AAF;
                        }
                    }
                    catch
                    {
                        e.Result = "0";
                    }
                }
            Label_0AAF:
                if (argument.Contains("alo.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='widgetAutor']"))
                        {
                            for (num = 0; num < node.ChildNodes.Count; num++)
                            {
                                if (node.ChildNodes[num].InnerHtml.Contains("Komentara"))
                                {
                                    str5 = node.ChildNodes[num].InnerHtml.Replace(" ", "").Replace("<strong>", "").Replace("Komentara:", "").Replace("</strong>", "");
                                    e.Result = str5;
                                    break;
                                }
                            }
                            break;
                        }
                        return;
                    }
                    catch
                    {
                        e.Result = "0";
                    }
                }
            }
            catch
            {
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.BrojKomentara.Text = (string) e.Result;
                if (e.Result.ToString().Length > 0)
                {
                    this.BrojKomentara.Visible = true;
                }
            }
            catch
            {
            }
        }

        private void Control_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.WasClicked != null)
            {
                this.WasClicked(this, EventArgs.Empty);
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

        public Image DownloadImage(string _URL)
        {
            Image image = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(_URL);
                request.AllowWriteStreamBuffering = true;
                request.UserAgent = "Opera/9.52 (Windows NT 6.0; U; en)";
                request.Referer = "http://www.blic.rs";
                request.Timeout = 0x4e20;
                WebResponse response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                image = Image.FromStream(responseStream);
                responseStream.Close();
                response.Close();
            }
            catch
            {
                return null;
            }
            return image;
        }

        public void ImaKomentara(int kom, string por)
        {
            if (kom == 0)
            {
                this.pictureBox3.Visible = false;
            }
            if (kom == 1)
            {
                this.pictureBox3.BackgroundImage = Resources.Comments;
                this.pictureBox3.Visible = true;
                if (por == "PLUS")
                {
                    try
                    {
                        string[] strArray = this.PrikazBrojevaMojihKomentara.Text.Replace(" ", "").Split(new char[] { '/' });
                        this.PrikazBrojevaMojihKomentara.Text = int.Parse(strArray[0]).ToString() + " / " + ((int.Parse(strArray[1]) + 1)).ToString();
                    }
                    catch
                    {
                        this.PrikazBrojevaMojihKomentara.Text = "? / ?";
                    }
                }
                else
                {
                    this.PrikazBrojevaMojihKomentara.Text = por;
                }
                this.PrikazBrojevaMojihKomentara.Visible = true;
            }
            if (kom == 2)
            {
                this.pictureBox3.BackgroundImage = Resources.GladIcon;
                this.pictureBox3.Visible = true;
                this.PrikazBrojevaMojihKomentara.Text = por;
                this.PrikazBrojevaMojihKomentara.Visible = true;
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.BrojKomentara = new Label();
            this.Naslov = new Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new BackgroundWorker();
            this.pictureBox3 = new PictureBox();
            this.pictureBox2 = new PictureBox();
            this.panel1 = new Panel();
            this.PrikazBrojevaMojihKomentara = new Button();
            ((ISupportInitialize) this.pictureBox3).BeginInit();
            ((ISupportInitialize) this.pictureBox2).BeginInit();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.BrojKomentara.AutoSize = true;
            this.BrojKomentara.BackColor = Color.White;
            this.BrojKomentara.BorderStyle = BorderStyle.FixedSingle;
            this.BrojKomentara.Cursor = Cursors.Hand;
            this.BrojKomentara.Dock = DockStyle.Top;
            this.BrojKomentara.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.BrojKomentara.Location = new Point(0, 0);
            this.BrojKomentara.Name = "BrojKomentara";
            this.BrojKomentara.Size = new Size(0x17, 0x1a);
            this.BrojKomentara.TabIndex = 1;
            this.BrojKomentara.Text = "0";
            this.BrojKomentara.Visible = false;
            this.Naslov.BackColor = Color.White;
            this.Naslov.Cursor = Cursors.Hand;
            this.Naslov.Dock = DockStyle.Bottom;
            this.Naslov.FlatAppearance.BorderSize = 0;
            this.Naslov.FlatStyle = FlatStyle.Flat;
            this.Naslov.Location = new Point(0, 0x62);
            this.Naslov.Name = "Naslov";
            this.Naslov.Size = new Size(0xc6, 50);
            this.Naslov.TabIndex = 2;
            this.Naslov.Text = "NASLOV";
            this.Naslov.UseVisualStyleBackColor = false;
            this.timer1.Interval = 0x5dc;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.pictureBox3.BackColor = Color.Transparent;
            this.pictureBox3.BackgroundImage = Resources.Comments;
            this.pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            this.pictureBox3.Location = new Point(0xa5, 0x2f);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new Size(30, 30);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            this.pictureBox2.BackColor = Color.Black;
            this.pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            this.pictureBox2.Cursor = Cursors.Hand;
            this.pictureBox2.Location = new Point(0x94, 0);
            this.pictureBox2.Margin = new Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(50, 0x19);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            this.panel1.BackgroundImage = Resources.newssrbija;
            this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel1.Controls.Add(this.PrikazBrojevaMojihKomentara);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.BrojKomentara);
            this.panel1.Cursor = Cursors.Hand;
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0xc6, 110);
            this.panel1.TabIndex = 5;
            this.PrikazBrojevaMojihKomentara.FlatAppearance.BorderColor = Color.White;
            this.PrikazBrojevaMojihKomentara.FlatAppearance.MouseDownBackColor = Color.White;
            this.PrikazBrojevaMojihKomentara.FlatAppearance.MouseOverBackColor = Color.White;
            this.PrikazBrojevaMojihKomentara.FlatStyle = FlatStyle.Flat;
            this.PrikazBrojevaMojihKomentara.Font = new Font("Microsoft Sans Serif", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.PrikazBrojevaMojihKomentara.Location = new Point(0x98, 0x51);
            this.PrikazBrojevaMojihKomentara.Margin = new Padding(0);
            this.PrikazBrojevaMojihKomentara.Name = "PrikazBrojevaMojihKomentara";
            this.PrikazBrojevaMojihKomentara.Size = new Size(0x2e, 0x12);
            this.PrikazBrojevaMojihKomentara.TabIndex = 5;
            this.PrikazBrojevaMojihKomentara.Text = "0 / 0";
            this.PrikazBrojevaMojihKomentara.UseVisualStyleBackColor = true;
            this.PrikazBrojevaMojihKomentara.Visible = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.BorderStyle = BorderStyle.FixedSingle;
            base.Controls.Add(this.Naslov);
            base.Controls.Add(this.panel1);
            base.Margin = new Padding(1, 2, 1, 2);
            base.Name = "MiniVest";
            base.Size = new Size(0xc6, 0x94);
            base.Load += new EventHandler(this.MiniVest_Load);
            ((ISupportInitialize) this.pictureBox3).EndInit();
            ((ISupportInitialize) this.pictureBox2).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            base.ResumeLayout(false);
        }

        private void MiniVest_Load(object sender, EventArgs e)
        {
            base.MouseClick += new MouseEventHandler(this.Control_MouseClick);
            foreach (Control control in base.Controls)
            {
                control.MouseClick += new MouseEventHandler(this.Control_MouseClick);
            }
        }

        private void naslovtekst_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int num;
                string innerText;
                string html = "";
                string address = e.Argument.ToString();
                if (address.Contains("*"))
                {
                    address = address.Split(new char[] { '*' })[0];
                }
                using (WebClient client = new WebClient())
                {
                    if (address.Contains("b92.net"))
                    {
                        client.Encoding = Encoding.GetEncoding(0x4e2);
                    }
                    else
                    {
                        client.Encoding = Encoding.UTF8;
                    }
                    html = client.DownloadString(address);
                    client.Dispose();
                }
                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(html);
                if (address.Contains("b92.net"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='article-text']"))
                        {
                            num = 0;
                            while (num < node.ChildNodes.Count)
                            {
                                if (node.ChildNodes[num].Name.Contains("h1"))
                                {
                                    e.Result = node.ChildNodes[num].InnerText;
                                    break;
                                }
                                num++;
                            }
                            goto Label_0198;
                        }
                    }
                    catch
                    {
                        e.Result = "B92 NASLOV";
                    }
                }
            Label_0198:
                if (address.Contains("blic.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@id='article_content']"))
                        {
                            num = 0;
                            while (num < node.ChildNodes.Count)
                            {
                                if (node.ChildNodes[num].Name.Contains("h1"))
                                {
                                    e.Result = node.ChildNodes[num].InnerText;
                                    break;
                                }
                                num++;
                            }
                            goto Label_0278;
                        }
                    }
                    catch
                    {
                        e.Result = "BLIC NASLOV";
                    }
                }
            Label_0278:
                if (address.Contains("kurir-info.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//h1[@itemprop='name headline']"))
                        {
                            e.Result = node.InnerText;
                            goto Label_02F1;
                        }
                    }
                    catch
                    {
                    }
                }
            Label_02F1:
                if (address.Contains("novosti.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//h2[@class='articleTitle']"))
                        {
                            string str3 = node.InnerText.Replace("  ", "").Replace("\r\n", "").Replace("&quot;", "");
                            e.Result = str3;
                            goto Label_03A6;
                        }
                    }
                    catch
                    {
                    }
                }
            Label_03A6:
                if (address.Contains("danas.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='block']"))
                        {
                            num = 0;
                            while (num < node.ChildNodes.Count)
                            {
                                if (node.ChildNodes[num].Name.Contains("h1"))
                                {
                                    innerText = node.ChildNodes[num].InnerText;
                                    e.Result = innerText;
                                    break;
                                }
                                num++;
                            }
                        }
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='block floatedBlock']"))
                        {
                            num = 0;
                            while (num < node.ChildNodes.Count)
                            {
                                if (node.ChildNodes[num].Name.Contains("h1"))
                                {
                                    innerText = node.ChildNodes[num].InnerText;
                                    e.Result = innerText;
                                    break;
                                }
                                num++;
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                if (address.Contains("politika.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='big_article_home item_details']"))
                        {
                            num = 0;
                            while (num < node.ChildNodes.Count)
                            {
                                if (node.ChildNodes[num].OuterHtml.Contains("<h1>"))
                                {
                                    innerText = node.ChildNodes[num].InnerText;
                                    e.Result = innerText;
                                    break;
                                }
                                num++;
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                if (address.Contains("rts.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@id='content']"))
                        {
                            num = 0;
                            while (num < node.ChildNodes.Count)
                            {
                                if (node.ChildNodes[num].OuterHtml.Contains("<h1>"))
                                {
                                    innerText = node.ChildNodes[num].InnerText;
                                    e.Result = innerText;
                                    break;
                                }
                                num++;
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                if (address.Contains("telegraf.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//figure[@class='featured-img']"))
                        {
                            for (num = 0; num < node.Attributes.Count; num++)
                            {
                                if (node.Attributes[num].Name.Contains("title"))
                                {
                                    innerText = node.Attributes[num].Value;
                                    e.Result = innerText;
                                    break;
                                }
                            }
                            goto Label_07C6;
                        }
                    }
                    catch
                    {
                    }
                }
            Label_07C6:
                if (address.Contains("alo.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//span[@class='titleRedBck']"))
                        {
                            innerText = node.InnerHtml;
                            e.Result = innerText;
                            break;
                        }
                        return;
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

        private void naslovtekst_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                string str = e.Result.ToString();
                this.Naslov.Text = str;
                this.NaslovZaUpdate = str;
                WebClient client = new WebClient();
                string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/UpdateNewsHeadAndPicture2.php?";
                address = (address + "&Id=" + this.GlavniID) + "&Naslov=" + this.NaslovZaUpdate.Replace("&", "");
                string str3 = client.DownloadString(address);
                try
                {
                    try
                    {
                        WebClient client2 = new WebClient();
                        NameValueCollection data = new NameValueCollection();
                        data["IAMIdKorisnika"] = this.PerID;
                        data["IAMUrlVesti"] = this.LinkZaProveru;
                        data["IAMNaslovVesti"] = this.Naslov.Text;
                        data["IAMAkcija"] = "Ažuriranje naslova";
                        client2.Encoding = Encoding.UTF8;
                        byte[] bytes = client2.UploadValues("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/InsertNewHistoryAdmin.php", "POST", data);
                        if (Encoding.UTF8.GetString(bytes).Contains("OKET"))
                        {
                        }
                    }
                    catch
                    {
                    }
                }
                catch
                {
                }
                this.Naslov.BackColor = Color.DarkSlateGray;
                this.Naslov.ForeColor = Color.White;
            }
            catch
            {
                this.Naslov.BackColor = Color.DarkSlateGray;
                this.Naslov.ForeColor = Color.White;
            }
        }

        public void OsveziBrojKomentara()
        {
            try
            {
                this.backgroundWorker1.RunWorkerAsync(this.LinkZaProveru);
            }
            catch
            {
            }
        }

        public void OsveziNaslovVesti(string ID)
        {
            try
            {
                this.PerID = ID;
                this.Naslov.BackColor = Color.Red;
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(this.naslovtekst_DoWork);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.naslovtekst_RunWorkerCompleted);
                worker.RunWorkerAsync(this.LinkZaProveru);
            }
            catch
            {
                this.Naslov.BackColor = Color.DarkSlateGray;
                this.Naslov.ForeColor = Color.White;
            }
        }

        public void OznaciKontroluZuto()
        {
            if (this.ZutaBoja == 0)
            {
                this.Naslov.BackColor = Color.DarkSlateGray;
                this.Naslov.ForeColor = Color.White;
                this.ZutaBoja = 1;
            }
            else
            {
                this.Naslov.BackColor = Color.White;
                this.Naslov.ForeColor = Color.Black;
                this.ZutaBoja = 0;
            }
        }

        public void Pocetak(string id, string link, int start, string naslov, string slika, string UserID)
        {
            this.PerID = UserID;
            if (start == 0)
            {
                this.GlavniID = id;
                this.LinkZaProveru = link;
                this.Naslov.Text = naslov;
                if (slika.Contains(@"InternetTim\Vpic"))
                {
                    this.panel1.BackgroundImage = Image.FromFile(slika);
                }
                else
                {
                    this.panel1.BackgroundImage = this.DownloadImage(slika);
                    try
                    {
                        string str2 = Path.GetPathRoot(Environment.SystemDirectory) + @"InternetTim\Vpic\";
                        new Bitmap(this.panel1.BackgroundImage).Save(str2 + this.GlavniID + ".jpg");
                    }
                    catch
                    {
                    }
                }
                if (this.panel1.BackgroundImage == null)
                {
                    if (link.Contains("b92.net"))
                    {
                        this.panel1.BackgroundImage = Resources.b92logo;
                    }
                    if (link.Contains("blic.rs"))
                    {
                        this.panel1.BackgroundImage = Resources.bliclogoorig;
                    }
                    if (link.Contains("kurir-info.rs"))
                    {
                        this.panel1.BackgroundImage = Resources.kurir001;
                    }
                    if (link.Contains("novosti.rs"))
                    {
                        this.panel1.BackgroundImage = Resources.novostionline;
                    }
                    if (link.Contains("danas.rs"))
                    {
                        this.panel1.BackgroundImage = Resources.DanasVelika;
                    }
                    if (link.Contains("telegraf.rs"))
                    {
                        this.panel1.BackgroundImage = Resources.TelegrafVelika;
                    }
                    if (link.Contains("politika.rs"))
                    {
                        this.panel1.BackgroundImage = Resources.PolitikaVelika;
                    }
                    if (link.Contains("rts.rs"))
                    {
                        this.panel1.BackgroundImage = Resources.RTSVelika;
                    }
                    if (link.Contains("alo.rs"))
                    {
                        this.panel1.BackgroundImage = Resources.AloVelika2;
                    }
                    if ((this.panel1.BackgroundImage == null) && link.Contains("*"))
                    {
                        try
                        {
                            string[] strArray = link.Split(new char[] { '*' });
                            this.LinkZaProveru = link;
                            this.Naslov.Text = strArray[2];
                            if (strArray[1] == "1")
                            {
                                this.panel1.BackgroundImage = Resources.facebook;
                            }
                            if (strArray[1] == "2")
                            {
                                this.panel1.BackgroundImage = Resources.twitter;
                            }
                            if (strArray[1] == "3")
                            {
                                this.panel1.BackgroundImage = Resources.youtube;
                            }
                            if (strArray[1] == "4")
                            {
                                this.panel1.BackgroundImage = Resources.newssrbija;
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                else
                {
                    this.SlikaZaUpdate = slika;
                }
                if (link.Contains("b92.net"))
                {
                    this.pictureBox2.BackgroundImage = Resources.B92;
                }
                if (link.Contains("blic.rs"))
                {
                    this.pictureBox2.BackgroundImage = Resources.BLIC;
                }
                if (link.Contains("kurir-info.rs"))
                {
                    this.pictureBox2.BackgroundImage = Resources.KURIR;
                }
                if (link.Contains("novosti.rs"))
                {
                    this.pictureBox2.BackgroundImage = Resources.NOVOSTI;
                }
                if (link.Contains("danas.rs"))
                {
                    this.pictureBox2.BackgroundImage = Resources.DanasMala;
                }
                if (link.Contains("politika.rs"))
                {
                    this.pictureBox2.BackgroundImage = Resources.PolitikaMala;
                }
                if (link.Contains("rts.rs"))
                {
                    this.pictureBox2.BackgroundImage = Resources.RTSMala;
                }
                if (link.Contains("telegraf.rs"))
                {
                    this.pictureBox2.BackgroundImage = Resources.TelegrafMala;
                }
                if (link.Contains("alo.rs"))
                {
                    this.pictureBox2.BackgroundImage = Resources.AloMala;
                }
                if (this.pictureBox2.BackgroundImage != null)
                {
                    this.pictureBox2.Visible = true;
                }
            }
            else
            {
                this.PromeniSlikuVesti(link);
            }
        }

        public void PromeniNaslovVesti(string ime)
        {
            this.Naslov.Text = ime;
            this.NaslovZaUpdate = ime;
        }

        public void PromeniSlikuVesti(string link)
        {
            try
            {
                int num2;
                string innerText;
                int num3;
                int num4;
                string[] strArray2;
                string str6;
                string html = "";
                string address = link;
                if (address.Contains("*"))
                {
                    address = address.Split(new char[] { '*' })[0];
                }
                using (WebClient client = new WebClient())
                {
                    if (address.Contains("b92.net"))
                    {
                        client.Encoding = Encoding.GetEncoding(0x4e2);
                    }
                    else
                    {
                        client.Encoding = Encoding.UTF8;
                    }
                    html = client.DownloadString(address);
                    client.Dispose();
                }
                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(html);
                int num = 0;
                if (!address.Contains("b92.net"))
                {
                    goto Label_0384;
                }
                num++;
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//img[@class='trista']"))
                    {
                        num2 = 0;
                        while (num2 < node.Attributes.Count)
                        {
                            if (node.Attributes[num2].Name.Contains("src"))
                            {
                                this.panel1.BackgroundImage = this.DownloadImage("http://www.b92.net" + node.Attributes[num2].Value);
                                this.SlikaZaUpdate = "http://www.b92.net" + node.Attributes[num2].Value;
                                break;
                            }
                            num2++;
                        }
                        goto Label_01CD;
                    }
                }
                catch
                {
                }
            Label_01CD:
                if ((this.panel1.BackgroundImage == null) || (this.SlikaZaUpdate == ""))
                {
                    this.panel1.BackgroundImage = Resources.b92logo;
                }
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='article-text']"))
                    {
                        num2 = 0;
                        while (num2 < node.ChildNodes.Count)
                        {
                            if (node.ChildNodes[num2].Name.Contains("h1"))
                            {
                                this.NaslovZaUpdate = this.Naslov.Text = node.ChildNodes[num2].InnerText;
                                break;
                            }
                            num2++;
                        }
                        goto Label_02EB;
                    }
                }
                catch
                {
                    this.Naslov.Text = "B92 NASLOV";
                }
            Label_02EB:;
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//span[@class='comment-number']"))
                    {
                        this.BrojKomentara.Text = node.InnerText;
                        goto Label_0364;
                    }
                }
                catch
                {
                    this.BrojKomentara.Text = "0";
                }
            Label_0364:
                this.pictureBox2.BackgroundImage = Resources.B92;
                this.pictureBox2.Visible = true;
            Label_0384:
                if (!address.Contains("blic.rs"))
                {
                    goto Label_08A0;
                }
                num++;
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='img_full']"))
                    {
                        num2 = 0;
                        while (num2 < node.ChildNodes[0].Attributes.Count)
                        {
                            if (node.ChildNodes[0].Attributes[num2].Value.Contains(".jpg"))
                            {
                                this.panel1.BackgroundImage = this.DownloadImage("http://www.blic.rs" + node.ChildNodes[0].Attributes[num2].Value);
                                this.SlikaZaUpdate = "http://www.blic.rs" + node.ChildNodes[0].Attributes[num2].Value;
                                break;
                            }
                            num2++;
                        }
                        goto Label_0628;
                    }
                }
                catch
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@id='article_content']"))
                        {
                            num2 = 0;
                            while (num2 < node.ChildNodes[7].ChildNodes[0].Attributes.Count)
                            {
                                if (node.ChildNodes[7].ChildNodes[0].Attributes[num2].Value.Contains(".jpg"))
                                {
                                    this.panel1.BackgroundImage = this.DownloadImage("http://www.blic.rs" + node.ChildNodes[7].ChildNodes[0].Attributes[num2].Value);
                                    this.SlikaZaUpdate = "http://www.blic.rs" + node.ChildNodes[7].ChildNodes[0].Attributes[num2].Value;
                                    break;
                                }
                                num2++;
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            Label_0628:
                if ((this.panel1.BackgroundImage == null) || (this.SlikaZaUpdate == ""))
                {
                    this.panel1.BackgroundImage = Resources.bliclogoorig;
                }
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@id='article_content']"))
                    {
                        num2 = 0;
                        while (num2 < node.ChildNodes.Count)
                        {
                            if (node.ChildNodes[num2].Name.Contains("h1"))
                            {
                                this.NaslovZaUpdate = this.Naslov.Text = node.ChildNodes[num2].InnerText;
                                break;
                            }
                            num2++;
                        }
                        goto Label_0746;
                    }
                }
                catch
                {
                    this.Naslov.Text = "BLIC NASLOV";
                }
            Label_0746:;
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='article_info']"))
                    {
                        num2 = 0;
                        while (num2 < node.ChildNodes[1].ChildNodes.Count)
                        {
                            if (node.ChildNodes[1].ChildNodes[num2].InnerText.Contains("Komentara"))
                            {
                                innerText = node.ChildNodes[1].ChildNodes[num2].InnerText.Replace("Komentara", "").Replace(":", "").Replace(" ", "");
                                this.BrojKomentara.Text = innerText;
                                break;
                            }
                            num2++;
                        }
                    }
                }
                catch
                {
                    this.BrojKomentara.Text = "0";
                }
                this.pictureBox2.BackgroundImage = Resources.BLIC;
                this.pictureBox2.Visible = true;
            Label_08A0:
                if (!address.Contains("kurir-info.rs"))
                {
                    goto Label_0B58;
                }
                num++;
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//img[@itemprop='contentUrl representativeOfPage']"))
                    {
                        num2 = 0;
                        while (num2 < node.Attributes.Count)
                        {
                            if (node.Attributes[num2].Value.Contains(".jpg"))
                            {
                                this.panel1.BackgroundImage = this.DownloadImage(node.Attributes[num2].Value);
                                this.SlikaZaUpdate = node.Attributes[num2].Value;
                                break;
                            }
                            num2++;
                        }
                    }
                }
                catch
                {
                }
                if ((this.panel1.BackgroundImage == null) || (this.SlikaZaUpdate == ""))
                {
                    this.panel1.BackgroundImage = Resources.kurir001;
                }
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//h1[@itemprop='name headline']"))
                    {
                        this.NaslovZaUpdate = this.Naslov.Text = node.InnerText;
                        goto Label_0A53;
                    }
                }
                catch
                {
                }
            Label_0A53:;
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//section[@class='comments_module']"))
                    {
                        innerText = node.ChildNodes[1].ChildNodes[1].InnerText.Replace("(", "").Replace(")", "").Replace("Komentari", "").Replace(" ", "");
                        this.BrojKomentara.Text = innerText;
                        goto Label_0B38;
                    }
                }
                catch
                {
                    this.BrojKomentara.Text = "0";
                }
            Label_0B38:
                this.pictureBox2.BackgroundImage = Resources.KURIR;
                this.pictureBox2.Visible = true;
            Label_0B58:
                if (!address.Contains("novosti.rs"))
                {
                    goto Label_0F1D;
                }
                num++;
                foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='imgb']"))
                {
                    num2 = 0;
                    while (num2 < node.ChildNodes[1].Attributes.Count)
                    {
                        if (node.ChildNodes[1].Attributes[num2].Value.Contains(".jpg"))
                        {
                            this.panel1.BackgroundImage = this.DownloadImage("http://www.novosti.rs" + node.ChildNodes[1].Attributes[num2].Value);
                            this.SlikaZaUpdate = "http://www.novosti.rs" + node.ChildNodes[1].Attributes[num2].Value;
                            break;
                        }
                        num2++;
                    }
                    break;
                }
                if ((this.panel1.BackgroundImage == null) || (this.SlikaZaUpdate == ""))
                {
                    this.panel1.BackgroundImage = Resources.novostionline;
                }
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//h2[@class='articleTitle']"))
                    {
                        string str4 = node.InnerText.Replace("  ", "").Replace("\r\n", "").Replace("&quot;", "");
                        this.NaslovZaUpdate = this.Naslov.Text = str4;
                        goto Label_0D7E;
                    }
                }
                catch
                {
                }
            Label_0D7E:;
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='articleInfo']"))
                    {
                        num2 = 0;
                        while (num2 < node.ChildNodes.Count)
                        {
                            if (node.ChildNodes[num2].InnerText.Contains("Komentara"))
                            {
                                innerText = node.ChildNodes[num2].InnerText.Replace("\t", "").Replace("\r", "").Replace("\n", "").Replace(":", "").Replace("Komentara", "").Replace(" ", "");
                                if (innerText.Length > 3)
                                {
                                    this.BrojKomentara.Text = "0";
                                }
                                else
                                {
                                    this.BrojKomentara.Text = innerText;
                                }
                                break;
                            }
                            num2++;
                        }
                    }
                }
                catch
                {
                    this.BrojKomentara.Text = "0";
                }
                this.pictureBox2.BackgroundImage = Resources.NOVOSTI;
                this.pictureBox2.Visible = true;
            Label_0F1D:
                if (!address.Contains("danas.rs"))
                {
                    goto Label_1433;
                }
                num++;
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='slikaClanka']"))
                    {
                        num2 = 0;
                        while (num2 < node.ChildNodes.Count)
                        {
                            if (node.ChildNodes[num2].Name.Contains("img"))
                            {
                                num3 = 0;
                                while (num3 < node.ChildNodes[num2].Attributes.Count)
                                {
                                    if (node.ChildNodes[num2].Attributes[num3].Name.Contains("src"))
                                    {
                                        this.panel1.BackgroundImage = this.DownloadImage("http://www.danas.rs" + node.ChildNodes[num2].Attributes[num3].Value);
                                        this.SlikaZaUpdate = "http://www.danas.rs" + node.ChildNodes[num2].Attributes[num3].Value;
                                        break;
                                    }
                                    num3++;
                                }
                                break;
                            }
                            num2++;
                        }
                        goto Label_10BE;
                    }
                }
                catch
                {
                }
            Label_10BE:
                if ((this.panel1.BackgroundImage == null) || (this.SlikaZaUpdate == ""))
                {
                    this.panel1.BackgroundImage = Resources.DanasVelika;
                }
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='block']"))
                    {
                        num2 = 0;
                        while (num2 < node.ChildNodes.Count)
                        {
                            if (node.ChildNodes[num2].Name.Contains("h1"))
                            {
                                innerText = node.ChildNodes[num2].InnerText;
                                this.NaslovZaUpdate = this.Naslov.Text = innerText;
                                break;
                            }
                            num2++;
                        }
                    }
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='block floatedBlock']"))
                    {
                        num2 = 0;
                        while (num2 < node.ChildNodes.Count)
                        {
                            if (node.ChildNodes[num2].Name.Contains("h1"))
                            {
                                innerText = node.ChildNodes[num2].InnerText;
                                this.NaslovZaUpdate = this.Naslov.Text = innerText;
                                break;
                            }
                            num2++;
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='komentari']"))
                    {
                        num2 = 0;
                        while (num2 < node.ChildNodes.Count)
                        {
                            if (node.ChildNodes[num2].InnerText.Contains("Komentari"))
                            {
                                innerText = node.ChildNodes[num2].InnerText.Replace("(", "").Replace(")", "").Replace("\t", "").Replace("\r", "").Replace("\n", "").Replace(":", "").Replace("Komentari", "").Replace(" ", "");
                                this.BrojKomentara.Text = innerText;
                                break;
                            }
                            num2++;
                        }
                    }
                }
                catch
                {
                    this.BrojKomentara.Text = "0";
                }
                this.pictureBox2.BackgroundImage = Resources.DanasMala;
                this.pictureBox2.Visible = true;
            Label_1433:
                if (!address.Contains("politika.rs"))
                {
                    goto Label_1908;
                }
                num++;
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='big_article_home item_details']"))
                    {
                        num2 = 0;
                        while (num2 < node.ChildNodes.Count)
                        {
                            if (node.ChildNodes[num2].OuterHtml.Contains("img src"))
                            {
                                num3 = 0;
                                while (num3 < node.ChildNodes[num2].ChildNodes.Count)
                                {
                                    num4 = 0;
                                    while (num4 < node.ChildNodes[num2].ChildNodes[num3].Attributes.Count)
                                    {
                                        if (node.ChildNodes[num2].ChildNodes[num3].Attributes[num4].Name.Contains("src"))
                                        {
                                            this.panel1.BackgroundImage = this.DownloadImage(node.ChildNodes[num2].ChildNodes[num3].Attributes[num4].Value);
                                            this.SlikaZaUpdate = node.ChildNodes[num2].ChildNodes[num3].Attributes[num4].Value;
                                            break;
                                        }
                                        num4++;
                                    }
                                    num3++;
                                }
                                break;
                            }
                            num2++;
                        }
                        goto Label_1625;
                    }
                }
                catch
                {
                }
            Label_1625:
                if ((this.panel1.BackgroundImage == null) || (this.SlikaZaUpdate == ""))
                {
                    this.panel1.BackgroundImage = Resources.PolitikaVelika;
                }
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='big_article_home item_details']"))
                    {
                        num2 = 0;
                        while (num2 < node.ChildNodes.Count)
                        {
                            if (node.ChildNodes[num2].OuterHtml.Contains("<h1>"))
                            {
                                innerText = node.ChildNodes[num2].InnerText;
                                this.NaslovZaUpdate = this.Naslov.Text = innerText;
                                break;
                            }
                            num2++;
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='article_info']"))
                    {
                        strArray2 = node.InnerHtml.Split(new char[] { '>' });
                        foreach (string str5 in strArray2)
                        {
                            if (str5.Contains("komentari") || str5.Contains("коментари"))
                            {
                                innerText = str5;
                                innerText = innerText.Replace("</a", "").Replace("(", "").Replace(")", "").Replace("\t", "").Replace("\r", "").Replace("\n", "").Replace(":", "").Replace("komentari", "").Replace("коментари", "").Replace(" ", "");
                                this.BrojKomentara.Text = innerText;
                                break;
                            }
                        }
                        goto Label_18E8;
                    }
                }
                catch
                {
                    this.BrojKomentara.Text = "0";
                }
            Label_18E8:
                this.pictureBox2.BackgroundImage = Resources.PolitikaMala;
                this.pictureBox2.Visible = true;
            Label_1908:
                if (!address.Contains("rts.rs"))
                {
                    goto Label_1CC7;
                }
                num++;
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='boxImage']"))
                    {
                        num2 = 0;
                        while (num2 < node.ChildNodes.Count)
                        {
                            if (node.ChildNodes[num2].OuterHtml.Contains("img src"))
                            {
                                num3 = 0;
                                while (num3 < node.ChildNodes[num2].Attributes.Count)
                                {
                                    if (node.ChildNodes[num2].Attributes[num3].Name.Contains("src"))
                                    {
                                        this.panel1.BackgroundImage = this.DownloadImage("http://www.rts.rs" + node.ChildNodes[num2].Attributes[num3].Value);
                                        this.SlikaZaUpdate = "http://www.rts.rs" + node.ChildNodes[num2].Attributes[num3].Value;
                                        break;
                                    }
                                    num3++;
                                }
                                break;
                            }
                            num2++;
                        }
                        goto Label_1AA9;
                    }
                }
                catch
                {
                }
            Label_1AA9:
                if ((this.panel1.BackgroundImage == null) || (this.SlikaZaUpdate == ""))
                {
                    this.panel1.BackgroundImage = Resources.RTSVelika;
                }
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@id='content']"))
                    {
                        num2 = 0;
                        while (num2 < node.ChildNodes.Count)
                        {
                            if (node.ChildNodes[num2].OuterHtml.Contains("<h1>"))
                            {
                                innerText = node.ChildNodes[num2].InnerText;
                                this.NaslovZaUpdate = this.Naslov.Text = innerText;
                                break;
                            }
                            num2++;
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//td[@class='commentRight']"))
                    {
                        num3 = 0;
                        while (num3 < node.ChildNodes.Count)
                        {
                            if (node.ChildNodes[num3].Name.Contains("span"))
                            {
                                str6 = node.ChildNodes[num3].InnerText.Replace(" ", "");
                                this.BrojKomentara.Text = str6;
                                break;
                            }
                            num3++;
                        }
                        goto Label_1CA7;
                    }
                }
                catch
                {
                    this.BrojKomentara.Text = "0";
                }
            Label_1CA7:
                this.pictureBox2.BackgroundImage = Resources.RTSMala;
                this.pictureBox2.Visible = true;
            Label_1CC7:
                if (!address.Contains("telegraf.rs"))
                {
                    goto Label_2064;
                }
                num++;
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//figure[@class='featured-img']"))
                    {
                        num2 = 0;
                        while (num2 < node.Attributes.Count)
                        {
                            if (node.Attributes[num2].Name.Contains("data"))
                            {
                                this.panel1.BackgroundImage = this.DownloadImage(node.Attributes[num2].Value);
                                this.SlikaZaUpdate = node.Attributes[num2].Value;
                                break;
                            }
                            num2++;
                        }
                        goto Label_1DCC;
                    }
                }
                catch
                {
                }
            Label_1DCC:
                if ((this.panel1.BackgroundImage == null) || (this.SlikaZaUpdate == ""))
                {
                    this.panel1.BackgroundImage = Resources.TelegrafVelika;
                }
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//figure[@class='featured-img']"))
                    {
                        num2 = 0;
                        while (num2 < node.Attributes.Count)
                        {
                            if (node.Attributes[num2].Name.Contains("title"))
                            {
                                innerText = node.Attributes[num2].Value;
                                this.NaslovZaUpdate = this.Naslov.Text = innerText;
                                break;
                            }
                            num2++;
                        }
                        goto Label_1EDD;
                    }
                }
                catch
                {
                }
            Label_1EDD:;
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='block-comments']"))
                    {
                        str6 = node.InnerText.Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("Ukupno", "").Replace("komentara", "").Replace("Pošaljite", "").Replace("Vaš", "").Replace("komentari", "").Replace("komentar", "").Replace("Svi", "").Replace(@"\...", "");
                        this.BrojKomentara.Text = str6;
                        goto Label_2044;
                    }
                }
                catch
                {
                    this.BrojKomentara.Text = "0";
                }
            Label_2044:
                this.pictureBox2.BackgroundImage = Resources.TelegrafMala;
                this.pictureBox2.Visible = true;
            Label_2064:
                if (!address.Contains("alo.rs"))
                {
                    goto Label_246D;
                }
                num++;
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='imageInArticle']"))
                    {
                        num2 = 0;
                        while (num2 < node.ChildNodes.Count)
                        {
                            if (node.ChildNodes[num2].OuterHtml.Contains("img "))
                            {
                                for (num3 = 0; num3 < node.ChildNodes[num2].ChildNodes.Count; num3++)
                                {
                                    for (num4 = 0; num4 < node.ChildNodes[num2].ChildNodes[num3].Attributes.Count; num4++)
                                    {
                                        if (node.ChildNodes[num2].ChildNodes[num3].Attributes[num4].Name.Contains("src"))
                                        {
                                            this.panel1.BackgroundImage = this.DownloadImage("http://www.alo.rs" + node.ChildNodes[num2].ChildNodes[num3].Attributes[num4].Value);
                                            this.SlikaZaUpdate = "http://www.alo.rs" + node.ChildNodes[num2].ChildNodes[num3].Attributes[num4].Value;
                                            break;
                                        }
                                    }
                                }
                                break;
                            }
                            num2++;
                        }
                        goto Label_226D;
                    }
                }
                catch
                {
                }
            Label_226D:
                if ((this.panel1.BackgroundImage == null) || (this.SlikaZaUpdate == ""))
                {
                    this.panel1.BackgroundImage = Resources.AloVelika2;
                }
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//span[@class='titleRedBck']"))
                    {
                        innerText = node.InnerHtml;
                        this.NaslovZaUpdate = this.Naslov.Text = innerText;
                        goto Label_2320;
                    }
                }
                catch
                {
                }
            Label_2320:;
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='widgetAutor']"))
                    {
                        for (num2 = 0; num2 < node.ChildNodes.Count; num2++)
                        {
                            if (node.ChildNodes[num2].InnerHtml.Contains("Komentara"))
                            {
                                str6 = node.ChildNodes[num2].InnerHtml.Replace(" ", "").Replace("<strong>", "").Replace("Komentara:", "").Replace("</strong>", "");
                                this.BrojKomentara.Text = str6;
                                break;
                            }
                        }
                        goto Label_244D;
                    }
                }
                catch
                {
                    this.BrojKomentara.Text = "0";
                }
            Label_244D:
                this.pictureBox2.BackgroundImage = Resources.AloMala;
                this.pictureBox2.Visible = true;
            Label_246D:
                try
                {
                    this.LinkZaProveru = link;
                    this.timer1.Enabled = true;
                    this.timer1.Start();
                }
                catch
                {
                }
                if (num == 0)
                {
                    this.BrojKomentara.Visible = false;
                    this.pictureBox2.Visible = false;
                    try
                    {
                        strArray2 = link.Split(new char[] { '*' });
                        this.LinkZaProveru = link;
                        this.NaslovZaUpdate = this.Naslov.Text = strArray2[2];
                        if (strArray2[1] == "1")
                        {
                            this.panel1.BackgroundImage = Resources.facebook;
                        }
                        if (strArray2[1] == "2")
                        {
                            this.panel1.BackgroundImage = Resources.twitter;
                        }
                        if (strArray2[1] == "3")
                        {
                            this.panel1.BackgroundImage = Resources.youtube;
                        }
                        if (strArray2[1] == "4")
                        {
                            this.panel1.BackgroundImage = Resources.newssrbija;
                        }
                    }
                    catch
                    {
                    }
                }
                else
                {
                    this.BrojKomentara.Visible = true;
                }
            }
            catch
            {
            }
        }

        public void Saktivanje(string uslov)
        {
            if (!this.LinkZaProveru.Contains(uslov))
            {
                base.Hide();
            }
            else
            {
                base.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.timer1.Enabled = false;
            try
            {
                WebClient client = new WebClient();
                string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/GetIdFromUrl.php?";
                address = address + "&ur=" + this.LinkZaProveru.Replace("&", "[[]]");
                this.GlavniID = client.DownloadString(address).Replace("\r\n", "");
                WebClient client2 = new WebClient();
                string str3 = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/UpdateNewsHeadAndPicture.php?";
                str3 = ((str3 + "&Id=" + this.GlavniID) + "&Naslov=" + this.NaslovZaUpdate) + "&Slika=" + this.SlikaZaUpdate;
                string str4 = client2.DownloadString(str3);
                try
                {
                    WebClient client3 = new WebClient();
                    NameValueCollection data = new NameValueCollection();
                    data["IAMIdKorisnika"] = this.PerID;
                    data["IAMUrlVesti"] = this.LinkZaProveru;
                    data["IAMNaslovVesti"] = this.NaslovZaUpdate;
                    data["IAMAkcija"] = "Unos nove vesti";
                    client3.Encoding = Encoding.UTF8;
                    byte[] bytes = client3.UploadValues("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/InsertNewHistoryAdmin.php", "POST", data);
                    if (Encoding.UTF8.GetString(bytes).Contains("OKET"))
                    {
                    }
                }
                catch
                {
                }
                try
                {
                    string str7 = Path.GetPathRoot(Environment.SystemDirectory) + @"InternetTim\Vpic\";
                    new Bitmap(this.panel1.BackgroundImage).Save(str7 + this.GlavniID + ".jpg");
                }
                catch
                {
                }
            }
            catch
            {
            }
        }

        public string UzmiBrojKomentara()
        {
            return this.BrojKomentara.Text;
        }

        public string UzmiNaslovVesti()
        {
            return this.Naslov.Text;
        }

        public string UzmiOriginalID()
        {
            return this.GlavniID;
        }

        public string UzmiOriginalLink()
        {
            return this.LinkZaProveru;
        }

        public string UzmiSliku()
        {
            return this.SlikaZaUpdate;
        }
    }
}

