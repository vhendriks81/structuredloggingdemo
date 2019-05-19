namespace DemoApi.Tasks
{
    using System;
    using System.Threading.Tasks;
    using DemoApi.Services;
    using Microsoft.Extensions.Logging;

    public class DemoTask : ITask
    {
        private readonly IDemoService _demoService;
        private readonly ILogger<DemoTask> _logger;

        public DemoTask(ILogger<DemoTask> logger, IDemoService demoService)
        {
            _logger = logger;
            _demoService = demoService;
        }

        public async Task Run()
        {
            _logger.LogDebug("Delaying for 1 second");
            await Task.Delay(TimeSpan.FromSeconds(1));

            // Select a random rockstar
            var randomRockstar = _demoService.GetRandomRockstar();
            _logger.LogDebug("Selected {@rockstar} as the one to message", randomRockstar);

            // Message the selected rockstar.
            _logger.LogInformation("Messaging {@rockstar}", randomRockstar);
            _demoService.MessageRockstar(randomRockstar, $"Hello {randomRockstar.Name}!");
        }
    }
}
