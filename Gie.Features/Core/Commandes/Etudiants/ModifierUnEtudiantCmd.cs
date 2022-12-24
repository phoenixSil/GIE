using MediatR;
using Register.API.DTOs.Etudiants;
using MsCommun.Reponses;
using Gie.Features.Dtos.Etudiants;

namespace Gie.Features.Commandes.Etudiants
{
    public class ModifierUnEtudiantCmd : IRequest<ReponseDeRequette>
    {
        public Guid EtudiantId { get; set; }
        public EtudiantAModifierDto EtudiantAModifierDto { get; set; }
    }
}
