using System.Collections;
using System.Linq;
using Teleware.Foundation.Collections;
using Xunit;

namespace Teleware.Foundation.Core.Tests.Collections
{
    public class EnumerableExtensionsTests
    {
    }

    public class PartitionTests
    {
        [Fact]
        public void TestPartitionToOneSection()
        {
            var source = Enumerable.Range(0, 100).ToArray();
            var expected = 1;
            int actual;

            var partition = new Partition<int>(source, source.Length);
            actual = partition.Count();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestPartitionToTwoSections()
        {
            var source = Enumerable.Range(0, 100).ToArray();
            var expected = 2;
            int actual;

            var partition = new Partition<int>(source, source.Length - 10);
            actual = partition.Count();

            Assert.Equal(expected, actual);
        }
    }

    public class PartitionSectionTests
    {
        [Fact]
        public void TestCreateSectionWithSufficientDatas()
        {
            var source = Enumerable.Range(0, 100).ToArray();
            var from = 0;
            var size = 10;

            var expected = size;
            int actual;

            var section = new PartitionSection<int>(source, from, size);
            actual = section.Count();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestEnumerateWithInsufficientDatas()
        {
            var source = Enumerable.Range(0, 5).ToArray();
            var from = 0;
            var size = 10;

            var expected = source.Length;
            int actual;

            var section = new PartitionSection<int>(source, from, size);
            actual = section.Count();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCreateSectionWithSufficientDatas2()
        {
            var source = Enumerable.Range(0, 100).ToArray();
            var from = 90;
            var size = 10;

            var expected = size;
            int actual;

            var section = new PartitionSection<int>(source, from, size);
            actual = section.Count();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestEnumerateWithInsufficientDatas2()
        {
            var source = Enumerable.Range(0, 100).ToArray();
            var from = 95;
            var size = 10;

            var expected = source.Length - from;
            int actual;

            var section = new PartitionSection<int>(source, from, size);
            actual = section.Count();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNonGenericEnumerator()
        {
            var source = Enumerable.Range(0, 100).ToArray();
            var from = 0;
            var size = 10;

            var expected = size;
            var actual = 0;

            var section = new PartitionSection<int>(source, from, size);

            var enumerator = (section as IEnumerable).GetEnumerator();
            while (enumerator.MoveNext())
            {
                actual++;
            }
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGenericEnumerator()
        {
            var source = Enumerable.Range(0, 100).ToArray();
            var from = 0;
            var size = 10;

            var expected = size;
            var actual = 0;

            var section = new PartitionSection<int>(source, from, size);

            var enumerator = section.GetEnumerator();
            while (enumerator.MoveNext())
            {
                actual++;
            }
            Assert.Equal(expected, actual);
        }
    }
}