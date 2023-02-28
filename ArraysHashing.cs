using System;
using System.Collections.Generic;
using System.Linq;
//using System.Numerics;
//using System.Text;

namespace Leetcode
{
    internal class ArraysHashing
    {
        public ArraysHashing()
        {
            Console.WriteLine("\n 242.Valid Anagram");
            Console.WriteLine(IsAnagram("anagram", "nagaram"));
            Console.WriteLine(IsAnagram("rat", "car"));

            Console.WriteLine("\n 217.Contains Duplicate");
            Console.WriteLine(ContainsDuplicate(new int[] { 1, 2, 3, 1 }));
            Console.WriteLine(ContainsDuplicate(new int[] { 1, 2, 3, 4 }));
            Console.WriteLine(ContainsDuplicate( new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 } ) );
        }

        // 242.Valid Anagram
        // Given two strings s and t, return true if t is an anagram of s, and false otherwise.
        public bool IsAnagram(string s, string t)
        {
            // Can't be an anagram if there's not the same number of letters
            if (s.Length != t.Length) { return false; }

            // Counting difference in occurences of each letter method (fastest)
            // Taking advantage of only lowercase english letters to use an array to be faster than a dictionary
            int[] letterCounts = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                letterCounts[s[i] - 'a']++;
                letterCounts[t[i] - 'a']--;
            }
            foreach (int count in letterCounts)
            {
                if (count != 0) return false;
            }
            return true;

            // Same counting method as above but uses a dictionary for unicode support (faster)
            // Costs more memory

            // Fill dictionary, counting the difference in number of each letter in the words
            Dictionary<char, int> alphabet = new Dictionary<char, int>(26);
            for (int i = 0; i < s.Length; i++)
            {
                alphabet[s[i]] = alphabet.GetValueOrDefault(s[i]) + 1;
                alphabet[t[i]] = alphabet.GetValueOrDefault(t[i]) - 1;
            }
            foreach (var letter in alphabet)
            {
                // An anagram has the same number of occurances in each letter
                if (letter.Value != 0)
                {
                    return false;
                }
            }
            return true;

            // Comparing sorted arrays method (slowest)
            char[] one = s.ToCharArray();
            char[] two = t.ToCharArray();
            Array.Sort<char>(one);
            Array.Sort<char>(two);
            return one.SequenceEqual(two);
        }

        // 217.Contains Duplicate
        // Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.
        public bool ContainsDuplicate(int[] nums)
        {
            // Quickest method at the expense of some memory
            HashSet<int> set = new HashSet<int>(nums.Length);
            
            for (int i = 0; i < nums.Length; i++)
            {
                // Adding to hashsets will fail if a number already exists
                if (!set.Add(nums[i]))
                {
                    return true;
                }
            }
            return false;

            // Quickest method without using extra memory
            Array.Sort<int>(nums);            

            // Foreach number in the array
            for (int i = 0; i < nums.Length - 1; i++)
            {
                // Check only the adjacent number since the list is already sorted
                if (nums[i] == nums[i + 1])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
