using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Введите, пожалуйста, коэффициенты квадратного уравнения вида A*x^2+B*x+C=0");
            int a;
            int b;
            int c;
            bool result;
            Console.Write("A = ");
            do
            {
                result = int.TryParse(Console.ReadLine(), out a);
                if (result)
                {
                    break;
                }
                else
                {
                    Console.Write("Вы ввели не число! Пожалуйста, повторите ввод: ");
                }
            } while (true);
            Console.Write("B = ");
            do
            {
                result = int.TryParse(Console.ReadLine(), out b);
                if (result)
                {
                    break;
                }
                else
                {
                    Console.Write("Вы ввели не число! Пожалуйста, повторите ввод: ");
                }
            } while (true);
            Console.Write("C = ");
            do
            {
                result = int.TryParse(Console.ReadLine(), out c);
                if (result)
                {
                    break;
                }
                else
                {
                    Console.Write("Вы ввели не число! Пожалуйста, повторите ввод: ");
                }
            } while (true);
            Console.Write("Ввод коэффициентов проведён успешно!\nДля продолжения программы нажмите любую клавишу...");
            Console.ReadLine();

            double db;
            double dc;
            if (a == 0)
            {
                if (b == 0)
                {
                    if (c == 0)
                    {
                        Console.WriteLine("У данного уравнения бесконечно много корней ;)");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("У данного уравнения нет действительных корней :(");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Корень х данного уравнения равен {0}", -c / b);
                }
            }
            else
            {
                db = b / a;
                dc = c / a;
                double dis = db * db - 4 * dc;
                if (dis < 0)
                {
                    Console.WriteLine("У данного уравнения нет действительных корней :(");
                    Console.ReadLine();
                }
                else
                {
                    if (dis == 0)
                    {
                        Console.WriteLine("Корень х данного уравнения равен {0}", -db / 2);
                    }
                    else
                    {
                        Console.WriteLine("Корни х1 и х2 данного уравнения равны: ({0}) и ({1})\n", (-db + Math.Sqrt(dis)) / 2, (-db - Math.Sqrt(dis)) / 2);
                    }
                }
            }
            Console.WriteLine("Работа программы завершена :)\nДля выхода нажмите любую клавишу...");
            Console.Read();
        }
    }
}
