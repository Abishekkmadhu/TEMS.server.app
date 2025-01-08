using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.DTOs;
using Application.Enquiry.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Enquiry.Handlers
{
    public class GetAllEnquiryHandler : IRequestHandler<GetAllEnquiryQuery, IEnumerable<CustomerDto>>
    {
        //add logger
        private readonly IEnquiryRepository _enquiryRepository;
        private readonly IEnquiryService _enquiryService;
        public GetAllEnquiryHandler(IEnquiryRepository enquiryRepository, IEnquiryService enquiryService)
        {
            _enquiryRepository = enquiryRepository;
            _enquiryService = enquiryService;
        }

        public async Task<IEnumerable<CustomerDto>> Handle(GetAllEnquiryQuery request, CancellationToken cancellationToken)
        {
            var result =  await _enquiryRepository.GetAllEnquiry();
            return _enquiryService.GetAllEnquiryService(result);
        }
    }
}
