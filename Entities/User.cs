using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaManagementSystem.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string? Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserType { get; set; }

        public int? Bonuses { get; set; }

        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
