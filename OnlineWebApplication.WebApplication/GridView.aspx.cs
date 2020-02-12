using System;
using System.Collections.Generic;
using System.Web;
using OnlineMobileShop.BL;
using System.Web.UI;
using OnlineMobileShop.DAL;
using System.Data.SqlClient;
using OnlineMobileShop.Entity;
using System.Web.UI.WebControls;

namespace OnlineWebApplication.WebApplication
{
    public partial class GridView : System.Web.UI.Page
    {
        UserBL userManager = new UserBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridView();
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void PopulateGridView()
        {
            try
            {

                if (userManager.ToBind().Rows.Count > 0)
                {
                    GridView1.DataSource = userManager.ToBind();
                    GridView1.DataBind();
                }
                else
                {
                    //userManager.ToBind().Rows.Add(userManager.ToBind().NewRow());
                    //GridView1.DataSource = userManager.ToBind();
                    //GridView1.DataBind();
                    //GridView1.Rows[0].Cells.Clear();
                    //GridView1.Rows[0].Cells[0].ColumnSpan = userManager.ToBind().Columns.Count;
                    //GridView1.Rows[0].Cells[0].Text = "No Data Found";
                    //GridView1.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                TextBox txtBrand = GridView1.FooterRow.FindControl("txtBrand") as TextBox;
                TextBox txtModel = GridView1.FooterRow.FindControl("txtModel") as TextBox;
                TextBox txtBattery = (GridView1.FooterRow.FindControl("txtBattery")) as TextBox;
                TextBox txtRAM = GridView1.FooterRow.FindControl("txtRAM") as TextBox;
                TextBox txtROM = GridView1.FooterRow.FindControl("txtROM") as TextBox;
                TextBox txtPrice = GridView1.FooterRow.FindControl("txtPrice") as TextBox;
                Product user = new Product(txtBrand.Text, txtModel.Text, Convert.ToInt32(txtBattery), Convert.ToInt32(txtRAM), Convert.ToInt32(txtROM), Convert.ToInt32(txtPrice));
                if (userManager.GetProduct(user) == true)
                {
                    PopulateGridView();

                }
            }
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            PopulateGridView();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            PopulateGridView();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtMobileID = GridView1.Rows[e.RowIndex].FindControl("txtMobileID") as TextBox;
            TextBox txtBrand = GridView1.Rows[e.RowIndex].FindControl("txtBrand") as TextBox;
            TextBox txtModel = GridView1.Rows[e.RowIndex].FindControl("txtModel") as TextBox;
            TextBox txtBattery = (GridView1.Rows[e.RowIndex].FindControl("txtBattery")) as TextBox;
            TextBox txtRAM = GridView1.Rows[e.RowIndex].FindControl("txtRAM") as TextBox;
            TextBox txtROM = GridView1.Rows[e.RowIndex].FindControl("txtROM") as TextBox;
            TextBox txtPrice = GridView1.Rows[e.RowIndex].FindControl("txtPrice") as TextBox;
            Product user = new Product(txtBrand.Text, txtModel.Text, Convert.ToInt32(txtBattery.Text), Convert.ToInt32(txtRAM.Text), Convert.ToInt32(txtROM.Text), Convert.ToInt32(txtPrice.Text));
            if (userManager.UpdateProduct(user, Convert.ToInt32(txtMobileID.Text)) == true)
            {
                //  GridView1.EditIndex = -1;
                PopulateGridView();

            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Product user = new Product(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
            if (userManager.DeleteProduct(user) == true)
            {
                PopulateGridView();

            }

        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            PopulateGridView();
        }
        protected void btnInsert_Click(object o, EventArgs e)
        {
            // Product user = new Product((GridView1.FooterRow.FindControl("txtBrandFooter") as TextBox.Text), (GridView1.FooterRow.FindControl("txtModelFooter") as TextBox).Text.Trim(),(Convert.ToInt32((GridView1.FooterRow.FindControl("txtBatteryFooter") as TextBox).Text.Trim(), Convert.ToInt32((GridView1.FooterRow.FindControl("txtBatteryFooter") as TextBox).Text.Trim()), Convert.ToInt32((GridView1.FooterRow.FindControl("txtRAMFooter") as TextBox).Text.Trim()), Convert.ToInt32((GridView1.FooterRow.FindControl("cityFooter") as TextBox).Text.Trim()), Convert.ToInt32((GridView1.FooterRow.FindControl("addressFooter") as TextBox).Text.Trim()));
            TextBox txtBrand = GridView1.FooterRow.FindControl("txtBrandFooter") as TextBox;
            TextBox txtModel = GridView1.FooterRow.FindControl("txtModelFooter") as TextBox;
            TextBox txtBattery = (GridView1.FooterRow.FindControl("txtBatteryFooter")) as TextBox;
            TextBox txtRAM = GridView1.FooterRow.FindControl("txtRAMFooter") as TextBox;
            TextBox txtROM = GridView1.FooterRow.FindControl("txtROMFooter") as TextBox;
            TextBox txtPrice = GridView1.FooterRow.FindControl("txtPriceFooter") as TextBox;
            Product user = new Product(txtBrand.Text, txtModel.Text, Convert.ToInt32(txtBattery.Text), Convert.ToInt32(txtRAM.Text), Convert.ToInt32(txtROM.Text), Convert.ToInt32(txtPrice.Text));
            if (userManager.GetProduct(user))
            {
                PopulateGridView();
            }

        }
    }
}