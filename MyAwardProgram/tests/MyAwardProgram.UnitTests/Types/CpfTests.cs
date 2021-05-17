using MyAwardProgram.Shared.Types;
using System;
using Xunit;

namespace MyAwardProgram.UnitTests.Types
{
    public class CpfTests
    {
        [Theory]
        [InlineData("872.491.850-47", "872.491.850-47", "872.491.850-47")]
        [InlineData("87249185047", "87249185047", "872.491.850-47")]
        public void ValidCpf_Tests(string input, string expectedResult, string expectedFormatResult)
        {
            //Arrange
            CPF value = input;

            var result = value.ToString();
            var resultFormat = value.ToFormattedString();

            Assert.Equal(expectedResult, result);
            Assert.Equal(expectedFormatResult, resultFormat);
        }

        [Theory]
        [InlineData("  ")]
        [InlineData("00000")]
        [InlineData("~355")]
        public void InvalidCpf_Tests(string input)
        {
            CPF value = null;
            Action act = () => value = input;

            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal($"String '{input}' was not recognized as a valid CPF.", exception.Message);
        }
    }
}
