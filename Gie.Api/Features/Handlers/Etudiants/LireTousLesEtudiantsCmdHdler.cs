using AutoMapper;
using MediatR;
using Register.API.DTOs.Etudiants;
using MsCommun.Exceptions;
using Register.API.Features.Commandes.Etudiants;
using Gie.Api.Modeles;
using Gie.Api.Repertoires.Contrats;
using Gie.Api.Dtos.Etudiants;

namespace Register.API.Features.CommandHandlers.Etudiants
{
    public class LireTousLesEtudiantsCmdHdler : IRequestHandler<LireTousLesEtudiantsCmd, List<EtudiantDto>>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireTousLesEtudiantsCmdHdler(IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<List<EtudiantDto>> Handle(LireTousLesEtudiantsCmd request, CancellationToken cancellationToken)
        {

            var listEtudiant = await _pointDaccess.RepertoireDetudiant.Lire();

            var listEtudiantDto = _mapper.Map<List<EtudiantDto>>(listEtudiant);

            return listEtudiantDto;
        }
    }
}
