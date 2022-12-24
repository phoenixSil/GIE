using MediatR;
using MsCommun.Reponses;

namespace Gie.Features.Commandes.Niveaux
{
    public class SupprimerUnNiveauCmd : IRequest<ReponseDeRequette>
    {
        public Guid Id { get; set; }
    }
}
