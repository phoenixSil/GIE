using MediatR;
using Gie.Api.Dtos.Adresses;

namespace Gie.Api.Features.Commandes.Adresses
{
    public class LireAdresseUniqueDunEtudiantCmd: IRequest<AdresseDetailDto>
    {
        public Guid EtudiantId { get; set; }
        public Guid AdresseId { get; set; }
    }
}
