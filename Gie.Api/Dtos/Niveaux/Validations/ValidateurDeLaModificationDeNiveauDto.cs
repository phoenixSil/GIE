using FluentValidation;
using Gie.Api.Dtos.Config.Niveaux;
using Gie.Api.Repertoires.Contrats;

namespace Gie.Api.Dtos.Niveaus.Validations
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
