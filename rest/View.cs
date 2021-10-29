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

namespace rest
{
    public partial class View : Form
    {


        int a, b, c;


        public View()
        {
            InitializeComponent();
            panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF293541");
            dataGridView1.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#FF293541");
            dataGridView1.GridColor = System.Drawing.ColorTranslator.FromHtml("#FF293541");
            textBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#E87E31");
            textBox1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFF");
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#E87E31");
            Rectangle Bounds = new Rectangle(0, 0, this.Width, this.Height);
            int CornerRadius = 20;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(Bounds.X, Bounds.Y, CornerRadius, CornerRadius, 180, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y, CornerRadius, CornerRadius, 270, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            path.AddArc(Bounds.X, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            path.CloseAllFigures();

            this.Region = new Region(path);

            a = 0x84;
            b = 0x1;
            c = 0x2;







            
        }


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




        private void View_Load(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=db.db");
            con.Open();
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM mah", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
            dataGridView1.Columns[0].HeaderText = "نام محصول";
            dataGridView1.Columns[1].HeaderText = "قیمت";
            dataGridView1.Columns[2].HeaderText = "کد محصول";
            dataGridView1.Columns[3].HeaderText = "توضيحات";
            dataGridView1.Columns[4].HeaderText = "تعداد فروش";
            dataGridView1.Columns[5].HeaderText = "نوع";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for (int a = 0; a < dataGridView1.RowCount-1; a++)
            {
                if (dataGridView1.Rows[a].Cells[2].Value.ToString() == textBox1.Text.ToString())
                {
                    button4.Enabled = true;
                    button2.Enabled = true;
                    break;
                }
                else
                {
                    button4.Enabled = false;
                    button2.Enabled = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str="";
            if (button1.Text == "جست و جو")
            {
                try
                {
                    
                    int col = dataGridView1.RowCount;
                    for (int a = 0; a < col; a++)
                    {
                        for (int b = 0; b < 3; b++)
                        {
                            if (dataGridView1.Rows[a].Cells[b].Value.ToString() == textBox1.Text)
                            {
                                str = dataGridView1.Rows[a].Cells[2].Value.ToString();
                                button1.Text = "پاک کردن";
                                break;
   
                            }

                        }
                    }
                    
                }
                catch
                {
                }

                SQLiteConnection con = new SQLiteConnection(@"Data Source=db.db");
                SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM mah WHERE num='"+str+"';", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                dataGridView1.Columns[0].HeaderText = "نام محصول";
                dataGridView1.Columns[1].HeaderText = "قیمت";
                dataGridView1.Columns[2].HeaderText = "کد محصول";
                dataGridView1.Columns[3].HeaderText = "توضيحات";
                dataGridView1.Columns[4].HeaderText = "تعداد فروش";
                dataGridView1.Columns[5].HeaderText = "نوع";
            }
            else
            {

                button1.Text = "جست و جو";
                SQLiteConnection con = new SQLiteConnection(@"Data Source=db.db");
                con.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM mah", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
                dataGridView1.Columns[0].HeaderText = "نام محصول";
                dataGridView1.Columns[1].HeaderText = "قیمت";
                dataGridView1.Columns[2].HeaderText = "کد محصول";
                dataGridView1.Columns[3].HeaderText = "توضيحات";
                dataGridView1.Columns[4].HeaderText = "تعداد فروش";
                dataGridView1.Columns[5].HeaderText = "نوع";
                textBox1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection("Data Source=db.db");
            SQLiteCommand com = new SQLiteCommand("DELETE FROM mah WHERE num='"+textBox1.Text+"';", con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            con.Open();
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM mah", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
            dataGridView1.Columns[0].HeaderText = "نام محصول";
            dataGridView1.Columns[1].HeaderText = "قیمت";
            dataGridView1.Columns[2].HeaderText = "کد محصول";
            dataGridView1.Columns[3].HeaderText = "توضيحات";
            dataGridView1.Columns[4].HeaderText = "تعداد فروش";
            dataGridView1.Columns[5].HeaderText = "نوع";
            textBox1.Clear();
            button2.Enabled = false;
            button4.Enabled = false;
        }

        string name = "", val = "", num = "", toz = "", tid = "", noe = "";


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            name = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            val = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            num = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            toz = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            tid = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            noe = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            button4.Enabled = true;
            button5.Enabled = true;
            button2.Enabled = true;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection("Data Source=db.db");
            SQLiteCommand com = new SQLiteCommand("DELETE FROM mah;", con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            con.Open();
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM mah", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

            dataGridView1.Columns[0].HeaderText = "نام محصول";
            dataGridView1.Columns[1].HeaderText = "قیمت";
            dataGridView1.Columns[2].HeaderText = "کد محصول";
            dataGridView1.Columns[3].HeaderText = "توضيحات";
            dataGridView1.Columns[4].HeaderText = "تعداد فروش";
            dataGridView1.Columns[5].HeaderText = "نوع";
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Editwin ed = new Editwin();
            ed.name.Text = name;
            ed.val.Text = val;
            ed.code.Text = num;
            ed.combo.Text = noe;
            ed.ri.Text=toz;
            ed.Closed += new EventHandler(clo);
            ed.ShowDialog();
            button2.Enabled = false;
            button4.Enabled = false;
        }


        public void clo(object sender,EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=db.db");
            con.Open();
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM mah", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
            dataGridView1.Columns[0].HeaderText = "نام محصول";
            dataGridView1.Columns[1].HeaderText = "قیمت";
            dataGridView1.Columns[2].HeaderText = "کد محصول";
            dataGridView1.Columns[3].HeaderText = "توضيحات";
            dataGridView1.Columns[4].HeaderText = "تعداد فروش";
            dataGridView1.Columns[5].HeaderText = "نوع";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            print print = new print();
            print.label6.Text = name;
            print.label7.Text = val;
            print.label8.Text = num;
            print.label9.Text = noe;
            print.label10.Text = toz;
            print.Show();
        }


    }
}
