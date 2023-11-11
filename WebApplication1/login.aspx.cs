using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace WebApplication1
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void in_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\桌面\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            conn.Open();

            SqlCommand cmd = new SqlCommand("Select cId,account,password From Customer Where account=@username AND password=@pass", conn);
            cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = tbUserName.Text;
            cmd.Parameters.Add("@pass", SqlDbType.NChar, 10).Value = tbPass.Text;
            SqlDataReader dr = cmd.ExecuteReader();

            //check if the username and pass already existed or not
            if (dr.HasRows) //if existed
            {
                while (dr.Read())
                {
                    Session["customer"] = dr[0].ToString();
                }


                Response.Redirect("search.aspx");

            }
            else //if not exist
            {
                tbUserName.Text = "";
                tbPass.Text = "";
                Response.Write("<script>alert('Login Failed!')</script>");

            }

            cmd.Dispose();
            dr.Close();
            conn.Close();
        }

        protected void clear_Click(object sender, EventArgs e)
        {
            tbUserName.Text = "";
            tbPass.Text = "";
        }
    }
}