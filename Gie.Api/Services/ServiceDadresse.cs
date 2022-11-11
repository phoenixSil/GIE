using Gie.Api.Core.Commandes.Adresses;
using Gie.Api.Dtos.Adresses;
using Gie.Api.DTOs.Adresses;
using Gie.Api.Features.Commandes.Adresses;
using MsCommun.Reponses;
using Gie.Api.Services.Contrats;
using MediatR;
using Register.API.DTOs.Adresses;

namespace Gie.Api.Services
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
            var response = await _mediator.Send(new AjouterUneAdresseAUnEtudiantCmd { AdresseACreerDto = adresseDto });
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
            var response = await _mediator.Send(new LireAdresseUniqueDunEtudiantCmd { AdresseId = adresseId });
            return response;
        }

        public async Task<List<AdresseDto>> LireToutesLesAdresseDunEtudiant(Guid personneId)
        {
            var response = await _mediator.Send(new LireToutesLesAdressesDunEtudiantCmd { PersonneId = personneId });
            return response;
        }

        public async Task<ReponseDeRequette> ModifierAdresseDunEtudiant(Guid adresseId, AdresseAModifierDto adresseDto)
        {
            var response = await _mediator.Send(new ModifierAdresseDunEtudiantCmd { AdresseId = adresseId, AdresseAModifierDto = adresseDto });
            return response;
        }


        public async Task<ReponseDeRequette> SupprimerAdresseDunEtudiant(Guid adresseId)
        {
            var response = await _mediator.Send(new SupprimerAdresseDunEtudiantCmd { AdresseId = adresseId });
            return response;
        }
    }
}