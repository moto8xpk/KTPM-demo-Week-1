using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;
using WindowsFormsApp1.DAL;

namespace WindowsFormsApp1.BLL
{
    class ProductBUS
    {
        public static List<Product> getAllProducts()
        {
            return ProductDAO.selectAll();
        }

        public static List<Product> searchByName(String keywords)
        {
            return ProductDAO.searchByName(keywords);
        }
        public static Product searchById(String id)
        {
            return ProductDAO.searchById(id);
        }
        public static Boolean updateById(Product product)
        {
            return ProductDAO.updateById(product);
        }
        public static Boolean Insert(Product product)
        {
            return ProductDAO.Insert(product);
        }

        public static Boolean deleteById (String id)
        {
            return ProductDAO.deleteById(id);
        }
    }
}
