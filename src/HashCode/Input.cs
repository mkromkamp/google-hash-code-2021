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
            var challenge = new Challenge
            {
                Duration = int.Parse(firstLine[0]),
                NumberOfIntersections = int.Parse(firstLine[1]),
                NumberOfStreets = int.Parse(firstLine[2]),
                NumberOfCars = int.Parse(firstLine[3]),
                BonusPoints = int.Parse(firstLine[4]),
            };

            for (int i = 0; i < challenge.NumberOfStreets; i++)
            {
                var currentStreet = lines[1 + i].Split(' ').ToList();
                new Street
                {
                    StartIntersection = int.Parse(currentStreet[0]),
                    EndIntersection = int.Parse(currentStreet[1]),
                    StreetName = currentStreet[2],
                    StreetLength = int.Parse(currentStreet[3]),
                    
                }
            }
            

            return new Challenge();
        }
    }
}