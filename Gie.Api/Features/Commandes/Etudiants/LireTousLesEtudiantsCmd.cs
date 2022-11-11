using Gie.Api.Dtos.Etudiants;
using MediatR;
using Register.API.DTOs.Etudiants;

namespace Register.API.Features.Commandes.Etudiants
{
    public class LireTousLesEtudiantsCmd : IRequest<List<EtudiantDto>>
    {
        
    }
}
