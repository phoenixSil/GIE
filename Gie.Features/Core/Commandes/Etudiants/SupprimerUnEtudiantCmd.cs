using MediatR;
using Register.API.DTOs.Etudiants;
using MsCommun.Reponses;

namespace Gie.Features.Commandes.Etudiants
{
    public class SupprimerUnEtudiantCmd: IRequest<ReponseDeRequette>
    {
        public Guid Id { get; set; }
    }
}
