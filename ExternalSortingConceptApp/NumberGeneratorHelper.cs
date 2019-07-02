using System;
using System.Collections.Generic;
using System.Linq;

namespace ExternalSortingConceptApp
{
    public static class NumberGeneratorHelper
    {
        static Random random = new Random();

        public static int[] GenerateRandom(int count) => GenerateRandom(count, 0, count);

        private static int[] GenerateRandom(int count, int min, int max)
        {
            ValidateRange(count, min, max);
            var candidates = new HashSet<int>();
            for (int top = max - count; top < max; top++)
                if (!candidates.Add(random.Next(min, top + 1)))
                    candidates.Add(top);
            var result = candidates.ToList();
            for (var i = result.Count - 1; i > 0; i--)
            {
                var j = random.Next(i + 1);
                var temp = result[j];
                result[j] = result[i];
                result[i] = temp;
            }
            return result.ToArray();
        }
        
        private static void ValidateRange(int count, int min, int max)
        {
            if (max <= min || count < 0 || (count > max - min && max - min > 0))
                throw new ArgumentOutOfRangeException("Range or count is illegal");
        }
    }
}