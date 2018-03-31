namespace Sudoku.Core
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class Board
    {
        BoardStore data;
        byte rowLength = 9;
        byte columnLength = 9;

        public Board() => data = new BoardStore(rowLength, columnLength);

        public bool AddNewNumberIfValid(Point pos, byte number)
        {
            if (IsNewNumberValid(pos, number))
            {
                data.SetDataInPos(pos, number);
                return true;
            }
            return false;
        }

        public bool IsNewNumberValid(Point pos, byte number)
        {
            return (data.GetDataInPos(pos) == 0) &&
                    IsRowValidCore(new Point(pos.X, 0), columnLength, number) &&
                    IsColumnValidCore(new Point(0, pos.Y), rowLength, number) &&
                    IsGroupValid(GetGroup(pos), number);
        }

        Point GetGroup(Point pos)
        {
            var x = 0;
            if (pos.X >= 6) x = 6;
            if (pos.X >= 3) x = 3;

            var y = 0;
            if (pos.Y >= 6) y = 6;
            if (pos.Y >= 3) y = 3;

            return new Point(x, y);
        }

        IEnumerable<Point> GetRowsPoints(Point begin, byte columnLength) => Enumerable.Range(0, columnLength).Select(i => new Point(begin.X, begin.Y + i));

        IEnumerable<Point> GetColumnsPoints(Point begin, byte rowLength) => Enumerable.Range(0, rowLength).Select(i => new Point(begin.X + i, begin.Y));

        IEnumerable<Point> GetGroupPoints(Point groupPos)
        {
            byte rowGroupLength = 3;
            byte columnGroupLength = 3;

            return (
                from x in Enumerable.Range(groupPos.X, columnGroupLength)
                from y in Enumerable.Range(groupPos.Y, rowGroupLength)
                select new Point(x, y)
                );
        }

        bool AreDataInPointsValid(IEnumerable<Point> points, byte number) => points.Select(data.GetDataInPos).All(n => n != number);

        bool IsGroupValid(Point groupPos, byte number) => AreDataInPointsValid(GetGroupPoints(groupPos), number);

        bool IsRowValidCore(Point begin, byte columnLength, byte number) => AreDataInPointsValid(GetRowsPoints(begin, columnLength),number);

        bool IsColumnValidCore(Point begin, byte rowLength, byte number) => AreDataInPointsValid(GetColumnsPoints(begin, rowLength), number);
    }
}