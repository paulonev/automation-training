using NUnit.Framework;
using TriangleServices.Exceptions;

namespace TriangleServices.Tests
{
    [TestFixture]
    public class TriangleService_IsPossibleTriangle
    {
        [TestCase(7,10,5)]
        [TestCase(3,4,5)]
        [TestCase(6,8,10)]
        public void IsPossible_Triangle(int s1, int s2, int s3)
        {
            TriangleInit tr1 = new TriangleInit(s1,s2,s3);
            Assert.AreEqual(tr1.IsPossibleTriangle(), true);
        }
        
        [TestCase(3,3,1)]
        [TestCase(5,5,0)]
        [TestCase(0,0,1)]
        [TestCase(7,7,7)]
        [TestCase(0,0,0)]
        public void IsPossible_comboSides_Triangle(int t1,int t2, int t3)
        {
            TriangleInit tr1 = new TriangleInit(t1,t2,t3);
            if(t1 == 0 || t2 ==0 || t3 == 0){
                Assert.False(tr1.IsPossibleTriangle());
            }
            else Assert.True(tr1.IsPossibleTriangle());
        }
           
        [TestCase(3,-1,3)]
        [TestCase(-5,-5,1)]
        public void IsPossible_Triangle_exception(int g1, int g2, int g3)
        {
            var ex = Assert.Throws<NegativeValueOfSideException>(()=> new TriangleInit(g1,g2,g3));
            Assert.That(ex.Message == "Negative side...");
        }
    }
}