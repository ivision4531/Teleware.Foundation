using Teleware.Foundation.Util;
using Xunit;

namespace Teleware.Foundation.Core.Tests.Util
{
    public class UnitsTests
    {
        [Fact]
        public void SquaremeterToMuTest()
        {
            var sm = 10000;
            var expected = 15;
            var actual = Units.ToMu(sm);

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void MuToSquaremeterTest()
        {
            var mu = 15;
            var expected = 10000;
            var actual = Units.MuToSquareMeter(mu);

            Assert.Equal(expected, actual);
        }
    }
}