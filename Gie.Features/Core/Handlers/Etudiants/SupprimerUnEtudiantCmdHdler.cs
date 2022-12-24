using AutoMapper;
using MediatR;
using Register.API.DTOs.Etudiants;
using MsCommun.Exceptions;
using Gie.Features.Commandes.Etudiants;
using Gie.Domain.Modeles;
using Gie.Features.Contrats.Repertoires;
using MsCommun.Reponses;

namespace Gie.Features.CommandHandlers.Etudiants
{
    public class SupprimerUnEtudiantCmdHdler : IRequestHandler<SupprimerUnEtudiantCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMediator _mediator;

        public SupprimerUnEtudiantCmdHdler(IPointDaccess pointDaccess, IMediator mediator)
        {
            _pointDaccess = pointDaccess;
            _mediator = mediator;
        }

        public async Task<ReponseDeRequette> Handle(SupprimerUnEtudiantCmd request, CancellationToken cancellationToken)
        {
            var response = new ReponseDeRequette();

            var etudiant = await _pointDaccess.RepertoireDetudiant.Lire(request.Id);

            if (etudiant == null)
                throw new NotFoundException(nameof(Etudiant), request.Id);

            if (etudiant != null)
            {
                var resultat = await _pointDaccess.RepertoireDetudiant.Supprimer(etudiant);
                if (resultat == true)
                {
                    response.Success = true;
                    response.Message = $"l'etudiant d'Id [{request.Id}] a ete supprimer avec success ";

                    // on supprime la personne associer a cet etudiant 
                    await _mediator.Send(new SupprimerUnEtudiantCmd { Id = etudiant.Id }, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Une Erreur Inconnu est Survenue dans le Serveur ";
                }
            }
            else
            {
                response.Success = false;
                response.Message = $"il n'existe pas d'etudiant d'Id {request.Id}";
            }
            return response;
        }
    }
}
