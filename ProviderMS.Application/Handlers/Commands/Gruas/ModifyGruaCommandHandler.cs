using AutoMapper;
using MediatR;
using ProviderMS.Application.Commands.Grua;
using ProviderMS.Application.Exceptions;
using ProviderMS.Application.Validators.Grua;
using ProviderMS.Core.Repositories;
using ProviderMS.Domain.Entities;


namespace ProviderMS.Application.Handlers.Commands.Gruas
{
    public class ModifyGruaCommandHandler : IRequestHandler<ModifyGruaCommand, Unit>
    {
        private readonly IGruaRepository _gruaRepository;
        private readonly IMapper _mapper;

        public ModifyGruaCommandHandler(IGruaRepository gruaRepository, IMapper mapper)
        {
            _gruaRepository = gruaRepository;
            _mapper = mapper;
        }


        public async Task<Unit> Handle(ModifyGruaCommand request, CancellationToken cancellationToken)
        {
            var validator = new ModifyGruaValidator();
            await validator.ValidateRequest(request.ModifyGrua);

            var gruas = await _gruaRepository.GetAllAsyncGrua();
            var gruaExistente = gruas.FirstOrDefault(p => p.Placa == request.ModifyGrua.Placa);

            if (gruaExistente != null && gruaExistente.Id != request.ModifyGrua.Id)
            {
                throw new ValidatorException("La grua ya cuenta con registro previo");
            }

            var grua = _mapper.Map<Grua>(request.ModifyGrua);

            await _gruaRepository.ModifyAsyncGrua(grua);

            return Unit.Value;
        }



    }
}
