using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rest
{
    public partial class print : Form
    {
        public print()
        {
            InitializeComponent();
            BackgroundImage = Image.FromFile(Application.StartupPath+"\\pir\\pic.png");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        Bitmap b;
        private void print_Load(object sender, EventArgs e)
        {
            b = new Bitmap(this.Width,this.Height);
            DrawToBitmap(b,new Rectangle(0,0,this.Width,this.Height));
            printDocument1.Print();
            Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(b, new Point(0,0));
        }
    }
}
