﻿using Gie.Api.Datas;
using Gie.Domain.Modeles;
using Gie.Features.Contrats.Repertoires;
using Microsoft.EntityFrameworkCore;
using MsCommun.Repertoires;


namespace Gie.Api.Repertoires
{
    public class RepertoireDadresse : RepertoireGenerique<Adresse>, IRepertoireDadresse
    {
        private readonly EtudiantDbContext _context;
        public RepertoireDadresse(EtudiantDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Adresse>> LireToutesLesAdresseDunEtudiant(Guid etudiantId)
        {
            var listeAdresse = await _context.Adresses
                .Where(pers => pers.EtudiantId == etudiantId)
                .ToListAsync();

            return listeAdresse;
        }

    }
}
