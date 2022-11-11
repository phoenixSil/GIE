using AutoMapper;
using MediatR;
using Register.API.DTOs.Etudiants.Validations;
using Register.API.Features.Commandes.Etudiants;
using Gie.Api.Modeles;
using Gie.Api.Repertoires.Contrats;
using MsCommun.Reponses;

namespace Register.API.Features.CommandHandlers.Etudiants
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
                reponse.Message = "Echec de Lajout dune Etudiant a la personne donc l'Id est notee dans le champs d'Id";
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
                    reponse.Message = "Echec de Lajout dune Etudiant a la personne donc l'Id est notee dans le champs d'Id";
                }
                else
                {
                    reponse.Success = true;
                    reponse.Message = "Ajout de Personne Reussit";
                    reponse.Id = result.Id;
                }
            }

            return reponse;
        }
    }
}
