using System;
using System.Collections.Generic;

using System.Web;
using OnlineMobileShop.DAL;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace OnlineWebApplication.WebApplication
{
    public partial class GridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Refreshdata();
            }
        }

        public void Refreshdata()
        {
            SqlConnection sqlConnection = UserRespository.GetDBConnection();
            SqlCommand cmd = new SqlCommand("select userId,Name,Number,MailId,Password from tbl_data", sqlConnection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            sda.Fill(dt);
            Gv_OnlineMobileShop.DataBind();
            sqlConnection.Close();
        }
       protected void Gv_OnlineMobileShop_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection sqlConnection = UserRespository.GetDBConnection();
            int userId = Convert.ToInt16(Gv_OnlineMobileShop.DataKeys[e.RowIndex].Values["userId"].ToString());
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("delete from tbl_data where id =@userId", sqlConnection);
            cmd.Parameters.AddWithValue("userId", userId);
            int i = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            Refreshdata();
        }
        protected void Gv_OnlineMobileShop_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gv_OnlineMobileShop.EditIndex = e.NewEditIndex;
            Refreshdata();
        }
       protected void Gv_OnlineMobileShop_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_OnlineMobileShop.EditIndex = -1;
            Refreshdata();
        }

        protected void Gv_OnlineMobileShop_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            SqlConnection sqlConnection = UserRespository.GetDBConnection();
            TextBox txtname = Gv_OnlineMobileShop.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;
            TextBox txtcity = Gv_OnlineMobileShop.Rows[e.RowIndex].FindControl("TextBox2") as TextBox;
            int id = Convert.ToInt16(Gv_OnlineMobileShop.DataKeys[e.RowIndex].Values["id"].ToString());
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("sp_updatedata", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("name", txtname.Text);
            cmd.Parameters.AddWithValue("city", txtcity.Text);
            cmd.Parameters.AddWithValue("id", id);

            int i = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            Gv_OnlineMobileShop.EditIndex = -1;
            Refreshdata();


        }
    }
}