using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace HackerRankWeek4
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestCookies();
            TestJesseAndCookies_File();
        }
        static void TestJesseAndCookies_File()
        {
            TextWriter textWriter = new StreamWriter(Directory.GetCurrentDirectory() + "\\output13.txt", true);
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\input13.txt");

            string[] firstMultipleInput = sr.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            List<int> A = sr.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList();

            Stopwatch stopwatch = Stopwatch.StartNew();
            int result = Result.cookies(k, A);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
        static void TestSolve()
        {
            List<int> arr;
            List<int> queries;

            //arr = new() { 2, 3, 4, 5, 6 };
            //queries = new() { 2, 3 };
            //Console.WriteLine(String.Join(",",Result.solve(arr, queries)));
            //Console.WriteLine("Expected: 3, 4");

            //arr = new() { 1, 2, 3, 4, 5 };
            //queries = new() { 1, 2, 3, 4, 5 };
            //Console.WriteLine(String.Join(",", Result.solve(arr, queries)));
            //Console.WriteLine("Expected: 1,2,3,4,5");

            arr = new() { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            queries = new() { 2 };
            Console.WriteLine(String.Join(",", Result.solve(arr, queries)));
            Console.WriteLine("Expected: 2");

        }
        static void TestArrayManipulation()
        {
            List<List<int>> queries = new()
            {
                new() { 1, 5, 3 },
                new() { 4, 8, 7 },
                new() { 6, 9, 1 }
            };

            int n = 10;

            Console.WriteLine(Result.arrayManipulation(n, queries));
        }

        static void TestHighestValuePalindrome()
        {
            string s;
            int k;

            s = "1234";
            k = 4;
            Console.WriteLine(Result.highestValuePalindrome(s, s.Length, k));
            Console.WriteLine("Expected 9999");

            s = "092282";
            k = 3;
            Console.WriteLine(Result.highestValuePalindrome(s, s.Length, k));
            Console.WriteLine("Expected 992299");

            s = "1";
            k = 5;
            Console.WriteLine(Result.highestValuePalindrome(s, s.Length, k));
            Console.WriteLine("Expected 9");

            s = "3943";
            k = 1;
            Console.WriteLine(Result.highestValuePalindrome(s, s.Length, k));
            Console.WriteLine("Expected 3993");

            s = "0011";
            k = 1;
            Console.WriteLine(Result.highestValuePalindrome(s, s.Length, k));
            Console.WriteLine("Expected -1");

            s = "1231";
            k = 3;
            Console.WriteLine(Result.highestValuePalindrome(s, s.Length, k));
            Console.WriteLine("Expected 9339");

            s = "12321";
            k = 1;
            Console.WriteLine(Result.highestValuePalindrome(s, s.Length, k));
            Console.WriteLine("Expected 12921");

        }

        static void TestCookies()
        {
            List<int> list = new List<int>() { 2, 7, 3, 6, 4, 6 };
            int k = 9;
            Console.WriteLine(Result.cookies(k, list));
            Console.WriteLine("Expected: 4");

            list = new List<int>() { 1, 2, 3, 9, 10, 12 };
            k = 7;
            Console.WriteLine(Result.cookies(k, list));
            Console.WriteLine("Expected: 2");

            list = new List<int>() { 7, 2, 4, 6, 5, 9, 12, 11 };
            k = 3;
            Console.WriteLine(Result.cookies(k, list));
            Console.WriteLine("Expected: 1");

        }


        static void TestHackerLand()
        {
            List<int> list = new List<int>() { 1, 2, 3, 5, 9 };
            int k = 1;
            Console.WriteLine(Result.hackerlandRadioTransmitters(list, k));
            Console.WriteLine("Expected: 3");

            list = new List<int>() { 1, 2, 3, 4, 5 };
            k = 1;
            Console.WriteLine(Result.hackerlandRadioTransmitters(list, k));
            Console.WriteLine("Expected: 2");

            list = new List<int>() { 7, 2, 4, 6, 5, 9, 12, 11 };
            k = 2;
            Console.WriteLine(Result.hackerlandRadioTransmitters(list, k));
            Console.WriteLine("Expected: 3");

        }

        static void TestHighestValuePalindromeFile()
        {
            TextWriter textWriter = new StreamWriter(Directory.GetCurrentDirectory() + "\\output10.txt", true);

            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\input10.txt");

            string[] firstMultipleInput = sr.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            string s = sr.ReadLine();


            Stopwatch stopwatch = Stopwatch.StartNew();
            string result = Result.highestValuePalindrome(s, n, k);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedTicks);


            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();

        }

        static void TestEqualStacks()
        {
            List<int> h1 = new() { 1, 2, 1, 1 };
            List<int> h2 = new() { 1, 1, 2 };
            List<int> h3 = new() { 1, 1 };

            Console.WriteLine(Result.equalStacks(h1, h2, h3));
        }

        static void TestMaxSubArray()
        {
            List<int> list = new() { -1, 2, 3, -4, 5, 10 };
            Console.WriteLine(String.Join(",", Result.maxSubarray(list)));
            Console.WriteLine("Expected: 16, 20");

            list = new() { 1, 2, 3, 4 };
            Console.WriteLine(String.Join(",", Result.maxSubarray(list)));
            Console.WriteLine("Expected: 10, 10");

            list = new() { 2, -1, 2, 3, 4, -5 };
            Console.WriteLine(String.Join(",", Result.maxSubarray(list)));
            Console.WriteLine("Expected: 10, 11");

        }
        static void TestSolveFile()
        {
            TextWriter textWriter = new StreamWriter(Directory.GetCurrentDirectory()+"//output00.txt", true);

            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "//input00.txt");

            string[] firstMultipleInput = sr.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int q = Convert.ToInt32(firstMultipleInput[1]);

            List<int> arr = sr.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            List<int> queries = new List<int>();

            for (int i = 0; i < q; i++)
            {
                int queriesItem = Convert.ToInt32(sr.ReadLine().Trim());
                queries.Add(queriesItem);
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<int> result = Result.solve(arr, queries);

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedTicks);

            textWriter.WriteLine(String.Join("\n", result));

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
