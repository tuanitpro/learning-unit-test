using System;
using Xunit;
using Core;
namespace Core.UnitTests
{
    public class LogAnalyzerTests
    {
        [Fact]
        public void IsValidFileName_BadExtension_ReturnFalse()
        {
            // Arrange
            string fileName = "babfileextension.foo";
            var logAnalyzer = new LogFileAnalyzer();

            // Act
            var actualResult = logAnalyzer.IsValidLogFileName(fileName);

            // Assert
            Assert.False(actualResult);
        }

        [Fact]
        public void IsValidLogFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            // Arrange
            string fileName = "goodfileextension.slf";
            var logAnalyzer = new LogFileAnalyzer();

            // Act
            var actualResult = logAnalyzer.IsValidLogFileName(fileName);

            // Assert
            Assert.True(actualResult);
        }

        [Fact]
        public void IsValidLogFileName_GoodExtensionUppercase_ReturnsTrue()
        {
            // Arrange
            string fileName = "goodfileextension.SLF";
            var logAnalyzer = new LogFileAnalyzer();

            // Act
            var actualResult = logAnalyzer.IsValidLogFileName(fileName);

            // Assert
            Assert.True(actualResult);
        }

        [Theory]
        [InlineData("file1.slf")]
        [InlineData("file2.SLF")]
        public void IsValidLogFileName_ValidExtensions_ReturnsTrue(string fileName)
        {
            // Arrange
            var logAnalyzer = new LogFileAnalyzer();

            // Act
            var actualResult = logAnalyzer.IsValidLogFileName(fileName);

            // Assert
            Assert.True(actualResult);
        }

        [Theory]
        [InlineData("filewithgoodextension.SLF", true)]
        [InlineData("filewithgoodextension.slf", true)]
        [InlineData("filewithbadextension.foo", false)]
        public void IsValidLogFileName_VariousExtensions_ChecksThem(string fileName, bool expected)
        {
            // Arrange
            var logAnalyzer = new LogFileAnalyzer();

            // Act
            var actualResult = logAnalyzer.IsValidLogFileName(fileName);

            // Assert
            Assert.Equal(expected, actualResult);
        }

        [Fact]
        public void IsValidFileName_EmptyFileName_Throws()
        {
            // Arrange
            string fileName = string.Empty;
            var logAnalyzer = new LogFileAnalyzer();

            // Act
            var ex = Assert.Throws<ArgumentException>(() => logAnalyzer.IsValidLogFileName(fileName));

            // Assert
            Assert.Equal("filename has to be provided", ex.Message);
        }
    }
}