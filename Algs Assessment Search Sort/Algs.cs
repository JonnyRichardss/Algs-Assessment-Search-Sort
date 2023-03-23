using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algs_Assessment_Search_Sort
{
    public enum SortingAlgs
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
        //decided to make these int-only based on the given data for the assessment
        public static int BinarySearch(in int[] array, int lo, int hi, int key, ref int counter)
        {
            counter++;

            if (key < array[lo])
            {
                return -lo;
            }
            if (key > array[hi])
            {
                return -hi;
            }

            int mid = (lo + hi) / 2;
            if (lo > hi)
            {
                return (-mid);
            }
            if (key == array[mid])
            {
                return mid;
            }
            else if (array[mid] < key)
            {
                if (mid < array.Length - 1 && array[mid + 1] > key)
                {
                    return -GetClosest(array, mid, mid + 1, key);
                }
                else
                {
                    return BinarySearch(array, mid + 1, hi, key, ref counter);
                }
            }
            else
            {
                if (mid > 0 && array[mid - 1] < key)
                {
                    return -GetClosest(array, mid-1, mid, key);
                }
                else
                {
                    return BinarySearch(array, lo, mid - 1, key, ref counter);
                } 
            }
        }
        public static int GetClosest(in int[] array,int lo, int hi, int key)
        {
            if (key - array[lo] > array[hi] - key)
            {
                return hi;
            }
            else
            {
                return lo;
            }
        }

        public static List<int> SequentialSearch(in int[] array,int key,ref int counter)
        {
            List<int> foundIndices = new List<int>();
            int nearestindex=0;
            int nearestdistance = int.MaxValue;
            for (int i=0; i<array.Length;i++)
            {
                counter++;
                if (array[i] == key)
                {
                    foundIndices.Add(i);
                    nearestdistance = 0;
                }
                if (nearestdistance > 0)
                {
                    int newdistance = Math.Abs(array[i] - key);
                    if (newdistance < nearestdistance)
                    {
                        nearestdistance = newdistance;
                        nearestindex = i;
                    }
                }
            }
            if (foundIndices.Count == 0)
            {
                return new List<int> { -nearestindex };
            }
            else
            {
                return foundIndices;
            }
        }


        public static void Sort(ref int[] array,bool asc, ref int counter)
        {
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
            if(array.Length == 1)
            {
                return;
            }
            int i1 = array.Length / 2;
            int i2 = array.Length - i1;

            int[] lefthalf = new int[array.Length/2];
            int[] righthalf = new int[array.Length -lefthalf.Length];

            Array.Copy(array, 0, lefthalf, 0, i1);
            Array.Copy(array, i1, righthalf, 0, i2);

            MergeSort(ref lefthalf,asc,ref counter);
            MergeSort(ref righthalf,asc,ref counter);
            Merge(lefthalf, righthalf,asc,ref counter).CopyTo(array, 0);
        }
        public static int[] Merge(int[] aL, int[] aR,bool asc,ref int counter)
        {
            int[] output = new int[aL.Length + aR.Length];
            int indexL = 0;
            int indexR = 0;
            int outputIndex = 0;
            bool condition;
            while (indexL < aL.Length && indexR < aR.Length)
            {
                counter++;
                if (asc)
                {
                    condition = aL[indexL]< aR[indexR];
                }
                else
                {
                    condition = aL[indexL]> aR[indexR];
                }

                if (condition)
                {
                    output[outputIndex] = aL[indexL];
                    indexL++;
                    outputIndex++;
                }
                else
                {
                    output[outputIndex] = aR[indexR];
                    indexR++;
                    outputIndex++;
                }
            }
            while (indexL < aL.Length)
            {
                counter++;
                output[outputIndex] = aL[indexL];
                indexL++;
                outputIndex++;
            }
            while (indexR < aR.Length)
            {
                counter++;
                output[outputIndex] = aR[indexR];
                indexR++;
                outputIndex++;
            }
           
            return output;
        }
        public static void QuickSort(ref int[] array,int lo,int hi,bool asc, ref int counter)
        {
            if (lo < hi)
            {
                int pivotIndex = Partition(ref array, lo, hi, asc,ref counter);
                QuickSort(ref array,lo,pivotIndex-1,asc,ref counter);
                QuickSort(ref array, pivotIndex + 1, hi, asc, ref counter);
            }
        }
        public static int Partition(ref int[] array,int lo,int hi, bool asc,ref int counter)
        {
            int pivotValue = array[hi]; //pivot value chosen, always using the last value greatly simplifies iteration
            int i = lo - 1; // I represents the index before the pivot value, the more values we place below where the pivot will be, the higher i gets
            bool condition;//for asc/desc
            for (int j = lo; j <= hi; j++)//iterate over the section in question
            {
                counter++;
                if (asc)//ascending or descending comparison
                {
                    condition = array[j] < pivotValue;//ascending places lower values left of pivot
                }
                else 
                {
                    condition = array[j] > pivotValue;//descending places higher values left of pivot
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
            int tempvalue = array[i1];
            array[i1] = array[i2];
            array[i2] = tempvalue;
        }
        public static void BubbleSort(ref int[] array,bool asc,ref int counter)
        {
            bool condition;
            bool swapped = true;
            int i = 0;
            while(swapped && i< array.Length)
            {
                swapped = false;
                for (int j = 0; j < array.Length - 1; j++)
                {
                    counter++;
                    if (asc)
                    {
                        condition = array[j] > array[j + 1];
                    }
                    else
                    {
                        condition = array[j] < array[j + 1];
                    }

                    if (condition)
                    {
                        Swap(ref array, j, j + 1);
                        swapped = true;
                    }
                }
                i++;
            }
        }
        public static void InsertionSort(ref int[] array,bool asc,ref int counter)
        {
            int sortedLength = 1;
            while (sortedLength < array.Length)
            {
                int currentValue = array[sortedLength];
                int i;
                bool condition;
                for (i = sortedLength; i > 0; i--)
                {
                    counter++;
                    if (asc)
                    {
                        condition = currentValue < array[i-1];
                    }
                    else
                    {
                        condition = currentValue > array[i-1];
                    }
                    if (condition)
                    {
                        array[i] = array[i-1];
                    }
                    else
                    {
                        break;
                    }
                }
                array[i] = currentValue;
                sortedLength++;
            }
        }
        
        public static void AddEqualNeighbours(ref List<int> equalIndices, in int[] array, int index)
        {
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
        public static bool CheckSorted(in int[] array)//checks to see if array is sorted in ascending order
        {
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
