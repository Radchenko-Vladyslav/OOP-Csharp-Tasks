using System.Reflection.Metadata;

namespace Lab1
{
    internal class LB1
    {
        static void Main()
        {
            int a;
            int b;
            int c;

            PosAsp(out a);
            PosAsp(out b);
            PosAsp(out c);

            PosNum(a, b, c);
            if (isTriangel(a, b, c))
            {
                Console.WriteLine("Периметр трикутника: " + Perimeter(a, b, c));

                Area(a, b, c);

                Equilateral(a, b, c);
                IsIsosceles(a, b, c);
                IsRectangular(a, b, c);
                IsScalene(a, b, c);
            }
        }

        public static int PosAsp(out int a)
        {

            bool isValid = true;

            do
            {
                Console.WriteLine("Введіть число:");
                isValid = int.TryParse(Console.ReadLine(), out a) && a > 0;

                if (!isValid)
                {
                    Console.WriteLine("Неправильний вхідний параметр. Введіть правильне ціле число.");
                }
            } while (!isValid);

            Console.WriteLine("Число: " + a);
            return a;
        }

        public static int PosNum(int a, int b, int c)
        {
            if (a > 0 && b > 0 && c > 0)
            {
                Console.WriteLine("Всі числа додатні.");
                return 1;

            }
            else
            {
                Console.WriteLine("Не всі числа додатні.");
                return 0;
            }
        }


        public static bool isTriangel(int a, int b, int c)
        {
            if (a + b > c && a + c > b && b + c > a)
            {
                Console.WriteLine("Трикутник існує");
                return true;
            }
            else
            {
                Console.WriteLine("Трикутник не існує");
                return false;
            }
        }

        public static int Perimeter(int a, int b, int c)
        {
            return a + b + c;
        }

        public static double Area(int a, int b, int c)
        {
            double p = Perimeter(a, b, c) / 2.0;
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            Console.WriteLine("Площа трикутника: " + s);
            return s;
        }

        public static bool Equilateral(int a, int b, int c)
        {
            bool isTrue = (a == b && b == c);
            if (isTrue) Console.WriteLine("Трикутник рівносторонній");
            return isTrue;
        }

        public static bool IsIsosceles(int a, int b, int c)
        {
            bool isTrue = (a == b || b == c || a == c);
            if (isTrue) Console.WriteLine("Трикутник рівнобедрений");
            return isTrue;
        }

        public static bool IsRectangular(int a, int b, int c)
        {
            bool isTrue = (a * a + b * b == c * c || a * a + c * c == b * b || b * b + c * c == a * a);
            if (isTrue) Console.WriteLine("Трикутник прямокутний");
            return isTrue;
        }

        public static bool IsScalene(int a, int b, int c)
        {
            bool isTrue = (a != b && b != c && a != c);
            if (isTrue) Console.WriteLine("Трикутник довільний (різносторонній)");
            return isTrue;
        }
    }
}