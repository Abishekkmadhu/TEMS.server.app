using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.DTOs;
using Application.Enquiry.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Enquiry.Handlers
{
    public class GetAllEnquiryHandler : IRequestHandler<GetAllEnquiryQuery, IEnumerable<CustomerDto>>
    {
        private readonly ILogger<GetAllEnquiryHandler> _logger;
        private readonly IEnquiryRepository _enquiryRepository;
        private readonly IEnquiryService _enquiryService;
        public GetAllEnquiryHandler(IEnquiryRepository enquiryRepository, IEnquiryService enquiryService, ILogger<GetAllEnquiryHandler> logger)
        {
            _enquiryRepository = enquiryRepository;
            _enquiryService = enquiryService;
            _logger = logger;
        }

        public async Task<IEnumerable<CustomerDto>> Handle(GetAllEnquiryQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("HANDLER LOG : Handling GetAllEnquiry request.");
            var result =  await _enquiryRepository.GetAllEnquiry();

            if (result.Count <= 0 || result == null)
            {
                _logger.LogError("HANDLER LOG : No Enquiries fetched");
            }

            return _enquiryService.GetAllEnquiryService(result);
        }
    }
}
