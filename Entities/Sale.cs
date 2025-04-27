using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaManagementSystem.Entities
{
    public class Sale
    {
        public int Id { get; set; }

        [Required] 
        [Range(1, int.MaxValue, ErrorMessage = "The number of tickets must be greater than zero.")]
        public int TicketsCount { get; set; }

        [Required] 
        [Range(0.01, double.MaxValue, ErrorMessage = "The sum must be greater than zero.")]
        public decimal TotalAmount { get; set; }

        [Required] 
        public DateTime PurchaseDate { get; set; }

        public Discount? Discount { get; set; }
        public int? DiscountId { get; set; }

        public User? User { get; set; }
        public int? UserId { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
