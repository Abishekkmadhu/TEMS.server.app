using Application.Abstractions.Services;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EnquiryService : IEnquiryService
    {
        public readonly ILogger<EnquiryService> _logger;
        public readonly IMapper _mapper;

        public EnquiryService(ILogger<EnquiryService> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<CustomerDto> GetAllEnquiryService (List<Customer?> customers)
        {
            if (customers.Count == 0)
            {
                _logger.LogError("There is no Enquiries available in the Database.");
                return Enumerable.Empty<CustomerDto>();
            }
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public Customer AddEnquiryService(CustomerDto customer)
        {
            if (customer == null) 
            {
                _logger.LogError("There is no Enquiries available/ Value is null.");
                return null;
            }
            return _mapper.Map<Customer>(customer);

        }

    }
}
