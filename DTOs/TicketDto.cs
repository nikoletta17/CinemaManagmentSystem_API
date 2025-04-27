namespace CinemaManagementSystem.DTOs
{
    public class TicketDto
    {
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public int SessionId { get; set; }
    }
}
