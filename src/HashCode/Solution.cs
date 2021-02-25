using System.Collections.Generic;

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
            return new Solution();
        }
    }
}