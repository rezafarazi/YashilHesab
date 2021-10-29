using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Windows.Forms.DataVisualization.Charting;

namespace rest
{
    public partial class chart : Form
    {
        public chart()
        {
            InitializeComponent();
            Rectangle Bounds = new Rectangle(0, 0, this.Width, this.Height);
            int CornerRadius = 20;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(Bounds.X, Bounds.Y, CornerRadius, CornerRadius, 180, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y, CornerRadius, CornerRadius, 270, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            path.AddArc(Bounds.X, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            path.CloseAllFigures();

            this.Region = new Region(path);
            panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF293541");
            
            panel3.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF1F2A36");



            Font f = new Font("",26, FontStyle.Bold,GraphicsUnit.World);
            label1.Font = f;
            
            
        }

        int a=0x84, b=0x1, c=0x2;



        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (a == m.Msg && b == (int)m.Result)
            {
                m.Result = (IntPtr)c;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Enter(object sender, EventArgs e)
        {
            
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF1F2A36");
            lbl.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFE87E31");
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.BackColor = Color.Transparent;
            lbl.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFF");
        }

        private void chart_Load(object sender, EventArgs e)
        {
            dataes("SELECT * FROM sef",dataGridView1);
            dataes("SELECT num From mah",dataGridView2);
        }

        public void dataes(string str,DataGridView dg)
        {
            SQLiteConnection con = new SQLiteConnection("Data Source=db.db");
            con.Open();
            SQLiteDataAdapter da = new SQLiteDataAdapter(str, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dg.DataSource = ds.Tables[0];
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            chart3.Hide();
            chart2.Hide();
            FlatButton1.Hide();
            FlatButton2.Hide();
            FlatButton3.Hide();
            FlatButton4.Hide();
            FlatButton6.Hide();
            FlatButton5.Hide();
            dataes("SELECT * FROM sef", dataGridView1);
            dataes("SELECT num From mah", dataGridView2);
            int a = dataGridView2.RowCount - 1;
            int[] li = new int[a];
            string []ttaturk = new string[a];
            for (int b = 0; b < a; b++)
            {
                dataes("SELECT * FROM sef WHERE num='"+dataGridView2.Rows[b].Cells[0].Value.ToString()+"';", dataGridView1);
                int o = 0;

                for (int c = 0; c < dataGridView1.RowCount - 1; c++)
                {
                    ttaturk[b] = dataGridView1.Rows[0].Cells[0].Value.ToString();
                    o += int.Parse(dataGridView1.Rows[c].Cells[6].Value.ToString());
                }
                li[b] = o;
            }
            chart1.Titles.Clear();
            chart1.Series.Clear();
            Series sqo = new Series();
            for (int q = 0; q < li.Length; q++)
            {
                sqo.Points.AddXY(ttaturk[q],li[q]);
            }
            sqo.ChartType = SeriesChartType.Pie;
            chart1.Titles.Add("نمودار کلی");
            chart1.Series.Add(sqo);
            chart1.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (label2.Text == "نمودار سفارشی")
            {
                label2.Text = "بستن";
                textBox1.Show();
            }
            else
            {
                label2.Text = "نمودار سفارشی";
                textBox1.Clear();
                textBox1.Hide();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "کد محصول مورد نظر";
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                yuuuuu = textBox1.Text;
                chart3.Hide();
                chart2.Hide();
                FlatButton3.Hide();
                FlatButton4.Hide();
                FlatButton6.Hide();
                FlatButton5.Hide();
                castum();
            }
        }

        public void castum()
        {
            mah();
            FlatButton1.Show();
            FlatButton2.Show();
        }



        public void mah()
        {
            try
            {
                
                label2.Text = "نمودار سفارشی";
                textBox1.Hide();
                dataes("SELECT * FROM sef WHERE num='" + yuuuuu + "';", dataGridView1);

                int far = 0, or = 0, khor = 0, tir = 0, mor = 0, sha = 0, mer = 0, aba = 0, aza = 0, dey = 0, bah = 0, es = 0;



                for (int r = 0; r < dataGridView1.RowCount - 1; r++)
                {
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "1")
                    {
                        far += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "2")
                    {
                        or += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "3")
                    {
                        khor += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "4")
                    {
                        tir += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "5")
                    {
                        mor += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "6")
                    {
                        sha += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "7")
                    {
                       mer += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "8")
                    {
                        aba += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "9")
                    {
                        aza += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "10")
                    {
                       dey += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[2].Value.ToString() == "11")
                    {
                        bah += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "12")
                    {
                        es += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                }



                chart1.Titles.Clear();
                chart1.Series.Clear();
                Series sqo = new Series();

                sqo.Points.AddXY("فروردین", far);
                sqo.Points.AddXY("اردیبهشت", or);
                sqo.Points.AddXY("خرداد", khor);
                sqo.Points.AddXY("مرداد", tir);
                sqo.Points.AddXY("تیر", mor);
                sqo.Points.AddXY("شهریور", sha);
                sqo.Points.AddXY("مهر", mer);
                sqo.Points.AddXY("آبان", aba);
                sqo.Points.AddXY("آذر", aza);
                sqo.Points.AddXY("دی", dey);
                sqo.Points.AddXY("بهمن", bah);
                sqo.Points.AddXY("اسفند", es);

                sqo.ChartType = SeriesChartType.Pie;

                chart1.Titles.Add("نمودار سفارشی    " + dataGridView1.Rows[0].Cells[0].Value.ToString());

                chart1.Series.Add(sqo);

                chart1.Show();



                textBox1.Clear();
            }
            catch
            {

                Form3 p = new Form3();
                p.label1.Text = "کد محصول صحیح نمی باشد";
                Font fnt = new System.Drawing.Font("Mj_Ashgar", 16);
                p.label1.Font = fnt;
                p.ShowDialog();

            }
        }

        string yuuuuu = "";

        public void forrsd()
        {
            try
            {
                
                chart1.Series.Clear();
                label2.Text = "نمودار سفارشی";
                textBox1.Hide();

                dataes("SELECT * FROM sef WHERE num='" + yuuuuu + "';", dataGridView1);

                int ckeck = 0, naghd = 0, parda = 0;



                for (int r = 0; r < dataGridView1.RowCount - 1; r++)
                {
                    if (dataGridView1.Rows[r].Cells[2].Value.ToString() == "پرداخت نقدی")
                    {
                        naghd += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[2].Value.ToString() == "چک")
                    {
                        ckeck += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[2].Value.ToString() == "پراداخت شده")
                    {
                        parda += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                }


                chart1.Titles.Clear();
                chart1.Series.Clear();
                Series sqo = new Series();

                sqo.Points.AddXY("پرداخت با چک", ckeck);
                sqo.Points.AddXY("پرداخت نقد", naghd);
                sqo.Points.AddXY("پرداخت شده", parda);

                sqo.ChartType = SeriesChartType.Pie;

                chart1.Titles.Add("نمودار سفارشی    " + dataGridView1.Rows[0].Cells[0].Value.ToString());

                chart1.Series.Add(sqo);

                chart1.Show();



                textBox1.Clear();
            }
            catch
            {

                Form3 p = new Form3();
                p.label1.Text = "کد محصول صحیح نمی باشد";
                Font fnt = new System.Drawing.Font("Mj_Ashgar", 16);
                p.label1.Font = fnt;
                p.ShowDialog();

            }
        }
    
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (label3.Text == "نمودار مقایسه ای")
            {
                label3.Text = "بستن";
                textBox2.Show();
                textBox3.Show();
                btn.Show();
            }
            else
            {
                label3.Text = "نمودار مقایسه ای";
                textBox2.Hide();
                textBox3.Hide();
                textBox2.Text = "کد محصول اول";
                textBox3.Text = "کد محصول دوم";
                btn.Hide();
                
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "کد محصول اول";
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "کد محصول دوم";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        public void chartt2()
        {
            dataes("SELECT * FROM sef WHERE num='" + textBox2.Text.ToString() + "';", dataGridView1);
                    int ckeck = 0, naghd = 0, parda = 0;
                    for (int r = 0; r < dataGridView1.RowCount - 1; r++)
                    {
                        if (dataGridView1.Rows[r].Cells[2].Value.ToString() == "پرداخت نقدی")
                        {
                            naghd += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                        }
                        if (dataGridView1.Rows[r].Cells[2].Value.ToString() == "چک")
                        {
                            ckeck += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                        }
                        if (dataGridView1.Rows[r].Cells[2].Value.ToString() == "پراداخت شده")
                        {
                            parda += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                        }
                    }
                    chart2.Titles.Clear();
                    chart2.Series.Clear();
                    Series sqo = new Series();
                    sqo.Points.AddXY("پرداخت با چک", ckeck);
                    sqo.Points.AddXY("پرداخت نقد", naghd);
                    sqo.Points.AddXY("پرداخت شده", parda);
                    sqo.ChartType = SeriesChartType.Pie;
                    chart2.Titles.Add("نمودار سفارشی    " + dataGridView1.Rows[0].Cells[0].Value.ToString());
                    chart2.Series.Add(sqo);
                    chart2.Show();
        }

        public void chartt3()
        {
            dataes("SELECT * FROM sef WHERE num='" + textBox3.Text.ToString() + "';", dataGridView1);
            int ckeck = 0, naghd = 0, parda = 0;
            for (int r = 0; r < dataGridView1.RowCount - 1; r++)
            {
                if (dataGridView1.Rows[r].Cells[2].Value.ToString() == "پرداخت نقدی")
                {
                    naghd += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                }
                if (dataGridView1.Rows[r].Cells[2].Value.ToString() == "چک")
                {
                    ckeck += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                }
                if (dataGridView1.Rows[r].Cells[2].Value.ToString() == "پراداخت شده")
                {
                    parda += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                }
            }
            chart3.Titles.Clear();
            chart3.Series.Clear();
            Series sqo = new Series();
            sqo.Points.AddXY("پرداخت با چک", ckeck);
            sqo.Points.AddXY("پرداخت نقد", naghd);
            sqo.Points.AddXY("پرداخت شده", parda);
            sqo.ChartType = SeriesChartType.Pie;
            chart3.Titles.Add("نمودار سفارشی    " + dataGridView1.Rows[0].Cells[0].Value.ToString());
            chart3.Series.Add(sqo);
            chart3.Show();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
           
            chart1.Hide();
            FlatButton1.Hide();
            FlatButton2.Hide();
            FlatButton4.Show();
            FlatButton3.Show();
            FlatButton5.Show();
            FlatButton6.Show();
            try
            {
                chartt2();
                chartt3();
            }
            catch {
                Form3 p = new Form3();
                p.label1.Text = "کد محصول صحیح نمی باشد";
                Font fnt = new System.Drawing.Font("Mj_Ashgar", 16);
                p.label1.Font = fnt;
                p.ShowDialog();
            }
            
           
        }




        public void charttt2()
        {
            try
            {

                label2.Text = "نمودار سفارشی";
                textBox1.Hide();
                dataes("SELECT * FROM sef WHERE num='" + textBox2.Text.ToString() + "';", dataGridView1);

                int far = 0, or = 0, khor = 0, tir = 0, mor = 0, sha = 0, mer = 0, aba = 0, aza = 0, dey = 0, bah = 0, es = 0;



                for (int r = 0; r < dataGridView1.RowCount - 1; r++)
                {
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "1")
                    {
                        far += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "2")
                    {
                        or += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "3")
                    {
                        khor += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "4")
                    {
                        tir += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "5")
                    {
                        mor += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "6")
                    {
                        sha += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "7")
                    {
                        mer += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "8")
                    {
                        aba += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "9")
                    {
                        aza += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "10")
                    {
                        dey += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[2].Value.ToString() == "11")
                    {
                        bah += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "12")
                    {
                        es += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                }



                chart2.Titles.Clear();
                chart2.Series.Clear();
                Series sqo = new Series();

                sqo.Points.AddXY("فروردین", far);
                sqo.Points.AddXY("اردیبهشت", or);
                sqo.Points.AddXY("خرداد", khor);
                sqo.Points.AddXY("مرداد", tir);
                sqo.Points.AddXY("تیر", mor);
                sqo.Points.AddXY("شهریور", sha);
                sqo.Points.AddXY("مهر", mer);
                sqo.Points.AddXY("آبان", aba);
                sqo.Points.AddXY("آذر", aza);
                sqo.Points.AddXY("دی", dey);
                sqo.Points.AddXY("بهمن", bah);
                sqo.Points.AddXY("اسفند", es);

                sqo.ChartType = SeriesChartType.Pie;

                chart2.Titles.Add("نمودار سفارشی    " + dataGridView1.Rows[0].Cells[0].Value.ToString());

                chart2.Series.Add(sqo);

                chart2.Show();



            }
            catch
            {

                Form3 p = new Form3();
                p.label1.Text = "کد محصول صحیح نمی باشد";
                Font fnt = new System.Drawing.Font("Mj_Ashgar", 16);
                p.label1.Font = fnt;
                p.ShowDialog();

            }
        }



        public void charttt3()
        {
            try
            {

                label2.Text = "نمودار سفارشی";
                textBox1.Hide();
                dataes("SELECT * FROM sef WHERE num='" + textBox2.Text.ToString() + "';", dataGridView1);

                int far = 0, or = 0, khor = 0, tir = 0, mor = 0, sha = 0, mer = 0, aba = 0, aza = 0, dey = 0, bah = 0, es = 0;



                for (int r = 0; r < dataGridView1.RowCount - 1; r++)
                {
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "1")
                    {
                        far += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "2")
                    {
                        or += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "3")
                    {
                        khor += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "4")
                    {
                        tir += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "5")
                    {
                        mor += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "6")
                    {
                        sha += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "7")
                    {
                        mer += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "8")
                    {
                        aba += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "9")
                    {
                        aza += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "10")
                    {
                        dey += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[2].Value.ToString() == "11")
                    {
                        bah += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                    if (dataGridView1.Rows[r].Cells[8].Value.ToString() == "12")
                    {
                        es += int.Parse(dataGridView1.Rows[r].Cells[6].Value.ToString());
                    }
                }



                chart3.Titles.Clear();
                chart3.Series.Clear();
                Series sqo = new Series();

                sqo.Points.AddXY("فروردین", far);
                sqo.Points.AddXY("اردیبهشت", or);
                sqo.Points.AddXY("خرداد", khor);
                sqo.Points.AddXY("مرداد", tir);
                sqo.Points.AddXY("تیر", mor);
                sqo.Points.AddXY("شهریور", sha);
                sqo.Points.AddXY("مهر", mer);
                sqo.Points.AddXY("آبان", aba);
                sqo.Points.AddXY("آذر", aza);
                sqo.Points.AddXY("دی", dey);
                sqo.Points.AddXY("بهمن", bah);
                sqo.Points.AddXY("اسفند", es);

                sqo.ChartType = SeriesChartType.Pie;

                chart3.Titles.Add("نمودار سفارشی    " + dataGridView1.Rows[0].Cells[0].Value.ToString());

                chart3.Series.Add(sqo);

                chart3.Show();



            }
            catch
            {

                Form3 p = new Form3();
                p.label1.Text = "کد محصول صحیح نمی باشد";
                Font fnt = new System.Drawing.Font("Mj_Ashgar", 16);
                p.label1.Font = fnt;
                p.ShowDialog();

            }
        }












        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FlatButton2_Click(object sender, EventArgs e)
        {
            mah();
        }

        private void FlatButton1_Click(object sender, EventArgs e)
        {
            forrsd();
        }

        private void FlatButton3_Click(object sender, EventArgs e)
        {
            chartt2();
        }

        private void FlatButton4_Click(object sender, EventArgs e)
        {
            charttt2();
        }

        private void FlatButton6_Click(object sender, EventArgs e)
        {
            charttt3();
        }

        private void FlatButton5_Click(object sender, EventArgs e)
        {
            chartt3();
        }












        private void FlatButton7_Click(object sender, EventArgs e)
        {
        }

        private void FlatButton8_Click(object sender, EventArgs e)
        {

        }





    }
}
