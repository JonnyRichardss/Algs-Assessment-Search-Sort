namespace Algs_Assessment_Search_Sort
{
    internal class Program
    {
        static string[] filenames_256 = {"Road_1_256.txt", "Road_2_256.txt", "Road_3_256.txt"}; //array of source file names
        static string[] filenames_2048 = {"Road_1_2048.txt", "Road_2_2048.txt", "Road_3_2048.txt"};
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
            Console.WriteLine("Arrays were already imported at program start!");
        }
        static void Task2()
        {
            int index = Helpers.intMenu("Choose a file to sort and display:", filenames_256);
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
            int index = Helpers.intMenu("Choose a file to search:", filenames_256);
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
            int index = Helpers.intMenu("Choose a file to search:", filenames_256);
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
            Console.WriteLine("Arrays were already imported at program start!");
            int index = Helpers.intMenu("Choose a file:", filenames_2048);
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
            int[] mergedarray = Tasks.Merging(road1_256, road3_256);
            Tasks.Sorting(ref mergedarray);
            Tasks.Searching(ref mergedarray, true);
            Tasks.Searching(ref mergedarray, false);
        }
        static void Task7() 
        {
            int[] mergedarray = Tasks.Merging(road1_2048, road3_2048);
            Tasks.Sorting(ref mergedarray);
            Tasks.Searching(ref mergedarray, true);
            Tasks.Searching(ref mergedarray, false);
        }
        static void Main(string[] args)
        {
            bool exit = false;
            int[] testArray = {0,0,0,0,4,4,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23};
            Tasks.Searching(ref testArray, false);
            while (!exit)
            {
                string[] menuoptions = 
                {
                    "Task 1 - Import 256 length arrays", 
                    "Task 2 - Sort and display digits at interval",
                    "Task 3 - Search for a value in a list (error if not found)",
                    "Task 4 - Search for a value in a list (nearest values if not found)",
                    "Task 5 - Repeat tasks 1-4 with 2048 Length arrays",
                    "Task 6 - Merge arrays and repeat tasks 2-4 on merged arrays",
                    "Task 7 - Repeat task 6 with 2048 Length arrays",
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
                        exit = true;
                        break;
                }
            }
        }
    }
}