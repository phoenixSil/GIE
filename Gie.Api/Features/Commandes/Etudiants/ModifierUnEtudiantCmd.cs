using MediatR;
using Register.API.DTOs.Etudiants;
using MsCommun.Reponses;
using Gie.Api.Dtos.Etudiants;

namespace Register.API.Features.Commandes.Etudiants
{
    public class ModifierUnEtudiantCmd : IRequest<ReponseDeRequette>
    {
        public Guid EtudiantId { get; set; }
        public EtudiantAModifierDto EtudiantAModifierDto { get; set; }
    }
}
