using System.Numerics;

namespace wolfPawRandom
{
	/// <summary>
	/// My complimentary Math class with some useful stuff
	/// </summary>
	internal static class Math
	{
		public const double PI = System.Math.PI;
		public const double E = System.Math.E;

		public static long BigMul(int a, int b)
		{
			return System.Math.BigMul(a, b);
		}
		
		public static double Sin(int a)
		{
			return System.Math.Sin(a);
		}

		/// <summary>
		/// Basic GCD calculation
		/// </summary>
		public static int gcd(int a, int b)
		{
			int d = 0, g = 0;
			while (even(a) && even(b))
			{
				a /= 2;
				b /= 2;
				d++;
			}

			while (a != b)
			{
				if (even(a)) { a /= 2; }
				else if (even(b)) { b /= 2; }
				else if (a > b) { a = (a - b) / 2; }
				else { b = (b - a) / 2; }
			}

			g = a;

			return g * (int)System.Math.Pow(2, d);
		}

		/// <summary>
		/// Basic LCM calculation
		/// </summary>
		public static int lcm(int a, int b)
		{
			return (a * b) / gcd(a, b);
		}

		/// <summary>
		/// Advanced LCM calculation for array of inputs
		/// </summary>
		public static long lcm2(int[] arr) //Code from → https://www.geeksforgeeks.org/lcm-of-given-array-elements/
		{
			long e = 1;
			int d = 2;

			while (true)
			{
				int c = 0;
				bool divisible = false;

				for (int i = 0; i < arr.Length; i++)
				{
					if (arr[i] == 0) { return 0; }
					else if (arr[i] < 0) { arr[i] *= (-1); }

					if (arr[i] == 1) { c++; }

					if (arr[i] % d == 0) { divisible = true; arr[i] = arr[i] / d; }
				}

				if (divisible) { e *= d; }
				else { d++; }

				if (c == arr.Length) { return e; }
			}
		}

		/// <summary>
		/// return input % 2 == 0
		/// </summary>
		public static bool even(int input)
		{
			return input % 2 == 0;
		}

		public static BigInteger getSmallestDivisable(long from, long to)
		{
			if (from >= to) { return 0; }

			BigInteger ret = 1;

			for (long i = from; i <= to; i++)
			{
				ret = (ret * i) / BigInteger.GreatestCommonDivisor(ret, i);
			}

			return ret;
		}
	}
}