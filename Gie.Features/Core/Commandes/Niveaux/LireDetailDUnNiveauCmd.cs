using Gie.Features.Dtos.Config.Niveaux;
using MediatR;

namespace Gie.Features.Commandes.Niveaux
{
    public class LireDetailDUnNiveauCmd : IRequest<NiveauDetailDto>
    {
        public Guid? Id { get; set; }
        public Guid? NumeroExterne { get; set; }
    }
}
