using AutoMapper;
using Gie.Features.Dtos.Config.Niveaux;
using Gie.Api.Messages.HandlersMessages;
using Gie.Features.Contrats.Services;
using MassTransit;
using MsCommun.Messages.Niveaux;
using MsCommun.Messages.Utils;
using Microsoft.Extensions.Logging;

namespace Gie.Api.Messages.NiveauxMessageHandler
{
    public class ModifierNiveauMessageHandler : IConsumer<NiveauAModifierMessage>
    {
        private readonly IServiceDeNiveau _service;
        private readonly IMapper _mapper;
        private readonly ILogger<AjouterNiveauMessageHandler> _logger;

        public ModifierNiveauMessageHandler(ILogger<AjouterNiveauMessageHandler> logger, IServiceDeNiveau service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<NiveauAModifierMessage> context)
        {
            var niveauMessage = context.Message;
            
            if (niveauMessage.Service == DesignationService.SERVICE_GESC)
            {
                if (niveauMessage.Type == TypeMessage.MODIFICATION)
                {
                    NiveauDetailDto niveau = await _service.LireNiveauParNumeroExterne(niveauMessage.NumeroExterne);
                    var dto = _mapper.Map<NiveauAModifierDto>(niveauMessage);
                    await _service.ModifierUnNiveau(niveau.Id, dto).ConfigureAwait(false);
                }
            }
        }
    }
}
