using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PackagePreference
    {
        public int PackagePreferenceId { get; set; }
        public string? PackageType { get; set; }
        public decimal? BudgetRange { get; set; }
        public string? AccommodationType { get; set; }
        public string? TransportationPreference { get; set; }
        public string? MealPreferences { get; set; }
        public string? PreferredActivities { get; set; }

        // Foreign key relationship
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
