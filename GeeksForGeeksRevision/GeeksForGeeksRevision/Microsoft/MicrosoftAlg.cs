using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeksRevision
{
    class MicrosoftAlg
    {

        //Arrange given numbers to form the biggest number | Set 1
        //https://www.geeksforgeeks.org/arrange-given-numbers-form-biggest-number-set-2/
        public static void ArrangeLargestNumFromArray(int [] a)
        {
            StringBuilder sbLargestNum = new StringBuilder();
            for(int i=0;i<a.Length;i++)
            {
                for(int j=i+1;j<a.Length;j++)
                {
                    string xy = a[i].ToString() + a[j].ToString();
                    string yx = a[j].ToString() + a[i].ToString();
                    if(xy.CompareTo(yx)<0)
                    {
                        int temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
                sbLargestNum.Append(a[i]);
            }

        }



       
        public static bool Anagram(String strAnagrm1, string strAngrm2)
        {
            if (strAnagrm1.Length != strAngrm2.Length)
                return false;

            Dictionary<string, int> dictAna1 = new Dictionary<string, int>();
            
            for(int i=0;i<strAnagrm1.Length;i++)
            {
                dictAna1.Add(strAnagrm1[i].ToString(), i);
            }
            for (int i = 0; i < strAngrm2.Length; i++)
            {
                if (!dictAna1.ContainsKey(strAngrm2[i].ToString()))
                    return false;
            }
            return true;
        }

        static int NO_OF_CHARS = 256;

        /* function to check whether two strings 
        are anagram of each other */
        static bool areAnagram(char[] str1, char[] str2)
        {
            // Create 2 count arrays and initialize 
            // all values as 0 
            int[] count1 = new int[NO_OF_CHARS];
            int[] count2 = new int[NO_OF_CHARS];
            int i;

            // For each character in input strings, 
            // increment count in the corresponding 
            // count array 
            for (i = 0; i < str1.Length && i < str2.Length;
                 i++)
            {
                count1[str1[i]]++;
                count2[str2[i]]++;
            }

            // If both strings are of different length. 
            // Removing this condition will make the program 
            // fail for strings like "aaca" and "aca" 
            if (str1.Length != str2.Length)
                return false;

            // Compare count arrays 
            for (i = 0; i < NO_OF_CHARS; i++)
                if (count1[i] != count2[i])
                    return false;

            return true;
        }

        static bool areAnagram(String str1, String str2)
        {
            // If two strings have different length  
            if (str1.Length != str2.Length)
            {
                return false;
            }

            // To store the xor value  
            int value = 0;

            for (int i = 0; i < str1.Length; i++)
            {
                value = value ^ (int)str1[i];
                value = value ^ (int)str2[i];
            }

            return value == 0;

        }

        //find maximum consecutive repeating character in string.
        //Input : str = "aaaaaabbcbbbbbcbbbb"
        //Output :a



        public static void MaxRepeatingChar(string strInput)
        {
            int maxCount = 0;
            int count = 0;
            string charMaxCount = string.Empty;
            for (int i = 0; i < strInput.Length; i++)
            {
                if (i<strInput.Length-1 && strInput[i] == strInput[i + 1])
                {
                    count++;
                }
                else
                {
                    count++;
                    if (maxCount < count)
                    {
                        //save the count
                        maxCount = count;
                        //save the character
                        charMaxCount = strInput[i].ToString();
                    }
                    //reset the count
                    count = 0;
                }
            }
            
            Console.WriteLine("The max count of a character {0} is {1}", charMaxCount, maxCount);
        }

        public static void MergeSortedArray( int [] l1, int [] l2)
        {
            int len1 = l1.Length;
            int len2 = l2.Length;
            int lenMerg = len1 + len2;
            int[] mergArray = new int[lenMerg];
            int a1 = 0;
            int b1 = 0;
            int m = 0;
            while (a1 <= len1 - 1 && b1 <= len2 - 1)
            {
                if (l1[a1] < l2[b1])
                {
                    mergArray[m++] = l1[a1++];
                    
                }
                else
                {
                    mergArray[m++] = l2[b1++];                    
                }                
            }
            while (a1 < len1)
            {
                mergArray[m++] = l1[a1++];
                
            }
            while (b1 < len2)
            {
                mergArray[m++] = l2[b1++];
            }
        }

        public static void PushNegativeNumLeft(int [] arr)
        {
            int n = arr.Length;
            int key, j;
            for (int i = 1; i < n; i++)
            {
                key = arr[i];

                // if current element is positive
                // do nothing
                if (key > 0)
                    continue;

                /* if current element is negative,
                shift positive elements of arr[0..i-1],
                to one position to their right */
                j = i - 1;
                while (j >= 0 && arr[j] > 0)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }

                // Put negative element at its right position
                arr[j + 1] = key;
            }
        }
    }
}
