using System;
using System.Collections.Generic;

internal class Program
{
    static void Main(string[] args)
    {
        // read height of the triangle
        int triangleHeight = Convert.ToInt32(Console.ReadLine());

        List<List<double>> triangle = new List<List<double>>();

        // read the numbers of the triangle
        for (int i = 0; i < triangleHeight; i++)
        {
            string[] sNums = Console.ReadLine().Split();
            List<double> nums = new List<double>();
            for (int j = 0; j < sNums.Length; j++)
                nums.Add(Convert.ToDouble(sNums[j]));

            triangle.Add(nums);
        }
        Console.WriteLine("max sum: " + getMaxSum(triangle));
        Console.ReadKey();
    }

    static double getMaxSum(List<List<double>> triangle)
    {

        double sum = 0;

        // array for the previous triangle sum layer
        List<double> prevSumLevel = triangle[0];
        // array for the current triangle sum layer
        List<double> curSumLevel = new List<double>();

        // loop along the height of the triangle
        for (int i = 1; i < triangle.Count; i++)
        {
            curSumLevel.Clear();
            // loop along the elements of the triangle layer
            for (int j = 0; j < triangle[i].Count; j++)
            {
                // the sum value for the first element
                if (j == 0)
                {
                    curSumLevel.Add(triangle[i][j] + prevSumLevel[0]);
                }
                // the sum value for the last element
                else if (j == triangle[i].Count - 1)
                {
                    curSumLevel.Add(triangle[i][j] + prevSumLevel[prevSumLevel.Count - 1]);
                }
                // the sum value for the elements is not at the ends
                else
                {
                    curSumLevel.Add(Math.Max(triangle[i][j] + prevSumLevel[j - 1], triangle[i][j] + prevSumLevel[j]));
                }
            }
            prevSumLevel.Clear();
            for (int j = 0; j < curSumLevel.Count; j++)
                prevSumLevel.Add(curSumLevel[j]);
        }
        for (int i = 0; i < curSumLevel.Count; i++)
        {
            sum = Math.Max(sum, curSumLevel[i]);
        }

        return sum;
    }
}
