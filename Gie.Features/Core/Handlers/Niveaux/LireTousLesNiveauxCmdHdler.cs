using AutoMapper;
using MediatR;
using Gie.Features.Commandes.Niveaux;
using Gie.Features.Dtos.Config.Niveaux;
using Gie.Features.Contrats.Repertoires;

namespace Gie.Features.CommandHandlers.Niveaux
{
    public class LireTousLesNiveauxCmdHdler : IRequestHandler<LireTousLesNiveauxCmd, List<NiveauDto>>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireTousLesNiveauxCmdHdler(IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<List<NiveauDto>> Handle(LireTousLesNiveauxCmd request, CancellationToken cancellationToken)
        {

            var listNiveau = await _pointDaccess.RepertoireDeNiveau.Lire();

            var listNiveauDto = _mapper.Map<List<NiveauDto>>(listNiveau);

            return listNiveauDto;
        }
    }
}
