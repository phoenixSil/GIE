using Gie.Api.Modeles;
using Gie.Api.Dtos;
using Gie.Api.Dtos.Etudiants;

namespace Gie.Api.Dtos.Config.Niveaux
{
    public class NiveauDetailDto : BaseDomainDto, INiveauDto
    {
        public int ValeurCycle { get; set; }
        public string Designation { get; set; }
        public Guid NumeroExterne { get; set; }
        public string DesignationFiliere { get; set; }
        public string DesignationCycle { get; set; }
        public virtual List<EtudiantDto> Etudiants { get; set; }
    }
}
