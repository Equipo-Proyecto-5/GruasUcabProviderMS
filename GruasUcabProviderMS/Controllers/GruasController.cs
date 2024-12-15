using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProviderMS.Application.Commands.Grua;
using ProviderMS.Commons.Dtos.Request.Grua;

namespace GruasUcabProviderMS.Controllers


{

    [ApiController]
    [Route("[controller]")]
    public class GruasController : ControllerBase
    {

        private readonly ILogger<GruasController> _logger;
        private readonly IMediator _mediator;

        public GruasController(ILogger<GruasController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGrua([FromBody] CreateGruaDto createGruaDto)
        {
            // Verifica si el modelo es válido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var command = new CreateGruaCommand(createGruaDto);
                var gruaId = await _mediator.Send(command);
                return Ok(gruaId);
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
                _logger.LogError(ex, "Validation errors occurred while creating a crane.");
                return BadRequest(errors);
            }
        }


    }
}
