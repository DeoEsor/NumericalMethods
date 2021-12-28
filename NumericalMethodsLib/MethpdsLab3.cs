using System;
namespace NumericalMethodsLib
{
	public static partial class Methods
	{
	
	public static void Gauss( ref double[,] A, ref double[] B, ref double[] X)

		{
			int _xLength = X.Length;
			for (int index = 0; index < _xLength; index++)
			{
				double aii = A[index,index];
				B[index] /= aii;
				for (int column = 0; column < _xLength; column++)
					A[index,column] /= aii;

				for (int later_string = index + 1; later_string < _xLength; later_string++)
				{
					double same_column_member = A[later_string,index] / A[index, index];
					B[later_string] -= B[index] * same_column_member;
					for (int another_column = 0; another_column < _xLength; another_column++)
						A[later_string,another_column] -= A[index,another_column] * same_column_member;
				}
			}

			X[_xLength - 1] = B[_xLength - 1];
			

			for (int i = _xLength - 2; i >= 0; i--)
			{
				X[i] = B[i];
				for (int j = _xLength - 1; j > i; j--)
					X[i] -= A[i,j] * X[j];
				X[i] /= A[i,i];
			}
		}
	}
}