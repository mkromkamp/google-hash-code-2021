using System.Collections.Generic;

namespace HashCode
{
    public class Challenge
    {
        public int Duration { get; set; }
        public int NumberOfIntersections { get; set; }
        public int NumberOfStreets { get; set; }
        public int NumberOfCars { get; set; }
        public int BonusPoints { get; set; }
        
        public List<Street> Streets { get; set; }
    }

    public class Street
    {
        public int StartIntersection { get; set; }
        public int EndIntersection { get; set; }
        public string StreetName { get; set; }
        public int StreetLength { get; set; }
    }
}