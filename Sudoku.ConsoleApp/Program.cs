using System;

namespace Sudoku.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Sudoku.Core.Board();
            var result1 = board.AddNewNumberIfValid(0,0, 1);
            var result2 = board.AddNewNumberIfValid(0,1, 1);
            var result3 = board.AddNewNumberIfValid(1,1, 1);
 
        }
    }
}
