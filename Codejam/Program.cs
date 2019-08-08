using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    class NoPointSegment
    {
        int x1, y1, x2, y2, x3, y3, x4, y4;
        public string Intersection(int[] X, int[] Y)
        {
            x1 = X[0];
            y1 = X[1];
            x2 = X[2];
            y2 = X[3];
            x3 = Y[0];
            y3 = Y[1];
            x4 = Y[2];
            y4 = Y[3];
            
            if (isIntersecting() == "Yes")
                return "POINT";
            else if (isOverlapping() == "Yes")
                return "SEGMENT";
            else
                return "NO";
        }
        public String isParallel()
        {
            if (((y1 == y2) && (y3 == y4)) || ((x1 == x2) && (x3 == x4)))
                return "Yes";
            else
                return "No";
        }

        public String isPerpendicular()
        {
            if (((y1 == y2) && (x3 == x4)) || ((x1 == x2) && (y3 == y4)))
                return "Yes";
            else
                return "No";
        }

        public String isIntersecting()
        {
            if (isPerpendicular() == ("Yes"))
            {
                if ((y1 == y2) && (x3 >= Math.Min(x1, x2) && x3 <= Math.Max(x1, x2)) && (y1 >= Math.Min(y3, y4) && y1 <= Math.Max(y3, y4)))
                {
                    return "Yes";
                }
                else if ((x1 == x2) && (y3 >= Math.Min(y1, y2) && y3 <= Math.Max(y1, y2)) && (x1 >= Math.Min(x3, x4) && x1 <= Math.Max(x3, x4)))
                {
                    return "Yes";
                }
            }
            //if (isParallel()==("Yes"))
            else
            {
                if (y1 == y3)
                {
                    if ((((Math.Min(x3, x4) == Math.Max(x1, x2)) && (Math.Max(x3, x4) > Math.Max(x1, x2)))) || ((Math.Min(x1, x2) == Math.Max(x3, x4)) && (Math.Max(x1, x2) > Math.Max(x3, x4))))
                        return "Yes";
                    else if (((x1 == x2) && (y1 == y2)) || ((x3 == x4) && (y3 == y4)))
                        return "Yes";
                }
                if (x1 == x3)
                {
                    if (((Math.Min(y3, y4) == Math.Max(y1, y2)) && (Math.Max(y3, y4) > Math.Max(y1, y2))) || ((Math.Min(y1, y2) == Math.Max(y3, y4)) && (Math.Max(y1, y2) > Math.Max(y3, y4))))
                        return "Yes";
                    else if (((x1 == x2) && (y1 == y2)) || ((x3 == x4) && (y3 == y4)))
                        return "Yes";
                }
                    return "No";
            }
             
            return "No";
        }

        public String isOverlapping()
        {
            if (isParallel()==("Yes"))
            {
                if (y1 == y3)
                {
                    if ((Math.Min(x3, x4) >= Math.Min(x1, x2)) && (Math.Min(x3, x4) <= Math.Max(x1, x2)) || (Math.Min(x1, x2) >= Math.Min(x3, x4)) && (Math.Min(x1, x2) <= Math.Max(x3, x4)))
                        return "Yes";
                }
                else if (x1 == x3)
                {
                    if ((Math.Min(y3, y4) >= Math.Min(y1, y2)) && (Math.Min(y3, y4) <= Math.Max(y1, y2)) || (Math.Min(y1, y2) >= Math.Min(y3, y4)) && (Math.Min(y1, y2) <= Math.Max(y3, y4)))
                        return "Yes";
                }
            }
            return "No";
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            string input = Console.ReadLine();
            NoPointSegment solver = new NoPointSegment();
            do
            {
                var segments = input.Split('|');
                var segParts = segments[0].Split(',');
                var seg1 = new int[4] { int.Parse(segParts[0]), int.Parse(segParts[1]), int.Parse(segParts[2]), int.Parse(segParts[3]) };
                segParts = segments[1].Split(',');
                var seg2 = new int[4] { int.Parse(segParts[0]), int.Parse(segParts[1]), int.Parse(segParts[2]), int.Parse(segParts[3]) };
                Console.WriteLine(solver.Intersection(seg1, seg2));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}