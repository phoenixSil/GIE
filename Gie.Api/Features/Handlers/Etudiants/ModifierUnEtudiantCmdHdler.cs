using AutoMapper;
using MediatR;
using Register.API.DTOs.Etudiants;
using Register.API.DTOs.Etudiants;
using Register.API.DTOs.Etudiants.Validations;
using MsCommun.Exceptions;
using Register.API.Features.Commandes.Etudiants;
using Gie.Domain.Modeles;
using Gie.Api.Repertoires.Contrats;
using MsCommun.Reponses;

namespace Register.API.Features.CommandHandlers.Etudiants
{
    public class ModifierUnEtudiantCmdHdler : IRequestHandler<ModifierUnEtudiantCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ModifierUnEtudiantCmdHdler(IPointDaccess pointDaccess, IMediator mediator, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<ReponseDeRequette> Handle(ModifierUnEtudiantCmd request, CancellationToken cancellationToken)
        {
            var etudiant = await _pointDaccess.RepertoireDetudiant.Lire(request.EtudiantId);

            if (etudiant is null)
                throw new NotFoundException(nameof(etudiant), request.EtudiantId);

            if (request.EtudiantAModifierDto != null)
            {
                var reponse = new ReponseDeRequette();
                var validateur = new ValidateurDeLaModificationDetudiantDto();
                var resultatValidation = await validateur.ValidateAsync(request.EtudiantAModifierDto, cancellationToken);

                if (!await _pointDaccess.RepertoireDetudiant.Exists(request.EtudiantId))
                    throw new BadRequestException($"L'un des Ids Etudiant::[{request.EtudiantId}] que vous avez entrez est null");

                if (resultatValidation.IsValid == false)
                    throw new ValidationException(resultatValidation);

                _mapper.Map(request.EtudiantAModifierDto, etudiant);

                await _pointDaccess.RepertoireDetudiant.Modifier(etudiant);
                await _pointDaccess.Enregistrer();

                reponse.Success = true;
                reponse.Message = "Modification Reussit";
                reponse.Id = etudiant.Id;

                return reponse;
            }
            throw new BadRequestException("etudiant a Modifier est null");
        }
    }
}
