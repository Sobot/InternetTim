namespace InternetTim.Izvestaji
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;

    public class ZadnjaAktivnostKorisnika : Form
    {
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private IContainer components = null;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ZadnjaAktivnost;

        public ZadnjaAktivnostKorisnika()
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(ZadnjaAktivnostKorisnika));
            this.dataGridView1 = new DataGridView();
            this.Column1 = new DataGridViewTextBoxColumn();
            this.Column2 = new DataGridViewTextBoxColumn();
            this.Column3 = new DataGridViewTextBoxColumn();
            this.ZadnjaAktivnost = new DataGridViewTextBoxColumn();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            base.SuspendLayout();
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = Color.White;
            this.dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { this.Column1, this.Column2, this.Column3, this.ZadnjaAktivnost });
            this.dataGridView1.Dock = DockStyle.Fill;
            this.dataGridView1.GridColor = Color.Black;
            this.dataGridView1.Location = new Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new Size(0x43e, 0x288);
            this.dataGridView1.TabIndex = 1;
            this.Column1.HeaderText = "Ime";
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            this.Column2.HeaderText = "Prezime";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            this.Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Opstina";
            this.Column3.Name = "Column3";
            this.ZadnjaAktivnost.HeaderText = "Zadnja aktivnost";
            this.ZadnjaAktivnost.Name = "ZadnjaAktivnost";
            this.ZadnjaAktivnost.Width = 200;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x43e, 0x288);
            base.Controls.Add(this.dataGridView1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "ZadnjaAktivnostKorisnika";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Zadnja aktivnost korisnika";
            base.Shown += new EventHandler(this.ZadnjaAktivnostKorisnika_Shown);
            ((ISupportInitialize) this.dataGridView1).EndInit();
            base.ResumeLayout(false);
        }

        private void ZadnjaAktivnostKorisnika_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WebClient client = new WebClient();
                string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Izvestaji/GetLastActivityOfUsers.php";
                JsonTextReader reader = new JsonTextReader(new StringReader(client.DownloadString(address)));
                int num = 0;
                while (reader.Read())
                {
                    if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                    {
                        switch (num)
                        {
                            case 0:
                                this.dataGridView1.Rows.Add();
                                this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[0].Value = reader.Value.ToString();
                                break;

                            case 1:
                                this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[1].Value = reader.Value.ToString();
                                break;

                            case 2:
                                this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[2].Value = reader.Value.ToString();
                                break;

                            case 3:
                                this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[3].Value = reader.Value.ToString();
                                break;
                        }
                        num++;
                        if (num == 4)
                        {
                            num = 0;
                        }
                    }
                }
            }
            catch
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Dogodila se greška, probajte ponovo ili restartujte program.", "INFO");
                base.Close();
            }
            Cursor.Current = Cursors.Default;
        }
    }
}

