using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CSharp07._06
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static Point operator ++(Point p)
        {
            p.X++;
            p.Y++;
            return p;
        }
        public static Point operator --(Point p)
        {
            p.X--;
            p.Y--;
            return p;
        }
        public static Point operator -(Point p)
        {
            return new Point { X = -p.X, Y = -p.Y };
        }
        public static Point operator - (Point p1, int x)
        {
            p1.X -= x;
            p1.Y -= x;
            return p1;
        }
        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Equals(p2);
        }
        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1 == p2);
        }
        public static bool operator>(Point p1, Point p2)
        {
            return Math.Sqrt(p1.X * p1.X + p1.Y * p1.Y) >
                Math.Sqrt(p2.X * p2.X + p2.Y * p2.Y);
        }
        public static bool operator <(Point p1, Point p2)
        {
            return Math.Sqrt(p1.X * p1.X + p1.Y * p1.Y) <
                Math.Sqrt(p2.X * p2.X + p2.Y * p2.Y);
        }
        public static bool operator true(Point p)
        {
            return p.X != 0 || p.Y != 0 ? true : false;
        }
        public static bool operator false(Point p)
        {
            return p.X != 0 && p.Y != 0 ? true : false;
        }

        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public override string ToString()
        {
            return $"Point: X = {X}, Y = {Y}\n";
        }
    }
    class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Vector() { }
        public Vector(Point begin, Point end)
        {
            X = end.X - begin.X;
            Y = end.Y - begin.Y;
        }
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector { X = v1.X + v2.X, Y = v1.Y + v2.Y };
        }
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector { X = v1.X - v2.X, Y = v1.Y - v2.Y };
        }
        public static Vector operator *(Vector v, int n)
        {
            v.X *= n;
            v.Y *= n;
            return v;
        }
        public static Vector operator*(int n, Vector v)
        {
            return v * n;
        }
        public override string ToString()
        {
            return $"Vector: X = {X}, Y = {Y}\n";
        }
    }

    class CPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    struct SPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class Human
    {
        int _id;
        protected string firstName;
        protected string lastName;
        public Human(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public void Print()
        {
            Console.WriteLine($"first name: {firstName}, last name: {lastName}");
        }
    }
    sealed class Employee: Human
    {
        double _salary;
        new string firstName;
        public Employee(string fName, string lName, double salsry) : base(fName, lName)
        {
            _salary= salsry; 
        }
        public new void Print()
        {
            base.Print();
            Console.WriteLine($"Salary = {_salary}");
        }
    }
    class Builder : Human
    {
        double _salary;
        public Builder(string fname, string lName, double salary) : base(fname, lName)
        {
            _salary = salary;
        }
        public void PrintBuilder()
        {
            Print();
            Console.WriteLine($"Строитель Зарплата{_salary}");
        }
    }
    class Sailor : Human
    {
        double _salary;
        public Sailor(string fname, string lName, double salary) : base(fname, lName)
        {
            _salary = salary;
        }
        public void PrintSailor()
        {
            Print();
            Console.WriteLine($"Моряк Зарплата{_salary}");
        }
    }
    class Pilot : Human
    {
        double _salary;
        public Pilot(string fname, string lName, double salary) : base(fname, lName)
        {
            _salary = salary;
        }
        public void PrintPilot()
        {
            Print();
            Console.WriteLine($"Летчик\nЗарплата {_salary}");
        }
    }
    /*
    Создайте класс Human, который будет содержать
    информацию о человеке.
    С помощью механизма наследования, реализуйте класс
    Builder (содержит информацию о строителе), класс Sailor
    (содержит информацию о моряке), класс Pilot (содержит
    информацию о летчике).
    Каждый из классов должен содержать необходимые
    для работы методы.
    */

    internal class Program
    {
        //public  static тип_возврата operator символ_операции(параметры) { }


        static void Main(string[] args)
        {
            /*Point point = new Point { X = 10, Y = 10 };
            Console.WriteLine(point);
            Console.WriteLine(point++);
            Console.WriteLine(++point);
            Console.WriteLine(--point);
            Console.WriteLine(point--);
            Console.WriteLine(point);
            int a = 10;
            Console.WriteLine(a);
            Console.WriteLine(a++);
            Console.WriteLine(++a);
            Console.WriteLine(--a);
            Console.WriteLine(a--);
            Console.WriteLine(a);*/

            /*Point p1 = new Point { X= 2, Y = 3 };
            Point p2 = new Point { X = 3, Y = 1 };

            Vector v1 = new Vector(p1, p2);
            Vector v2 = new Vector { X= 2, Y= 3 };

            Console.WriteLine(v1 + " " + v2);
            Console.WriteLine(v1 + v2);
            Console.WriteLine(v1 - v2);
            int n = 6;
            v1 *= n;
            v1 = v1 * n;
            v1 = n * v1;
            Console.WriteLine(v1 + " " + v2);*/

            /*CPoint cp = new CPoint { X = 10, Y = 10};
            CPoint cp1 = new CPoint { X = 10, Y = 10};
            CPoint cp2 = cp1;

            Console.WriteLine($"ReferenceEquals(cp, cp1) = {ReferenceEquals(cp, cp1)}");
            Console.WriteLine($"ReferenceEquals(cp1, cp2) = {ReferenceEquals(cp1, cp2)}");

            SPoint sp = new SPoint { X = 10, Y = 10 };
            SPoint sp1 = new SPoint { X = 10, Y = 10 };
            Console.WriteLine($"ReferenceEquals(sp, sp) = {ReferenceEquals(sp, sp)}");
            
            Console.WriteLine($"Equals(cp, cp1) = {Equals(cp, cp1)}");
            Console.WriteLine($"Equals(sp, sp1) = {Equals(sp, sp1)}");*/

            /*Point point1 = new Point { X = 10, Y = 10 };
            Point point2 = new Point { X = 20, Y = 20 };

            Console.WriteLine(point1 == point2);
            Console.WriteLine(point1 != point2);
            Console.WriteLine(point1 > point2);
            Console.WriteLine(point1 < point2);

            if (point1) Console.WriteLine("No zero");
            else Console.WriteLine("Zero");

            while (point2)
            {
                Console.WriteLine(point2);
                point2 -= 5;
            }*/

            Human[] humans =
            {
                new Builder("строитель", "Иванов", 45888),
                new Pilot("пилот", "Петров", 28222),
                new Sailor("продавец", "Сидоров", 34445)
            };
            foreach (Human item in humans)
            {
                item.Print();
                // 1ый вариант
                try
                {
                    ((Builder)item).PrintBuilder();
                }
                catch { }
                // 2ой вариант
                Sailor sailor = item as Sailor;
                if (sailor != null) sailor.PrintSailor();
                // 3ой вариант
                if (item is Pilot)
                    (item as Pilot).PrintPilot();
            }

            Console.ReadKey();
        }
       
    }
}
