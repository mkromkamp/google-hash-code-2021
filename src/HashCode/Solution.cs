using System.Collections.Generic;
using System.Linq;

namespace HashCode
{
    public partial class Solution
    {
        public List<Intersection> Intersections { get; set; } = new List<Intersection>();

        public long GetScore()
        {
            return 0;
        }

        public static Solution Solve(Challenge challenge)
        {
            var cars = new List<CarPath>();
            
            // Remove cars that take longer than total duration
            foreach (var car in challenge.Paths)
            {
                if (car.Streets.Sum(s => s.StreetLength) <= challenge.Duration)
                    cars.Add(car);
            }
            
            // Sort cars based on number of paths to take
            cars = cars.OrderByDescending(c => c.Streets.Sum(s => s.StreetLength)).ToList();

            var s = 0;
            var solution = new Solution();

            while (s <= challenge.Duration)
            {
                var remainingCars = cars.Where(c => c.Streets.Count() > s).ToList();
                if (!remainingCars.Any())
                    break;
                
                // Get intersection with most waiting cars
                var intersection = remainingCars.Select(c => c.Streets[s]).GroupBy(s => s).OrderByDescending(g => g.Key).ToList().First().First();
                var streets = remainingCars.Where(c => c.Streets[s] == intersection).Select(c => c.Streets[s]);

                solution.Intersections.Add(
                    new Intersection
                    {
                        Id = streets.First().EndIntersection,
                        Schedules = streets
                            .GroupBy(s => s.StreetName)
                            .ToList()
                            .Select(g => 
                                new Schedule
                                {
                                    StreetName = g.Key, GreenDuration = g.Count()
                                }).ToList()
                    }
                );
                    
                s++;
            }
            
            return solution;
        }
    }
}