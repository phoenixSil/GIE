using Gie.Api.Dtos.Adresses;
using Gie.Api.DTOs.Adresses;
using MsCommun.Reponses;
using Gie.Api.Services.Contrats;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<ReponseDeRequette>> AjouterUneAdresseAUnePersonne(AdresseACreerDto adresseACreerDto)
        {
            var result = await _service.AjouterUneAdresseAUnEtudiant(adresseACreerDto);
            return Ok(result);
        }

        [HttpPut("/detail/{adresseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> ModifierAdresseDunePersonne(Guid adresseId, AdresseAModifierDto adresseAModifierDto)
        {
            var resultat = await _service.ModifierAdresseDunEtudiant(adresseId, adresseAModifierDto);
            return Ok(resultat);
        }

        [HttpGet("/{adresseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AdresseDetailDto>> LireAdresseDunePersonne(Guid adresseId)
        {
            var resultat = await _service.LireAdresseUniqueDunEtudiant(adresseId);
            return Ok(resultat);
        }

        [HttpGet("/personne/{personneId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<AdresseDto>>> LireToutesLesAdresseDunePersonne(Guid personneId)
        {
            var resultat = await _service.LireToutesLesAdresseDunEtudiant(personneId);
            if (resultat.Count == 0 || resultat == null)
                return NoContent();
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

        [HttpPost("/personne/{personneId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<ReponseDeRequette>>> AjoutterListDadresseAUnePersonne(List<AdresseACreerDto> listAdressedto)
        {
            var resultat = await _service.AjouterUneListeDAdresseAUnEtudiant(listAdressedto);
            return Ok(resultat);
        }
    }
}
