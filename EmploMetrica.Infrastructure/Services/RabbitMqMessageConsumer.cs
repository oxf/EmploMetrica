using EmploMetrica.Application.Interfaces;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploMetrica.Infrastructure.Services
{
    public class RabbitMqMessageConsumer(IPublishEndpoint _publishEndpoint): IMessageConsumer
    {

    }
}
