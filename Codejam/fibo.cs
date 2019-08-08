using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    class TriFibonacci
    {
        public int Complete(int[] test)
        {
            int a = test[0];
            int b = test[1];
            int c = test[2];
            if (a == -1)
                return (test[3] - b - c )> 0 ? test[3] - b - c : -1;
            if (b == -1)
                return (test[3] - a - c )> 0 ? test[3] - a - c : -1;
            if (c == -1)
                return (test[3] - b - a) > 0 ? test[3] - a - c : -1;
            for (int i=3;i<test.Length;i++)
            {
                if (test[i] == -1)
                    return a + b + c;
                else if (test[i] != a + b + c)
                    break;
                else
                {
                    a = b;
                    b = c;
                    c = test[i];
                }
            }
            return -1;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            TriFibonacci triFibonacci = new TriFibonacci();
            do
            {
                string[] values = input.Split(',');
                int[] numbers = Array.ConvertAll<string, int>(values, delegate (string s) { return Int32.Parse(s); });
                int result = triFibonacci.Complete(numbers);
                Console.WriteLine(result);
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}