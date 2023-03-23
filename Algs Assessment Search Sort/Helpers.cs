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
        public static int intMenu(string heading, string[] options)
        {
            //function that constructs a text menu with any number of options from options array
            //returns an int that is guaranteed to be in the range of the options given
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

            return output;//once valid and in range, return the int
        }
        public static int intInput()
        {
            //function that takes and validates a simple integer input
            //returns the integer the user inputted
            bool validInput = false;
            string userInput;
            int output = -1;
            while (!validInput)
            {
                //take input
                Console.Write(">");
                userInput = Console.ReadLine() ?? string.Empty; //again the weird question mark thing to shut the compiler up
                if (int.TryParse(userInput, out output))
                {
                    validInput = true;//if the input is valid continue
                }
                else
                {
                    Console.WriteLine("Input was not an integer!"); //else loop
                }
            }
            return output;//finally return the integer
        }
        public static int[] ReadFile(string path)
        {
            //function that reads file full of integers on separate lines into a int[] array

            //read in file as strings
            string[] lines = File.ReadAllLines(path);
            //convert to int
            int[] output = new int[lines.Length];
            for (int i=0;i<lines.Length; i++)
            {
                output[i] = int.Parse(lines[i]); //this has no error checking but as it is, the files are hard-coded so it shouldn't matter
            }

            return output;//return final array
        }
        public static List<int[]> ReadMultiFiles(string[] paths)
        {
            //function that simply calls readfile multiple times and returns it as a 2d list
            List<int[]> output = new List<int[]>();
            foreach (string path in paths)
            {
                output.Add(ReadFile(path));
            }
            return output;
        }
        public static string FormatSteps(List<int> results)
        {
            //formatting function to ensure correct spacing on steps vs n table
            //gves every int int the input its own 10-character space to be put in
            string output = "";
            int targetlen = 10;
            foreach(int i in results) //for every int
            {
                int ilen = i.ToString().Length;//get its # of digits
                int remaininglen = targetlen - ilen; //calculate amount of white space needed

                //construct the white space
                string left = new string(' ', remaininglen/2)+" ";
                string right = new string(' ', remaininglen - (left.Length-1))+"|";

                output = output + left+i+right;//add it all to the output
            }
            return output;//finally return the line as a single string
        }
    }
}
