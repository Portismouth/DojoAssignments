using System;
using System.Collections.Generic;

namespace CollectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an array to hold integer values 0 - 9
            int[] numArray = new int[10];
            for (int i = 0; i < numArray.Length; i++)
            {
                numArray[i] = i;
                Console.WriteLine(numArray[i]);
            }

            //Array of strings
            string[] stringArray = new string[4] {"Tim", "Martin", "Nikki", "Sara"};
            Console.WriteLine(stringArray);

            //Array alternates true and false
            bool[] boolArray = new bool[10];
            for (int i = 0; i < numArray.Length; i++)
            {
                if( i % 2 == 0 )
                {
                    boolArray[i] = true;
                    Console.WriteLine(boolArray[i]);
                }
                else
                {
                    boolArray[i] = false;
                    Console.WriteLine(boolArray[i]);
                }
            }

            // Multidimensional multiplication table
            int [,] multiplication = new int[10,10];
            var rowCount = multiplication.GetLength(0);
            var colCount = multiplication.GetLength(1);
            for (int i = 1; i <= rowCount; i ++)
            {
                for (int j = 1; j <= colCount; j ++)
                {
                    // This Multipies each number in the array by the "# Row" that we are on, which is i
                    Console.Write(string.Format("{0} ", i * j));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }

            //List of Flavors
            List<string> flavors = new List<string>(0);
            flavors.Add("Vanilla");
            flavors.Add("Chocolate");
            flavors.Add("Rocky Road");
            flavors.Add("Cookie Dough");
            flavors.Add("Cflavors");
            int count = 0;
            foreach( string item in flavors )
            {
                count++;
            }
            Console.WriteLine("The length of the flavors list is {0}", count);
            Console.WriteLine(flavors[2]);
            flavors.RemoveAt(2);
            count = 0;
            foreach( string item in flavors )
            {
                count++;
            }
            Console.WriteLine("The length of the new flavors list is {0}", count);


            //User info dictionary
            Random rand = new Random();
            Dictionary<string,string> profile = new Dictionary<string,string>();
            profile.Add("Mitchell", null);
            profile.Add("Spiderman", null);
            profile.Add("Batman", null);
            List<string> keys = new List<string>(profile.Keys);
            foreach (string key in keys)
            {
                int rng = rand.Next(flavors.Count);
                profile[key] = flavors[rng];
            }
            foreach(var item in profile)
            {
                Console.WriteLine("Name: {0}, Ice Cream: {1}", item.Key, item.Value);
            }
        }
    }
}
