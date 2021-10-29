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
    /// Interaction logic for insertwin.xaml
    /// </summary>
    public partial class insertwin : Window
    {
        public insertwin()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Image_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void TextBox_GotFocus_1(object sender, RoutedEventArgs e)
        {
            TextBox te = (TextBox)sender;
            if (te.Text.ToString() == "نام محصول")
            {
                textb1.Visibility = System.Windows.Visibility.Visible;
            }
            else if (te.Text.ToString() == "قیمت")
            {
                textb2.Visibility = System.Windows.Visibility.Visible;
            }
            else if (te.Text.ToString() == "کد محصول")
            {
                textb3.Visibility = System.Windows.Visibility.Visible;
            }
            te.Clear();
            
        }

        private void TextBox_LostFocus_1(object sender, RoutedEventArgs e)
        {
            TextBox te=(TextBox)sender;
            if (te.Text == "")
            {
                te.Text = "نام محصول";
                textb1.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        private void TextBox_LostFocus_2(object sender, RoutedEventArgs e)
        {
            TextBox te = (TextBox)sender;
            if (te.Text == "")
            {
                te.Text = "قیمت";
                textb2.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        private void TextBox_LostFocus_3(object sender, RoutedEventArgs e)
        {
            TextBox te = (TextBox)sender;
            if (te.Text == "")
            {
                te.Text = "کد محصول";
                textb3.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void Image_PreviewMouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int.Parse(textbo2.Text.ToString());
                SQLiteConnection con = new SQLiteConnection(@"Data Source=db.db");
                SQLiteCommand com = new SQLiteCommand("INSERT INTO mah VALUES('" + textbo1.Text.ToString() + "','" + textbo2.Text.ToString() + "','" + textbo3.Text.ToString() + "','','0','');", con);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                clear();
            }
            catch
            {
                Form3 p = new Form3();
                p.label1.Text = "ورودی غیر منطقی";
                System.Drawing.Font fnt = new System.Drawing.Font("Mj_Ashgar", 16);
                p.label1.Font = fnt;
                p.ShowDialog();
            }
        }


        public void clear()
        {
            textbo1.Text = "نام محصول";
            textbo2.Text = "قیمت";
            textbo3.Text = "کد محصول";
            textb1.Visibility = System.Windows.Visibility.Hidden;
            textb2.Visibility = System.Windows.Visibility.Hidden;
            textb3.Visibility = System.Windows.Visibility.Hidden;
        }

        private void TextBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                textb2.Focus();
            }
        }

        private void textbo2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                textb3.Focus();
            }
        }

        private void textbo3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (textbo1.Text == "")
                {
                    textbo1.Focus();
                }
                if (textbo2.Text == "")
                {
                    textbo2.Focus();
                }
                else
                {

                }
            }
        }

        private void Image_PreviewMouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            View view = new View();
            view.ShowDialog();
        }
    }
}
