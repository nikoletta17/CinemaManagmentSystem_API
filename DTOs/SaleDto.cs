namespace CinemaManagementSystem.DTOs
{
    public class SaleDto
    {
        public int TicketsCount { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int? DiscountId { get; set; }
        public int? UserId { get; set; }
    }
}
