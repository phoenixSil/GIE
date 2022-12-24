using AutoMapper;
using MediatR;
using Register.API.DTOs.Adresses;
using Gie.Features.Contrats.Repertoires;
using Gie.Features.Dtos.Adresses;
using Gie.Features.Commandes.Adresses;

namespace Gie.Features.CommandHandlers.Adresses
{
    public class LireUneAdresseCmdHdler : IRequestHandler<LireDetailDuneAdresseCmd, AdresseDetailDto>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireUneAdresseCmdHdler(IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<AdresseDetailDto> Handle(LireDetailDuneAdresseCmd request, CancellationToken cancellationToken)
        {
            var adresse = await _pointDaccess.RepertoireDadresse.Lire(request.AdresseId);
            var adresseDetail = _mapper.Map<AdresseDetailDto>(adresse);

            return adresseDetail;
        }
    }
}
