using Gie.Api.Modeles;
using Gie.Api.Modeles.Utils;
using System.ComponentModel.DataAnnotations;

namespace Gie.Api.Dtos.Etudiants
{
    public class EtudiantAModifierDto : BaseDomainDto, IEtudiantDto
    {
        [Required]
        public NIVEAU_ETUDE Niveau_DEntrer { get; set; }

        [Required]
        public DateTime DateInscription { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }

        [Required]
        public Guid NiveauId { get; set; }
    }
}
