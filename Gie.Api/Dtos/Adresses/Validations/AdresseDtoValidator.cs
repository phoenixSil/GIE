using FluentValidation;
using Gie.Api.Dtos.Adresses;
using Gie.Api.Repertoires.Contrats;

namespace Register.API.DTOs.Adresses.Validations
{
    public class ValidateurDeDtoDadresse: AbstractValidator<IAdresseDto>
    {
        private readonly IPointDaccess _pointDaccess;

        public ValidateurDeDtoDadresse(IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;

            RuleFor(p => p.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Votre Email nes pas valide ");

            RuleFor(p => p.Pays)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Le nom du pays est au trop court")
                .MaximumLength(100).WithMessage("le nom du pays ne doit pas exceder les 100 caracteres");

            RuleFor(p => p.Ville)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Le nom de la ville est au trop court")
                .MaximumLength(100).WithMessage("le nom de la ville ne doit pas exceder les 100 caracteres");

            RuleFor(p => p.EtudiantId)
               .NotEmpty()
               .MustAsync(async (id, token) => {
                   var personneExists = await _pointDaccess.RepertoireDetudiant.Exists(id);
                   return personneExists;
               })
               .WithMessage($" l'etudiant nexiste pas dans la base de donnees  ");
        }
    }
}
