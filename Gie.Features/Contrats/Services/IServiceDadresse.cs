using Gie.Features.Dtos.Adresses;
using Gie.Features.DTOs.Adresses;
using MsCommun.Reponses;
using Register.API.DTOs.Adresses;

namespace Gie.Features.Contrats.Services
{
    public interface IServiceDadresse
    {
        public Task<List<AdresseDto>> LireToutesLesAdresseDunEtudiant(Guid personneId);
        public Task<AdresseDetailDto> LireAdresseUniqueDunEtudiant(Guid adresseId);
        public Task<ReponseDeRequette> ModifierAdresseDunEtudiant(Guid adresseId, AdresseAModifierDto adresseDto);
        public Task<ReponseDeRequette> AjouterUneAdresseAUnEtudiant(AdresseACreerDto adresseDto);
        public Task<List<ReponseDeRequette>> AjouterUneListeDAdresseAUnEtudiant(List<AdresseACreerDto> adresseDto);
        public Task<ReponseDeRequette> SupprimerAdresseDunEtudiant(Guid adresseId);

    }
}
