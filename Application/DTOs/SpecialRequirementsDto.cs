using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class SpecialRequirementsDto
    {
        public int SpecialRequirementsId { get; set; }
        public string? SpecialRequests { get; set; }
        public bool TravelInsurance { get; set; }

        // Foreign key relationship
        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
    }
}
