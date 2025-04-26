using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaManagementSystem.Entities
{
    public class Hall
    {
        public int Id { get; set; }

        [Required] 
        public int HallNumber { get; set; }

        [Range(1, 1000)] 
        public int SeatsCount { get; set; }

        [Required] 
        [StringLength(50)] 
        public string HallType { get; set; }

        public ICollection<Session> Sessions { get; set; } = new List<Session>(); 
    }
}
