namespace Sudoku.Core
{
    public class Board
    {
        byte[] data;
        byte rowLength = 9;
        byte columnLength = 9;
        public Board()
        {
            data = new byte[columnLength*rowLength];
        }

        public bool AddNewNumberIfValid(byte x, byte y, byte number)
        {
            if(IsNewNumberValid(x, y, number))
            {
                data[x+(y * rowLength)] = number;
                return true;
            }    
            return false;
        }

        public bool IsNewNumberValid(byte x, byte y, byte number)
        {
            return IsRowValid((byte)(y * rowLength), number); 
        }

        bool IsRowValid(byte rowBegin, byte number)
        {
            for(int i = rowBegin; i < rowBegin + rowLength; i++)
            {
                if(data[i] == number) return false;
            }

            return true;
        }

        bool IsColumnValid(byte columnBegin, byte number)
        {
            for(int i = columnBegin; i < columnBegin + columnLength; i = i + rowLength)
            {
                if(data[i] == number) return false;
            }

            return true;
        }
    }
}