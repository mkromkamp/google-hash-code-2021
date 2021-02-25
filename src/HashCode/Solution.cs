using System.Collections.Generic;

namespace HashCode
{
    public class Solution
    {
        public List<Intersection> Intersections { get; set; } = new List<Intersection>();

        public long GetScore()
        {
            return 0;
        }

        public static Solution Solve(Challenge challenge)
        {
            challenge.CalculateBestPathTime();
            
            
            var solution = new Solution();
            solution.Intersections.Add(new Intersection
            {
                Schedules = new List<Schedule> {new Schedule {StreetName = "dave street", GreenDuration = 4}}
            });
            return solution;
        }
    }
}