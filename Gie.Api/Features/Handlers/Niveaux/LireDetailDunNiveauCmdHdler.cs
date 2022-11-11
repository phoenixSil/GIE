using AutoMapper;
using MediatR;
using Gesc.Api.Features.Commandes.Niveaux;
using Gie.Api.Dtos.Config.Niveaux;
using Gie.Api.Repertoires.Contrats;

namespace Gesc.Api.Features.CommandHandlers.Niveaux
{
    public class LireDetailDUnNiveauCmdHdler : IRequestHandler<LireDetailDUnNiveauCmd, NiveauDetailDto>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireDetailDUnNiveauCmdHdler(IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<NiveauDetailDto> Handle(LireDetailDUnNiveauCmd request, CancellationToken cancellationToken)
        {
            var niveau = await _pointDaccess.RepertoireDeNiveau.Lire(request.Id);
            var NiveauDetail = _mapper.Map<NiveauDetailDto>(niveau);

            return NiveauDetail;
        }
    }
}
