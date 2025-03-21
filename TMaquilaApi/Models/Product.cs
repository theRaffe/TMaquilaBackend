using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMaquilaApi.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;


        public decimal Price { get; set; }

        public bool Active { get; set; }

        public DateTime DateModified { get; set; }


    }
}