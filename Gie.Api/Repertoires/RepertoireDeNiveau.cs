using Gie.Api.Datas;
using Gie.Api.Modeles;
using Gie.Api.Repertoires.Contrats;
using Microsoft.EntityFrameworkCore;
using MsCommun.Repertoires;
using System;

namespace Gie.Api.Repertoires
{
    public class RepertoireDeNiveau : RepertoireGenerique<Niveau>, IRepertoireDeNiveau
    {
        private readonly EtudiantDbContext _context;
        public RepertoireDeNiveau(EtudiantDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExistsByExternalId(Guid numeroExterne)
        {
            return await _context.Niveaux.AnyAsync(p => p.NumeroExterne.CompareTo(numeroExterne) == 0);
        }

        public async Task<Niveau> LireParNumeroExterne(Guid numeroExterne)
        {
            var niveau = await _context.Niveaux
                    .SingleOrDefaultAsync(niv => niv.NumeroExterne == numeroExterne);

            return niveau;
        }
    }
}
