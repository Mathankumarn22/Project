using System;
using System.Collections.Generic;
using System.Web;
using OnlineMobileShop.BL;
using System.Web.UI;
using OnlineMobileShop.DAL;
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
            UserBL.RefreshData(Gv_OnlineMobileShop);
        }
       public void Gv_OnlineMobileShop_RowDeleting(object sender,GridViewDeleteEventArgs e)
        {
            int userId = Convert.ToInt16(Gv_OnlineMobileShop.DataKeys[e.RowIndex].Values["userId"].ToString());        
            UserBL.Gv_OnlineMobileShop_RowDeleting(e, userId);
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
        protected void Gv_OnlineMobileShop_RowUpdating(object sender,GridViewUpdateEventArgs e)
        {
            UserBL.Gv_OnlineMobileShop_RowUpdating(Gv_OnlineMobileShop,e);
            Refreshdata();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            UserBL.InsertData(Gv_OnlineMobileShop);
            Refreshdata();
        }
    }
}