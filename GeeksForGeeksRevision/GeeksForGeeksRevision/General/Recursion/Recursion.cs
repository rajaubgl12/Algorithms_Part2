using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision
{
    public class Recursion
    {
        /// <summary>
        /// its n-3 because you need to print A 3 times 
        /// f(n) = { n if n<=6 
        ///     // = {else max of {2.f(n-3),3.f(n-4), 4.f(n-5), 5.f(n-6)..... (n-2)f(1) 
        ///     https://www.youtube.com/watch?v=nyR8K63F2KY
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int PrintMaxNumberOfA(int N)
        {
            if (N <= 6)
                return N;
            // Initialize result
            int max = 0;

            // TRY ALL POSSIBLE BREAK-POINTS
            // For any keystroke N, we need
            // to loop from N-3 keystrokes
            // back to 1 keystroke to find 
            // a breakpoint 'b' after which
            // we will have Ctrl-A, Ctrl-C 
            // and then only Ctrl-V all the way.
            

            for (int b = N - 3; b >= 1; b--)
            {
                // If the breakpoint is s 
                // at b'th keystroke then
                // the optimal string would
                // have length (n-b-1)*screen[b-1];
                int K = (N - b - 1);
                int curr = K * PrintMaxNumberOfA(b); // or K can be initialized to 2 and increment till n-2
                if (curr > max)
                    max = curr;
            }
            return max;

        }

        static int findoptimal(int N)
        {
            // The optimal string length is N 
            // when N is smaller than 7
            if (N <= 6)
                return N;

            // An array to store result
            // of subproblems
            int [] screen = new int[N];

            int b; // To pick a breakpoint

            // Initializing the optimal lengths 
            // array for uptil 6 input strokes
            int n;
            for (n = 1; n <= 6; n++)
                screen[n - 1] = n;

            // Solve all subproblems in bottom manner
            for (n = 7; n <= N; n++)
            {
                // Initialize length of optimal
                // string for n keystrokes
                screen[n - 1] = 0;

                // For any keystroke n, we need 
                // to loop from n-3 keystrokes
                // back to 1 keystroke to find 
                // a breakpoint 'b' after which we
                // will have ctrl-a, ctrl-c and
                // then only ctrl-v all the way.
                for (b = n - 3; b >= 1; b--)
                {
                    // if the breakpoint is 
                    // at b'th keystroke then
                    // the optimal string would
                    // have length
                    // (n-b-1)*screen[b-1];
                    int curr = (n - b - 1) * screen[b - 1];
                    if (curr > screen[n - 1])
                        screen[n - 1] = curr;
                }
            }

            return screen[N - 1];
        }
       

        public int Fibonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            int fibSum = 0;
            int prev = 0;
            int curr = 1;
            for (int i = 2; i <= n; i++)
            {
                fibSum = prev + curr;
                prev = curr;
                curr = fibSum;
            }
            return fibSum;
        }
        //recursion
        public int Fibonacci2(int n)
        {
            if (n <= 1)
                return n;
            else
                return Fibonacci2(n - 1) + Fibonacci2(n - 2);
        }
        public int GCD(int m, int n)
        {
            if (m % n == 0)
                return n;
            return GCD(m, m % n);
        }

        // A recursive function to replace previous color 'prevC' at  '(x, y)' 
        // and all surrounding pixels of (x, y) with new color 'newC' and
        

        
    }
}
