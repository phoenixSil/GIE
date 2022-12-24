using Gie.Features.Dtos.Etudiants;
using MediatR;
using Register.API.DTOs.Etudiants;

namespace Gie.Features.Commandes.Etudiants
{
    public class LireTousLesEtudiantsCmd : IRequest<List<EtudiantDto>>
    {
        
    }
}
