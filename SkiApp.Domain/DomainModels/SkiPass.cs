using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiApp.Domain.DomainModels
{
    public class SkiPass
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? PassType { get; set; } // Day/Week/Season

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime ValidFrom { get; set; }

        [Required]
        public DateTime ValidUntil { get; set; }

        [Required]
        public string? AccessLevel { get; set; } // Beginner/All/Expert

        // Foreign Key
        public Guid SkiResortId { get; set; }
        public SkiResort? SkiResort { get; set; }

        // Navigation
        public virtual ICollection<Booking>? Bookings { get; set; }
    }
}
