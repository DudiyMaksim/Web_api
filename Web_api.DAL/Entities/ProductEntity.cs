using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_api.DAL.Entities
{
    public class ProductEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }
        [MaxLength]
        public string? Description { get; set; }
        [Column(TypeName ="decimal(18, 2)")]
        [Range(0, double.MaxValue)]
        public decimal? Price { get; set; }
        public decimal? Amount { get; set; }

        [ForeignKey("CategoryId")]
        public string? CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }
    }
}
