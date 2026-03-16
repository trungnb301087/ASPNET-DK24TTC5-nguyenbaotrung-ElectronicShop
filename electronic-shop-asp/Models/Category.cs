using System.ComponentModel.DataAnnotations;

namespace electronic_shop_asp.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}