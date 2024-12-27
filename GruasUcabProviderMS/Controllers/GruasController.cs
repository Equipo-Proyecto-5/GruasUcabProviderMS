using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProviderMS.Application.Commands;
using ProviderMS.Application.Commands.Grua;
using ProviderMS.Application.Queries;
using ProviderMS.Commons.Dtos.Request;
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



        [HttpGet]

        public async Task<IActionResult> GetAllGruas()
        {
            try
            {
                var query = new GetGruaQuery();
                var gruas = await _mediator.Send(query);
                return Ok(gruas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all cranes.");
                return StatusCode(500, "An error occurred while getting all cranes.");
            }
        }
        [HttpGet("/locations")]
        public async Task<IActionResult> GetAllUbicacionGruas()
        {
            try
            {
                var query = new GetGruasUbicacionQuery();
                var gruas = await _mediator.Send(query);
                return Ok(gruas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all cranes.");
                return StatusCode(500, "An error occurred while getting all cranes.");
            }
        }
        [HttpGet("/expired")]
        public async Task<IActionResult> GetAllExpiredGruas()
        {
            try
            {
                var query = new GetLocalizacionVencidaQuery();
                await _mediator.Send(query);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all cranes.");
                return StatusCode(500, "An error occurred while getting all cranes.");
            }
        }


        [HttpPut("{id}")]

        public async Task<IActionResult> ModifyGrua(Guid id, [FromBody] ModifyGruaDto gruaDto)
        {
            // Verifica si el modelo es válido
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            try
            {
                var command = new ModifyGruaCommand(gruaDto, id);
                await _mediator.Send(command);
                return NoContent();
            }
            catch (ValidationException ex)
            {

                var errors = new List<string>();
                foreach (var failure in ex.Errors)
                {
                    Console.WriteLine("Propiedad: " + failure.PropertyName + " Error: " + failure.ErrorMessage);
                    errors.Add($"Propiedad: {failure.PropertyName} Error: {failure.ErrorMessage}");
                }

                _logger.LogError(ex, "Validation errors occurred while modifying the provider.");
                return BadRequest(errors);
            }
            catch (Exception e)
            {

                _logger.LogError(e, "An unexpected error occurred while modifying the provider.");
                return StatusCode(500, "Ha ocurrido un error al modificar la grua: " + e.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrua(Guid id)
        {
            try
            {
                var command = new DeleteGruaCommand(id);
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the crane.");
                return StatusCode(500, "An error occurred while deleting the crane.");
            }
        }

    }
}
