using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2
{
    interface IPrint
    {
        void Print();
    }
    //Фигура
    abstract class Figure
    {
        //Автоматически реализуемые свойства
        //поддерживающая переменная создается автоматически
        //Тип фигуры
        public string Type { get; protected set; }

        //Абстрактный метод вычисления площади фигуры
        public abstract double Area();
        //Метод вывода площади фигуры
        public override string ToString()
        {
            return "Площадь фигуры: " + this.Area().ToString();
        }
    }
    //Прямоугольник
    class Rectangle : Figure, IPrint
    {
        //Конструктор
        public Rectangle(double w, double h)
        {
            this.Type = "Прямоугольник";
            this.width = w;
            this.length = h;
        }

        //Длина
        private double _length = 0;
        public double length
        {
            //возвращаемое значение 
            get
            {
                return _length;
            }
            //установка значения, value - ключевое слово 
            set
            {
                _length = value;
            }
        }
        //Ширина
        private double _width = 0;
        public double width
        {
            //возвращаемое значение 
            get
            {
                return _width;
            }
            //установка значения, value - ключевое слово 
            set
            {
                _width = value;
            }
        }
        public override string ToString()
        {
            return this.Type + " со сторонами равными " + this.width + " и "
                + this.length + " и площадью равной " + this.Area();

        }
        public override double Area()
        {
            double Result = this.length * this.width;
            return Result;
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }
    //Квадрат
    class Square : Rectangle, IPrint
    {
        public double size {get; set; }
        public Square(double s) : base(s, s)
        {
            this.Type = "Квадрат";
            this.size = s;
        }
        public override string ToString()
        {
            return this.Type + " со стороной " + this.size + " и площадью " + this.Area();
        }
    }
    //Круг
    class Circle : Figure, IPrint
    {
        private double _radius = 0;
        public double radius
        {
            //возвращаемое значение 
            get
            {
                return _radius;
            }
            //установка значения, value - ключевое слово 
            set
            {
                _radius = value;
            }
        }
        public Circle(double r)
        {
            this.radius = r;
            this.Type = "Круг";
        }
        public override double Area()
        {
            double Result = Math.PI * this.radius * this.radius;
            return Result;
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
        public override string ToString()
        {
            return this.Type + " с радиусом " + this.radius + " и площадью " + this.Area();
        }
    }
    //Основная программа
    class Program
    {
        //Функция меню
        static int Menu()
        {
            Console.Write("!!!Перед вами программа для работы с площадями геометрических фигур!!!\n");
            Console.Write("Выберите интересующую вас фигуру\n");
            Console.Write("================\n");
            Console.Write("1. Прямоугольник\n");
            Console.Write("2. Квадрат\n");
            Console.Write("3. Круг\n");
            Console.Write("4. Выход\n");
            Console.Write("================\n\n");

            int c;
            c = Vvod_int();
            return c;
        }

        //Функция ввода целого числа без ошибок
        static int Vvod_int()
        {
            bool result;
            int c;
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
            return c;
        }

        //Главная функция
        static void Main(string[] args)
        {
            int a;
            int b;
            int P = Menu();
            switch (P)
            {
                case 1:
                    Console.Write("Введите значение сторон прямоугольника (длина, ширина):\n");
                    a = Vvod_int();
                    b = Vvod_int();
                    Rectangle rec1 = new Rectangle(a, b);
                    rec1.Print();
                    break;
                case 2:
                    Console.Write("Введите значение стороны квадрата:\n");
                    a = Vvod_int();
                    Square sq1 = new Square(a);
                    sq1.Print();
                    break;
                case 3:
                    Console.Write("Введите значение радиуса круга:\n");
                    a = Vvod_int();
                    Circle с1 = new Circle(a);
                    с1.Print();
                    break;
                case 4:
                    break;
            }
        Console.WriteLine("Работа программы завершена :)\n");
        Console.Read();
        }
    }
}
