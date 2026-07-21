namespace ShopEase.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public string PaymentMode { get; set; }

        public decimal Amount { get; set; }

        public string Status { get; set; }
    }
}