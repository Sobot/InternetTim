namespace InternetTim.Komentari
{
    using GemBox.Spreadsheet;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public class BazaMojiKomentari : Form
    {
        private Button button1;
        private IContainer components = null;
        private int Kbroj = 0;
        private string[] Komentari = new string[0x4e20];
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;

        public BazaMojiKomentari()
        {
            this.InitializeComponent();
        }

        private void BazaMojiKomentari_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                int num2;
                int num3;
                string str2 = Path.GetPathRoot(Environment.SystemDirectory) + "InternetTim";
                ExcelFile file = new ExcelFile();
                file.LoadXls(str2 + @"\Vpic\MKB\obj.jpg");
                int count = file.Worksheets[0].Rows.Count;
                if (count != 0)
                {
                    for (num2 = 0; num2 < count; num2++)
                    {
                        this.Komentari[this.Kbroj] = file.Worksheets[0].Rows[num2].Cells[0].Value.ToString();
                        this.Kbroj++;
                    }
                    if (count > 0xfa0)
                    {
                        for (num3 = 0; num3 < 400; num3++)
                        {
                            file.Worksheets[0].Rows[0].Delete();
                        }
                        file.SaveXls(str2 + @"\Vpic\MKB\obj.jpg");
                    }
                }
                ExcelFile file2 = new ExcelFile();
                file2.LoadXls(str2 + @"\Vpic\MKB\pos.jpg");
                int num4 = file2.Worksheets[0].Rows.Count;
                if (num4 != 0)
                {
                    for (num2 = 0; num2 < num4; num2++)
                    {
                        this.Komentari[this.Kbroj] = file2.Worksheets[0].Rows[num2].Cells[0].Value.ToString();
                        this.Kbroj++;
                    }
                    if (num4 > 0xfa0)
                    {
                        for (num3 = 0; num3 < 400; num3++)
                        {
                            file2.Worksheets[0].Rows[0].Delete();
                        }
                        file2.SaveXls(str2 + @"\Vpic\MKB\pos.jpg");
                    }
                }
                if ((count == 0) && (num4 == 0))
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Nema komentara u bazi.", "INFO");
                    base.Close();
                }
            }
            catch
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Dogodila se neka greška, probajte ponovo ili restartujte program.", "INFO");
                base.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.textBox2.Text = "";
                string[] strArray = this.textBox1.Text.Split(new char[] { ' ' });
                foreach (string str in this.Komentari)
                {
                    if (str == null)
                    {
                        goto Label_00D6;
                    }
                    foreach (string str2 in strArray)
                    {
                        if (str.Contains(str2))
                        {
                            this.textBox2.Text = this.textBox2.Text + str + "\r\n\r\n";
                            break;
                        }
                    }
                }
            }
            catch
            {
            }
        Label_00D6:
            Cursor.Current = Cursors.Default;
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(BazaMojiKomentari));
            this.textBox1 = new TextBox();
            this.button1 = new Button();
            this.label1 = new Label();
            this.textBox2 = new TextBox();
            base.SuspendLayout();
            this.textBox1.Location = new Point(12, 0x1a);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x306, 20);
            this.textBox1.TabIndex = 0;
            this.button1.Cursor = Cursors.Hand;
            this.button1.Location = new Point(0x318, 12);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x85, 0x22);
            this.button1.TabIndex = 1;
            this.button1.Text = "Pronađi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.label1.AutoSize = true;
            this.label1.ForeColor = Color.White;
            this.label1.Location = new Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x249, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Upiši pojam ili nekoliko pojmova i potvrdi na \"Pronađi\". Zadnjih 4000 komentara koje si prijavio u programu se ovde nalaze.";
            this.textBox2.Location = new Point(12, 0x35);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = ScrollBars.Vertical;
            this.textBox2.Size = new Size(0x391, 0x233);
            this.textBox2.TabIndex = 3;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Maroon;
            base.ClientSize = new Size(0x3a9, 0x274);
            base.Controls.Add(this.textBox2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.textBox1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "BazaMojiKomentari";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Moji komentari";
            base.Shown += new EventHandler(this.BazaMojiKomentari_Shown);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

