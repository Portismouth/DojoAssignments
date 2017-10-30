using System;
using System.Collections.Generic;

namespace BoxingUnpacking
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> box = new List<object>();
            box.Add(78);
            box.Add(-1);
            box.Add(28);
            box.Add(true);
            box.Add("chair");
            int sum = 0;
            foreach ( var item in box )
            {
                if ( item is int )
                {
                    int j = (int)item;
                    sum += j;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
