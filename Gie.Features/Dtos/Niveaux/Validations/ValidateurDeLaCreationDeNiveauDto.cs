using FluentValidation;
using Gie.Features.Dtos.Config.Niveaux;
using Gie.Features.Contrats.Repertoires;

namespace Gie.Features.Dtos.Niveaus.Validations
{
    public class ValidateurDeLaCreationDeNiveauDto : AbstractValidator<NiveauACreerDto>
    {

        public ValidateurDeLaCreationDeNiveauDto()
        {
            Include(new ValidateurDeDtoDeNiveau());
        }
    }
}
