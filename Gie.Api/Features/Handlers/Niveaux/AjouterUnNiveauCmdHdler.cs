using AutoMapper;
using MediatR;
using Gesc.Api.Features.Commandes.Niveaux;
using Gie.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using Gie.Api.Dtos.Niveaus.Validations;
using Gie.Domain.Modeles;

namespace Gesc.Api.Features.CommandHandlers.Niveaux
{
    public class AjouterUnNiveauCmdHdler : IRequestHandler<AjouterUnNiveauCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public AjouterUnNiveauCmdHdler(IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }
        public async Task<ReponseDeRequette> Handle(AjouterUnNiveauCmd request, CancellationToken cancellationToken)
        {
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDeNiveauDto();
            var resultatValidation = await validateur.ValidateAsync(request.NiveauAAjouterDto, cancellationToken);

            if(await _pointDaccess.RepertoireDeNiveau.ExistsByExternalId(request.NiveauAAjouterDto.NumeroExterne))
            {
                reponse.Success = true;
                reponse.Message = "le Niveaux Existe Deja";
                return reponse;
            }

            if (!resultatValidation.IsValid)
            {
                reponse.Success = false;
                reponse.Message = "Echec de Lajout dune Niveau a la personne donc l'Id est notee dans le champs d'Id";
                reponse.Errors = resultatValidation.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var niveauACreer = _mapper.Map<Niveau>(request.NiveauAAjouterDto);
                niveauACreer.Id = Guid.NewGuid();
                var result = await _pointDaccess.RepertoireDeNiveau.Ajoutter(niveauACreer);
                await _pointDaccess.Enregistrer();

                if (result is null)
                {
                    reponse.Success = false;
                    reponse.Message = "Echec de Lajout de Niveau";
                }
                else
                {
                    reponse.Success = true;
                    reponse.Message = "Ajout de Niveau Reussit";
                    reponse.Id = result.Id;
                }
            }

            return reponse;
        }
    }
}
