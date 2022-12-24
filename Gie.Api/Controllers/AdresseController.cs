using MsCommun.Reponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gie.Features.Contrats.Services;
using Gie.Features.Dtos.Adresses;
using Gie.Features.DTOs.Adresses;

namespace Gie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdresseController : ControllerBase
    {
        private readonly IServiceDadresse _service;

        public AdresseController(IServiceDadresse service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ReponseDeRequette>> AjouterAdresse(AdresseACreerDto adresseACreerDto)
        {
            var result = await _service.AjouterUneAdresseAUnEtudiant(adresseACreerDto);
            return Ok(result);
        }

        [HttpPut("/detail/{adresseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> ModifierUneAdresse(Guid adresseId, AdresseAModifierDto adresseAModifierDto)
        {
            var resultat = await _service.ModifierAdresseDunEtudiant(adresseId, adresseAModifierDto);
            return Ok(resultat);
        }

        [HttpGet("/{adresseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AdresseDetailDto>> LireDetailDUneAdresse(Guid adresseId)
        {
            var resultat = await _service.LireAdresseUniqueDunEtudiant(adresseId);
            return Ok(resultat);
        }

        [HttpDelete("/{adresseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> SupprimerUneAdresse(Guid adresseId)
        {
            var resultat = await _service.SupprimerAdresseDunEtudiant(adresseId);
            return Ok(resultat);
        }

    }
}
