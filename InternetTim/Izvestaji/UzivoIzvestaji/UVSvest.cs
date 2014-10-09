namespace InternetTim.Izvestaji.UzivoIzvestaji
{
    using HtmlAgilityPack;
    using Infragistics.UltraChart.Resources.Appearance;
    using Infragistics.UltraChart.Shared.Styles;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinChart;
    using InternetTim.Properties;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Windows.Forms;

    public class UVSvest : UserControl
    {
        private BackgroundWorker backgroundWorker1;
        private IContainer components = null;
        public string GlavniID = "99999";
        private string glavnilink = "";
        private Panel panel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private TableLayoutPanel tableLayoutPanel1;
        private int ukupno = 0;
        private UltraButton ultraButton1;
        private UltraChart ultraChart1;

        public UVSvest()
        {
            this.InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int num;
                string str3;
                string str5;
                string argument = (string) e.Argument;
                string html = "";
                using (WebClient client = new WebClient())
                {
                    if (argument.Contains("b92.net"))
                    {
                        client.Encoding = Encoding.GetEncoding(0x4e2);
                    }
                    else
                    {
                        client.Encoding = Encoding.UTF8;
                    }
                    html = client.DownloadString(argument);
                    client.Dispose();
                }
                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(html);
                if (argument.Contains("b92.net"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//span[@class='comment-number']"))
                        {
                            e.Result = node.InnerText;
                            goto Label_0109;
                        }
                    }
                    catch
                    {
                        e.Result = "0";
                    }
                }
            Label_0109:
                if (argument.Contains("blic.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='article_info']"))
                        {
                            num = 0;
                            while (num < node.ChildNodes[1].ChildNodes.Count)
                            {
                                if (node.ChildNodes[1].ChildNodes[num].InnerText.Contains("Komentara"))
                                {
                                    str3 = node.ChildNodes[1].ChildNodes[num].InnerText.Replace("Komentara", "").Replace(":", "").Replace(" ", "");
                                    e.Result = str3;
                                    break;
                                }
                                num++;
                            }
                            goto Label_0252;
                        }
                    }
                    catch
                    {
                        e.Result = "0";
                    }
                }
            Label_0252:
                if (argument.Contains("kurir-info.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//section[@class='comments_module']"))
                        {
                            str3 = node.ChildNodes[1].ChildNodes[1].InnerText.Replace("(", "").Replace(")", "").Replace("Komentari", "").Replace(" ", "");
                            e.Result = str3;
                            goto Label_0345;
                        }
                    }
                    catch
                    {
                        e.Result = "0";
                    }
                }
            Label_0345:
                if (argument.Contains("novosti.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='articleInfo']"))
                        {
                            num = 0;
                            while (num < node.ChildNodes.Count)
                            {
                                if (node.ChildNodes[num].InnerText.Contains("Komentara"))
                                {
                                    str3 = node.ChildNodes[num].InnerText.Replace("\t", "").Replace("\r", "").Replace("\n", "").Replace(":", "").Replace("Komentara", "").Replace(" ", "");
                                    if (str3.Length > 3)
                                    {
                                        e.Result = "0";
                                    }
                                    else
                                    {
                                        e.Result = str3;
                                    }
                                    break;
                                }
                                num++;
                            }
                            goto Label_04CE;
                        }
                    }
                    catch
                    {
                        e.Result = "0";
                    }
                }
            Label_04CE:
                if (argument.Contains("danas.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='komentari']"))
                        {
                            num = 0;
                            while (num < node.ChildNodes.Count)
                            {
                                if (node.ChildNodes[num].InnerText.Contains("Komentari"))
                                {
                                    str3 = node.ChildNodes[num].InnerText.Replace("(", "").Replace(")", "").Replace("\t", "").Replace("\r", "").Replace("\n", "").Replace(":", "").Replace("Komentari", "").Replace(" ", "");
                                    if (str3.Length > 3)
                                    {
                                        e.Result = "0";
                                    }
                                    else
                                    {
                                        e.Result = str3;
                                    }
                                    break;
                                }
                                num++;
                            }
                            goto Label_067D;
                        }
                    }
                    catch
                    {
                        e.Result = "0";
                    }
                }
            Label_067D:
                if (argument.Contains("politika.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='article_info']"))
                        {
                            string[] strArray = node.InnerHtml.Split(new char[] { '>' });
                            foreach (string str4 in strArray)
                            {
                                if (str4.Contains("komentari") || str4.Contains("коментари"))
                                {
                                    str3 = str4;
                                    str3 = str3.Replace("</a", "").Replace("(", "").Replace(")", "").Replace("\t", "").Replace("\r", "").Replace("\n", "").Replace(":", "").Replace("komentari", "").Replace("коментари", "").Replace(" ", "");
                                    e.Result = str3;
                                    break;
                                }
                            }
                            goto Label_083E;
                        }
                    }
                    catch
                    {
                        e.Result = "0";
                    }
                }
            Label_083E:
                if (argument.Contains("rts.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//td[@class='commentRight']"))
                        {
                            for (int i = 0; i < node.ChildNodes.Count; i++)
                            {
                                if (node.ChildNodes[i].Name.Contains("span"))
                                {
                                    str5 = node.ChildNodes[i].InnerText.Replace(" ", "");
                                    e.Result = str5;
                                    break;
                                }
                            }
                            goto Label_093A;
                        }
                    }
                    catch
                    {
                        e.Result = "0";
                    }
                }
            Label_093A:
                if (argument.Contains("telegraf.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='block-comments']"))
                        {
                            str5 = node.InnerText.Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("Ukupno", "").Replace("komentara", "").Replace("Pošaljite", "").Replace("Vaš", "").Replace("komentari", "").Replace("komentar", "").Replace("Svi", "").Replace(@"\...", "");
                            e.Result = str5;
                            goto Label_0AAF;
                        }
                    }
                    catch
                    {
                        e.Result = "0";
                    }
                }
            Label_0AAF:
                if (argument.Contains("alo.rs"))
                {
                    try
                    {
                        foreach (HtmlNode node in (IEnumerable<HtmlNode>) document.DocumentNode.SelectNodes("//div[@class='widgetAutor']"))
                        {
                            for (num = 0; num < node.ChildNodes.Count; num++)
                            {
                                if (node.ChildNodes[num].InnerHtml.Contains("Komentara"))
                                {
                                    str5 = node.ChildNodes[num].InnerHtml.Replace(" ", "").Replace("<strong>", "").Replace("Komentara:", "").Replace("</strong>", "");
                                    e.Result = str5;
                                    break;
                                }
                            }
                            break;
                        }
                        return;
                    }
                    catch
                    {
                        e.Result = "0";
                    }
                }
            }
            catch
            {
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.ukupno = int.Parse(e.Result.ToString());
                this.ultraChart1.DataSource = this.Podaci();
                this.ultraChart1.DataBind();
            }
            catch
            {
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

        public Image DownloadImage(string _URL)
        {
            Image image = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(_URL);
                request.AllowWriteStreamBuffering = true;
                request.UserAgent = "Opera/9.52 (Windows NT 6.0; U; en)";
                request.Referer = "http://www.blic.rs";
                request.Timeout = 0x4e20;
                WebResponse response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                image = Image.FromStream(responseStream);
                responseStream.Close();
                response.Close();
            }
            catch
            {
                return null;
            }
            return image;
        }

        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            PaintElement element = new PaintElement();
            BarChartAppearance appearance2 = new BarChartAppearance();
            ChartTextAppearance item = new ChartTextAppearance();
            GradientEffect effect = new GradientEffect();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.ultraButton1 = new UltraButton();
            this.ultraChart1 = new UltraChart();
            this.panel1 = new Panel();
            this.pictureBox2 = new PictureBox();
            this.pictureBox1 = new PictureBox();
            this.backgroundWorker1 = new BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.ultraChart1.BeginInit();
            this.panel1.SuspendLayout();
            ((ISupportInitialize) this.pictureBox2).BeginInit();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.tableLayoutPanel1.BackColor = Color.Silver;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5f));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 320f));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 6f));
            this.tableLayoutPanel1.Controls.Add(this.ultraButton1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.ultraChart1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Location = new Point(0, 0);
            this.tableLayoutPanel1.Margin = new Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 5f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 5f));
            this.tableLayoutPanel1.Size = new Size(0x45d, 270);
            this.tableLayoutPanel1.TabIndex = 0;
            appearance.BackColor = Color.FromArgb(0xc0, 0xc0, 0xff);
            appearance.BackColor2 = Color.White;
            appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraButton1.Appearance = appearance;
            this.ultraButton1.Dock = DockStyle.Fill;
            this.ultraButton1.Font = new Font("Arial", 18f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.ultraButton1.Location = new Point(0x148, 8);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new Size(780, 0x2c);
            this.ultraButton1.TabIndex = 1;
            this.ultraButton1.Text = "NASLOV";
            this.ultraButton1.UseOsThemes = DefaultableBoolean.False;
            this.ultraChart1.ChartType = ChartType.BarChart;
            this.ultraChart1.Axis.BackColor = Color.FromArgb(0xff, 0xf8, 220);
            element.ElementType = PaintElementType.None;
            element.Fill = Color.FromArgb(0xff, 0xf8, 220);
            this.ultraChart1.Axis.PE = element;
            this.ultraChart1.Axis.X.Extent = 20;
            this.ultraChart1.Axis.X.Labels.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.ultraChart1.Axis.X.Labels.FontColor = Color.Red;
            this.ultraChart1.Axis.X.Labels.HorizontalAlign = StringAlignment.Far;
            this.ultraChart1.Axis.X.Labels.ItemFormatString = "<DATA_VALUE:0>";
            this.ultraChart1.Axis.X.Labels.Layout.Behavior = AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.X.Labels.Orientation = TextOrientation.Horizontal;
            this.ultraChart1.Axis.X.Labels.SeriesLabels.Font = new Font("Verdana", 20.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.ultraChart1.Axis.X.Labels.SeriesLabels.FontColor = Color.DimGray;
            this.ultraChart1.Axis.X.Labels.SeriesLabels.FormatString = "";
            this.ultraChart1.Axis.X.Labels.SeriesLabels.HorizontalAlign = StringAlignment.Far;
            this.ultraChart1.Axis.X.Labels.SeriesLabels.Layout.Behavior = AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.X.Labels.SeriesLabels.Orientation = TextOrientation.VerticalLeftFacing;
            this.ultraChart1.Axis.X.Labels.SeriesLabels.VerticalAlign = StringAlignment.Center;
            this.ultraChart1.Axis.X.Labels.VerticalAlign = StringAlignment.Center;
            this.ultraChart1.Axis.X.LineThickness = 1;
            this.ultraChart1.Axis.X.MajorGridLines.AlphaLevel = 0xff;
            this.ultraChart1.Axis.X.MajorGridLines.Color = Color.Gainsboro;
            this.ultraChart1.Axis.X.MajorGridLines.DrawStyle = LineDrawStyle.Dot;
            this.ultraChart1.Axis.X.MajorGridLines.Visible = true;
            this.ultraChart1.Axis.X.MinorGridLines.AlphaLevel = 0xff;
            this.ultraChart1.Axis.X.MinorGridLines.Color = Color.LightGray;
            this.ultraChart1.Axis.X.MinorGridLines.DrawStyle = LineDrawStyle.Dot;
            this.ultraChart1.Axis.X.MinorGridLines.Visible = false;
            this.ultraChart1.Axis.X.RangeMax = 100.0;
            this.ultraChart1.Axis.X.RangeType = AxisRangeType.Custom;
            this.ultraChart1.Axis.X.TickmarkInterval = 10.0;
            this.ultraChart1.Axis.X.TickmarkStyle = AxisTickStyle.Smart;
            this.ultraChart1.Axis.X.Visible = true;
            this.ultraChart1.Axis.X2.Labels.Font = new Font("Verdana", 7f);
            this.ultraChart1.Axis.X2.Labels.FontColor = Color.Gray;
            this.ultraChart1.Axis.X2.Labels.HorizontalAlign = StringAlignment.Far;
            this.ultraChart1.Axis.X2.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            this.ultraChart1.Axis.X2.Labels.Layout.Behavior = AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.X2.Labels.Orientation = TextOrientation.VerticalLeftFacing;
            this.ultraChart1.Axis.X2.Labels.SeriesLabels.Font = new Font("Verdana", 7f);
            this.ultraChart1.Axis.X2.Labels.SeriesLabels.FontColor = Color.Gray;
            this.ultraChart1.Axis.X2.Labels.SeriesLabels.FormatString = "";
            this.ultraChart1.Axis.X2.Labels.SeriesLabels.HorizontalAlign = StringAlignment.Far;
            this.ultraChart1.Axis.X2.Labels.SeriesLabels.Layout.Behavior = AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.X2.Labels.SeriesLabels.Orientation = TextOrientation.VerticalLeftFacing;
            this.ultraChart1.Axis.X2.Labels.SeriesLabels.VerticalAlign = StringAlignment.Center;
            this.ultraChart1.Axis.X2.Labels.VerticalAlign = StringAlignment.Center;
            this.ultraChart1.Axis.X2.Labels.Visible = false;
            this.ultraChart1.Axis.X2.LineThickness = 1;
            this.ultraChart1.Axis.X2.MajorGridLines.AlphaLevel = 0xff;
            this.ultraChart1.Axis.X2.MajorGridLines.Color = Color.Gainsboro;
            this.ultraChart1.Axis.X2.MajorGridLines.DrawStyle = LineDrawStyle.Dot;
            this.ultraChart1.Axis.X2.MajorGridLines.Visible = true;
            this.ultraChart1.Axis.X2.MinorGridLines.AlphaLevel = 0xff;
            this.ultraChart1.Axis.X2.MinorGridLines.Color = Color.LightGray;
            this.ultraChart1.Axis.X2.MinorGridLines.DrawStyle = LineDrawStyle.Dot;
            this.ultraChart1.Axis.X2.MinorGridLines.Visible = false;
            this.ultraChart1.Axis.X2.TickmarkInterval = 40.0;
            this.ultraChart1.Axis.X2.TickmarkStyle = AxisTickStyle.Smart;
            this.ultraChart1.Axis.X2.Visible = false;
            this.ultraChart1.Axis.Y.Extent = 400;
            this.ultraChart1.Axis.Y.Labels.Font = new Font("Verdana", 24f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.ultraChart1.Axis.Y.Labels.HorizontalAlign = StringAlignment.Far;
            this.ultraChart1.Axis.Y.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.ultraChart1.Axis.Y.Labels.Layout.Behavior = AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.Y.Labels.Orientation = TextOrientation.Horizontal;
            this.ultraChart1.Axis.Y.Labels.SeriesLabels.HorizontalAlign = StringAlignment.Center;
            this.ultraChart1.Axis.Y.Labels.SeriesLabels.Layout.Behavior = AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.Y.Labels.SeriesLabels.Orientation = TextOrientation.VerticalLeftFacing;
            this.ultraChart1.Axis.Y.Labels.SeriesLabels.VerticalAlign = StringAlignment.Center;
            this.ultraChart1.Axis.Y.Labels.SeriesLabels.Visible = false;
            this.ultraChart1.Axis.Y.Labels.VerticalAlign = StringAlignment.Center;
            this.ultraChart1.Axis.Y.LineThickness = 1;
            this.ultraChart1.Axis.Y.MajorGridLines.AlphaLevel = 0xff;
            this.ultraChart1.Axis.Y.MajorGridLines.Color = Color.Gainsboro;
            this.ultraChart1.Axis.Y.MajorGridLines.DrawStyle = LineDrawStyle.Dot;
            this.ultraChart1.Axis.Y.MajorGridLines.Visible = true;
            this.ultraChart1.Axis.Y.MinorGridLines.AlphaLevel = 0xff;
            this.ultraChart1.Axis.Y.MinorGridLines.Color = Color.LightGray;
            this.ultraChart1.Axis.Y.MinorGridLines.DrawStyle = LineDrawStyle.Dot;
            this.ultraChart1.Axis.Y.MinorGridLines.Visible = false;
            this.ultraChart1.Axis.Y.TickmarkStyle = AxisTickStyle.Smart;
            this.ultraChart1.Axis.Y.Visible = true;
            this.ultraChart1.Axis.Y2.Labels.Font = new Font("Verdana", 7f);
            this.ultraChart1.Axis.Y2.Labels.FontColor = Color.Gray;
            this.ultraChart1.Axis.Y2.Labels.HorizontalAlign = StringAlignment.Near;
            this.ultraChart1.Axis.Y2.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.ultraChart1.Axis.Y2.Labels.Layout.Behavior = AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.Y2.Labels.Orientation = TextOrientation.Horizontal;
            this.ultraChart1.Axis.Y2.Labels.SeriesLabels.Font = new Font("Verdana", 7f);
            this.ultraChart1.Axis.Y2.Labels.SeriesLabels.FontColor = Color.Gray;
            this.ultraChart1.Axis.Y2.Labels.SeriesLabels.HorizontalAlign = StringAlignment.Center;
            this.ultraChart1.Axis.Y2.Labels.SeriesLabels.Layout.Behavior = AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.Y2.Labels.SeriesLabels.Orientation = TextOrientation.VerticalLeftFacing;
            this.ultraChart1.Axis.Y2.Labels.SeriesLabels.VerticalAlign = StringAlignment.Center;
            this.ultraChart1.Axis.Y2.Labels.VerticalAlign = StringAlignment.Center;
            this.ultraChart1.Axis.Y2.Labels.Visible = false;
            this.ultraChart1.Axis.Y2.LineThickness = 1;
            this.ultraChart1.Axis.Y2.MajorGridLines.AlphaLevel = 0xff;
            this.ultraChart1.Axis.Y2.MajorGridLines.Color = Color.Gainsboro;
            this.ultraChart1.Axis.Y2.MajorGridLines.DrawStyle = LineDrawStyle.Dot;
            this.ultraChart1.Axis.Y2.MajorGridLines.Visible = true;
            this.ultraChart1.Axis.Y2.MinorGridLines.AlphaLevel = 0xff;
            this.ultraChart1.Axis.Y2.MinorGridLines.Color = Color.LightGray;
            this.ultraChart1.Axis.Y2.MinorGridLines.DrawStyle = LineDrawStyle.Dot;
            this.ultraChart1.Axis.Y2.MinorGridLines.Visible = false;
            this.ultraChart1.Axis.Y2.TickmarkStyle = AxisTickStyle.Smart;
            this.ultraChart1.Axis.Y2.Visible = false;
            this.ultraChart1.Axis.Z.Labels.Font = new Font("Verdana", 7f);
            this.ultraChart1.Axis.Z.Labels.FontColor = Color.DimGray;
            this.ultraChart1.Axis.Z.Labels.HorizontalAlign = StringAlignment.Near;
            this.ultraChart1.Axis.Z.Labels.ItemFormatString = "";
            this.ultraChart1.Axis.Z.Labels.Layout.Behavior = AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.Z.Labels.Orientation = TextOrientation.Horizontal;
            this.ultraChart1.Axis.Z.Labels.SeriesLabels.Font = new Font("Verdana", 7f);
            this.ultraChart1.Axis.Z.Labels.SeriesLabels.FontColor = Color.DimGray;
            this.ultraChart1.Axis.Z.Labels.SeriesLabels.HorizontalAlign = StringAlignment.Near;
            this.ultraChart1.Axis.Z.Labels.SeriesLabels.Layout.Behavior = AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.Z.Labels.SeriesLabels.Orientation = TextOrientation.Horizontal;
            this.ultraChart1.Axis.Z.Labels.SeriesLabels.VerticalAlign = StringAlignment.Center;
            this.ultraChart1.Axis.Z.Labels.VerticalAlign = StringAlignment.Center;
            this.ultraChart1.Axis.Z.Labels.Visible = false;
            this.ultraChart1.Axis.Z.LineThickness = 1;
            this.ultraChart1.Axis.Z.MajorGridLines.AlphaLevel = 0xff;
            this.ultraChart1.Axis.Z.MajorGridLines.Color = Color.Gainsboro;
            this.ultraChart1.Axis.Z.MajorGridLines.DrawStyle = LineDrawStyle.Dot;
            this.ultraChart1.Axis.Z.MajorGridLines.Visible = true;
            this.ultraChart1.Axis.Z.MinorGridLines.AlphaLevel = 0xff;
            this.ultraChart1.Axis.Z.MinorGridLines.Color = Color.LightGray;
            this.ultraChart1.Axis.Z.MinorGridLines.DrawStyle = LineDrawStyle.Dot;
            this.ultraChart1.Axis.Z.MinorGridLines.Visible = false;
            this.ultraChart1.Axis.Z.TickmarkStyle = AxisTickStyle.Smart;
            this.ultraChart1.Axis.Z.Visible = false;
            this.ultraChart1.Axis.Z2.Labels.Font = new Font("Verdana", 7f);
            this.ultraChart1.Axis.Z2.Labels.FontColor = Color.Gray;
            this.ultraChart1.Axis.Z2.Labels.HorizontalAlign = StringAlignment.Near;
            this.ultraChart1.Axis.Z2.Labels.ItemFormatString = "";
            this.ultraChart1.Axis.Z2.Labels.Layout.Behavior = AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.Z2.Labels.Orientation = TextOrientation.Horizontal;
            this.ultraChart1.Axis.Z2.Labels.SeriesLabels.Font = new Font("Verdana", 7f);
            this.ultraChart1.Axis.Z2.Labels.SeriesLabels.FontColor = Color.Gray;
            this.ultraChart1.Axis.Z2.Labels.SeriesLabels.HorizontalAlign = StringAlignment.Near;
            this.ultraChart1.Axis.Z2.Labels.SeriesLabels.Layout.Behavior = AxisLabelLayoutBehaviors.Auto;
            this.ultraChart1.Axis.Z2.Labels.SeriesLabels.Orientation = TextOrientation.VerticalLeftFacing;
            this.ultraChart1.Axis.Z2.Labels.SeriesLabels.VerticalAlign = StringAlignment.Center;
            this.ultraChart1.Axis.Z2.Labels.VerticalAlign = StringAlignment.Center;
            this.ultraChart1.Axis.Z2.Labels.Visible = false;
            this.ultraChart1.Axis.Z2.LineThickness = 1;
            this.ultraChart1.Axis.Z2.MajorGridLines.AlphaLevel = 0xff;
            this.ultraChart1.Axis.Z2.MajorGridLines.Color = Color.Gainsboro;
            this.ultraChart1.Axis.Z2.MajorGridLines.DrawStyle = LineDrawStyle.Dot;
            this.ultraChart1.Axis.Z2.MajorGridLines.Visible = true;
            this.ultraChart1.Axis.Z2.MinorGridLines.AlphaLevel = 0xff;
            this.ultraChart1.Axis.Z2.MinorGridLines.Color = Color.LightGray;
            this.ultraChart1.Axis.Z2.MinorGridLines.DrawStyle = LineDrawStyle.Dot;
            this.ultraChart1.Axis.Z2.MinorGridLines.Visible = false;
            this.ultraChart1.Axis.Z2.TickmarkStyle = AxisTickStyle.Smart;
            this.ultraChart1.Axis.Z2.Visible = false;
            this.ultraChart1.BackgroundImageLayout = ImageLayout.Center;
            item.ChartTextFont = new Font("Arial", 20.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            item.Column = -2;
            item.HorizontalAlign = StringAlignment.Far;
            item.ItemFormatString = "<DATA_VALUE:0>";
            item.Row = -2;
            item.Visible = true;
            appearance2.ChartText.Add(item);
            this.ultraChart1.BarChart = appearance2;
            this.ultraChart1.ColorModel.AlphaLevel = 150;
            this.ultraChart1.ColorModel.ColorBegin = Color.Pink;
            this.ultraChart1.ColorModel.ColorEnd = Color.DarkRed;
            this.ultraChart1.ColorModel.ModelStyle = ColorModels.CustomLinear;
            this.ultraChart1.Dock = DockStyle.Fill;
            this.ultraChart1.Effects.Effects.Add(effect);
            this.ultraChart1.EmptyChartText = "Učitavanje podataka...";
            this.ultraChart1.Legend.Location = LegendLocation.Left;
            this.ultraChart1.Location = new Point(0x148, 0x3a);
            this.ultraChart1.Name = "ultraChart1";
            this.ultraChart1.Size = new Size(780, 0xcc);
            this.ultraChart1.TabIndex = 2;
            this.ultraChart1.Tooltips.HighlightFillColor = Color.DimGray;
            this.ultraChart1.Tooltips.HighlightOutlineColor = Color.DarkGray;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(5, 5);
            this.panel1.Margin = new Padding(0);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 2);
            this.panel1.Size = new Size(320, 260);
            this.panel1.TabIndex = 3;
            this.pictureBox2.BackColor = Color.Sienna;
            this.pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            this.pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox2.Location = new Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(100, 50);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox1.BackColor = Color.Maroon;
            this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            this.pictureBox1.Dock = DockStyle.Fill;
            this.pictureBox1.Location = new Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(320, 260);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.tableLayoutPanel1);
            base.Margin = new Padding(10, 15, 3, 0);
            base.Name = "UVSvest";
            base.Size = new Size(0x45d, 270);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ultraChart1.EndInit();
            this.panel1.ResumeLayout(false);
            ((ISupportInitialize) this.pictureBox2).EndInit();
            ((ISupportInitialize) this.pictureBox1).EndInit();
            base.ResumeLayout(false);
        }

        public void Pocetak(string id, string link, int start, string naslov, string slika, int velicina)
        {
            this.GlavniID = id;
            this.ultraButton1.Text = naslov;
            this.tableLayoutPanel1.ColumnStyles[1].Width = velicina + 20;
            this.glavnilink = link;
            this.pictureBox1.BackgroundImage = this.DownloadImage(slika);
            if (this.pictureBox1.BackgroundImage == null)
            {
                if (link.Contains("b92.net"))
                {
                    this.pictureBox1.BackgroundImage = InternetTim.Properties.Resources.b92logo;
                }
                if (link.Contains("blic.rs"))
                {
                    this.pictureBox1.BackgroundImage = InternetTim.Properties.Resources.bliclogoorig;
                }
                if (link.Contains("kurir-info.rs"))
                {
                    this.pictureBox1.BackgroundImage = InternetTim.Properties.Resources.kurir001;
                }
                if (link.Contains("novosti.rs"))
                {
                    this.pictureBox1.BackgroundImage = InternetTim.Properties.Resources.novostionline;
                }
                if (link.Contains("danas.rs"))
                {
                    this.pictureBox1.BackgroundImage = InternetTim.Properties.Resources.DanasVelika;
                }
                if (link.Contains("telegraf.rs"))
                {
                    this.pictureBox1.BackgroundImage = InternetTim.Properties.Resources.TelegrafVelika;
                }
                if (link.Contains("politika.rs"))
                {
                    this.pictureBox1.BackgroundImage = InternetTim.Properties.Resources.PolitikaVelika;
                }
                if (link.Contains("rts.rs"))
                {
                    this.pictureBox1.BackgroundImage = InternetTim.Properties.Resources.RTSVelika;
                }
                if (link.Contains("alo.rs"))
                {
                    this.pictureBox1.BackgroundImage = InternetTim.Properties.Resources.AloVelika2;
                }
            }
            if (link.Contains("b92.net"))
            {
                this.pictureBox2.BackgroundImage = InternetTim.Properties.Resources.B92;
            }
            if (link.Contains("blic.rs"))
            {
                this.pictureBox2.BackgroundImage = InternetTim.Properties.Resources.BLIC;
            }
            if (link.Contains("kurir-info.rs"))
            {
                this.pictureBox2.BackgroundImage = InternetTim.Properties.Resources.KURIR;
            }
            if (link.Contains("novosti.rs"))
            {
                this.pictureBox2.BackgroundImage = InternetTim.Properties.Resources.NOVOSTI;
            }
            if (link.Contains("danas.rs"))
            {
                this.pictureBox2.BackgroundImage = InternetTim.Properties.Resources.DanasMala;
            }
            if (link.Contains("telegraf.rs"))
            {
                this.pictureBox2.BackgroundImage = InternetTim.Properties.Resources.TelegrafMala;
            }
            if (link.Contains("politika.rs"))
            {
                this.pictureBox2.BackgroundImage = InternetTim.Properties.Resources.PolitikaMala;
            }
            if (link.Contains("rts.rs"))
            {
                this.pictureBox2.BackgroundImage = InternetTim.Properties.Resources.RTSMala;
            }
            if (link.Contains("alo.rs"))
            {
                this.pictureBox2.BackgroundImage = InternetTim.Properties.Resources.AloMala;
            }
            this.backgroundWorker1.RunWorkerAsync(this.glavnilink);
        }

        private DataTable Podaci()
        {
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            try
            {
                WebClient client = new WebClient();
                JsonTextReader reader = new JsonTextReader(new StringReader(client.DownloadString("http://198.199.126.105/ngledovic/Install/InternetTim/php/Komentari/AktuelniZadaci/GetStatsNewsById.php?IdVesti=" + this.GlavniID)));
                int num4 = 0;
                while (reader.Read())
                {
                    if ((reader.Value != null) && (reader.Value.ToString() != "Korisnik"))
                    {
                        switch (num4)
                        {
                            case 0:
                                num = int.Parse(reader.Value.ToString());
                                break;

                            case 1:
                                num2 = int.Parse(reader.Value.ToString());
                                break;

                            case 2:
                                num3 = int.Parse(reader.Value.ToString());
                                break;
                        }
                        num4++;
                        if (num4 == 3)
                        {
                            num4 = 0;
                        }
                    }
                }
            }
            catch
            {
            }
            DataTable table = new DataTable();
            table.Columns.Add("Ukupno komentara", typeof(int));
            table.Columns.Add("Komentarisalo korisnika", typeof(int));
            table.Columns.Add("Poslato komentara", typeof(int));
            table.Columns.Add("Objavljeno komentara", typeof(int));
            object[] values = new object[] { this.ukupno, num3, num2, num };
            int num5 = 10;
            if (num5 <= num2)
            {
                num5 = num2 + 10;
            }
            if (num5 <= this.ukupno)
            {
                num5 = this.ukupno + 10;
            }
            this.ultraChart1.Axis.X.RangeMax = num5;
            this.ultraChart1.Axis.X.RangeMin = 0.0;
            table.Rows.Add(values);
            return table;
        }

        public void PokreniAzuriranje()
        {
            this.backgroundWorker1.RunWorkerAsync(this.glavnilink);
        }
    }
}

