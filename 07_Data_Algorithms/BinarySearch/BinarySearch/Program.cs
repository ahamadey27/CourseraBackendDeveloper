using System;
using System.Diagnostics;
class Program
{

    static int BinarySearch(int[] sortedArray, int target)
    {
        int left = 0, right = sortedArray.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (sortedArray[mid] == target) return mid;
            if (sortedArray[mid] < target) left = mid + 1;
            else right = mid - 1;
        }
        return -1; // Target not found
    }

    static int LinearSearch(int[] array, int target)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == target)
                return i;
        }
        return -1;
    }

    static void Main()
    {
        int[] userIds = { 101, 203, 304, 405, 506, 607, 708, 809, 910 };
        int target = 506;
        int index = BinarySearch(userIds, target);
        if (index != -1)
            Console.WriteLine($"User ID {target} found at index {index}.");
        else
            Console.WriteLine($"User ID {target} not found.");

        // Additional test cases for edge cases
        int[] emptyArray = { };
        int[] duplicatesArray = { 101, 203, 304, 304, 506, 607 };
        int targetNotFound = 999;
        Console.WriteLine(BinarySearch(emptyArray, 101)); // Expected: -1
        Console.WriteLine(BinarySearch(duplicatesArray, 304)); // Expected: Index of any occurrence of 304
        Console.WriteLine(BinarySearch(duplicatesArray, targetNotFound)); // Expected: -1


        // Performance testing starts here
        int[] largeDataset = new int[1000000000];
        for (int i = 0; i < largeDataset.Length; i++)
        {
            largeDataset[i] = i;
        }
        int largeTarget = 999999999;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        int binarySearchResult = BinarySearch(largeDataset, largeTarget);
        stopwatch.Stop();
        Console.WriteLine($"Binary Search Time: {stopwatch.ElapsedMilliseconds} ms");
        stopwatch.Restart();
        int linearSearchResult = LinearSearch(largeDataset, largeTarget);
        stopwatch.Stop();
        Console.WriteLine($"Linear Search Time: {stopwatch.ElapsedMilliseconds} ms");
    }
   
}