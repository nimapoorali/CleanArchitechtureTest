using MediatR;
using Microsoft.AspNetCore.Mvc;
using Test.Application.Features.Commands;

namespace Test.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
