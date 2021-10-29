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
    public partial class Form3 : Form
    {
        public Form3()
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
            panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF1F2A36");
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF1F2A36");
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

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialRaisedButton1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void materialRaisedButton1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

    }
}
