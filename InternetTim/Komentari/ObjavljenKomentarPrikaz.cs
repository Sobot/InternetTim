namespace InternetTim.Komentari
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ObjavljenKomentarPrikaz : Form
    {
        public string Bodovi = "";
        private IContainer components = null;
        public string tekst = "";
        private TextBox textBox1;
        private Timer timer1;

        public ObjavljenKomentarPrikaz()
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
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(ObjavljenKomentarPrikaz));
            this.textBox1 = new TextBox();
            this.timer1 = new Timer(this.components);
            base.SuspendLayout();
            this.textBox1.Dock = DockStyle.Fill;
            this.textBox1.Location = new Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = ScrollBars.Vertical;
            this.textBox1.Size = new Size(0x2b6, 0x1a5);
            this.textBox1.TabIndex = 0;
            this.timer1.Enabled = true;
            this.timer1.Interval = 0x11170;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x2b6, 0x1a5);
            base.Controls.Add(this.textBox1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "ObjavljenKomentarPrikaz";
            this.Text = "Objavljen komentar";
            base.Shown += new EventHandler(this.ObjavljenKomentarPrikaz_Shown);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void ObjavljenKomentarPrikaz_Shown(object sender, EventArgs e)
        {
            this.textBox1.Text = this.tekst;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}

