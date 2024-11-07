using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CustomerPreferences
    {
        public int CustomerPreferencesId { get; set; }
        public string? PreferredTourDuration { get; set; }
        public bool GuidedTours { get; set; }
        public string? PackageInclusions { get; set; }

        // Foreign key relationship
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
