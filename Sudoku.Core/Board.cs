namespace Sudoku.Core
{
    using System;

    public class Board
    {
        byte[] data;
        byte rowLength = 9;
        byte columnLength = 9;

        public Board()
        {
            data = new byte[columnLength * rowLength];
        }

        public bool AddNewNumberIfValid(byte rowPos, byte columnPos, byte number)
        {
            if (IsNewNumberValid(rowPos, columnPos, number))
            {
                data[columnPos + (rowPos * rowLength)] = number;
                return true;
            }
            return false;
        }

        public bool IsNewNumberValid(byte rowPos, byte columnPos, byte number)
        {
            return  (data[columnPos + (rowPos * rowLength)] == 0) &&
                    IsRowValidCore((byte)(rowPos * rowLength), rowLength, number) &&
                    IsColumnValidCore((byte)(columnPos % columnLength), columnLength, rowLength, number) &&
                    IsGroupValid(GetGroup(rowPos, columnPos), number);
        }

        Tuple<byte, byte> GetGroup(byte rowPos, byte columnPos)
        {
            if (rowPos >= 6)
            {
                if (columnPos >= 6)
                {
                    return Tuple.Create<byte, byte>(6, 6);
                }
                if (columnPos >= 3)
                {
                    return Tuple.Create<byte, byte>(6, 3);
                }
                return Tuple.Create<byte, byte>(6, 0);
            }

            if (rowPos >= 3)
            {
                if (columnPos >= 6)
                {
                    return Tuple.Create<byte, byte>(3, 6);
                }
                if (columnPos >= 3)
                {
                    return Tuple.Create<byte, byte>(3, 3);
                }
                return Tuple.Create<byte, byte>(3, 0);
            }

            if (columnPos >= 6)
            {
                return Tuple.Create<byte, byte>(0, 6);
            }
            if (columnPos >= 3)
            {
                return Tuple.Create<byte, byte>(0, 3);
            }
            return Tuple.Create<byte, byte>(0, 0);
        }

        bool IsGroupValid(Tuple<byte, byte> groupPos, byte number)
        {
            byte rowGroupLength = 3;
            byte columnGroupLength = 3;

            var rowBegin = (byte)(groupPos.Item1 * rowLength);
            if (!IsRowValidCore(rowBegin, columnGroupLength, number)) return false;
            rowBegin += rowLength;
            if (!IsRowValidCore(rowBegin, columnGroupLength, number)) return false;
            rowBegin += rowLength;
            if (!IsRowValidCore(rowBegin, columnGroupLength, number)) return false;

            var columnBegin = groupPos.Item2;
            if (!IsColumnValidCore(columnBegin, columnGroupLength, rowGroupLength, number)) return false;
            columnBegin += 1;
            if (!IsColumnValidCore(columnBegin, columnGroupLength, rowGroupLength, number)) return false;
            columnBegin += 1;
            if (!IsColumnValidCore(columnBegin, columnGroupLength, rowGroupLength, number)) return false;

            return true;
        }

        bool IsRowValidCore(byte rowBegin, byte rowLength, byte number)
        {
            for (int i = rowBegin; i < rowBegin + rowLength; i++)
            {
                if (data[i] == number) return false;
            }

            return true;
        }

        bool IsColumnValidCore(byte columnBegin, byte columnLength, byte rowLength, byte number)
        {
            for (int i = columnBegin; i < columnBegin + (columnLength * rowLength); i = i + rowLength)
            {
                if (data[i] == number) return false;
            }

            return true;
        }
    }
}