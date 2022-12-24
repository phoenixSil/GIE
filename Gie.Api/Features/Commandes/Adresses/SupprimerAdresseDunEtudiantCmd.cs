using MediatR;
using Gie.Api.Dtos.Adresses;
using Gie.Domain.Modeles;
using MsCommun.Reponses;

namespace Gie.Api.Features.Commandes.Adresses
{
    public class SupprimerAdresseDunEtudiantCmd : IRequest<ReponseDeRequette>
    {
        public Guid AdresseId { get; set; }
    }
}
