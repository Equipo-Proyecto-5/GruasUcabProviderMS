using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProviderMS.Application.Commands;
using ProviderMS.Application.Queries;
using ProviderMS.Commons.Dtos.Request;

namespace ProviderMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProveedoresController : ControllerBase
    {
        private readonly ILogger<ProveedoresController> _logger;
        private readonly IMediator _mediator;

        public ProveedoresController(ILogger<ProveedoresController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProveedor(CreateProveedorDto createProveedorDto)
        {
            try
            {
                var command = new CreateProveedorCommand(createProveedorDto);
                var proveedorId = await _mediator.Send(command);
                return Ok(proveedorId);
            }
            catch (Exception e)
            {
                _logger.LogError("An error occurred while trying to create a provider {Message}", e.Message);
                return StatusCode(500, "An error occurred while trying to create a provider");
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProveedores()
        {
            try
            {
                var query = new GetProveedorQuery();
                var proveedores = await _mediator.Send(query);
                return Ok(proveedores);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while getting providers: {Message}", e.Message);
                return StatusCode(500, "An error occurred while getting providers.");
            }
        }
    }
}
