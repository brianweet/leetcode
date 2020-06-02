using System;
using System.Linq;

namespace LeetCode
{
    class Program4
    {
        static void Main(string[] args)
        {
            var solution = new Solution4();

            // 1,2,3 -> 2
            Run(solution, new[] { 1, 3 }, new[] { 2 }, 2.0);
            // 1,2,3,4 -> 2.5
            Run(solution, new[] { 1, 2 }, new[] { 3, 4 }, 2.5);

            static void Run(Solution4 solution, int[] nums1, int[] nums2, double expected)
            {
                var result = solution.FindMedianSortedArrays(nums1, nums2);
                Console.WriteLine($"{expected} {result}");
            }
        }
    }
    public class Solution4
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var sorted = nums1.Concat(nums2).OrderBy(x => x);
            var total = (nums1.Length + nums2.Length);
            var middle = total / 2;
            return total % 2 == 1 ?
                sorted.ElementAt(middle) : (sorted.ElementAt(middle - 1) + sorted.ElementAt(middle)) / 2.0;
        }
    }
}