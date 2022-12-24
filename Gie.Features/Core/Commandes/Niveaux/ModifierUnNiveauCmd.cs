using Gie.Features.Dtos.Config.Niveaux;
using MediatR;
using MsCommun.Reponses;

namespace Gie.Features.Commandes.Niveaux
{
    public class ModifierUnNiveauCmd : IRequest<ReponseDeRequette>
    {
        public Guid NiveauId { get; set; }
        public NiveauAModifierDto NiveauAModifierDto { get; set; }
    }
}
