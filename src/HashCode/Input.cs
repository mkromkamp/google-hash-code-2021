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

                var street = new Street
                {
                    StartIntersection = int.Parse(currentStreet[0]),
                    EndIntersection = int.Parse(currentStreet[1]),
                    StreetName = currentStreet[2],
                    StreetLength = int.Parse(currentStreet[3]),
                };

                challenge.Streets.Add(street);
            }

            for (int i = 0; i < challenge.NumberOfCars; i++)
            {
                var currentPath = lines[1 + challenge.NumberOfStreets + i].Split(' ').ToList();
                var carPath = new CarPath
                {
                    NumberOfStreets = int.Parse(currentPath[0]),
                    Streets = currentPath.Skip(1).Select(x => challenge.Streets.First(y => y.StreetName.Equals(x))).ToList()
                };

                challenge.Paths.Add(carPath);
            }

            return challenge;
        }
    }
}