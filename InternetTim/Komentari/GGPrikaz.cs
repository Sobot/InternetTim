namespace InternetTim.Komentari
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class GGPrikaz : Form
    {
        private IContainer components = null;
        public string tekst = "";
        private TextBox textBox1;

        public GGPrikaz()
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

        private void GGPrikaz_Shown(object sender, EventArgs e)
        {
            this.textBox1.Text = this.tekst;
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(GGPrikaz));
            this.textBox1 = new TextBox();
            base.SuspendLayout();
            this.textBox1.Dock = DockStyle.Fill;
            this.textBox1.Location = new Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x30b, 560);
            this.textBox1.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x30b, 560);
            base.Controls.Add(this.textBox1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "GGPrikaz";
            this.Text = "Gramatička greška";
            base.TopMost = true;
            base.Shown += new EventHandler(this.GGPrikaz_Shown);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

