using AutoMapper;
using MediatR;
using Gie.Features.Commandes.Niveaux;
using Gie.Features.Dtos.Config.Niveaux;
using MsCommun.Exceptions;
using Microsoft.Extensions.Logging;
using Gie.Features.Contrats.Repertoires;

namespace Gie.Features.CommandHandlers.Niveaux
{
    public class LireDetailDUnNiveauCmdHdler : IRequestHandler<LireDetailDUnNiveauCmd, NiveauDetailDto>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;
        private readonly ILogger<LireDetailDUnNiveauCmdHdler> _logger;

        public LireDetailDUnNiveauCmdHdler(IMapper mapper, IPointDaccess pointDaccess, ILogger<LireDetailDUnNiveauCmdHdler> logger)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<NiveauDetailDto> Handle(LireDetailDUnNiveauCmd request, CancellationToken cancellationToken)
        {
            _logger.LogError($"Lecture du detail dun Niveau ");
            if (request.Id.HasValue)
            {
                var niveau = await _pointDaccess.RepertoireDeNiveau.Lire(request.Id.Value);
                var NiveauDetail = _mapper.Map<NiveauDetailDto>(niveau);
                return NiveauDetail;
            }
            else if(request.NumeroExterne.HasValue)
            {
                var niveau = await _pointDaccess.RepertoireDeNiveau.LireParNumeroExterne(request.NumeroExterne.Value);
                var NiveauDetail = _mapper.Map<NiveauDetailDto>(niveau);
                return NiveauDetail;
            }
            else
            {
                _logger.LogError($"Une erreur Inconnue est survenue {request.Id} et NumeroExterne {request.NumeroExterne}");
                throw new BadRequestException($"Une erreur Inconnue est survenue {request.Id} et NumeroExterne {request.NumeroExterne}");
            }
        }
    }
}
