﻿using Gie.Features.Core.BaseFactoryClass.Enums;
using MediatR;
using MsCommun.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gie.Features.Core.BaseFactoryClass
{
    public abstract class BaseCommand : IRequest<ReponseDeRequette>
    {
        public TypeDeRequette Operation { get; set; }
    }
}
