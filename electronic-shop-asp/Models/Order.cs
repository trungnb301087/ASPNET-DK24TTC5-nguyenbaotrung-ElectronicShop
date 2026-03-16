using System.ComponentModel.DataAnnotations;

namespace electronic_shop_asp.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public decimal TotalAmount { get; set; }

        public string? ShippingAddress { get; set; }

        public string? Phone { get; set; }

        public string Status { get; set; } = "Pending";

        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}