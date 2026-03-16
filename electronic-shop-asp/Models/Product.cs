using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace electronic_shop_asp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(200)]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}