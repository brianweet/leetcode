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
            var n = s.Length;
            var set = new HashSet<char>();
            int ans = 0, i = 0, j = 0;
            while (i < n && j < n) {
                // try to extend the range [i, j]
                if (!set.Contains(s[j])){
                    set.Add(s[j++]);
                    ans = Math.Max(ans, j - i);
                }
                else {
                    set.Remove(s[i++]);
                }
            }
            return ans;
        }
    }
}