using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Program5
    {
        static void Main(string[] args)
        {
            var solution = new Solution5();

            var test = solution.IsPalindrome("lepel");
            var test0 = solution.IsPalindrome("bab");
            var test1 = solution.IsPalindrome("bb");
            var test2 = solution.IsPalindrome("bbx");


            // "babad" -> "bab" or "aba"
            Run(solution, "babad", "bab");
            // "cbbd" -> "bb"
            Run(solution, "cbbd", "bb");

            static void Run(Solution5 solution, string input, string expected)
            {
                var result = solution.LongestPalindrome(input);
                Console.WriteLine($"{expected} {result}");
            }
        }
    }

    public class Solution5
    {
        public string LongestPalindrome(string s)
        {
            var longest = "";
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = s.Length - 1; j >= i; j--)
                {
                    var length = j - i + 1;
                    if (length > longest.Length)
                    {
                        var current = s.Substring(i, length);
                        if (IsPalindrome(current))
                        {
                            longest = current;
                            i++;
                            j = s.Length;
                        }
                    }
                    else
                    {
                        i++;
                        j = s.Length;
                    }
                }
            }
            return longest;
        }

        public bool IsPalindrome(string v)
        {
            int i = 0, j = v.Length - 1;
            while (i < j)
            {
                if (v[i] != v[j])
                {
                    return false;
                }
                i++;
                j--;
            }
            return true;
        }
    }
}