using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ExternalSortingConceptApp
{
    class Program
    {
        const string PROBE = "probe.csv";
        const string SOLVE = "solve.csv";
        const string DATE_TIME_FORMAT = "yyyy-MM-dd HH:mm:ss.fff";

        static void Main(string[] args)
        {
            var rawData = NumberGeneratorHelper.GenerateRandom(1000000);
            File.WriteAllLines(PROBE, rawData.Select(e => e.ToString()));
            var stopwatch = new Stopwatch();
            Console.WriteLine(
                $@"Start: {DateTime.UtcNow.ToString(DATE_TIME_FORMAT, CultureInfo.InvariantCulture)}"
            );
            stopwatch.Start();
            ComputationEngineHelper.Run(PROBE, SOLVE);
            stopwatch.Stop();
            Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");
            Console.WriteLine(
                $@"Stop: {DateTime.UtcNow.ToString(DATE_TIME_FORMAT, CultureInfo.InvariantCulture)}"
            );
        }
    }
}
