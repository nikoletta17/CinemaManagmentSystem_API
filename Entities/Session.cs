using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaManagementSystem.Entities
{
    public class Session
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "The ticket price must be greater than zero.")]
        public decimal TicketPrice { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } 

        [Required]
        public Movie Movie { get; set; }
        public int MovieId { get; set; }

        [Required]
        public Hall Hall { get; set; }
        public int HallId { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
