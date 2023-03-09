namespace Algs_Assessment_Search_Sort
{
    internal class Program
    {
        //Task 1 Read in all files (including task 5 elements too)
        static int[] road1_256 = Helpers.ReadFile("Road_1_256.txt");
        static int[] road1_2048 = Helpers.ReadFile("Road_1_2048.txt");
        static int[] road2_256 = Helpers.ReadFile("Road_2_256.txt");
        static int[] road2_2048 = Helpers.ReadFile("Road_2_2048.txt");
        static int[] road3_256 = Helpers.ReadFile("Road_3_256.txt");
        static int[] road3_2048 = Helpers.ReadFile("Road_3_2048.txt");
        static int[][] roads = { road1_256, road1_2048, road2_256, road2_2048, road3_256, road3_2048 };// array of references to the loaded arrays
        static string[] filenames = { "Road_1_256.txt", "Road_1_2048.txt", "Road_2_256.txt", "Road_2_2048.txt", "Road_3_256.txt", "Road_3_2048.txt" }; //array of source file names
        static void Task2()
        {
            int[] array = roads[Helpers.intMenu("Choose a file to sort and display", filenames)-1];
            Console.WriteLine("Sorting array");

            Algs.Sort(ref array);

            int[] descArray = new int[array.Length];
            array.CopyTo(descArray, 0);
            Array.Reverse(descArray);

            string ascendingout = "";
            string descendingout = "";
            for (int i = 0; i < array.Length; i++)
            {
                if(i %10 == 0)
                {
                    ascendingout += String.Format(" {0} ", array[i]);
                    descendingout += String.Format(" {0} ", descArray[i]);
                }
            }
            Console.WriteLine("Displaying every 10th value:");
            Console.WriteLine("Ascending: "+ascendingout);
            Console.WriteLine("Descending "+descendingout);
        }
        static void Main(string[] args)
        {

            bool exit = false;
            while (!exit)
            {
                string[] menuoptions = { "Task 2 - sort and display every 10th value.", "Exit." };
                switch (Helpers.intMenu("Choose a function:", menuoptions))
                {
                    case 1:
                        Task2();
                        break;
                    case 2:
                        exit = true;
                        continue;
                }
            }
        }
    }
}