using Gie.Api.Dtos.Config.Niveaux;
using MediatR;
using MsCommun.Reponses;

namespace Gesc.Api.Features.Commandes.Niveaux
{
    public class ModifierUnNiveauCmd : IRequest<ReponseDeRequette>
    {
        public Guid NiveauId { get; set; }
        public NiveauAModifierDto NiveauAModifierDto { get; set; }
    }
}
