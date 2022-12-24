using FluentValidation;
using Gie.Features.Dtos.Config.Niveaux;
using Gie.Features.Contrats.Repertoires;

namespace Gie.Features.Dtos.Niveaus.Validations
{
    public class ValidateurDeLaModificationDeNiveauDto : AbstractValidator<NiveauAModifierDto>
    {
        public ValidateurDeLaModificationDeNiveauDto()
        {
            RuleFor(p => p.Id).NotNull()
                .NotEmpty()
                .WithMessage("Id doit pas etre null");

            Include(new ValidateurDeDtoDeNiveau());
        }
    }
}
