using EmploMetrica.Application.Interfaces;
using EmploMetrica.Domain.Time;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploMetrica.Application.UseCases.Time
{
    public class ConsumeTimeEventUseCase(ILogger<ConsumeTimeEventUseCase> _logger) : IConsumer<CreateWorkDayDto>
    {
        public Task Consume(ConsumeContext<CreateWorkDayDto> context)
        {
            _logger.LogInformation("New WorkDay created: {context.Message}");
            return Task.CompletedTask;
        }
    }
}
