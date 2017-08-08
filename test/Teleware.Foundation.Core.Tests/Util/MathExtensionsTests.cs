using Teleware.Foundation.Util;
using Xunit;

namespace Teleware.Foundation.Core.Tests.Util
{
    public class MathExtensionsTests
    {
        [Fact]
        public void ToFixedDecimalTest()
        {
            var source = 1.2344M;
            var digits = 3;
            var expected = 1.234M;

            var actual = source.ToFixed(digits);
            Xunit.Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToFixedDecimalRoundTest()
        {
            var source = 1.2345M;
            var digits = 3;
            var expected = 1.235M;

            var actual = source.ToFixed(digits);
            Xunit.Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToFixedTruncateAllDigitsDecimalTest()
        {
            var source = 1.2344M;
            var digits = 0;
            var expected = 1M;

            var actual = source.ToFixed(digits);
            Xunit.Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToFixedDoubleTest()
        {
            var source = 1.2344;
            var digits = 3;
            var expected = 1.234;

            var actual = source.ToFixed(digits);
            Xunit.Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToFixedDoubleRoundTest()
        {
            var source = 1.2345;
            var digits = 3;
            var expected = 1.235;

            var actual = source.ToFixed(digits);
            Xunit.Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToFixedTruncateAllDigitDoubleTest()
        {
            var source = 1.2344;
            var digits = 0;
            var expected = 1;

            var actual = source.ToFixed(digits);
            Xunit.Assert.Equal(expected, actual);
        }
    }
}