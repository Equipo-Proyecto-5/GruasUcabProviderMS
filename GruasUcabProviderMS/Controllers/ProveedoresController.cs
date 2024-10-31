
using FluentValidation;
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
        public async Task<IActionResult> CreateProveedor([FromBody] CreateProveedorDto createProveedorDto)
        {
            // Verifica si el modelo es válido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var command = new CreateProveedorCommand(createProveedorDto);
                var proveedorId = await _mediator.Send(command);
                return Ok(proveedorId);
            }
            catch (ValidationException ex)
            {
                var errors = new List<string>();
                foreach (var failure in ex.Errors)
                {
                    Console.WriteLine("Propiedad: " + failure.PropertyName + " Error: " + failure.ErrorMessage);
                    errors.Add($"Propiedad: {failure.PropertyName} Error: {failure.ErrorMessage}");
                }
                // Manejo específico de errores de validación
                _logger.LogError(ex, "Validation errors occurred while creating a provider.");
                return BadRequest(errors);
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
