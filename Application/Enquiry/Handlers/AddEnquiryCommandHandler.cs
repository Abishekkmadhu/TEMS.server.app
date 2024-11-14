using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Enquiry.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Enquiry.Handlers
{
    public class AddEnquiryCommandHandler : IRequestHandler<AddEnquiryCommand>
    {
        //add logger
        private readonly IEnquiryRepository _enquiryRepository;
        private readonly IEnquiryService _enquiryService;

        public AddEnquiryCommandHandler(IEnquiryRepository enquiryRepository, IEnquiryService enquiryService)
        {
            _enquiryRepository = enquiryRepository;
            _enquiryService = enquiryService;
        }

        public async Task<Unit> Handle(AddEnquiryCommand request, CancellationToken cancellationToken)
        {
            var entity = _enquiryService.AddEnquiryService(request.Customer);
            await _enquiryRepository.AddEnquiry(entity);
            return Unit.Value;
        }
    }
}
