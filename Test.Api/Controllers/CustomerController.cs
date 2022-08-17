using MediatR;
using Microsoft.AspNetCore.Mvc;
using Test.Application.Features.Commands;
using Test.Application.Features.Queries;

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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCustomerRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(request));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCustomerRequest { Id = id }));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allTerritories = await Mediator.Send(new GetAllCustomersRequest());
            return Ok(allTerritories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetCustomerByIdRequest { Id = id }));
        }

    }
}
