using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApi.DTOs
{
    public class ProductGetAllDto
    {
        public List<ProductListItemDto> Products { get; set; }
        public int TotalCount { get; set; }
        public ProductGetAllDto()
        {
            Products = new();
        }
    }
}
