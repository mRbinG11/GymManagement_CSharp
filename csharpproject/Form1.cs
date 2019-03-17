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
    public partial class Form1 : Form
    {
        Timer timer1 = new Timer();
        Timer timer2 = new Timer();
        Label logreg = new Label();
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(320, 480);
            pictureBox1.Top = 50;
        }
        private void FormLoad1(object sender,EventArgs e)
        {
            timer1.Tick += new EventHandler(timer1_go);
            timer2.Tick += new EventHandler(timer2_go);
            timer1.Interval = 10;
            timer2.Interval = 5;
            timer1.Start();
        }
        void timer1_go(object sender,EventArgs e )
        {
            logoposition();
        }
        void timer2_go(object sender,EventArgs e)
        {
            if (logreg.Text == "Register")
            {
                reg();
            }
            else if (logreg.Text == "Login")
            {
                log();
            }

        }
        int go = 1;
        void logoposition()
        {
            if(panel1.Left==0)
            {
                pictureBox1.Top += go;
                if(pictureBox1.Top>50)
                {
                    timer1.Stop();
                }
                panel3.BackColor = Color.DodgerBlue;
                pictureBox1.BackColor = Color.DodgerBlue;
                bunifuCustomLabel1.ForeColor = Color.Black;
            }
            if (panel2.Left==0)
            {
                pictureBox1.Top -= go;
                if(pictureBox1.Top<34)
                {
                    timer1.Stop();
                }
                panel3.BackColor = Color.Black;
                pictureBox1.BackColor = Color.Black;
            }
        }
        void line()
        {
            if(panel1.Left==0)
            {
                bunifuSeparator1.LineThickness = 1;
                bunifuSeparator1.LineColor = Color.White;
                bunifuSeparator2.LineThickness = 2;
                bunifuSeparator2.LineColor = Color.DodgerBlue;
            }
            if(panel2.Left==0)
            {
                bunifuSeparator2.LineThickness = 1;
                bunifuSeparator2.LineColor = Color.White;
                bunifuSeparator1.LineThickness = 2;
                bunifuSeparator1.LineColor = Color.Black;
            }
        }
        int move_speed = 320;
        void reg()
        {
            if(panel2.Left>0)
            {
                timer1.Start();
                line();
                panel1.Left -= move_speed;
                panel2.Left -= move_speed;
                if(panel2.Left==0)
                {
                    timer2.Stop();
                }
            }
        }
        void log()
        {
            if(panel1.Left<0)
            {
                timer1.Start();
                line();
                panel2.Left += move_speed;
                panel1.Left += move_speed;
                if(panel1.Left==0)
                {
                    timer2.Stop();
                }
            }
        }
        void Enter1(object sender,EventArgs e)
        {
            if(textBox1.Text=="Username")
            {
                textBox1.Text = string.Empty;
            }
        }
        void Leave1(object sender,EventArgs e)
        {
            if(textBox1.Text==string.Empty)
            {
                textBox1.Text = "Username";
            }  
        }
        void Enter2(object sender,EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.PasswordChar = '*';
                textBox2.Text = string.Empty;
            }
        }
        void Leave2(object sender,EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                textBox2.PasswordChar = '\0';
                textBox2.Text = "Password";
            }
        }
        void Enter3(object sender, EventArgs e)
        {
            if (textBox3.Text == "Username")
            {
                textBox3.Text = string.Empty;
            }
        }
        void Leave3(object sender, EventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                textBox3.Text = "Username";
            }
        }
        void Enter4(object sender, EventArgs e)
        {
            if (textBox4.Text == "Full Name")
            {
                textBox4.Text = string.Empty;
            }
        }
        void Leave4(object sender, EventArgs e)
        {
            if (textBox4.Text == string.Empty)
            {
                textBox4.Text = "Full Name";
            }
        }
        void Enter5(object sender, EventArgs e)
        {
            if (textBox5.Text == "Password")
            {
                textBox5.PasswordChar = '*';
                textBox5.Text = string.Empty;
            }
        }
        void Leave5(object sender, EventArgs e)
        {
            if (textBox5.Text == string.Empty)
            {
                textBox5.PasswordChar = '\0';
                textBox5.Text = "Password";
            }
        }
        void Enter6(object sender, EventArgs e)
        {
            if (textBox6.Text == "Email id")
            {
                textBox6.Text = string.Empty;
            }
        }
        void Leave6(object sender, EventArgs e)
        {
            if (textBox6.Text == string.Empty)
            {
                textBox6.Text = "Email id";
            }
        }
        private void Register(object sender, EventArgs e)
        {
            Label lr = (Label)sender;
            logreg = lr;
            timer2.Start();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Label lr = (Label)sender;
            timer2.Start();
            line();
            reg();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Label lr = (Label)sender;
            timer2.Start();
            line();
            log();
        }
        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=MR-BING-PC\\SQLEXPRESS01; database=csharpproj;integrated security=SSPI");
            SqlCommand cmd = new SqlCommand("select * from dbo.admins", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            if(rdr.HasRows==true)
            {
                while (rdr.Read())
                {
                    string uname = rdr["username"].ToString();
                    string pswd = rdr["password"].ToString();
                    if (textBox1.Text == uname && textBox2.Text == pswd)
                    {
                        this.Hide();
                        Form2 f2 = new Form2();
                        f2.Show();
                    }
                    else if(textBox1.Text != uname && textBox2.Text != pswd)
                    {
                        bunifuCustomLabel1.ForeColor = Color.DodgerBlue;
                    }
                }
            }
        }
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "Full Name" && textBox3.Text != "Username" && textBox6.Text != "Email id" && textBox5.Text != "Password")
            {
                SqlConnection con = new SqlConnection("data source=MR-BING-PC\\SQLEXPRESS01; database=csharpproj;integrated security=SSPI");
                SqlCommand cmd = new SqlCommand("insert into dbo.padmins values(@fullname,@username,@mailid,@password)", con);
                cmd.Parameters.AddWithValue("@fullname", textBox4.Text);
                cmd.Parameters.AddWithValue("@username", textBox3.Text);
                cmd.Parameters.AddWithValue("@mailid", textBox6.Text);
                cmd.Parameters.AddWithValue("@password", textBox5.Text);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registeration Initiated");
                    timer2.Start();
                    line();
                    log();
                }
                catch(SqlException ex) when (ex.Number==2627)
                {
                    MessageBox.Show("Violation of Primary Key Constraint, duplicate username: " + textBox3.Text);
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Enter Details Properly");
            }
        }
    }
}