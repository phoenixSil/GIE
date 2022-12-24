using Gie.Features.Dtos;
using Gie.Features.Dtos.Etudiants;
using System.ComponentModel.DataAnnotations;

namespace Gie.Features.Dtos.Config.Niveaux
{
    public class NiveauAModifierDto : BaseDomainDto, INiveauDto
    {
        [Required]
        public int ValeurCycle { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public Guid NumeroExterne { get; set; }
        public string DesignationFiliere { get; set; }
        public string DesignationCycle { get; set; }
    }
}
