using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploMetrica.Application.Interfaces
{
    public interface IMessageProducer
    {
        public Task SendAsync<T>(T message, CancellationToken cancellationToken = default) where T : class;
    }
}
