using System;
namespace NumericalMethodsLib
{
	public static partial class Methods
	{
		public static double TrapezoidMethod(Func<double,double> f, double a , double b ,long n ) 
		{
			double sum = 0.0 , step;
			uint i ;
			if (n == 0 ) return sum;
			step = ( b - a ) / ( 1.0 * n ) ;
			for ( i = 1 ; i < n ; ++i )
				sum += f ( a + i * step );
			
			sum += ( f ( a ) + f ( b ) ) / 2 ;
			sum *= step;
			return sum;
		}
		
		public static double SimpsonMethod(Func<double,double> f , double a , double b , long n ) 
		{
			double h = ( b - a ) / n ;
			double k1 = 0 , k2 = 0 ;
			for (var k = 1; k <= n; k++)
			{
				var xk = a + k * h;
				if (k <= n - 1)
					k1 += f(xk);

				var xk_1 = a + (k - 1) * h;
				k2 += f((xk + xk_1) / 2);
			}
			
			return  h / 3d * (1d / 2d * f(a) + k1 + 2 * k2 + 1d / 2d * f(b));
		}
	}
}