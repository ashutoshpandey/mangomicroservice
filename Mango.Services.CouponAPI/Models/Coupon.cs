using System.ComponentModel.DataAnnotations;

namespace Mango.Services.CouponAPI.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId {  get; set; }
        [Required]
        public double Discount {  get; set; }
        [Required]
        public string CouponCode {  get; set; }
        public int MinimumAmount {  get; set; }
    }
}
