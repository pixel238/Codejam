using System;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;
using System.Text;

namespace Codejam
{
    class CreatePairs
    {
        int MaximalSum(int[] data)
        {
            int sum = 0;
            int NumberOfElementsGreaterThanEqualTwo = 0;
            int NumberOfNegativeNumber = 0;
            int NumberOfOnes = 0;
            bool IsZeroPresent = false;
            int Iterator = 1;
            Array.Sort(data);
            //Your code goes here
            for (int i = data.Length - 1; i >= 0; i--)
            {
                if (data[i] > 1)
                    NumberOfElementsGreaterThanEqualTwo++;
                else if (data[i] < 0)
                    NumberOfNegativeNumber++;
                else if (data[i] == 0)
                    IsZeroPresent = true;
                else
                    NumberOfOnes++;
            }
            if (NumberOfElementsGreaterThanEqualTwo > 0)
            {
                for (int i = 0; i <= NumberOfElementsGreaterThanEqualTwo / 2-NumberOfElementsGreaterThanEqualTwo%2; i += 2)
                {
                    sum += data[data.Length - i - 1] * data[data.Length - i - 2];
                }
                if (NumberOfElementsGreaterThanEqualTwo % 2 != 0)
                {
                    sum += data[data.Length - NumberOfElementsGreaterThanEqualTwo];
                }
            }
            if (NumberOfOnes > 0)
            {
                while (data[data.Length - NumberOfElementsGreaterThanEqualTwo - Iterator] == 1)
                {
                    sum += 1;
                    Iterator++;
                    if (data.Length - NumberOfElementsGreaterThanEqualTwo - Iterator < 0)
                        break;
                }
            }
            if (NumberOfNegativeNumber != 0)
            {
                for (int i = 0; i <= NumberOfNegativeNumber / 2-1; i += 2)
                {
                    sum += data[i] * data[i + 1];
                }
                if (NumberOfNegativeNumber % 2 != 0)
                {
                    //Console.WriteLine("Going");
                    if (!IsZeroPresent)
                    {
                        //Console.WriteLine("Going");
                        sum += data[NumberOfNegativeNumber - 1];
                    }
                }
            }
            //Your code goes here
            if (data.Length == 0)
                Console.WriteLine("Enter More than one Value");
            return sum;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            CreatePairs createPairs = new CreatePairs();
            do
            {
                int[] data = Array.ConvertAll<string, int>(input.Split(','), delegate (string s) { return Int32.Parse(s); });
                Console.WriteLine(createPairs.MaximalSum(data));
                input = Console.ReadLine();
            } while (input != "*");
        }
        #endregion
    }
}
