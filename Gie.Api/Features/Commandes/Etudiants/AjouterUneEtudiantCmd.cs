using MediatR;
using Register.API.DTOs.Etudiants;
using MsCommun.Reponses;
using Gie.Api.Dtos.Etudiants;

namespace Register.API.Features.Commandes.Etudiants
{
    public class AjouterUnEtudiantCmd : IRequest<ReponseDeRequette>
    {
        public EtudiantACreerDto EtudiantAAjouterDto { get; set; }
    }
}
