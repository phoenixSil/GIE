using FluentValidation;
using Gie.Api.DTOs.Adresses;
using Gie.Api.Repertoires.Contrats;

namespace Register.API.DTOs.Adresses.Validations
{
    public class ValidateurDeLaModificationDadresseDto: AbstractValidator<AdresseAModifierDto>
    {
        private readonly IPointDaccess _pointDaccess;
        public ValidateurDeLaModificationDadresseDto(IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;

            RuleFor(p => p.Id).NotNull()
                .NotEmpty()
                .WithMessage("Id doit pas etre null");

            Include(new ValidateurDeDtoDadresse(_pointDaccess));
        }
    }
}
 