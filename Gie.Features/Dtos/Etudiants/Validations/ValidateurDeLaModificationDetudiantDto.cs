using FluentValidation;
using Gie.Features.Dtos.Etudiants;
using Gie.Features.Contrats.Repertoires;

namespace Register.API.DTOs.Etudiants.Validations
{
    public class ValidateurDeLaModificationDetudiantDto: AbstractValidator<EtudiantAModifierDto>
    {
        public ValidateurDeLaModificationDetudiantDto()
        {

            RuleFor(p => p.Id).NotNull()
                .NotEmpty()
                .WithMessage("Id doit pas etre null");

            RuleFor(x => x.Niveau_DEntrer)
                .NotEmpty();

            Include(new ValidateurDeDtoDetudiant());
        }
    }
}
 