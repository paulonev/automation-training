using NUnit.Framework;
using TriangleServices; 

namespace TriangleServices.Tests
{
    [TestFixture]
    public class TriangleService_IsPossibleTriangle
    {
        [Test]
        public void IsPossible_withSides7_10_5_expectTrue()
        {
            TriangleInit tr1 = new TriangleInit(7,10,5);
            Assert.AreEqual(tr1.IsPossibleTriangle(), true);
        }
        
        [Test]
        public void IsPossible_withNegativeSide_expectFalse()
        {
            TriangleInit tr1 = new TriangleInit(-7,10,5);
            Assert.AreEqual(tr1.IsPossibleTriangle(), false);
        }
        
        [Test]
        public void IsPossible_withEqualSides_expectTrue()
        {
            TriangleInit tr1 = new TriangleInit(7,7,7);
            Assert.AreEqual(tr1.IsPossibleTriangle(), true);
        }

        [Test]
        public void IsPossible_withOneSizeAsZero_expectFalse()
        {
            TriangleInit tr1 = new TriangleInit(7,10,0);
            Assert.AreEqual(tr1.IsPossibleTriangle(), false);
        }
    }
}