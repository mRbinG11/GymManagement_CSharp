using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Bunifu;
using BunifuAnimatorNS;

namespace csharpproject
{
    public partial class UserControl4 : UserControl
    {
        public UserControl4()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection("data source=MR-BING-PC\\SQLEXPRESS01; database=csharpproj;integrated security=SSPI");
            SqlDataAdapter sda = new SqlDataAdapter("select fullname,username from dbo.admins", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            bunifuCustomDataGrid1.ForeColor = Color.Black;
            sda = new SqlDataAdapter("select fullname,username from dbo.padmins", con);
            dt = new DataTable();
            sda.Fill(dt);
            bunifuCustomDataGrid2.DataSource = dt;
            bunifuCustomDataGrid2.ForeColor = Color.Black;
        }
        void Enter1(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "Username")
            {
                bunifuMaterialTextbox1.Text = string.Empty;
            }
        }
        void Leave1(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == string.Empty)
            {
                bunifuMaterialTextbox2.Text = "Username";
            }
        }
        void Enter2(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text == "Username")
            {
                bunifuMaterialTextbox2.Text = string.Empty;
            }
        }
        void Leave2(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text == string.Empty)
            {
                bunifuMaterialTextbox2.Text = "Username";
            }
        }
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if(bunifuMaterialTextbox1.Text!="Username")
            {
                SqlConnection con = new SqlConnection("data source=MR-BING-PC\\SQLEXPRESS01; database=csharpproj;integrated security=SSPI");
                SqlCommand cmd = new SqlCommand("delete from dbo.admins where username=@usr", con);
                cmd.Parameters.AddWithValue("@usr", bunifuMaterialTextbox1.Text);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Removed Successfully from admins");
                    
                }
                catch (SqlException ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message);
                }
                SqlDataAdapter sda = new SqlDataAdapter("select fullname,username from dbo.admins", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                bunifuCustomDataGrid1.DataSource = dt;
                bunifuCustomDataGrid1.ForeColor = Color.Black;
            }
            else
            {
                MessageBox.Show("Enter Username Properly");
            }
        }
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text != "Username")
            {
                SqlConnection con = new SqlConnection("data source=MR-BING-PC\\SQLEXPRESS01; database=csharpproj;integrated security=SSPI");
                SqlCommand cmd = new SqlCommand("delete from dbo.padmins where username=@usr", con);
                cmd.Parameters.AddWithValue("@usr", bunifuMaterialTextbox2.Text);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Removed Successfully from pending admins");
                }
                catch (SqlException ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message);
                }
                SqlDataAdapter sda = new SqlDataAdapter("select fullname,username from dbo.padmins", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                bunifuCustomDataGrid2.DataSource = dt;
                bunifuCustomDataGrid2.ForeColor = Color.Black;
            }
            else
            {
                MessageBox.Show("Enter Username Properly");
            }
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text != "Username")
            {
                SqlConnection con = new SqlConnection("data source=MR-BING-PC\\SQLEXPRESS01; database=csharpproj;integrated security=SSPI");
                SqlCommand cmd = new SqlCommand("select * from dbo.padmins where username=@usr", con);
                cmd.Parameters.AddWithValue("@usr", bunifuMaterialTextbox2.Text);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if(rdr.HasRows==true)
                {
                    string f, u, m, p;
                    while (rdr.Read())
                    {
                        f = rdr["fullname"].ToString();
                        u = rdr["username"].ToString();
                        m = rdr["mailid"].ToString();
                        p = rdr["password"].ToString();
                        SqlConnection con1 = new SqlConnection("data source=MR-BING-PC\\SQLEXPRESS01; database=csharpproj;integrated security=SSPI");
                        cmd = new SqlCommand("insert into dbo.admins values(@f,@u,@m,@p)", con1);
                        cmd.Parameters.AddWithValue("@f", f);
                        cmd.Parameters.AddWithValue("@u", u);
                        cmd.Parameters.AddWithValue("@m", m);
                        cmd.Parameters.AddWithValue("@p", p);
                        con1.Open();
                        try
                        {
                            cmd.ExecuteNonQuery();
                            con1.Close();
                            MessageBox.Show("Added to admins, Username: " + u);
                            SqlDataAdapter sda1 = new SqlDataAdapter("select fullname,username from dbo.admins", con1);
                            DataTable dt1 = new DataTable();
                            sda1.Fill(dt1);
                            bunifuCustomDataGrid1.DataSource = dt1;
                            bunifuCustomDataGrid1.ForeColor = Color.Black;
                        }
                        catch (SqlException ex) when (ex.Number == 2627)
                        {
                            con1.Close();
                            MessageBox.Show(ex.Message);
                        }
                        catch (SqlException ex)
                        {
                            con1.Close();
                            MessageBox.Show(ex.Message);
                        }
                        bunifuThinButton23_Click(sender, e);
                    }
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Enter Username Properly");
            }
        }
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text != "Username")
            {
                SqlConnection con = new SqlConnection("data source=MR-BING-PC\\SQLEXPRESS01; database=csharpproj;integrated security=SSPI");
                SqlCommand cmd = new SqlCommand("select * from dbo.admins where username=@usr", con);
                cmd.Parameters.AddWithValue("@usr", bunifuMaterialTextbox1.Text);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    string f, u, m, p;
                    while (rdr.Read())
                    {
                        f = rdr["fullname"].ToString();
                        u = rdr["username"].ToString();
                        m = rdr["mailid"].ToString();
                        p = rdr["password"].ToString();
                        SqlConnection con1 = new SqlConnection("data source=MR-BING-PC\\SQLEXPRESS01; database=csharpproj;integrated security=SSPI");
                        cmd = new SqlCommand("insert into dbo.padmins values(@f,@u,@m,@p)", con1);
                        cmd.Parameters.AddWithValue("@f", f);
                        cmd.Parameters.AddWithValue("@u", u);
                        cmd.Parameters.AddWithValue("@m", m);
                        cmd.Parameters.AddWithValue("@p", p);
                        con1.Open();
                        try
                        {
                            cmd.ExecuteNonQuery();
                            con1.Close();
                            MessageBox.Show("Added to padmins, Username: " + u);
                            SqlDataAdapter sda1 = new SqlDataAdapter("select fullname,username from dbo.padmins", con1);
                            DataTable dt1 = new DataTable();
                            sda1.Fill(dt1);
                            bunifuCustomDataGrid2.DataSource = dt1;
                            bunifuCustomDataGrid2.ForeColor = Color.Black;
                        }
                        catch (SqlException ex) when (ex.Number == 2627)
                        {
                            con1.Close();
                            MessageBox.Show(ex.Message);
                        }
                        catch(SqlException ex)
                        {
                            con1.Close();
                            MessageBox.Show(ex.Message);
                        }
                        bunifuThinButton24_Click(sender, e);
                    }
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Enter Username Properly");
            }
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=MR-BING-PC\\SQLEXPRESS01; database=csharpproj;integrated security=SSPI");
            SqlDataAdapter sda = new SqlDataAdapter("select fullname,username from dbo.admins", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            bunifuCustomDataGrid1.ForeColor = Color.Black;
            sda = new SqlDataAdapter("select fullname,username from dbo.padmins", con);
            dt = new DataTable();
            sda.Fill(dt);
            bunifuCustomDataGrid2.DataSource = dt;
            bunifuCustomDataGrid2.ForeColor = Color.Black;
        }
    }
}