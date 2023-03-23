namespace Algs_Assessment_Search_Sort
{
    internal class Program
    {
        static string[] filenames_256 = {"Road_1_256.txt", "Road_2_256.txt", "Road_3_256.txt"}; //array of source file names
        static string[] filenames_2048 = {"Road_1_2048.txt", "Road_2_2048.txt", "Road_3_2048.txt"};
        static string[] allfilenames = { "Road_1_256.txt", "Road_2_256.txt", "Road_3_256.txt", "Road_1_2048.txt", "Road_2_2048.txt", "Road_3_2048.txt" };
        //TASK 1 - Import 256 Length Files
        static int[] road1_256 = Helpers.ReadFile(filenames_256[0]);
        static int[] road2_256 = Helpers.ReadFile(filenames_256[1]);
        static int[] road3_256 = Helpers.ReadFile(filenames_256[2]);
        //TASK 5 - Import 2048 Length Files
        static int[] road1_2048 = Helpers.ReadFile(filenames_2048[0]);
        static int[] road2_2048 = Helpers.ReadFile(filenames_2048[1]);
        static int[] road3_2048 = Helpers.ReadFile(filenames_2048[2]);
        
        static void Task1()
        {
            Console.WriteLine("Task 1 - Re-Importing arrays!");
            road1_256 = Helpers.ReadFile(filenames_256[0]);
            road2_256 = Helpers.ReadFile(filenames_256[1]);
            road3_256 = Helpers.ReadFile(filenames_256[2]);
            road1_2048 = Helpers.ReadFile(filenames_2048[0]);
            road2_2048 = Helpers.ReadFile(filenames_2048[1]);
            road3_2048 = Helpers.ReadFile(filenames_2048[2]);
        }
        static void Task2()
        {
            int index = Helpers.intMenu("Task 2 - Choose a file to sort and display:", filenames_256);
            switch (index)
            {
                case 1:
                    Tasks.Sorting(ref road1_256);
                    break;
                case 2:
                    Tasks.Sorting(ref road2_256);
                    break;
                case 3:
                    Tasks.Sorting(ref road3_256);
                    break;
            }
        }
        static void Task3()
        {
            int index = Helpers.intMenu("Task 3 - Choose a file to search:", filenames_256);
            switch (index)
            {
                case 1:
                    Tasks.Searching(ref road1_256,true);
                    break;
                case 2:
                    Tasks.Searching(ref road2_256,true);
                    break;
                case 3:
                    Tasks.Searching(ref road3_256,true);
                    break;
            }

        }
        static void Task4()
        {
            int index = Helpers.intMenu("Task 4 - Choose a file to search:", filenames_256);
            switch (index)
            {
                case 1:
                    Tasks.Searching(ref road1_256, false);
                    break;
                case 2:
                    Tasks.Searching(ref road2_256, false);
                    break;
                case 3:
                    Tasks.Searching(ref road3_256, false);
                    break;
            }
        }
        static void Task5()
        {
            Task1();
            int index = Helpers.intMenu("Task 5 - Choose a file:", filenames_2048);
            switch (index)
            {
                case 1:
                    Tasks.Sorting(ref road1_2048);
                    Tasks.Searching(ref road1_2048, true);
                    Tasks.Searching(ref road1_2048, false);
                    break;
                case 2:
                    Tasks.Sorting(ref road2_2048);
                    Tasks.Searching(ref road2_2048, true);
                    Tasks.Searching(ref road2_2048, false);
                    break;
                case 3:
                    Tasks.Sorting(ref road3_2048);
                    Tasks.Searching(ref road3_2048, true);
                    Tasks.Searching(ref road3_2048, false);
                    break;
            }
        }
        static void Task6()
        {
            Console.WriteLine("Task 6 - Merging road1_256 and road3_256");
            int[] mergedarray = Tasks.Merging(road1_256, road3_256,false);
            Tasks.Sorting(ref mergedarray);
            Tasks.Searching(ref mergedarray, true);
            Tasks.Searching(ref mergedarray, false);
        }
        static void Task7() 
        {
            Console.WriteLine("Task 7 - Merging road1_2048 and road3_2048");
            int[] mergedarray = Tasks.Merging(road1_2048, road3_2048,false);
            Tasks.Sorting(ref mergedarray);
            Tasks.Searching(ref mergedarray, true);
            Tasks.Searching(ref mergedarray, false);
        }
        static void PrintAllSteps()
        {
            List<int[]> allarrays = Helpers.ReadMultiFiles(allfilenames);
            allarrays.Add(Tasks.Merging(road1_256, road3_256, true));
            allarrays.Add(Tasks.Merging(road1_2048, road3_2048, true));
            int[][] arraysCopy = new int[allarrays.Count][];
            Console.WriteLine("    N=    |    256    |    256    |    256    |    2048   |    2048   |    2048   |    512    |    4096   |");
            Console.WriteLine("Algorithm |Road_1_256 |Road_2_256 |Road_3_256 |Road_1_2048|Road_2_2048|Road_3_2048|256 Merged |2048 Merged|");
            
            
            for (int a = 1; a < 5; a++)
            {
                Algs.currentAlg = (SortingAlgs)a;
                allarrays.CopyTo(arraysCopy);
                List<int> results = new List<int>();
                for (int i = 0; i < arraysCopy.Length; i++)
                {
                    int counter = 0;
                    Algs.Sort(ref arraysCopy[i], false, ref counter);
                    results.Add(counter);
                }
                Console.WriteLine("{0,-10}|{1}", Algs.currentAlg, Helpers.FormatSteps(results));
            }
            List<int> binResults = new List<int>();
            List<int> seqResults = new List<int>();
            foreach (int[] array in arraysCopy) 
            {
                int binCounter = 0;
                int seqCounter = 0;
                Algs.BinarySearch(array, 0, array.Length, 55, ref binCounter);
                Algs.SequentialSearch(array,55,ref seqCounter);
                binResults.Add(binCounter);
                seqResults.Add(seqCounter);
            }
            Console.WriteLine("Binary    |{0}", Helpers.FormatSteps(binResults));
            Console.WriteLine("Sequential|{0}", Helpers.FormatSteps(seqResults));
        }
        static void Main(string[] args)
        {
            foreach(string s in allfilenames)
            {
                Console.Write("|{0}", s.Split(".")[0]);
            }
            Console.WriteLine();
            bool exit = false;
            while (!exit)
            {
                string[] menuoptions =
                {
                    "Task 1 - Import 256 length arrays (also re-imports all arrays)",
                    "Task 2 - Sort and display digits at interval",
                    "Task 3 - Search for a value in a list (error if not found)",
                    "Task 4 - Search for a value in a list (nearest values if not found)",
                    "Task 5 - Repeat tasks 1-4 with 2048 Length arrays",
                    "Task 6 - Merge arrays and repeat tasks 2-4 on merged arrays",
                    "Task 7 - Repeat task 6 with 2048 Length arrays",
                    "Extra - Change sorting algorithm",
                    "Extra - Ouput all steps vs n",
                    "Exit."
                };
                switch (Helpers.intMenu("Choose a function:", menuoptions))
                {
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        Task3();
                        break;
                    case 4:
                        Task4();
                        break;
                    case 5:
                        Task5();
                        break;
                    case 6:
                        Task6();
                        break;
                    case 7:
                        Task7();
                        break;
                    case 8:
                        Algs.currentAlg = (SortingAlgs)Helpers.intMenu("Choose sorting algoithm to use",Algs.algNames);
                        break;
                    case 9:
                        PrintAllSteps();
                        break;
                    case 10:
                        exit = true;
                        break;
                }
            }
        }
    }
}