using Gie.Api.Dtos.Config.Niveaux;
using Gie.Api.Services.Contrats;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MsCommun.Reponses;

namespace Gie.Api.Controllers
{
    [Route("api/Etudiant/[controller]")]
    [ApiController]
    public class NiveauController : ControllerBase
    {
        private readonly IServiceDeNiveau _service;

        public NiveauController(IServiceDeNiveau service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ReponseDeRequette>> AjouterUnNiveau(NiveauGieACreerDto dto)
        {
            var result = await _service.AjouterUnNiveau(dto);
            return Ok(result);
        }
    }
}
