using AutoMapper;
using MediatR;
using Register.API.DTOs.Etudiants.Validations;
using Gie.Features.Commandes.Etudiants;
using Gie.Domain.Modeles;
using Gie.Features.Contrats.Repertoires;
using MsCommun.Reponses;

namespace Gie.Features.CommandHandlers.Etudiants
{
    public class AjouterUneEtudiantAUnePersonneCmdHdler : IRequestHandler<AjouterUnEtudiantCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public AjouterUneEtudiantAUnePersonneCmdHdler(IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }
        public async Task<ReponseDeRequette> Handle(AjouterUnEtudiantCmd request, CancellationToken cancellationToken)
        {
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDetudiantDto(_pointDaccess);
            var resultatValidation = await validateur.ValidateAsync(request.EtudiantAAjouterDto);

            if (resultatValidation.IsValid == false)
            {
                reponse.Success = false;
                reponse.Message = "Echec de Lajout dun Etudiant";
                reponse.Errors = resultatValidation.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var etudiantACreer = _mapper.Map<Etudiant>(request.EtudiantAAjouterDto);
                var result = await _pointDaccess.RepertoireDetudiant.Ajoutter(etudiantACreer);
                await _pointDaccess.Enregistrer();

                if (result == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Echec de Lajout dun Etudiant ";
                }
                else
                {
                    reponse.Success = true;
                    reponse.Message = "Ajout d Etudiant Reussit";
                    reponse.Id = result.Id;
                }
            }

            return reponse;
        }
    }
}
