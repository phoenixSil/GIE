﻿using MediatR;
using Gie.Features.Dtos.Adresses;
using MsCommun.Reponses;

namespace Gie.Features.Commandes.Adresses
{
    public class AjouterUneAdresseCmd : IRequest<ReponseDeRequette>
    {
        public AdresseACreerDto AdresseACreerDto { get; set; }
    }
}
