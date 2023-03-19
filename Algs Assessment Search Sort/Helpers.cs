using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algs_Assessment_Search_Sort
{
    internal static class Helpers
    {
        //class of functions that perform miscellaneous tasks in my code
        public static int intMenu(string heading, string[] options)//function that constructs a text menu with any number of options from options array
        {
            bool invalidSelection;
            int output = 0;
            string input = "";
            //loop while there is no valid input
            do
            {
                //display heading and iterate to show options
                Console.WriteLine(heading);
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine("{0}: {1}",i+1,options[i]);
                }
                Console.Write(">");
                //take user input
                input = Console.ReadLine() ??string.Empty; //the question mark thing is weird here but it makes the compiler happy
                if (int.TryParse(input, out output)&& output>0 && output <=options.Length)  //if input is an int and in range of the menu
                {
                    invalidSelection = false;//continue
                }
                else
                {
                    //else loop
                    invalidSelection = true;
                    Console.WriteLine("Not a valid option!");
                }
            } while (invalidSelection);

            return output;
        }
        public static int intInput()
        {
            bool validInput = false;
            string userInput;
            int output = -1;
            while (!validInput)
            {
                Console.WriteLine("Input an integer:");
                Console.Write(">");
                userInput = Console.ReadLine();
                if (int.TryParse(userInput, out output))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Input was not an integer!");
                }
            }
            return output;
        }
        public static int[] ReadFile(string path) //reads file full of integers on separate lines into a int[] array
        {
            //read in file as string
            string[] lines = File.ReadAllLines(path);
            //convert to int
            int[] output = new int[lines.Length];
            for (int i=0;i<lines.Length; i++)
            {
                output[i] = int.Parse(lines[i]);
            }

            return output;
        }
        public static bool CheckSorted(in int[] array)//checks to see if array is sorted in ascending order
        {
            //I chose to use only ascending to simplify the logic
            //iterate through the array
            for (int i = 0; i < array.Length-1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    return false; //if sorted ascending no value will be greater than the one after it
                }
            }
            return true;
        }
        //THIS NEEDS CHANGING TO BOOL
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
    }
}
