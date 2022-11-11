using Gie.Api.Modeles;
using MsCommun.Repertoires.Contrats;

namespace Gie.Api.Repertoires.Contrats
{
    public interface IRepertoireDetudiant : IRepertoireGenerique<Etudiant>
    {
        public Task<Etudiant> LireDetailDunEtudiant(Guid id);
    }
}
