
using Gie.Api.Dtos;
using Gie.Api.Dtos.Adresses;

namespace Gie.Api.DTOs.Adresses
{
    public class AdresseAModifierDto: BaseDomainDto, IAdresseDto
    {
        public int Telephone { get; set; }
        public string Pays { get; set; }
        public string Region { get; set; }
        public string Ville { get; set; }
        public string Email { get; set; }
        public Guid EtudiantId { get; set; }
    }
}
