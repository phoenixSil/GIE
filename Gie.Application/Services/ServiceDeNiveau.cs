﻿using Gie.Features.Dtos.Config.Niveaux;
using Gie.Features.Contrats.Services;
using MediatR;
using MsCommun.Reponses;
using Gie.Features.Commandes.Niveaux;

namespace Gie.Features.Services
{
    public class ServiceDeNiveau : IServiceDeNiveau
    {
        private readonly IMediator _mediator;
        public ServiceDeNiveau(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ReponseDeRequette> AjouterUnNiveau(NiveauACreerDto etudiantAAjouter)
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

        public async Task<NiveauDetailDto> LireNiveauParNumeroExterne(Guid numeroExterne)
        {
            var etudiant = await _mediator.Send(new LireDetailDUnNiveauCmd { NumeroExterne = numeroExterne });
            return etudiant;
        }
    }
}
