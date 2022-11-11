using Gie.Api.Modeles;
using Gie.Api.Modeles.Utils;

namespace Gie.Api.Dtos.Etudiants
{
    public interface IEtudiantDto
    {
        public NIVEAU_ETUDE Niveau_DEntrer { get; set; }
        public DateTime DateInscription { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public Guid NiveauId { get; set; }
    }
}
