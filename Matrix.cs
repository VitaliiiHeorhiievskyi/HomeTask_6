using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_6
{
    class Matrix : IEnumerator, IEnumerable
    {
        private double[,] array;

        public double[,] Array
        {
            get
            {
                return array;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                array = value;
            }
        }

        public double this[int row, int column]
        {
            get
            {
                if (row > Array.GetLength(0) || column > Array.GetLength(1))
                    throw new IndexOutOfRangeException();

                return Array[row, column];
            }
            set
            {
                if (row > Array.GetLength(0) || column > Array.GetLength(1))
                    throw new IndexOutOfRangeException();

                Array[row, column] = value;
            }
        }

        private int positionRow = -1;

        private int positionColumn = -1;

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            if (positionColumn == -1 && positionRow == -1)
                Reset();

            positionColumn--;

            if (positionColumn < 0 && positionRow > 0)
            {
                positionRow--;
                positionColumn = Array.GetLength(1) - 1;
            }


            return (positionColumn >= 0 && positionRow >= 0);
        }

        public void Reset()
        {
            positionRow = Array.GetLength(0) - 1;
            positionColumn = Array.GetLength(1);
        }

        public object Current
        {
            get { return Array[positionRow, positionColumn]; }
        }

    }
}
