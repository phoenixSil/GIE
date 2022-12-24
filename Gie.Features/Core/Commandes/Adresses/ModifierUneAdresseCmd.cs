using MediatR;
using MsCommun.Reponses;
using Gie.Features.DTOs.Adresses;

namespace Gie.Features.Commandes.Adresses
{
    public class ModifierUneAdresseCmd : IRequest<ReponseDeRequette>
    {
        public Guid AdresseId { get; set; }
        public AdresseAModifierDto AdresseAModifierDto { get; set; }
    }
}
