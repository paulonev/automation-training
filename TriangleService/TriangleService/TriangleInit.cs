using System;

namespace TriangleServices
{
    public class TriangleInit
    {
        public int A { get; private set; }
        public int B { get; private set; }
        public int C { get; private set; }

        public TriangleInit(int x, int y, int z)
        {
            A = x;
            B = y;
            C = z;
        }

        public bool IsPossibleTriangle()
        {
            if (A==0 || B==0 || C==0) return false;
            else if(A+B>=C && A+C>=B && B+C>=A) return true;
            else return false;
        }
    }
}
