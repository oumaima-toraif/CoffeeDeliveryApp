using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApi.Models
{
    public class Product
    {
        public int ProducTID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public int price { get; set; }
    }
}