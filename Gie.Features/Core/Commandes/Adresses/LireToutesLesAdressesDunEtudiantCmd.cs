using MediatR;
using Gie.Features.Dtos.Adresses;

namespace Gie.Api.Core.Commandes.Adresses
{
    public class LireToutesLesAdressesDunEtudiantCmd: IRequest<List<AdresseDto>>
    {
        public Guid PersonneId { get; set; }
    }
}
