using System;

namespace TriangleServices.Exceptions
{
    public class NegativeValueOfSideException : Exception
    {
        public NegativeValueOfSideException()
            : base()
        {}
        public NegativeValueOfSideException(string message)
            : base(message)
        {}
    }
}
