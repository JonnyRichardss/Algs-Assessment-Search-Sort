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
        public static int BinarySearch(in int[] array,int key)
        {
            //iterative implementation chosen because i like the arguments better :)
            int lo = 0;
            int hi = array.Length-1;
            int mid = (hi + lo)/2;
            while(lo < hi)
            {
                if (array[mid] == key)
                {
                    return mid;
                }

                if (array[mid] < key)
                {
                    lo = mid + 1;
                }
                else if (array[mid] > key)
                {
                    hi = mid - 1;
                }
                mid = (hi + lo)/2;
            }
            return -mid;
        }
        public static void MergeSort(ref int[] array,ref int steps)
        {
            steps++;
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

            MergeSort(ref lefthalf,ref steps);
            MergeSort(ref righthalf,ref steps);
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
