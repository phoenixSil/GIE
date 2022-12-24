namespace Gie.Features.Dtos.Adresses
{
    public interface IAdresseDto
    {
        public int Telephone { get; set; }
        public string Pays { get; set; }
        public string Region { get; set; }
        public string Ville { get; set; }
        public string Email { get; set; }
        public Guid EtudiantId { get; set; }
    }
}
