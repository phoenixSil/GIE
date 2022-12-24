using Gie.Domain.Modeles.Utils;
using Gie.Features.Dtos.Adresses;
using System.ComponentModel.DataAnnotations.Schema;
using Gie.Domain.Modeles;
using Gie.Features.Dtos.Config.Niveaux;

namespace Gie.Features.Dtos.Etudiants
{
    public class EtudiantDetailDto : BaseDomainDto, IEtudiantDto
    {
        public NIVEAU_ETUDE Niveau_DEntrer { get; set; }
        public DateTime DateInscription { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public virtual List<AdresseDto> Adresses { get; set; }
        public Guid NiveauId { get; set; }
        public virtual NiveauDto Niveau { get; set; }
    }
}
