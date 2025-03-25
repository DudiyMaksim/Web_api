using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_api.BLL.Dtos.Product
{
    public class UpdateProductDto
    {
        public string Id { get; set; } = string.Empty;
        public required string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? Amount { get; set; } 
    }
}
