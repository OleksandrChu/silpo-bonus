using Xunit;

namespace SilpoBonusCore.Tests
{
    public class CheckTest
    {
        [Fact]
        public void Sum_of_twos_returns_four()
        {
            // Act
            int sum = DumbService.Sum(1, 1);

            // Assert
            Assert.Equal(2, sum);
        }
    }
}