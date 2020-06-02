using System;
using System.Linq;

namespace LeetCode
{
    class Program4
    {
        static void Main(string[] args)
        {
            var solution = new Solution4();

            // 1,3,7,8,9,11,15,18,19,21,25 -> 11
            Run(solution, new[] { 1,3,8,9,15 }, new[] { 7, 11, 18, 19, 21, 25 }, 11.0);
            // 1,3,7,8,9,11,15,18,19,21,25 -> 11
            Run(solution, new[] { 23,26,31,35 }, new[] { 3,5,7,9,11,16 }, 13.5);

            // 1,2,3 -> 2
            Run(solution, new[] { 1, 3 }, new[] { 2 }, 2.0);
            // 1,2,3,4 -> 2.5
            Run(solution, new[] { 1, 2 }, new[] { 3, 4 }, 2.5);
            // 1,2,3 -> 2
            Run(solution, new[] { 1, 2, 3 }, new int[0], 2.0);
            // 1,2,3 -> 2
            Run(solution, new int[0], new int[] { 1, 2, 3 }, 2.0);

            static void Run(Solution4 solution, int[] nums1, int[] nums2, double expected)
            {
                var result = solution.FindMedianSortedArrays(nums1, nums2);
                Console.WriteLine($"{expected} {result}");
            }
        }
    }
    public class Solution4
    {
        public double FindMedianSortedArrays(int[] x, int[] y)
        {
            if (x.Length > y.Length)
            {
                return FindMedianSortedArrays(y, x);
            }
            var start = 0;
            var end = x.Length;
            while (start <= end)
            {
                var splitX = (start + end) / 2;
                var splitY = ((x.Length + y.Length + 1) / 2) - splitX;

                var maxLeftX = splitX == 0 ? int.MinValue : x[splitX - 1];
                var minRightX = splitX == x.Length ? int.MaxValue : x[splitX];
                var maxLeftY = splitY == 0 ? int.MinValue : y[splitY - 1];
                var minRightY = splitY == y.Length ? int.MaxValue : y[splitY];

                if (maxLeftX <= minRightY && maxLeftY <= minRightX)
                {
                    if ((x.Length + y.Length) % 2 == 0)
                    {
                        return (Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY)) / 2.0;
                    }
                    else
                    {
                        return Math.Max(maxLeftX, maxLeftY);
                    }
                }
                else if (maxLeftX > minRightY)
                {
                    end = splitX - 1;
                }
                else
                {
                    start = splitX + 1;
                }
            }
            throw new Exception();
        }
    }
}