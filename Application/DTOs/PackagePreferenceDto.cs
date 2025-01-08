using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PackagePreferenceDto
    {
        public string? PackageType { get; set; }
        public decimal? BudgetRange { get; set; }
        public string? AccommodationType { get; set; }
        public string? TransportationPreference { get; set; }
        public string? MealPreferences { get; set; }
        public string? PreferredActivities { get; set; }
    }
}
