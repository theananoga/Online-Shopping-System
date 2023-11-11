using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace WebApplication1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ( TextBox2.Text != "")
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\桌面\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
                conn.Open();

                SqlCommand cmd = new SqlCommand("Select * from [" + RadioButtonList1.SelectedValue + "] where gId=@gId AND cId=@cId", conn);
                cmd.Parameters.Add("@gId", SqlDbType.Int, 4).Value = Convert.ToInt32(TextBox2.Text);
                cmd.Parameters.Add("@cId", SqlDbType.Int, 4).Value = Convert.ToInt32(Session["customer"]);

                SqlDataReader dr = cmd.ExecuteReader();

                GridView1.DataSource = dr;
                GridView1.DataBind();


                cmd.Cancel();
                dr.Close();
                conn.Dispose();
                conn.Close();
            }
            else
            {

                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\桌面\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
                conn.Open();

                SqlCommand cmd = new SqlCommand("Select * from [" + RadioButtonList1.SelectedValue + "] where  cId=@cId", conn);
                cmd.Parameters.Add("@cId", SqlDbType.Int, 4).Value = Convert.ToInt32(Session["customer"]);

                SqlDataReader dr = cmd.ExecuteReader();

                GridView1.DataSource = dr;
                GridView1.DataBind();


                cmd.Cancel();
                dr.Close();
                conn.Dispose();
                conn.Close();
            }


            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
                Response.Redirect("buy.aspx");
            
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = GridView1.Rows[index];

            Label1.Text=selectedRow.Cells[2].Text;

            if (e.CommandName == "e")
            {
                if (RadioButtonList1.SelectedIndex == 0)
                {
                    Panel2.Visible = true;
                }
                else if (RadioButtonList1.SelectedIndex == 1)
                {
                    Label1.Text = selectedRow.Cells[6].Text;
                    Panel3.Visible = true;
                }
            }
            if (e.CommandName == "del")
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\桌面\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
                conn.Open();
                SqlCommand cmd;
                //建立Delete帶參數語法
                if (RadioButtonList1.SelectedIndex == 0)
                {
                     cmd = new SqlCommand("Delete From [" + RadioButtonList1.SelectedValue + "] Where  oId=@oId", conn);
                    cmd.Parameters.Add("@oId", SqlDbType.Int, 4).Value = Convert.ToInt32(selectedRow.Cells[2].Text);
                    cmd.ExecuteNonQuery();

                }
                else if (RadioButtonList1.SelectedIndex == 1)
                {
                    cmd = new SqlCommand("Delete From [" + RadioButtonList1.SelectedValue + "] Where  cId=@cId AND no=@no", conn);
                    cmd.Parameters.Add("@cId", SqlDbType.Int, 4).Value = Convert.ToInt32(Session["customer"]);
                    cmd.Parameters.Add("@no", SqlDbType.Int, 4).Value = Convert.ToInt32(selectedRow.Cells[6].Text);
                    //cmd.Parameters.Add("@times", SqlDbType.DateTime).Value = DateTime.Parse(selectedRow.Cells[3].Text);
                    cmd.ExecuteNonQuery();

                }

            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\桌面\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            conn.Open();
            //建立Update帶參數語法
            SqlCommand cmd = new SqlCommand("Update [Order] Set    gId = @gId, pay = @pay, tId = @tId,cDate=@cDate    Where oId=@oId", conn);
            //於SqlCommand中加入SqlParameter參數，並設定參數值
            cmd.Parameters.Add("@gId", SqlDbType.Int, 4).Value = Convert.ToInt32(TextBox3.Text);
            cmd.Parameters.Add("@pay", SqlDbType.Int, 4).Value = DropDownList2.SelectedValue;
            cmd.Parameters.Add("@tId", SqlDbType.Int, 4).Value = DropDownList3.SelectedValue;
            cmd.Parameters.Add("@cDate", SqlDbType.Date, 4).Value = DateTime.Now.ToShortDateString();
            cmd.Parameters.Add("@oId", SqlDbType.Int, 4).Value = Convert.ToInt32(Label1.Text);

            cmd.ExecuteNonQuery();
            cmd.Cancel();
            conn.Dispose();
            conn.Close();

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Panel3.Visible = false;

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\桌面\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            conn.Open();
            //建立Update帶參數語法
            SqlCommand cmd = new SqlCommand("Update [Cart] Set number = @number Where no = @no", conn);
            //於SqlCommand中加入SqlParameter參數，並設定參數值
            cmd.Parameters.Add("@number", SqlDbType.Int, 4).Value = Convert.ToInt32(TextBox4.Text);
            cmd.Parameters.Add("@no", SqlDbType.Int, 4).Value = Convert.ToInt32(Label1.Text);

            cmd.ExecuteNonQuery();
            cmd.Cancel();
            conn.Dispose();
            conn.Close();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }
    }
}