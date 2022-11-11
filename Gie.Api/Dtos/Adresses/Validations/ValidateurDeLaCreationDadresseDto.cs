using FluentValidation;
using Gie.Api.Dtos.Adresses;
using Gie.Api.Repertoires.Contrats;

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
