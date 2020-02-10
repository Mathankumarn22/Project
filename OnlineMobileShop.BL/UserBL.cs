using OnlineMobileShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace OnlineMobileShop.BL
{
    public static class UserBL
    {
        public static void RefreshData(GridView Gv_OnlineMobileShop)
        {
            UserRespository.RefreshData(Gv_OnlineMobileShop);
        }
        public static void Gv_OnlineMobileShop_RowDeleting(GridViewDeleteEventArgs e, int userId)
        {
            UserRespository.Gv_OnlineMobileShop_RowDeleting(e, userId);

        }
        public static void Gv_OnlineMobileShop_RowUpdating(GridView Gv_OnlineMobileShop,GridViewUpdateEventArgs e)
        {
            UserRespository.Gv_OnlineMobileShop_RowUpdating(Gv_OnlineMobileShop,e);
        }
        public static void InsertData(GridView Gv_OnlineMobileShop)
        {
            UserRespository.InsertData(Gv_OnlineMobileShop);
        }

    }
}
