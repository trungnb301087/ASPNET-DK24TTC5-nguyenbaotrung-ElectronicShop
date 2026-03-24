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
        public string StatusText
        {
            get
            {
                return Status switch
                {
                    "Pending" => "Chờ xử lý",
                    "Confirmed" => "Đã xác nhận",
                    "Shipping" => "Đang giao",
                    "Completed" => "Hoàn thành",
                    "Cancelled" => "Đã hủy",
                    _ => Status
                };
            }
        }

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}