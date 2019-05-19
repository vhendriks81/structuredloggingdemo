using System;
using System.Threading.Tasks;

namespace DemoApi.Tasks
{
    using DemoApi.Services;
    using Microsoft.Extensions.Logging;

    public class DemoTask : ITask
    {
        private readonly ILogger<DemoTask> _logger;
        private readonly IDemoService _demoService;

        public DemoTask(ILogger<DemoTask> logger, IDemoService demoService)
        {
            _logger = logger;
            _demoService = demoService;
        }

        public async Task Run()
        {
            _logger.LogDebug("Delaying for 1 second");
            await Task.Delay(TimeSpan.FromSeconds(1));

            var randomRockstar = _demoService.GetRandomRockstar();
            _logger.LogDebug("Selected {@rockstar} as the one to message", randomRockstar);

            _logger.LogInformation("Messaging {@rockstar}", randomRockstar);
            _demoService.MessageRockstar(randomRockstar, $"Hello {randomRockstar.Name}!");
        }
    }
}
