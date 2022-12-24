using Gie.Features.Dtos.Config.Niveaux;
using MsCommun.Reponses;

namespace Gie.Features.Contrats.Services
{
    public interface IServiceDeNiveau
    {
        public Task<List<NiveauDto>> LireTousLesNiveaux();
        public Task<ReponseDeRequette> AjouterUnNiveau(NiveauACreerDto niveauAAjouter);
        public Task<ReponseDeRequette> SupprimerUnNiveau(Guid NiveauId);
        public Task<NiveauDetailDto> LireDetailDunNiveau(Guid id);
        public Task<ReponseDeRequette> ModifierUnNiveau(Guid niveauId, NiveauAModifierDto niveauAModifierDto);
        public Task<NiveauDetailDto> LireNiveauParNumeroExterne(Guid numeroExterne);
    }
}
