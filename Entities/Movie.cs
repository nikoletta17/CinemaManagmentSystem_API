using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaManagementSystem.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)] 
        public string Title { get; set; }

        [Required] 
        [StringLength(50)] 
        public string Genre { get; set; }

        [Required] 
        [StringLength(100)] 
        public string Director { get; set; }

        [Range(1, 300)] 
        public int DurationMinutes { get; set; }

        [Range(1900, 2100)] 
        public int ReleaseYear { get; set; }

        public string? AgeRestriction { get; set; } 

        [Required] 
        public string Description { get; set; }

        public ICollection<Session> Sessions { get; set; } = new List<Session>(); 
    }
}
