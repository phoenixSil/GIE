using MediatR;
using Gie.Api.Dtos.Adresses;
using MsCommun.Reponses;

namespace Gie.Api.Features.Commandes.Adresses
{
    public class AjouterUneAdresseAUnEtudiantCmd : IRequest<ReponseDeRequette>
    {
        public AdresseACreerDto AdresseACreerDto { get; set; }
    }
}
