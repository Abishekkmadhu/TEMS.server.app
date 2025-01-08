using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SpecialRequirements
    {
        public int SpecialRequirementsId { get; set; }
        public string? SpecialRequests { get; set; }
        public bool TravelInsurance { get; set; }

        // Foreign key relationship
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
