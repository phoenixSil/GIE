using Gie.Features.Dtos.Etudiants;
using MsCommun.Reponses;
using Gie.Features.Contrats.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtudiantController : ControllerBase
    {
        private readonly IServiceDetudiant _service;

        public EtudiantController(IServiceDetudiant service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ReponseDeRequette>> AjouterUnEtudiant(EtudiantACreerDto etudiantAAjouterDto)
        {
            var result = await _service.AjouterUnEtudiant(etudiantAAjouterDto);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<EtudiantDto>>> LireTousLesEtudiants()
        {
            var result = await _service.LireTousLesEtudiants();

            if (result == null || result.Count == 0)
                return NoContent();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EtudiantDto>> LireUnEtudiant(Guid id)
        {
            var result = await _service.LireDetailDunEtudiant(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> ModifierUnEtudiant(Guid etudiantId, EtudiantAModifierDto etudiantAModifierDto)
        {
            var resultat = await _service.ModifierUnEtudiant(etudiantId, etudiantAModifierDto);
            return Ok(resultat);
        }
    }
}
