using Gie.Features.Dtos.Adresses;
using Gie.Features.DTOs.Adresses;
using Gie.Features.Commandes.Adresses;
using MsCommun.Reponses;
using Gie.Features.Contrats.Services;
using MediatR;
using Register.API.DTOs.Adresses;
using Gie.Features.Contrats.Services;
using Gie.Api.Core.Commandes.Adresses;

namespace Gie.Features.Services
{
    public class ServiceDadresse: IServiceDadresse
    {
        private readonly IMediator _mediator;
        public ServiceDadresse(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<ReponseDeRequette> AjouterUneAdresseAUnEtudiant(AdresseACreerDto adresseDto)
        {
            var response = await _mediator.Send(new AjouterUneAdresseCmd { AdresseACreerDto = adresseDto });
            return response;
        }

        public async Task<List<ReponseDeRequette>> AjouterUneListeDAdresseAUnEtudiant(List<AdresseACreerDto> adresseDto)
        {
            var responseList = new List<ReponseDeRequette>();

            foreach (var adresseACreer in adresseDto)
            {
                responseList.Add(await AjouterUneAdresseAUnEtudiant(adresseACreer));
            }

            return responseList;
        }

        public async Task<AdresseDetailDto> LireAdresseUniqueDunEtudiant(Guid adresseId)
        {
            var response = await _mediator.Send(new LireDetailDuneAdresseCmd { AdresseId = adresseId });
            return response;
        }

        public async Task<List<AdresseDto>> LireToutesLesAdresseDunEtudiant(Guid personneId)
        {
            var response = await _mediator.Send(new LireToutesLesAdressesCmd { PersonneId = personneId });
            return response;
        }

        public async Task<ReponseDeRequette> ModifierAdresseDunEtudiant(Guid adresseId, AdresseAModifierDto adresseDto)
        {
            var response = await _mediator.Send(new ModifierUneAdresseCmd { AdresseId = adresseId, AdresseAModifierDto = adresseDto });
            return response;
        }


        public async Task<ReponseDeRequette> SupprimerAdresseDunEtudiant(Guid adresseId)
        {
            var response = await _mediator.Send(new SupprimerUneAdresseCmd { AdresseId = adresseId });
            return response;
        }
    }
}