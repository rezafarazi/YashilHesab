using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SQLite;

namespace rest
{
    /// <summary>
    /// Interaction logic for Editwin.xaml
    /// </summary>
    public partial class Editwin : Window
    {
        public Editwin()
        {
            InitializeComponent();

            reff();
            
        }




        public void reff()
        {
            try
            {
                Form1 frm = new Form1();
                SQLiteConnection con = new SQLiteConnection(@"Data Source=db.db");
                con.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM noe;", con);

                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds);
                frm.dataGridView1.DataSource = ds.Tables[0];
                con.Close();

                for (int a = 0; a < frm.dataGridView1.RowCount - 1; a++)
                    combo.Items.Add(frm.dataGridView1.Rows[a].Cells[0].Value.ToString());
                combo.Text = frm.dataGridView1.Rows[0].Cells[0].Value.ToString();
            }
            catch { }
        }



        private void TextBox_GotFocus_1(object sender, RoutedEventArgs e)
        {
            TextBox te = (TextBox)sender;
            te.Clear();
        }

        private void Rectangle_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Image_PreviewMouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void name_LostFocus(object sender, RoutedEventArgs e)
        {
            if (name.Text == "")
            name.Text = "نام محصول";
        }

        private void val_LostFocus(object sender, RoutedEventArgs e)
        {
            if (val.Text == "")
            val.Text = "قیمت";
        }

        private void code_LostFocus(object sender, RoutedEventArgs e)
        {
            if(code.Text=="")
            code.Text = "کد محصول";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Form1 frm = new Form1();
            frm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(clo);
            frm.ShowDialog();
        }

        public void clo(object sender, EventArgs e)
        {
            combo.Items.Clear();
            reff();
        }

        private void Image_PreviewMouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int.Parse(val.Text.ToString());
                SQLiteConnection con = new SQLiteConnection(@"Data Source=db.db");
                SQLiteCommand com = new SQLiteCommand("UPDATE mah SET name='" + name.Text.ToString() + "',val='" + val.Text.ToString() + "',noe='" + combo.Text.ToString() + "',toz='" + ri.Text.ToString() + "' WHERE num='" + code.Text.ToString() + "';", con);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                this.Close();
            }
            catch
            {
                Form3 p = new Form3();
                p.label1.Text = "ورودی غیرمنطقی";
                System.Drawing.Font fnt = new System.Drawing.Font("Mj_Ashgar", 16);
                p.label1.Font = fnt;
                p.ShowDialog();
            }
        }
    }
}
