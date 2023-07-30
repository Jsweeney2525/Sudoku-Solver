using System.Collections.Generic;

namespace Sudoku_Solver.SudokuBoard
{
    public class SudokuBoard
    {
        readonly List<CellSet> Rows = new List<CellSet>();
        readonly List<CellSet> Columns = new List<CellSet>();
        readonly List<CellSet> Blocks = new List<CellSet>();
        readonly List<CellSet> AllSets = new List<CellSet>();

        // test
        public SudokuBoard()
        {
            for (var i = 0; i < 9; ++i)
            {
                Rows.Add(new CellSet());
                Columns.Add(new CellSet());
                Blocks.Add(new CellSet());
            }

            AllSets.AddRange(Rows);
            AllSets.AddRange(Columns);
            AllSets.AddRange(Blocks);

            for (var i = 0; i < 81; ++i)
            {
                Cell cell = new Cell();

                Rows[i / 9].Cells.Add(cell);
                Columns[i % 9].Cells.Add(cell);

                // dividing by 27 will reduce the value to 0, 1, or 2.
                // Multiplying by 3 after (instead of dividing by 9) will get 0, 3, 6, which is correct
                var blockRowIndex = (i / 27) * 3;
                // dividing by 3 will reduce values to 0 - 26 in groups of 3 (same row, subsequent columns)
                // Then modding by 3 will get values 0, 1, or 2- which matches the column number for that grouping.
                var blockColumnIndex = (i / 3) % 3;

                Blocks[blockRowIndex + blockColumnIndex].Cells.Add(cell);
            }
        }

        public void Initialize(params short?[] values)
        {
            for (var i = 0; i < values.Length; ++i)
            {
                var rowIndex = i / 9;
                var value = values[i];
                Rows[rowIndex].Cells[i % 9].Value = value;
            }
        }
    }
}
