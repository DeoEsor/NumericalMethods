using System;
using System.ComponentModel;
using NumericalMethodsLib;
namespace NumericalMethods
{
	class NumericalMethods
	{
		private static readonly double Eps = 1e-5;
		static void Main(string[] args) => Lab4();

		#region Lab 4
		static double  Func ( double x ) => Math.Sin(x) / (1 + x * x);
		public static void Lab4()
		{
			double a = 0.0, b = 1;
			double res , prev ;
			long Count = 2 ;
			
			do
			{
				prev = NumericalMethodsLib.Methods.TrapezoidMethod(Func, a, b, Count *= 2);
				
				res = NumericalMethodsLib.Methods.TrapezoidMethod(Func, a, b, Count);
			} while ( Math.Abs( res - prev ) > Eps);
			
			Console.Out.Write($"Результат вычислений методом трапеций : \n\t интеграл - {NumericalMethodsLib.Methods.TrapezoidMethod(Func, a, b, Count *= 2)} \n\t число интервалов - {Count}");
			Count = 2;
			
			do 
			{
				prev = NumericalMethodsLib.Methods.SimpsonMethod( Func , a , b , Count *= 2);
				
				res = NumericalMethodsLib.Methods.SimpsonMethod( Func , a , b , Count );
			} while ( Math.Abs( res - prev ) > Eps);

			Console.Out.Write($"\nРезультат вычислений методом Симпсона : \n\t интеграл - {NumericalMethodsLib.Methods.SimpsonMethod( Func , a , b , Count *= 2 )} \n\t число интервалов - {Count}");

		}
  #endregion
	
		//Done
		#region Lab 1
		const double a1 = -1, b1 = 0, a2 = 2, b2 = 4;
		static double function(double x) => Math.Pow(MathF.E, x) - 6 * x - 3;
		static double diff_Func(double x) => Math.Pow(MathF.E, x) - 6;
		public static void Lab1()
		{
			ulong iter = 0;
			
			Console.Out.Write("Dichotomy method :\n");
			Console.Out.Write($"\tCount of iterations : \t {NumericalMethodsLib.Methods.Dichotomy(a1, b1, in Eps, ref iter, function)}" +
				$" \t Count of iterations {iter} \n");
			Console.Out.Write($"\tCount of iterations : \t {NumericalMethodsLib.Methods.Dichotomy(a2, b2, in  Eps, ref iter, function)}" +
				$" \t Count of iterations {iter} \n");
					
			Console.Out.Write( "Simple iterations method :\n");
			Console.Out.Write($"\tCount of iterations : \t { NumericalMethodsLib.Methods.Simple_iteration(a1, b1, in Eps, ref iter, function, diff_Func)} " +
				$"\t Count of iterations {iter} \n");
			Console.Out.Write($"\tCount of iterations : \t {NumericalMethodsLib.Methods.Simple_iteration(a2, b2, in Eps, ref iter, function, diff_Func)}" +  
				$" \t Count of iterations {iter} \n");
		}
  #endregion
		//Done
		#region Lab 2
		static double f(double x, double y) => Math.Pow(x,2) * Math.Pow(y,2) - 2 * Math.Pow(x,3) -5 * Math.Pow(y,3) + 10;

		static double g(double x, double y) => Math.Pow(x,4) - 8 * y + 1;
		
		
		static double func1_x_der(double x, double y) => 2 * x *Math.Pow(y,2) - 6 *Math.Pow(x,2);

		static double func1_y_der(double x, double y) => 2 * y *Math.Pow(x,2) - 15 *Math.Pow(y,2);

		static double func2_x_der(double x, double y) => 4 * Math.Pow(x,3);

		static double func2_y_der(double x, double y) => -8;


		static double func11_numerically(double x, double y) =>(1 / Eps) * (f(x + Eps, y) - f(x, y));

		static double func12_numerically(double x, double y) => (1 / Eps) * (f(x, y + Eps) - f(x, y));

		static double func21_numerically(double x, double y) => (1 / Eps) * (g(x + Eps, y) - g(x, y));

		static double func22_numerically(double x, double y) => (1 / Eps) * (g(x, y + Eps) - g(x, y));

		public static void Lab2()
		{
			double x1 = -1.7, y1 = 1.7;
			double x2 = 1, y2 = 0;
			double xResult = 0, yResult =0;
			long iter = 0;
			NumericalMethodsLib.Methods.NewtonsMethod.Analytical(x1, y1, Eps, ref xResult,ref yResult,ref iter, f,g,func1_x_der,func1_y_der,func2_x_der,func2_y_der);
			Console.Out.Write("Numerical method\n");
			Console.Out.Write($"Count of iterations: {iter} \n");
			Console.Out.Write($"\t x = {xResult} \n");
			Console.Out.Write($"\t y = {yResult} \n");
			NumericalMethodsLib.Methods.NewtonsMethod.Analytical(x2, y2, Eps, ref xResult,ref yResult,ref iter, f,g,func1_x_der,func1_y_der,func2_x_der,func2_y_der);
			Console.Out.Write($"Count of iterations: {iter} \n");
			Console.Out.Write($"\t x = {xResult} \n");
			Console.Out.Write($"\t y = {yResult} \n");
			NumericalMethodsLib.Methods.NewtonsMethod.Numerical(x1, y1, Eps, ref xResult,ref yResult,ref iter, f,g,func11_numerically,func12_numerically,func21_numerically,func22_numerically);
			Console.Out.Write("Analytical method\n");
			Console.Out.Write($"Count of iterations: {iter} \n");
			Console.Out.Write($"\t x = {xResult} \n");
			Console.Out.Write($"\t y = {yResult} \n");
			NumericalMethodsLib.Methods.NewtonsMethod.Numerical(x2, y2, Eps, ref xResult,ref yResult,ref iter,  f,g,func11_numerically,func12_numerically,func21_numerically,func22_numerically);
			Console.Out.Write($"Count of iterations: {iter} \n");
			Console.Out.Write($"\t x = {xResult} \n");
			Console.Out.Write($"\t y = {yResult} \n");
		}
		
  #endregion
		//Done
		#region Lab 3
		//static void Main(string[] args) => Lab3(ref A, ref B, 4);
		static  double[,] A = new double[4,4]{

			{3, 1, -1, 2},

			{-5, 1, 3, -4},

			{2, 0, 1, -1},

			{1, -5, 3, -3}

		};
		
		static double[] B = new double[4]{6, -12, 1, 3 };


		public static void Lab3( ref double[,] A, ref double[] B, int dimension)
		{
			double[] X = new double[dimension];
			
			Console.Out.Write("\t Matrix a \t\t\tMatrix b \n");
			for (int i = 0; i < dimension; i++)
			{
				for (int j = 0; j < dimension; j++) 
					Console.Out.Write($"{A[i,j]} \t");
				Console.Out.Write($"|\t {B[i]}\n");
			}

			
			Console.Out.Write(Console.Out.NewLine + "Gauss method :\n \tX : \n");
			NumericalMethodsLib.Methods.Gauss(ref A, ref B, ref X);
			for(int i=0; i< dimension; i++)
				Console.Out.Write($"\t{X[i]:G17}");
		}
  #endregion
	}
}

