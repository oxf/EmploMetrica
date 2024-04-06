using EmploMetrica.Application.UseCases.Time;
using EmploMetrica.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace EmploMetrica.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalenderController(ProduceTimeEventUseCase _produceTimeEventUseCase)
    {
        [HttpGet]
        public Task CreateWorkDay(CancellationToken cancellationToken = default)
        {
            return _produceTimeEventUseCase.CreateWorkDay(cancellationToken);
        }
    }
}
