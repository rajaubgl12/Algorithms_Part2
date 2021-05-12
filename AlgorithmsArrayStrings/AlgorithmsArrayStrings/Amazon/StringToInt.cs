using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsArrayStrings.Amazon
{
   public class StringToInt
    {
       
        /// <summary>
        /// important ones are 
        /// 1. Run through the array
        /// 2. Save the sign, check for digits multiply by 10 and keep adding the digits.
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int MyAtoi(string str)
        {
            int i = 0;
            
            if (string.IsNullOrWhiteSpace(str))
                return 0;

            str = str.Trim();
            if (i == str.Length)
            {
                // then it was all whitespace
                return 0;
            }

            // check if there is a sign character and more past it if so
            int sign = 1;
            if (str[i] == '-')
            {
                sign = -1;
                i++;
            }
            else if (str[i] == '+')
            {
                i++;
            }

            // use a int since we need to try and parse an int. if result > Int_Max then we overflowed and we should return Min or Max int depending on the sign
            long result = 0;
            for (; i < str.Length; i++)
            {
                if (str[i] < '0' || str[i] > '9')
                {
                    // check if we're no longer dealing with integral numbers
                    break;
                }

                // otherwise assume we can add to the result
                result *= 10;
                result += (str[i] - '0') * (sign);

                // see if we overflowed
                if (result < Int32.MinValue || result > Int32.MaxValue)
                {
                    return sign==-1 ? Int32.MinValue : Int32.MaxValue;
                }
            }

            // if we got here then the uint result must not have overflowed. cast it to an int and apply the sign 
            return (int)result;
        }

        String[] SingleNum = new String[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        String[] DoubleNum = new String[] { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        String[] HundredNum = new String[] { "", " Hundred" };
        String[] ThousandNum = new String[] { "", " Thousand" };
        String[] MillionNum = new String[] { "", " Million" };
        String[] BillionNum = new String[] { "", " Billion" };
        String[] SpaceNum = new String[] { "", " " };

        /// <summary>
        /// https://www.youtube.com/watch?v=qwotMTggot0 watch this for implementation.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public String numberToWords(int num)
        {
            if (num == 0)
                return "Zero";

            String retStr;

            int B = 1000000000;
            int M = 1000000;
            int K = 1000;
            retStr = SingleNum[num / B] + BillionNum[num >= B ? 1 : 0] + SpaceNum[num > B && (num % B / M != 0) ? 1 : 0] +
                    ConvertHundred(num % B / M) + MillionNum[num >= M && (num % B / M) != 0 ? 1 : 0] 
                    + SpaceNum[(num >= M && (num % M / K) != 0) ? 1 : 0] +
                    ConvertHundred(num % M / K) + ThousandNum[num >= K && (num % M / K) != 0 ? 1 : 0] 
                    + SpaceNum[num > K && (num % K != 0) ? 1 : 0] +
                    ConvertHundred(num % K);

            return retStr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private String ConvertHundred(int num)
        { //num < 1000
            String retStr;
            if (num % 100 < 20)
                retStr = SingleNum[(num % 20)];
            else
                retStr = DoubleNum[(num % 100 / 10)] + SpaceNum[(num % 10 != 0) ? 1 : 0] + SingleNum[(num % 10)];
            retStr = SingleNum[num / 100] + HundredNum[num >= 100 ? 1 : 0] + SpaceNum[(num > 100 && num % 100 != 0) ? 1 : 0] + retStr;
            return retStr;
        }


        public string Number2WordsMyCode(int num)
        {
            if (num == 0)
                return "Zero";

            int B = 1000000000;
            int M = 1000000;
            int K = 1000;
            string numToWrds = SingleNum[num / B] + BillionNum[num >= B ? 1 : 0] + " " + ConvertHunderedMyCode((num % B) / M) + MillionNum[num >= M ? 1 : 0]
                + " " + ConvertHunderedMyCode((num % M) / K) + ThousandNum[num >= K ? 1 : 0]
                + " " + ConvertHunderedMyCode((num % K));

            return numToWrds;
        }

        private string ConvertHunderedMyCode(int num)
        {
            string strRet = "";
           strRet =  SingleNum[num / 100] + HundredNum[num >= 100 ? 1 : 0] + DoubleNum[(num % 100) / 10] + SingleNum[num % 10];
            return strRet;
        }
                
    }
}
