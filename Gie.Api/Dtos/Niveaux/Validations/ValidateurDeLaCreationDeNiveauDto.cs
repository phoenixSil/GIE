using FluentValidation;
using Gie.Api.Dtos.Config.Niveaux;
using Gie.Api.Repertoires;
using Gie.Api.Repertoires.Contrats;

namespace Gie.Api.Dtos.Niveaus.Validations
{
    public class ValidateurDeLaCreationDeNiveauDto : AbstractValidator<NiveauGieACreerDto>
    {

        public ValidateurDeLaCreationDeNiveauDto()
        {
            Include(new ValidateurDeDtoDeNiveau());
        }
    }
}
