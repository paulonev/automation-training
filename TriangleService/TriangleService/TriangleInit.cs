//using System;
using TriangleServices.Exceptions;

namespace TriangleServices
{
    public class TriangleInit
    {
        public int A { get; private set; }
        public int B { get; private set; }
        public int C { get; private set; }

        public TriangleInit(int x, int y, int z)
        {
            if(x<0 || y<0 || z<0) throw new NegativeValueOfSideException("Negative side...");
            A = x;
            B = y;
            C = z;
        }

        public bool IsPossibleTriangle()
        {
            if(A+B>C && A+C>B && B+C>A) return true;
            else return false;
        }
    }
}
