using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IK_Algorithms.Recursion
{
    public class TargetSum_AllExpression
    {


        /// <summary>
        /// https://leetcode.com/problems/expression-add-operators/
        /// Input: num = "123", target = 6
        /// Output: ["1+2+3", "1*2*3"]
        /// Input: num = "105", target = 5
        /// Output: ["1*0+5","10-5"]
        /// 
        /// DFS
        /// </summary>
        /// <param name="num"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<string> AddOperators(string num, int target)
        {
            IList<string> result = new List<string>();
            int total = 0;
            int prevNum = 0;
            int index = 0;
            string candidate = "";
            HelperAddOperatorLeetCode(num,index,candidate,total,prevNum, target, result);
          //  string [] list = result.ToArray();
            return result;

        }

        /// <summary>
        /// https://www.youtube.com/watch?v=uhZeoivB7_4
        /// </summary>
        /// <param name="num"></param>
        /// <param name="index"></param>
        /// <param name="candidate"></param>
        /// <param name="total"></param>
        /// <param name="prevNum"></param>
        /// <param name="target"></param>
        /// <param name="result"></param>
        private void HelperAddOperatorLeetCode(string num, int index, string candidate
            , int total, int prevNum, int target, IList<string> result)
        {
            if(index==num.Length)
            {
                if (total == target)
                    result.Add(candidate);
                
                return;
            }

            for(int i=index+1; i<=num.Length;i++)
            {
                string numSub = num.Substring(index, i - index);
                int currNum = int.Parse(numSub);
                if (num[index] == '0' && numSub != "0")
                    continue;
                if (string.IsNullOrWhiteSpace(candidate))
                    HelperAddOperatorLeetCode(num, i, numSub, currNum, currNum, target, result);

                else
                {
                    //Addition
                    HelperAddOperatorLeetCode(num, i, (candidate + '+' + currNum), total + currNum, currNum, target, result);

                    //Subtraction
                    HelperAddOperatorLeetCode(num, i, (candidate + '-' + currNum), total - currNum, -currNum, target, result);

                    //Multiplication
                    HelperAddOperatorLeetCode(num, i, (candidate + '*' + currNum), total - prevNum + prevNum * currNum, currNum, target, result);

                }

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<string> AddOperatorsTry(string num, int target)
        {
            char[] oprtr = { '+', '-', '*' };
            IList<string> result = new List<string>();
            StringBuilder sbCurrent = new StringBuilder();
            int currSum = 0;
            int index = 0;
            HelperAddOperator(num, index, target, oprtr, result,sbCurrent, currSum);
            return result;
        }


        private void HelperAddOperator(string num, int index, int target, char[] oprtr, IList<string> result, StringBuilder sbCurrent, int currSum)
        {
            if(index==num.Length && currSum==target)
            {
                result.Add(sbCurrent.ToString());
                return;
            }
            if(index==num.Length)
            {
                return;
            }

            for(int i =0;i<oprtr.Length;i++)
            {
                int currNum = num[index] - '0';
                if (oprtr[i] =='+')
                {
                    currSum = currSum + currNum;
                    
                }
                if (oprtr[i] == '-')
                {
                    currSum = currSum - currNum;
                    
                }
                if (oprtr[i] == '*')
                {
                    currSum = currSum * (currNum);
                }
                if(index!=0)
                sbCurrent.Append(oprtr[i]);
                sbCurrent.Append(currNum);
                
                HelperAddOperator(num, index + 1, target, oprtr, result, sbCurrent, currSum);
                sbCurrent.Remove(sbCurrent.ToString().IndexOf(num[index]), currNum.ToString().Length);
                sbCurrent.Remove(sbCurrent.ToString().LastIndexOf(oprtr[i]), 1);
                
            }
        }

        #region related algorithms

        /// <summary>
        /// https://leetcode.com/problems/basic-calculator-ii/
        /// Given a string s which represents an expression, evaluate this expression and return its value.
        /// Input: s = "3+2*2"
        /// Output: 7
        /// Input: s = " 3/2 "
        /// Output: 1
        /// Input: s = " 3+5 / 2 "
        /// Output: 5
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Calculate(string s)
        {
            Stack<int> stackInt = new Stack<int>();
            char oprtr = '+';
            int currentNumber = 0;

            for (int i=0;i<s.Length;i++)
            {
                char currentChar = s[i];
                if(char.IsDigit(currentChar))
                {
                    currentNumber = (currentNumber * 10) + (s[i] - '0');
                }
                if ((!char.IsDigit(currentChar) && !char.IsWhiteSpace(currentChar))||i==s.Length-1)
                {
                    if(oprtr == '-')
                    {
                        stackInt.Push(-currentNumber);
                    }

                    if (oprtr == '+')
                    {
                        stackInt.Push(currentNumber);
                    }

                    if (oprtr == '*')
                    {
                        stackInt.Push(stackInt.Pop() * currentNumber);
                    }
                    if (oprtr == '/')
                    {
                        stackInt.Push(stackInt.Pop() / currentNumber);
                    }
                    currentNumber = 0;
                    oprtr = currentChar;
                }
            }
            int result = 0;
            while(stackInt.Count>0)
            {
                result += stackInt.Pop();
            }

            return result;
        }

        public IList<IList<string>> CombinationNumbers(string str)
        {
            //StringBuilder sb = new StringBuilder();
            IList<IList<string>> lstCombination = new List<IList<string>>();
            IList<string> lstCurrent = new List<string>();
            HelperCombination(str, lstCurrent, 0, lstCombination);
            return lstCombination;
        }

        private void HelperCombination(string str, IList<string> lstCurrent, int index, IList<IList<string>> lstCombination)
        {
            if(index==str.Length)
            {
                if(lstCurrent.Count>0)
                lstCombination.Add(new List<string>(lstCurrent));
                return;
            }

            for (int i = 1 + index; i <= str.Length; i++)
            {
                string strTmp = str.Substring(index, i - index);
                lstCurrent.Add(strTmp);
                HelperCombination(str, lstCurrent, i, lstCombination);
                lstCurrent.Remove(strTmp);
            }
           
        }

        #endregion
    }
}
