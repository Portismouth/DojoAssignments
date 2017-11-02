using System;
using System.Collections.Generic;

namespace puzzles
{
    class Program
    {
        public static void randomArray()
        {
            Random rand = new Random();
            //Initializing Array with 10 spots
            int[] numArray = new int[10];
            for( int i = 0; i < 10; i ++)
            {
                //replacing all 10 spots with a random num between 5-25
                numArray[i] = rand.Next(5,26);
            }

            //Generic find max min sum
            int max = numArray[0];
            int min = numArray[0];
            int sum = numArray[0];
            for ( int j = 1; j < numArray.Length; j++ )
            {
                if ( max < numArray[j] )
                {
                    max = numArray[j];
                }
                if ( min > numArray[j] )
                {
                    min = numArray[j];
                }
                sum += numArray[j];
            }
            Console.WriteLine("Max: {0}, Min: {1}, Sum: {2}", max, min, sum);
        }

        public static string coinFlip()
        {
            Random rand = new Random();
            //Random number between 0-1 to check if heads or tails
            int flip = rand.Next(0,2);
            Console.WriteLine(flip);
            if (flip == 1)
            {
                Console.WriteLine("Heads");
                return "Heads";
            }
            else
            {
                Console.WriteLine("Tails");
                return "Tails";
            }
        }

        public static double tossMultipleCoins(int num)
        {
            Random rand = new Random();
            int count = 0;
            for ( int i = 0; i <= num; i++ )
            {
                //Random number between 0-1 to check if heads or tails
                int flip = rand.Next(0,2);
                if (flip == 1)
                {
                    //Only need to count heads to get percentages of both
                    Console.WriteLine("Heads");
                    count++;
                }
                else
                {
                    Console.WriteLine("Tails");
                }
            }
            //setting ration number as double
            double ratio = (double)count / num;
            return ratio * 100;   
        }


        public static string[] names(string[] arr)
        {
            Random rand = new Random();
            //Creating list to add names that are longer than 5 letters
            List<string> bigNames = new List<string>();
            for ( int i = 0; i < arr.Length; i++ )
            {
                //Getting a random number between 0 and length of array, then doing temp swap out values every iteration to "shuffle"
                int rng = rand.Next(arr.Length);
                string temp = arr[i];
                arr[i] = arr[rng];
                arr[rng] = temp;
            }
            //Adds names bigger than five to new list
            for ( int j = 0; j < arr.Length; j++ ){
                if ( arr[j].Length > 5 )
                {
                    bigNames.Add(arr[j]);
                }
            }
            //Return arr or shuffled names, return bigNames for names over 5
            return arr;
        }


        static void Main(string[] args)
        {
            // randomArray();

            // string response = coinFlip();
            // Console.WriteLine("The winner is {0}", response);ß

            // double percent = tossMultipleCoins(100);
            // Console.WriteLine("{0}%", percent);

            string[] namesArray = new string[5] {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            // string[] stringArray = names(namesArray);
            // foreach ( string item in stringArray )
            // {
            //     Console.WriteLine(item);
            // }

            Console.WriteLine(names(namesArray));
            foreach (string item in names(namesArray))
            {
                Console.WriteLine(item);
            }

        }
    }
}
