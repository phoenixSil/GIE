namespace Gie.Api.Modeles
{
    public class Adresse: BaseEntite
    {
        public int Telephone { get; set; }
        public string Pays { get; set; }
        public string Region { get; set; }
        public string Ville { get; set; }
        public string Email { get; set; }
        public Guid EtudiantId { get; set; }
        public virtual Etudiant Etudiant { get; set; }
    }
}
