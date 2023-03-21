using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algs_Assessment_Search_Sort
{
    internal static class Tasks
    {
        //Class of functions that are used by multiple by the individual task methods
        public static void Sorting(ref int[] array)
        {
            int displayInterval;
            if (array.Length < 2048)
            {
                displayInterval = 10;
            }
            else
            {
                displayInterval = 50;
            }
            Console.WriteLine("Sorting array...");
            int steps = 0;
            Algs.Sort(ref array,ref steps);
            Console.WriteLine("Merge sorted in {0} steps!", steps);

            //this needs changing to a full sort
            //maybe force heap sort to "reverse" sorted array
            int[] descArray = new int[array.Length];
            array.CopyTo(descArray, 0);
            Array.Reverse(descArray);

            string ascendingout = "";
            string descendingout = "";

            for (int i = 0; i < array.Length; i++)
            {
                if (i % displayInterval == 0)
                {
                    ascendingout += String.Format(" {0} ", array[i]);
                    descendingout += String.Format(" {0} ", descArray[i]);
                }
            }
            Console.WriteLine("Displaying every {0}th value:", displayInterval);
            //These are hacked together like this in case I want to add ConsoleColor
            Console.Write("Ascending: "); Console.WriteLine(ascendingout);
            Console.Write("Descending: "); Console.WriteLine(descendingout);
        }

        public static void Searching(ref int[] array,bool task3)
        {
            int searchInput = Helpers.intInput();
            int steps = 0;
            int searchResult = -1;
            List<int> foundList = new List<int>();
            Console.WriteLine("Checking if array is sorted...");
            if (!Helpers.CheckSorted(array))
            {
                Console.WriteLine("Array not sorted! Using sequential search.");
                int[] foundArray = Algs.SequentialSearch(array, searchInput, ref steps);
                if (foundArray[0] < 0)
                {
                    searchResult = foundArray[0];
                }
                else
                {
                    foundList.AddRange(foundArray);
                }
            }
            else
            {
                Console.WriteLine("Array Sorted! Using binary search.");
                searchResult = Algs.BinarySearch(array, 0, array.Length - 1, searchInput, ref steps);
                Helpers.AddEqualNeighbours(ref foundList, array, searchResult);
            }
            Console.WriteLine("Search completed in {0} steps!", steps);
            if (searchResult > 0)
            {
                Console.WriteLine("Found {0} at the following positions:", searchInput);
                foreach (int i in foundList)
                {
                    Console.WriteLine(i);
                }
            }
            else
            {
                if (task3)
                {
                    Console.WriteLine("Input not found!");
                }
                else
                {
                    searchResult = Math.Abs(searchResult);
                    Console.WriteLine("Nearest value {0} found at {1}!", array[searchResult], searchResult);
                }
            }
        }

        public static int[] Merging(int[] array1, int[] array2)
        {
            Console.WriteLine("Checking if arrays are sorted...");
            if (!Helpers.CheckSorted(array1))
            {
                Console.WriteLine("Array 1 not sorted! Sorting array...");
                int steps = 0;
                Algs.MergeSort(ref array1, ref steps);
                Console.WriteLine("Merge sorted in {0} steps!", steps);
            }
            if (!Helpers.CheckSorted(array2))
            {
                Console.WriteLine("Array 2 not sorted! Sorting array...");
                int steps = 0;
                Algs.MergeSort(ref array2, ref steps);
                Console.WriteLine("Merge sorted in {0} steps!", steps);
            }
            return Algs.Merge(array1, array2);
        }
    }
}
