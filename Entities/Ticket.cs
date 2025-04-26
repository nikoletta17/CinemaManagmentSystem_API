using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaManagementSystem.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public int SeatNumber { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Ціна квитка має бути більше нуля.")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }

        [Required]
        public Session Session { get; set; }
        public int SessionId { get; set; }
    }
}
