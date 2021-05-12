using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision.FaceBook.Arrays
{
   public class ValidParanthesis
    {
        public bool IsValid(string strWord)
        {

            Stack<char> stParanthesis = new Stack<char>();
            if (strWord.Length == 1)
                return false;
            for (int i = 0; i < strWord.Length; i++)
            {
                if (strWord[i] == '(' || strWord[i] == '{' || strWord[i] == '[')
                {
                    stParanthesis.Push(strWord[i]);
                }
                /* If exp[i] is an ending parenthesis then pop from stack and check if the popped parenthesis is a matching pair*/
                if (strWord[i] == '}' || strWord[i] == ')' || strWord[i] == ']')
                {
                    if (stParanthesis.Count == 0)
                        return false;
                    else if (!isMatchingPair(stParanthesis.Pop(), strWord[i]))
                    {
                        return false;
                    }
                }
            }
            if (stParanthesis.Count == 0)
                return true;
            else
                return false;
        }

        static bool isMatchingPair(char character1, char character2)
        {
            if (character1 == '(' && character2 == ')')
                return true;
            else if (character1 == '{' && character2 == '}')
                return true;
            else if (character1 == '[' && character2 == ']')
                return true;
            else
                return false;

        }

    }
}
