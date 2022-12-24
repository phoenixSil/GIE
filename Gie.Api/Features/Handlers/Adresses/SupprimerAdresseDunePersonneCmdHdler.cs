using AutoMapper;
using MediatR;
using MsCommun.Exceptions;
using Gie.Domain.Modeles;
using Gie.Api.Repertoires;
using Gie.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using Gie.Api.Features.Commandes.Adresses;

namespace Register.API.Features.CommandHandlers.Adresses
{
    public class SupprimerAdresseDunePersonneCmdHdler : IRequestHandler<SupprimerAdresseDunEtudiantCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDAccess;
        public SupprimerAdresseDunePersonneCmdHdler(IPointDaccess pointDAccess)
        {
            _pointDAccess = pointDAccess;
        }
        public async Task<ReponseDeRequette> Handle(SupprimerAdresseDunEtudiantCmd request, CancellationToken cancellationToken)
        {
            var response = new ReponseDeRequette();

            var adresse = await _pointDAccess.RepertoireDadresse.Lire(request.AdresseId);

            //validation
            if (adresse is null)
                throw new NotFoundException(nameof(Adresse),request.AdresseId);

            var resultat = await _pointDAccess.RepertoireDadresse.Supprimer(adresse);

            if (resultat == true)
            {
                response.Success = true;
                response.Message = $"l'adresse d'Id [{request.AdresseId}] a ete supprimer avec success ";
            }
            else
            {
                response.Success = false;
                response.Message = $"Une Erreur Inconnu est Survenue dans le Serveur ";
            }
            return response;
        }
    }
}
