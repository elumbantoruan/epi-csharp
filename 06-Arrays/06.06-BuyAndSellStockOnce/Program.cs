using System;

namespace _06._06_BuyAndSellStockOnce
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] prices = {310, 315, 275, 295, 260, 270, 290, 230, 255, 250};
            int maxProfit = MaxProfitSellOnce(prices);
            Console.WriteLine(maxProfit);
        }

        /*
            Time complexity O(n)
            Space complexity O(1)
         */
        static int MaxProfitSellOnce(int[] prices) {
            int maxProfit = 0;
            int minPrice = prices[0];

            for (int i = 1; i < prices.Length; i++) {
                int potentialProfit = prices[i] - minPrice;
                maxProfit = Math.Max(potentialProfit, maxProfit);
                minPrice = Math.Min(minPrice, prices[i]);
            }
            return maxProfit;
        }
    }
}
