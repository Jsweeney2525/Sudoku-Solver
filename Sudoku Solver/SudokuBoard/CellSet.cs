using System.Collections.Generic;
using System.Linq;

namespace Sudoku_Solver.SudokuBoard
{
    /// <summary>
    /// Represents a Row, Column, or Block of cells,
    /// that is a set of 9 cells.
    /// </summary>
    public class CellSet
    {
        public List<Cell> Cells = new List<Cell>();

        public bool IsFull()
        {
            return Cells.TrueForAll(c => c.Value.HasValue);
        }

        public bool IsValid()
        {
            bool ret = true;

            for (var i = 1; i < 10; ++i)
            {
                ret &= Cells.Count(c => c.Value == i) == 1;
            }

            return ret;
        }
    }
}
