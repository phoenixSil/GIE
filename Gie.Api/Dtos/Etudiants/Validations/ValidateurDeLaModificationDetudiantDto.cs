using FluentValidation;
using Gie.Api.Dtos.Etudiants;
using Gie.Api.Repertoires.Contrats;

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
 