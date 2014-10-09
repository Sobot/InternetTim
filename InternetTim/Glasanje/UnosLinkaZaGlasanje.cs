namespace InternetTim.Glasanje
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class UnosLinkaZaGlasanje : Form
    {
        private Button button1;
        private IContainer components = null;
        private string LINKZASLANJE = "";
        public string PersonalID = "000000";
        private TextBox textBox1;

        public UnosLinkaZaGlasanje()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((this.textBox1.Text.Contains("blic.rs") || this.textBox1.Text.Contains("b92.net")) || this.textBox1.Text.Contains("kurir-info.rs"))
            {
                this.LINKZASLANJE = this.textBox1.Text;
                GlasanjeNaKomentareExterna externa = new GlasanjeNaKomentareExterna();
                externa.FormClosed += new FormClosedEventHandler(this.idemo_FormClosed);
                externa.GLAVNILINK = this.LINKZASLANJE;
                externa.Show();
                base.Hide();
            }
            else
            {
                MessageBox.Show("Proverite da li ste dobro kopirali link vesti.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void idemo_FormClosed(object sender, FormClosedEventArgs e)
        {
            base.Close();
        }

        private void InitializeComponent()
        {
            this.textBox1 = new TextBox();
            this.button1 = new Button();
            base.SuspendLayout();
            this.textBox1.Dock = DockStyle.Top;
            this.textBox1.Location = new Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x32b, 20);
            this.textBox1.TabIndex = 0;
            this.button1.Cursor = Cursors.Hand;
            this.button1.Dock = DockStyle.Fill;
            this.button1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.button1.Location = new Point(0, 20);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x32b, 0x35);
            this.button1.TabIndex = 1;
            this.button1.Text = "POTVRDI";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x32b, 0x49);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.textBox1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Name = "UnosLinkaZaGlasanje";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Kopiraj link vesti";
            base.TopMost = true;
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

