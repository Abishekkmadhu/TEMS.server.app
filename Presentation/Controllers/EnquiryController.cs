using Application.DTOs;
using Application.Enquiry.Commands;
using Application.Enquiry.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, User")] // Only users with the role can access this controller
    //[Authorize]
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
        public async Task<IActionResult> GetAll()
        {
            var enquiries = await _mediator.Send(new GetAllEnquiryQuery());
            return Ok(enquiries);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var enquiries = await _mediator.Send(new GetEnquiryQuery(id));
            return Ok(enquiries);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CustomerDto enquiry)
        {
            var result = await _mediator.Send(new AddEnquiryCommand(enquiry));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerDto enquiry)
        {
            var result = await _mediator.Send(new UpdateEnquiryCommand(enquiry));
            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteEnquiryCommand(id));
            return Ok(result);
        }
    }
}
