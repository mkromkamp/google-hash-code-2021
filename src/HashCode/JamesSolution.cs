using System;
using System.Collections.Generic;
using System.Linq;

namespace HashCode
{
    public partial class Solution
    {
        /// <summary>
        /// Dont like this way anymore
        /// </summary>
        /// <param name="challenge"></param>
        /// <returns></returns>
        public static Solution JamesSolve(Challenge challenge)
        {
            Console.WriteLine("starting solution");
            var solution = new Solution();

            var intersectionsLeft = FindAllIntersections(challenge);
            Console.WriteLine("found intersections");
            foreach (var intersection in intersectionsLeft)
            {
                SetRandomOnIntersection(intersection, challenge.Duration);
            }

            solution.Intersections.AddRange(intersectionsLeft);
            Console.WriteLine("easy intersections done");
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

        private static void SetRandomOnIntersection(Intersection intersection, int totalTime)
        {
            if (!intersection.Streets.Any())
            {
                return;
            }

            if (intersection.Streets.Count == 1)
            {
                intersection.Schedules.Add(new Schedule
                {
                    StreetName = intersection.Streets.First().StreetName,
                    GreenDuration = totalTime
                });
                
                return;
            }

            var runningTotal = 0;
            var ran = new Random();
            var index = ran.Next(intersection.Streets.Count);
            var time = (int)Math.Ceiling((decimal) totalTime / intersection.Streets.Count);
            while (runningTotal < totalTime)
            {
                var remainingTime = GetRemainingTime(runningTotal, time, totalTime);
                
                intersection.Schedules.Add(new Schedule
                {
                    StreetName = intersection.Streets[index].StreetName,
                    GreenDuration = remainingTime
                });

                index = GetNextIndex(index, intersection.Streets);
                runningTotal += remainingTime;
            }
        }

        private static int GetNextIndex(int index, List<Street> intersectionStreets)
        {
            var nextIndex = index + 1;
            if (nextIndex == intersectionStreets.Count)
            {
                return 0;
            }

            return nextIndex;
        }

        private static int GetRemainingTime(int runningTotal, int time, int totalTime)
        {
            if (runningTotal + time <= totalTime)
                return time;

            return totalTime - runningTotal;

        }
        
        
    }
}