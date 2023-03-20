namespace Algs_Assessment_Search_Sort
{
    internal class Program
    {
        static string[] filenames = { "Road_1_256.txt", "Road_2_256.txt", "Road_3_256.txt", "Road_1_2048.txt", "Road_2_2048.txt", "Road_3_2048.txt" }; //array of source file names
        //TASK 1 - Import 256 Length Files
        static int[] road1_256 = Helpers.ReadFile(filenames[0]);
        static int[] road2_256 = Helpers.ReadFile(filenames[1]);
        static int[] road3_256 = Helpers.ReadFile(filenames[2]);
        //TASK 5 - Import 2048 Length Files
        static int[] road1_2048 = Helpers.ReadFile(filenames[3]);
        static int[] road2_2048 = Helpers.ReadFile(filenames[4]);
        static int[] road3_2048 = Helpers.ReadFile(filenames[5]);

        static void Task2()
        {
            int index = Helpers.intMenu("Choose a file to sort and display:", filenames);
            int[] array;
            switch (index)
            {
                case 1:
                    array = road1_256;
                    break;
                case 2:
                    array = road2_256;
                    break;
                case 3:
                    array = road3_256;
                    break;
                case 4:
                    array = road1_2048;
                    break;
                case 5:
                    array = road2_2048;
                    break;
                case 6:
                    array = road3_2048;
                    break;
                default:
                    //this stops the compiler whining at me it *shouldn't* ever run thanks to error checking in intMenu()
                    array = new int[0];
                    break;
            }

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
            Algs.MergeSort(ref array);
            
            //this needs changing
            int[] descArray = new int[array.Length];
            array.CopyTo(descArray, 0);
            Array.Reverse(descArray);

            string ascendingout = "";
            string descendingout = "";

            for (int i = 0; i < array.Length; i++)
            {
                if(i %displayInterval == 0)
                {
                    ascendingout += String.Format(" {0} ", array[i]);
                    descendingout += String.Format(" {0} ", descArray[i]);
                }
            }
            Console.WriteLine("Displaying every {0}th value:",displayInterval);
            //These are hacked together like this in case I want to add ConsoleColor
            Console.Write("Ascending: "); Console.WriteLine(ascendingout);
            Console.Write("Descending: "); Console.WriteLine(descendingout);

        }
        
        static void Task3()
        {
            int index = Helpers.intMenu("Choose a file to search:", filenames);
            int[] array;
            switch (index)
            {
                case 1:
                    array = road1_256;
                    break;
                case 2:
                    array = road2_256;
                    break;
                case 3:
                    array = road3_256;
                    break;
                case 4:
                    array = road1_2048;
                    break;
                case 5:
                    array = road2_2048;
                    break;
                case 6:
                    array = road3_2048;
                    break;
                default:
                    //this stops the compiler whining at me it *shouldn't* ever run thanks to error checking in intMenu()
                    array = new int[0];
                    break;
            }
            Console.WriteLine("Checking if array is sorted...");
            if (!Helpers.CheckSorted(array))
            {
                Console.WriteLine("Array not sorted! Sorting array...");
                Algs.MergeSort(ref array);
            }
            Console.Write("Proceeding to search! ");
            int searchInput = Helpers.intInput();
            int foundIndex = Algs.TempSearch(array, searchInput);
            if (foundIndex > 0)
            {
                List<int> foundList = new List<int>();
                Helpers.AddEqualNeighbours(ref foundList, array, foundIndex);
                Console.WriteLine("Found {0} at the following positions:",searchInput);
                foreach (int i in foundList)
                {
                    Console.WriteLine(i);
                }
            }
            else
            {
                Console.WriteLine("Input not found!");
            }
        }
        
        static void Task4()
        {

        }
        static void Task6()
        {

        }
        static void Task7() 
        { 

        }

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                string[] menuoptions = { "Task 2 - sort and display digits at interval.","Task 3 - search for a value in a list.", "Exit." };
                switch (Helpers.intMenu("Choose a function:", menuoptions))
                {
                    case 1:
                        Task2();
                        break;
                    case 2:
                        Task3();
                        break;
                    case 3:
                        exit = true;
                        continue;
                }
            }
        }
    }
}