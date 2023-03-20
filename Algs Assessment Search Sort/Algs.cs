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
        public static void MergeSort(ref int[] array)
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

            MergeSort(ref lefthalf);
            MergeSort(ref righthalf);
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
        //PLS PLS PLS REMEMBER TO AT LEAST COMMENT THESE OUT BEFORE YOU SUMBIT OMG
        // /*
        public static int TempSearch(in int[] array, int key)
        {
            return Array.IndexOf(array, key); //temp to test things
        }
        public static void TempSort(ref int[] array)
        {
            Array.Sort(array); //temp to test things
        }
        // */
    }
}
