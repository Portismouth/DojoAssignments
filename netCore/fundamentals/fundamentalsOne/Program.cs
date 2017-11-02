using System;

namespace fundamentalsOne
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 - 255
            for(int i = 1; i <= 255; i++)
            {
                Console.WriteLine(i);
            }

            // All values from 1-100 that are divisible by 3 or 5
            for(int i = 1; i <= 100; i++)
            {
                if(i % 3 == 0 || i % 5 == 0 )
                {
                    Console.WriteLine(i);
                }
            }

            //Fizz Buzz
            for(int i = 1; i <= 100; i++)
            {
                if(i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if(i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if(i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
            }

            //Random Values
            Random rand = new Random();
            for(int i = 0; i < 10; i++)
            {
                int x = rand.Next();
                if(x % 3 == 0 && x % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if(x % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if(x % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
            }

        }
    }
}
