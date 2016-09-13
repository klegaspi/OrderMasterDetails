using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
                                
        public ICollection<ProductOption> ProductOptions { get; set; }
    }
}