using Gie.Api.Datas;
using Gie.Features.Contrats.Repertoires;

namespace Gie.Api.Repertoires
{
    public class PointDaccess : IPointDaccess
    {
        private readonly EtudiantDbContext _context;
        private IRepertoireDetudiant _repertoireDetudiant;
        private IRepertoireDadresse _repertoireDadresse;
        private IRepertoireDeNiveau _repertoireDeNiveau;

        public PointDaccess(EtudiantDbContext context)
        {
            _context = context;
        }

        public async Task Enregistrer()
        {
            await _context.SaveChangesAsync();
        }

        public IRepertoireDadresse RepertoireDadresse => _repertoireDadresse ??= new RepertoireDadresse(_context);
        public IRepertoireDetudiant RepertoireDetudiant => _repertoireDetudiant ??= new RepertoireDetudiant(_context);
        public IRepertoireDeNiveau RepertoireDeNiveau => _repertoireDeNiveau ??= new RepertoireDeNiveau(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
