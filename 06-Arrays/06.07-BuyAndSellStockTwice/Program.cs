using System;
using System.Diagnostics;

namespace _06._07_BuyAndSellStockTwice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] prices = {12, 11, 13, 9, 12, 8, 14, 13, 15};
            int maxProfit = MaxProfit(prices);
            Console.WriteLine(maxProfit);
            Debug.Assert(maxProfit ==  10);
        }

        /*
            Time complexity: O(n)
            Space complexity: O(n) which is used to store array of profits from prev sells
         */
        static int MaxProfit(int[] prices) {
            int maxProfit = 0;
            int minPrice = Int32.MaxValue;
            int[] profits = new int[prices.Length];
            for (int i = 0; i < prices.Length; i++) {
                int potentialProfit = prices[i] - minPrice;
                maxProfit = Math.Max(maxProfit, potentialProfit);
                minPrice = Math.Min(minPrice, prices[i]);
                profits[i] = maxProfit;
            }

            int maxPrice = Int32.MinValue;
            for (int i = prices.Length -1; i > 0; i--) {
                maxPrice = Math.Max(maxPrice, prices[i]);
                maxProfit = Math.Max(maxProfit, maxPrice - prices[i] + profits[i - 1]);
            }

            return maxProfit;
        }
    }
}
