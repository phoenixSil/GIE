using FluentValidation;
using Gie.Features.Contrats.Repertoires;
using Gie.Features.Dtos.Adresses;

namespace Register.API.DTOs.Adresses.Validations
{
    public class ValidateurDeLaCreationDadresseDto:  AbstractValidator<AdresseACreerDto>
    {
        private readonly IPointDaccess _pointDaccess;
        public ValidateurDeLaCreationDadresseDto(IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            Include(new ValidateurDeDtoDadresse(_pointDaccess));
        }
    }
}
