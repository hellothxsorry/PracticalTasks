using PracticalTasks;
using Xunit;

namespace PracticalTasksTests
{
    public class ProgramTests
    {
        [Theory]
        [InlineData("aaayywbnL", 5)]
        [InlineData(" ", 0)]
        [InlineData("391807", 6)]
        [InlineData("WWLO", 3)]
        [InlineData("vRtKmJHnY", 9)]
        [InlineData("!q* ~%@(", 7)]
        [InlineData("", 0)]
        public void MaxUnequalCharsTest(string line, int expected)
        {
            Assert.Equal(expected, Program.MaxUnequalChars(line));
        }

        [Theory]
        [InlineData("1e2r77u", 1)]
        [InlineData("wwwswwfwaww", 3)]
        [InlineData("KkKkt3t", 4)]
        [InlineData(" ", 0)]
        [InlineData("u uu", 2)]
        [InlineData("", 0)]
        [InlineData("!!!^^?-", 0)]
        public void MaxIdenticalLettersTest(string input, int expected)
        {
            Assert.Equal(expected, Program.MaxIdenticalLetters(input));
        }

        [Theory]
        [InlineData("r15Es77777Olrr59990T3333Hjj", 5)]
        [InlineData("LKlyyyH", 0)]
        [InlineData("", 0)]
        [InlineData("0918726453", 1)]
        [InlineData(" ", 0)]
        [InlineData("-55!!! 7*g1", 2)]
        public void MaxIdenticalDigitsTest(string line, int expected)
        {
            Assert.Equal(expected, Program.MaxIdenticalDigits(line));
        }
    }
}