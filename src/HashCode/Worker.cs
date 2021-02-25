using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HashCode
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
            _logger.LogInformation("HashCode 2021!");
            
            for (var i = 1; i <= 6; i++)
            {
                var challenge = Input.Parse(Path.Combine("input", $"problem{i}.txt"));
                var solution = Solution.Solve(challenge);
                Output.Write(solution, $"output/problem{i}.txt");
                
                Console.WriteLine($"Input {i}: {solution.GetScore()} points");
            }
        }
    }
}
