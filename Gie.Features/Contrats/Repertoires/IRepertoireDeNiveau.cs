using Gie.Domain.Modeles;
using MsCommun.Repertoires.Contrats;

namespace Gie.Features.Contrats.Repertoires
{
    public interface IRepertoireDeNiveau : IRepertoireGenerique<Niveau>
    {
        Task<bool> ExistsByExternalId(Guid numeroExterne);
        Task<Niveau> LireParNumeroExterne(Guid value);
    }
}
