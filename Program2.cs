using System;
namespace LeetCode
{
    class Program2
    {
        static void Main2(string[] args)
        {
            var list1 = new ListNode(5);
            Console.WriteLine($"list1 {list1.GetValueString()}");
            var list2 = new ListNode(5);
            var prev = list2;
            for (int i = 0; i < 3; i++)
            {
                prev.next = new ListNode(0);
                prev = prev.next;
            }
            prev.next = new ListNode(1);
            Console.WriteLine($"list2 {list2.GetValueString()}");
            
            var expected = 10010;
            var solution = new Solution2();
            var real = solution.AddTwoNumbers(list1, list2);
            var sb = real.GetValueString();
            Console.WriteLine($"{expected} {sb}");
        }
    }
    public class Solution2
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            return RecursiveSum(l1, l2);
        }

        public ListNode RecursiveSum(ListNode l1, ListNode l2, int carry = 0) {
            // If both are null, we're done
            if (l1 == null && l2 == null) {
                // Might still have to create carry node
                return carry == 1 ? new ListNode(1) : null;
            }
            
            // Sum up current values + carry
            var sum = (l1?.val ?? 0) + (l2?.val?? 0) + carry;
            // Verify if we have to carry
            if (sum > 9) {
                return new ListNode(sum % 10, RecursiveSum(l1?.next, l2?.next, 1));
            } else {
                return new ListNode(sum, RecursiveSum(l1?.next, l2?.next, 0));
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public static class ListNodeExtensions
    {
        public static string GetValueString(this ListNode listNode){
            return $"{listNode.next?.GetValueString() ?? string.Empty}{listNode.val}";
        }
    }
}
