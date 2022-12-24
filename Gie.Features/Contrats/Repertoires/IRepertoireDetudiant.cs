using Gie.Domain.Modeles;
using MsCommun.Repertoires.Contrats;

namespace Gie.Features.Contrats.Repertoires
{
    public interface IRepertoireDetudiant : IRepertoireGenerique<Etudiant>
    {
        public Task<Etudiant> LireDetailDunEtudiant(Guid id);
    }
}
