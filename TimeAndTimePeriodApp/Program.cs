using System;
using ClassLibrary;

namespace TimeAndTimePeriodApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Time p1 = new Time(12, 15, 20);
            Time p1a = new Time(12, 15, 20);
            Time p2 = new Time(13, 1, 1);
            Time p3 = new Time(10, 10, 10);
            TimePeriod p4 = new TimePeriod(2, 20, 9);
            TimePeriod p5 = new TimePeriod(2, 10, 9);
            Time p6 = new Time(10, 10);


            Console.WriteLine(p1 - p2);
            Console.WriteLine(p1);
            Console.WriteLine(p1.Plus(p4));
            Console.WriteLine(p3 + p5);
            Console.WriteLine(p1.GetHashCode());
            Console.WriteLine(Time.Plus(p1, p4));
            Console.WriteLine(p4 != p5);

            Console.WriteLine(p1 - p2);

            Console.WriteLine(p1a.Equals(p1));
            Console.WriteLine(p4.Equals(p5));
            Console.WriteLine(p6);
        }
    }
}
