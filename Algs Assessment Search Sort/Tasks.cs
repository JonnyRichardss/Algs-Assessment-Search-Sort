using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algs_Assessment_Search_Sort
{
    internal static class Tasks
    {
        //Class of functions that are used by multiple of the individual task methods
        public static void Sorting(ref int[] array)
        {
            //Generic function for task 2 and repeats
            //sorts and displays values from int[] array

            //setting the display interval based on the array length, so that 256 uses every 10th and 2048 every 50th
            int displayInterval;
            if (array.Length < 2048)
            {
                displayInterval = 10;
            }
            else
            {
                displayInterval = 50;
            }

            //sort using selected algorithm
            Console.WriteLine("Sorting array...");
            int ascSteps = 0;
            Algs.Sort(ref array, true, ref ascSteps);
            Console.WriteLine("{1} sorted ascending in {0} steps!", ascSteps,Algs.currentAlg);

            //make a copy to sort descending using the same algorithm
            int[] descArray = new int[array.Length];
            array.CopyTo(descArray, 0);
            int descSteps = 0;
            Algs.Sort(ref descArray, false, ref descSteps);
            Console.WriteLine("{1} sorted descending in {0} steps!", descSteps, Algs.currentAlg) ;

            //intialise variables for output
            string ascendingout = "";
            string descendingout = "";

            for (int i = 0; i < array.Length; i++) //iterate over both ascending and descending
            {
                if (i % displayInterval == 0)
                {
                    //adding correct values to output
                    ascendingout += String.Format(" {0} ", array[i]);
                    descendingout += String.Format(" {0} ", descArray[i]);
                }
            }
            //outputting values
            Console.WriteLine("Displaying every {0}th value:", displayInterval);
            //These are hacked together like this in case I wanted to add ConsoleColor
            Console.Write("Ascending: "); Console.WriteLine(ascendingout);
            Console.Write("Descending: "); Console.WriteLine(descendingout);
        }

        public static void Searching(ref int[] array,bool task3)
        {
            //Generic function for tasks 3,4 and repeats
            //asks user for input and searches for it in int[] array

            //helpful output for later tasks where tasks 3&4 are one after the other
            if (task3)
            {
                Console.WriteLine("Task 3 mode - giving error if value not found.");
            }
            else
            {
                Console.WriteLine("Task 4 mode - giving nearest value if value not found.");
            }

            //take input from the user, sanitised to be an integer
            Console.WriteLine("Input an integer to search for:");
            int searchInput = Helpers.intInput();
            int steps = 0;

            //have to init both here because sequential and binary searches return differently
            int searchResult = -1;
            List<int> foundList = new List<int>(); 

            Console.WriteLine("Checking if array is sorted...");
            if (!Algs.CheckSorted(array))
            {
                Console.WriteLine("Array not sorted! Using sequential search.");
                foundList =  Algs.SequentialSearch(array, searchInput, ref steps); //sequential search straight into foundList
                searchResult = foundList[0];//searchResult has the -ve check done on it later so it needs to be assigned (perhaps I could've used foundlist[0] for both and done away with this entirely)
            }
            else
            {
                Console.WriteLine("Array Sorted! Using binary search.");
                searchResult = Algs.BinarySearch(array, 0, array.Length - 1, searchInput, ref steps);//binary search first outputs a single int
                Algs.AddEqualNeighbours(ref foundList, array, searchResult);//foundlist is populated after the fact
            }

            //output search results
            Console.WriteLine("Search completed in {0} steps!", steps);
            if (searchResult > 0)//if result found
            {
                //output all occurences
                Console.WriteLine("Found {0} at the following positions:", searchInput);
                foreach (int i in foundList)
                {
                    Console.WriteLine(i);
                }
            }
            else 
            {
                //different not found reaction based on task
                if (task3)
                {
                    Console.WriteLine("Input not found!");
                }
                else
                {
                    //showing nearest value
                    searchResult = Math.Abs(searchResult);
                    Console.WriteLine("Nearest value {0} found at {1}!", array[searchResult], searchResult);
                }
            }
        }

        public static int[] Merging(int[] array1, int[] array2,bool silent)
        {
            //merges int[] array1 and array2, using different approach depending on if they are sorted
            //bool silent allows it to be used for tasks (where user feedback is wanted) or for steps vs n table, where it would clog the console
            if (!silent)Console.WriteLine("Checking if arrays are sorted...");

            if (Algs.CheckSorted(array1) && Algs.CheckSorted(array2)) //if both arrays are sorted use sorted merge
            {
                if (!silent) Console.WriteLine("Arrays are sorted! Using MergeSort merge.");
                int dummycounter = 0;
                return Algs.Merge(array1, array2,true,ref dummycounter);
            }
            else //otherwise concatenate
            {
                if (!silent) Console.WriteLine("One or both arrays not sorted! Using concatenation.");
                List<int> bothArrays = new List<int>();
                bothArrays.AddRange(array1);
                bothArrays.AddRange(array2);
                return bothArrays.ToArray();
                
            }
            
            
        }
    }
}
