using Gie.Api.Modeles;
using MsCommun.Repertoires.Contrats;

namespace Gie.Api.Repertoires.Contrats
{
    public interface IRepertoireDadresse : IRepertoireGenerique<Adresse>
    {
        public Task<List<Adresse>> LireToutesLesAdresseDunEtudiant(Guid eutiantId);

    }
}
