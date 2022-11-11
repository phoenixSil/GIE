using Gie.Api.Dtos.Etudiants;
using MediatR;
using Register.API.DTOs.Etudiants;

namespace Register.API.Features.Commandes.Etudiants
{
    public class LireDetailDUnEtudiantCmd : IRequest<EtudiantDetailDto>
    {
        public Guid Id { get; set; }
    }
}
