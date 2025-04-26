using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaManagementSystem.Entities
{
    public class Discount
    {
        public int Id { get; set; }

        [Required] 
        public string Description { get; set; } 

        [Range(0, 100)] 
        public decimal Percentage { get; set; } 

        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
