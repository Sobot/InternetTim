namespace InternetTim.Komentari
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;

    public class GramatickeGreske : Form
    {
        private IContainer components = null;
        private string[] ID = new string[0x1388];
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label7;
        private ListBox listBox1;
        private Button OBRISI;
        private Button SNIMI;
        private TextBox textBox1;
        private TextBox textBox2;

        public GramatickeGreske()
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

        private void GramatickeGreske_Shown(object sender, EventArgs e)
        {
            this.Ucitavanje();
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(GramatickeGreske));
            this.listBox1 = new ListBox();
            this.label1 = new Label();
            this.OBRISI = new Button();
            this.label2 = new Label();
            this.textBox1 = new TextBox();
            this.textBox2 = new TextBox();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label7 = new Label();
            this.SNIMI = new Button();
            base.SuspendLayout();
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new Point(13, 0x20);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new Size(0x13e, 0x20c);
            this.listBox1.TabIndex = 0;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Baza reči";
            this.OBRISI.Cursor = Cursors.Hand;
            this.OBRISI.Location = new Point(12, 560);
            this.OBRISI.Name = "OBRISI";
            this.OBRISI.Size = new Size(0x13e, 0x17);
            this.OBRISI.TabIndex = 2;
            this.OBRISI.Text = "Obriši reč iz baze";
            this.OBRISI.UseVisualStyleBackColor = true;
            this.OBRISI.Click += new EventHandler(this.OBRISI_Click);
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Microsoft Sans Serif", 21.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(0x1c3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x106, 0x21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Gramatičke greške";
            this.textBox1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.textBox1.Location = new Point(0x1c9, 0xb1);
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x110, 0x1a);
            this.textBox1.TabIndex = 4;
            this.textBox2.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.textBox2.Location = new Point(0x1c9, 250);
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(0x110, 0x1a);
            this.textBox2.TabIndex = 5;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x1c9, 0x9e);
            this.label3.Name = "label3";
            this.label3.Size = new Size(150, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Greška - upišite nepravilnu reč";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x1c9, 0xea);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x9c, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Prepravka - upišite pravilni oblik";
            this.label7.AutoSize = true;
            this.label7.Location = new Point(0x165, 0x3f);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x1c5, 0x34);
            this.label7.TabIndex = 10;
            this.label7.Text = manager.GetString("label7.Text");
            this.SNIMI.Cursor = Cursors.Hand;
            this.SNIMI.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.SNIMI.Location = new Point(0x1c9, 0x133);
            this.SNIMI.Name = "SNIMI";
            this.SNIMI.Size = new Size(0x110, 0x66);
            this.SNIMI.TabIndex = 11;
            this.SNIMI.Text = "SNIMI U BAZU";
            this.SNIMI.UseVisualStyleBackColor = true;
            this.SNIMI.Click += new EventHandler(this.SNIMI_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(0x354, 0x24f);
            base.Controls.Add(this.SNIMI);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.textBox2);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.OBRISI);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.listBox1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "GramatickeGreske";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Gramatičke greške";
            base.Shown += new EventHandler(this.GramatickeGreske_Shown);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void OBRISI_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex != -1)
            {
                WebClient client = new WebClient();
                string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/GramatickeGreske/DeleteErrorById.php?";
                address = address + "Id=" + this.ID[this.listBox1.SelectedIndex];
                if (client.DownloadString(address).Contains("OKET"))
                {
                    MessageBox.Show("Uspešno brisanje", "INFO");
                    this.textBox1.Text = "";
                    this.textBox2.Text = "";
                    this.Ucitavanje();
                }
            }
            else
            {
                MessageBox.Show("Prvo izaberite u listi", "INFO");
            }
        }

        private void SNIMI_Click(object sender, EventArgs e)
        {
            if ((this.textBox1.Text.Length > 2) && (this.textBox2.Text.Length > 2))
            {
                WebClient client = new WebClient();
                string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/GramatickeGreske/InsertNewError.php?";
                address = (address + "Bad=" + this.textBox1.Text) + "&Good=" + this.textBox2.Text;
                if (client.DownloadString(address).Contains("OKET"))
                {
                    MessageBox.Show("Uspešno snimanje", "INFO");
                    this.textBox1.Text = "";
                    this.textBox2.Text = "";
                    this.Ucitavanje();
                }
            }
            else
            {
                MessageBox.Show("Proverite da li ste dobro napisali podatke", "INFO");
            }
        }

        private void Ucitavanje()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.listBox1.Items.Clear();
            Array.Clear(this.ID, 0, 0x1388);
            try
            {
                WebClient client = new WebClient();
                JsonTextReader reader = new JsonTextReader(new StringReader(client.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/GramatickeGreske/GetAllErrors.php")));
                int num = 0;
                int index = 0;
                string item = "";
                while (reader.Read())
                {
                    if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                    {
                        switch (num)
                        {
                            case 0:
                                this.ID[index] = reader.Value.ToString();
                                index++;
                                break;

                            case 1:
                                item = reader.Value.ToString();
                                break;

                            case 2:
                                item = item + " > treba > " + reader.Value.ToString();
                                this.listBox1.Items.Add(item);
                                break;
                        }
                        num++;
                        if (num == 3)
                        {
                            num = 0;
                        }
                    }
                }
            }
            catch
            {
            }
            Cursor.Current = Cursors.Default;
        }
    }
}

