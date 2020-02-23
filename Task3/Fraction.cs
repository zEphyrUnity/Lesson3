using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task3
{
    class Fraction
    {
        private int num;
        private int den;

        //Свойство доступа для числителя
        int numerator 
        {
            get => num;
            set 
            {
                num = value;
            }
        }
        //Свойство доступа для знаменателя
        int denominator
        {
            get => den;
            set 
            {
                try
                {
                    ZeroCheck(value);
                    den = value;
                }
                catch (ArgumentException error)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("{0}: {1}", error.GetType().Name, error.Message);
                    Environment.Exit(0);
                }
            }
        }

        //Свойство типа double, только чтение, получить десятичную дробь
        double decFraction
        {
            get => (double)numerator / denominator;
        }

        //Конструктор
        public Fraction(int num = 1, int den = 1)
        {
            numerator = num;
            denominator = den;
        }

        //Метод сложения дробей
        public Fraction Plus(Fraction frac2) 
        {
            Fraction result = new Fraction();

            result.numerator = (this.numerator * frac2.denominator) + (frac2.numerator * this.denominator);
            result.denominator = this.denominator * frac2.denominator;

            result.Simplify();
            Console.Write("Результат сложения: ");
            Console.WriteLine(result.ToString());

            return result;
        }

        //Метод вычитания дробей
        public Fraction Minus(Fraction frac2)
        {
            Fraction result = new Fraction();

            result.numerator = (this.numerator * frac2.denominator) - (frac2.numerator * this.denominator);
            result.denominator = this.denominator * frac2.denominator;

            result.Simplify();

            if (result.numerator == 0)
            {
                Console.Write("Результат вычитания: ");
                Console.WriteLine(0);
            }
            else 
            {
                Console.Write("Результат вычитания: ");
                Console.WriteLine(result.ToString());
            }

            return result;
        }

        //Метод умножения дробей
        public Fraction Multiplication(Fraction frac2)
        {
            Fraction result = new Fraction();

            result.numerator = this.numerator *  frac2.numerator;
            result.denominator = this.denominator * frac2.denominator;

            result.Simplify();
            Console.Write("Результат умножения: ");
            Console.WriteLine(result.ToString());

            return result;
        }


        //Метод деления дробей
        public Fraction Dividing(Fraction frac2)
        {
            Fraction result = new Fraction();

            result.numerator = this.numerator * frac2.denominator;
            result.denominator = this.denominator * frac2.numerator;

            result.Simplify();
            Console.Write("Результат деления: ");
            Console.WriteLine(result.ToString());

            return result;
        }

        // Метод вывода результата расчетов
        public string ToString() 
        {
            return numerator + " / " + denominator;
        }

        //Метод проверки нулевого значения знаменателя и создания исключения ArgumentException
        public void ZeroCheck(int value)
        {
            if (value == 0)
                throw new ArgumentException("Знаменатель не может быть равен 0");
        }

        //Метод упрощения дроби
        public void Simplify() 
        {
            for (int i = 10; i > 1; i--)
                if (numerator % i == 0 && denominator % i == 0) 
                {
                    numerator /= i;
                    denominator /= i;
                }
        }

        static void Main()
        {
            Fraction frac1 = new Fraction(1, 2);
            Fraction frac2 = new Fraction(2, 3);
            
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"Дробь 1: {frac1.ToString()}");
            Console.WriteLine("{0:f2}", frac1.decFraction);

            Console.WriteLine($"Дробь 2: {frac2.ToString()}");
            Console.WriteLine("{0:f2}", frac2.decFraction);
            Console.WriteLine();

            //Сложение дробей
            frac1.Plus(frac2);

            //Вычитание дробей
            frac1.Minus(frac2);

            //Умножение дробей
            frac1.Multiplication(frac2);

            //Деление дробей
            frac1.Dividing(frac2);

            Console.ReadKey();
        }
    }
}