using Gie.Domain.Modeles.Utils;
using System.ComponentModel.DataAnnotations;

namespace Gie.Domain.Modeles
{
    public class Etudiant: BaseEntite
    {
        public NIVEAU_ETUDE Niveau_DEntrer { get; set; }
        public DateTime DateInscription { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public virtual List<Adresse> Adresses { get; set; }
        public Guid NiveauId { get; set; }
        public virtual Niveau Niveau { get; set; }
    }
}
