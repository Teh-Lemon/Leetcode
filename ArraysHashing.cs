using System;
using System.Collections.Generic;
//using System.Numerics;
//using System.Text;

namespace Leetcode
{
    internal class ArraysHashing
    {
        public ArraysHashing()
        {
            Console.WriteLine("217.Contains Duplicate");
            Console.WriteLine(ContainsDuplicate(new int[] { 1, 2, 3, 1 }));
            Console.WriteLine(ContainsDuplicate(new int[] { 1, 2, 3, 4 }));
            Console.WriteLine(ContainsDuplicate( new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 } ) );
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
