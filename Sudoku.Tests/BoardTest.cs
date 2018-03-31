using System;
using System.Drawing;
using Xunit;

namespace Sudoku.Tests
{
    public class BoardTest
    {
        [Fact]
        public void TestRowValidation_FailsIfHasTwoColumnsFilledInTheSameRow()
        {
            var board = new Sudoku.Core.Board();
            Assert.True(board.AddNewNumberIfValid(new Point(1,0), 1));
            Assert.False(board.AddNewNumberIfValid(new Point(1,1), 1));
        }

        [Fact]
        public void TestRowValidation_FailsIfHasTwoRowsFilledInTheSameColumn()
        {
            var board = new Sudoku.Core.Board();
            Assert.True(board.AddNewNumberIfValid(new Point(1,1), 1));
            Assert.False(board.AddNewNumberIfValid(new Point(2,1), 1));
        }

        [Fact]
        public void TestRowValidation_FailsIfHasTwoEqualValuesInTheSameGroup()
        {
            var board = new Sudoku.Core.Board();
            Assert.True(board.AddNewNumberIfValid(new Point(1,0), 1));
            Assert.False(board.AddNewNumberIfValid(new Point(2,1), 1));
        }

        [Fact]
        public void TestRowValidation_OKIfHasTwoColumnsFilledInDiferentRowsAndDiferentGroups()
        {
            var board = new Sudoku.Core.Board();
            Assert.True(board.AddNewNumberIfValid(new Point(1,0), 1));
            Assert.True(board.AddNewNumberIfValid(new Point(5,1), 1));
        }

         [Fact]
        public void TestRowValidation_FailsIfSetANumberInACellWithANumberAlreadySetted()
        {
            var board = new Sudoku.Core.Board();
            Assert.True(board.AddNewNumberIfValid(new Point(1,0), 1));
            Assert.False(board.AddNewNumberIfValid(new Point(1,0), 1));
        }
    }
}
