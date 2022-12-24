using FluentValidation;
using Gie.Features.Dtos.Etudiants;
using Gie.Features.Contrats.Repertoires;

namespace Register.API.DTOs.Etudiants.Validations
{
    public class ValidateurDeDtoDetudiant: AbstractValidator<IEtudiantDto>
    {

        public ValidateurDeDtoDetudiant()
        {
            RuleFor(x => x.Nom)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(100)
                .WithMessage("le Nom que vous avez entrer est incorrect ");

            RuleFor(x => x.Prenom)
               .NotEmpty()
               .MinimumLength(4)
               .MaximumLength(100)
               .WithMessage("le Nom que vous avez entrer est incorrect ");
        }
    }
}
