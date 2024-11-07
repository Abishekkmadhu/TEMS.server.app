using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OtherInformation
    {
        public int OtherInformationId { get; set; }
        public string? HowDidYouHearAboutUs { get; set; }
        public bool PreviousCustomer { get; set; }

        // Adding foreing key reference
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
