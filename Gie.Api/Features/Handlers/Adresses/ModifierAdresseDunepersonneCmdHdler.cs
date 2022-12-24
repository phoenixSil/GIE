using AutoMapper;
using MediatR;
using Register.API.DTOs.Adresses.Validations;
using MsCommun.Exceptions;
using Gie.Domain.Modeles;
using Gie.Api.Repertoires;
using Gie.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using Gie.Api.Features.Commandes.Adresses;

namespace Register.API.Features.CommandHandlers.Adresses
{
    public class ModifierAdresseDunEtudiantCmdHdler : IRequestHandler<ModifierAdresseDunEtudiantCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ModifierAdresseDunEtudiantCmdHdler(IPointDaccess pointDaccess, IMediator mediator, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ReponseDeRequette> Handle(ModifierAdresseDunEtudiantCmd request, CancellationToken cancellationToken)
        {

            var adresse = await _pointDaccess.RepertoireDadresse.Lire(request.AdresseId);

            if (adresse is null)
                throw new NotFoundException(nameof(adresse), request.AdresseId);

            if(request.AdresseAModifierDto != null)
            {
                var reponse = new ReponseDeRequette();
                var validateur = new ValidateurDeLaModificationDadresseDto(_pointDaccess);
                var resultatValidation = await validateur.ValidateAsync(request.AdresseAModifierDto, cancellationToken);

                if (!await _pointDaccess.RepertoireDadresse.Exists(request.AdresseId))
                    throw new BadRequestException($"L'un des Ids Adresse::[{request.AdresseId}] que vous avez entrez est null");

                if (resultatValidation.IsValid == false)
                    throw new ValidationException(resultatValidation);

                _mapper.Map(request.AdresseAModifierDto, adresse);

                await _pointDaccess.RepertoireDadresse.Modifier(adresse);
                await _pointDaccess.Enregistrer();

                reponse.Success = true;
                reponse.Message = "Modification Reussit";
                reponse.Id = adresse.Id;

                return reponse;

            }

            throw new BadRequestException("adresse a Modifier est null");

        }
    }
}
