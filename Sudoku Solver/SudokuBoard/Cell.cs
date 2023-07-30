using System.Collections.Generic;

namespace Sudoku_Solver.SudokuBoard
{
    public class Cell
    {
        private short? _value;
        public short? Value {
            get => _value; 
            set {
                PotentialValues.Clear();
                _value = value;
            }
        }

        public List<short> PotentialValues { get; protected set; }

        public Cell()
        {
            PotentialValues = new List<short> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }
    }
}
