namespace PZ1
{
    internal class Program
    {
        static void Main()
        {
            int[][] grades = 
            { 
                new int[] { 90, 85, 78, 92, 88, 76, 95, 81, 87, 90 }, 
                new int[] { 75, 80, 91, 68, 85, 79, 88, 93, 77, 82, 90, 86 }, 
                new int[] { 95, 87, 90, 100, 84, 91, 78, 89, 93, 96, 85, 88, 92, 80, 97 } 
            }; 
           
            PrintResults(grades);
        }
        public static void PrintResults(int[][] grades)
        {
            for (int i = 0; i < grades.Length; i++)
            {
                Console.WriteLine($"Група {i + 1}:");
                Console.WriteLine($"Середній бал: {GetAverage(grades[i]):F2}");
                Console.WriteLine($"Мінімальна оцінка: {GetMin(grades[i])}");
                Console.WriteLine($"Максимальна оцінка: {GetMax(grades[i])}");
                Console.WriteLine();
            }

            Console.WriteLine("Результат для всього потоку:");
            Console.WriteLine($"Середній бал: {GetStreamAverage(grades):F2}");
            Console.WriteLine($"Мінімальна оцінка: {GetStreamMin(grades)}");
            Console.WriteLine($"Максимальна оцінка: {GetStreamMax(grades)}");
        }
        public static double GetAverage(int[] group)
        {
            int sum = 0;

            for (int i = 0; i < group.Length; i++)
            {
                sum += group[i];
            }

            return (double)sum / group.Length;
        }
        public static int GetMin(int[] group)
        {
            int min = group[0];

            for (int i = 1; i < group.Length; i++)
            {
                if (group[i] < min)
                {
                    min = group[i];
                }
            }
            return min;
        }
        public static int GetMax(int[] group)
        {
            int max = group[0];

            for (int i = 1; i < group.Length; i++)
            {
                if (group[i] > max)
                {
                    max = group[i];
                }
            }
            return max;
        }
        public static double GetStreamAverage(int[][] grades)
        {
            int sum = 0;
            int count = 0;

            for (int i = 0; i < grades.Length; i++)
            {
                for (int j = 0; j < grades[i].Length; j++)
                {
                    sum += grades[i][j];
                    count++;
                }
            }
            return (double)sum / count;
        }
        public static int GetStreamMin(int[][] grades)
        {
            int min = grades[0][0];

            for (int i = 0; i < grades.Length; i++)
            {
                for (int j = 0; j < grades[i].Length; j++)
                {
                    if (grades[i][j] < min)
                    {
                        min = grades[i][j];
                    }
                }
            }
            return min;
        }
        public static int GetStreamMax(int[][] grades)
        {
            int max = grades[0][0];

            for (int i = 0; i < grades.Length; i++)
            {
                for (int j = 0; j < grades[i].Length; j++)
                {
                    if (grades[i][j] > max)
                    {
                        max = grades[i][j];
                    }
                }
            }
            return max;
        }
    }
}
