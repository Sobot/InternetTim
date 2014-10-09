namespace InternetTim.Obavestenja
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;

    public class SlanjeObavestenja : Form
    {
        private Button button1;
        private ColorDialog colorDialog1;
        private ComboBox comboBox1;
        private IContainer components = null;
        public string ID = "";
        private Label label1;
        private Label label2;
        private Label label3;
        private ListBox listBox1;
        private Button PromeniBold;
        private Button PromeniColor;
        private RichTextBox richTextBox1;
        private TextBox textBox1;

        public SlanjeObavestenja()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int num = 0;
                if (this.textBox1.Text.Length < 3)
                {
                    MessageBox.Show("Upišite naslov", "INFO");
                    num++;
                }
                if (this.richTextBox1.Text.Length < 3)
                {
                    MessageBox.Show("Upišite tekst", "INFO");
                    num++;
                }
                if (this.listBox1.SelectedItems.Count < 1)
                {
                    MessageBox.Show("Izaberite na listi levo na koje opštine treba obaveštenje da se pošalje", "INFO");
                    num++;
                }
                if (num == 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    WebClient client = new WebClient();
                    string str = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Obavestenja/InsertNewMessage.php?";
                    str = ((str + "Id=" + this.ID) + "&Naslov=" + this.textBox1.Text.Replace("&", "[[]]")) + "&Tekst=" + this.richTextBox1.Rtf.Replace("&", "[[]]");
                    foreach (string str2 in this.listBox1.SelectedItems)
                    {
                        if (str2 == " Sve opštine")
                        {
                            client.DownloadString(str + "&Opstina=SSS");
                        }
                        else
                        {
                            client.DownloadString(str + "&Opstina=" + str2);
                        }
                    }
                    this.textBox1.Text = "";
                    this.richTextBox1.Rtf = "";
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Poruka je poslata", "INFO");
                }
            }
            catch
            {
                MessageBox.Show("Greška u slanju, pokušajte opet kasnije", "INFO");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", (float) int.Parse(this.comboBox1.SelectedItem.ToString()));
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(SlanjeObavestenja));
            this.textBox1 = new TextBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.button1 = new Button();
            this.listBox1 = new ListBox();
            this.label3 = new Label();
            this.richTextBox1 = new RichTextBox();
            this.PromeniBold = new Button();
            this.colorDialog1 = new ColorDialog();
            this.PromeniColor = new Button();
            this.comboBox1 = new ComboBox();
            base.SuspendLayout();
            this.textBox1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.textBox1.ForeColor = Color.Red;
            this.textBox1.Location = new Point(260, 0x19);
            this.textBox1.MaxLength = 180;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x312, 0x43);
            this.textBox1.TabIndex = 0;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(260, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Naslov obaveštenja";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(260, 0x79);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x5f, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tekst obaveštenja";
            this.button1.Cursor = Cursors.Hand;
            this.button1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.button1.Location = new Point(260, 600);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x312, 0x42);
            this.button1.TabIndex = 4;
            this.button1.Text = "POŠALJI OBAVEŠTENJE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new Point(12, 0x19);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = SelectionMode.MultiSimple;
            this.listBox1.Size = new Size(0xf2, 0x281);
            this.listBox1.Sorted = true;
            this.listBox1.TabIndex = 5;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(10, 9);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x4b, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Izaberi opštine";
            this.richTextBox1.Location = new Point(260, 0x89);
            this.richTextBox1.MaxLength = 0x4b0;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new Size(0x312, 0x1c9);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            this.PromeniBold.Cursor = Cursors.Hand;
            this.PromeniBold.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.PromeniBold.Location = new Point(0x17a, 0x6c);
            this.PromeniBold.Name = "PromeniBold";
            this.PromeniBold.Size = new Size(0x4b, 0x17);
            this.PromeniBold.TabIndex = 8;
            this.PromeniBold.Text = "Bold";
            this.PromeniBold.UseVisualStyleBackColor = true;
            this.PromeniBold.Click += new EventHandler(this.PromeniBold_Click);
            this.colorDialog1.AllowFullOpen = false;
            this.colorDialog1.SolidColorOnly = true;
            this.PromeniColor.Cursor = Cursors.Hand;
            this.PromeniColor.ForeColor = Color.Red;
            this.PromeniColor.Location = new Point(460, 0x6c);
            this.PromeniColor.Name = "PromeniColor";
            this.PromeniColor.Size = new Size(0x4b, 0x17);
            this.PromeniColor.TabIndex = 9;
            this.PromeniColor.Text = "Color";
            this.PromeniColor.UseVisualStyleBackColor = true;
            this.PromeniColor.Click += new EventHandler(this.PromeniColor_Click);
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] { "8", "10", "12", "14", "16", "18", "20", "22" });
            this.comboBox1.Location = new Point(0x21d, 0x6c);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(0x35, 0x17);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(0x420, 0x2a3);
            base.Controls.Add(this.comboBox1);
            base.Controls.Add(this.PromeniColor);
            base.Controls.Add(this.PromeniBold);
            base.Controls.Add(this.richTextBox1);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.listBox1);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.textBox1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "SlanjeObavestenja";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Slanje obaveštenja";
            base.Load += new EventHandler(this.SlanjeObavestenja_Load);
            base.Shown += new EventHandler(this.SlanjeObavestenja_Shown);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void PromeniBold_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", this.richTextBox1.SelectionFont.Size, FontStyle.Bold);
        }

        private void PromeniColor_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.richTextBox1.SelectionColor = this.colorDialog1.Color;
            }
        }

        private void SlanjeObavestenja_Load(object sender, EventArgs e)
        {
        }

        private void SlanjeObavestenja_Shown(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                WebClient client = new WebClient();
                JsonTextReader reader = new JsonTextReader(new StringReader(client.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Obavestenja/GetRegionsForUser.php?Id=" + this.ID)));
                int num = 0;
                while (reader.Read())
                {
                    if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                    {
                        if (num == 0)
                        {
                            this.listBox1.Items.Add(reader.Value.ToString());
                        }
                        num++;
                        if (num == 1)
                        {
                            num = 0;
                        }
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch
            {
            }
        }
    }
}

