using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAL
{
    class ProductDAO
    {
        public static List<Product> selectAll()
        {
            String connectStr = @"Server=localhost;Database=shoppingcart;port=3306;User Id=root;password=89541926";
            MySqlConnection conn = new MySqlConnection(connectStr);
            conn.Open();
            String queryStr = @"SELECT * FROM sc_product";
            MySqlCommand cmd = new MySqlCommand(queryStr, conn);
            DbDataReader reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        id = reader.GetInt32(0),
                        name = reader.GetString(1),
                        cateid = reader.GetInt32(2),
                        price = reader.GetInt32(3),
                        description = reader.GetString(4),
                        imagelink = reader.GetString(5),
                    };
                    products.Add(product);
                }
            }

            conn.Close();
            return products;
        }
        public static List<Product> searchByName(String keywords)
        {
            String connectStr = @"Server=localhost;Database=shoppingcart;port=3306;User Id=root;password=89541926";
            MySqlConnection conn = new MySqlConnection(connectStr);
            conn.Open();
            String queryStr = @"SELECT * FROM sc_product WHERE name LIKE '%"+keywords+"%' ";
            MySqlCommand cmd = new MySqlCommand(queryStr, conn);
            DbDataReader reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        id = reader.GetInt32(0),
                        name = reader.GetString(1),
                        cateid = reader.GetInt32(2),
                        price = reader.GetInt32(3),
                        description = reader.GetString(4),
                        imagelink = reader.GetString(5),
                    };
                    products.Add(product);
                }
            }

            conn.Close();
            return products;
        }

        public static Product searchById(String id)
        {
            String connectStr = @"Server=localhost;Database=shoppingcart;port=3306;User Id=root;password=89541926";
            MySqlConnection conn = new MySqlConnection(connectStr);
            conn.Open();
            String queryStr = @"SELECT * FROM sc_product WHERE id = '" + id + "' ";
            MySqlCommand cmd = new MySqlCommand(queryStr, conn);
            DbDataReader reader = cmd.ExecuteReader();
            Product productTemp = new Product();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        id = reader.GetInt32(0),
                        name = reader.GetString(1),
                        cateid = reader.GetInt32(2),
                        price = reader.GetInt32(3),
                        description = reader.GetString(4),
                        imagelink = reader.GetString(5),
                    };
                    productTemp = product;
                }
            }

            conn.Close();
            return productTemp;
        }

        public static Boolean updateById(Product product)
        {
            String connectStr = @"Server=localhost;Database=shoppingcart;port=3306;User Id=root;password=89541926";
            MySqlConnection conn = new MySqlConnection(connectStr);
            conn.Open();
            String queryStr = @"UPDATE sc_product SET name=@name,cateid=@cateid,price=@price,description=@description,imagelink=@imagelink WHERE id = @id ";
            MySqlCommand cmd = new MySqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@name", product.name);
            cmd.Parameters.AddWithValue("@cateid", product.cateid);
            cmd.Parameters.AddWithValue("@price", product.price);
            cmd.Parameters.AddWithValue("@description", product.description);
            cmd.Parameters.AddWithValue("@imagelink", product.imagelink);
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters["@id"].Value = product.id;

            Int32 rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            Console.WriteLine("RowsAffected: {0}", rowsAffected);

            return rowsAffected > 0;
        }

        public static Boolean Insert(Product product)
        {
            String connectStr = @"Server=localhost;Database=shoppingcart;port=3306;User Id=root;password=89541926";
            MySqlConnection conn = new MySqlConnection(connectStr);
            conn.Open();
            String queryStr = @"INSERT INTO sc_product(id,name,cateid,price,description,imagelink) VALUES (@id,@name,@cateid,@price,@description,@imagelink)";
            MySqlCommand cmd = new MySqlCommand(queryStr, conn);

            cmd.Parameters.AddWithValue("@name", product.name);
            cmd.Parameters.AddWithValue("@cateid", product.cateid);
            cmd.Parameters.AddWithValue("@price", product.price);
            cmd.Parameters.AddWithValue("@description", product.description);
            cmd.Parameters.AddWithValue("@imagelink", product.imagelink);
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters["@id"].Value = product.id;

            Int32 rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            Console.WriteLine("RowsAffected: {0}", rowsAffected);

            return rowsAffected > 0;
        }

        public static Boolean deleteById(String id)
        {
            String connectStr = @"Server=localhost;Database=shoppingcart;port=3306;User Id=root;password=89541926";
            MySqlConnection conn = new MySqlConnection(connectStr);
            conn.Open();
            String queryStr = @"Delete from sc_product where id = @id";
            MySqlCommand cmd = new MySqlCommand(queryStr, conn);
           
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters["@id"].Value = id;

            Int32 rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            Console.WriteLine("RowsAffected: {0}", rowsAffected);

            return rowsAffected > 0;
        }
    }
}
