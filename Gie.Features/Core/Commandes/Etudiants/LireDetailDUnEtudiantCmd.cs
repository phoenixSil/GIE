using Gie.Features.Dtos.Etudiants;
using MediatR;
using Register.API.DTOs.Etudiants;

namespace Gie.Features.Commandes.Etudiants
{
    public class LireDetailDUnEtudiantCmd : IRequest<EtudiantDetailDto>
    {
        public Guid Id { get; set; }
    }
}
