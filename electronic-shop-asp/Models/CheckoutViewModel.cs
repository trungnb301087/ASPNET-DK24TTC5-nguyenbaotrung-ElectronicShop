using System.ComponentModel.DataAnnotations;

namespace electronic_shop_asp.Models
{
    public class CheckoutViewModel
    {
        [Required(ErrorMessage = "Địa chỉ giao hàng không được để trống")]
        public string ShippingAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string Phone { get; set; } = string.Empty;

        public List<CartItem>? CartItems { get; set; }

        public decimal TotalAmount { get; set; }
    }
}