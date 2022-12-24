using Gie.Features.Dtos.Etudiants;
using MsCommun.Reponses;
using Gie.Features.Contrats.Services;
using MediatR;
using Register.API.DTOs.Etudiants;
using Gie.Features.Commandes.Etudiants;

namespace Gie.Features.Services
{
    public class ServiceDetudiant : IServiceDetudiant
    {
        private readonly IMediator _mediator;
        public ServiceDetudiant(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ReponseDeRequette> AjouterUnEtudiant(EtudiantACreerDto etudiantAAjouter)
        {
            var resultatAjoutEtudiant = await _mediator.Send(new AjouterUnEtudiantCmd { EtudiantAAjouterDto = etudiantAAjouter });
            return resultatAjoutEtudiant;
        }

        public async Task<EtudiantDetailDto> LireDetailDunEtudiant(Guid id)
        {
            var etudiant = await _mediator.Send(new LireDetailDUnEtudiantCmd { Id = id });
            return etudiant;
        }

        public async Task<List<EtudiantDto>> LireTousLesEtudiants()
        {
            var listEtudiant = await _mediator.Send(new LireTousLesEtudiantsCmd { });
            return listEtudiant;
        }

        public async Task<ReponseDeRequette> SupprimerUnEtudiant(Guid EtudiantId)
        {
            var resultatSuppression = await _mediator.Send(new SupprimerUnEtudiantCmd { Id = EtudiantId });
            return resultatSuppression;
        }

        public async Task<ReponseDeRequette> ModifierUnEtudiant(Guid etudiantId, EtudiantAModifierDto etudiantAModifier)
        {
           
            var resultatEtudiantAModifier = await _mediator.Send(new ModifierUnEtudiantCmd { EtudiantAModifierDto = etudiantAModifier });
            return resultatEtudiantAModifier;
        }
    }
}
