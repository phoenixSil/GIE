using AutoMapper;
using MediatR;
using Register.API.DTOs.Adresses;
using MsCommun.Exceptions;
using Gie.Domain.Modeles;
using Gie.Features.Contrats.Repertoires;
using Gie.Api.Core.Commandes.Adresses;
using Gie.Features.Dtos.Adresses;

namespace Gie.Features.CommandHandlers.Adresses
{
    public class LireToutesLesAdresseCmdHdler : IRequestHandler<LireToutesLesAdressesCmd, List<AdresseDto>>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireToutesLesAdresseCmdHdler(IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<List<AdresseDto>> Handle(LireToutesLesAdressesCmd request, CancellationToken cancellationToken)
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
