using System;
using System.Collections.Generic;
namespace basicThirteen
{
    class Program
    {
        //Print 1-255
        public static void oneTo255()
        {
            for( int i = 1; i <= 255; i ++)
            {
                Console.WriteLine(i);
            }
        }

        //Print 1-255 odds
        public static void printOdds()
        {
            for( int i = 1; i <= 255; i ++)
            {
                if ( i % 2 == 1 )
                {
                    Console.WriteLine(i);
                }
            }
        }

        //Print sum
        public static void sum()
        {
            int sum = 0;
            for( int i = 0; i <= 255; i ++)
            {
                sum += i;
                Console.WriteLine("New number: {0} Sum: {1}", i , sum);
            }
        }

        //Iterate through array
        public static void iterArray(int[] x)
        {
            for( int i = 0; i < x.Length; i ++)
            {
                Console.WriteLine(x[i]);
            }
        }

        //Find max
        public static void findMax(int[] arr)
        {
            int max = arr[0];
            for( int i = 1; i < arr.Length; i ++)
            {
                if ( arr[i] > max )
                {
                    max = arr[i];
                }
            }
            Console.WriteLine(max);
        }

        //Find avg
        public static void findAvg(int[] arr)
        {
            int sum = arr[0];
            for( int i = 1; i < arr.Length; i ++)
            {
                sum += arr[i];
            }
            Console.WriteLine(sum);
            double avg = (double)sum / arr.Length;
            Console.WriteLine(avg);
        }

        //Odd Array
        public static void oddArray()
        {
            List<int> list = new List<int>();
            for( int i = 1; i <= 255; i ++)
            {
                if ( i % 2 == 1 )
                {
                    list.Add(i);
                }
            }
            foreach ( int item in list )
            {
                Console.WriteLine(item);
            }
        }

        //Greater than Y
        public static void greaterThan(int[] arr, int y)
        {
            int count = 0;
            for( int i = 0; i < arr.Length; i ++)
            {
                if ( y < arr[i] )
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }

        // Square the values
        public static void square(int[] arr)
        {
            for( int i = 0; i < arr.Length; i ++)
            {
                arr[i] = arr[i] * arr[i];
            }
            foreach ( int item in arr ){
                Console.WriteLine(item);
            }
        }

        // No Negatives
        public static void noNegs(int[] arr)
        {
            for( int i = 0; i < arr.Length; i ++)
            {
                if ( arr[i] < 0 )
                {
                    arr[i] = 0;
                }
            }
            foreach ( int item in arr ){
                Console.WriteLine(item);
            }
        }

        // Min Max Avg
        public static void minMaxAvg(int[] arr)
        {
            int min = arr[0];
            int max = arr[0];
            int sum = arr[0];
            for( int i = 1; i < arr.Length; i ++)
            {
                if ( arr[i] < min )
                {
                    min = arr[i];
                }
                if ( arr[i] > max )
                {
                    max = arr[i];
                }
                sum += arr[i];
            }
            double avg = (double)sum / arr.Length;
            Console.WriteLine("Max: {0}, Min: {1}, Avg: {2}", max, min, avg);
        }

        // Num to string
        public static void numToString(int[] arr)
        {
            List<object> array = new List<object>();
            for( int i = 1; i < arr.Length; i ++)
            {
                if ( arr[i] < 0 )
                {
                    array.Add("Dojo");
                }
                else
                {
                    array.Add(arr[i]);
                }
            }
            foreach (var item in array)
            {
                if ( item is int )
                {
                    int i = (int)item;
                    Console.WriteLine(i);
                }
                else
                {
                    string arrayString = item as string;
                    Console.WriteLine(arrayString);
                }
            }
        }



        public static void shift(int[] arr)
        {
            for( int i = 0; i < arr.Length; i ++)
            {
                if ( i  == arr.Length - 1 )
                {
                    arr[i] = 0;
                }
                else
                {
                    arr[i] = arr[i+1];
                }
            }
            foreach ( int item in arr )
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            // oneTo255();

            // printOdds();

            // sum();

            int[] arr; 
            arr = new int[] {1,-2,3,-4,5,6,7,-8,9,10};
            // iterArray(arr);
            // findMax(arr);
            // findAvg(arr);

            // oddArray();

            // greaterThan(arr, 4);

            // square(arr);

            // noNegs(arr);

            // minMaxAvg(arr);

            // shift(arr);

            // List<int> list = new List<int>();
            // toString()

            List<object> array = new List<object>();
            array.Add(1);
            array.Add(1);
            array.Add(-2);
            array.Add(1);
            array.Add(-3);
            numToString(arr);
        }
    }
}
