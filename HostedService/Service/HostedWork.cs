namespace HostedService.Service
{
    public class HostedWork : IHostedService, IDisposable
    {
        private Timer? timer;
        private readonly ILogger<HostedWork> _logger;
        int triggers;
        
        public HostedWork(ILogger<HostedWork> logger)
        {
            _logger = logger;   
        }

        public void Dispose()
        {
            timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer
            (
                call => ExecuteAsync()
                , null
                , TimeSpan.FromSeconds(5)
                , TimeSpan.FromSeconds(1)
            );

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void ExecuteAsync()
        {
            triggers++;
            _logger.LogCritical($"I was triggered by a hosted service {triggers} times");
        }
    }
}