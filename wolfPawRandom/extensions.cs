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
			if(List.Count % 10 > 0) { List = List.Take(List.Count - (List.Count % 10)).ToList(); }
			if (shuffle) { List.shuffle(); }
			
			var v = List[0];
			
			return v;
		}

		/// <summary>
		/// Shuffles the List in a randomized manner
		/// </summary>
		/// <param name="List">The list to randomize</param>
		/// <param name="times">The number of shuffle operations. Defaults to 1</param>
		public static void shuffle<T>(this List<T> List, int times = 1)
		{
			if (List.Count % 10 > 0) { List = List.Take(List.Count - (List.Count % 10)).ToList(); }
			if (times == 0) { return; }
			T[] arr = List.ToArray();
			for (int i = 0; i < times; i++)
			{
				method4(ref arr);
			}
			List = arr.ToList();
		}

		/// <summary>
		/// M4: Shuffle array (WolfyD)
		/// Modified to shuffle 10 lines at a time
		/// </summary>
		public static void method4<T>(ref T[] arr)
		{
			T[] a2 = new T[arr.Length];
			T[] a3 = new T[arr.Length];
			arr.CopyTo(a3, 0);
			try
			{
				for (int i = 1; i < a2.Length / 10 + 1; i++)
				{
					if (a3.Length == 0)
						break;
					Thread.Sleep(1);
					int r = new Random(method1_short()).Next(0, a3.Length / 10);
					for (int ii = 0; ii < 10; ii++)
					{
						a2[((i - 1) * 10) + ii] = a3[r + ii];
					}

					a3 = a3.Except(new T[] {
					a3[r + 0],
					a3[r + 1],
					a3[r + 2],
					a3[r + 3],
					a3[r + 4],
					a3[r + 5],
					a3[r + 6],
					a3[r + 7],
					a3[r + 8],
					a3[r + 9]
				}).ToArray();
				}
			}
			catch
			{

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

		/// <summary>
		/// Shifts the lists items to the left
		/// </summary>
		/// <param name="List">The list to shift</param>
		/// <param name="amount">The number of spaces to shift items</param>
		/// <param name="wrapAround">If false the shift acts like a pop, shortening the list with every shift</param>
		/// <returns>The shifted List&lt;T&gt;</returns>
		public static void shiftLeft<T>(this List<T> List, int amount = 1, bool wrapAround = false)
		{
			if (List.Count == 0 || amount == 0) { return; }
			if (!wrapAround && amount >= List.Count) { return; };
			

			List<T> lst = new List<T>();
			lst.AddRange(List);

			for (int i = 0; i < amount; i++)
			{
				var tmp = lst[0];
				lst = lst.Skip(1).ToList();
				if (wrapAround)
				{
					lst.Add(tmp);
				}
			}

			List.Clear();
			List.AddRange(lst);
		}

		/// <summary>
		/// Shifts the lists items to the Right
		/// </summary>
		/// <param name="List">The list to shift</param>
		/// <param name="amount">The number of spaces to shift items</param>
		/// <param name="wrapAround">If false the shift acts like a pull, shortening the list with every shift</param>
		/// <returns>The shifted List&lt;T&gt;</returns>
		public static List<T> shiftRight<T>(this List<T> List, int amount = 1, bool wrapAround = false)
		{
			if (List.Count == 0 || amount == 0) { return List; }
			if (!wrapAround && amount >= List.Count) { return default(List<T>); }

			for (int i = 0; i < amount; i++)
			{
				var tmp = List[List.Count - 1];
				List = List.GetRange(0, List.Count - 2);
				if (wrapAround)
				{
					List.Prepend(tmp);
				}
			}

			return List;
		}

		public static T pop<T>(this List<T> List)
		{
			var v = List[0];
			List.RemoveAt(0);
			return v;
		}

		public static T pull<T>(this List<T> List)
		{
			var v = List[List.Count - 1];
			List.RemoveAt(List.Count - 1);
			return v;
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
