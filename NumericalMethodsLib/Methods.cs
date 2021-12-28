using System;
using System.Collections.Generic;
using NumericalMethodsLib.Exceptions;

namespace NumericalMethodsLib
{
	
	public static partial class Methods
	{
		
		/// <summary>
		/// The dichotomy method allows you to find the zero of a monotone function f(x) on the segment 
		/// [left border, right border], if the function values have different signs at the ends of this segment.
		/// </summary>
		/// <typeparam name="double">a numerical type</typeparam>
		/// <param name="a"> - left border</param>
		/// <param name="b"> - right border</param>
		/// <param name="eps"> - accuracy of result</param>
		/// <param name="iter"> - a reference to the variable that count steps of method</param>
		/// <param name="function"> - a reference to the function to which this method will be applied</param>
		/// <returns>The root</returns>
		public static double Dichotomy(double a, double b, in double  eps, ref ulong iter, Func<double, double> function)
		{
			iter = 0;
			if (function(a) * function(b) > 0) throw new NumericalMethodException("Incorrect borders");

			double x = (a + b) / 2;

			while (Math.Abs(b - a) > eps)
			{
				if (function(a) * function(x) < 0) b = x; else a = x;

				x = (a + b) / 2;
				iter++;
			}

			return x;
		}
		
		/// <summary>
		/// The simple iteration method is a one-step iterative process
		/// </summary>
		/// <typeparam name="double">a numerical type</typeparam>
		/// <param name="function"></param>
		/// <param name="dif_function"></param>
		/// <param name="a"> - left border</param>
		/// <param name="b"> - right border</param>
		/// <param name="eps"> - accuracy of result</param>
		/// <param name="iter"> - a reference to the variable that count steps of method</param>
		/// <param name="function"> - a reference to the function to which this method will be applied</param>
		/// <param name="diff_function"> - a reference to the derivative of the function to which this method is applied</param>
		/// <returns>The root</returns>
		/// 
		public static double Simple_iteration(double a, double b, in double  eps, ref ulong iter, Func<double, double> function,  Func<double, double> diff_function)
		{

			iter = 0;
			int  sign = (diff_function(a) < 0) ? -1 : 1;

			double t = 2 / Math.Abs(diff_function(a) + diff_function(b)),
				x = b;

			while (Math.Abs(function(x)) > eps)
			{
				x -=  sign * t * function(x);
				iter++;
			}

			return x;
		}
	}
}
