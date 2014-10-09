namespace InternetTim.Obavestenja
{
    using GemBox.Spreadsheet;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class PrikazPorukaBaza : Form
    {
        private Button button1;
        private IContainer components = null;
        private ListBox listBox1;
        private string[] Naslovi = new string[500];
        public string putanja = "";
        private string[] Tekstovi = new string[500];

        public PrikazPorukaBaza()
        {
            this.InitializeComponent();
            SpreadsheetInfo.SetLicense("EQU1-4YRI-KEYA-HERE");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex != -1)
            {
                try
                {
                    new PrikaziObavestenje { Naslov = this.Naslovi[this.listBox1.SelectedIndex], Tekst = this.Tekstovi[this.listBox1.SelectedIndex] }.Show();
                }
                catch
                {
                }
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

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(PrikazPorukaBaza));
            this.listBox1 = new ListBox();
            this.button1 = new Button();
            base.SuspendLayout();
            this.listBox1.Dock = DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new Size(0x38a, 0x240);
            this.listBox1.TabIndex = 0;
            this.button1.Cursor = Cursors.Hand;
            this.button1.Dock = DockStyle.Bottom;
            this.button1.Location = new Point(0, 0x249);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x38a, 0x25);
            this.button1.TabIndex = 1;
            this.button1.Text = "PRIKAŽI PORUKU";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(0x38a, 0x26e);
            base.Controls.Add(this.listBox1);
            base.Controls.Add(this.button1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "PrikazPorukaBaza";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Poruke";
            base.Shown += new EventHandler(this.PrikazPorukaBaza_Shown);
            base.ResumeLayout(false);
        }

        private void PrikazPorukaBaza_Shown(object sender, EventArgs e)
        {
            try
            {
                ExcelFile file = new ExcelFile();
                file.LoadXls(this.putanja + @"\obav.jpg");
                int index = 0;
                for (int i = file.Worksheets[0].Rows.Count - 1; i >= 0; i--)
                {
                    this.Naslovi[index] = file.Worksheets[0].Rows[i].Cells[1].Value.ToString();
                    this.Tekstovi[index] = file.Worksheets[0].Rows[i].Cells[2].Value.ToString();
                    index++;
                }
                for (int j = 0; j < file.Worksheets[0].Rows.Count; j++)
                {
                    this.listBox1.Items.Add(this.Naslovi[j]);
                }
            }
            catch
            {
            }
        }
    }
}

