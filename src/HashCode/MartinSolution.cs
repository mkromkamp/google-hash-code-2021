using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace HashCode
{
    public partial class Solution
    {
        public static Solution MartinSolve(Challenge challenge)
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
            var seen = new HashSet<int>();

            while (s <= challenge.Duration)
            {
                var remainingCars = cars.Where(c => c.Streets.Count > s).ToList();
                if (!remainingCars.Any())
                    break;

                // Get intersection with most waiting cars
                var intersection = remainingCars.Select(c => c.Streets[s]).GroupBy(s => s.StreetName)
                    .OrderByDescending(g => g.Count())
                    .ToList().First().First();

                var streets = remainingCars.Where(c => c.Streets[s].EndIntersection == intersection.EndIntersection)
                    .Select(c => c.Streets[s]).ToList();

                if (!seen.Contains(intersection.EndIntersection))
                {
                    solution.Intersections.Add(
                        new Intersection
                        {
                            Id = intersection.EndIntersection,
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
                    
                    seen.Add(intersection.EndIntersection);
                }
                
                s++;
            }

            return solution;
        }
    }
}