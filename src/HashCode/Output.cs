using System.IO;

namespace HashCode
{
    public static class Output
        {
            public static void Write(Solution solution, string fileName)
            {
                using (var outputFile = File.Open(fileName, FileMode.OpenOrCreate))
                {
                    using (var writer = new StreamWriter(outputFile))
                    {
                        writer.WriteLine("TODO");
                        
                        writer.Flush();
                    }
                }
            }
        }
}