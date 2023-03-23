using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algs_Assessment_Search_Sort
{
    public enum SortingAlgs //enum allows for easier changing of sorting algorithm than using just an int
    {
        Merge =1,
        Quick =2,
        Bubble =3,
        Insertion =4
    }
    internal static class Algs
    {
        //class of functions that perform array-related actions

        public static SortingAlgs currentAlg = (SortingAlgs)1;
        public static string[] algNames = { "Merge Sort", "Quick Sort", "Bubble Sort", "Insertion Sort" };
        public static int BinarySearch(in int[] array, int lo, int hi, int key, ref int counter)
        {
            //recursive function that searches a given int[] array for 'key'
            //returns a positive index of the position if a value is found
            //returns the negative of the nearest value's index if the value is not found

            counter++;//increments the counter for efficiency analysis

            //checks to see if key is out of the range of the current search, stopping early
            if (key < array[lo])
            {
                return -lo;
            }
            if (key > array[hi])
            {
                return -hi;
            }

            int mid = (lo + hi) / 2;//sets the value to check

            if (lo > hi)
            {
                return (-mid); //old base case where value was not found, this will always be skipped due to the GetClosest checks
            }

            if (key == array[mid])
            {
                return mid; //base case - if the value is found, return it
            }

            //recursive case
            else if (array[mid] < key)
            {
                //check right half of array
                if (mid < array.Length - 1 && array[mid + 1] > key) //if we are not at edge of array and next value is right of key (key is between current mid and next lo)
                {
                    //intercepting check to see if we are at a possible closest value to 'key'
                    return -GetClosest(array, mid, mid + 1, key); //returns the index of whichever value is closest to 'key'
                }
                else
                {
                    return BinarySearch(array, mid + 1, hi, key, ref counter); //recurse, check right half
                }
            }
            else
            {
                //check left half of array
                if (mid > 0 && array[mid - 1] < key)//if we are not at edge of array and next value is left of key (key is between current mid and next hi)
                {
                    //intercepting check to see if we are at a possible closest value to 'key'
                    return -GetClosest(array, mid-1, mid, key);//returns the index of whichever value is closest to 'key'
                }
                else
                {
                    return BinarySearch(array, lo, mid - 1, key, ref counter); //recurse, check left half
                } 
            }
        }
        public static int GetClosest(in int[] array,int lo, int hi, int key)
        {
            //simple function to help binary search
            //returns the index of 'lo' or 'hi', whichever's value is closest to key

            if (key - array[lo] > array[hi] - key) 
            {
                return hi;
            }
            else
            {
                return lo;
            }
            //perhaps the 'lo' and 'hi' don't have to be rigidly specified if Abs() is taken of the difference
        }

        public static List<int> SequentialSearch(in int[] array,int key,ref int counter)
        {
            //iterative function that searches a whole array sequentially
            //returns a List of all indices where the value 'key' is found

            List<int> foundIndices = new List<int>();

            int nearestindex=0;
            int nearestdistance = int.MaxValue; //setting nearest distance high so that we can improve it when the array is iterated over

            for (int i=0; i<array.Length;i++) //over the whole array
            {
                counter++;//increments the counter for efficiency analysis
                if (array[i] == key) 
                {
                    //if we find the value, add it to the list and disable nearest value finding
                    foundIndices.Add(i);
                    nearestdistance = 0;
                }
                if (nearestdistance > 0) //if we still need to refine a nearest value
                {
                    int newdistance = Math.Abs(array[i] - key); //find the current value's distance to the key
                    if (newdistance < nearestdistance)
                    {
                        //if it is better, update the best value found
                        nearestdistance = newdistance;
                        nearestindex = i;
                    }
                }
            }
            if (foundIndices.Count == 0)
            {
                return new List<int> { -nearestindex }; //list has count 1 and the index is negative if no value is found
            }
            else
            {
                return foundIndices; //if anything is found, list has positive indices and has as many elements as occurences found
            }
        }


        public static void Sort(ref int[] array,bool asc, ref int counter)
        {
            //switching function so that changing algorithms only happens here instead of all over the code
            //checks which algorithm is selected and passes straight on to that algorithm
            switch (currentAlg)
            {
                case SortingAlgs.Merge:
                    MergeSort(ref array,asc, ref counter);
                    break;
                case SortingAlgs.Quick:
                    QuickSort(ref array,0,array.Length-1, asc, ref counter);
                    break;
                case SortingAlgs.Bubble:
                    BubbleSort(ref array, asc, ref counter);
                    break;
                case SortingAlgs.Insertion:
                    InsertionSort(ref array, asc, ref counter);
                    break;
            }
        }

        public static void MergeSort(ref int[] array,bool asc, ref int counter)
        {
            //recursive function to merge sort int[] array
            //bool asc will reverse direction if set to false
            //passing by reference means no return type is necessary, simplifying recursion

            if(array.Length == 1)//base case, array cannot be merged
            {
                return;
            }
            //recursive case

            //splitting array into two halves
            int i1 = array.Length / 2;
            int i2 = array.Length - i1;

            
            int[] lefthalf = new int[array.Length/2];
            int[] righthalf = new int[array.Length -lefthalf.Length];

            //copying halves into their own arrays
            Array.Copy(array, 0, lefthalf, 0, i1);
            Array.Copy(array, i1, righthalf, 0, i2);

            //recursively sort halves
            MergeSort(ref lefthalf,asc,ref counter);
            MergeSort(ref righthalf,asc,ref counter);
            //once base case comes back up, merge the two halves
            Merge(lefthalf, righthalf,asc,ref counter).CopyTo(array, 0);//copy the merged result into the original array
        }
        public static int[] Merge(int[] aL, int[] aR,bool asc,ref int counter)
        {
            //function that takes in two int[] arrays, Left and Right, merging them into a single array
            //returns a single int[] that has all elements of both arrays, sorted in order

            //initialising output and other locals
            int[] output = new int[aL.Length + aR.Length];
            int indexL = 0;
            int indexR = 0;
            int outputIndex = 0;
            bool condition;
            while (indexL < aL.Length && indexR < aR.Length) //until one array runs out
            {
                counter++;//increments the counter for efficiency analysis

                if (asc)// this switches between checking for ascending or descending sort
                {
                    condition = aL[indexL]< aR[indexR]; //ascending
                }
                else
                {
                    condition = aL[indexL]> aR[indexR];//descending
                }

                if (condition)
                {
                    //add the value from the left array to the output
                    output[outputIndex] = aL[indexL];
                    indexL++;
                    outputIndex++;
                }
                else
                {
                    //add the value from the right array to the output
                    output[outputIndex] = aR[indexR];
                    indexR++;
                    outputIndex++;
                }
            }
            //once either array is exhausted, the rest of the values in the other must be added to the output
            while (indexL < aL.Length)
            {
                counter++;//increments the counter for efficiency analysis
                output[outputIndex] = aL[indexL];
                indexL++;
                outputIndex++;
            }
            while (indexR < aR.Length)
            {
                counter++;//increments the counter for efficiency analysis
                output[outputIndex] = aR[indexR];
                indexR++;
                outputIndex++;
            }
           
            return output;
        }
        public static void QuickSort(ref int[] array,int lo,int hi,bool asc, ref int counter)
        {
            //recursive function to quick sort int[] array
            //bool asc will reverse direction if set to false
            //passing by reference means no return type is necessary, simplifying recursion
            //takes the section of the array to work on (lo,hi) as input

            if (lo < hi)// lo>hi is the base case, does nothing since there is no return type (it could perhaps be nice to change this to be explicit like in the merge sort)
            {
                int pivotIndex = Partition(ref array, lo, hi, asc,ref counter); //sort the arrray into two halves and grab the position of the pivot for sorting
                //recursively sort each half
                QuickSort(ref array,lo,pivotIndex-1,asc,ref counter);
                QuickSort(ref array, pivotIndex + 1, hi, asc, ref counter);
            }
        }
        public static int Partition(ref int[] array,int lo,int hi, bool asc,ref int counter)
        {
            //function to sort array into two sides from a chosen pivot
            //returns the current position of the pivot
            //takes the section of the array to work on (lo,hi) as input

            int pivotValue = array[hi]; //pivot value chosen, always using the last value greatly simplifies iteration
            int i = lo - 1; // I represents the index before the pivot value, the more values we place below where the pivot will be, the higher i gets
            bool condition;//for asc/desc
            for (int j = lo; j <= hi; j++)//iterate over the section in question
            {
                counter++;//increments the counter for efficiency analysis

                if (asc)// this switches between checking for ascending or descending sort
                {
                    condition = array[j] < pivotValue;//ascending
                }
                else 
                {
                    condition = array[j] > pivotValue;//descending
                }

                if (condition)//if array[j] goes left of the pivot
                {
                    i++;//move the pivot one right
                    Swap(ref array, i, j);//place the value left of the pivot
                }
            }
            Swap(ref array, i+1, hi);//place the pivot in its correct spot
            return i + 1;//return the pivot spot
        }
        public static void Swap(ref int[] array, int i1, int i2)
        {
            //simple function to swap two indices in an array using a temp value
            int tempvalue = array[i1];
            array[i1] = array[i2];
            array[i2] = tempvalue;
        }
        public static void BubbleSort(ref int[] array,bool asc,ref int counter)
        {
            //iterative function to bubble sort int[] array
            //bool asc will reverse direction if set to false

            bool condition;

            bool swapped = true;//bool swapped allows an optimisation where sorting will not continue if a pass is made with no array changes
            int i = 0;

            while(swapped && i< array.Length) //while we are still in the array and made a change last pass through
            {
                swapped = false;//reset swapped for the current pass

                for (int j = 0; j < array.Length - 1; j++)//iterate through the whole array
                {

                    counter++;//increments the counter for efficiency analysis

                    if (asc)// this switches between checking for ascending or descending sort
                    {
                        condition = array[j] > array[j + 1]; //ascending
                    }
                    else
                    {
                        condition = array[j] < array[j + 1]; //descending
                    }

                    if (condition) //if value needs to move right
                    {
                        Swap(ref array, j, j + 1);
                        swapped = true;//mark that we have made a change this pass so the array is not necessarily sorted
                    }
                }
                i++;
            }
        }
        public static void InsertionSort(ref int[] array,bool asc,ref int counter)
        {
            //iterative function to insertion sort int[] array
            //bool asc will reverse direction if set to false

            int sortedLength = 1; //integer marking length of currently sorted portion
            while (sortedLength < array.Length) //keep loopign until whole array is sorted
            {
                int currentValue = array[sortedLength]; //check the index after our sorted section
                int i;
                bool condition;
                for (i = sortedLength; i > 0; i--) //iterate over the sorted section
                {
                    counter++;//increments the counter for efficiency analysis

                    if (asc)// this switches between checking for ascending or descending sort
                    {
                        condition = currentValue < array[i-1]; //ascending
                    }
                    else
                    {
                        condition = currentValue > array[i-1]; //descending
                    }
                    if (condition) //if value needs to go left
                    {
                        array[i] = array[i-1]; //move the value that is currently left to the right
                    }
                    else
                    {
                        break; //once no more values are shuffled, the correct spot is found 
                    }
                }
                array[i] = currentValue;//place the value in the current spot
                sortedLength++;//move to next value
            }
        }
        
        public static void AddEqualNeighbours(ref List<int> equalIndices, in int[] array, int index)
        {
            //recursive function to help binary search find multiple instances of a value
            //adds the currently checked index to equalIndices and calls the function on neighbours that have the same value

            if (!(equalIndices.Contains(index)))
            {
                equalIndices.Add(index);
                try
                {
                    if (array[index] == array[index - 1])
                    {
                        AddEqualNeighbours(ref equalIndices, array, index - 1);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    //this is perhaps a silly way to deal with being on the edge of the array but it made sense when I originally coded it
                }
                try
                {
                    if (array[index] == array[index + 1])
                    {
                        AddEqualNeighbours(ref equalIndices, array, index + 1);
                    }
                }
                catch (IndexOutOfRangeException)
                {

                }
            }
        }
        public static bool CheckSorted(in int[] array)
        {
            //function to sequentially check to see if array is sorted in ascending order
            //I chose to use only ascending to simplify the logic
            //iterate through the array
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    return false; //if sorted ascending no value will be greater than the one after it
                }
            }
            return true;
        }
    }
}
