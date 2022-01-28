using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankWeek4
{
    class Result
    {
        /*
         * https://www.hackerrank.com/challenges/one-month-preparation-kit-equal-stacks/problem
         */
        public static int equalStacks(List<int> h1, List<int> h2, List<int> h3)
        {

            // stack height
            int t1 = h1.Sum();
            int t2 = h2.Sum();
            int t3 = h3.Sum();

            // max height;
            int max;

            // Loop while stacks height are different
            while ( t1!=t2 || t2 != t3 || t3 != t1)
            {
                // Get taller
                max = Math.Max(t1, Math.Max(t2, t3));

                // Check who is taller
                if ( t1 == max)
                {
                    t1 -= h1[0];
                    h1.RemoveAt(0);
                }
                else if ( t2 == max){
                    t2 -= h2[0];
                    h2.RemoveAt(0);
                }
                else
                {
                    t3 -= h3[0];
                    h3.RemoveAt(0);
                }
                
            }

            return t1;
        }

        /*
         * https://www.hackerrank.com/challenges/one-month-preparation-kit-maxsubarray/problem
         */
        public static List<int> maxSubarray(List<int> arr)
        {
            return new List<int>()
            {
                MaxContiguousSubarray(arr),
                MaxSubarray(arr)
            };
        }

        /*
         *  Kadane’s algorithm
         *  Adapted from https://www.geeksforgeeks.org/largest-sum-contiguous-subarray/
         */
        private static int MaxContiguousSubarray(List<int> list)
        {

            int m1 = Int32.MinValue;
            int m2 = 0;

            for ( int i =0; i<list.Count; i++)
            {
                m2 += list[i];

                if (m2 > m1)
                    m1 = m2;

                if (m2 < 0)
                    m2 = 0;
            }

            return m1;
        }
        private static int MaxSubarray(List<int> list)
        {

            int max = list.Max();
            int min = list.Min();

            if (max < 0)
                return max;

            return list.Where(p => p > 0).Sum();

        }

        /*
         * Jesse and Cookies
         * 
         * https://www.hackerrank.com/challenges/one-month-preparation-kit-jesse-and-cookies/problem
         * 
         *    Slowest algorithim
         */
        public static int cookies0(int k, List<int> A)
        {
            A.Sort();
            int i = 0;

            int cNew;

            while (A.Count > 1 && A[0] < k)
            {
                cNew = A[0] + 2 * A[1];
                A.RemoveAt(0);
                A.RemoveAt(0);
                A.Add(cNew);
                A.Sort();

                i++;
            }

            if (A.Count < 2)
                i = -1;

            return i;
        }
        /*
         *  A bit better than before
         */
        public static int cookies2(int k, List<int> A)
        {

            int pHead = 0;
            int pInsert = 2;
            int pNewCookie;
            int c = 0;

            A.Sort();

            while (A[pHead] < k && pHead < A.Count - 1)
            {
                pNewCookie = A[pHead] + A[pHead + 1] * 2;

                // Insert sorted
                if (pNewCookie >= A[A.Count - 1])
                {
                    A.Add(pNewCookie);
                }
                else
                {
                    while (A[pInsert] < pNewCookie & pInsert < A.Count - 1)
                        pInsert++;
                    A.Insert(pInsert, pNewCookie);
                }

                pHead += 2;
                pInsert = pHead + 1;

                c++;
            }

            if (A[pHead] < k && pHead >= A.Count - 1)
                return -1;

            else
                return c;

        }
        /* 
         * Fastest that I could, but not enough
         */
        public static int cookies(int k, List<int> A)
        {
            SortedList<int, int> A1 = new SortedList<int, int>(new DuplicateKeyComparer<int>());

            foreach (int x in A.OrderBy(p => p))
                A1.Add(x, x);

            int i = 0;

            int cNew;

            while (A1.Count > 1 && A1.ElementAt(0).Key < k)
            {
                cNew = A1.ElementAt(0).Key + 2 * A1.ElementAt(1).Key;
                A1.RemoveAt(0);
                A1.RemoveAt(0);
                A1.Add(cNew, cNew);
                i++;
            }

            if (A1.Count < 2)
                i = -1;

            return i;
        }
        /*
         *    Lets try not removing from queue
         */
        public static int cookies4(int k, List<int> A)
        {
            SortedList<int, int> A1 = new SortedList<int, int>(new DuplicateKeyComparer<int>());

            foreach (int x in A.OrderBy(p => p))
                A1.Add(x, x);

            int i = 0;
            int pHead = 0;
            int cNew;

            while (pHead<A1.Count-1 && A1.ElementAt(pHead).Key < k)
            {
                cNew = A1.ElementAt(pHead).Key + 2 * A1.ElementAt(pHead+1).Key;
                A1.Add(cNew, cNew);
                pHead += 2;
                i++;
            }

            if (A1.ElementAt(pHead).Key < k && pHead >= A.Count - 1)
                return -1;

            else
                return i;
        }
        /*
        * https://www.hackerrank.com/challenges/one-month-preparation-kit-hackerland-radio-transmitters
        */

        public static int hackerlandRadioTransmitters(List<int> x, int k)
        {
            // ShortCut
            if (x.Count == 0)
                return 0;

            // Sort list
            x.Sort();

            // first element of segment
            int sFirst = x[0];

            // las element of segment
            int sLastPossible = x[0];

            // Qtd of radio antenas installed
            int q = 1;

            // Loop points from second element
            for (int i = 1; i < x.Count; i++)
            {
                // Is this point in the range of the first element of this segment?
                if (x[i] - sFirst <= k)
                {
                    // We may put an antena here
                    sLastPossible = x[i];
                }
                // Is this point out of the range of the last possible point?
                else if (x[i] - sLastPossible > k)
                {
                    sFirst = x[i];
                    sLastPossible = x[i];
                    q++;
                }
            }

            return q;
        }

        /*
         * https://www.hackerrank.com/challenges/one-month-preparation-kit-richie-rich/problem
         */

        public static string highestValuePalindrome(string s, int n, int k)
        {

            // First create an Array to store and change bytes within the string - cannot change string directly ( as its imuttable )
            char[] s1 = s.ToArray();

            // How many chars do we need to change at least to form a palindrome?
            int needToChange = 0;
            for (int i = 0; i < s1.Length / 2; i++)
            {
                // Compare index with its simetric pair
                if (s1[i] != s1[s1.Length - i - 1])
                {
                    // Increase counter
                    needToChange++;
                }
            }

            // Check if its not posssible - need to change more than allowed
            if (needToChange > k)
                return "-1";

            // Check how many extra changes can we make
            int extraChanges = k - needToChange;

            // Lets check all chars, up to the middle
            for (int i = 0; i < s1.Length / 2; i++)
            {
                // Index of simmetric pair
                int ip = s1.Length - i - 1;

                // If both are not 9 and we have at least 2 extra changes available
                if (s1[i] != '9' && s1[ip] != '9' && extraChanges > 1)
                {
                    // If they are different, one change was accounted to normal changes, so lets burn only 1 extra
                    if (s1[i] != s1[ip])
                        extraChanges -= 1;

                    // They were equal, both changes should be couted as extra
                    else
                        extraChanges -= 2;

                    // Change both to 9
                    s1[i] = s1[ip] = '9';

                }
                // If they are different
                else if (s1[i] != s1[ip])
                {
                    // If we have at least 1 extra change available, and both are different and not 9
                    if (extraChanges > 0 && s1[i] != '9' && s1[ip] != '9')
                    {
                        // Change both to 9
                        s1[i] = s1[ip] = '9';

                        // Update extra changes available - althoug we changed both, they were different, 1 change was already counted outside extra changes available
                        extraChanges -= 1;

                    }
                    // If first is greater
                    else if (s1[i] > s1[ip])
                    {
                        // change first to pair value
                        s1[ip] = s1[i];
                    }
                    // If pair is greater 
                    else
                    {
                        // change pair to first value
                        s1[i] = s1[ip];
                    }
                }
            }

            // If there is still extra changes allowed, and s leng is even ( there's a solitary element at the middle )
            if (extraChanges > 0 && s1.Length % 2 != 0 && s1[s1.Length / 2] != '9')
            {
                // Change middle element to 9
                s1[s1.Length / 2] = '9';
            }

            // Return new string build with array content
            return new string(s1);
        }

        public static string highestValuePalindrome1(string s, int n, int k)
        {
            // First create an Array to store and change bytes within the string
            char[] s1 = s.ToArray();

            // Now we need to know what are the chars that must be changed to make a palindrome, and save their indexes
            List<int> mustChangeList = new List<int>();
            for (int i = 0; i < s1.Length / 2; i++)
            {
                // Compare index with its simetric pair
                if (s1[i] != s1[s1.Length - i - 1])
                {
                    // Save position of index that must be changed
                    mustChangeList.Add(i);
                }
            }

            // Now lets check how many extra changes are available
            int extraChanges = k - mustChangeList.Count;

            // If extraChanges < 0, whe have to change more chars than allowed, return -1
            if (extraChanges < 0)
                return "-1";

            // If we have more than 1 extra change allowed, lets start changing all pairs from left to right, to 9 - limit to the middle of the array
            int j = 0;
            while (extraChanges > 1 && j < s1.Length / 2)
            {
                // First check if the pair already contains 9 - if one is nine, it will be changed later - we have counted all single changes out of extraChanges
                if (s1[j] != '9' && s1[s1.Length - j - 1] != '9')
                {
                    if (s1[j] != s1[s1.Length - j - 1])
                        extraChanges -= 1;
                    else
                        //Update extra changes available
                        extraChanges -= 2;

                    s1[j] = '9';
                    s1[s1.Length - j - 1] = '9';
                }
                j++;
            }

            // Now lets change all unpaired numbers
            foreach (int l in mustChangeList)
            {
                // If both are not 9 and whe still have extraChange
                if (s1[l] != '9' && s1[s1.Length - l - 1] != '9' && extraChanges > 0)
                {
                    // Change both
                    s1[l] = '9';
                    s1[s1.Length - l - 1] = '9';

                    // Although we made 2 changes, one was already computed at the mandatory changes, so we spared 1 extra change
                    extraChanges--;
                }
                // Check who is greater, and make lower equal to greater
                if (s1[l] > s1[s1.Length - l - 1])
                {
                    s1[s1.Length - l - 1] = s1[l];
                }
                else
                {
                    s1[l] = s1[s1.Length - l - 1];
                }
            }

            // Is there any extra changes allowed, and s leng is even ( un solitary element at the middle ) ?
            if (extraChanges > 0 && s1.Length % 2 != 0)
            {
                // Change middle element to 9
                s1[s1.Length / 2] = '9';
            }

            // return array to string
            return new string(s1);
        }
        /*
         * https://www.hackerrank.com/challenges/one-month-preparation-kit-crush/problem
         */
        public static long arrayManipulation(int n, List<List<int>> queries)
        {
            long[] a = new long[n];

            foreach (List<int> query in queries)
            {
                a[query[0] - 1] += query[2];
                if (query[1] < n)
                    a[query[1]] -= query[2];
            }

            long prefixSum = 0;
            long max = long.MinValue;

            foreach (long i in a)
            {
                prefixSum += i;
                if (prefixSum > max)
                    max = prefixSum;
            }

            return max;
        }
        /*
         * https://www.hackerrank.com/challenges/one-month-preparation-kit-queries-with-fixed-length/problem
         */

        public static List<int> solve0(List<int> arr, List<int> queries)
        {

            // Result set
            List<int> r = new List<int>();

            // MinValue
            int min;

            // MaxValue
            int max = 0;

            // Each query
            for (int i = 0; i < queries.Count; i++)
            {
                // resset min
                min = int.MaxValue;

                // For each tuple
                for (int j = 0; j <= arr.Count - queries[i]; j++)
                {
                    // Get Max of this tuple
                    max = arr.GetRange(j, queries[i]).Max();

                    // Compare and save min value
                    min = Math.Min(min, max);
                }

                // Get min value of mav value list, and save to result
                r.Add(min);
            }

            return r;
        }

        public static List<int> solve1(List<int> arr, List<int> queries)
        {

            // Result set
            List<int> r = new List<int>();

            // MinValue
            int min;

            // MaxValue
            int max;

            // Query - subarray lengh
            int sLengh;

            // Each query
            for (int i = 0; i < queries.Count; i++)
            {
                sLengh = queries[i];
                max = 0;
                min = 0;


                // For each number in list
                for (int n = 0; n < arr.Count; n++)
                {
                    if (arr[n] >= max)
                        max = arr[n];

                    else if (n >= sLengh)
                        if (arr[n - sLengh] == max)
                            max = arr.GetRange(n - sLengh + 1, sLengh).Max();

                    if (n >= sLengh - 1)
                        if (min == 0 || min > max)
                            min = max;
                }

                // Get min value of mav value list, and save to result
                r.Add(min);
            }

            return r;
        }

        public static List<int> solve2(List<int> arr, List<int> queries)
        {

            // Result set
            List<int> r = new List<int>();

            // MinValue
            int min;

            // MaxValue
            int max = 0;

            // Each query
            for (int i = 0; i < queries.Count; i++)
            {
                // resset min
                min = int.MaxValue;

                // For each tuple
                for (int j = 0; j <= arr.Count - queries[i]; j++)
                {
                    // Get Max of this tuple
                    max = arr.GetRange(j, queries[i]).Max();

                    // Compare and save min value
                    min = Math.Min(min, max);
                }

                // Get min value of mav value list, and save to result
                r.Add(min);
            }

            return r;
        }
        /*
         * https://www.hackerrank.com/challenges/one-month-preparation-kit-queries-with-fixed-length/problem
         */

        public static List<int> solve(List<int> arr, List<int> queries)
        {
            List<int> r = new List<int>();

            foreach (int q in queries)
            {
                int min = arr.GetRange(0, q).Max();
                int max = min;

                for (int i = 1; i <= arr.Count - q; i++)
                {
                    if (arr[i] > max)
                        max = arr[i];

                    else if (arr[i - 1] == max)
                        max = arr.GetRange(i, q).Max();

                    if (max < min)
                        min = max;
                }

                r.Add(min);
            }

            return r;

        }


    }

    public class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
    {
        public int Compare(TKey x, TKey y)
        {
            int result = x.CompareTo(y);

            if (result == 0)
                result = 1;

            return result;
        }
    }

}
