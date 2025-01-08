using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CustomerPreferencesDto
    {
        public string? PreferredTourDuration { get; set; }
        public bool GuidedTours { get; set; }
        public string? PackageInclusions { get; set; }
    }
}
