using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.DTOs;
using Application.Enquiry.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Enquiry.Handlers
{
    public class GetEnuiryQueryHandler : IRequestHandler<GetEnquiryQuery, CustomerDto>
    {
        private readonly ILogger<GetEnuiryQueryHandler> _logger;
        private readonly IEnquiryRepository _enquiryRepository;
        private readonly IEnquiryService _enquiryService;
        public GetEnuiryQueryHandler(ILogger<GetEnuiryQueryHandler> logger, IEnquiryRepository enquiryRepository, IEnquiryService enquiryService)
        {
            _logger = logger;
            _enquiryRepository = enquiryRepository;
            _enquiryService = enquiryService;
        }

        public async Task<CustomerDto> Handle(GetEnquiryQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"HANDLER LOG : Handling GetEnquiry request ID: {request.id}");
            var result = await _enquiryRepository.GetEnquiryById(request.id);

            if (result == null)
            {
                _logger.LogError("HANDLER LOG : No Enquiries fetched");
            }

            return _enquiryService.GetEnquiryService(result);
        }
    }
}
