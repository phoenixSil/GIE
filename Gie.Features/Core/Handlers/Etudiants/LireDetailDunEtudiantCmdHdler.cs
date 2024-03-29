﻿using AutoMapper;
using MediatR;
using Register.API.DTOs.Etudiants;
using Gie.Features.Commandes.Etudiants;
using Gie.Features.Contrats.Repertoires;
using Gie.Features.Dtos.Etudiants;

namespace Gie.Features.CommandHandlers.Etudiants
{
    public class LireDetailDUnEtudiantCmdHdler : IRequestHandler<LireDetailDUnEtudiantCmd, EtudiantDetailDto>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireDetailDUnEtudiantCmdHdler(IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<EtudiantDetailDto> Handle(LireDetailDUnEtudiantCmd request, CancellationToken cancellationToken)
        {
            var etudiant = await _pointDaccess.RepertoireDetudiant.LireDetailDunEtudiant(request.Id);
            var EtudiantDetail = _mapper.Map<EtudiantDetailDto>(etudiant);

            return EtudiantDetail;
        }
    }
}
