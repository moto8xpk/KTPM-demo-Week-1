using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    class Product
    {
        public Int32 id { get; set; }
        public String name { get; set; }
        public Int32 cateid { get; set; }
        public Int32 price { get; set; }

        public String description { get; set; }
        public String imagelink { get; set; }

        public Product(int id, string name, int cateid, int price, string description, string imagelink)
        {
            this.id = id;
            this.name = name;
            this.cateid = cateid;
            this.price = price;
            this.description = description;
            this.imagelink = imagelink;
        }

        public Product(string name, int cateid, int price, string description, string imagelink)
        {
            this.name = name;
            this.cateid = cateid;
            this.price = price;
            this.description = description;
            this.imagelink = imagelink;
        }

        public Product()
        {
        }
    }
}
