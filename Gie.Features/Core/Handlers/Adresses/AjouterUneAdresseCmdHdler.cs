using AutoMapper;
using MediatR;
using Register.API.DTOs.Adresses.Validations;
using Gie.Domain.Modeles;
using Gie.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using Gie.Features.Commandes.Adresses;

namespace Gie.Features.CommandHandlers.Adresses
{
    public class AjouterUneAdresseCmdHdler : IRequestHandler<AjouterUneAdresseCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public AjouterUneAdresseCmdHdler(IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }
        public async Task<ReponseDeRequette> Handle(AjouterUneAdresseCmd request, CancellationToken cancellationToken)
        {            
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDadresseDto(_pointDaccess);
            var resultatValidation = await validateur.ValidateAsync(request.AdresseACreerDto);

            if(resultatValidation.IsValid == false)
            {
                reponse.Success = false;
                reponse.Message = "Echec de Lajout dune Adresse";
                reponse.Errors = resultatValidation.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var adresseACreer = _mapper.Map<Adresse>(request.AdresseACreerDto);
                var result = await _pointDaccess.RepertoireDadresse.Ajoutter(adresseACreer);
                await _pointDaccess.Enregistrer();

                if (result == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Echec de Lajout dune Adresse ";
                }
                else
                {
                    reponse.Success = true;
                    reponse.Message = "Ajout d adresse Reussit";
                    reponse.Id = result.Id;
                }
            }

            return reponse;
        }
    }
}
