using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task2
{
    class Task2
    {
        //Метод подсчета суммы всех нечетных положительных чисел, пока не будет введен 0.
        public static void PositiveOddSum()
        {
            string text;
            int num = 0;
            int sum = 0;

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Введите числа, когда будет введен 0, вы получите сумму всех нечетных чисел.");
            Console.ForegroundColor = ConsoleColor.Red;

            do
            {
                text = Console.ReadLine();
                //Проверка введеных данных
                if (Regex.IsMatch(text, @"[0-9]"))
                    Int32.TryParse(text, out num);

                //Прибавить число, если оно больше нуля и нечетное
                if ((num > 0) && (num % 2 != 0))
                    sum += num;

                //Если число равно нулю закончить ввод чисел
                if (num == 0)
                    break;
            }
            while (true);

            Console.WriteLine(sum);
        }

        static void Main()
        {
            //Вызов метода подсчета суммы всех нечетных положительных чисел, пока не будет введен 0.
            PositiveOddSum();

            Console.ReadKey();
        }
    }
}
