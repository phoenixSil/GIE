using FluentValidation;
using Gie.Features.Contrats.Repertoires;
using Gie.Features.Dtos.Etudiants;

namespace Register.API.DTOs.Etudiants.Validations
{
    public class ValidateurDeLaCreationDetudiantDto:  AbstractValidator<EtudiantACreerDto>
    {
        private readonly IPointDaccess _pointDaccess;
        public ValidateurDeLaCreationDetudiantDto(IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            RuleFor(x => x.Niveau_DEntrer)
                .NotEmpty();

            RuleFor(p => p.NiveauId)
              .NotEmpty()
              .MustAsync(async (id, token) =>
              {
                  var niveauExists = await _pointDaccess.RepertoireDeNiveau.Exists(id);
                  return niveauExists;
              })
              .WithMessage($" l'etudiant nexiste pas dans la base de donnees  ");

            Include(new ValidateurDeDtoDetudiant());
            _pointDaccess = pointDaccess;
        }
    }
}
