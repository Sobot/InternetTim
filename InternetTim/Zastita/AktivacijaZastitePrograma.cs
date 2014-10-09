namespace InternetTim.Zastita
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Net;
    using System.Windows.Forms;

    public class AktivacijaZastitePrograma : Form
    {
        private Button button1;
        private IContainer components = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        public string PersonalID = "000000";
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private TextBox textBox1;

        public AktivacijaZastitePrograma()
        {
            this.InitializeComponent();
        }

        private void AktivacijaZastitePrograma_Shown(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                WebClient client = new WebClient();
                string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Zastita/GetUsersInfoById.php?";
                address = address + "Id=" + this.PersonalID;
                if (client.DownloadString(address).StartsWith("DA"))
                {
                    this.radioButton1.Checked = true;
                }
            }
            catch
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Dogodila se greška sa serverom, program će se sad ugasiti.\nPokušajte kasnije.", "INFO");
                base.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient client;
            string str;
            Cursor.Current = Cursors.WaitCursor;
            if (this.radioButton1.Checked)
            {
                if (((this.textBox1.Text.Length > 3) && !this.textBox1.Text.Contains("#")) && !this.textBox1.Text.Contains("&"))
                {
                    try
                    {
                        client = new WebClient();
                        str = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Zastita/UpdateUserPass.php?";
                        str = (str + "Id=" + this.PersonalID) + "&Pass=DA" + this.textBox1.Text;
                        if (client.DownloadString(str).StartsWith("OKET"))
                        {
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show("Uspešno snimanje.", "INFO");
                            base.Close();
                        }
                    }
                    catch
                    {
                    }
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Pokušajte drugu šifru", "INFO");
                }
            }
            else
            {
                try
                {
                    client = new WebClient();
                    str = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Zastita/UpdateUserPass.php?";
                    str = (str + "Id=" + this.PersonalID) + "&Pass=NE";
                    if (client.DownloadString(str).StartsWith("OKET"))
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Uspešno snimanje.", "INFO");
                        base.Close();
                    }
                }
                catch
                {
                }
            }
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
            this.radioButton1 = new RadioButton();
            this.radioButton2 = new RadioButton();
            this.textBox1 = new TextBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.button1 = new Button();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.label6 = new Label();
            base.SuspendLayout();
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new Font("Microsoft Sans Serif", 48f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.radioButton1.Location = new Point(0x2c, 0x6c);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new Size(0x8d, 0x4d);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "DA";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Font = new Font("Microsoft Sans Serif", 48f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.radioButton2.Location = new Point(0x2c, 0xbf);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new Size(0x8d, 0x4d);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "NE";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.textBox1.Font = new Font("Microsoft Sans Serif", 27.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.textBox1.Location = new Point(0x158, 0xd6);
            this.textBox1.MaxLength = 0x29;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x174, 0x31);
            this.textBox1.TabIndex = 2;
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 27.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(0xad, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x18f, 0x2a);
            this.label1.TabIndex = 3;
            this.label1.Text = "ZAŠTITA PROGRAMA";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Microsoft Sans Serif", 27.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(430, 0xa9);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0xb5, 0x2a);
            this.label2.TabIndex = 4;
            this.label2.Text = "Upiši šifru";
            this.button1.Cursor = Cursors.Hand;
            this.button1.Dock = DockStyle.Bottom;
            this.button1.Font = new Font("Microsoft Sans Serif", 27.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.button1.Location = new Point(0, 0x176);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x2ea, 0x71);
            this.button1.TabIndex = 5;
            this.button1.Text = "POTVRDI";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x15a, 0x10a);
            this.label3.Name = "label3";
            this.label3.Size = new Size(370, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "*Ako želite naknadno da promenite šifru samo ukucajte drugu šifru i potvrdite.";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(12, 0x10a);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x135, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "*Da bi sklonili zaštitu programa potrebno je štiklirati NE i potvrditi.";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(12, 0x117);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0xdd, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "*Ako izaberete NE nije potrebno ukucati šifru.";
            this.label6.AutoSize = true;
            this.label6.Location = new Point(0x15a, 0x117);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0xe1, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "*Šifra mora biti duža od 3 slova a manja od 40.";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(0x2ea, 0x1e7);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.radioButton2);
            base.Controls.Add(this.radioButton1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Name = "AktivacijaZastitePrograma";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Zastita programa";
            base.Shown += new EventHandler(this.AktivacijaZastitePrograma_Shown);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

