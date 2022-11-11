using Gesc.Api.Features.Commandes.Niveaux;
using Gie.Api.Dtos.Config.Niveaux;
using Gie.Api.Services.Contrats;
using MediatR;
using MsCommun.Reponses;

namespace Gie.Api.Services
{
    public class ServiceDeNiveau : IServiceDeNiveau
    {
        private readonly IMediator _mediator;
        public ServiceDeNiveau(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ReponseDeRequette> AjouterUnNiveau(NiveauGieACreerDto etudiantAAjouter)
        {
            var resultatAjoutNiveau = await _mediator.Send(new AjouterUnNiveauCmd { NiveauAAjouterDto = etudiantAAjouter });
            return resultatAjoutNiveau;
        }

        public async Task<NiveauDetailDto> LireDetailDunNiveau(Guid id)
        {
            var etudiant = await _mediator.Send(new LireDetailDUnNiveauCmd { Id = id });
            return etudiant;
        }

        public async Task<List<NiveauDto>> LireTousLesNiveaux()
        {
            var listNiveau = await _mediator.Send(new LireTousLesNiveauxCmd { });
            return listNiveau;
        }

        public async Task<ReponseDeRequette> SupprimerUnNiveau(Guid NiveauId)
        {
            var resultatSuppression = await _mediator.Send(new SupprimerUnNiveauCmd { Id = NiveauId });
            return resultatSuppression;
        }

        public async Task<ReponseDeRequette> ModifierUnNiveau(Guid etudiantId, NiveauAModifierDto etudiantAModifier)
        {

            var resultatNiveauAModifier = await _mediator.Send(new ModifierUnNiveauCmd { NiveauAModifierDto = etudiantAModifier });
            return resultatNiveauAModifier;
        }
    }
}
