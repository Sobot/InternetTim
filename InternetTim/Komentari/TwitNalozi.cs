namespace InternetTim.Komentari
{
    using HtmlAgilityPack;
    using Newtonsoft.Json;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Windows.Forms;

    public class TwitNalozi : Form
    {
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private IContainer components = null;
        private DataGridView dataGridView1;
        private Button OBRISI;
        private TextBox textBox1;
        private int TWbroj = 0;
        private string[] TWid = new string[0x7d0];
        private string[] TWnalozi = new string[0x7d0];
        private Button UnosNovogNaloga;

        public TwitNalozi()
        {
            this.InitializeComponent();
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MyDataGridHelper.DataGridSort(this.dataGridView1, e.ColumnIndex);
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(TwitNalozi));
            this.dataGridView1 = new DataGridView();
            this.Column1 = new DataGridViewTextBoxColumn();
            this.Column2 = new DataGridViewTextBoxColumn();
            this.Column3 = new DataGridViewTextBoxColumn();
            this.Column4 = new DataGridViewTextBoxColumn();
            this.Column5 = new DataGridViewTextBoxColumn();
            this.Column6 = new DataGridViewTextBoxColumn();
            this.textBox1 = new TextBox();
            this.UnosNovogNaloga = new Button();
            this.OBRISI = new Button();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            base.SuspendLayout();
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = Color.White;
            this.dataGridView1.BorderStyle = BorderStyle.None;
            this.dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { this.Column1, this.Column2, this.Column3, this.Column4, this.Column5, this.Column6 });
            this.dataGridView1.Location = new Point(12, 0x29);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new Size(0x3b0, 0x228);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "NALOG";
            this.Column1.Name = "Column1";
            this.Column2.HeaderText = "TWEETS";
            this.Column2.Name = "Column2";
            this.Column3.HeaderText = "PHOTOS/VIDEOS";
            this.Column3.Name = "Column3";
            this.Column4.HeaderText = "FOLLOWING";
            this.Column4.Name = "Column4";
            this.Column5.HeaderText = "FOLLOWERS";
            this.Column5.Name = "Column5";
            this.Column6.HeaderText = "FAVORITES";
            this.Column6.Name = "Column6";
            this.textBox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.textBox1.Location = new Point(13, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x25e, 0x16);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Kopiraj link twitter naloga";
            this.UnosNovogNaloga.Cursor = Cursors.Hand;
            this.UnosNovogNaloga.Location = new Point(0x271, 11);
            this.UnosNovogNaloga.Name = "UnosNovogNaloga";
            this.UnosNovogNaloga.Size = new Size(0xad, 0x18);
            this.UnosNovogNaloga.TabIndex = 2;
            this.UnosNovogNaloga.Text = "POTVRDI";
            this.UnosNovogNaloga.UseVisualStyleBackColor = true;
            this.UnosNovogNaloga.Click += new EventHandler(this.UnosNovogNaloga_Click);
            this.OBRISI.Location = new Point(0x324, 11);
            this.OBRISI.Name = "OBRISI";
            this.OBRISI.Size = new Size(0x98, 0x17);
            this.OBRISI.TabIndex = 3;
            this.OBRISI.Text = "OBRIŠI IZABRANI";
            this.OBRISI.UseVisualStyleBackColor = true;
            this.OBRISI.Click += new EventHandler(this.OBRISI_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(0x3c8, 0x25d);
            base.Controls.Add(this.OBRISI);
            base.Controls.Add(this.UnosNovogNaloga);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.dataGridView1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "TwitNalozi";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Nalozi";
            base.Shown += new EventHandler(this.TwitNalozi_Shown);
            ((ISupportInitialize) this.dataGridView1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void OBRISI_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.SelectedRows[0].Index;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    WebClient client = new WebClient();
                    string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/Twitter/DeleteTwitterUserById.php?";
                    address = address + "&Id=" + this.TWid[index];
                    if (client.DownloadString(address).Contains("OKET"))
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Uspešno obrisan korisnik", "INFO");
                        this.dataGridView1.Rows[index].Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Izaberite nalog u tabeli prvo", "INFO");
                }
            }
            catch
            {
                MessageBox.Show("Dogodila se greška, pokušajte ponovo ili restartujte program.", "INFO");
            }
            Cursor.Current = Cursors.Default;
        }

        private void TwitNalozi_Shown(object sender, EventArgs e)
        {
            this.Ucitavanje();
        }

        private void Ucitavanje()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.TWbroj = 0;
                Array.Clear(this.TWid, 0, 0x7d0);
                Array.Clear(this.TWnalozi, 0, 0x7d0);
                this.dataGridView1.Rows.Clear();
                WebClient client = new WebClient();
                JsonTextReader reader = new JsonTextReader(new StringReader(client.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/Twitter/GetAllTwitterNalozi.php")));
                int num = 0;
                while (reader.Read())
                {
                    if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                    {
                        switch (num)
                        {
                            case 0:
                                this.dataGridView1.Rows.Add();
                                this.TWid[this.TWbroj] = reader.Value.ToString();
                                break;

                            case 1:
                            {
                                this.TWnalozi[this.TWbroj] = reader.Value.ToString().Replace("[[]]", "&");
                                string[] strArray = this.TWnalozi[this.TWbroj].Split(new char[] { '/' });
                                this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[0].Value = strArray[strArray.Length - 1];
                                try
                                {
                                    string html = "";
                                    using (WebClient client2 = new WebClient())
                                    {
                                        client2.Encoding = Encoding.UTF8;
                                        html = client2.DownloadString(this.TWnalozi[this.TWbroj]);
                                        client2.Dispose();
                                    }
                                    HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                                    document.LoadHtml(html);
                                    foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//ul[@class='ProfileNav-list']"))
                                    {
                                        decimal num2;
                                        int num3;
                                        string str3 = node.ChildNodes[1].InnerText.Replace(" ", "").Replace("\n", "").Replace("Tweets", "");
                                        if (str3.Contains("K"))
                                        {
                                            num2 = decimal.Parse(str3.Replace("K", "")) * 1000M;
                                            num3 = (int) num2;
                                            str3 = num3.ToString();
                                        }
                                        str3 = str3.Replace(",", "").Replace(".", "");
                                        this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[1].Value = str3;
                                        str3 = node.ChildNodes[2].InnerText.Replace(" ", "").Replace("\n", "").Replace("Photos/Videos", "");
                                        if (str3.Contains("K"))
                                        {
                                            num2 = decimal.Parse(str3.Replace("K", "")) * 1000M;
                                            num3 = (int) num2;
                                            str3 = num3.ToString();
                                        }
                                        str3 = str3.Replace(",", "").Replace(".", "");
                                        this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[2].Value = str3;
                                        str3 = node.ChildNodes[3].InnerText.Replace(" ", "").Replace("\n", "").Replace("Following", "");
                                        if (str3.Contains("K"))
                                        {
                                            num2 = decimal.Parse(str3.Replace("K", "")) * 1000M;
                                            num3 = (int) num2;
                                            str3 = num3.ToString();
                                        }
                                        str3 = str3.Replace(",", "").Replace(".", "");
                                        this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[3].Value = str3;
                                        str3 = node.ChildNodes[4].InnerText.Replace(" ", "").Replace("\n", "").Replace("Followers", "");
                                        if (str3.Contains("K"))
                                        {
                                            num2 = decimal.Parse(str3.Replace("K", "")) * 1000M;
                                            num3 = (int) num2;
                                            str3 = num3.ToString();
                                        }
                                        str3 = str3.Replace(",", "").Replace(".", "");
                                        this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[4].Value = str3;
                                        str3 = node.ChildNodes[5].InnerText.Replace(" ", "").Replace("\n", "").Replace("Favorites", "");
                                        if (str3.Contains("K"))
                                        {
                                            num2 = decimal.Parse(str3.Replace("K", "")) * 1000M;
                                            str3 = ((int) num2).ToString();
                                        }
                                        str3 = str3.Replace(",", "").Replace(".", "");
                                        this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[5].Value = str3;
                                    }
                                }
                                catch
                                {
                                }
                                break;
                            }
                        }
                        num++;
                        if (num == 2)
                        {
                            this.TWbroj++;
                            num = 0;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Dogodila se greška, pokušajte ponovo ili restartujte program.", "INFO");
            }
            Cursor.Current = Cursors.Default;
        }

        private void UnosNovogNaloga_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if ((this.textBox1.Text.Length > 2) && (this.textBox1.Text != "Kopiraj link twitter naloga"))
                {
                    WebClient client = new WebClient();
                    string address = "http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/Twitter/InsertNewTwitterNalog.php?";
                    address = address + "&nalog=" + this.textBox1.Text.Replace("&", "[[]]");
                    if (client.DownloadString(address).Contains("OKET"))
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Uspešno unet novi korisnik", "INFO");
                        this.textBox1.Text = "Kopiraj link twitter naloga";
                        this.Ucitavanje();
                    }
                }
                else
                {
                    MessageBox.Show("Proverite link", "INFO");
                }
            }
            catch
            {
                MessageBox.Show("Dogodila se greška, pokušajte ponovo ili restartujte program.", "INFO");
            }
            Cursor.Current = Cursors.Default;
        }

        public class MyDataGridHelper
        {
            public static void DataGridSort(DataGridView dgv, int column)
            {
                DataGridViewCustomSorter comparer = null;
                if (!((dgv.Tag != null) && (dgv.Tag is IComparer)))
                {
                    comparer = new DataGridViewCustomSorter(dgv);
                    dgv.Tag = comparer;
                }
                else
                {
                    comparer = (DataGridViewCustomSorter) dgv.Tag;
                }
                comparer.SortColumn = column;
                dgv.Sort(comparer);
            }

            private class DataGridViewCustomSorter : IComparer
            {
                private int ColumnIndex;
                private DataGridView myDataGridView;
                private TypeCode mySortTypeCode;
                private SortOrder OrderOfSort;

                public DataGridViewCustomSorter(DataGridView dgv)
                {
                    this.myDataGridView = dgv;
                    this.mySortTypeCode = System.Type.GetTypeCode(System.Type.GetType("System.String"));
                    this.ColumnIndex = 0;
                    this.OrderOfSort = SortOrder.None;
                }

                public int Compare(object x, object y)
                {
                    int num;
                    DataGridViewRow row = (DataGridViewRow) x;
                    DataGridViewRow row2 = (DataGridViewRow) y;
                    string str = row.Cells[this.ColumnIndex].Value.ToString();
                    string str2 = row2.Cells[this.ColumnIndex].Value.ToString();
                    if ((str == string.Empty) && (str2 == string.Empty))
                    {
                        num = 0;
                    }
                    else if ((str == string.Empty) && (str2 != string.Empty))
                    {
                        num = -1;
                    }
                    else if ((str != string.Empty) && (str2 == string.Empty))
                    {
                        num = 1;
                    }
                    else
                    {
                        switch (this.mySortTypeCode)
                        {
                            case TypeCode.Decimal:
                            {
                                decimal num2 = Convert.ToDecimal(str);
                                decimal num3 = Convert.ToDecimal(str2);
                                num = num2.CompareTo(num3);
                                goto Label_014C;
                            }
                            case TypeCode.DateTime:
                            {
                                DateTime time = Convert.ToDateTime(str);
                                DateTime time2 = Convert.ToDateTime(str2);
                                num = time.CompareTo(time2);
                                goto Label_014C;
                            }
                            case TypeCode.String:
                                num = new CaseInsensitiveComparer().Compare(str, str2);
                                goto Label_014C;
                        }
                        num = new CaseInsensitiveComparer().Compare(str, str2);
                    }
                Label_014C:
                    if (this.OrderOfSort == SortOrder.Descending)
                    {
                        num = -num;
                    }
                    return num;
                }

                public SortOrder Order
                {
                    get
                    {
                        return this.OrderOfSort;
                    }
                    set
                    {
                        this.OrderOfSort = value;
                    }
                }

                public int SortColumn
                {
                    get
                    {
                        return this.ColumnIndex;
                    }
                    set
                    {
                        if (this.ColumnIndex == value)
                        {
                            this.OrderOfSort = (this.OrderOfSort == SortOrder.Descending) ? SortOrder.Ascending : SortOrder.Descending;
                        }
                        this.ColumnIndex = value;
                        try
                        {
                            this.mySortTypeCode = System.Type.GetTypeCode(System.Type.GetType(this.myDataGridView.Columns[this.ColumnIndex].Tag.ToString()));
                        }
                        catch
                        {
                            this.mySortTypeCode = TypeCode.Decimal;
                        }
                    }
                }
            }
        }
    }
}

