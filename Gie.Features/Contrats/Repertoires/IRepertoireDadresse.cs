using Gie.Domain.Modeles;
using MsCommun.Repertoires.Contrats;

namespace Gie.Features.Contrats.Repertoires
{
    public interface IRepertoireDadresse : IRepertoireGenerique<Adresse>
    {
        public Task<List<Adresse>> LireToutesLesAdresseDunEtudiant(Guid eutiantId);

    }
}
