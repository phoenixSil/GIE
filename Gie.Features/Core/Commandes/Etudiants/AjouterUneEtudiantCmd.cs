using MediatR;
using Register.API.DTOs.Etudiants;
using MsCommun.Reponses;
using Gie.Features.Dtos.Etudiants;

namespace Gie.Features.Commandes.Etudiants
{
    public class AjouterUnEtudiantCmd : IRequest<ReponseDeRequette>
    {
        public EtudiantACreerDto EtudiantAAjouterDto { get; set; }
    }
}
