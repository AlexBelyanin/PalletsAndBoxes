using Xunit;

namespace TestBA.Tests
{
    public class BoxTests
    {
        [Theory]
        [InlineData(100, 49, 27, 132300)]
        public void VolumeSimpleValues(int width, int length, int height, long expected)
        {
            Box box = new Box(0, width, length, height, 0, new DateTime(), new DateTime());
            long actual = box.Volume;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ExpirationDateSimpleValueOfExpirationDate()
        {
            DateOnly expected = new DateOnly(2024, 2, 15);
            DateTime expirationDate = new DateTime(2024, 2, 15);

            Box box = new Box(0, 0, 0, 0, 0, expirationDate, new DateTime());
            DateOnly actual = box.ExpirationDate;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ExpirationDateSimpleValueOfProductionDate()
        {
            DateOnly expected = new DateOnly(2024, 4, 10);
            DateTime productionDate = new DateTime(2024, 1, 1);

            Box box = new Box(0, 0, 0, 0, 0, new DateTime(), productionDate);
            DateOnly actual = box.ExpirationDate;

            Assert.Equal(expected, actual);
        }
    }
}
