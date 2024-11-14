using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class OtherInformationDto
    {
        public int OtherInformationId { get; set; }
        public string? HowDidYouHearAboutUs { get; set; }
        public bool PreviousCustomer { get; set; }

        // Adding foreing key reference
        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
    }
}
