using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string? EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string? PreferredContactMethod { get; set; }
        public string? PreferredTimeForContact { get; set; }
        public EnquiryStatus Status { get; set; } = EnquiryStatus.New;

        // Navigation properties for relationships
        public TravelDetails TravelDetails { get; set; }
        public CustomerPreferences CustomerPreferences { get; set; }
        public PackagePreference PackagePreference { get; set; }
        public SpecialRequirements SpecialRequirements { get; set; }
        public OtherInformation OtherInformation { get; set; }
    }
}
