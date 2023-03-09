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
        public static int Search(in int[] array,int key) 
        {
            return Array.IndexOf(array,key); //temp to test things
        }
        public static void Sort(ref int[] array)
        {
            Array.Sort(array); //temp to test things
        }
    }
}
