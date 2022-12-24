
using Gie.Features.Dtos.Etudiants;

namespace Gie.Features.Dtos.Adresses
{
    public class AdresseDetailDto : BaseDomainDto
    {
        public int Telephone { get; set; }
        public string Pays { get; set; }
        public string Region { get; set; }
        public string Ville { get; set; }
        public string Email { get; set; }
        public EtudiantDto Personne { get; set; }
    }
}
