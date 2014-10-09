namespace InternetTim.Problem
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Net;
    using System.Net.Mail;
    using System.Windows.Forms;

    public class PosaljiProblem : Form
    {
        private IContainer components = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button PosaljiPorukuNaMail;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;

        public PosaljiProblem()
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(PosaljiProblem));
            this.textBox1 = new TextBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.textBox2 = new TextBox();
            this.label3 = new Label();
            this.textBox3 = new TextBox();
            this.PosaljiPorukuNaMail = new Button();
            base.SuspendLayout();
            this.textBox1.Location = new Point(12, 0x1d);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x2f7, 20);
            this.textBox1.TabIndex = 0;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0xd7, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ime, prezime, opština, e-mail, mobilni telefon.";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(13, 0x34);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x4c, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Naslov poruke";
            this.textBox2.Location = new Point(12, 0x44);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(0x2f7, 20);
            this.textBox2.TabIndex = 2;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(13, 0x5b);
            this.label3.Name = "label3";
            this.label3.Size = new Size(70, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tekst poruke";
            this.textBox3.Location = new Point(12, 0x6b);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Size(0x2f7, 0x1eb);
            this.textBox3.TabIndex = 4;
            this.PosaljiPorukuNaMail.Cursor = Cursors.Hand;
            this.PosaljiPorukuNaMail.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.PosaljiPorukuNaMail.Location = new Point(12, 0x25c);
            this.PosaljiPorukuNaMail.Name = "PosaljiPorukuNaMail";
            this.PosaljiPorukuNaMail.Size = new Size(0x2f7, 0x2d);
            this.PosaljiPorukuNaMail.TabIndex = 6;
            this.PosaljiPorukuNaMail.Text = "POŠALJI PORUKU";
            this.PosaljiPorukuNaMail.UseVisualStyleBackColor = true;
            this.PosaljiPorukuNaMail.Click += new EventHandler(this.PosaljiPorukuNaMail_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x310, 0x295);
            base.Controls.Add(this.PosaljiPorukuNaMail);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.textBox3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.textBox2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.textBox1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "PosaljiProblem";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Prijavi problem";
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void PosaljiPorukuNaMail_Click(object sender, EventArgs e)
        {
            if (((this.textBox1.Text.Length > 3) && (this.textBox2.Text.Length > 3)) && (this.textBox3.Text.Length > 3))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string machineName = Environment.MachineName;
                    string str2 = "";
                    str2 = ((str2 + "Poruku poslao:\n" + this.textBox1.Text + "\n\n") + "Naslov poruke:\n" + this.textBox2.Text + "\n\n") + "Tekst poruke:\n" + this.textBox3.Text + "\n\n";
                    MailAddress from = new MailAddress("slanjeizvestajaitreports@gmail.com", machineName);
                    MailAddress to = new MailAddress("itprimanjeizvestaja@gmail.com", "za it");
                    string password = "warcraft83";
                    string str4 = "";
                    str4 = "Prijavljen problem: " + machineName;
                    string str5 = str2;
                    SmtpClient client = new SmtpClient {
                        Host = "smtp.gmail.com",
                        Port = 0x24b,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(from.Address, password),
                        Timeout = 0xea60
                    };
                    MailMessage message2 = new MailMessage(from, to) {
                        Subject = str4,
                        Body = str5
                    };
                    using (MailMessage message = message2)
                    {
                        client.Send(message);
                    }
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Poruka je uspešno poslata.", "INFO");
                    base.Close();
                }
                catch
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Dogodila se greška.\n Poruka nije mogla biti poslata.\nProverite da li internet radi ili pokušajte kasnije.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    base.Close();
                }
            }
            else
            {
                MessageBox.Show("Ubacite podatke", "INFO");
            }
        }
    }
}

