using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string? EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string? PreferredContactMethod { get; set; }
        public string? PreferredTimeForContact { get; set; }

        // Navigation properties for relationships
        public TravelDetailsDto TravelDetails { get; set; }
        public CustomerPreferencesDto CustomerPreferences { get; set; }
        public PackagePreferenceDto PackagePreference { get; set; }
        public SpecialRequirementsDto SpecialRequirements { get; set; }
        public OtherInformationDto OtherInformation { get; set; }
    }
}
