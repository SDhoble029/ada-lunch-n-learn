using NUnit.Framework;
using FluentAssertions;
using GameOfLife;

namespace GameOfLifeTests
{
    [TestFixture]
    public class Tests
    {

        [Test, TestCaseSource("GameOfLifeTestCases")]
        public void Test1(int[,] inputGrid, int[,] expectedOutputGrid)
        {
            var outputGrid = Program.GetNextGridState(inputGrid);
            Program.DisplayGrid(outputGrid);
            outputGrid.Should().Equal(expectedOutputGrid);
        }

        static object[] GameOfLifeTestCases = {
            new object[] { new int[,] { { 1, 1, 1, 1 }, { 0, 1, 1, 0 }, { 1, 1, 0, 0 } }, new int[,] { { 0, 1, 1, 0 }, { 1, 1, 1, 0 }, { 0, 1, 0, 0 } }},
            new object[] { new int[,] { { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 } }, new int[,] { { 1, 1, 1, 1 }, { 1, 0, 0, 1 }, { 1, 1, 1, 1 } }},
            new object[] { new int[,] { { } }, new int[,] { { } }},
        };
    }

  
}