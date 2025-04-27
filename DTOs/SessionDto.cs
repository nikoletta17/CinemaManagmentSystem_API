namespace CinemaManagementSystem.DTOs
{
    public class SessionDto
    {
        public DateTime DateTime { get; set; }
        public decimal TicketPrice { get; set; }
        public string Status { get; set; }
        public int MovieId { get; set; }
        public int HallId { get; set; }
    }
}
