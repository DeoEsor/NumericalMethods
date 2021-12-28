using System;
namespace NumericalMethodsLib.Exceptions
{
	
	public class NumericalMethodException : Exception
	{
		public string error;
		public NumericalMethodException(string _error)
		{
			error = _error;
		}
	}
}
