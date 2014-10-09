namespace InternetTim.Komentari
{
    using InternetTim.Properties;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Media;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    public class Chat1 : Form
    {
        private Button button1;
        private IContainer components = null;
        private bool Connected;
        public const uint FLASHW_ALL = 3;
        public const uint FLASHW_TIMERNOFG = 12;
        private FlowLayoutPanel flowLayoutPanel1;
        private string GlavnaIPadresa = "46.240.192.6";
        private string GlavnoIme = "";
        private const int HTCAPTION = 2;
        private IPAddress ipAddr;
        private Label label1;
        private Button OpcijaZvuk;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        public string PersonalID = "000000";
        private System.Windows.Forms.Timer PocetnoUcitavanje;
        private Button PosaljiPoruku;
        private int potvrdaZvuk = 0;
        private RichTextBox richTextBox1;
        private Button ServerKonekcija;
        private Button SpustiProgram;
        private StreamReader srReceiver;
        private StreamWriter swSender;
        private TableLayoutPanel tableLayoutPanel1;
        private TcpClient tcpServer;
        private TextBox textBox1;
        private Thread thrMessaging;
        private System.Windows.Forms.Timer timer1;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private Button UgasiProgram;
        private string UserName = "Unknown";
        private const int WM_NCLBUTTONDOWN = 0xa1;

        public Chat1()
        {
            this.InitializeComponent();
        }

        private void Chat1_Shown(object sender, EventArgs e)
        {
            this.PocetnoUcitavanje.Enabled = true;
            this.PocetnoUcitavanje.Start();
        }

        private void CloseConnection(string Reason)
        {
            try
            {
                this.richTextBox1.AppendText("\r\nGAŠENJE KONEKCIJE\r\n\r\n");
                this.Connected = false;
                this.swSender.Close();
                this.srReceiver.Close();
                this.tcpServer.Close();
                this.thrMessaging.Abort();
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

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);
        public static bool FlashWindowEx(Form form)
        {
            FLASHWINFO flashwinfo;
            IntPtr handle = form.Handle;
            flashwinfo = new FLASHWINFO {
                cbSize = Convert.ToUInt32(Marshal.SizeOf(flashwinfo)),
                hwnd = handle,
                dwFlags = 15,
                uCount = uint.MaxValue,
                dwTimeout = 0
            };
            return FlashWindowEx(ref flashwinfo);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(Chat1));
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.flowLayoutPanel1 = new FlowLayoutPanel();
            this.panel1 = new Panel();
            this.button1 = new Button();
            this.textBox1 = new TextBox();
            this.panel3 = new Panel();
            this.PosaljiPoruku = new Button();
            this.richTextBox1 = new RichTextBox();
            this.panel2 = new Panel();
            this.OpcijaZvuk = new Button();
            this.trackBar2 = new TrackBar();
            this.trackBar1 = new TrackBar();
            this.SpustiProgram = new Button();
            this.UgasiProgram = new Button();
            this.label1 = new Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PocetnoUcitavanje = new System.Windows.Forms.Timer(this.components);
            this.ServerKonekcija = new Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.trackBar2.BeginInit();
            this.trackBar1.BeginInit();
            base.SuspendLayout();
            this.tableLayoutPanel1.BackColor = Color.Gainsboro;
            this.tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200f));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Location = new Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 150f));
            this.tableLayoutPanel1.Size = new Size(600, 600);
            this.tableLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = Color.Gainsboro;
            this.flowLayoutPanel1.Dock = DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new Point(0x18f, 0x16);
            this.flowLayoutPanel1.Margin = new Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.tableLayoutPanel1.SetRowSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Size = new Size(200, 0x241);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.PosaljiPoruku);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(6, 0x1c6);
            this.panel1.Margin = new Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x183, 140);
            this.panel1.TabIndex = 1;
            this.button1.BackColor = Color.White;
            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.Location = new Point(6, 0x53);
            this.button1.Margin = new Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0xaf, 0x19);
            this.button1.TabIndex = 3;
            this.button1.Text = "ime";
            this.button1.TextAlign = ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.textBox1.BackColor = Color.White;
            this.textBox1.BorderStyle = BorderStyle.FixedSingle;
            this.textBox1.Dock = DockStyle.Fill;
            this.textBox1.Location = new Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x183, 0x70);
            this.textBox1.TabIndex = 1;
            this.textBox1.Visible = false;
            this.textBox1.KeyUp += new KeyEventHandler(this.textBox1_KeyUp);
            this.panel3.Dock = DockStyle.Bottom;
            this.panel3.Location = new Point(0, 0x70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(0x183, 5);
            this.panel3.TabIndex = 2;
            this.PosaljiPoruku.Cursor = Cursors.Hand;
            this.PosaljiPoruku.Dock = DockStyle.Bottom;
            this.PosaljiPoruku.Location = new Point(0, 0x75);
            this.PosaljiPoruku.Name = "PosaljiPoruku";
            this.PosaljiPoruku.Size = new Size(0x183, 0x17);
            this.PosaljiPoruku.TabIndex = 0;
            this.PosaljiPoruku.Text = "Pošalji poruku";
            this.PosaljiPoruku.UseVisualStyleBackColor = true;
            this.PosaljiPoruku.Visible = false;
            this.PosaljiPoruku.Click += new EventHandler(this.PosaljiPoruku_Click);
            this.richTextBox1.BackColor = Color.White;
            this.richTextBox1.Dock = DockStyle.Fill;
            this.richTextBox1.Location = new Point(4, 0x19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new Size(0x187, 420);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "Povezivanje sa serverom...\n";
            this.richTextBox1.LinkClicked += new LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            this.panel2.BackColor = Color.FromArgb(0x8f, 0x7b, 240);
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.ServerKonekcija);
            this.panel2.Controls.Add(this.OpcijaZvuk);
            this.panel2.Controls.Add(this.trackBar2);
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Controls.Add(this.SpustiProgram);
            this.panel2.Controls.Add(this.UgasiProgram);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Cursor = Cursors.NoMove2D;
            this.panel2.Dock = DockStyle.Fill;
            this.panel2.Location = new Point(1, 1);
            this.panel2.Margin = new Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x256, 20);
            this.panel2.TabIndex = 3;
            this.panel2.MouseDown += new MouseEventHandler(this.panel2_MouseDown);
            this.OpcijaZvuk.BackColor = Color.FromArgb(0x8f, 0x7b, 240);
            this.OpcijaZvuk.BackgroundImage = Resources.sound;
            this.OpcijaZvuk.BackgroundImageLayout = ImageLayout.Stretch;
            this.OpcijaZvuk.Cursor = Cursors.Hand;
            this.OpcijaZvuk.Dock = DockStyle.Right;
            this.OpcijaZvuk.FlatAppearance.BorderColor = Color.FromArgb(0x8f, 0x7b, 240);
            this.OpcijaZvuk.FlatAppearance.MouseDownBackColor = Color.FromArgb(0x8f, 0x7b, 240);
            this.OpcijaZvuk.FlatAppearance.MouseOverBackColor = Color.FromArgb(0x8f, 0x7b, 240);
            this.OpcijaZvuk.FlatStyle = FlatStyle.Flat;
            this.OpcijaZvuk.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.OpcijaZvuk.ForeColor = Color.White;
            this.OpcijaZvuk.Location = new Point(520, 0);
            this.OpcijaZvuk.Name = "OpcijaZvuk";
            this.OpcijaZvuk.Size = new Size(20, 20);
            this.OpcijaZvuk.TabIndex = 5;
            this.OpcijaZvuk.UseVisualStyleBackColor = false;
            this.OpcijaZvuk.Click += new EventHandler(this.OpcijaZvuk_Click);
            this.trackBar2.AutoSize = false;
            this.trackBar2.Cursor = Cursors.VSplit;
            this.trackBar2.Location = new Point(0x101, -1);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new Size(0x60, 0x19);
            this.trackBar2.TabIndex = 4;
            this.trackBar2.TickStyle = TickStyle.None;
            this.trackBar2.Scroll += new EventHandler(this.trackBar2_Scroll);
            this.trackBar1.AutoSize = false;
            this.trackBar1.Cursor = Cursors.VSplit;
            this.trackBar1.Location = new Point(0x9b, 0);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new Size(0x60, 0x19);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.TickStyle = TickStyle.None;
            this.trackBar1.Scroll += new EventHandler(this.trackBar1_Scroll);
            this.SpustiProgram.BackColor = Color.DimGray;
            this.SpustiProgram.Cursor = Cursors.Hand;
            this.SpustiProgram.Dock = DockStyle.Right;
            this.SpustiProgram.FlatAppearance.BorderColor = Color.DimGray;
            this.SpustiProgram.FlatAppearance.MouseDownBackColor = Color.DimGray;
            this.SpustiProgram.FlatAppearance.MouseOverBackColor = Color.DimGray;
            this.SpustiProgram.FlatStyle = FlatStyle.Flat;
            this.SpustiProgram.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.SpustiProgram.ForeColor = Color.White;
            this.SpustiProgram.Location = new Point(540, 0);
            this.SpustiProgram.Name = "SpustiProgram";
            this.SpustiProgram.Size = new Size(0x1d, 20);
            this.SpustiProgram.TabIndex = 2;
            this.SpustiProgram.Text = "-";
            this.SpustiProgram.UseVisualStyleBackColor = false;
            this.SpustiProgram.Click += new EventHandler(this.SpustiProgram_Click);
            this.UgasiProgram.BackColor = Color.Black;
            this.UgasiProgram.Cursor = Cursors.Hand;
            this.UgasiProgram.Dock = DockStyle.Right;
            this.UgasiProgram.FlatAppearance.BorderColor = Color.Black;
            this.UgasiProgram.FlatAppearance.MouseDownBackColor = Color.Black;
            this.UgasiProgram.FlatAppearance.MouseOverBackColor = Color.Black;
            this.UgasiProgram.FlatStyle = FlatStyle.Flat;
            this.UgasiProgram.ForeColor = Color.White;
            this.UgasiProgram.Location = new Point(0x239, 0);
            this.UgasiProgram.Name = "UgasiProgram";
            this.UgasiProgram.Size = new Size(0x1d, 20);
            this.UgasiProgram.TabIndex = 1;
            this.UgasiProgram.Text = "X";
            this.UgasiProgram.UseVisualStyleBackColor = false;
            this.UgasiProgram.Click += new EventHandler(this.UgasiProgram_Click);
            this.label1.AutoSize = true;
            this.label1.ForeColor = Color.White;
            this.label1.Location = new Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pričaonica";
            this.label1.MouseDown += new MouseEventHandler(this.label1_MouseDown);
            this.timer1.Interval = 500;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.PocetnoUcitavanje.Interval = 0x5dc;
            this.PocetnoUcitavanje.Tick += new EventHandler(this.PocetnoUcitavanje_Tick);
            this.ServerKonekcija.BackColor = Color.LightGray;
            this.ServerKonekcija.BackgroundImageLayout = ImageLayout.Stretch;
            this.ServerKonekcija.Cursor = Cursors.Hand;
            this.ServerKonekcija.Dock = DockStyle.Right;
            this.ServerKonekcija.FlatAppearance.BorderColor = Color.FromArgb(0x8f, 0x7b, 240);
            this.ServerKonekcija.FlatAppearance.MouseDownBackColor = Color.FromArgb(0x8f, 0x7b, 240);
            this.ServerKonekcija.FlatAppearance.MouseOverBackColor = Color.FromArgb(0x8f, 0x7b, 240);
            this.ServerKonekcija.FlatStyle = FlatStyle.Flat;
            this.ServerKonekcija.Font = new Font("Corbel", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.ServerKonekcija.ForeColor = Color.White;
            this.ServerKonekcija.Location = new Point(0x1c1, 0);
            this.ServerKonekcija.Margin = new Padding(0);
            this.ServerKonekcija.Name = "ServerKonekcija";
            this.ServerKonekcija.Size = new Size(0x47, 20);
            this.ServerKonekcija.TabIndex = 6;
            this.ServerKonekcija.Text = "SERVER:??";
            this.ServerKonekcija.UseVisualStyleBackColor = false;
            this.ServerKonekcija.Click += new EventHandler(this.ServerKonekcija_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(600, 600);
            base.Controls.Add(this.tableLayoutPanel1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "Chat1";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Pričaonica";
            base.Shown += new EventHandler(this.Chat1_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.trackBar2.EndInit();
            this.trackBar1.EndInit();
            base.ResumeLayout(false);
        }

        private void InitializeConnection()
        {
            try
            {
                this.ipAddr = IPAddress.Parse(this.GlavnaIPadresa);
                this.tcpServer = new TcpClient();
                this.tcpServer.Connect(this.ipAddr, 0x7c2);
                this.Connected = true;
                this.UserName = this.GlavnoIme;
                this.swSender = new StreamWriter(this.tcpServer.GetStream());
                this.swSender.WriteLine(this.GlavnoIme);
                this.swSender.Flush();
                this.thrMessaging = new Thread(new ThreadStart(this.ReceiveMessages));
                this.thrMessaging.Start();
                this.textBox1.Visible = true;
                this.PosaljiPoruku.Visible = true;
                this.ServerKonekcija.Text = "SERVER:ON";
                this.ServerKonekcija.BackColor = Color.Green;
            }
            catch
            {
                this.ServerKonekcija.Text = "SERVER:OFF";
                this.ServerKonekcija.BackColor = Color.Red;
                MessageBox.Show("Server je trenutno iskljucen", "INFO");
                base.Close();
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm(base.Handle);
            }
        }

        public static void MoveForm(IntPtr Handle)
        {
            ReleaseCapture();
            int num = SendMessage(Handle, 0xa1, 2, 0);
        }

        private void OpcijaZvuk_Click(object sender, EventArgs e)
        {
            if (this.potvrdaZvuk == 0)
            {
                this.potvrdaZvuk = 1;
                this.OpcijaZvuk.BackgroundImage = Resources.speaker;
            }
            else
            {
                this.potvrdaZvuk = 0;
                this.OpcijaZvuk.BackgroundImage = Resources.sound;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm(base.Handle);
            }
        }

        private void PocetnoUcitavanje_Tick(object sender, EventArgs e)
        {
            this.PocetnoUcitavanje.Stop();
            this.PocetnoUcitavanje.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string str = new WebClient().DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/GetUsersInfoById.php?Id=" + this.PersonalID);
                this.GlavnoIme = str = str.Replace("\r\n", "");
                if (!this.Connected)
                {
                    this.InitializeConnection();
                }
                else
                {
                    this.CloseConnection("Korisnik je zatvorio pričaonicu.");
                }
            }
            catch
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Dogodila se greška, pokušajte kasnije ili restartujte program", "INFO");
                base.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        private void PosaljiPoruku_Click(object sender, EventArgs e)
        {
            this.SendMessage();
        }

        private void ReceiveMessages()
        {
            try
            {
                this.srReceiver = new StreamReader(this.tcpServer.GetStream());
                string str = this.srReceiver.ReadLine();
                if (str[0] == '1')
                {
                    base.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { "Uspešna konekcija sa serverom!" });
                }
                else
                {
                    string str2 = "Greška u konekciji: ";
                    str2 = str2 + str.Substring(2, str.Length - 2);
                    this.Connected = false;
                }
                while (this.Connected)
                {
                    try
                    {
                        base.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { this.srReceiver.ReadLine() });
                    }
                    catch
                    {
                        this.Connected = false;
                    }
                }
            }
            catch
            {
                try
                {
                }
                catch
                {
                }
            }
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
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

        private void SendMessage()
        {
            try
            {
                if ((this.textBox1.Text != "") && (this.textBox1.Text.Length > 0))
                {
                    string str = this.textBox1.Text.Replace("\r\n", "");
                    this.swSender.WriteLine(str);
                    this.swSender.Flush();
                }
                this.textBox1.Text = this.textBox1.Text.Replace("\r\n", "");
                this.textBox1.Text = "";
                this.richTextBox1.ScrollToCaret();
                this.textBox1.Focus();
            }
            catch
            {
                this.richTextBox1.AppendText("\r\nGREŠKA U SLANJU PORUKE\r\n\r\n");
                MessageBox.Show("Dogodila se greška.\nŠta je potrebno uraditi.\nProverite da li vam internet radi.\nUgasite program pa ga ponovo upalite.\nAko i dalje neće onda pokušajte kasnije.", "INFO");
                this.CloseConnection("nema servera");
                base.Close();
            }
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private void ServerKonekcija_Click(object sender, EventArgs e)
        {
            try
            {
                this.CloseConnection("");
                this.ServerKonekcija.Text = "SERVER:OFF";
                this.ServerKonekcija.BackColor = Color.Red;
            }
            catch
            {
            }
            try
            {
                this.ipAddr = IPAddress.Parse(this.GlavnaIPadresa);
                this.tcpServer = new TcpClient();
                this.tcpServer.Connect(this.ipAddr, 0x7c2);
                this.Connected = true;
                this.UserName = this.GlavnoIme;
                this.swSender = new StreamWriter(this.tcpServer.GetStream());
                this.swSender.WriteLine(this.GlavnoIme);
                this.swSender.Flush();
                this.thrMessaging = new Thread(new ThreadStart(this.ReceiveMessages));
                this.thrMessaging.Start();
                this.ServerKonekcija.Text = "SERVER:ON";
                this.ServerKonekcija.BackColor = Color.Green;
            }
            catch
            {
            }
        }

        private void SpustiProgram_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Minimized;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (this.textBox1.Text != "\r\n")
                {
                    this.SendMessage();
                }
                else
                {
                    this.textBox1.Text = this.textBox1.Text.Replace("\r\n", "");
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.timer1.Enabled = false;
            base.Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            base.Size = new Size(600 + (this.trackBar1.Value * 0x19), base.Size.Height);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            base.Size = new Size(base.Size.Width, 600 + (this.trackBar2.Value * 0x19));
        }

        private void UgasiProgram_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ugasi Pričaonicu?", "POTVRDA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.UgasiProgram.Visible = false;
                if (this.Connected)
                {
                    this.Connected = false;
                    this.swSender.Close();
                    this.srReceiver.Close();
                    this.tcpServer.Close();
                    this.thrMessaging.Abort();
                }
                this.timer1.Enabled = true;
                this.timer1.Start();
            }
        }

        private void UpdateLog(string strMessage)
        {
            try
            {
                string str;
                byte[] bytes;
                string str2;
                int textLength;
                int num2;
                if (strMessage.StartsWith("XXXAD1"))
                {
                    str = strMessage.Replace("XXXAD1", "").Replace("*", "");
                    bytes = Encoding.Default.GetBytes(str);
                    str = Encoding.UTF8.GetString(bytes);
                    str2 = "Korisnik " + str + " se konektovao.\r\n\r\n";
                    textLength = this.richTextBox1.TextLength;
                    this.richTextBox1.AppendText(str2);
                    this.richTextBox1.SelectionStart = textLength;
                    this.richTextBox1.SelectionLength = str2.Length;
                    this.richTextBox1.SelectionColor = Color.Green;
                    if (base.WindowState == FormWindowState.Minimized)
                    {
                        FlashWindowEx(this);
                    }
                }
                if (strMessage.StartsWith("XXXRU1"))
                {
                    str = strMessage.Replace("XXXRU1", "").Replace("*", "");
                    bytes = Encoding.Default.GetBytes(str);
                    str = Encoding.UTF8.GetString(bytes);
                    str2 = "Korisnik " + str + " je otišao.\r\n\r\n";
                    textLength = this.richTextBox1.TextLength;
                    this.richTextBox1.AppendText(str2);
                    this.richTextBox1.SelectionStart = textLength;
                    this.richTextBox1.SelectionLength = str2.Length;
                    this.richTextBox1.SelectionColor = Color.Red;
                }
                if (strMessage.StartsWith("XXXSM1"))
                {
                    str = strMessage.Replace("XXXSM1", "");
                    num2 = str.IndexOf("]") + 1;
                    string text = str.Substring(0, num2);
                    textLength = this.richTextBox1.TextLength;
                    this.richTextBox1.AppendText(text);
                    this.richTextBox1.SelectionStart = textLength;
                    this.richTextBox1.SelectionLength = text.Length;
                    this.richTextBox1.SelectionColor = Color.FromArgb(0x8f, 0x7b, 240);
                    string s = str.Substring(num2, str.Length - num2);
                    str = str.Substring(num2, str.Length - num2);
                    bytes = Encoding.Default.GetBytes(s);
                    s = Encoding.UTF8.GetString(bytes);
                    string str5 = s.Substring(0, s.IndexOf(":") - 1) + "\r\n";
                    int num3 = this.richTextBox1.TextLength;
                    this.richTextBox1.AppendText(str5);
                    this.richTextBox1.SelectionStart = num3;
                    this.richTextBox1.SelectionLength = str5.Length;
                    this.richTextBox1.SelectionColor = Color.Blue;
                    string str6 = str.Substring(str.IndexOf(":") + 1, (str.Length - str.IndexOf(":")) - 1) + "\r\n\r\n";
                    int num4 = this.richTextBox1.TextLength;
                    this.richTextBox1.AppendText(str6);
                    this.richTextBox1.SelectionStart = num4;
                    this.richTextBox1.SelectionLength = str6.Length;
                    this.richTextBox1.SelectionColor = Color.Black;
                    if (base.WindowState == FormWindowState.Minimized)
                    {
                        FlashWindowEx(this);
                    }
                    try
                    {
                        if (this.potvrdaZvuk == 0)
                        {
                            new SoundPlayer(Resources.ChatZvukPoruka).Play();
                        }
                    }
                    catch
                    {
                    }
                }
                if (strMessage.StartsWith("XXXSK1"))
                {
                    str = strMessage.Replace("XXXSK1", "");
                    this.flowLayoutPanel1.Controls.Clear();
                    string[] strArray = str.Split(new char[] { '#' });
                    foreach (string str7 in strArray)
                    {
                        if (str7 != "")
                        {
                            num2 = str7.IndexOf("]") + 1;
                            string str8 = str7.Substring(num2, str7.Length - num2).Replace("*", "");
                            bytes = Encoding.Default.GetBytes(str8);
                            str8 = Encoding.UTF8.GetString(bytes);
                            Button button = new Button {
                                Margin = this.button1.Margin,
                                Size = this.button1.Size,
                                BackColor = this.button1.BackColor,
                                FlatStyle = this.button1.FlatStyle,
                                TextAlign = this.button1.TextAlign
                            };
                            button.FlatAppearance.BorderColor = this.button1.FlatAppearance.BorderColor;
                            button.FlatAppearance.BorderSize = this.button1.FlatAppearance.BorderSize;
                            button.FlatAppearance.CheckedBackColor = this.button1.FlatAppearance.CheckedBackColor;
                            button.FlatAppearance.MouseDownBackColor = this.button1.FlatAppearance.MouseDownBackColor;
                            button.FlatAppearance.MouseOverBackColor = this.button1.FlatAppearance.MouseOverBackColor;
                            button.Text = str8;
                            this.flowLayoutPanel1.Controls.Add(button);
                        }
                    }
                }
                if (strMessage.StartsWith("XXXERROR" + this.GlavnoIme))
                {
                    this.CloseConnection("ERROR");
                    this.timer1.Enabled = true;
                    this.timer1.Start();
                }
                this.richTextBox1.ScrollToCaret();
            }
            catch
            {
                this.richTextBox1.AppendText("\r\nGREŠKA U PRIJEMU PORUKE\r\n\r\n");
            }
        }

        private delegate void CloseConnectionCallback(string strReason);

        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public uint cbSize;
            public IntPtr hwnd;
            public uint dwFlags;
            public uint uCount;
            public uint dwTimeout;
        }

        private delegate void UpdateLogCallback(string strMessage);
    }
}

