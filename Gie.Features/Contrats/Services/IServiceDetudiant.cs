using Gie.Features.Dtos.Etudiants;
using MsCommun.Reponses;
using Register.API.DTOs.Etudiants;

namespace Gie.Features.Contrats.Services
{
    public interface IServiceDetudiant
    {
        public Task<List<EtudiantDto>> LireTousLesEtudiants();
        public Task<ReponseDeRequette> AjouterUnEtudiant(EtudiantACreerDto etudiantAAjouter);
        public Task<ReponseDeRequette> SupprimerUnEtudiant(Guid EtudiantId);
        public Task<EtudiantDetailDto> LireDetailDunEtudiant(Guid id);
        public Task<ReponseDeRequette> ModifierUnEtudiant(Guid etudiantId, EtudiantAModifierDto etudiantAModifierDto);

    }
}
