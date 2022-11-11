using MediatR;
using Gie.Api.Dtos.Adresses;
using MsCommun.Reponses;
using Register.API.DTOs.Adresses;
using Gie.Api.DTOs.Adresses;

namespace Gie.Api.Features.Commandes.Adresses
{
    public class ModifierAdresseDunEtudiantCmd : IRequest<ReponseDeRequette>
    {
        public Guid AdresseId { get; set; }
        public AdresseAModifierDto AdresseAModifierDto { get; set; }
    }
}
