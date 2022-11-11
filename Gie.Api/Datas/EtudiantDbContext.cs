using Gie.Api.Modeles;
using Microsoft.EntityFrameworkCore;

namespace Gie.Api.Datas
{
    public class EtudiantDbContext: DbContext
    {
        public EtudiantDbContext(DbContextOptions<EtudiantDbContext> options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Etudiant>())
            {
                entry.Entity.DateDerniereModification = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreation = DateTime.Now;
                    entry.Entity.DateInscription = DateTime.Now;
                }
                    
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EtudiantDbContext).Assembly);
        }

        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Niveau> Niveaux { get; set; }
    }
}
