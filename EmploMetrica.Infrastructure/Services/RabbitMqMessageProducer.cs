using EmploMetrica.Application.Interfaces;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploMetrica.Infrastructure.Services
{
    public sealed class RabbitMqMessageProducer(IPublishEndpoint _publishEndpoint) : IMessageProducer
    {
        public Task SendAsync<T>(T message, CancellationToken cancellationToken = default) where T : class
        {
            return _publishEndpoint.Publish(message, cancellationToken);
        }
    }
}
