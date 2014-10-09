namespace InternetTim.Startovanje
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class SlikeUcitavanje : Form
    {
        private Button button1;
        private IContainer components = null;
        private ProgressBar progressBar1;

        public SlikeUcitavanje()
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
            this.progressBar1 = new ProgressBar();
            this.button1 = new Button();
            base.SuspendLayout();
            this.progressBar1.BackColor = Color.White;
            this.progressBar1.Dock = DockStyle.Right;
            this.progressBar1.Location = new Point(0, 0x17);
            this.progressBar1.Maximum = 9;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new Size(500, 0x11);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 0;
            this.button1.BackColor = Color.White;
            this.button1.Dock = DockStyle.Top;
            this.button1.FlatAppearance.BorderColor = Color.DimGray;
            this.button1.FlatAppearance.MouseDownBackColor = Color.White;
            this.button1.FlatAppearance.MouseOverBackColor = Color.White;
            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.Location = new Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new Size(500, 0x17);
            this.button1.TabIndex = 1;
            this.button1.Text = "Učitavanje podataka.Malo strpljenja.";
            this.button1.UseVisualStyleBackColor = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(500, 40);
            base.Controls.Add(this.progressBar1);
            base.Controls.Add(this.button1);
            this.Cursor = Cursors.WaitCursor;
            this.DoubleBuffered = true;
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "SlikeUcitavanje";
            base.ShowInTaskbar = false;
            base.SizeGripStyle = SizeGripStyle.Hide;
            base.StartPosition = FormStartPosition.Manual;
            base.TopMost = true;
            base.TransparencyKey = SystemColors.Control;
            base.TextChanged += new EventHandler(this.SlikeUcitavanje_TextChanged);
            base.ResumeLayout(false);
        }

        private void SlikeUcitavanje_TextChanged(object sender, EventArgs e)
        {
            if (this.Text == "20")
            {
                base.Close();
            }
            else
            {
                this.progressBar1.PerformStep();
            }
            if (this.Text == "R")
            {
                this.progressBar1.Value = 0;
                this.button1.Text = "Učitavanje i dalje traje,bez nervoze.";
            }
        }
    }
}

