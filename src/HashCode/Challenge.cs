using System.Collections.Generic;
using System.Linq;

namespace HashCode
{
    public class Challenge
    {
        public int Duration { get; set; }
        public int NumberOfIntersections { get; set; }
        public int NumberOfStreets { get; set; }
        public int NumberOfCars { get; set; }
        public int BonusPoints { get; set; }
        
        public List<Street> Streets { get; } = new List<Street>();
        
        public List<CarPath> Paths { get;  } = new List<CarPath>();

        public Challenge CalculateBestPathTime()
        {
            foreach (var carPath in Paths)
            {
                carPath.CalculateBestTotalTime();
            }
            
            return this;
        }
    }

    public class CarPath
    {
        public int NumberOfStreets { get; set; }
        public List<Street> Streets { get; set; } = new List<Street>();
        
        public int BestTotalTime { get; private set; }

        public void CalculateBestTotalTime()
        {
            BestTotalTime = Streets.Sum(x => x.StreetLength);
        }
    }

    public class Street
    {
        public int StartIntersection { get; set; }
        public int EndIntersection { get; set; }
        public string StreetName { get; set; }
        public int StreetLength { get; set; }
    }
}