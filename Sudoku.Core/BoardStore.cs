using System.Drawing;

namespace Sudoku.Core
{
    public class BoardStore
    {
        byte[] data;
        int rowLength;
        
        public BoardStore(int rowLength, int columnLength)
        {
            this.rowLength = rowLength;
            data = new byte[rowLength * columnLength];
        }

        public byte GetDataInPos(Point point)
        {
            return data[(point.X * rowLength) + point.Y];
        }

        public void SetDataInPos(Point point, byte number)
        {
            data[(point.X * rowLength) + point.Y] = number;
        }
    }
}