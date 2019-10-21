using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            //Arrange
            var parserInstance = new TacoParser();
            var lines = "34.992219,-86.841402,Taco Bell Ardmore...";

            //Assert
            Assert.NotNull(parserInstance.Parse(lines));
        }

        [Theory]
        [InlineData("34.280205,-86.217115,Taco Bell Albertvill...", "Taco Bell Albertvill...")]
        [InlineData("34.992219,-86.841402,Taco Bell Ardmore...", "Taco Bell Ardmore...")]
        [InlineData("90,180,Taco Bell", "Taco Bell")]
        [InlineData("-90, -180,Taco Bell", "Taco Bell")]
        [InlineData("0, 0,Taco bell", "Taco bell")]
        public void ShouldParseName(string data, string expected)
        {
            // Arrange
            TacoParser location = new TacoParser();

            // Act
            ITrackable actual = location.Parse(data);

            // Assert
            Assert.Equal(expected, actual.Name);
        }

        [Theory]
        [InlineData("34.280205,-86.217115,Taco Bell Albertvill...", 34.280205)]
        [InlineData("34.992219,-86.841402,Taco Bell Ardmore...", 34.992219)]
        [InlineData("90, 180, Taco Bell", 90)]
        [InlineData("-90, -180, Taco Bell", -90)]
        [InlineData("0, 0, Taco bell", 0)]

        public void ShouldParseLatitude(string data, double expected)
        {
            // Arrange
            TacoParser location = new TacoParser();

            // Act
            ITrackable actual = location.Parse(data);

            // Assert
            Assert.Equal(expected, actual.Location.Latitude);
        }

        [Theory]
        [InlineData("34.280205,-86.217115,Taco Bell Albertvill...", -86.217115)]
        [InlineData("34.992219,-86.841402,Taco Bell Ardmore...", -86.841402)]
        [InlineData("90, 180, Taco Bell", 180)]
        [InlineData("-90, -180, Taco Bell", -180)]
        [InlineData("0, 0, Taco bell", 0)]

        public void ShouldParseLongitude(string data, double expected)
        {
            // Arrange
            TacoParser location = new TacoParser();

            // Act
            ITrackable actual = location.Parse(data);

            // Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("90, 90")]
        [InlineData("90, TacoBell")]
        [InlineData("TacoBell")]
        public void ShouldFailParse(string str)
        {
            // Arrange
            TacoParser Location = new TacoParser();

            // Act
            ITrackable actual = Location.Parse(str);

            // Assert
            Assert.Null(actual);
        }
    }
}