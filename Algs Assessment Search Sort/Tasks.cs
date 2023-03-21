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
            int ascSteps = 0;
            Algs.Sort(ref array, true, ref ascSteps);
            Console.WriteLine("{1} sorted ascending in {0} steps!", ascSteps,Algs.currentAlg);

            int[] descArray = new int[array.Length];
            array.CopyTo(descArray, 0);
            int descSteps = 0;
            Algs.Sort(ref descArray, false, ref descSteps);
            Console.WriteLine("{1} sorted descending in {0} steps!", descSteps, Algs.currentAlg) ;

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
            if (task3)
            {
                Console.WriteLine("Task 3 mode - giving error if value not found.");
            }
            else
            {
                Console.WriteLine("Task 4 mode - giving nearest value if value not found.");
            }
            Console.WriteLine("Input an integer to search for:");
            int searchInput = Helpers.intInput();
            int steps = 0;
            int searchResult = -1;
            List<int> foundList = new List<int>();
            Console.WriteLine("Checking if array is sorted...");
            if (!Algs.CheckSorted(array))
            {
                Console.WriteLine("Array not sorted! Using sequential search.");
                foundList =  Algs.SequentialSearch(array, searchInput, ref steps);
                searchResult = foundList[0];
            }
            else
            {
                Console.WriteLine("Array Sorted! Using binary search.");
                searchResult = Algs.BinarySearch(array, 0, array.Length - 1, searchInput, ref steps);
                Algs.AddEqualNeighbours(ref foundList, array, searchResult);
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
            if (Algs.CheckSorted(array1) && Algs.CheckSorted(array2))
            {
                Console.WriteLine("Arrays are sorted! Using MergeSort merge.");
                return Algs.Merge(array1, array2,true);
            }
            else
            {
                Console.WriteLine("One or both arrays not sorted! Using concatenation.");
                List<int> bothArrays = new List<int>();
                bothArrays.AddRange(array1);
                bothArrays.AddRange(array2);
                return bothArrays.ToArray();
                
            }
            
            
        }
    }
}
