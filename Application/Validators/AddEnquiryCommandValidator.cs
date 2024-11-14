using Application.Enquiry.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public sealed class AddEnquiryCommandValidator : AbstractValidator<AddEnquiryCommand>
    {
        public AddEnquiryCommandValidator()
        {

        }
    }
}
