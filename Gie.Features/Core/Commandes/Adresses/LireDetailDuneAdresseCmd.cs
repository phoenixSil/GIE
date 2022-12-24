using MediatR;
using Gie.Features.Dtos.Adresses;

namespace Gie.Features.Commandes.Adresses
{
    public class LireDetailDuneAdresseCmd: IRequest<AdresseDetailDto>
    {
        public Guid EtudiantId { get; set; }
        public Guid AdresseId { get; set; }
    }
}
