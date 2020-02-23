using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

struct Complex
{
    private double im;
    private double re;

    //Конструктор
    public Complex(double im = 0, double re = 0) 
    {
        this.im = im;
        this.re = re;
    }

    // Свойства применены в учебных целях никаких практических целей не преследуют
    public double imaginary
    {
        get {
            return im;
        }
        set {
            im = value;
        }
    }

    public double real
    {
        get {
            return re;
        }
        set {
            re = value;
        }
    }

    //  Сложение двух комплексных чисел
    public Complex Plus(Complex b)
    {
        Complex a = new Complex();
        a.imaginary = b.imaginary + this.imaginary;
        a.real = b.real + this.real;

        return a;
    }

    //  Вычитание двух комплексных чисел
    public Complex Minus(Complex b)
    {
        Complex a = new Complex();
        a.imaginary = b.imaginary - this.imaginary;
        a.real = b.real - this.real;

        return a;
    }

    //  Произведение двух комплексных чисел
    public Complex Multiplication(Complex b)
    {
        Complex a = new Complex();
        a.imaginary = real * b.imaginary + imaginary * b.real;
        a.real = real * b.real - imaginary * b.imaginary;

        return a;
    }

    // Метод вывода результата расчетов
    public string ToString()
    {
        return re + "+" + im + "i";
    }
}
class Program
{
    public enum Operation 
    {
        minus = 1,
        plus,
        multiplication
    };

    static void Main()
    {
        int action;
        string text;

        Complex complex1 = new Complex();
        complex1.real = 1;
        complex1.imaginary = 1;

        Complex complex2 = new Complex();
        complex2.real = 2;
        complex2.imaginary = 2;

        Complex result = complex1.Plus(complex2);
        Complex result2 = complex1.Minus(complex2);
        Complex result3 = complex1.Multiplication(complex2);

        Console.WriteLine("Введите номер действия для комплексных чисел: 1 сложение, 2 вычитание, 3 умножение");

        do
        {
            text = Console.ReadLine();

            if (Regex.IsMatch(text, @"1|2|3")) 
            {
                action = Int32.Parse(text);
                break;
            }
            else {
                Console.WriteLine("Введите номер действия для комплексных чисел: 1 сложение, 2 вычитание, 3 умножение");
            }
        }
        while (true);

        switch(action) 
        {
            case (int)Operation.minus:
                Console.WriteLine(result.ToString());
                break;
            case (int)Operation.plus:
                Console.WriteLine(result2.ToString());
                break;
            case (int)Operation.multiplication:
                Console.WriteLine(result3.ToString());
                break;
        }
        
        Console.ReadKey();
    }
}