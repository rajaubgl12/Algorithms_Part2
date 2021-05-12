using System;
using System.Collections.Generic;
using System.Text;

namespace IK_Algorithms.Amazon
{
    public class AmazonAlgo
    {
        #region Amazon Test 11/1
        public int finalInstances(int instances, List<int> averageUtil)
        {
            int minUtilConst = 25;
            int maxUtilConst = 60;
            int minInstance = 1;
            int maxInstance = 2 * 10 ^ 8;
            double totalInstance = 0;
            //double instances = Convert.ToDouble(instances);
            double updateInstance = instances;
            bool isAction = false;
            for (int i = 0; i < averageUtil.Count; i++)
            {
                if (i < averageUtil.Count && averageUtil[i] < minUtilConst)
                {
                    if (updateInstance > minInstance)
                    {
                        updateInstance = Math.Ceiling((updateInstance / 2));
                        //no action for 10 secs
                        i = i + 9;
                        totalInstance += updateInstance;
                    }
                   
                }
                else if (i < averageUtil.Count && averageUtil[i] > maxUtilConst)
                {
                    if (updateInstance < maxInstance)
                    {
                        if (2 * updateInstance < maxInstance)
                        {
                            updateInstance = Math.Ceiling(2 * updateInstance);
                            //no action for 10 secs
                            i = i + 9;
                            totalInstance += updateInstance;
                        }
                    }
                }
                
            }

            return (int)totalInstance;
        }



        public  List<int> numberOfItems(string s, List<int> startIndices, List<int> endIndices)
        {
            List<int> totalItems = new List<int>();

            for (int i = 0; i < startIndices.Count; i++)
            {

                int startIndex = startIndices[i] - 1 < 0 ? 0 : startIndices[i] - 1;
                int endIndex = endIndices[i] - startIndices[i] + 1 > s.Length-1 ? s.Length-1 : endIndices[i] - startIndices[i] + 1;
                string subString = s.Substring(startIndex, endIndex);

                if (!string.IsNullOrWhiteSpace(subString))
                {
                    bool isStartPipe = false;
                    int count = 0;
                    int actualCount = 0;
                    for (int j = 0; j < subString.Length; j++)
                    {
                        if (subString[j] == '|' && !isStartPipe)
                        {
                            isStartPipe = true;
                        }
                        else if (isStartPipe && subString[j] == '*')
                        {
                            count++;
                        }
                        else if (isStartPipe && subString[j] == '|')
                        {
                            actualCount = count;
                        }
                    }
                    totalItems.Add(actualCount);
                }
            }
            return totalItems;
        }

        #endregion
    }
}
