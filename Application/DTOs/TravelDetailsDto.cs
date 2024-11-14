using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class TravelDetailsDto
    {
        public int TravelDetailsId { get; set; }
        public string? TravelDestination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool FlexibleDates { get; set; }
        public int? NumberOfAdults { get; set; }
        public int? NumberOfChildren { get; set; }
        public int? NumberOfInfants { get; set; }
        public string? TravelPurpose { get; set; }

        // Foreign key relationship
        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
    }
}
