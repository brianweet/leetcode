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

            var test = solution.IsPalindrome("lepel", 0, 4);
            var test0 = solution.IsPalindrome("bab", 0, 2);
            var test1 = solution.IsPalindrome("bb", 0, 1);
            var test2 = solution.IsPalindrome("bbx", 0, 2);


            // "babad" -> "bab" or "aba"
            Run(solution, "babad", "bab");
            // "cbbd" -> "bb"
            Run(solution, "cbbd", "bb");

            Run(solution, "gphyvqruxjmwhonjjrgumxjhfyupajxbjgthzdvrdqmdouuukeaxhjumkmmhdglqrrohydrmbvtuwstgkobyzjjtdtjroqpyusfsbjlusekghtfbdctvgmqzeybnwzlhdnhwzptgkzmujfldoiejmvxnorvbiubfflygrkedyirienybosqzrkbpcfidvkkafftgzwrcitqizelhfsruwmtrgaocjcyxdkovtdennrkmxwpdsxpxuarhgusizmwakrmhdwcgvfljhzcskclgrvvbrkesojyhofwqiwhiupujmkcvlywjtmbncurxxmpdskupyvvweuhbsnanzfioirecfxvmgcpwrpmbhmkdtckhvbxnsbcifhqwjjczfokovpqyjmbywtpaqcfjowxnmtirdsfeujyogbzjnjcmqyzciwjqxxgrxblvqbutqittroqadqlsdzihngpfpjovbkpeveidjpfjktavvwurqrgqdomiibfgqxwybcyovysydxyyymmiuwovnevzsjisdwgkcbsookbarezbhnwyqthcvzyodbcwjptvigcphawzxouixhbpezzirbhvomqhxkfdbokblqmrhhioyqubpyqhjrnwhjxsrodtblqxkhezubprqftrqcyrzwywqrgockioqdmzuqjkpmsyohtlcnesbgzqhkalwixfcgyeqdzhnnlzawrdgskurcxfbekbspupbduxqxjeczpmdvssikbivjhinaopbabrmvscthvoqqbkgekcgyrelxkwoawpbrcbszelnxlyikbulgmlwyffurimlfxurjsbzgddxbgqpcdsuutfiivjbyqzhprdqhahpgenjkbiukurvdwapuewrbehczrtswubthodv", "");

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
                for (int j = s.Length; j >= i; j--)
                {
                    var length = j - i;
                    if (length > longest.Length)
                    {
                        if (IsPalindrome(s, i, j-1))
                        {
                            longest = s.Substring(i, length);
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return longest;
        }

        public bool IsPalindrome(string v, int i, int j)
        {
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