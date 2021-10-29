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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;


namespace rest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Timer time;


        public MainWindow()
        {
            InitializeComponent();
            
            time = new Timer();
            time.Tick += new EventHandler(timer);
            time.Start();
            win1 = new Window1();
            win1.close_box_main.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(close_box_main_PreviewMouseLeftButtonUp);
            win1.Closing += new System.ComponentModel.CancelEventHandler(exit);
            
        }


        public void exit(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Form4 frm = new Form4();
            frm.btnno.Click += new EventHandler(no);
            frm.ShowDialog();
            if (l==true)
            {
                this.Close();
                return;
            }
            e.Cancel = true;
            frm.Dispose();
        }

        bool l = false;

        public void no(object sender,EventArgs e)
        {
            l = true;
            this.Close();
        }


        private void close_box_main_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            win1.Close();
            this.Close();

        }


        int a = 0;
        Window1 win1;
        public void timer(object sender, EventArgs e)
        {
            a++;
            if (a == 5)
            {
                
                this.Hide();
                win1.Show();
                time.Stop();
            }
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }


    }
}
