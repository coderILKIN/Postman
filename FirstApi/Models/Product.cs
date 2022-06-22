using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal SoldPrice { get; set; }
        public decimal CostPrice { get; set; }
        public bool DisplayStatis { get; set; }
    }
}
