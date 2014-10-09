namespace InternetTim.Glasanje
{
    using HtmlAgilityPack;
    using InternetTim.Properties;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    public class GlasanjeNaKomentareExterna : Form
    {
        private int aktivnoservera = 0;
        private int[] BrojacRadniZadaci = new int[100];
        private IContainer components = null;
        private int DozvoljenoMaxServera = 200;
        private string[] Evidencija = new string[0x3e8];
        public string GLAVNILINK = "";
        private string[] IdKomentara = new string[100];
        private string[] IpAdrese = new string[0x30d40];
        private int ipbroj = 0;
        private Label label1;
        private Button Naslov;
        private int OdjednomPokreni = 5;
        public string PersonalID = "000000";
        private PictureBox pictureBox1;
        private DateTime[] PocetnoVremeGlasanja = new DateTime[0x3e8];
        private int PokretanjeServera = 0;
        private Button PrikaziKomentare;
        private System.Windows.Forms.Timer ProsekGlasanja;
        private BackgroundWorker ProveraRealnihBrojeva;
        private System.Windows.Forms.Timer ProxyTimer;
        private string[] RadniZadaci = new string[100];
        private RichTextBox richTextBox1;
        private TrackBar trackBar1;
        private string vest = "";
        private VestiPrikazRealnihKomentara vestpri = new VestiPrikazRealnihKomentara();
        private int ZaustaviSmanjivanje = 0;

        public GlasanjeNaKomentareExterna()
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

        private void GlasanjeNaKomentareExterna_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WebClient client = new WebClient();
                string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Glasanje/GetLive12hServers2.php";
                JsonTextReader reader = new JsonTextReader(new StringReader(client.DownloadString(address)));
                while (reader.Read())
                {
                    if (reader.Value != null)
                    {
                        if (reader.Value.ToString().Contains("."))
                        {
                            this.IpAdrese[this.ipbroj] = reader.Value.ToString();
                        }
                        else
                        {
                            int num;
                            if (int.TryParse(reader.Value.ToString(), out num))
                            {
                                this.IpAdrese[this.ipbroj] = this.IpAdrese[this.ipbroj] + ":" + reader.Value.ToString();
                                this.ipbroj++;
                                continue;
                            }
                        }
                    }
                }
            }
            catch
            {
                Cursor.Current = Cursors.Default;
            }
            try
            {
                int num2;
                string html = "";
                string gLAVNILINK = this.GLAVNILINK;
                using (WebClient client2 = new WebClient())
                {
                    if (gLAVNILINK.Contains("b92.net"))
                    {
                        client2.Encoding = Encoding.GetEncoding(0x4e2);
                    }
                    else
                    {
                        client2.Encoding = Encoding.UTF8;
                    }
                    html = client2.DownloadString(gLAVNILINK);
                    client2.Dispose();
                }
                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(html);
                if (!gLAVNILINK.Contains("blic.rs"))
                {
                    goto Label_04CE;
                }
                this.vest = "BLIC";
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='img_full']"))
                    {
                        num2 = 0;
                        while (num2 < node.ChildNodes[0].Attributes.Count)
                        {
                            if (node.ChildNodes[0].Attributes[num2].Value.Contains(".jpg"))
                            {
                                this.pictureBox1.BackgroundImage = this.DownloadImage("http://www.blic.rs" + node.ChildNodes[0].Attributes[num2].Value);
                                break;
                            }
                            num2++;
                        }
                        goto Label_03CE;
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
                                    this.pictureBox1.BackgroundImage = this.DownloadImage("http://www.blic.rs" + node.ChildNodes[7].ChildNodes[0].Attributes[num2].Value);
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
            Label_03CE:
                if (this.pictureBox1.BackgroundImage == null)
                {
                    this.pictureBox1.BackgroundImage = Resources.bliclogoorig;
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
                                this.Naslov.Text = node.ChildNodes[num2].InnerText;
                                break;
                            }
                            num2++;
                        }
                        goto Label_04CE;
                    }
                }
                catch
                {
                    this.Naslov.Text = "BLIC NASLOV";
                }
            Label_04CE:
                if (!gLAVNILINK.Contains("b92.net"))
                {
                    goto Label_06C7;
                }
                this.vest = "B92";
                try
                {
                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//img[@class='trista']"))
                    {
                        num2 = 0;
                        while (num2 < node.Attributes.Count)
                        {
                            if (node.Attributes[num2].Name.Contains("src"))
                            {
                                this.pictureBox1.BackgroundImage = this.DownloadImage("http://www.b92.net" + node.Attributes[num2].Value);
                                break;
                            }
                            num2++;
                        }
                        goto Label_05C7;
                    }
                }
                catch
                {
                }
            Label_05C7:
                if (this.pictureBox1.BackgroundImage == null)
                {
                    this.pictureBox1.BackgroundImage = Resources.b92logo;
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
                                this.Naslov.Text = node.ChildNodes[num2].InnerText;
                                break;
                            }
                            num2++;
                        }
                        goto Label_06C7;
                    }
                }
                catch
                {
                    this.Naslov.Text = "B92 NASLOV";
                }
            Label_06C7:
                if (gLAVNILINK.Contains("kurir-info.rs"))
                {
                    this.vest = "KURIR";
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//img[@itemprop='contentUrl representativeOfPage']"))
                        {
                            for (num2 = 0; num2 < node.Attributes.Count; num2++)
                            {
                                if (node.Attributes[num2].Value.Contains(".jpg"))
                                {
                                    this.pictureBox1.BackgroundImage = this.DownloadImage(node.Attributes[num2].Value);
                                    break;
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                    if (this.pictureBox1.BackgroundImage == null)
                    {
                        this.pictureBox1.BackgroundImage = Resources.kurir001;
                    }
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//h1[@itemprop='name headline']"))
                        {
                            this.Naslov.Text = node.InnerText;
                            break;
                        }
                        goto Label_0876;
                    }
                    catch
                    {
                        this.Naslov.Text = "KURIR NASLOV";
                    }
                }
            }
            catch
            {
                MessageBox.Show("Dogodila se greska prilikom skidanja podataka, pokusajte ponovo ili probajte malo kasnije.", "INFO");
                base.Close();
            }
        Label_0876:
            if (this.GLAVNILINK.Contains("b92.net"))
            {
                this.ProsekGlasanja.Interval = 0x2bf20;
            }
            if (this.GLAVNILINK.Contains("kurir-info.rs"))
            {
                this.ProsekGlasanja.Interval = 0x1d4c0;
            }
            Cursor.Current = Cursors.Default;
            this.PrikaziKomentare.Visible = true;
            this.ProxyTimer.Enabled = true;
            this.ProxyTimer.Start();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(GlasanjeNaKomentareExterna));
            this.richTextBox1 = new RichTextBox();
            this.ProxyTimer = new System.Windows.Forms.Timer(this.components);
            this.ProsekGlasanja = new System.Windows.Forms.Timer(this.components);
            this.ProveraRealnihBrojeva = new BackgroundWorker();
            this.PrikaziKomentare = new Button();
            this.pictureBox1 = new PictureBox();
            this.Naslov = new Button();
            this.trackBar1 = new TrackBar();
            this.label1 = new Label();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            this.trackBar1.BeginInit();
            base.SuspendLayout();
            this.richTextBox1.Dock = DockStyle.Bottom;
            this.richTextBox1.Location = new Point(0, 0xcf);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new Size(0x220, 0x19e);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.ProxyTimer.Interval = 0x2710;
            this.ProxyTimer.Tick += new EventHandler(this.ProxyTimer_Tick);
            this.ProsekGlasanja.Enabled = true;
            this.ProsekGlasanja.Interval = 0x13880;
            this.ProsekGlasanja.Tick += new EventHandler(this.ProsekGlasanja_Tick);
            this.ProveraRealnihBrojeva.DoWork += new DoWorkEventHandler(this.ProveraRealnihBrojeva_DoWork);
            this.ProveraRealnihBrojeva.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.ProveraRealnihBrojeva_RunWorkerCompleted);
            this.PrikaziKomentare.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.PrikaziKomentare.Location = new Point(0, 0x88);
            this.PrikaziKomentare.Name = "PrikaziKomentare";
            this.PrikaziKomentare.Size = new Size(0x220, 30);
            this.PrikaziKomentare.TabIndex = 30;
            this.PrikaziKomentare.Text = "Prikaži komentare";
            this.PrikaziKomentare.UseVisualStyleBackColor = true;
            this.PrikaziKomentare.Visible = false;
            this.PrikaziKomentare.Click += new EventHandler(this.PrikaziKomentare_Click);
            this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            this.pictureBox1.Location = new Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0xc0, 0x7c);
            this.pictureBox1.TabIndex = 0x1f;
            this.pictureBox1.TabStop = false;
            this.Naslov.BackColor = Color.FromArgb(0xff, 0xe0, 0xc0);
            this.Naslov.FlatAppearance.BorderColor = Color.FromArgb(0xff, 0xc0, 0x80);
            this.Naslov.FlatAppearance.BorderSize = 3;
            this.Naslov.FlatStyle = FlatStyle.Flat;
            this.Naslov.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Naslov.Location = new Point(1, 2);
            this.Naslov.Name = "Naslov";
            this.Naslov.Padding = new Padding(200, 0, 0, 0);
            this.Naslov.Size = new Size(540, 0x86);
            this.Naslov.TabIndex = 0x20;
            this.Naslov.Text = "NASLOV";
            this.Naslov.UseVisualStyleBackColor = false;
            this.Naslov.Click += new EventHandler(this.Naslov_Click);
            this.trackBar1.Location = new Point(1, 0xad);
            this.trackBar1.Maximum = 0x19;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new Size(540, 0x2d);
            this.trackBar1.TabIndex = 0x21;
            this.trackBar1.TickStyle = TickStyle.Both;
            this.trackBar1.Value = 5;
            this.trackBar1.Scroll += new EventHandler(this.trackBar1_Scroll);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(5, 0xa9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x77, 13);
            this.label1.TabIndex = 0x22;
            this.label1.Text = "Brzina rada programa: 5";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(0x220, 0x26d);
            base.Controls.Add(this.richTextBox1);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.trackBar1);
            base.Controls.Add(this.pictureBox1);
            base.Controls.Add(this.Naslov);
            base.Controls.Add(this.PrikaziKomentare);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.Name = "GlasanjeNaKomentareExterna";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Glasanje";
            base.Shown += new EventHandler(this.GlasanjeNaKomentareExterna_Shown);
            ((ISupportInitialize) this.pictureBox1).EndInit();
            this.trackBar1.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void Naslov_Click(object sender, EventArgs e)
        {
            string str = "";
            if (this.GLAVNILINK.Contains("kurir-info.rs"))
            {
                string[] strArray = this.GLAVNILINK.Split(new char[] { '-' });
                str = this.vest + "$" + strArray[strArray.Length - 1] + "%";
            }
            else
            {
                str = this.vest + "%";
            }
            foreach (string str2 in this.RadniZadaci)
            {
                if (str2 == null)
                {
                    break;
                }
                str = str + str2 + "%";
            }
            int num = 1;
            for (int i = 0; i < num; i++)
            {
                string argument = this.IpAdrese[this.PokretanjeServera] + str;
                this.PokretanjeServera++;
                this.aktivnoservera++;
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(this.pozadina_DoWork);
                worker.WorkerReportsProgress = true;
                worker.ProgressChanged += new ProgressChangedEventHandler(this.pozadina_ProgressChanged);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.pozadina_RunWorkerCompleted);
                worker.RunWorkerAsync(argument);
                if ((this.PokretanjeServera + 1) > this.ipbroj)
                {
                    this.PokretanjeServera = 0;
                }
            }
        }

        private void pozadina_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker) sender;
            try
            {
                string[] strArray = e.Argument.ToString().Split(new char[] { '%' });
                string str = "";
                string str2 = "";
                if (strArray[0].Contains("BLIC"))
                {
                    str2 = "BLIC";
                    strArray[0] = strArray[0].Replace("BLIC", "");
                }
                if (strArray[0].Contains("B92"))
                {
                    str2 = "B92";
                    strArray[0] = strArray[0].Replace("B92", "");
                }
                if (strArray[0].Contains("KURIR"))
                {
                    str2 = "KURIR";
                    strArray[0] = strArray[0].Replace("KURIR", "");
                    string[] strArray2 = strArray[0].Split(new char[] { '$' });
                    strArray[0] = strArray2[0];
                    str = strArray2[1];
                }
                try
                {
                    string[] strArray3;
                    WebProxy proxy;
                    string str4;
                    HttpWebRequest request;
                    CookieContainer container;
                    string str5;
                    WebHeaderCollection headers;
                    HttpWebResponse response;
                    int num2;
                    Stream stream;
                    StreamReader reader;
                    int num3;
                    string[] strArray5;
                    string str7;
                    string str8;
                    string str9;
                    string str13;
                    byte[] bytes;
                    HttpWebRequest request2;
                    CookieCollection cookies;
                    CookieCollection cookies2;
                    HttpWebResponse response2;
                    StreamReader reader2;
                    CookieCollection cookies3;
                    int num = 0;
                    foreach (string str3 in strArray)
                    {
                        if (str3 == null)
                        {
                            break;
                        }
                        if ((str3 != "******") && (str3.Length >= 2))
                        {
                            num++;
                        }
                    }
                    if (num <= 1)
                    {
                        goto Label_14FF;
                    }
                    if (str2 == "BLIC")
                    {
                        try
                        {
                            strArray3 = strArray[0].Split(new char[] { ':' });
                            proxy = new WebProxy(strArray3[0], int.Parse(strArray3[1]));
                            str4 = "http://www.blic.rs";
                            request = (HttpWebRequest) WebRequest.Create(str4);
                            request.AllowWriteStreamBuffering = true;
                            request.KeepAlive = false;
                            request.Proxy = proxy;
                            container = new CookieContainer();
                            request.CookieContainer = container;
                            str5 = null;
                            headers = new WebHeaderCollection();
                            using (response = (HttpWebResponse) request.GetResponse())
                            {
                                for (num2 = 0; num2 < response.Headers.Count; num2++)
                                {
                                    headers.Add(response.Headers.AllKeys[num2], response.Headers.Get(num2));
                                }
                                if (response.StatusCode == HttpStatusCode.OK)
                                {
                                    using (stream = response.GetResponseStream())
                                    {
                                        using (reader = new StreamReader(stream))
                                        {
                                            str5 = reader.ReadToEnd();
                                        }
                                    }
                                }
                                response.Close();
                            }
                            str4 = "http://www.blic.rs/resources/templates/comments/comments_vote.php";
                            string[] strArray4 = strArray[1].ToString().Split(new char[] { '#' });
                            if (!(!strArray4[2].Contains("www.blic.rs") || strArray4[2].Contains("komentari")))
                            {
                                strArray4[2] = strArray4[2] + "/komentari#vas-komentar";
                            }
                            string html = "";
                            try
                            {
                                using (WebClient client = new WebClient())
                                {
                                    client.Proxy = proxy;
                                    client.Encoding = Encoding.UTF8;
                                    html = client.DownloadString(strArray4[2]);
                                    client.Dispose();
                                }
                            }
                            catch
                            {
                            }
                            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                            document.LoadHtml(html);
                            for (num3 = 0; num3 < 100; num3++)
                            {
                                if (strArray[num3] == null)
                                {
                                    goto Label_0935;
                                }
                                if (((strArray[num3] != "******") && strArray[num3].Contains("www")) && (strArray[num3].Length > 2))
                                {
                                    strArray5 = strArray[num3].ToString().Split(new char[] { '#' });
                                    str7 = strArray5[0];
                                    str8 = strArray5[1].Replace("komentar_", "");
                                    str9 = strArray5[2];
                                    string str10 = "";
                                    string str11 = "";
                                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='comm_text']"))
                                    {
                                        string[] strArray6 = node.ParentNode.OuterHtml.Split(new char[] { '>' });
                                        foreach (string str12 in strArray6)
                                        {
                                            if (str12.Contains("javascript:comment_vote"))
                                            {
                                                try
                                                {
                                                    string[] strArray7 = str12.Split(new char[] { '\'' });
                                                    if ((str7 == strArray7[3]) && (str8 == strArray7[1]))
                                                    {
                                                        str10 = strArray7[5];
                                                        str11 = strArray7[7];
                                                        break;
                                                    }
                                                }
                                                catch
                                                {
                                                }
                                            }
                                        }
                                    }
                                    str13 = "id=" + str8 + "&type=" + str7 + "&data=" + str10 + "&hash=" + str11;
                                    bytes = Encoding.UTF8.GetBytes(str13);
                                    request2 = (HttpWebRequest) WebRequest.Create(str4);
                                    request2.Timeout = 0x4e20;
                                    request2.Proxy = proxy;
                                    request2.CookieContainer = container;
                                    cookies = container.GetCookies(new Uri("http://www.blic.rs"));
                                    foreach (Cookie cookie in cookies)
                                    {
                                        if (!cookie.Name.Contains("PHPSESS"))
                                        {
                                            cookie.Expires = DateTime.Now.Subtract(TimeSpan.FromDays(1.0));
                                        }
                                    }
                                    cookies2 = container.GetCookies(new Uri("http://blic.rs"));
                                    foreach (Cookie cookie in cookies2)
                                    {
                                        if (!cookie.Name.Contains("PHPSESS"))
                                        {
                                            cookie.Expires = DateTime.Now.Subtract(TimeSpan.FromDays(1.0));
                                        }
                                    }
                                    request2.AllowWriteStreamBuffering = true;
                                    request2.Method = "POST";
                                    request2.Headers.Add("X-Requested-With", "XMLHttpRequest");
                                    request2.Accept = "*/*";
                                    request2.Headers.Add("Accept-Language", "sr-RS,sr;q=0.9,en;q=0.8");
                                    request2.Headers.Add("Accept-Encoding", "gzip, deflate");
                                    request2.Referer = "http://www.blic.rs/komentari";
                                    request2.KeepAlive = false;
                                    request2.ContentLength = bytes.Length;
                                    request2.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/34.0.1847.116 Safari/537.36";
                                    request2.ContentType = "application/x-www-form-urlencoded";
                                    str5 = null;
                                    request2.GetRequestStream().Write(bytes, 0, bytes.Length);
                                    request2.GetRequestStream().Close();
                                    using (response2 = (HttpWebResponse) request2.GetResponse())
                                    {
                                        if (response2.StatusCode == HttpStatusCode.OK)
                                        {
                                            using (stream = response2.GetResponseStream())
                                            {
                                                using (reader2 = new StreamReader(stream))
                                                {
                                                    str5 = reader2.ReadToEnd();
                                                }
                                            }
                                        }
                                        cookies3 = response2.Cookies;
                                        foreach (Cookie cookie in cookies3)
                                        {
                                            if (!cookie.Name.Contains("PHPSESS"))
                                            {
                                                cookie.Expires = DateTime.Now.Subtract(TimeSpan.FromDays(1.0));
                                            }
                                        }
                                        response2.Close();
                                    }
                                    worker.ReportProgress(num3 - 1);
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                Label_0935:
                    if (str2 == "B92")
                    {
                        try
                        {
                            strArray3 = strArray[0].Split(new char[] { ':' });
                            proxy = new WebProxy(strArray3[0], int.Parse(strArray3[1]));
                            str4 = "http://www.b92.net/";
                            request = (HttpWebRequest) WebRequest.Create(str4);
                            request.AllowWriteStreamBuffering = true;
                            request.KeepAlive = false;
                            request.Proxy = proxy;
                            container = new CookieContainer();
                            request.CookieContainer = container;
                            str5 = null;
                            headers = new WebHeaderCollection();
                            using (response = (HttpWebResponse) request.GetResponse())
                            {
                                for (num2 = 0; num2 < response.Headers.Count; num2++)
                                {
                                    headers.Add(response.Headers.AllKeys[num2], response.Headers.Get(num2));
                                }
                                if (response.StatusCode == HttpStatusCode.OK)
                                {
                                    using (stream = response.GetResponseStream())
                                    {
                                        using (reader = new StreamReader(stream))
                                        {
                                            str5 = reader.ReadToEnd();
                                        }
                                    }
                                }
                                response.Close();
                            }
                            str4 = "http://www.b92.net/komentari/tick.php";
                            for (num3 = 0; num3 < 100; num3++)
                            {
                                if (strArray[num3] == null)
                                {
                                    goto Label_0EEE;
                                }
                                if (((strArray[num3] != "******") && strArray[num3].Contains("www")) && (strArray[num3].Length > 2))
                                {
                                    strArray5 = strArray[num3].ToString().Split(new char[] { '#' });
                                    str7 = strArray5[0];
                                    str8 = strArray5[1].Replace("komentar_", "").Replace("k", "");
                                    str9 = strArray5[2];
                                    str13 = "lang=srpski&id=" + str8 + "&thumbs=" + str7;
                                    bytes = Encoding.UTF8.GetBytes(str13);
                                    request2 = (HttpWebRequest) WebRequest.Create(str4);
                                    request2.Timeout = 0x4e20;
                                    request2.Proxy = proxy;
                                    request2.CookieContainer = container;
                                    cookies = container.GetCookies(new Uri("http://www.b92.net/"));
                                    foreach (Cookie cookie in cookies)
                                    {
                                        if (!cookie.Name.Contains("PHPSESS"))
                                        {
                                            cookie.Expires = DateTime.Now.Subtract(TimeSpan.FromDays(1.0));
                                        }
                                    }
                                    cookies2 = container.GetCookies(new Uri("http://www.b92.net/"));
                                    foreach (Cookie cookie in cookies2)
                                    {
                                        if (!cookie.Name.Contains("PHPSESS"))
                                        {
                                            cookie.Expires = DateTime.Now.Subtract(TimeSpan.FromDays(1.0));
                                        }
                                    }
                                    request2.AllowWriteStreamBuffering = true;
                                    request2.Method = "POST";
                                    request2.Headers.Add("X-Requested-With", "XMLHttpRequest");
                                    request2.Accept = "*/*";
                                    request2.Headers.Add("Accept-Language", "sr-RS,sr;q=0.9,en;q=0.8");
                                    request2.Headers.Add("Accept-Encoding", "gzip, deflate");
                                    request2.Referer = "http://www.b92.net/";
                                    request2.KeepAlive = false;
                                    request2.ContentLength = bytes.Length;
                                    request2.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/34.0.1847.116 Safari/537.36";
                                    request2.ContentType = "application/x-www-form-urlencoded";
                                    str5 = null;
                                    request2.GetRequestStream().Write(bytes, 0, bytes.Length);
                                    request2.GetRequestStream().Close();
                                    using (response2 = (HttpWebResponse) request2.GetResponse())
                                    {
                                        if (response2.StatusCode == HttpStatusCode.OK)
                                        {
                                            using (stream = response2.GetResponseStream())
                                            {
                                                using (reader2 = new StreamReader(stream))
                                                {
                                                    str5 = reader2.ReadToEnd();
                                                }
                                            }
                                        }
                                        cookies3 = response2.Cookies;
                                        foreach (Cookie cookie in cookies3)
                                        {
                                            if (!cookie.Name.Contains("PHPSESS"))
                                            {
                                                cookie.Expires = DateTime.Now.Subtract(TimeSpan.FromDays(1.0));
                                            }
                                        }
                                        response2.Close();
                                    }
                                    worker.ReportProgress(num3 - 1);
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                Label_0EEE:
                    if (str2 == "KURIR")
                    {
                        try
                        {
                            strArray3 = strArray[0].Split(new char[] { ':' });
                            proxy = new WebProxy(strArray3[0], int.Parse(strArray3[1]));
                            str4 = "http://www.kurir-info.rs/";
                            request = (HttpWebRequest) WebRequest.Create(str4);
                            request.AllowWriteStreamBuffering = true;
                            request.KeepAlive = false;
                            request.Proxy = proxy;
                            container = new CookieContainer();
                            request.CookieContainer = container;
                            str5 = null;
                            headers = new WebHeaderCollection();
                            using (response = (HttpWebResponse) request.GetResponse())
                            {
                                for (num2 = 0; num2 < response.Headers.Count; num2++)
                                {
                                    headers.Add(response.Headers.AllKeys[num2], response.Headers.Get(num2));
                                }
                                if (response.StatusCode == HttpStatusCode.OK)
                                {
                                    using (stream = response.GetResponseStream())
                                    {
                                        using (reader = new StreamReader(stream))
                                        {
                                            str5 = reader.ReadToEnd();
                                        }
                                    }
                                }
                                response.Close();
                            }
                            str4 = "http://www.kurir-info.rs/index.php?ctl=content_comment_user&content_id=" + str + "&content_type=1&action=ajax_vote";
                            for (num3 = 0; num3 < 100; num3++)
                            {
                                if (strArray[num3] == null)
                                {
                                    break;
                                }
                                if (((strArray[num3] != "******") && strArray[num3].Contains("www")) && (strArray[num3].Length > 2))
                                {
                                    strArray5 = strArray[num3].ToString().Split(new char[] { '#' });
                                    str7 = "";
                                    if (strArray5[0] == "up")
                                    {
                                        str7 = "1";
                                    }
                                    else
                                    {
                                        str7 = "2";
                                    }
                                    str8 = strArray5[1].Replace("komentar_", "").Replace("k", "");
                                    str9 = strArray5[2];
                                    str13 = "&comment_id=" + str8 + "&a=" + str7;
                                    bytes = Encoding.UTF8.GetBytes(str13);
                                    request2 = (HttpWebRequest) WebRequest.Create(str4);
                                    request2.Timeout = 0x4e20;
                                    request2.Proxy = proxy;
                                    request2.CookieContainer = container;
                                    cookies = container.GetCookies(new Uri("http://www.kurir-info.rs"));
                                    foreach (Cookie cookie in cookies)
                                    {
                                        if (!cookie.Name.Contains("PHPSESS"))
                                        {
                                            cookie.Expires = DateTime.Now.Subtract(TimeSpan.FromDays(1.0));
                                        }
                                    }
                                    cookies2 = container.GetCookies(new Uri("http://www.kurir-info.rs"));
                                    foreach (Cookie cookie in cookies2)
                                    {
                                        if (!cookie.Name.Contains("PHPSESS"))
                                        {
                                            cookie.Expires = DateTime.Now.Subtract(TimeSpan.FromDays(1.0));
                                        }
                                    }
                                    request2.AllowWriteStreamBuffering = true;
                                    request2.Method = "POST";
                                    request2.Headers.Add("X-Requested-With", "XMLHttpRequest");
                                    request2.Accept = "*/*";
                                    request2.Headers.Add("Accept-Language", "sr-RS,sr;q=0.9,en;q=0.8");
                                    request2.Headers.Add("Accept-Encoding", "gzip, deflate");
                                    request2.Referer = "http://www.kurir-info.rs";
                                    request2.KeepAlive = false;
                                    request2.ContentLength = bytes.Length;
                                    request2.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/34.0.1847.116 Safari/537.36";
                                    request2.ContentType = "application/x-www-form-urlencoded";
                                    str5 = null;
                                    request2.GetRequestStream().Write(bytes, 0, bytes.Length);
                                    request2.GetRequestStream().Close();
                                    using (response2 = (HttpWebResponse) request2.GetResponse())
                                    {
                                        if (response2.StatusCode == HttpStatusCode.OK)
                                        {
                                            using (stream = response2.GetResponseStream())
                                            {
                                                using (reader2 = new StreamReader(stream))
                                                {
                                                    str5 = reader2.ReadToEnd();
                                                }
                                            }
                                        }
                                        cookies3 = response2.Cookies;
                                        foreach (Cookie cookie in cookies3)
                                        {
                                            if (!cookie.Name.Contains("PHPSESS"))
                                            {
                                                cookie.Expires = DateTime.Now.Subtract(TimeSpan.FromDays(1.0));
                                            }
                                        }
                                        response2.Close();
                                    }
                                    worker.ReportProgress(num3 - 1);
                                }
                            }
                            goto Label_14FF;
                        }
                        catch
                        {
                        }
                    }
                }
                catch (Exception exception)
                {
                    e.Result = exception.ToString();
                }
            }
            catch
            {
            }
        Label_14FF:
            Thread.Sleep(0x88b8);
        }

        private void pozadina_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                int progressPercentage = e.ProgressPercentage;
                if (this.ZaustaviSmanjivanje == 0)
                {
                    if (this.BrojacRadniZadaci[progressPercentage] == 0)
                    {
                        this.BrojacRadniZadaci[progressPercentage]--;
                        this.RadniZadaci[progressPercentage] = "******";
                        string text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + " - Glasanje " + this.IdKomentara[progressPercentage] + " stopirano, čekamo upoređivanje sa realnim stanjem.\r\n";
                        int textLength = this.richTextBox1.TextLength;
                        this.richTextBox1.AppendText(text);
                        this.richTextBox1.SelectionStart = textLength;
                        this.richTextBox1.SelectionLength = text.Length;
                        this.richTextBox1.SelectionColor = Color.PaleVioletRed;
                        this.richTextBox1.ScrollToCaret();
                    }
                    else
                    {
                        this.BrojacRadniZadaci[progressPercentage]--;
                    }
                }
            }
            catch
            {
            }
        }

        private void pozadina_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.aktivnoservera--;
        }

        private void PrikaziKomentare_Click(object sender, EventArgs e)
        {
            VestiPrikazRealnihKomentara komentara = new VestiPrikazRealnihKomentara {
                LINK = this.GLAVNILINK,
                NASLOV = this.Naslov.Text,
                SLIKA = this.pictureBox1.BackgroundImage
            };
            komentara.KomandaGlasaj += new EventHandler<VestiPrikazRealnihKomentara.PosaljiNazadKomentar>(this.vestkom_KomandaGlasaj);
            komentara.KomandaKomentari += new EventHandler<VestiPrikazRealnihKomentara.PosaljiKomentar>(this.vestkom_KomandaKomentari);
            komentara.KomandaBrisanjeGlasanja += new EventHandler<VestiPrikazRealnihKomentara.PosaljiBrisanjeGlasanja>(this.vestkom_KomandaBrisanjeGlasanja);
            komentara.Show();
        }

        private void ProsekGlasanja_Tick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.ZaustaviSmanjivanje = 1;
            this.ProsekGlasanja.Stop();
            this.ProsekGlasanja.Enabled = false;
            string[] argument = new string[500];
            argument[0] = this.GLAVNILINK;
            int index = 1;
            int num2 = 0;
            foreach (string str in this.Evidencija)
            {
                int num3;
                switch (str)
                {
                    case null:
                        goto Label_012B;

                    case "******":
                    {
                        continue;
                    }
                    default:
                        num3 = 0;
                        foreach (string str2 in this.RadniZadaci)
                        {
                            if (str2 == null)
                            {
                                break;
                            }
                            if ((str2 != "******") && str.StartsWith(str2))
                            {
                                num3 = 1;
                                num2++;
                                break;
                            }
                        }
                        break;
                }
                if (num3 == 0)
                {
                    argument[index] = str;
                    index++;
                }
            }
        Label_012B:;
            string text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + " - Trenutno se glasa na [" + num2.ToString() + "] komentara. \r\n";
            int textLength = this.richTextBox1.TextLength;
            this.richTextBox1.AppendText(text);
            this.richTextBox1.SelectionStart = textLength;
            this.richTextBox1.SelectionLength = text.Length;
            this.richTextBox1.SelectionColor = Color.SkyBlue;
            this.richTextBox1.ScrollToCaret();
            if (argument[1] != null)
            {
                this.ProveraRealnihBrojeva.RunWorkerAsync(argument);
            }
            else
            {
                this.ZaustaviSmanjivanje = 0;
                this.ProsekGlasanja.Enabled = true;
                this.ProsekGlasanja.Start();
            }
            Cursor.Current = Cursors.Default;
        }

        private void ProveraRealnihBrojeva_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int num2;
                int num3;
                string[] strArray6;
                int num5;
                Random random;
                int num6;
                int num7;
                Random random2;
                int num8;
                string[] strArray = new string[0x3e8];
                int index = 0;
                string[] argument = new string[500];
                argument = (string[]) e.Argument;
                string str = argument[0];
                string address = str;
                string[] strArray3 = str.Split(new char[] { '=' });
                string[] strArray4 = str.Split(new char[] { '/' });
                if (!(!address.Contains("www.blic.rs") || address.Contains("komentari")))
                {
                    address = address + "/komentari#vas-komentar";
                }
                if (address.Contains("www.b92.net"))
                {
                    try
                    {
                        if (address.Contains("www.b92.net/eng/news"))
                        {
                            address = "http://www.b92.net/eng/news/comments.php?nav_id=" + strArray3[strArray3.Length - 1];
                        }
                        else
                        {
                            address = "http://www.b92.net/info/komentari.php?nav_id=" + strArray3[strArray3.Length - 1];
                        }
                    }
                    catch
                    {
                    }
                }
                string str3 = "";
                if (!(!address.Contains("www.kurir-info.rs") || address.Contains("komentari")))
                {
                    address = strArray4[0] + "//" + strArray4[2] + "/komentari/" + strArray4[strArray4.Length - 1];
                    str3 = "/komentari/" + strArray4[strArray4.Length - 1];
                }
                string html = "";
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
                if (address.Contains("blic.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='comm_text']"))
                        {
                            num2 = 0;
                            num3 = 0;
                            try
                            {
                                string[] strArray10;
                                int num17;
                                string id = node.ParentNode.Id;
                                try
                                {
                                    string[] strArray5 = node.ParentNode.OuterHtml.Split(new char[] { '>' });
                                    int num4 = 0;
                                    strArray10 = strArray5;
                                    num17 = 0;
                                    while (num17 < strArray10.Length)
                                    {
                                        string str6 = strArray10[num17];
                                        if (str6.Contains("vote_p"))
                                        {
                                            try
                                            {
                                                num2 = int.Parse(strArray5[num4 + 1].Replace("</span", ""));
                                            }
                                            catch
                                            {
                                            }
                                        }
                                        if (str6.Contains("vote_n"))
                                        {
                                            try
                                            {
                                                num3 = int.Parse(strArray5[num4 + 1].Replace("</span", ""));
                                                goto Label_0339;
                                            }
                                            catch
                                            {
                                            }
                                        }
                                        num4++;
                                        num17++;
                                    }
                                }
                                catch
                                {
                                }
                            Label_0339:
                                strArray10 = argument;
                                for (num17 = 0; num17 < strArray10.Length; num17++)
                                {
                                    str9 = strArray10[num17];
                                    if ((str9 != null) && str9.Contains(id))
                                    {
                                        strArray6 = str9.Split(new char[] { '#' });
                                        num5 = int.Parse(strArray6[strArray6.Length - 1]);
                                        if (num5 == 0)
                                        {
                                            if (str9.Contains("up"))
                                            {
                                                if (num3 >= num2)
                                                {
                                                    random = new Random();
                                                    num6 = random.Next(100, 180);
                                                    num7 = (num3 - num2) + num6;
                                                    strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                    index++;
                                                }
                                                else
                                                {
                                                    random2 = new Random();
                                                    num8 = random2.Next(100, 180);
                                                    if ((num3 + num8) >= num2)
                                                    {
                                                        num7 = num8;
                                                        strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                        index++;
                                                    }
                                                }
                                            }
                                            else if (num2 >= num3)
                                            {
                                                random = new Random();
                                                num6 = random.Next(100, 180);
                                                num7 = (num2 - num3) + num6;
                                                strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                index++;
                                            }
                                            else
                                            {
                                                random2 = new Random();
                                                num8 = random2.Next(100, 180);
                                                if ((num2 + num8) >= num3)
                                                {
                                                    num7 = num8;
                                                    strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                    index++;
                                                }
                                            }
                                        }
                                        else if (str9.Contains("up"))
                                        {
                                            if (num5 > num2)
                                            {
                                                num7 = (num5 - num2) + 10;
                                                strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                index++;
                                            }
                                        }
                                        else if (num5 > num3)
                                        {
                                            num7 = (num5 - num3) + 10;
                                            strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                            index++;
                                        }
                                        continue;
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
                    }
                }
                if (address.Contains("b92.net"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@id='tab-comments-h-tab']"))
                        {
                            for (int i = 0; i <= (node.ChildNodes[0].ChildNodes[3].ChildNodes.Count - 1); i++)
                            {
                                string innerText = node.ChildNodes[0].ChildNodes[3].ChildNodes[i].InnerText;
                                string str11 = node.ChildNodes[0].ChildNodes[3].ChildNodes[i].Id;
                                int num10 = 0;
                                int num11 = 0;
                                foreach (string str9 in argument)
                                {
                                    if (str9 != null)
                                    {
                                        if (!str9.Contains(str11))
                                        {
                                            continue;
                                        }
                                        string[] strArray7 = innerText.Split(new char[] { '(' });
                                        string[] strArray8 = new string[10];
                                        int num12 = 0;
                                        string str13 = "";
                                        foreach (string str14 in strArray7)
                                        {
                                            if (str14.Contains("Link komentara"))
                                            {
                                                break;
                                            }
                                            strArray8[num12] = str13 + str14;
                                            num12++;
                                        }
                                        try
                                        {
                                            int num13;
                                            int num14;
                                            string str15 = node.ChildNodes[0].ChildNodes[3].ChildNodes[i].InnerText.Replace("# Link komentara", "").Replace("&nbsp;", "").Replace("&hellip;", "").Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("Šta je ovo", "").Replace("# Comment link", "").Replace("What's this?", "");
                                            try
                                            {
                                                if (str15.Contains("Preporučujem ("))
                                                {
                                                    num2 = 0;
                                                    str15 = str15.Replace("Preporučujem (0)", "");
                                                    num13 = 1;
                                                    while (num13 < 0x5dc)
                                                    {
                                                        if (str15.Contains("Preporučujem (+"))
                                                        {
                                                            str15 = str15.Replace("Preporučujem (+" + num13.ToString() + ")", "");
                                                            num2++;
                                                        }
                                                        else
                                                        {
                                                            break;
                                                        }
                                                        num13++;
                                                    }
                                                    num10 = num2;
                                                }
                                            }
                                            catch
                                            {
                                            }
                                            try
                                            {
                                                if (str15.Contains("Ne preporučujem ("))
                                                {
                                                    num3 = 0;
                                                    str15 = str15.Replace("Ne preporučujem (0)", "");
                                                    num14 = 1;
                                                    while (num14 < 0x5dc)
                                                    {
                                                        if (str15.Contains("Ne preporučujem (-"))
                                                        {
                                                            str15 = str15.Replace("Ne preporučujem (-" + num14.ToString() + ")", "");
                                                            num3++;
                                                        }
                                                        else
                                                        {
                                                            break;
                                                        }
                                                        num14++;
                                                    }
                                                    num11 = num3;
                                                }
                                            }
                                            catch
                                            {
                                            }
                                            try
                                            {
                                                if (str15.Contains("Recommend ("))
                                                {
                                                    num2 = 0;
                                                    str15 = str15.Replace("Recommend (0)", "");
                                                    for (num13 = 1; num13 < 0x5dc; num13++)
                                                    {
                                                        if (str15.Contains("Recommend (+"))
                                                        {
                                                            str15 = str15.Replace("Recommend (+" + num13.ToString() + ")", "");
                                                            num2++;
                                                        }
                                                        else
                                                        {
                                                            break;
                                                        }
                                                    }
                                                    num10 = num2;
                                                }
                                            }
                                            catch
                                            {
                                            }
                                            try
                                            {
                                                if (str15.Contains("Poor comment ("))
                                                {
                                                    num3 = 0;
                                                    str15 = str15.Replace("Poor comment (0)", "");
                                                    for (num14 = 1; num14 < 0x5dc; num14++)
                                                    {
                                                        if (str15.Contains("Poor comment (-"))
                                                        {
                                                            str15 = str15.Replace("Poor comment (-" + num14.ToString() + ")", "");
                                                            num3++;
                                                        }
                                                        else
                                                        {
                                                            break;
                                                        }
                                                    }
                                                    num11 = num3;
                                                }
                                            }
                                            catch
                                            {
                                            }
                                        }
                                        catch
                                        {
                                        }
                                        strArray6 = str9.Split(new char[] { '#' });
                                        num5 = int.Parse(strArray6[strArray6.Length - 1]);
                                        if (num5 == 0)
                                        {
                                            if (str9.Contains("up"))
                                            {
                                                if (num11 >= num10)
                                                {
                                                    random = new Random();
                                                    num6 = random.Next(20, 30);
                                                    num7 = (num11 - num10) + num6;
                                                    strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                    index++;
                                                }
                                                else
                                                {
                                                    random2 = new Random();
                                                    num8 = random2.Next(20, 30);
                                                    if ((num11 + num8) >= num10)
                                                    {
                                                        num7 = num8;
                                                        strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                        index++;
                                                    }
                                                }
                                            }
                                            else if (num10 >= num11)
                                            {
                                                random = new Random();
                                                num6 = random.Next(20, 30);
                                                num7 = (num10 - num11) + num6;
                                                strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                index++;
                                            }
                                            else
                                            {
                                                random2 = new Random();
                                                num8 = random2.Next(20, 30);
                                                if ((num10 + num8) >= num11)
                                                {
                                                    num7 = num8;
                                                    strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                    index++;
                                                }
                                            }
                                        }
                                        else if (str9.Contains("up"))
                                        {
                                            if (num5 > num10)
                                            {
                                                num7 = (num5 - num10) + 10;
                                                strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                index++;
                                            }
                                        }
                                        else if (num5 > num11)
                                        {
                                            num7 = (num5 - num11) + 10;
                                            strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                            index++;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                if (address.Contains("kurir-info"))
                {
                    try
                    {
                        string str16;
                        int num15;
                        int num16;
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//p[@itemprop='commentText']"))
                        {
                            try
                            {
                                str16 = node.ParentNode.ChildNodes[9].Attributes[0].Value;
                                num15 = 0;
                                num16 = 0;
                                num15 = int.Parse(node.ParentNode.ChildNodes[7].ChildNodes[1].InnerText.Replace("Preporučujem (", "").Replace(")&nbsp;", ""));
                                num16 = int.Parse(node.ParentNode.ChildNodes[7].ChildNodes[5].InnerText.Replace("Ne Preporučujem (", "").Replace(")&nbsp;", ""));
                                foreach (string str9 in argument)
                                {
                                    if (str9 == null)
                                    {
                                        continue;
                                    }
                                    if (str9.Contains(str16))
                                    {
                                        strArray6 = str9.Split(new char[] { '#' });
                                        num5 = int.Parse(strArray6[strArray6.Length - 1]);
                                        if (num5 == 0)
                                        {
                                            if (str9.Contains("up"))
                                            {
                                                if (num16 >= num15)
                                                {
                                                    random = new Random();
                                                    num6 = random.Next(20, 30);
                                                    num7 = (num16 - num15) + num6;
                                                    strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                    index++;
                                                }
                                                else
                                                {
                                                    random2 = new Random();
                                                    num8 = random2.Next(20, 30);
                                                    if ((num16 + num8) >= num15)
                                                    {
                                                        num7 = num8;
                                                        strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                        index++;
                                                    }
                                                }
                                            }
                                            else if (num15 >= num16)
                                            {
                                                random = new Random();
                                                num6 = random.Next(20, 30);
                                                num7 = (num15 - num16) + num6;
                                                strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                index++;
                                            }
                                            else
                                            {
                                                random2 = new Random();
                                                num8 = random2.Next(20, 30);
                                                if ((num15 + num8) >= num16)
                                                {
                                                    num7 = num8;
                                                    strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                    index++;
                                                }
                                            }
                                        }
                                        else if (str9.Contains("up"))
                                        {
                                            if (num5 > num15)
                                            {
                                                num7 = (num5 - num15) + 10;
                                                strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                index++;
                                            }
                                        }
                                        else if (num5 > num16)
                                        {
                                            num7 = (num5 - num16) + 10;
                                            strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                            index++;
                                        }
                                        continue;
                                    }
                                }
                            }
                            catch
                            {
                            }
                        }
                        try
                        {
                            foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//a[@href='" + str3 + "?page=2']"))
                            {
                                if (!node.InnerHtml.Contains("stranica"))
                                {
                                    string str19;
                                    using (WebClient client2 = new WebClient())
                                    {
                                        client2.Encoding = Encoding.UTF8;
                                        str19 = client2.DownloadString(address + "?page=2");
                                        client2.Dispose();
                                    }
                                    HtmlAgilityPack.HtmlDocument document2 = new HtmlAgilityPack.HtmlDocument();
                                    document2.LoadHtml(str19);
                                    foreach (HtmlNode node2 in (IEnumerable<HtmlNode>) document2.DocumentNode.SelectNodes("//p[@itemprop='commentText']"))
                                    {
                                        try
                                        {
                                            str16 = node2.ParentNode.ChildNodes[9].Attributes[0].Value;
                                            num15 = 0;
                                            num16 = 0;
                                            num15 = int.Parse(node2.ParentNode.ChildNodes[7].ChildNodes[1].InnerText.Replace("Preporučujem (", "").Replace(")&nbsp;", ""));
                                            num16 = int.Parse(node2.ParentNode.ChildNodes[7].ChildNodes[5].InnerText.Replace("Ne Preporučujem (", "").Replace(")&nbsp;", ""));
                                            foreach (string str9 in argument)
                                            {
                                                if (str9 == null)
                                                {
                                                    continue;
                                                }
                                                if (str9.Contains(str16))
                                                {
                                                    strArray6 = str9.Split(new char[] { '#' });
                                                    num5 = int.Parse(strArray6[strArray6.Length - 1]);
                                                    if (num5 == 0)
                                                    {
                                                        if (str9.Contains("up"))
                                                        {
                                                            if (num16 >= num15)
                                                            {
                                                                random = new Random();
                                                                num6 = random.Next(20, 30);
                                                                num7 = (num16 - num15) + num6;
                                                                strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                                index++;
                                                            }
                                                            else
                                                            {
                                                                random2 = new Random();
                                                                num8 = random2.Next(20, 30);
                                                                if ((num16 + num8) >= num15)
                                                                {
                                                                    num7 = num8;
                                                                    strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                                    index++;
                                                                }
                                                            }
                                                        }
                                                        else if (num15 >= num16)
                                                        {
                                                            random = new Random();
                                                            num6 = random.Next(20, 30);
                                                            num7 = (num15 - num16) + num6;
                                                            strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                            index++;
                                                        }
                                                        else
                                                        {
                                                            random2 = new Random();
                                                            num8 = random2.Next(20, 30);
                                                            if ((num15 + num8) >= num16)
                                                            {
                                                                num7 = num8;
                                                                strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                                index++;
                                                            }
                                                        }
                                                    }
                                                    else if (str9.Contains("up"))
                                                    {
                                                        if (num5 > num15)
                                                        {
                                                            num7 = (num5 - num15) + 10;
                                                            strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                            index++;
                                                        }
                                                    }
                                                    else if (num5 > num16)
                                                    {
                                                        num7 = (num5 - num16) + 10;
                                                        strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                        index++;
                                                    }
                                                    continue;
                                                }
                                            }
                                        }
                                        catch
                                        {
                                        }
                                    }
                                    try
                                    {
                                        foreach (HtmlNode node3 in (IEnumerable<HtmlNode>) document2.DocumentNode.SelectNodes("//a[@href='" + str3 + "?page=3']"))
                                        {
                                            if (!node3.InnerHtml.Contains("stranica"))
                                            {
                                                string str20;
                                                using (WebClient client3 = new WebClient())
                                                {
                                                    client3.Encoding = Encoding.UTF8;
                                                    str20 = client3.DownloadString(address + "?page=3");
                                                    client3.Dispose();
                                                }
                                                HtmlAgilityPack.HtmlDocument document3 = new HtmlAgilityPack.HtmlDocument();
                                                document3.LoadHtml(str20);
                                                foreach (HtmlNode node4 in (IEnumerable<HtmlNode>) document3.DocumentNode.SelectNodes("//p[@itemprop='commentText']"))
                                                {
                                                    try
                                                    {
                                                        str16 = node4.ParentNode.ChildNodes[9].Attributes[0].Value;
                                                        num15 = 0;
                                                        num16 = 0;
                                                        num15 = int.Parse(node4.ParentNode.ChildNodes[7].ChildNodes[1].InnerText.Replace("Preporučujem (", "").Replace(")&nbsp;", ""));
                                                        num16 = int.Parse(node4.ParentNode.ChildNodes[7].ChildNodes[5].InnerText.Replace("Ne Preporučujem (", "").Replace(")&nbsp;", ""));
                                                        foreach (string str9 in argument)
                                                        {
                                                            if (str9 == null)
                                                            {
                                                                continue;
                                                            }
                                                            if (str9.Contains(str16))
                                                            {
                                                                strArray6 = str9.Split(new char[] { '#' });
                                                                num5 = int.Parse(strArray6[strArray6.Length - 1]);
                                                                if (num5 == 0)
                                                                {
                                                                    if (str9.Contains("up"))
                                                                    {
                                                                        if (num16 >= num15)
                                                                        {
                                                                            random = new Random();
                                                                            num6 = random.Next(20, 30);
                                                                            num7 = (num16 - num15) + num6;
                                                                            strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                                            index++;
                                                                        }
                                                                        else
                                                                        {
                                                                            random2 = new Random();
                                                                            num8 = random2.Next(20, 30);
                                                                            if ((num16 + num8) >= num15)
                                                                            {
                                                                                num7 = num8;
                                                                                strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                                                index++;
                                                                            }
                                                                        }
                                                                    }
                                                                    else if (num15 >= num16)
                                                                    {
                                                                        random = new Random();
                                                                        num6 = random.Next(20, 30);
                                                                        num7 = (num15 - num16) + num6;
                                                                        strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                                        index++;
                                                                    }
                                                                    else
                                                                    {
                                                                        random2 = new Random();
                                                                        num8 = random2.Next(20, 30);
                                                                        if ((num15 + num8) >= num16)
                                                                        {
                                                                            num7 = num8;
                                                                            strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                                            index++;
                                                                        }
                                                                    }
                                                                }
                                                                else if (str9.Contains("up"))
                                                                {
                                                                    if (num5 > num15)
                                                                    {
                                                                        num7 = (num5 - num15) + 10;
                                                                        strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                                        index++;
                                                                    }
                                                                }
                                                                else if (num5 > num16)
                                                                {
                                                                    num7 = (num5 - num16) + 10;
                                                                    strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                                    index++;
                                                                }
                                                                continue;
                                                            }
                                                        }
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                                try
                                                {
                                                    foreach (HtmlNode node5 in (IEnumerable<HtmlNode>) document3.DocumentNode.SelectNodes("//a[@href='" + str3 + "?page=4']"))
                                                    {
                                                        if (!node5.InnerHtml.Contains("stranica"))
                                                        {
                                                            string str21;
                                                            using (WebClient client4 = new WebClient())
                                                            {
                                                                client4.Encoding = Encoding.UTF8;
                                                                str21 = client4.DownloadString(address + "?page=4");
                                                                client4.Dispose();
                                                            }
                                                            HtmlAgilityPack.HtmlDocument document4 = new HtmlAgilityPack.HtmlDocument();
                                                            document4.LoadHtml(str21);
                                                            foreach (HtmlNode node6 in (IEnumerable<HtmlNode>) document4.DocumentNode.SelectNodes("//p[@itemprop='commentText']"))
                                                            {
                                                                try
                                                                {
                                                                    str16 = node6.ParentNode.ChildNodes[9].Attributes[0].Value;
                                                                    num15 = 0;
                                                                    num16 = 0;
                                                                    num15 = int.Parse(node6.ParentNode.ChildNodes[7].ChildNodes[1].InnerText.Replace("Preporučujem (", "").Replace(")&nbsp;", ""));
                                                                    num16 = int.Parse(node6.ParentNode.ChildNodes[7].ChildNodes[5].InnerText.Replace("Ne Preporučujem (", "").Replace(")&nbsp;", ""));
                                                                    foreach (string str9 in argument)
                                                                    {
                                                                        if (str9 == null)
                                                                        {
                                                                            continue;
                                                                        }
                                                                        if (str9.Contains(str16))
                                                                        {
                                                                            strArray6 = str9.Split(new char[] { '#' });
                                                                            num5 = int.Parse(strArray6[strArray6.Length - 1]);
                                                                            if (num5 == 0)
                                                                            {
                                                                                if (str9.Contains("up"))
                                                                                {
                                                                                    if (num16 >= num15)
                                                                                    {
                                                                                        random = new Random();
                                                                                        num6 = random.Next(20, 30);
                                                                                        num7 = (num16 - num15) + num6;
                                                                                        strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                                                        index++;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        random2 = new Random();
                                                                                        num8 = random2.Next(20, 30);
                                                                                        if ((num16 + num8) >= num15)
                                                                                        {
                                                                                            num7 = num8;
                                                                                            strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                                                            index++;
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else if (num15 >= num16)
                                                                                {
                                                                                    num6 = new Random().Next(20, 30);
                                                                                    num7 = (num15 - num16) + num6;
                                                                                    strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                                                    index++;
                                                                                }
                                                                                else
                                                                                {
                                                                                    num8 = new Random().Next(20, 30);
                                                                                    if ((num15 + num8) >= num16)
                                                                                    {
                                                                                        num7 = num8;
                                                                                        strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                                                        index++;
                                                                                    }
                                                                                }
                                                                            }
                                                                            else if (str9.Contains("up"))
                                                                            {
                                                                                if (num5 > num15)
                                                                                {
                                                                                    num7 = (num5 - num15) + 10;
                                                                                    strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                                                    index++;
                                                                                }
                                                                            }
                                                                            else if (num5 > num16)
                                                                            {
                                                                                num7 = (num5 - num16) + 10;
                                                                                strArray[index] = strArray6[0] + "#" + strArray6[1] + "#" + strArray6[2] + "#" + num7.ToString();
                                                                                index++;
                                                                            }
                                                                            continue;
                                                                        }
                                                                    }
                                                                }
                                                                catch
                                                                {
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
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                    catch
                    {
                    }
                }
                e.Result = strArray;
            }
            catch
            {
            }
        }

        private void ProveraRealnihBrojeva_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string str3;
            int textLength;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string[] result = (string[]) e.Result;
                foreach (string str in result)
                {
                    string[] strArray2 = str.Split(new char[] { '#' });
                    for (int i = 0; i < 100; i++)
                    {
                        if ((this.RadniZadaci[i] == null) || (this.RadniZadaci[i] == "******"))
                        {
                            this.RadniZadaci[i] = strArray2[0] + "#" + strArray2[1] + "#" + strArray2[2];
                            this.IdKomentara[i] = strArray2[1];
                            this.BrojacRadniZadaci[i] = int.Parse(strArray2[3]);
                            string str2 = "";
                            if (strArray2[0] == "up")
                            {
                                str2 = "PLUS";
                            }
                            else
                            {
                                str2 = "MINUS";
                            }
                            str3 = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + " - Obnovljeno glasanje " + str2 + " na " + strArray2[1] + " za [" + strArray2[3] + "]\r\n";
                            textLength = this.richTextBox1.TextLength;
                            this.richTextBox1.AppendText(str3);
                            this.richTextBox1.SelectionStart = textLength;
                            this.richTextBox1.SelectionLength = str3.Length;
                            this.richTextBox1.SelectionColor = Color.MediumSeaGreen;
                            this.richTextBox1.ScrollToCaret();
                            break;
                        }
                    }
                }
            }
            catch
            {
            }
            try
            {
                int index = 0;
                foreach (string str4 in this.Evidencija)
                {
                    int num4;
                    switch (str4)
                    {
                        case null:
                            goto Label_045B;

                        case "******":
                        {
                            index++;
                            continue;
                        }
                        default:
                            if (str4.EndsWith("#0"))
                            {
                                index++;
                                continue;
                            }
                            num4 = 0;
                            foreach (string str5 in this.RadniZadaci)
                            {
                                if (str5 == null)
                                {
                                    break;
                                }
                                if (str4.StartsWith(str5))
                                {
                                    num4 = 1;
                                    break;
                                }
                            }
                            break;
                    }
                    if (num4 == 0)
                    {
                        TimeSpan span = (TimeSpan) (DateTime.Now - this.PocetnoVremeGlasanja[index]);
                        string[] strArray3 = str4.Split(new char[] { '#' });
                        str3 = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + " - Završeno glasanje na " + strArray3[1] + " ,dostignuto realno glasova preko [" + strArray3[3] + "] , za " + Math.Round(span.TotalMinutes, 2).ToString() + " minuta.\r\n";
                        textLength = this.richTextBox1.TextLength;
                        this.richTextBox1.AppendText(str3);
                        this.richTextBox1.SelectionStart = textLength;
                        this.richTextBox1.SelectionLength = str3.Length;
                        this.richTextBox1.SelectionColor = Color.Red;
                        this.Evidencija[index] = "******";
                        this.richTextBox1.ScrollToCaret();
                    }
                    index++;
                }
            }
            catch
            {
            }
        Label_045B:
            this.ProsekGlasanja.Enabled = true;
            this.ProsekGlasanja.Start();
            this.ZaustaviSmanjivanje = 0;
            Cursor.Current = Cursors.Default;
        }

        private void ProxyTimer_Tick(object sender, EventArgs e)
        {
            this.ProxyTimer.Stop();
            this.ProxyTimer.Enabled = false;
            if (this.aktivnoservera < this.DozvoljenoMaxServera)
            {
                string str = "";
                if (this.GLAVNILINK.Contains("kurir-info.rs"))
                {
                    string[] strArray = this.GLAVNILINK.Split(new char[] { '-' });
                    str = this.vest + "$" + strArray[strArray.Length - 1] + "%";
                }
                else
                {
                    str = this.vest + "%";
                }
                foreach (string str2 in this.RadniZadaci)
                {
                    if (str2 == null)
                    {
                        break;
                    }
                    str = str + str2 + "%";
                }
                int odjednomPokreni = this.OdjednomPokreni;
                for (int i = 0; i < odjednomPokreni; i++)
                {
                    string argument = this.IpAdrese[this.PokretanjeServera] + str;
                    this.PokretanjeServera++;
                    this.aktivnoservera++;
                    BackgroundWorker worker = new BackgroundWorker();
                    worker.DoWork += new DoWorkEventHandler(this.pozadina_DoWork);
                    worker.WorkerReportsProgress = true;
                    worker.ProgressChanged += new ProgressChangedEventHandler(this.pozadina_ProgressChanged);
                    worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.pozadina_RunWorkerCompleted);
                    worker.RunWorkerAsync(argument);
                    if ((this.PokretanjeServera + 1) > this.ipbroj)
                    {
                        this.PokretanjeServera = 0;
                    }
                }
            }
            this.ProxyTimer.Enabled = true;
            this.ProxyTimer.Start();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.OdjednomPokreni = this.trackBar1.Value;
            this.label1.Text = "Brzina rada programa: " + this.trackBar1.Value.ToString();
        }

        private void vestkom_KomandaBrisanjeGlasanja(object sender, VestiPrikazRealnihKomentara.PosaljiBrisanjeGlasanja e)
        {
            try
            {
                string str = e.DobijenKomentar2;
                for (int i = 1; i < 100; i++)
                {
                    if ((this.RadniZadaci[i] != null) && this.RadniZadaci[i].Contains(str))
                    {
                        this.RadniZadaci[i] = "******";
                        break;
                    }
                }
                for (int j = 0; j < 0x3e8; j++)
                {
                    if ((this.Evidencija[j] != null) && this.Evidencija[j].Contains(str))
                    {
                        this.Evidencija[j] = "******";
                        break;
                    }
                }
                string text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + " - Završeno glasanje na " + str + " ,na zahtev korisnika.\r\n";
                int textLength = this.richTextBox1.TextLength;
                this.richTextBox1.AppendText(text);
                this.richTextBox1.SelectionStart = textLength;
                this.richTextBox1.SelectionLength = text.Length;
                this.richTextBox1.SelectionColor = Color.Red;
                this.richTextBox1.ScrollToCaret();
            }
            catch
            {
            }
        }

        private void vestkom_KomandaGlasaj(object sender, VestiPrikazRealnihKomentara.PosaljiNazadKomentar e)
        {
            int num;
            string str;
            string str2;
            int textLength;
            string[] dobijenKomentar = e.DobijenKomentar;
            if (!(dobijenKomentar[2] == "0"))
            {
                for (int i = 0; i < 100; i++)
                {
                    if ((this.RadniZadaci[i] == null) || (this.RadniZadaci[i] == "******"))
                    {
                        this.RadniZadaci[i] = dobijenKomentar[0];
                        this.IdKomentara[i] = dobijenKomentar[1];
                        this.BrojacRadniZadaci[i] = int.Parse(dobijenKomentar[2]);
                        for (num = 0; num < 0x3e8; num++)
                        {
                            if ((this.Evidencija[num] == null) || (this.Evidencija[num] == "******"))
                            {
                                this.Evidencija[num] = dobijenKomentar[0] + "#" + ((int.Parse(dobijenKomentar[3]) + int.Parse(dobijenKomentar[2]))).ToString();
                                this.PocetnoVremeGlasanja[num] = DateTime.Now;
                                break;
                            }
                        }
                        str = "";
                        if (dobijenKomentar[0].Contains("up"))
                        {
                            str = "PLUS";
                        }
                        else
                        {
                            str = "MINUS";
                        }
                        str2 = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + " - Započeto glasanje " + str + " na " + dobijenKomentar[1] + " za " + dobijenKomentar[2] + ", trenutno realnih glasova [" + dobijenKomentar[3] + "]\r\n";
                        textLength = this.richTextBox1.TextLength;
                        this.richTextBox1.AppendText(str2);
                        this.richTextBox1.SelectionStart = textLength;
                        this.richTextBox1.SelectionLength = str2.Length;
                        this.richTextBox1.SelectionColor = Color.Green;
                        this.richTextBox1.ScrollToCaret();
                        break;
                    }
                }
            }
            else
            {
                for (num = 0; num < 0x3e8; num++)
                {
                    if ((this.Evidencija[num] == null) || (this.Evidencija[num] == "******"))
                    {
                        this.Evidencija[num] = dobijenKomentar[0] + "#0";
                        this.PocetnoVremeGlasanja[num] = DateTime.Now;
                        break;
                    }
                }
                str = "";
                if (dobijenKomentar[0].Contains("up"))
                {
                    str = "PLUS";
                }
                else
                {
                    str = "MINUS";
                }
                str2 = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + " - Pokrenuto automatsko glasanje " + str + " na " + dobijenKomentar[1] + "\r\n";
                textLength = this.richTextBox1.TextLength;
                this.richTextBox1.AppendText(str2);
                this.richTextBox1.SelectionStart = textLength;
                this.richTextBox1.SelectionLength = str2.Length;
                this.richTextBox1.SelectionColor = Color.Green;
                this.richTextBox1.ScrollToCaret();
            }
        }

        private void vestkom_KomandaKomentari(object sender, VestiPrikazRealnihKomentara.PosaljiKomentar e)
        {
            try
            {
                this.vestpri = (VestiPrikazRealnihKomentara) sender;
                this.vestpri.AzurirajKomentareNaKojeSeGlasa(this.Evidencija);
            }
            catch
            {
            }
        }
    }
}

