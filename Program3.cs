using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Program3
    {
        static void Main(string[] args)
        {
            var solution = new Solution3();
            
            var input = "abcabcbb";
            var expected = 3;
            var result = solution.LengthOfLongestSubstring(input);
            Console.WriteLine($"{expected} {result}");

            var inputx = "abcadcdcbb";
            var expectedx = 4;
            var resultx = solution.LengthOfLongestSubstring(inputx);
            Console.WriteLine($"{expectedx} {resultx}");
        }
    }
    public class Solution3
    {
        public int LengthOfLongestSubstring(string s) {
            // Optimized sliding window 
            int n = s.Length, ans = 0;
            var map = new Dictionary<char, int>();
            // current index of character
            // try to extend the range [i, j]
            for (int j = 0, i = 0; j < n; j++) {
                if (map.ContainsKey(s[j])) {
                    i = Math.Max(map[s[j]], i);
                    map.Remove(s[j]);
                }
                ans = Math.Max(ans, j - i + 1);
                map.Add(s[j], j + 1);
            }
            return ans;
        }
    }
}