using System;
using System.Collections.Generic;
using System.Linq;

namespace HashCode
{
    public partial class Solution
    {
        public static Solution JamesSolve(Challenge challenge)
        {
            var solution = new Solution();

            var intersections = FindAllIntersections(challenge);

            foreach (var intersection in intersections)
            {
                SetRandomOnIntersection(intersection, 5, challenge.Duration);
            }

            solution.Intersections = intersections;
            return solution;
        }

        private static List<Intersection> FindAllIntersections(Challenge challenge)
        {
            var results = new Dictionary<int, Intersection>();
            foreach (var street in challenge.Streets)
            {
                if (results.ContainsKey(street.EndIntersection))
                {
                    var intersection = results[street.EndIntersection];
                    intersection.Streets.Add(street);
                }
                else
                {
                    var intersection = new Intersection {Id = street.EndIntersection};
                    intersection.Streets.Add(street);
                    results.Add(intersection.Id, intersection);
                }
            }

            return results.Values.ToList();
        }

        private static void SetRandomOnIntersection(Intersection intersection, int time, int totalTime)
        {
            var runningTotal = 0;
            var ran = new Random();
            while (runningTotal < totalTime)
            {
                var remainingTime = GetRemainingTime(runningTotal, time, totalTime);
                var nextStreetIndex = ran.Next(intersection.Streets.Count);
                intersection.Schedules.Add(new Schedule
                {
                    StreetName = intersection.Streets[nextStreetIndex].StreetName,
                    GreenDuration = remainingTime
                });
                runningTotal += remainingTime;
            }
        }

        private static int GetRemainingTime(int runningTotal, int time, int totalTime)
        {
            if (runningTotal + time <= totalTime)
                return time;

            return totalTime - runningTotal;

        }
        
        
    }
}