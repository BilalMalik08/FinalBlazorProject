using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YumBlazor.Data
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Range(500, 5000)]
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? SpecialTag { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public string? ImageUrl { get; set; }
    }
}
