using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_api.DAL.Entities
{
    public class ProductImageEntity : BaseEntity<string>
    {
        public override string Id { get; set; } = Guid.NewGuid().ToString();
        public required string Name { get; set; }
        public required string Path { get; set; }

        [ForeignKey("Product")]
        public required string ProductId { get; set; }
        public ProductEntity? Product { get; set; }

        [NotMapped]
        public string ImagePath { get => System.IO.Path.Combine(Path, Name); }
    }
}
