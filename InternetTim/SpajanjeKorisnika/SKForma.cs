namespace InternetTim.SpajanjeKorisnika
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;

    public class SKForma : Form
    {
        private Button button1;
        private DataGridViewTextBoxColumn ColumnID;
        private DataGridViewTextBoxColumn ColumnIME;
        private DataGridViewTextBoxColumn ColumnOPSTINA;
        private DataGridViewTextBoxColumn ColumnPREZIME;
        private DataGridViewTextBoxColumn ColumnRACUNAR;
        private IContainer components = null;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private string[] Id = new string[0xbb8];
        private string[] Ime = new string[0xbb8];
        private Label label1;
        private Label label2;
        private Label label3;
        private string[] Opstina = new string[0xbb8];
        private string[] Prezime = new string[0xbb8];
        private string[] Racunar = new string[0xbb8];
        private int stanje = 0;
        private TextBox textBox1;
        private TextBox textBox2;

        public SKForma()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/SpajanjeKorisnika/InsertNewCommand.php?";
                address = (address + "id1=" + this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString()) + "&id2=" + this.dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                string str2 = client.DownloadString(address);
                MessageBox.Show("POSLATA KOMANDA", "INFO");
            }
            catch
            {
                MessageBox.Show("GRESKA U SLANJU", "INFO");
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(SKForma));
            this.button1 = new Button();
            this.label1 = new Label();
            this.textBox1 = new TextBox();
            this.label2 = new Label();
            this.textBox2 = new TextBox();
            this.label3 = new Label();
            this.dataGridView1 = new DataGridView();
            this.ColumnID = new DataGridViewTextBoxColumn();
            this.ColumnIME = new DataGridViewTextBoxColumn();
            this.ColumnPREZIME = new DataGridViewTextBoxColumn();
            this.ColumnOPSTINA = new DataGridViewTextBoxColumn();
            this.ColumnRACUNAR = new DataGridViewTextBoxColumn();
            this.dataGridView2 = new DataGridView();
            this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            ((ISupportInitialize) this.dataGridView2).BeginInit();
            base.SuspendLayout();
            this.button1.Cursor = Cursors.Hand;
            this.button1.Location = new Point(6, 0x2b9);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4f6, 0x25);
            this.button1.TabIndex = 2;
            this.button1.Text = "POTVRDI";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x30e, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Izaberi korsnika sa leve liste koji će da postane korisnik sa desne liste. Poslaće se komanda korisniku sa leve liste, čim upali program postaće korsnik sa desne liste. ";
            this.textBox1.Location = new Point(0x49, 0x29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0xfb, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(20, 0x2c);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x2f, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pretraga";
            this.textBox2.Location = new Point(0x2c5, 0x29);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(0xfb, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.TextChanged += new EventHandler(this.textBox2_TextChanged);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x290, 0x2c);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x2f, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Pretraga";
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { this.ColumnID, this.ColumnIME, this.ColumnPREZIME, this.ColumnOPSTINA, this.ColumnRACUNAR });
            this.dataGridView1.Location = new Point(6, 0x43);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new Size(630, 0x270);
            this.dataGridView1.TabIndex = 8;
            this.ColumnID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            this.ColumnIME.HeaderText = "IME";
            this.ColumnIME.Name = "ColumnIME";
            this.ColumnIME.ReadOnly = true;
            this.ColumnPREZIME.HeaderText = "PREZIME";
            this.ColumnPREZIME.Name = "ColumnPREZIME";
            this.ColumnPREZIME.ReadOnly = true;
            this.ColumnOPSTINA.HeaderText = "OPSTINA";
            this.ColumnOPSTINA.Name = "ColumnOPSTINA";
            this.ColumnOPSTINA.ReadOnly = true;
            this.ColumnRACUNAR.HeaderText = "RACUNAR";
            this.ColumnRACUNAR.Name = "ColumnRACUNAR";
            this.ColumnRACUNAR.ReadOnly = true;
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new DataGridViewColumn[] { this.dataGridViewTextBoxColumn1, this.dataGridViewTextBoxColumn2, this.dataGridViewTextBoxColumn3, this.dataGridViewTextBoxColumn4, this.dataGridViewTextBoxColumn5 });
            this.dataGridView2.Location = new Point(0x286, 0x43);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView2.RowTemplate.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new Size(630, 0x270);
            this.dataGridView2.TabIndex = 9;
            this.dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "IME";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "PREZIME";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "OPSTINA";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.HeaderText = "RACUNAR";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(0x502, 0x2eb);
            base.Controls.Add(this.dataGridView2);
            base.Controls.Add(this.dataGridView1);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.textBox2);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.button1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "SKForma";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Spajanje korisnika";
            base.Shown += new EventHandler(this.SKForma_Shown);
            ((ISupportInitialize) this.dataGridView1).EndInit();
            ((ISupportInitialize) this.dataGridView2).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void SKForma_Shown(object sender, EventArgs e)
        {
            this.Ucitavanje();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            for (int i = 0; i < 0xbb8; i++)
            {
                if (this.Id[i] == null)
                {
                    break;
                }
                if (this.Ime[i].ToLower().Contains(this.textBox1.Text.ToLower()) || this.Prezime[i].ToLower().Contains(this.textBox1.Text.ToLower()))
                {
                    this.dataGridView1.Rows.Add();
                    this.dataGridView1[0, this.dataGridView1.Rows.Count - 1].Value = this.Id[i];
                    this.dataGridView1[1, this.dataGridView1.Rows.Count - 1].Value = this.Ime[i];
                    this.dataGridView1[2, this.dataGridView1.Rows.Count - 1].Value = this.Prezime[i];
                    this.dataGridView1[3, this.dataGridView1.Rows.Count - 1].Value = this.Opstina[i];
                    this.dataGridView1[4, this.dataGridView1.Rows.Count - 1].Value = this.Racunar[i];
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.dataGridView2.Rows.Clear();
            for (int i = 0; i < 0xbb8; i++)
            {
                if (this.Id[i] == null)
                {
                    break;
                }
                if (this.Ime[i].ToLower().Contains(this.textBox2.Text.ToLower()) || this.Prezime[i].ToLower().Contains(this.textBox2.Text.ToLower()))
                {
                    this.dataGridView2.Rows.Add();
                    this.dataGridView2[0, this.dataGridView2.Rows.Count - 1].Value = this.Id[i];
                    this.dataGridView2[1, this.dataGridView2.Rows.Count - 1].Value = this.Ime[i];
                    this.dataGridView2[2, this.dataGridView2.Rows.Count - 1].Value = this.Prezime[i];
                    this.dataGridView2[3, this.dataGridView2.Rows.Count - 1].Value = this.Opstina[i];
                    this.dataGridView2[4, this.dataGridView2.Rows.Count - 1].Value = this.Racunar[i];
                }
            }
        }

        private void Ucitavanje()
        {
            try
            {
                WebClient client = new WebClient();
                string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/SpajanjeKorisnika/GetUsersInfoAll2.php?";
                address = address + "Id=sdf";
                JsonTextReader reader = new JsonTextReader(new StringReader(client.DownloadString(address)));
                int num = 0;
                while (reader.Read())
                {
                    if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                    {
                        switch (num)
                        {
                            case 0:
                                this.Id[this.stanje] = reader.Value.ToString();
                                break;

                            case 1:
                                this.Ime[this.stanje] = reader.Value.ToString();
                                break;

                            case 2:
                                this.Prezime[this.stanje] = reader.Value.ToString();
                                break;

                            case 3:
                                this.Opstina[this.stanje] = reader.Value.ToString();
                                break;

                            case 4:
                                this.Racunar[this.stanje] = reader.Value.ToString();
                                break;
                        }
                        num++;
                        if (num == 5)
                        {
                            num = 0;
                            this.stanje++;
                        }
                    }
                }
                int index = 0;
                foreach (string str3 in this.Id)
                {
                    if (str3 == null)
                    {
                        break;
                    }
                    this.dataGridView1.Rows.Add();
                    this.dataGridView1[0, this.dataGridView1.Rows.Count - 1].Value = this.Id[index];
                    this.dataGridView1[1, this.dataGridView1.Rows.Count - 1].Value = this.Ime[index];
                    this.dataGridView1[2, this.dataGridView1.Rows.Count - 1].Value = this.Prezime[index];
                    this.dataGridView1[3, this.dataGridView1.Rows.Count - 1].Value = this.Opstina[index];
                    this.dataGridView1[4, this.dataGridView1.Rows.Count - 1].Value = this.Racunar[index];
                    this.dataGridView2.Rows.Add();
                    this.dataGridView2[0, this.dataGridView2.Rows.Count - 1].Value = this.Id[index];
                    this.dataGridView2[1, this.dataGridView2.Rows.Count - 1].Value = this.Ime[index];
                    this.dataGridView2[2, this.dataGridView2.Rows.Count - 1].Value = this.Prezime[index];
                    this.dataGridView2[3, this.dataGridView2.Rows.Count - 1].Value = this.Opstina[index];
                    this.dataGridView2[4, this.dataGridView2.Rows.Count - 1].Value = this.Racunar[index];
                    index++;
                }
                for (int i = 0; i < (this.dataGridView1.Rows.Count - 1); i++)
                {
                    for (int j = 0; j < (this.dataGridView2.Rows.Count - 1); j++)
                    {
                        if ((i != j) && (this.dataGridView1[0, i].Value.ToString() == this.dataGridView2[0, j].Value.ToString()))
                        {
                            this.dataGridView1[0, i].Style.BackColor = Color.Silver;
                        }
                        else
                        {
                            try
                            {
                                if (((i != j) && (this.dataGridView1[1, i].Value.ToString().ToLower() == this.dataGridView2[1, j].Value.ToString().ToLower())) && (this.dataGridView1[2, i].Value.ToString().ToLower() == this.dataGridView2[2, j].Value.ToString().ToLower()))
                                {
                                    this.dataGridView1[1, i].Style.BackColor = Color.Yellow;
                                    this.dataGridView1[2, i].Style.BackColor = Color.Yellow;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                if (((i != j) && (this.dataGridView1[1, i].Value.ToString().ToLower().Substring(0, 3) == this.dataGridView2[1, j].Value.ToString().ToLower().Substring(0, 3))) && (this.dataGridView1[2, i].Value.ToString().ToLower().Substring(0, 3) == this.dataGridView2[2, j].Value.ToString().ToLower().Substring(0, 3)))
                                {
                                    this.dataGridView1[0, i].Style.BackColor = Color.Orange;
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}

