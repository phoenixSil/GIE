﻿using Gie.Domain.Modeles;
using Gie.Api.Dtos;
using Gie.Domain.Modeles;

namespace Gie.Api.Dtos.Config.Niveaux
{
    public class NiveauDto : BaseDomainDto
    {
        public int ValeurCycle { get; set; }
        public string Designation { get; set; }
        public string DesignationFiliere { get; set; }
        public string DesignationCycle { get; set; }
    }
}
