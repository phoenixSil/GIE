using MediatR;
using Register.API.DTOs.Etudiants;
using MsCommun.Reponses;

namespace Register.API.Features.Commandes.Etudiants
{
    public class SupprimerUnEtudiantCmd: IRequest<ReponseDeRequette>
    {
        public Guid Id { get; set; }
    }
}
