using SkiApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiApp.Domain.DomainModels
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        public DateTime? CheckOutDate { get; set; }

        public bool EquipmentRental { get; set; }

        public string? EquipmentType { get; set; } // "Skis+Boots", "Snowboard+Boots", etc.

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public string? Status { get; set; } // Pending/Confirmed/CheckedIn/Completed/Cancelled

        // Foreign Keys
        public string? UserId { get; set; }
        public SkiResortApplicationUser? User { get; set; }

        public Guid SkiPassId { get; set; }
        public SkiPass? SkiPass { get; set; }
    }
}
