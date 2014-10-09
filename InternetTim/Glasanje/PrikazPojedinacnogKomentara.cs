namespace InternetTim.Glasanje
{
    using InternetTim.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class PrikazPojedinacnogKomentara : UserControl
    {
        private Button Autor;
        public int BrojMinus = 0;
        public int BrojPlus = 0;
        private IContainer components = null;
        private int glasao = 0;
        public string IdKomentara = "";
        private string idkommmm = "";
        private Button IdStanjeKomentara;
        private Button minus;
        private Button plus;
        public int RealanMinus = 0;
        public int RealanPlus = 0;
        private Button TekstKomentara;
        private TextBox textBox1;
        private TextBox textBox2;

        public event EventHandler<EventArgs> IdKomentaraWasClicked;

        public event EventHandler<EventArgs> MinusWasClicked;

        public event EventHandler<EventArgs> PlusWasClicked;

        public event EventHandler<EventArgs> WasClicked;

        public PrikazPojedinacnogKomentara()
        {
            this.InitializeComponent();
        }

        private void Autor_Click(object sender, EventArgs e)
        {
            if (this.WasClicked != null)
            {
                this.WasClicked(this, EventArgs.Empty);
            }
        }

        public void AzurirajPreporucujem(int pl, int mi)
        {
            this.plus.Text = pl.ToString();
            this.minus.Text = mi.ToString();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void IdStanjeKomentara_Click(object sender, EventArgs e)
        {
            if (this.IdKomentaraWasClicked != null)
            {
                this.IdKomentaraWasClicked(this, EventArgs.Empty);
            }
            this.IdStanjeKomentara.Text = this.idkommmm;
            this.IdStanjeKomentara.BackColor = Color.White;
            this.textBox1.Visible = true;
            this.textBox2.Visible = true;
            this.glasao = 0;
        }

        private void InitializeComponent()
        {
            this.TekstKomentara = new Button();
            this.Autor = new Button();
            this.minus = new Button();
            this.plus = new Button();
            this.textBox1 = new TextBox();
            this.textBox2 = new TextBox();
            this.IdStanjeKomentara = new Button();
            base.SuspendLayout();
            this.TekstKomentara.BackColor = Color.White;
            this.TekstKomentara.Cursor = Cursors.Hand;
            this.TekstKomentara.Dock = DockStyle.Fill;
            this.TekstKomentara.FlatAppearance.MouseOverBackColor = Color.FromArgb(0xff, 0xc0, 0xc0);
            this.TekstKomentara.FlatStyle = FlatStyle.Flat;
            this.TekstKomentara.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.TekstKomentara.Location = new Point(0, 0x41);
            this.TekstKomentara.Margin = new Padding(0);
            this.TekstKomentara.Name = "TekstKomentara";
            this.TekstKomentara.Size = new Size(600, 0x41);
            this.TekstKomentara.TabIndex = 1;
            this.TekstKomentara.Text = "Tekst komentara";
            this.TekstKomentara.TextAlign = ContentAlignment.TopLeft;
            this.TekstKomentara.UseVisualStyleBackColor = false;
            this.TekstKomentara.Click += new EventHandler(this.Autor_Click);
            this.Autor.BackColor = Color.Wheat;
            this.Autor.Cursor = Cursors.Hand;
            this.Autor.Dock = DockStyle.Top;
            this.Autor.FlatAppearance.MouseOverBackColor = Color.FromArgb(0xff, 0xc0, 0xc0);
            this.Autor.FlatStyle = FlatStyle.Flat;
            this.Autor.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Autor.Location = new Point(0, 0);
            this.Autor.Margin = new Padding(0);
            this.Autor.Name = "Autor";
            this.Autor.Size = new Size(600, 0x41);
            this.Autor.TabIndex = 0;
            this.Autor.Text = "Autor";
            this.Autor.TextAlign = ContentAlignment.BottomLeft;
            this.Autor.UseVisualStyleBackColor = false;
            this.Autor.Click += new EventHandler(this.Autor_Click);
            this.minus.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.minus.BackColor = Color.MistyRose;
            this.minus.Cursor = Cursors.Hand;
            this.minus.FlatAppearance.MouseDownBackColor = Color.Red;
            this.minus.FlatAppearance.MouseOverBackColor = Color.White;
            this.minus.FlatStyle = FlatStyle.Flat;
            this.minus.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.minus.Image = Resources.votedown2;
            this.minus.ImageAlign = ContentAlignment.TopLeft;
            this.minus.Location = new Point(0x20d, 0);
            this.minus.Name = "minus";
            this.minus.Size = new Size(0x4b, 0x41);
            this.minus.TabIndex = 3;
            this.minus.Text = "0";
            this.minus.TextAlign = ContentAlignment.MiddleRight;
            this.minus.UseVisualStyleBackColor = false;
            this.minus.Click += new EventHandler(this.minus_Click);
            this.plus.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.plus.BackColor = Color.LightYellow;
            this.plus.Cursor = Cursors.Hand;
            this.plus.FlatAppearance.MouseDownBackColor = Color.Red;
            this.plus.FlatAppearance.MouseOverBackColor = Color.White;
            this.plus.FlatStyle = FlatStyle.Flat;
            this.plus.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.plus.Image = Resources.voteup2;
            this.plus.ImageAlign = ContentAlignment.TopLeft;
            this.plus.Location = new Point(0x1c3, 0);
            this.plus.Name = "plus";
            this.plus.Size = new Size(0x4b, 0x41);
            this.plus.TabIndex = 2;
            this.plus.Text = "0";
            this.plus.TextAlign = ContentAlignment.MiddleRight;
            this.plus.UseVisualStyleBackColor = false;
            this.plus.Click += new EventHandler(this.plus_Click);
            this.textBox1.Location = new Point(0x1c6, 0x29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x45, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextAlign = HorizontalAlignment.Center;
            this.textBox1.Click += new EventHandler(this.Autor_Click);
            this.textBox2.Location = new Point(0x210, 0x29);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(0x45, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.TextAlign = HorizontalAlignment.Center;
            this.textBox2.Click += new EventHandler(this.Autor_Click);
            this.IdStanjeKomentara.Cursor = Cursors.Hand;
            this.IdStanjeKomentara.FlatAppearance.MouseOverBackColor = Color.FromArgb(0x80, 0xff, 0xff);
            this.IdStanjeKomentara.FlatStyle = FlatStyle.Flat;
            this.IdStanjeKomentara.Font = new Font("Arial Narrow", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.IdStanjeKomentara.Location = new Point(0, 0);
            this.IdStanjeKomentara.Name = "IdStanjeKomentara";
            this.IdStanjeKomentara.Size = new Size(220, 0x20);
            this.IdStanjeKomentara.TabIndex = 6;
            this.IdStanjeKomentara.Text = "id komentara";
            this.IdStanjeKomentara.TextAlign = ContentAlignment.MiddleLeft;
            this.IdStanjeKomentara.UseVisualStyleBackColor = true;
            this.IdStanjeKomentara.Click += new EventHandler(this.IdStanjeKomentara_Click);
            base.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.White;
            base.Controls.Add(this.IdStanjeKomentara);
            base.Controls.Add(this.textBox2);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.minus);
            base.Controls.Add(this.plus);
            base.Controls.Add(this.TekstKomentara);
            base.Controls.Add(this.Autor);
            base.Margin = new Padding(3, 8, 3, 8);
            base.Name = "PrikazPojedinacnogKomentara";
            base.Size = new Size(600, 130);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void minus_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.glasao == 0)
                {
                    this.RealanMinus = int.Parse(this.minus.Text);
                    this.BrojMinus = int.Parse(this.textBox2.Text);
                    if (this.MinusWasClicked != null)
                    {
                        this.MinusWasClicked(this, EventArgs.Empty);
                    }
                    if (this.BrojMinus == 0)
                    {
                        this.IdStanjeKomentara.Text = "AUTOMATSKO GLASANJE";
                        this.IdStanjeKomentara.BackColor = Color.Red;
                    }
                    else
                    {
                        this.IdStanjeKomentara.Text = "U TOKU GLASANJE";
                        this.IdStanjeKomentara.BackColor = Color.GreenYellow;
                    }
                    this.textBox1.Visible = false;
                    this.textBox2.Visible = false;
                    this.glasao = 1;
                }
            }
            catch
            {
            }
        }

        public void OznaciKontrolu()
        {
            this.TekstKomentara.BackColor = Color.Tan;
            this.Autor.BackColor = Color.Tan;
            this.plus.BackColor = Color.Tan;
            this.minus.BackColor = Color.Tan;
        }

        private void plus_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.glasao == 0)
                {
                    this.RealanPlus = int.Parse(this.plus.Text);
                    this.BrojPlus = int.Parse(this.textBox1.Text);
                    if (this.PlusWasClicked != null)
                    {
                        this.PlusWasClicked(this, EventArgs.Empty);
                    }
                    if (this.BrojPlus == 0)
                    {
                        this.IdStanjeKomentara.Text = "AUTOMATSKO GLASANJE";
                        this.IdStanjeKomentara.BackColor = Color.Red;
                    }
                    else
                    {
                        this.IdStanjeKomentara.Text = "U TOKU GLASANJE";
                        this.IdStanjeKomentara.BackColor = Color.GreenYellow;
                    }
                    this.textBox1.Visible = false;
                    this.textBox2.Visible = false;
                    this.glasao = 1;
                }
            }
            catch
            {
            }
        }

        public void Pocetak(string tekst, string autortekst, int plustekst, int minustekst, string idkom)
        {
            this.TekstKomentara.Text = tekst;
            if (tekst.StartsWith("@"))
            {
                this.TekstKomentara.BackColor = Color.WhiteSmoke;
            }
            this.Autor.Text = autortekst;
            this.plus.Text = plustekst.ToString();
            this.minus.Text = minustekst.ToString();
            this.IdStanjeKomentara.Text = this.idkommmm = idkom;
        }

        public void SkiniBoju()
        {
            if (this.TekstKomentara.Text.StartsWith("@"))
            {
                this.TekstKomentara.BackColor = Color.WhiteSmoke;
            }
            else
            {
                this.TekstKomentara.BackColor = Color.White;
            }
            this.Autor.BackColor = Color.Wheat;
            this.plus.BackColor = Color.LightYellow;
            this.minus.BackColor = Color.MistyRose;
        }

        public void Utoku(int vrsta)
        {
            if (vrsta == 0)
            {
                this.IdStanjeKomentara.Text = "AUTOMATSKO GLASANJE";
                this.IdStanjeKomentara.BackColor = Color.Red;
                this.textBox1.Visible = false;
                this.textBox2.Visible = false;
                this.glasao = 1;
            }
            if (vrsta == 1)
            {
                this.IdStanjeKomentara.Text = "U TOKU GLASANJE";
                this.IdStanjeKomentara.BackColor = Color.GreenYellow;
                this.textBox1.Visible = false;
                this.textBox2.Visible = false;
                this.glasao = 1;
            }
            if (vrsta == 2)
            {
                this.IdStanjeKomentara.Text = this.IdKomentara;
                this.IdStanjeKomentara.BackColor = Color.White;
                this.textBox1.Visible = true;
                this.textBox2.Visible = true;
                this.glasao = 0;
            }
        }
    }
}

