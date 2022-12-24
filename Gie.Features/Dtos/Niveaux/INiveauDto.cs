﻿using System.ComponentModel.DataAnnotations;

namespace Gie.Features.Dtos.Config.Niveaux
{
    public interface INiveauDto
    {
        public int ValeurCycle { get; set; }
        public string Designation { get; set; }
        public string DesignationFiliere { get; set; }
        public string DesignationCycle { get; set; }
    }
}
