using Gie.Api.Datas;
using Gie.Domain.Modeles;
using Gie.Features.Contrats.Repertoires;
using Microsoft.EntityFrameworkCore;
using MsCommun.Repertoires;

namespace Gie.Api.Repertoires
{
    public class RepertoireDetudiant : RepertoireGenerique<Etudiant>, IRepertoireDetudiant
    {
        private readonly EtudiantDbContext _context;
        public RepertoireDetudiant(EtudiantDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Etudiant> LireDetailDunEtudiant(Guid id)
        {
            var etudiant = await _context.Etudiants.Where(x => x.Id == id)
                .Include(etd => etd.Adresses).
                Include(etd => etd.Niveau)
                .SingleOrDefaultAsync();

            return etudiant;
        }
    }
}
