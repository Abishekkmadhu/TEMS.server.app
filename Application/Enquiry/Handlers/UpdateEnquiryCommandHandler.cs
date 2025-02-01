using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Enquiry.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Enquiry.Handlers
{
    public class UpdateEnquiryCommandHandler : IRequestHandler<UpdateEnquiryCommand>
    {
        private readonly ILogger<UpdateEnquiryCommandHandler> _logger;
        private readonly IEnquiryRepository _enquiryRepository;
        private readonly IEnquiryService _enquiryService;

        public UpdateEnquiryCommandHandler(IEnquiryRepository enquiryRepository, IEnquiryService enquiryService, ILogger<UpdateEnquiryCommandHandler> logger)
        {
            _enquiryRepository = enquiryRepository;
            _enquiryService = enquiryService;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateEnquiryCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"HANDLER LOG : Executing Updating enquiry handler request ID: {request.Customer.CustomerId}");
            var entity = _enquiryService.UpdateEnquiryService(request.Customer);
            await _enquiryRepository.UpdateEnquiry(entity);
            return Unit.Value;
        }
    }
}
