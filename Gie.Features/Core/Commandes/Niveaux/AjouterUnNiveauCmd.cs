using Gie.Features.Dtos.Config.Niveaux;
using MediatR;
using MsCommun.Reponses;

namespace Gie.Features.Commandes.Niveaux
{
    public class AjouterUnNiveauCmd : IRequest<ReponseDeRequette>
    {
        public NiveauACreerDto NiveauAAjouterDto { get; set; }
    }
}
