using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace IK_Algorithms.MockTests
{
	/// <summary>
	/// 
	/// </summary>
	public class ArraysStrings
	{
		#region Competing Team quality
		/* Computing Team Quality

c(n, 1),    c(n, 2),                  c(n, 3)                        ... c(n, n)   = 2 ^ n - 1

n          n * (n-1) / 2 * 1      n * (n-1) * (n - 3) / 3 * 2 * 1
	 *
	 * When assembling a team of workers to perform a task, we focus on
	 * professionalism and speed of the workers. To Calculate the overall quality of a team
	 * of workers, we take the sum of each worker's speed, and multiply it by the lowest
	 * professionalism rating of all the workers.
	 * 
	 * Given information about several available workers, select workers to create a team of
	 * less than or equal to a particular size. Determine the maximum quality of the team
	 * that can be created.
	 * 
	 * Example 1
	 * speed           = [4,3,150,5,6]
	 * professionalism = [7,6, 1,2,8]
     
                          6, 40, 3, 5, 150
                          8, 7, 6, 2, 1
                          
	 * maxWorkers      = 3     
	 * 
	 * The maximum number of workers go use is maxWorkers = 3 chosen from 5 available workers.
	 * A worker[i]'s speed and professionalism rating are speed[i] and professionalism[i].
	 * 
	 * Select the first, second, and fifth workers. The maximum quality of the team is:
	 *    (speed[0]+speed[1]+speed[4])*min(professionalism[0],professionalism[1],professionalism[4])=
	 *    (4+3+6)*min(7,6,8) = 13*6 = 78
	 *    
	 * Example 2
	 * speed           = [12,112,100,13,55]
	 * professionalism = [31,  4,100,55,50]
	 * maxWorkers      = 3
	 * 
	 * Maximum quality can be achieved by only selecting the third worker.
	 * Max quality = 100*100 = 10000
	 * 
	 * Example 3
	 * speed           = [11, 10, 7];
     * professionalism = [6, 4, 8];
     * maxWorkers      = 2
     * 
     * Max quality = (11+7)*min(6,8) = 18*6 = 108
     * 
     * Constraints:
     * 1 <=  n (total available worker) <= 10^5
     * 1 <= speed[i] <= 10^5
     * 1 <= professionalism[i] <= 10^5
     * 1 <= maxWorkers <= n
     *     
	 */

		/* 
		Old Content below(Java):
			10 9 8 7 6 5 4 3 2 1
			1  2 3 4 5 6 7 8 9 10


		/*
		Print all combinations when we combine two strings.  The relative order of each string
		should be maintained:

		str1 -> will have only [a-z]
		str2 -> will have only [0-9]

		str1 = "ab", str2 = "12"


		ab12
		a1b2
		a12b
		1ab2
		1a2b
		12ab
		*/

		/*
		Given a set of words and a pattern, return all the words which matches the pattern

		words = [bat, cat, hat, had, hut, mad, what]

		pattern = "*at", return bat, cat, bat
		pattern = "h**", return hat, had, hut
		pattern = "h*t", return hat, hut
		pattern = "**d", return had, mad

		Query with a pattern could be called many times

		words = ["what", "want","walls"]
		pattern = "w**t" return what, want

		*/

		/*
		Given an integer array move all 0's to left and  maintain the relative positions
		of elements which are greater than 0

		input: [0,5,0,0,6,7,0,0,4,2]
		output: [0,0,0,0,0,5,6,7,4,2]
		*/
		#endregion

		/// <summary>
		/// https://leetcode.com/problems/maximum-performance-of-a-team/
		/// </summary>
		/// <param name="speed"></param>
		/// <param name="professionalism"></param>
		/// <param name="noOfWrkr"></param>
		/// <returns></returns>
		public int CalculateTeamQuality(int[] speed, int[] professionalism, int noOfWrkr)
		{
			//convert speed and professionalism to array of array

			int[][] quality = new int[speed.Length][];

			for (int i = 0; i < speed.Length; i++)
			{
				quality[i] = new int[] { speed[i], professionalism[i] };
			}

			Array.Sort(quality, (j1, j2) => j2[1] - j1[1]);

			
			SortedList<int, int> minQueue = new SortedList<int, int>();
			
			int maxQuality = 0;
			
			int sum = 0;
			// Get max quality until k worker 
			for(int i=0;i< noOfWrkr;i++)
			{
				minQueue.Add(quality[i][0],i);
				
				sum += quality[i][0];

				maxQuality = Math.Max(maxQuality, sum * quality[i][1]);
			}

			for (int j=noOfWrkr;j<quality.Length;j++)
			{
				if(quality[j][0]> minQueue.First().Value)
				{
					sum -= minQueue.First().Value;
					sum += quality[j][0];
					maxQuality = Math.Max(maxQuality, sum * quality[j][1]);
					//remove the min element from the queue
					minQueue.Remove(minQueue.First().Key);
					//Add new element in queue
					minQueue.Add(quality[j][0],j);
				}
			}

			return maxQuality;
		}

		/// <summary>
		/// To do: complete the algo
		/// </summary>
		/// <param name="quality"></param>
		/// <param name="index"></param>
		/// <param name="maxQualitySofar"></param>
		/// <param name="maxQuality"></param>
		/// <param name="wrkrCount"></param>
		/// <param name="lst"></param>
		private void GetQuality(int[][] quality, int index,
			int maxQualitySofar, int maxQuality, int wrkrCount, List<int[]> lst)
		{
			if (index == wrkrCount)
			{

			}

			GetQuality(quality, index + 1, maxQualitySofar, maxQuality, wrkrCount, lst);
			lst.Add(quality[index]);

			GetQuality(quality, index + 1, maxQualitySofar, maxQuality, wrkrCount, lst);
			lst.Remove(quality[index]);
		}

		#region generate abbreviation

		/*
		# == == == == == == == == == == == == == == == == == == == == == =
		#
		# Write a function to generate the generalized abbreviations of a word.
		#
		# Example:
		#
		# Input: "word"
		# Output:
		# ["word", "1ord", "w1rd", "wo1d", "wor1", "2rd", "w2d", "wo2", "1o1d", "1or1", "w1r1", "1o2", "2r1", "3d", "w3", "4"]
		# */
		/// <summary>
		/// https://leetcode.com/problems/generalized-abbreviation/
		/// </summary>
		/// <param name="wrd"></param>
		/// <returns></returns>
		public List<string> GenerateAbbrivation(string wrd)
		{
			List<string> lst = new List<string>();
			int index = 0;
			//StringBuilder result = new StringBuilder();
			string result = string.Empty;
			int abCount = 0;
			HelperWordAbbreivate(wrd.ToCharArray(), index, lst, result, abCount);
			

			return lst;
		}

		private void HelperWordAbbreivate(char[] wrd, int index, List<string> lst, string result, int abCount)
		{
			if (index == wrd.Length)
			{

				if (abCount != 0)
					result = result + (abCount);

				lst.Add(result);
				return;
			}

			HelperWordAbbreivate(wrd, index + 1, lst, result, abCount + 1);

			if (abCount != 0)
			{
				result = result + abCount;
			}
			HelperWordAbbreivate(wrd, index + 1, lst, result + (wrd[index]), 0);
		}
		#endregion

	}
}
