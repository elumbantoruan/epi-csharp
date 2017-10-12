using System;
using System.Collections.Generic;

namespace _13._06_FindTheNearestRepeatedEntries
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> words = new List<string>
            {
                "All", "work", "and", "no", "play", "makes", "for", "no", "work", "no", "fun", "and", "no", "results"
            };
            int result = FindTheNearestRepeatedEntries(words);
            Console.WriteLine(result);
        }

        static int FindTheNearestRepeatedEntries(List<String> words)
        {
            Dictionary<String,int> entriesIndex = new Dictionary<String,int>();
            int nearestRepeatedDistance = Int32.MaxValue;
            for (int i = 0; i < words.Count; i++) {
                if (entriesIndex.ContainsKey(words[i])) {
                    nearestRepeatedDistance = Math.Min(nearestRepeatedDistance, i - entriesIndex[words[i]]);
                }
                entriesIndex[words[i]] = i;
            }
            return nearestRepeatedDistance;
        }
    }
}
