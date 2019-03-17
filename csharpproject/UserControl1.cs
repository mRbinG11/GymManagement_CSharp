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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0 && numericUpDown1.Value < 100 && bunifuMaterialTextbox2.Text != "Id")
            {
                SqlConnection con = new SqlConnection("data source=MR-BING-PC\\SQLEXPRESS01; database=csharpproj;integrated security=SSPI");
                SqlCommand cmd = new SqlCommand("insert into dbo.mem values(@name,@id,@height,@weight,@contact,@gender,@age,@batch,@feemode)", con);
                cmd.Parameters.AddWithValue("@name", bunifuMaterialTextbox1.Text);
                cmd.Parameters.AddWithValue("@id", int.Parse(bunifuMaterialTextbox2.Text));
                cmd.Parameters.AddWithValue("@height", bunifuMaterialTextbox3.Text);
                cmd.Parameters.AddWithValue("@weight", bunifuMaterialTextbox4.Text);
                cmd.Parameters.AddWithValue("@contact", bunifuMaterialTextbox5.Text);
                cmd.Parameters.AddWithValue("@gender", comboBox1.GetItemText(comboBox1.SelectedItem));
                cmd.Parameters.AddWithValue("@age", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@batch", comboBox2.GetItemText(comboBox2.SelectedItem));
                cmd.Parameters.AddWithValue("@feemode", comboBox3.GetItemText(comboBox3.SelectedItem));
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Inserted Successfully");
                }
                catch (SqlException ex) when (ex.Number == 2627)
                {
                    MessageBox.Show("Violation of Primary Key Constraint, duplicate id: " + int.Parse(bunifuMaterialTextbox2.Text));
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Enter Details Properly");
            }
        }
        private void bunifuThinButton22_Click(object sender, EventArgs e)
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
    }
}
