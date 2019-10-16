using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything
        }

        [Theory]
        [InlineData("34.280205,-86.217115,Taco Bell Albertvill...")]
        [InlineData("34.992219,-86.841402,Taco Bell Ardmore...")]
        [InlineData("90 , 180, Taco Bell")]
        [InlineData("-90, -180, Taco Bell ")]
        [InlineData("0, 0, Taco bell")]
        public void ShouldParse(string str)
        {
            // TODO: Complete Should Parse
            // Arrange
            TacoParser location = new TacoParser();

            // Act
            ITrackable actual = location.Parse(str);

            // Assert
            Assert.NotNull(actual);
            Assert.NotNull(actual.Name);
            Assert.NotNull(actual.Location);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("90, 90")]
        [InlineData("90, TacoBell")]
        [InlineData("TacoBell")]
        public void ShouldFailParse(string str)
        {
            // TODO: Complete Should Fail Parse
            // Arrange
            TacoParser Location = new TacoParser();

            // Act
            ITrackable actual = Location.Parse(str);

            // Assert
            Assert.Null(actual);
        }
    }
}