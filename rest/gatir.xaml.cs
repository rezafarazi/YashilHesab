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
using System.Globalization;

namespace rest
{
    /// <summary>
    /// Interaction logic for gatir.xaml
    /// </summary>
    public partial class gatir : Window
    {
        public gatir()
        {
            InitializeComponent();
            vi();
            
        }


        public void check()
        {
            try
            {
                if (s != "" && combo2.Text.ToString() != "" && t.Text.ToString() != "")
                {
                    img.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    img.Visibility = System.Windows.Visibility.Hidden;
                }

                if (t.Text.ToString() != "" && combo2.Text.ToString() != "")
                {
                    valll.Text = "جمع کل   :  " + (int.Parse(t.Text.ToString()) * (int.Parse(combo2.Text.ToString()))).ToString();
                }
            }
            catch { }

        }

        int sat=0;
        Form2 frm;
        public void vi()
        {
            try
            {
                frm = new Form2();
                SQLiteConnection con = new SQLiteConnection(@"Data Source=db.db");
                con.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM mah;", con);

                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds);
                frm.dataGridView1.DataSource = ds.Tables[0];
                con.Close();

                for (int a = 0; a < frm.dataGridView1.RowCount - 1; a++)
                {
                    combo1.Items.Add(frm.dataGridView1.Rows[a].Cells[0].Value.ToString());
                    
                }
                combo1.Text = frm.dataGridView1.Rows[0].Cells[0].Value.ToString();
                combo2.Text = frm.dataGridView1.Rows[0].Cells[1].Value.ToString();
                lable1.Text = frm.dataGridView1.Rows[0].Cells[2].Value.ToString();
                lable3.Text = frm.dataGridView1.Rows[0].Cells[5].Value.ToString();
                lable5.Text = frm.dataGridView1.Rows[0].Cells[3].Value.ToString();
                sat = int.Parse(frm.dataGridView1.Rows[0].Cells[4].Value.ToString());
            }
            catch { }

        }






        private void mask_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void mask_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Rectangle_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Image_PreviewMouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Image_PreviewMouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            
            try
            {
                sat += int.Parse(t.Text.ToString());
                oncl(combo1.Text.ToString(), combo2.Text.ToString(), s, lable1.Text.ToString(), lable3.Text.ToString(), sat.ToString(),(int.Parse(t.Text.ToString())*int.Parse(combo2.Text.ToString())).ToString());

            }
            catch {
                
                Form3 p = new Form3();
                p.label1.Text = "مشكلي در ورود اطلاعات وجود دارد";
                System.Drawing.Font fnt = new System.Drawing.Font("Mj_Ashgar", 12);
                p.label1.Font = fnt;
                p.ShowDialog();
            }
           
        }




        public void oncl(string str1, string str2, string str3, string str4, string str5,string str6,string str7)
        {
            DateTime date=DateTime.Today;
            PersianCalendar datejal=new PersianCalendar();
            SQLiteConnection con = new SQLiteConnection("Data Source=db.db");
            SQLiteCommand com = new SQLiteCommand("INSERT INTO sef VALUES('" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','"+str7+"','"+datejal.GetYear(date).ToString()+"','"+datejal.GetMonth(date)+"','"+datejal.GetDayOfMonth(date)+"');", con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            
            try
            {
                int.Parse(t.Text.ToString());
                int.Parse(combo2.Text.ToString());
                combo1.Items.Clear();
                vi();
                ch1.IsChecked = false; ch2.IsChecked = false; ch3.IsChecked = false;
                valll.Text = "";
                t.Clear();
            }
            catch
            {
                int.Parse(t.Text.ToString());
                int.Parse(combo2.Text.ToString());
                combo1.Items.Clear();
                vi();
                ch1.IsChecked = false; ch2.IsChecked = false; ch3.IsChecked = false;
                valll.Text = "";
                t.Clear();
            }
        }


        string s = "";

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            RadioButton btnr = (RadioButton)sender;
            s = btnr.Content.ToString();
            check();
        }

        private void combo1_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
        }

        private void combo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            combo1.Text = frm.dataGridView1.Rows[combo1.SelectedIndex].Cells[0].Value.ToString();
            combo2.Text = frm.dataGridView1.Rows[combo1.SelectedIndex].Cells[1].Value.ToString();
            lable1.Text = frm.dataGridView1.Rows[combo1.SelectedIndex].Cells[2].Value.ToString();
            lable3.Text = frm.dataGridView1.Rows[combo1.SelectedIndex].Cells[5].Value.ToString();
            lable5.Text = frm.dataGridView1.Rows[combo1.SelectedIndex].Cells[3].Value.ToString();
            sat = int.Parse(frm.dataGridView1.Rows[combo1.SelectedIndex].Cells[4].Value.ToString());
            check();
        }

        private void combo2_TextChanged(object sender, TextChangedEventArgs e)
        {
            check();
        }

        private void t_TextChanged(object sender, TextChangedEventArgs e)
        {
            check();
            
        }





    }
}
