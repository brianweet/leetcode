using System;
using System.Collections;
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
            //a
            //-
            //ab
            //b
            //-
            //abc
            //bc
            //c
            //-
            //abcA
            //bca
            //ca
            //a
            //-
            //bcaB
            //cab
            //ab
            //b
            //-
            //cabC
            //abc
            //bc
            //c
            //-
            //abcB
            //bcB
            //cb
            //b
            //-
            //cbB
            //bB
            //b
            //-
            var longest = 0;
            var n = s.Length;
            for (int i = 0; i < n; i++){
                for (int j = i + 1; j <= n; j++) {
                    var len = j-i;
                    if (len > longest){
                        if (IsUnique(s, i, j)) {
                            longest = len;
                        } else {
                            break;
                        }
                    }
                }   
            }
            return longest;
        }

        private bool IsUnique(string s, int start, int end)
        {
            var hashTable = new Hashtable(end-start);
            var chars = s.Substring(start, end-start).ToCharArray();
            foreach (var item in chars)
            {
                if (hashTable[item] != null) {
                    return false;
                }
                hashTable[item] = item;
            }
            return true;
        }
    }
}