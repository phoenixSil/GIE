using AutoMapper;
using Gie.Api.Dtos.Adresses;
using Gie.Api.Dtos.Config.Niveaux;
using Gie.Api.Dtos.Etudiants;
using Gie.Api.DTOs.Adresses;
using Gie.Api.Modeles;
using MsCommun.Messages.Niveaux;
using Register.API.DTOs.Adresses;
using Register.API.DTOs.Etudiants;

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
