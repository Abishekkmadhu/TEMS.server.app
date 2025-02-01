using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Enquiry.Commands
{
    public record DeleteEnquiryCommand(int id) : IRequest;
}
