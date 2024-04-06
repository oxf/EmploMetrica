using EmploMetrica.Application.Interfaces;
using EmploMetrica.Domain.Shared;
using EmploMetrica.Domain.Time;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploMetrica.Application.UseCases.Time
{
    public class ProduceTimeEventUseCase(IMessageProducer _messageProducer,
        ILogger<ProduceTimeEventUseCase> _logger)
    {
        public Task CreateWorkDay(CancellationToken cancellationToken)
        {
            CreateWorkDayDto newWorkDay = new CreateWorkDayDto(DateTime.UtcNow);
            _logger.LogInformation($"New WorkDay sent: {newWorkDay.ToString()}");
            return _messageProducer.SendAsync<CreateWorkDayDto>(newWorkDay, cancellationToken);
        }
    }
}
