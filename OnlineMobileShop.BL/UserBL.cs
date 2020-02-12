using OnlineMobileShop.DAL;
using OnlineMobileShop.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace OnlineMobileShop.BL
{
    public class UserBL
    {
        ProductRepository productRepository = new ProductRepository();
       
        public bool GetProduct(Product product)
        {
            return productRepository.GetProduct(product);
        }
        public DataTable ToBind()
        {
            return productRepository.ToBind();
        }
        public bool UpdateProduct(Product product,int MobileID)
        {
            return productRepository.UpdateDetails(product,MobileID);
        }
        public bool DeleteProduct(Product product)
        {
            return productRepository.Delete(product);
        }
    }
}
