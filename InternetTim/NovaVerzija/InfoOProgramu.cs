namespace InternetTim.NovaVerzija
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class InfoOProgramu : Form
    {
        private IContainer components = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        public string verzija = "";

        public InfoOProgramu()
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

        private void InfoOProgramu_Load(object sender, EventArgs e)
        {
            this.label5.Text = this.verzija;
        }

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.label6 = new Label();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.ForeColor = Color.White;
            this.label1.Location = new Point(13, 0x1b);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Program:";
            this.label2.AutoSize = true;
            this.label2.ForeColor = Color.White;
            this.label2.Location = new Point(13, 0x37);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Verzija:";
            this.label3.AutoSize = true;
            this.label3.ForeColor = Color.White;
            this.label3.Location = new Point(13, 0x54);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x23, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Autor:";
            this.label4.AutoSize = true;
            this.label4.ForeColor = Color.White;
            this.label4.Location = new Point(0x44, 0x1b);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x2a, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "SkyNet";
            this.label5.AutoSize = true;
            this.label5.ForeColor = Color.White;
            this.label5.Location = new Point(0x44, 0x37);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x5e, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = ".............................";
            this.label6.AutoSize = true;
            this.label6.ForeColor = Color.White;
            this.label6.Location = new Point(0x44, 0x54);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x54, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Nenad Gledović";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.DarkSlateGray;
            base.ClientSize = new Size(0xb5, 0x7d);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Name = "InfoOProgramu";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Info";
            base.Load += new EventHandler(this.InfoOProgramu_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

