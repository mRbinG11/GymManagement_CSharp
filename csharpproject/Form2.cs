using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu;
using BunifuAnimatorNS;

namespace csharpproject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Size = new Size(800, 500);
            bunifuFlatButton6.Text = bunifuFlatButton1.Text;
            bunifuFlatButton6.Iconimage = bunifuFlatButton1.Iconimage;
            userControl11.Visible = true;
            userControl21.Visible = false;
            userControl31.Visible = false;
            userControl41.Visible = false;
            userControl51.Visible = false;
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            if (bunifuGradientPanel2.Width == 60)
                bunifuGradientPanel2.Width = 200;
            else
                bunifuGradientPanel2.Width = 60;
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            bunifuFlatButton6.Text = bunifuFlatButton1.Text;
            bunifuFlatButton6.Iconimage = bunifuFlatButton1.Iconimage;
            userControl11.Visible = true;
            userControl21.Visible = false;
            userControl31.Visible = false;
            userControl41.Visible = false;
            userControl51.Visible = false;
        }
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            bunifuFlatButton6.Text = bunifuFlatButton2.Text;
            bunifuFlatButton6.Iconimage = bunifuFlatButton2.Iconimage;
            userControl11.Visible = false;
            userControl21.Visible = true;
            userControl31.Visible = false;
            userControl41.Visible = false;
            userControl51.Visible = false;
        }
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            bunifuFlatButton6.Text = bunifuFlatButton3.Text;
            bunifuFlatButton6.Iconimage = bunifuFlatButton3.Iconimage;
            userControl11.Visible = false;
            userControl21.Visible = false;
            userControl31.Visible = true;
            userControl41.Visible = false;
            userControl51.Visible = false;
        }
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            bunifuFlatButton6.Text = bunifuFlatButton4.Text;
            bunifuFlatButton6.Iconimage = bunifuFlatButton4.Iconimage;
            userControl11.Visible = false;
            userControl21.Visible = false;
            userControl31.Visible = false;
            userControl41.Visible = true;
            userControl51.Visible = false;
        }
        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            bunifuFlatButton6.Text = bunifuFlatButton7.Text;
            bunifuFlatButton6.Iconimage = bunifuFlatButton7.Iconimage;
            userControl11.Visible = false;
            userControl21.Visible = false;
            userControl31.Visible = false;
            userControl41.Visible = false;
            userControl51.Visible = true;
        }
        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}