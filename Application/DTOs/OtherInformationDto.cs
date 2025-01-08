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
        public string? HowDidYouHearAboutUs { get; set; }
        public bool PreviousCustomer { get; set; }
    }
}
