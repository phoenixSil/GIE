using FluentValidation;
using Gie.Api.Dtos.Etudiants;
using Gie.Api.Repertoires.Contrats;

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
