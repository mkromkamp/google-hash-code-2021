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

            for (var i = 4; i <= 4; i++)
            {
                var challenge = Input.Parse(Path.Combine("input", $"problem{i}.txt"));
                
                _logger.LogInformation($"Solving problem {i}");
                var solution = Solution.MartinSolve(challenge);
                _logger.LogInformation($"Solved problem {i}");
                
                _logger.LogInformation($"Writing problem {i}");
                await Output.WriteAsync(solution, $"output/problem{i}.txt");
                _logger.LogInformation($"Wrote problem {i}");

                Console.WriteLine($"Input {i}: {solution.GetScore()} points");
            }
        }
    }
}