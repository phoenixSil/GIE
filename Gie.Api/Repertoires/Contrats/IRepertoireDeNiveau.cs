﻿using Gie.Api.Modeles;
using MsCommun.Repertoires.Contrats;

namespace Gie.Api.Repertoires.Contrats
{
    public interface IRepertoireDeNiveau : IRepertoireGenerique<Niveau>
    {
        Task<bool> ExistsByExternalId(Guid numeroExterne);
    }
}
