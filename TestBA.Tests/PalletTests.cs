using Xunit;

namespace TestBA.Tests
{
    public class PalletTests
    {
        [Fact]
        public void AddSimpleValue()
        {
            Pallet pallet = new Pallet();
            pallet.Add(new Box(0, 0, 0, 0, 0, new DateTime(2024, 10, 10), new DateTime()));

            Assert.True(pallet.Count == 1);
        }

        [Fact]
        public void VolumeSimpleValue()
        {
            long expected = 16942591;

            List<Box> boxes = new List<Box>() { new Box(0, 125, 27, 49, 0, new DateTime(2024, 10, 10), new DateTime()) };
            Pallet pallet = new Pallet(0, 256, 256, 256, boxes);
            long actual = pallet.Volume;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(15.25, 45.25)]
        [InlineData(double.MaxValue, double.MaxValue)]
        public void WeightSimpleValues(double boxWeight, double expected)
        {
            List<Box> boxes = new List<Box>() { new Box(0, 0, 0, 0, boxWeight, new DateTime(2024, 10, 10), new DateTime()) };
            Pallet pallet = new Pallet(0, 256, 256, 256, boxes);
            double actual = pallet.Weight;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ExpirationDateSimpleValue()
        {
            DateOnly expected = new DateOnly(2024, 10, 10);

            List<Box> boxes = new List<Box>() { new Box(0, 0, 0, 0, 0, new DateTime(2024, 10, 10), new DateTime()), 
                new Box(0, 0, 0, 0, 0, new DateTime(2024, 10, 11), new DateTime()) };
            Pallet pallet = new Pallet(0, 256, 256, 256, boxes);
            DateOnly actual = pallet.ExpirationDate;

            Assert.Equal(expected, actual);
        }
    }
}
