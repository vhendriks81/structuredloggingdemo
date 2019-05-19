namespace DemoApi.Tasks
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Quick and dirty implementation of a simple task runner just for demo purposes.
    /// </summary>
    public class TaskRunner : ITaskRunner
    {
        private readonly ILogger<TaskRunner> _logger;
        private readonly IServiceProvider _serviceProvider;

        public TaskRunner(ILogger<TaskRunner> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task Run()
        {
            try
            {
                _logger.LogDebug("Initialized task runner");
                while (true)
                {
                    await RunTask<DemoTask>();

                    await Task.Delay(TimeSpan.FromSeconds(10));
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An exception occurred in the task runner.");
                throw;
            }
        }

        private async Task RunTask<TTask>()
            where TTask : ITask
        {
            var taskRunId = Guid.NewGuid();

            using (_logger.BeginScope("Running task {task}. Task Run Id: {taskRunId}", typeof(TTask), taskRunId))
            {
                _logger.LogDebug("Running task {task}", typeof(TTask));
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var demoTask = scope.ServiceProvider.GetRequiredService<TTask>();

                        await demoTask.Run();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred trying to run a task");
                }
            }
        }
    }
}
