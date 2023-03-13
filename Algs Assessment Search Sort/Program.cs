namespace Algs_Assessment_Search_Sort
{
    internal class Program
    {

        static int[] road1_256, road2_256, road3_256;
        static int[] road1_2048, road2_2048, road3_2048;
        static int[][] roads_256 = { road1_256, road2_256, road3_256};// array of references to the loaded arrays
        static int[][] roads_2048 = {road1_2048, road2_2048, road3_2048};
        static string[] filenames_256 = { "Road_1_256.txt",  "Road_2_256.txt",  "Road_3_256.txt", }; //array of source file names
        static string[] filenames_2048 = { "Road_1_2048.txt", "Road_2_2048.txt", "Road_3_2048.txt" };
        static void Task1()
        {
            //Task 1 Read in all 256 length file
            for (int i = 0; i < roads_256.Length; i++)
            {
                roads_256[i] = Helpers.ReadFile(filenames_256[i]);
            }
        }
        static void Task2()
        {
            int[] array = roads_256[Helpers.intMenu("Choose a file to sort and display", filenames_256)-1];
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
        static void Task3()
        {

        }
        static void Task4()
        {

        }
        static void Task5()
        {
            //Task 5 Read in all 2048 length file
            for (int i = 0; i < roads_2048.Length; i++)
            {
                roads_2048[i] = Helpers.ReadFile(filenames_2048[i]);
            }
        }
        static void Task6()
        {

        }
        static void Task7() 
        { 

        }

        static void Main(string[] args)
        {
            Task1();
            Task5();
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