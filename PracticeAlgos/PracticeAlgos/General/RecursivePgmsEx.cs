using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgos.General
{
    public class RecursivePgmsEx
    {
        public int AddNumbers(int n)
        {
            if (n == 0 || n == 1) return n;


            return  (n + AddNumbers(n - 1));


        }
    }
}
