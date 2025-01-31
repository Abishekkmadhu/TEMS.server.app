﻿using Application.DTOs;
using Application.Enquiry.Commands;
using Application.Enquiry.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnquiryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly Serilog.ILogger _logger;
        public EnquiryController(IMediator mediator, Serilog.ILogger logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEnquiry()
        {
            var enquiries = await _mediator.Send(new GetAllEnquiryQuery());
            return Ok(enquiries);
        }

        [HttpPost]
        public async Task<IActionResult> AddEnquiry(CustomerDto enquiry)
        {
            await _mediator.Send(new AddEnquiryCommand(enquiry));
            return Ok();
        }


        //update
        //delete
    }
}
