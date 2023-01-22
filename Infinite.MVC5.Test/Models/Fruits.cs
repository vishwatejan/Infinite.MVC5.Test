using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infinite.MVC5.Test.Models
{
    public class Fruits
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int PackSizeId { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
        public int TotalPrice { get; set; }
        public int CategoryId { get; set; }
        public PackSize PackSizeName { get; set; }
        public Category CategoryName { get; set; }

    }
}