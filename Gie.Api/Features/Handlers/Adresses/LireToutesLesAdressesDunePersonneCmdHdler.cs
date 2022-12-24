using AutoMapper;
using MediatR;
using Register.API.DTOs.Adresses;
using MsCommun.Exceptions;
using Gie.Domain.Modeles;
using Gie.Api.Repertoires.Contrats;
using Gie.Api.Core.Commandes.Adresses;
using Gie.Api.Dtos.Adresses;

namespace Register.API.Features.CommandHandlers.Adresses
{
    public class LireToutesLesAdressesDunEtudiantCmdHdler : IRequestHandler<LireToutesLesAdressesDunEtudiantCmd, List<AdresseDto>>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireToutesLesAdressesDunEtudiantCmdHdler(IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<List<AdresseDto>> Handle(LireToutesLesAdressesDunEtudiantCmd request, CancellationToken cancellationToken)
        {
            var personne = await _pointDaccess.RepertoireDetudiant.Lire(request.PersonneId);

            if (personne == null)
                throw new NotFoundException(nameof(Etudiant), request.PersonneId);

            var listAdresse = _pointDaccess.RepertoireDadresse.LireToutesLesAdresseDunEtudiant(request.PersonneId);

            var listAdresseDto = _mapper.Map<List<AdresseDto>>(listAdresse);

            return listAdresseDto;
        }
    }
}
