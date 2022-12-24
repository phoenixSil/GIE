using AutoMapper;
using Gie.Features.Dtos.Adresses;
using Gie.Features.Dtos.Config.Niveaux;
using Gie.Features.Dtos.Etudiants;
using Gie.Features.DTOs.Adresses;
using Gie.Domain.Modeles;
using MsCommun.Messages.Niveaux;

namespace Gie.Api.MappingProfile
{
    public class MappingProf: Profile
    {
        public MappingProf()
        {

            // Adresses
            CreateMap<Adresse, AdresseDto>().ReverseMap();
            CreateMap<Adresse, AdresseDetailDto>().ReverseMap();
            CreateMap<Adresse, AdresseACreerDto>().ReverseMap();
            CreateMap<Adresse, AdresseAModifierDto>().ReverseMap();

            // Etudiant
            CreateMap<Etudiant, EtudiantDto>().ReverseMap();
            CreateMap<Etudiant, EtudiantACreerDto>().ReverseMap();
            CreateMap<Etudiant, EtudiantDetailDto>().ReverseMap();
            CreateMap<Etudiant, EtudiantAModifierDto>().ReverseMap();

            // Niveau
            CreateMap<Niveau, NiveauDto>().ReverseMap();
            CreateMap<Niveau, NiveauACreerDto>().ReverseMap();
            CreateMap<Niveau, NiveauDetailDto>().ReverseMap();
            CreateMap<Niveau, NiveauAModifierDto>().ReverseMap();
            CreateMap<NiveauACreerDto, NiveauACreerMessage>().ReverseMap();
        }
    }
}
