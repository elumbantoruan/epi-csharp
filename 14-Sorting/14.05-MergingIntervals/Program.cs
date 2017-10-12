using System;
using System.Collections.Generic;

namespace _14._05_MergingIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Interval> existingIntervals = new List<Interval>
            {
                new Interval(-4,-1),
                new Interval(0, 2),
                new Interval(3, 6),
                new Interval(7, 9),
                new Interval(11, 12),
                new Interval(14, 17)
            };
            Interval newInterval = new Interval(1, 8);
            List<Interval> result = MergingInterval(existingIntervals, newInterval);
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Start} - {item.End}");
            }
        }

        /*
         * Existing intervals: {-4,-1}{0,2}{3,6}{7,9}{11,12}{14,17}
         * New interval: {1,8}
         * Result: {-4,-1}{0,9}{11,12}{14,17}
         */
        static List<Interval> MergingInterval(List<Interval> existingIntervals, Interval newInterval)
        {
            List<Interval> combinedIntervals = new List<Interval>();
            for (int i = 0; i < existingIntervals.Count; i++) {
                if (existingIntervals[i].Start < newInterval.Start) {
                    combinedIntervals.Add(existingIntervals[i]);
                }
                else {
                    if (!combinedIntervals.Contains(newInterval)) {
                        combinedIntervals.Add(newInterval);
                    }
                    else {
                        combinedIntervals.Add(existingIntervals[i]);
                    }
                }
            }
            List<Interval> mergedIntervals = new List<Interval>();
            mergedIntervals.Add(combinedIntervals[0]);
            for (int i = 1 ; i < combinedIntervals.Count; i++) {
                Interval lastMerged = mergedIntervals[mergedIntervals.Count - 1];
                if (lastMerged.End >= combinedIntervals[i].Start) {
                    lastMerged.Start = Math.Min(lastMerged.Start, combinedIntervals[i].Start);
                    lastMerged.End = Math.Max(lastMerged.End, combinedIntervals[i].End);
                }
                else {
                    mergedIntervals.Add(combinedIntervals[i]);
                }
            }
            return mergedIntervals;
        }
    }

    public class Interval {
        public int Start { get; set; }
        public int End { get; set; }
        public Interval(int start, int end) {
            Start = start;
            End = end;
        }
    }
}
