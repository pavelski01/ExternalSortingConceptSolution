using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExternalSortingConceptApp
{
    public static class ComputationEngineHelper
    {
        public static void Run(string probe, string slove)
        {
            var bucket = new List<int>();
            //First phase
            for (var j = 0; j < 10; j++)
            {
                //Second phase
                for (var i = 0; i < 10; i++)
                {
                    var chunk = File.ReadLines(probe).Skip(100000 * i).Take(100000).ToList();
                    chunk.ForEach(
                        e =>
                        {
                            var digits = int.Parse(e);
                            if (digits >= 100000 * j && digits < 100000 * (j + 1))
                                bucket.Add(digits);
                        }
                    );
                }
                var package = bucket.ToArray();
                //Third phase
                SortingAlgorithmHelper.QuicksortPara(package, 0, 99999);
                File.AppendAllLines(slove, package.Select(e => e.ToString()));
                bucket.Clear();
            }
        }
    }
}
