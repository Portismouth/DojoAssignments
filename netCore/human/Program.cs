using System;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human mitchell = new Human("Mitchell");
            Human spiderman = new Human("Spiderman");
            mitchell.setAttributes("Mitchell", 10, 25, 7, 500);
            string result = mitchell.attack(spiderman, mitchell.Strength);
            Console.WriteLine(result);
            Console.WriteLine("{0}'s health is now: {1}", spiderman.Name, spiderman.Health);
        }
    }
}
