using AutoMapper;
using Gie.Features.Dtos.Config.Niveaux;
using Gie.Features.Contrats.Repertoires;
using Gie.Features.Contrats.Services;
using MassTransit;
using MsCommun.Messages.Niveaux;
using MsCommun.Messages.Utils;
using Microsoft.Extensions.Logging;

namespace Gie.Api.Messages.HandlersMessages
{
    public class AjouterNiveauMessageHandler: IConsumer<NiveauACreerMessage>
    {
        private readonly IServiceDeNiveau _service;
        private readonly IMapper _mapper;
        private readonly ILogger<AjouterNiveauMessageHandler> _logger;

        public AjouterNiveauMessageHandler(ILogger<AjouterNiveauMessageHandler> logger, IServiceDeNiveau service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<NiveauACreerMessage> context)
        {
            var niveauMessage = context.Message;
            if (niveauMessage.Service == DesignationService.SERVICE_GESC)
            {
                if (niveauMessage.Type == TypeMessage.CREATION)
                {
                    var dto = _mapper.Map<NiveauACreerDto>(niveauMessage);
                    await _service.AjouterUnNiveau(dto).ConfigureAwait(false);
                }
            }
        }
    }
}
