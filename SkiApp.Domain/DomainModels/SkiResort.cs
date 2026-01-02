using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiApp.Domain.DomainModels
{
    public class SkiResort
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Location { get; set; }

        [Required]
        public int Elevation { get; set; }

        [Required]
        public int NumberOfSlopes { get; set; }

        [Required]
        public string? Difficulty { get; set; } // Easy/Medium/Hard/Expert

        public DateTime SeasonStart { get; set; }
        public DateTime SeasonEnd { get; set; }

        // Navigation
        public virtual ICollection<SkiPass>? SkiPasses { get; set; }
    }
}
