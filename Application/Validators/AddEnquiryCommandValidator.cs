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
            RuleFor(command => command.Customer.PhoneNumber)
                .MinimumLength(10)
                .WithMessage("Customer phone number must contain atleast 10 digits.")
                .NotEmpty()
                .WithMessage("Customer phone number field cannot be empty.");
            RuleFor(command => command.Customer.FullName)
                .NotEmpty()
                .WithMessage("Customer full name cannot be empty.");
            RuleFor(command => command.Customer.TravelDetails.StartDate)
                .NotEmpty()
                .WithMessage("Trip start date cannot be empty.");
            RuleFor(command => command.Customer.TravelDetails.EndDate)
                .NotEmpty()
                .WithMessage("Trip end date cannot be empty.");
        }
    }
}
