using System.Collections.Generic;
using System.Linq;

namespace HashCode
{
    public class SolutionKavir
    {
        public List<Intersection> Intersections { get; set; } = new List<Intersection>();

        public long GetScore()
        {
            return 0;
        }

        public static Solution Solve(Challenge challenge)
        {
            challenge.CalculateBestPathTime();
            var sortedCarPaths = challenge.Paths
                .OrderBy(p => p.BestTotalTime)
                .ThenBy(p => p.NumberOfStreets)
                .Where(p => p.BestTotalTime <= challenge.Duration)
                .ToList();

            var solution = new Solution();

            var schedulesArray = new Schedule[challenge.Duration];

            foreach (var path in sortedCarPaths)
            {
                bool startOfStreet = false;
                int duration = 0;
                //var currentSchedule = new Schedule();

                foreach (var street in path.Streets)
                {
                    if (duration > challenge.Duration)
                        break;

                    if (startOfStreet)
                    {
                        continue;
                    }
                    else
                    {
                        if (schedulesArray[duration] == null)
                        {
                            schedulesArray[duration] = new Schedule { StreetName = street.StreetName, GreenDuration = street.StreetLength };
                            duration += street.StreetLength;
                        }
                        else
                        {
                            while (duration <= challenge.Duration)
                            {
                                duration++;

                                if (schedulesArray[duration] == null)
                                {
                                    schedulesArray[duration] = new Schedule { StreetName = street.StreetName, GreenDuration = street.StreetLength };
                                    duration += street.StreetLength;
                                }
                            }
                        }

                        startOfStreet = true;
                    }
                }
            }

            solution.Intersections.Add(new Intersection
            {
                Schedules = new List<Schedule>(schedulesArray)
            });
            
            return solution;
        }
    }
}