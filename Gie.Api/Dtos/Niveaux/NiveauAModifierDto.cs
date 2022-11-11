using Gie.Api.Dtos;
using Gie.Api.Dtos.Etudiants;
using System.ComponentModel.DataAnnotations;

namespace Gie.Api.Dtos.Config.Niveaux
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
