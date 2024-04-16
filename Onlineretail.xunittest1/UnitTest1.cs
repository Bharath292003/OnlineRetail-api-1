using System.ComponentModel;

namespace Onlineretail.xunittest1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int a = 1;
            int b = 5; 
            Assert.Equal(6,add(1,5));

        }
        [Theory]
        [InlineData(1,1,2)]
        [InlineData(2,2,4)]
        [InlineData(3,3,6)]
        public void testMultipleInput(int x,int y,int expect)
        {
            Assert.Equal(expect, add(x, y));
        }
        int add(int x,int y)
        {
            return x + y;
        }
    }
}