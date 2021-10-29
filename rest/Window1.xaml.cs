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
using System.Globalization;
using System.Data.SQLite;

namespace rest
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Image_PreviewMouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void close_box_main_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void TextBlock_MouseEnter_1(object sender, MouseEventArgs e)
        {
            TextBlock te = (TextBlock)sender;
            BrushConverter l = new BrushConverter();
            te.Background = (Brush)l.ConvertFrom("#1F2A36");
            te.Foreground = (Brush)l.ConvertFrom("#E87E31");
            te.Cursor = Cursors.Hand;
        }

        private void TextBlock_MouseLeave_1(object sender, MouseEventArgs e)
        {
            TextBlock te = (TextBlock)sender;
            BrushConverter l = new BrushConverter();
            te.Background = (Brush)l.ConvertFrom("#293541");
            te.Foreground = (Brush)l.ConvertFrom("#FFFFFF");
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            //Data Source=Data/data.db3;//
            PersianCalendar pc = new PersianCalendar();
            DateTime time = DateTime.Today;
            string date = pc.GetYear(time).ToString() + "/" + pc.GetMonth(time).ToString() + "/" + pc.GetDayOfMonth(time).ToString();
            string timee=DateTime.Now.Hour.ToString()+":"+DateTime.Now.Minute.ToString();
            


            //sqlite//

            SQLiteConnection con = new SQLiteConnection(@"Data Source=db.db");
            SQLiteCommand com = new SQLiteCommand("INSERT INTO log VALUES('"+date+"','"+timee+"','"+System.Windows.Forms.SystemInformation.UserName.ToString()+"');", con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            //sqlite//
        }

        private void TextBlock_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            insertwin inwin=new insertwin();
            inwin.ShowDialog();
        }

        private void TextBlock_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            View ed = new View();
            ed.ShowDialog();
        }

        private void TextBlock_MouseLeftButtonUp_3(object sender, MouseButtonEventArgs e)
        {
            gatir win = new gatir();
            win.ShowDialog();
        }

        private void TextBlock_MouseLeftButtonUp_4(object sender, MouseButtonEventArgs e)
        {
            chart c = new chart();
            this.Hide();
            c.ShowDialog();
            this.Show();
        }
    }
}
