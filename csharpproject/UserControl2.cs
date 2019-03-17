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
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection("data source=MR-BING-PC\\SQLEXPRESS01; database=csharpproj;integrated security=SSPI");
            SqlDataAdapter sda=new SqlDataAdapter("select * from dbo.mem", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            bunifuCustomDataGrid1.ForeColor = Color.Black;
        }
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=MR-BING-PC\\SQLEXPRESS01; database=csharpproj;integrated security=SSPI");
            SqlDataAdapter sda = new SqlDataAdapter("select * from dbo.mem", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            bunifuCustomDataGrid1.ForeColor = Color.Black;
        }
    }
}
