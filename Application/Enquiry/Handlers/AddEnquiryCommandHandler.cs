﻿using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Enquiry.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<AddEnquiryCommandHandler> _logger;
        private readonly IEnquiryRepository _enquiryRepository;
        private readonly IEnquiryService _enquiryService;

        public AddEnquiryCommandHandler(IEnquiryRepository enquiryRepository, IEnquiryService enquiryService, ILogger<AddEnquiryCommandHandler> logger)
        {
            _enquiryRepository = enquiryRepository;
            _enquiryService = enquiryService;
            _logger = logger;
        }

        public async Task<Unit> Handle(AddEnquiryCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("HANDLER LOG : Executing Add enquiry handler request.");
            var entity = _enquiryService.AddEnquiryService(request.Customer);
            await _enquiryRepository.AddEnquiry(entity);
            return Unit.Value;
        }
    }
}
