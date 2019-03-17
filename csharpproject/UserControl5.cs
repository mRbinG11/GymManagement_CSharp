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

namespace csharpproject
{
    public partial class UserControl5 : UserControl
    {
        public UserControl5()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection("data source=MR-BING-PC\\SQLEXPRESS01; database=csharpproj;integrated security=SSPI");
            SqlDataAdapter sda = new SqlDataAdapter("select * from dbo.equip", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            bunifuCustomDataGrid1.ForeColor = Color.Black;
        }
    }
}
