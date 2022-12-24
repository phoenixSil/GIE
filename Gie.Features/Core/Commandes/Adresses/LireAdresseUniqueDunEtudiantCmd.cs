using MediatR;
using Gie.Features.Dtos.Adresses;

namespace Gie.Features.Commandes.Adresses
{
    public class LireAdresseUniqueDunEtudiantCmd: IRequest<AdresseDetailDto>
    {
        public Guid EtudiantId { get; set; }
        public Guid AdresseId { get; set; }
    }
}
