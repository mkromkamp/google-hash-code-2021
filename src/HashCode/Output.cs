using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode
{
    public static class Output
    {
        public static async Task WriteAsync(Solution solution, string fileName)
        {
            await using var outputFile = File.Open(fileName, FileMode.OpenOrCreate);
            await using var writer = new StreamWriter(outputFile);

            var sb = new StringBuilder().AppendLine(solution.Intersections.Count.ToString());

            foreach (var intersection in solution.Intersections)
            {
                sb.AppendLine(intersection.Id.ToString());
                sb.AppendLine(intersection.Schedules.Distinct().Count().ToString());
                foreach (var schedule in intersection.Schedules)
                {
                    sb.AppendLine($"{schedule.StreetName} {schedule.GreenDuration}");
                }
            }

            await writer.WriteAsync(sb.ToString());

            await writer.FlushAsync();
        }
    }

    public class Intersection
    {
        public int Id { get; set; }
        public List<Schedule> Schedules { get; set; } = new List<Schedule>();
        public List<Street> Streets { get; set; } = new List<Street>();
    }

    public class Schedule
    {
        public string StreetName { get; set; }
        public int GreenDuration { get; set; }
    }
}