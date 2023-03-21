using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algs_Assessment_Search_Sort
{
    internal static class Algs
    {
        //decided to make these int-only based on the given data for the assessment
        public static int BinarySearchRecursive(in int[] array, int lo, int hi, int key, ref int counter)
        {
            int mid = (lo + hi) / 2;
            counter++;
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
                    return GetClosest(array, mid, mid + 1, key);
                }
                else
                {
                    return BinarySearchRecursive(array, mid + 1, hi, key, ref counter);
                }
            }
            else
            {
                if (mid > 0 && array[mid - 1] < key)
                {
                    return GetClosest(array, mid-1, mid, key);
                }
                else
                {
                    return BinarySearchRecursive(array, lo, mid - 1, key, ref counter);
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
        public static void MergeSort(ref int[] array,ref int counter)
        {
            counter++;
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

            MergeSort(ref lefthalf,ref counter);
            MergeSort(ref righthalf,ref counter);
            Merge(lefthalf, righthalf).CopyTo(array, 0);
        }
        public static int[] Merge(int[] aL, int[] aR)
        {
            int[] output = new int[aL.Length + aR.Length];
            int indexL = 0;
            int indexR = 0;
            int outputIndex = 0;
            while (indexL < aL.Length && indexR < aR.Length)
            {
                if (aL[indexL] < aR[indexR])
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
                output[outputIndex] = aL[indexL];
                indexL++;
                outputIndex++;
            }
            while (indexR < aR.Length)
            {
                output[outputIndex] = aR[indexR];
                indexR++;
                outputIndex++;
            }
            return output;
        }
    }
}
