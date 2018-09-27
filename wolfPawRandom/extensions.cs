using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace wolfPawRandom
{
	public static class extensions
	{
//List extensions

		public static T getRandom<T>(this List<T> List, bool shuffle = true)
		{
			if (shuffle) { List.shuffle(); }
			var v = List[0];
			List[0] = List[List.Count - 1];
			List[List.Count - 1] = v;
			return v;
		}

		/// <summary>
		/// Shuffles the List in a randomized manner
		/// </summary>
		/// <param name="List">The list to randomize</param>
		/// <param name="times">The number of shuffle operations. Defaults to 1</param>
		public static void shuffle<T>(this List<T> List, int times = 1)
		{
			if(times == 0) { return; }
			for(int i = 0; i < times; i++)
			{
				T[] arr = List.ToArray();
				method4(ref arr);
				List = arr.ToList();
			}
		}

		/// <summary>
		/// M4: Shuffle array (WolfyD)
		/// </summary>
		public static void method4<T>(ref T[] arr)
		{
			T[] a2 = new T[arr.Length];
			T[] a3 = new T[arr.Length];
			arr.CopyTo(a3, 0);
			for (int i = 1; i < a2.Length + 1; i++)
			{
				Thread.Sleep(2);
				int r = new Random(method1_short()).Next(0, a3.Length);
				a2[i - 1] = a3[r];
				a3 = a3.Except(new T[] { a3[r] }).ToArray();
				if (a3.Length == 1)
					break;
			}

			arr = a2;
		}

		/// <summary>
		/// M1: Generate random short
		/// </summary>
		public static short method1_short()
		{
			short ret = 0;

			Random r1 = new Random((int)((Environment.TickCount / Math.PI) * Math.Sin(new Random().Next())));
			Thread.Sleep(2);
			Random r2 = new Random((int)((Environment.TickCount / (Math.PI * 2)) + Math.BigMul(((int)Environment.WorkingSet * Environment.SystemPageSize), Environment.CurrentManagedThreadId) * r1.NextDouble()));
			string s1 = r1.Next(10000, 32767).ToString();
			string s2 = r2.Next(10000, 32767).ToString();
			string r = "";

			for (int i = 0; i < s1.Length; i++)
			{
				if (i % 2 == 0)
				{
					if (i == 0)
					{
						if (new Random().Next() % 2 == 0)
						{
							r += '0';
						}
						else
						{
							r += '1';
						}
					}
					else
					{
						r += s1[i];
					}
				}
				else
				{
					r += s2[i];
				}
			}

			ret = Convert.ToInt16(r);

			return ret;
		}

		//String extensions

		/// <summary>
		/// <para>Slices a string up to even lengths returning it as an array</para>
		/// <para>If string length is shorter than 2 or slicelength is greater than length of string, empty array is returned</para>
		/// </summary>
		/// <param name="inputString">String to be sliced</param>
		/// <param name="sliceLength">Length of slice. Default case splits string in two</param>
		/// <param name="keepTrimmings">Determines if any leftover string should be returned to the user. Defaults to true</param>
		/// <returns>Array of string slices</returns>
		public static string[] slice(this string inputString, int sliceLength = 0, bool keepTrimmings = true)
		{
			if(inputString.Length < 2 || sliceLength > inputString.Length) { return default(string[]); }
			if(sliceLength == 0) { sliceLength = inputString.Length / 2; }
			int slices = inputString.Length / sliceLength;
			if (!keepTrimmings) { slices = inputString.Length % sliceLength == 0 ? slices : slices - 1; }
			string[] sliceArray = new string[slices];

			int llength = sliceLength;
			for(int i = 0; i < slices; i++)
			{
				if(i == slices - 1 && keepTrimmings) { llength = inputString.Substring(i * llength).Length; }
				sliceArray[i] = inputString.Substring(i * llength, llength);
			}

			return sliceArray;
		}



//Console.WriteLine replacement

		private static ConsoleColor col2Color(col color)
		{
			ConsoleColor c = ConsoleColor.Gray;

			if (color == col.green) { c = ConsoleColor.Green; }
			else if (color == col.red) { c = ConsoleColor.Red; }
			else if (color == col.white) { c = ConsoleColor.White; }
			else if (color == col.yellow) { c = ConsoleColor.Yellow; }
			else if (color == col.blue) { c = ConsoleColor.Blue; }

			return c;
		}

		public static void ewrite(this string msg, col color = col.gray)
		{
			Console.ForegroundColor = col2Color(color);
			Console.Error.WriteLine(msg);
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		public static void write(this string msg, col color = col.gray)
		{
			Console.ForegroundColor = col2Color(color);
			Console.WriteLine(msg);
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		public static void owrite(this string msg, col color = col.gray)
		{
			Console.ForegroundColor = col2Color(color);
			Console.Out.WriteLine();
			Console.ForegroundColor = ConsoleColor.Gray;
		}


		public enum col
		{
			red,
			green,
			white,
			gray,
			yellow,
			blue
		}
	}

	
}
