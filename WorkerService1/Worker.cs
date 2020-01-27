using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
               // _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                SampleMethod();
                await Task.Delay(1000, stoppingToken);
            }
        }

        // use your code here
        protected void SampleMethod()
        {
            Console.WriteLine($"Test code here -{DateTime.Now}");
        }


        /*
         * .Net core 3.0 /2.0 look for Workerservice project
         * 
         Once you are happy .. publish the service.
         -> Opend the windows powershell in admin mode
         -> Change directory to the Publish directory path ex : C:\Projects\GitHub\WorkerService1\WorkerService1\bin\Release\netcoreapp3.0\publish
         -> Run below  command at power shell, this will install service in the services folder
         
                 sc.exe create TestService binpath= ./publish/WorkerService1.exe

        TestService is the name of the service you want to display in the services
        WorkerService1.exe is the exe file name.

        use full link :

        https://medium.com/@nickfane/introduction-to-worker-services-in-net-core-3-0-4bb3fc631225  // ignore the docker part
         
         */
    }
}
