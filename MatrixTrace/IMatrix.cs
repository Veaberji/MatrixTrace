using System.Collections.Generic;

namespace MatrixTrace
{
    public interface IMatrix
    {
        int GetSize(MatrixSize size);
        int[,] FillMatrix();
        int Trace();
        List<int> Snake();
    }
}