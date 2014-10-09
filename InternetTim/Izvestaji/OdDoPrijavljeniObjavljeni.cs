namespace InternetTim.Izvestaji
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;

    public class OdDoPrijavljeniObjavljeni : Form
    {
        private DataGridViewTextBoxColumn Bodovi;
        private Button button1;
        private IContainer components = null;
        private DataGridView dataGridView1;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private string[] Id = new string[0xbb8];
        private string[] Ime = new string[0xbb8];
        private DataGridViewTextBoxColumn ImeDV;
        private Label label1;
        private Label label2;
        private string[] Nivo = new string[0xbb8];
        private string NizDatum = "";
        private DataGridViewTextBoxColumn ObjavljenoKomentaraDV;
        private string[] Opstina = new string[0xbb8];
        private DataGridViewTextBoxColumn OpstinaDV;
        private Panel panel1;
        private DataGridViewTextBoxColumn PoslatoKomentaraDV;
        private string[] Prezime = new string[0xbb8];
        private DataGridViewTextBoxColumn PrezimeDV;
        private ProgressBar progressBar1;
        private int stanje = 0;
        private string[] SviDatumi = new string[500];

        public OdDoPrijavljeniObjavljeni()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (this.dateTimePicker1.Value >= this.dateTimePicker2.Value)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Izabrali ste veći početni datum od krajnjeg datuma.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                base.Size = new Size(base.Size.Width, 0x38);
                for (int i = 0; i < 350; i++)
                {
                    if (this.dateTimePicker1.Value > this.dateTimePicker2.Value)
                    {
                        break;
                    }
                    string str = this.dateTimePicker1.Value.Day.ToString();
                    if (str.Length == 1)
                    {
                        str = "0" + str;
                    }
                    string str2 = this.dateTimePicker1.Value.Month.ToString();
                    if (str2.Length == 1)
                    {
                        str2 = "0" + str2;
                    }
                    this.SviDatumi[i] = str + "." + str2 + "." + this.dateTimePicker1.Value.Year.ToString();
                    if (i == 0)
                    {
                        this.NizDatum = str + "." + str2 + "." + this.dateTimePicker1.Value.Year.ToString();
                    }
                    else
                    {
                        string nizDatum = this.NizDatum;
                        this.NizDatum = nizDatum + "*" + str + "." + str2 + "." + this.dateTimePicker1.Value.Year.ToString();
                    }
                    this.dateTimePicker1.Value = this.dateTimePicker1.Value.Date.AddDays(1.0);
                    this.progressBar1.Maximum++;
                }
                WebClient client = new WebClient();
                string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/NivoKorisnika/GetUsersInfoAll2.php?";
                address = address + "Id=sdf";
                string s = client.DownloadString(address);
                int length = s.Replace("],[", "*").Split(new char[] { '*' }).Length;
                this.progressBar1.Maximum = length;
                this.progressBar1.Value = 0;
                this.dataGridView1.Rows.Clear();
                JsonTextReader reader = new JsonTextReader(new StringReader(s));
                int num3 = 0;
                while (reader.Read())
                {
                    if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                    {
                        switch (num3)
                        {
                            case 0:
                            {
                                this.progressBar1.PerformStep();
                                this.Id[this.stanje] = reader.Value.ToString();
                                WebClient client2 = new WebClient();
                                string str6 = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Izvestaji/GetNumberOfComments.php?";
                                str6 = (str6 + "IdKorisnika=" + reader.Value.ToString()) + "&Datum=" + this.NizDatum;
                                string str7 = client.DownloadString(str6).Replace("\n", "").Replace("\r", "");
                                this.dataGridView1.Rows.Add();
                                this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[3].Value = int.Parse(str7);
                                WebClient client3 = new WebClient();
                                string str8 = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Izvestaji/GetNumberOfPublishComments.php?";
                                str8 = (str8 + "IdKorisnika=" + reader.Value.ToString()) + "&Datum=" + this.NizDatum;
                                string str9 = client.DownloadString(str8).Replace("\n", "").Replace("\r", "");
                                this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[4].Value = int.Parse(str9);
                                WebClient client4 = new WebClient();
                                string str10 = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Izvestaji/GetPointsOfUsers.php?";
                                str10 = (str10 + "IdKorisnika=" + reader.Value.ToString()) + "&Datum=" + this.NizDatum;
                                string str11 = client.DownloadString(str10).Replace("\n", "").Replace("\r", "");
                                try
                                {
                                    this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[5].Value = double.Parse(str11);
                                }
                                catch
                                {
                                    this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[5].Value = double.Parse("0.00");
                                }
                                break;
                            }
                            case 1:
                                this.Ime[this.stanje] = reader.Value.ToString();
                                this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[0].Value = reader.Value.ToString();
                                break;

                            case 2:
                                this.Prezime[this.stanje] = reader.Value.ToString();
                                this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[1].Value = reader.Value.ToString();
                                break;

                            case 3:
                                this.Opstina[this.stanje] = reader.Value.ToString();
                                this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[2].Value = reader.Value.ToString();
                                break;

                            case 4:
                                this.Nivo[this.stanje] = reader.Value.ToString();
                                break;
                        }
                        num3++;
                        if (num3 == 5)
                        {
                            num3 = 0;
                            this.stanje++;
                        }
                    }
                }
                base.Size = new Size(base.Size.Width, 700);
                MessageBox.Show("Dobijena tabela može da se prebaci u EXCEL.\n\n1. Izaberite sve ili nekoliko redova (držite CTRL i klik na red po red ili SHIFT pa prvi i poslednji red).\n2. Pritisnite CTRL + C za kopiranje podataka.\n3. U EXCEL tabelu desni klik mišem i odaberite PASTE SPECIAL.\n4. Izaberite UNICODE TEXT\nI to je to, sve je prebačeno sa našim slovima.\nSredite tabelu prema željama i imate izveštaj spreman za 5 minuta.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(OdDoPrijavljeniObjavljeni));
            this.panel1 = new Panel();
            this.progressBar1 = new ProgressBar();
            this.button1 = new Button();
            this.dateTimePicker2 = new DateTimePicker();
            this.label2 = new Label();
            this.label1 = new Label();
            this.dateTimePicker1 = new DateTimePicker();
            this.dataGridView1 = new DataGridView();
            this.ImeDV = new DataGridViewTextBoxColumn();
            this.PrezimeDV = new DataGridViewTextBoxColumn();
            this.OpstinaDV = new DataGridViewTextBoxColumn();
            this.PoslatoKomentaraDV = new DataGridViewTextBoxColumn();
            this.ObjavljenoKomentaraDV = new DataGridViewTextBoxColumn();
            this.Bodovi = new DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            base.SuspendLayout();
            this.panel1.BackColor = Color.White;
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x3cd, 0x3a);
            this.panel1.TabIndex = 0;
            this.progressBar1.Dock = DockStyle.Top;
            this.progressBar1.Location = new Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new Size(0x3cd, 0x1a);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 5;
            this.button1.Cursor = Cursors.Hand;
            this.button1.Location = new Point(0x2ec, 30);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0xd5, 0x1a);
            this.button1.TabIndex = 4;
            this.button1.Text = "POTVRDI";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.dateTimePicker2.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dateTimePicker2.Location = new Point(0x1a9, 30);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new Size(0x13c, 0x1a);
            this.dateTimePicker2.TabIndex = 3;
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(370, 30);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x31, 0x18);
            this.label2.TabIndex = 2;
            this.label2.Text = "- DO";
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(4, 30);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x26, 0x18);
            this.label1.TabIndex = 1;
            this.label1.Text = "OD";
            this.dateTimePicker1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dateTimePicker1.Location = new Point(0x30, 0x1c);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new Size(0x13c, 0x1a);
            this.dateTimePicker1.TabIndex = 0;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = Color.White;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.BackColor = Color.Sienna;
            style.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            style.ForeColor = Color.White;
            style.SelectionBackColor = Color.Black;
            style.SelectionForeColor = SystemColors.HighlightText;
            style.WrapMode = DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = style;
            this.dataGridView1.ColumnHeadersHeight = 0x1a;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { this.ImeDV, this.PrezimeDV, this.OpstinaDV, this.PoslatoKomentaraDV, this.ObjavljenoKomentaraDV, this.Bodovi });
            this.dataGridView1.Dock = DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = Color.Black;
            this.dataGridView1.Location = new Point(0, 0x3a);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new Size(0x3cd, 0);
            this.dataGridView1.TabIndex = 1;
            this.ImeDV.HeaderText = "Ime";
            this.ImeDV.Name = "ImeDV";
            this.ImeDV.ReadOnly = true;
            this.ImeDV.Width = 160;
            this.PrezimeDV.HeaderText = "Prezime";
            this.PrezimeDV.Name = "PrezimeDV";
            this.PrezimeDV.ReadOnly = true;
            this.PrezimeDV.Width = 200;
            this.OpstinaDV.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.OpstinaDV.HeaderText = "Opština";
            this.OpstinaDV.Name = "OpstinaDV";
            this.OpstinaDV.ReadOnly = true;
            this.PoslatoKomentaraDV.HeaderText = "Poslato komentara";
            this.PoslatoKomentaraDV.Name = "PoslatoKomentaraDV";
            this.PoslatoKomentaraDV.ReadOnly = true;
            this.PoslatoKomentaraDV.Width = 140;
            this.ObjavljenoKomentaraDV.HeaderText = "Objavljeno komentara";
            this.ObjavljenoKomentaraDV.Name = "ObjavljenoKomentaraDV";
            this.ObjavljenoKomentaraDV.ReadOnly = true;
            this.ObjavljenoKomentaraDV.Width = 140;
            this.Bodovi.HeaderText = "Bodovi";
            this.Bodovi.Name = "Bodovi";
            this.Bodovi.ReadOnly = true;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x3cd, 0x3a);
            base.Controls.Add(this.dataGridView1);
            base.Controls.Add(this.panel1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "OdDoPrijavljeniObjavljeni";
            this.Text = "Prijavljeni i objavljeni komentari";
            base.Shown += new EventHandler(this.OdDoPrijavljeniObjavljeni_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((ISupportInitialize) this.dataGridView1).EndInit();
            base.ResumeLayout(false);
        }

        private void OdDoPrijavljeniObjavljeni_Shown(object sender, EventArgs e)
        {
        }
    }
}

