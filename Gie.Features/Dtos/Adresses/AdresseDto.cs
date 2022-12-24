using Gie.Features.Dtos.Adresses;

namespace Gie.Features.Dtos.Adresses
{
    public class AdresseDto: BaseDomainDto, IAdresseDto
    {
        public int Telephone { get; set; }
        public string Pays { get; set; }
        public string Region { get; set; }
        public string Ville { get; set; }
        public string Email { get; set; }
        public Guid EtudiantId { get; set; }
    }
}
