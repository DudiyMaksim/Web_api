using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_api.DAL.Entities
{
    public class CategoryEntity : BaseEntity<string>
    {
        public override string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }
        [MaxLength(255)]
        public string? NormalizedName { get; set; }
        [MaxLength]
        public string? Description { get; set; }
        [MaxLength(255)]
        public string? Image { get; set; }

        public ICollection<ProductEntity> Products { get; set; } = [];
    }
}
