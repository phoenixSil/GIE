using MediatR;
using Gie.Features.Dtos.Adresses;
using Gie.Domain.Modeles;
using MsCommun.Reponses;

namespace Gie.Features.Commandes.Adresses
{
    public class SupprimerUneAdresseCmd : IRequest<ReponseDeRequette>
    {
        public Guid AdresseId { get; set; }
    }
}
