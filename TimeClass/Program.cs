namespace TimeClass
{
    internal class Program
    {
        public static void Main()
        {
            Time t1 = new Time(86399);
            Console.WriteLine(t1.ToString());

            Time t2 = new Time(4, 40, 50);
            Console.WriteLine(t2.ToString());

            Time t3 = new Time(4, 40, 50);
            Console.WriteLine(t3.ToString());

            Console.WriteLine("-----------------------");
            Console.WriteLine(t1 + t2);
            //Console.WriteLine(t1 - t2);
            Console.WriteLine(t1 * 3);
            Console.WriteLine(t1 / 3);
            //Console.WriteLine(t1 - t3);
            Console.WriteLine("-----------------------");
            Console.WriteLine(t1 > t2);
            Console.WriteLine(t1 >= t2);
            Console.WriteLine(t1 < t2);
            Console.WriteLine(t1 <= t2);
            Console.WriteLine("-----------------------");
            Console.WriteLine(t2 > t3);
            Console.WriteLine(t2 >= t3);
            Console.WriteLine(t2 < t3);

        }
    }
}