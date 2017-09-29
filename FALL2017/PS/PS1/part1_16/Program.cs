using System;

namespace part1_16
{
    class Program
    {
        static void Main(string[] args)
        {
            //Решение задачи №16 из 1 части
           
            Console.WriteLine("Введите номер билета");
            int number = int.Parse(Console.ReadLine());
            int firstSum = 0, secondSum = 0;
            double firstPartOfNumber = 0, secondPartOfNumber = 0;
            for (int i = 0; number > 0; i++)
            {
                int lastNumber = number % 10;
                number /= 10;
                if (i < 3)
                    secondSum += lastNumber;
                else
                    firstSum += lastNumber;
                if (i < 3) // Использую double и деление, чтобы потом не разворачивать число, а просто умножить на 100 и взять целую часть
                    secondPartOfNumber = secondPartOfNumber / 10 + lastNumber;
                else
                    firstPartOfNumber = firstPartOfNumber / 10 + lastNumber;
            }
            int firstPart = (int)(firstPartOfNumber * 100);
            int secondPart = (int)(secondPartOfNumber * 100);
            if (Math.Abs(firstSum - secondSum) == 1 || Math.Abs(firstPart - secondPart) == 1)
                Console.WriteLine("Является");
            else
                Console.WriteLine("Не является");
            
        }
    }
}
