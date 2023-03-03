using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    internal class TwoPointers
    {
        public TwoPointers()
        {
            Console.WriteLine("\n 125. Valid Palindrome");
            Console.WriteLine(IsPalindrome("A man, a plan, a canal: Panama"));
            Console.WriteLine(IsPalindrome("race a car"));
            Console.WriteLine(IsPalindrome(""));
            Console.WriteLine(IsPalindrome(".,"));
            Console.WriteLine(IsPalindrome("ab_a"));
        }

        // Easy Problems

        // 125. Valid Palindrome
        // Given a string s, return true if it is a palindrome, or false otherwise.
        public bool IsPalindrome(string s)
        {
            // Strip non-alphanumeric characters
            //char[] chars = s.ToLower().ToCharArray();
            //chars = Array.FindAll<char>(chars, c => char.IsLetterOrDigit(c));            
            //Console.WriteLine($"'{string.Join("", s)}', string length {s.Length}");

            int head = 0;
            int tail = s.Length - 1; // A string length of 0 or 1 will always be a palindrome
            while (head < tail)
            {
                // Move the pointers towards each other until they're on an alphanumber
                if (!char.IsLetterOrDigit(s[head]))
                {
                    head++;
                    continue;
                }
                if (!char.IsLetterOrDigit(s[tail]))
                {
                    tail--;
                    continue;
                }

                if (char.ToLower(s[head]) != char.ToLower(s[tail]))
                {
                    return false;
                }
                head++;
                tail--;
            }

            return true;
        }
    }
}
