using System.IO;
using System.Linq;

namespace HashCode
{
    public static class Input
    {
        public static Challenge Parse(string filePath)
        {
            var lines = File.ReadLines(filePath).ToList();

            var firstLine = lines[0].Split(' ');
            new Challenge
            {
                Duration = int.Parse(firstLine[0]),
                NumberOfIntersections = int.Parse(firstLine[1]),
                NumberOfStreets = int.Parse(firstLine[2]),
                NumberOfCars = int.Parse(firstLine[3]),
                BonusPoints = int.Parse(firstLine[4]),
            };

            return new Challenge();
        }
    }
}