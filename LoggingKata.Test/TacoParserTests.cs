using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("33.470013,-86.816966,Taco Bell Birmingham...", -86.816966)]
        [InlineData("34.342547,-86.307539,Taco Bell Guntersvill...", -86.307539)]
        [InlineData("32.637154,-85.41445,Taco Bell Opelik...", -85.41445)]
        [InlineData("33.796264,-84.224516,Taco Bell Stone Mountain...", -84.224516)]
        [InlineData("34.113051,-84.56005,Taco Bell Woodstoc...", -84.56005)]
        
        //test for correct longitude
        public void ShouldParseLongitude(string line, double expected)
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            string[] splitTacoBell = line.Split(',');
            var longitude = splitTacoBell[1];
            var actual = Convert.ToDouble(longitude);

            //Assert
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("33.470013,-86.816966,Taco Bell Birmingham...", 33.470013)]
        [InlineData("34.342547,-86.307539,Taco Bell Guntersvill...", 34.342547)]
        [InlineData("32.637154,-85.41445,Taco Bell Opelik...", 32.637154)]
        [InlineData("33.796264,-84.224516,Taco Bell Stone Mountain...", 33.796264)]
        [InlineData("34.113051,-84.56005,Taco Bell Woodstoc...", 34.113051)]
        
        //test for correct latitude
        public void ShouldParseLatitude(string line, double expected)
        {
            var tacoParser = new TacoParser();
            
            string[] splitTacoBell = line.Split(',');
            var latitude = splitTacoBell[0];
            var actual = Convert.ToDouble(latitude);
            
            Assert.Equal(expected, actual);
        }
    }
}
