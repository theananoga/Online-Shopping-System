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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\桌面\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
                conn.Open();

                SqlCommand cmd = new SqlCommand("Select * From Goods", conn);

                SqlDataReader dr = cmd.ExecuteReader();

                GridView1.DataSource = dr;
                GridView1.DataBind();


                cmd.Cancel();
                dr.Close();
                conn.Dispose();
                conn.Close();
                Label1.Text = "";
            }
            
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = GridView1.Rows[index];

            TableCell orderId = selectedRow.Cells[1];

            if (e.CommandName == "add")
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\桌面\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
                conn.Open();


                SqlCommand cmd = new SqlCommand("Insert Into [Cart] (cId,c_put_time, gId, number) Values(@cId,@c_put_time, @gId, @number)", conn);

                cmd.Parameters.Add("@cId", SqlDbType.Int,4).Value = Convert.ToInt32(Session["customer"].ToString());
                cmd.Parameters.Add("@c_put_time", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@gId", SqlDbType.Int, 4).Value = orderId.Text;
                cmd.Parameters.Add("@number", SqlDbType.Int, 4).Value = 1;

                cmd.ExecuteNonQuery();


                cmd.Cancel();
                conn.Close();

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            GridView2.Visible = true;
            Panel1.Visible = false;
            Button2.Visible = true;
            Button3.Visible = true;
            Button1.Visible = false;

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\桌面\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            conn.Open();

            SqlCommand cmd = new SqlCommand("Select * From Cart where cId=@cId", conn);
            cmd.Parameters.Add("@cId", SqlDbType.Int, 4).Value = Convert.ToInt32(Session["customer"].ToString());

            SqlDataReader dr = cmd.ExecuteReader();

            GridView2.DataSource = dr;
            GridView2.DataBind();

            cmd.Cancel();
            dr.Close();
            conn.Dispose();
            conn.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
            GridView2.Visible = false;
            Panel1.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            Button1.Visible = true;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            GridView1.Visible = false;
            Panel1.Visible = true;
            Button2.Visible = false;
            Button3.Visible = false;
            Button1.Visible = false;
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\桌面\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            conn.Open();

         
            SqlDataAdapter myAdapter = new SqlDataAdapter("Select * From Cart where cId=@cId", conn);
            myAdapter.SelectCommand.Parameters.Add("@cId", SqlDbType.Int, 4).Value = Convert.ToInt32(Session["customer"].ToString());
            DataSet ds = new DataSet();

            myAdapter.Fill(ds, "test");
            DataTable myTable = ds.Tables["test"];

            for (int i = 0; i < myTable.Rows.Count; i++)
            {
                SqlCommand cmd = new SqlCommand("Insert Into [Order]   (cId,gId,pay,tId,cDate) values  (@cId,@gId,@pay,@tId,@cDate)", conn);
                //於SqlCommand中加入SqlParameter參數，並設定參數值
                cmd.Parameters.Add("@cId", SqlDbType.Int, 4).Value = Convert.ToInt32(Session["customer"].ToString());
                cmd.Parameters.Add("@gId", SqlDbType.Int, 4).Value = myTable.Rows[i]["gId"];
                cmd.Parameters.Add("@pay", SqlDbType.Int, 4).Value = Convert.ToInt32(DropDownList1.SelectedValue);
                cmd.Parameters.Add("@tId", SqlDbType.Int, 4).Value = Convert.ToInt32(DropDownList2.SelectedValue);
                cmd.Parameters.Add("@cDate", SqlDbType.Date).Value = DateTime.Now.ToShortDateString();
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Delete From [Cart] Where  cId=@cId AND gId=@gId", conn);
                cmd.Parameters.Add("@cId", SqlDbType.Int, 4).Value = Convert.ToInt32(Session["customer"].ToString());
                cmd.Parameters.Add("@gId", SqlDbType.Int, 4).Value = myTable.Rows[i]["gId"];
                cmd.ExecuteNonQuery();

            }

            myAdapter = new SqlDataAdapter("Select * From [Order] where cId=@cId", conn);
            myAdapter.SelectCommand.Parameters.Add("@cId", SqlDbType.Int, 4).Value = Convert.ToInt32(Session["customer"].ToString());

            ds = new DataSet();

            myAdapter.Fill(ds, "test2");
            myTable = ds.Tables["test2"];


            GridView3.DataSource = ds.Tables["test2"];
            GridView3.DataBind();

            conn.Dispose();
            conn.Close();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("search.aspx");
        }
    }
}