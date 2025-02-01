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
    public class DeleteEnquiryHandler : IRequestHandler<DeleteEnquiryCommand>
    {
        private readonly ILogger<DeleteEnquiryHandler> _logger;
        private readonly IEnquiryRepository _enquiryRepository;
        private readonly IEnquiryService _enquiryService;

        public DeleteEnquiryHandler(IEnquiryRepository enquiryRepository, IEnquiryService enquiryService, ILogger<DeleteEnquiryHandler> logger)
        {
            _enquiryRepository = enquiryRepository;
            _enquiryService = enquiryService;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteEnquiryCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"HANDLER LOG : Executing Delete enquiry handler request ID: {request.id}");
            await _enquiryRepository.DeleteEnquiry(request.id);
            return Unit.Value;
        }

    }
}
