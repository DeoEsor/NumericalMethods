using System;
namespace NumericalMethodsLib
{
	public static partial class Methods
	{
		public static double[,] invert_matrix(double[,] a)
		{
			double det, temp;

			det = a[0, 0] * a[1, 1] - a[0, 1] * a[1, 0];
			temp = a[0, 0];
			a[0, 0] = a[1, 1] / det;
			a[1, 1] = temp / det;
			a[1, 0] = -a[1, 0] / det;
			a[0, 1] = -a[0, 1] / det;
			return a;
		}
		
		public static class NewtonsMethod
		{
			/// <summary>
			/// Analytical interpretation of Newton Method
			/// </summary>
			/// <param name="x"> - x coordinate of the point in the neighborhood where the solution is located </param>
			/// <param name="y"> - y coordinate of the point in the neighborhood where the solution is located</param>
			/// <param name="eps"> - error rate</param>
			/// <param name="x_result"> - x coor. of root</param>
			/// <param name="y_result"> - y coor. of root</param>
			/// <param name="iter"> - count of iterations</param>
			/// <param name="f"> - first original function</param>
			/// <param name="g"> - second original function</param>
			/// <param name="f_x"> - the derivative of <param name="f"></param> function by x</param>
			/// <param name="f_y"> - the derivative of <param name="f"></param> function by y</param>
			/// <param name="g_x"> - the derivative of <param name="g"></param> function by x</param>
			/// <param name="g_y"> - the derivative of <param name="g"></param> function by y</param>
			public static void Analytical
			(
				double x, double y,
				in double eps,
				ref double x_result, ref double y_result,
				ref long iter,
				Func<double, double, double> f,
				Func<double, double, double> g,
				Func<double, double, double> f_x,
				Func<double, double, double> f_y,
				Func<double, double, double> g_x,
				Func<double, double, double> g_y
			)
			{
				var i = 1;
				double dx, dy, norm;
				var b = new double[2];
				var a = new double[2, 2];
				iter = 0;
				do
				{
					a[0, 0] = f_x(x, y);
					a[0, 1] = f_y(x, y);
					a[1, 0] = g_x(x, y);
					a[1, 1] = g_y(x, y);
					invert_matrix(a);
					dx = -a[0, 0] * f(x, y) + -a[0, 1] * g(x, y);
					dy = -a[1, 0] * f(x, y) + -a[1, 1] * g(x, y);
					x = x + dx;
					y = y + dy;
					b[0] = f(x, y);
					b[1] = g(x, y);
					norm = Math.Sqrt(b[0] * b[0] + b[1] * b[1]);
					i++;
					iter++;
				} while (norm >= eps);
				x_result = x;
				y_result = y;
			}
			
			/// <summary>
			/// Numerical interpretation of Newton Method
			/// </summary>
			/// <param name="x"> - x coordinate of the point in the neighborhood where the solution is located </param>
			/// <param name="y"> - y coordinate of the point in the neighborhood where the solution is located</param>
			/// <param name="eps"> - error rate</param>
			/// <param name="x_result"> - x coor. of root</param>
			/// <param name="y_result"> - y coor. of root</param>
			/// <param name="iter"> - count of iterations</param>
			/// <param name="f"> - first original function</param>
			/// <param name="g"> - second original function</param>
			/// <param name="f11"></param>
			/// <param name="f12"></param>
			/// <param name="f21"></param>
			/// <param name="f22"></param>
			public static void Numerical
			(
				double x, double y,
				in double eps,
				ref double x_result, ref double y_result,
				ref long iter,
				Func<double, double, double> f,
				Func<double, double, double> g,
				Func<double, double, double> f11,
				Func<double, double, double> f12,
				Func<double, double, double> f21,
				Func<double, double, double> f22
			)
			{
				var i = 1;
				double dx, dy, norm;
				var b = new double[2];
				var a = new double[2, 2];
				iter = 0;
				do
				{
					a[0, 0] = f11(x, y);
					a[0, 1] = f12(x, y);
					a[1, 0] = f21(x, y);
					a[1, 1] = f22(x, y);
					invert_matrix(a);
					dx = -a[0, 0] * f(x, y) + -a[0, 1] * g(x, y);
					dy = -a[1, 0] * f(x, y) + -a[1, 1] * g(x, y);
					x = x + dx;
					y = y + dy;
					b[0] = f(x, y);
					b[1] = g(x, y);
					norm = Math.Sqrt(b[0] * b[0] + b[1] * b[1]);
					i++;
					iter++;
				} while (norm >= eps);
				x_result = x;
				y_result = y;
			}
		}
	}
}
