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
    public partial class UserControl3 : UserControl
    {
        public int oldid;
        public UserControl3()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection("data source=MR-BING-PC\\SQLEXPRESS01; database=csharpproj;integrated security=SSPI");
            SqlDataAdapter sda = new SqlDataAdapter("select * from dbo.mem", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            bunifuCustomDataGrid1.ForeColor = Color.Black;
        }
        void Enter1(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "Name")
            {
                bunifuMaterialTextbox1.Text = string.Empty;
            }
        }
        void Leave1(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == string.Empty)
            {
                bunifuMaterialTextbox1.Text = "Name";
            }
        }
        void Enter2(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text == "Id")
            {
                bunifuMaterialTextbox2.Text = string.Empty;
            }
        }
        void Leave2(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text == string.Empty)
            {
                bunifuMaterialTextbox2.Text = "Id";
            }
        }
        void Enter3(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox3.Text == "Height")
            {
                bunifuMaterialTextbox3.Text = string.Empty;
            }
        }
        void Leave3(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox3.Text == string.Empty)
            {
                bunifuMaterialTextbox3.Text = "Height";
            }
        }
        void Enter4(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox4.Text == "Weight")
            {
                bunifuMaterialTextbox4.Text = string.Empty;
            }
        }
        void Leave4(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox4.Text == string.Empty)
            {
                bunifuMaterialTextbox4.Text = "Weight";
            }
        }
        void Enter5(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox5.Text == "Contact No")
            {
                bunifuMaterialTextbox5.Text = string.Empty;
            }
        }
        void Leave5(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox5.Text == string.Empty)
            {
                bunifuMaterialTextbox5.Text = "Contact No";
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text != "Id")
            {
                SqlConnection con = new SqlConnection("data source=MR-BING-PC\\SQLEXPRESS01; database=csharpproj;integrated security=SSPI");
                SqlCommand cmd = new SqlCommand("select * from dbo.mem where id=@id", con);
                cmd.Parameters.AddWithValue("@id", int.Parse(bunifuMaterialTextbox2.Text));
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                    {
                        oldid = (int)rdr["id"];
                    }
                    con.Close();
                    cmd = new SqlCommand("select * from dbo.mem where id=@id", con);
                    cmd.Parameters.AddWithValue("@id", int.Parse(bunifuMaterialTextbox2.Text));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    bunifuCustomDataGrid1.DataSource = dt;
                    bunifuCustomDataGrid1.ForeColor = Color.Black;
                }
                else
                {
                    MessageBox.Show("Not Found Id: " + int.Parse(bunifuMaterialTextbox2.Text));
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Enter Id properly");
            }
        }
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0 && numericUpDown1.Value < 100 && bunifuMaterialTextbox2.Text != "Id" && bunifuMaterialTextbox1.Text != "Name" && bunifuMaterialTextbox3.Text != "Height" && bunifuMaterialTextbox4.Text != "Weight" && bunifuMaterialTextbox5.Text != "Contact" && comboBox1.Text != "Gender" && comboBox2.Text != "Batch" && comboBox3.Text != "Fees Mode")
            {
                SqlConnection con = new SqlConnection("data source=MR-BING-PC\\SQLEXPRESS01; database=csharpproj;integrated security=SSPI");
                SqlCommand cmd = new SqlCommand("update dbo.mem set name=@name,id=@id,height=@height,weight=@weight,contact=@contact,gender=@gender,age=@age,batch=@batch,feemode=@feemode where id=@oid", con);
                cmd.Parameters.AddWithValue("@name", bunifuMaterialTextbox1.Text);
                cmd.Parameters.AddWithValue("@id", int.Parse(bunifuMaterialTextbox2.Text));
                cmd.Parameters.AddWithValue("@height", bunifuMaterialTextbox3.Text);
                cmd.Parameters.AddWithValue("@weight", bunifuMaterialTextbox4.Text);
                cmd.Parameters.AddWithValue("@contact", bunifuMaterialTextbox5.Text);
                cmd.Parameters.AddWithValue("@gender", comboBox1.GetItemText(comboBox1.SelectedItem));
                cmd.Parameters.AddWithValue("@age", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@batch", comboBox2.GetItemText(comboBox2.SelectedItem));
                cmd.Parameters.AddWithValue("@feemode", comboBox3.GetItemText(comboBox3.SelectedItem));
                cmd.Parameters.AddWithValue("@oid", oldid);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Updated Successfully");
                    cmd = new SqlCommand("select * from dbo.mem where id=@id", con);
                    cmd.Parameters.AddWithValue("@id", int.Parse(bunifuMaterialTextbox2.Text));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    bunifuCustomDataGrid1.DataSource = dt;
                    bunifuCustomDataGrid1.ForeColor = Color.Black;
                }
                catch (SqlException ex) when (ex.Number == 2627)
                {
                    con.Close();
                    MessageBox.Show("Violation of Primary Key Constraint, duplicate id: " + int.Parse(bunifuMaterialTextbox2.Text));
                }
            }
            else
            {
                MessageBox.Show("Enter ALL Details Properly");
            }
        }
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text != "Id")
            {
                SqlConnection con = new SqlConnection("data source=MR-BING-PC\\SQLEXPRESS01; database=csharpproj;integrated security=SSPI");
                SqlCommand cmd = new SqlCommand("delete from dbo.mem where id=@oid", con);
                cmd.Parameters.AddWithValue("@oid", oldid);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Deleted Successfully");
                    cmd = new SqlCommand("select * from dbo.mem", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    bunifuCustomDataGrid1.DataSource = dt;
                    bunifuCustomDataGrid1.ForeColor = Color.Black;

                }
                catch (SqlException ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message);
                    cmd = new SqlCommand("select * from dbo.mem where id=@id", con);
                    cmd.Parameters.AddWithValue("@id", int.Parse(bunifuMaterialTextbox2.Text));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    bunifuCustomDataGrid1.DataSource = dt;
                    bunifuCustomDataGrid1.ForeColor = Color.Black;
                }
            }
            else
            {
                MessageBox.Show("Enter Id Properly");
            }
        }
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            bunifuMaterialTextbox1.Text = "Name";
            bunifuMaterialTextbox2.Text = "Id";
            bunifuMaterialTextbox3.Text = "Height";
            bunifuMaterialTextbox4.Text = "Weight";
            bunifuMaterialTextbox5.Text = "Contact No";
            comboBox1.Text = "Gender";
            comboBox2.Text = "Batch";
            comboBox3.Text = "Fees Mode";
            numericUpDown1.Value = 0;
            SqlConnection con = new SqlConnection("data source=MR-BING-PC\\SQLEXPRESS01; database=csharpproj;integrated security=SSPI");
            SqlDataAdapter sda = new SqlDataAdapter("select * from dbo.mem", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            bunifuCustomDataGrid1.ForeColor = Color.Black;
            //SqlConnection con1 = new SqlConnection("data source=MR-BING-PC\\SQLEXPRESS01; database=csharpproj;integrated security=SSPI");
            //SqlDataAdapter sda1 = new SqlDataAdapter("select * from dbo.mem", con1);
            //DataTable dt1 = new DataTable();
            //sda1.Fill(dt1);
            //bunifuCustomDataGrid1.DataSource = dt1;
            //bunifuCustomDataGrid1.ForeColor = Color.Black;
        }
    }
}