namespace InternetTim.Komentari
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Net;
    using System.Windows.Forms;

    public class MojaSugestija : Form
    {
        private Button button1;
        private IContainer components = null;
        public string IdVesti = "";
        private Panel panel1;
        public string PersonalIDS = "";
        private RichTextBox richTextBox1;

        public MojaSugestija()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WebClient client = new WebClient();
                string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/InsertNewSugestForNews.php?";
                address = ((address + "Id=" + this.PersonalIDS) + "&IdV=" + this.IdVesti) + "&Tekst=" + this.richTextBox1.Text.Replace("&", "[[]]");
                string str2 = client.DownloadString(address);
            }
            catch
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Dogodila se neka greška, pokušajte ponovo ili restartujte program.", "INFO");
            }
            Cursor.Current = Cursors.Default;
            base.Close();
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
            this.panel1 = new Panel();
            this.richTextBox1 = new RichTextBox();
            this.button1 = new Button();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.panel1.BackColor = Color.White;
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new Point(13, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x277, 0x11c);
            this.panel1.TabIndex = 0;
            this.richTextBox1.BorderStyle = BorderStyle.None;
            this.richTextBox1.Dock = DockStyle.Fill;
            this.richTextBox1.Location = new Point(0, 0);
            this.richTextBox1.MaxLength = 900;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new Size(0x277, 240);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.button1.Cursor = Cursors.Hand;
            this.button1.Dock = DockStyle.Bottom;
            this.button1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.button1.Location = new Point(0, 240);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x277, 0x2c);
            this.button1.TabIndex = 0;
            this.button1.Text = "POTVRDI";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Coral;
            base.ClientSize = new Size(0x290, 0x134);
            base.Controls.Add(this.panel1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Name = "MojaSugestija";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Napiši komentar";
            base.TopMost = true;
            this.panel1.ResumeLayout(false);
            base.ResumeLayout(false);
        }
    }
}

