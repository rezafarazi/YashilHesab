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
    public partial class Form1 : Form
    {
        public Form1()
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





            reff();
            
        }


        public void reff()
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=db.db");
            con.Open();
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM noe", con);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            
            dataGridView1.DataSource = ds.Tables[0];
            

            con.Close();
            listBox1.Items.Clear();
            for (int a = 0; a < dataGridView1.RowCount - 1; a++)
                listBox1.Items.Add(dataGridView1.Rows[a].Cells[0].Value.ToString());
            
            
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

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#E87E31");
            panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF293541");
            textBox1.TextAlign = HorizontalAlignment.Center;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection con = new SQLiteConnection(@"Data Source=db.db");
                SQLiteCommand com = new SQLiteCommand("INSERT INTO noe VALUES('" + textBox1.Text + "');", con);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                reff();
            }
            catch
            {
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.SelectedItem.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection con = new SQLiteConnection(@"Data Source=db.db");
                SQLiteCommand com = new SQLiteCommand("DELETE FROM noe WHERE name='" + textBox1.Text + "';", con);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                reff();
                textBox1.Clear();
            }
            catch { }
        }
    }
}
