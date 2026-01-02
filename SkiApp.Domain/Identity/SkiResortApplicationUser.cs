using Microsoft.AspNetCore.Identity;
using SkiApp.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiApp.Domain.Identity
{
    public class SkiResortApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? SkillLevel { get; set; } // Beginner/Intermediate/Advanced/Expert
        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<Booking>? UserBookings { get; set; }
    }
}
