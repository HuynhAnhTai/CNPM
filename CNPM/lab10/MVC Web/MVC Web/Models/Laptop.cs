using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Web.Models
{
    public class Laptop
    {
        public Laptop(int id, String name, String Ram, int price)
        {
            this.id = id;
            this.name = name;
            this.Ram = Ram;
            this.price = price;
        }

        public int id { get; set; }
        
        public String name { get; set; }

        public String Ram { get; set; }

        public int price { get; set; }
    }
}