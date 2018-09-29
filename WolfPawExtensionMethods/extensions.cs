using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace WolfPawExtensionMethods
{
	public static class extensions
	{
		#region List extensions

		public static T getRandom<T>(this List<T> List, bool shuffle = true)
		{
			if (List.Count % 10 > 0) { List = List.Take(List.Count - (List.Count % 10)).ToList(); }
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
				ArrayShuffle(ref arr);
			}
			List = arr.ToList();
		}

		/// <summary>
		/// Shuffle array
		/// Modified to shuffle 10 lines at a time
		/// </summary>
		public static void ArrayShuffle<T>(ref T[] arr)
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
					int r = new Random(ShortRandomGen()).Next(0, a3.Length / 10);
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
		/// Generate semi random short
		/// </summary>
		public static short ShortRandomGen()
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

		/// <summary>
		/// <para>Pops first element of the list off and returns it. </para>
		/// <para>List is shortened similar to Array.Pop </para>
		/// </summary>
		/// <param name="List">List to pop from</param>
		/// <returns>T element of List&lt;T&gt;</returns>
		public static T pop<T>(this List<T> List)
		{
			var v = List[0];
			List.RemoveAt(0);
			return v;
		}

		/// <summary>
		/// <para>Pulls last element of the list off and returns it. </para>
		/// <para>List is shortened.</para>
		/// </summary>
		/// <param name="List">List to pull from</param>
		/// <returns>T element of List&lt;T&gt;</returns>
		public static T pull<T>(this List<T> List)
		{
			var v = List[List.Count - 1];
			List.RemoveAt(List.Count - 1);
			return v;
		}

		#endregion List extensions

		#region String extensions

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
			if (inputString.Length < 2 || sliceLength > inputString.Length) { return default(string[]); }
			if (sliceLength == 0) { sliceLength = inputString.Length / 2; }
			int slices = inputString.Length / sliceLength;
			if (!keepTrimmings) { slices = inputString.Length % sliceLength == 0 ? slices : slices - 1; }
			string[] sliceArray = new string[slices];

			int llength = sliceLength;
			for (int i = 0; i < slices; i++)
			{
				if (i == slices - 1 && keepTrimmings) { llength = inputString.Substring(i * llength).Length; }
				sliceArray[i] = inputString.Substring(i * llength, llength);
			}

			return sliceArray;
		}

		/// <summary>
		/// Determines which of two strings is larger and returns the larger one
		/// </summary>
		/// <param name="str1">String A</param>
		/// <param name="str2">String B</param>
		/// <returns>String A or B depending on which is larger</returns>
		public static string larger(this string s, string str1, string str2)
		{
			stringComp sc = new stringComp();
			char c = (char)sc.Compare(str1, str2);
			if (c == 'a') { return str1; }
			else { return str2; }
		}

		/// <summary>
		/// String comparer used in comparison. Properly compares strings
		/// </summary>
		public class stringComp : IComparer<string>
		{
			public int Compare(string a, string b)
			{
				a = a.TrimStart('0');
				b = b.TrimStart('0');

				if (a == b) { return '='; }
				else if (a.Length > b.Length) { return 'a'; }
				else if (b.Length > a.Length) { return 'b'; }
				else if (a.Length == b.Length)
				{
					for (int i = 0; i < a.Length; i++)
					{
						if (a[i] == b[i]) { continue; }
						else
						{
							if (a[i] > b[i]) { return 'a'; }
							else { return 'b'; }
						}
					}
				}

				return 0;
			}

			public override bool Equals(object obj)
			{
				return base.Equals(obj);
			}

			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			public override string ToString()
			{
				return base.ToString();
			}
		}

		#region Console.WriteLine replacement and colors

		/// <summary>
		/// Converts ConsoleColor into col (just so I don't have to write out ConsoleColor every time...)
		/// </summary>
		/// <param name="color">Col to turn into proper Color</param>
		/// <returns>ConsoleColor</returns>
		private static ConsoleColor col2Color(col color)
		{
			ConsoleColor c = ConsoleColor.Gray;

			switch (color)
			{
				case col.black: c = ConsoleColor.Black; break;
				case col.blue: c = ConsoleColor.Blue; break;
				case col.cyan: c = ConsoleColor.Cyan; break;
				case col.darkBlue: c = ConsoleColor.DarkBlue; break;
				case col.darkCyan: c = ConsoleColor.DarkCyan; break;
				case col.darkGray: c = ConsoleColor.DarkGray; break;
				case col.darkGreen: c = ConsoleColor.DarkGreen; break;
				case col.darkMagenta: c = ConsoleColor.DarkMagenta; break;
				case col.darkRed: c = ConsoleColor.DarkRed; break;
				case col.darkYellow: c = ConsoleColor.DarkYellow; break;
				case col.gray: c = ConsoleColor.Gray; break;
				case col.green: c = ConsoleColor.Green; break;
				case col.magenta: c = ConsoleColor.Magenta; break;
				case col.red: c = ConsoleColor.Red; break;
				case col.white: c = ConsoleColor.White; break;
				case col.yellow: c = ConsoleColor.Yellow; break;
			}

			return c;
		}

		///<summary>
		///<para>Converts string form of color name to ConsoleColor for ease of use</para>
		///<para></para>
		///<para>Available Colors:</para>
		///<para>black</para>
		///<para>blue</para>
		///<para>cyan</para>
		///<para>darkBlue</para>
		///<para>darkCyan</para>
		///<para>darkGray</para>
		///<para>darkGreen</para>
		///<para>darkMagenta</para>
		///<para>darkRed</para>
		///<para>darkYellow</para>
		///<para>gray</para>
		///<para>green</para>
		///<para>magenta</para>
		///<para>red</para>
		///<para>white</para>
		///<para>yellow</para>
		///</summary>
		///<param name="color">Color input (uses tolower)</param>
		///<returns>ConsoleColor</returns>
		private static ConsoleColor col2Color(string color = "Gray")
		{
			ConsoleColor c = ConsoleColor.Gray;

			switch (color.ToLower())
			{
				case "black": c = ConsoleColor.Black; break;
				case "blue": c = ConsoleColor.Blue; break;
				case "cyan": c = ConsoleColor.Cyan; break;
				case "darkBlue": c = ConsoleColor.DarkBlue; break;
				case "darkCyan": c = ConsoleColor.DarkCyan; break;
				case "darkGray": c = ConsoleColor.DarkGray; break;
				case "darkGreen": c = ConsoleColor.DarkGreen; break;
				case "darkMagenta": c = ConsoleColor.DarkMagenta; break;
				case "darkRed": c = ConsoleColor.DarkRed; break;
				case "darkYellow": c = ConsoleColor.DarkYellow; break;
				case "gray": c = ConsoleColor.Gray; break;
				case "green": c = ConsoleColor.Green; break;
				case "magenta": c = ConsoleColor.Magenta; break;
				case "red": c = ConsoleColor.Red; break;
				case "white": c = ConsoleColor.White; break;
				case "yellow": c = ConsoleColor.Yellow; break;
			}

			return c;
		}

		/// <summary>
		/// Writes colored line to Console standard error. (With line break.)
		/// </summary>
		/// <param name="msg">Message to write</param>
		/// <param name="color">Color of message (defaults to gray)</param>
		/// <param name="bgcol">Background color of message (defaults to black)</param>
		public static void ewritel(this string msg, col color = col.gray, col bgcol = col.black)
		{
			Console.ForegroundColor = col2Color(color);
			Console.Error.WriteLine(msg);
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		public static void ewritel(this string msg, string color = "gray", string bgcol = "black")
		{
			Console.ForegroundColor = col2Color(color);
			Console.Error.WriteLine(msg);
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		/// <summary>
		/// Writes colored line to Console standard error. (With line break.)
		/// </summary>
		/// <param name="msg">Message to write</param>
		/// <param name="color">Color of message (defaults to gray)</param>
		/// <param name="bgcol">Background color of message (defaults to black)</param>
		public static void ceWL(this string msg, col color = col.gray, col bgcol = col.black) { ewritel(msg, color, bgcol); }

		public static void ceWL(this string msg, string color = "gray", string bgcol = "black")
		{
			ewritel(msg, color, bgcol);
		}

		/// <summary>
		/// Writes colored line to Console. (With line break.)
		/// </summary>
		/// <param name="msg">Message to write</param>
		/// <param name="color">Color of message (defaults to gray)</param>
		/// <param name="bgcol">Background color of message (defaults to black)</param>
		public static void writel(this string msg, col color = col.gray, col bgcol = col.black)
		{
			Console.ForegroundColor = col2Color(color);
			Console.WriteLine(msg);
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		public static void writel(this string msg, string color = "gray", string bgcol = "black")
		{
			Console.ForegroundColor = col2Color(color);
			Console.WriteLine(msg);
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		/// <summary>
		/// Writes colored line to Console. (With line break.)
		/// </summary>
		/// <param name="msg">Message to write</param>
		/// <param name="color">Color of message (defaults to gray)</param>
		/// <param name="bgcol">Background color of message (defaults to black)</param>
		public static void cWL(this string msg, col color = col.gray, col bgcol = col.black) { writel(msg, color, bgcol); }

		public static void cWL(this string msg, string color = "gray", string bgcol = "black")
		{
			writel(msg, color, bgcol);
		}

		/// <summary>
		/// Writes colored line to Console standard out. (With line break.)
		/// </summary>
		/// <param name="msg">Message to write</param>
		/// <param name="color">Color of message (defaults to gray)</param>
		/// <param name="bgcol">Background color of message (defaults to black)</param>
		public static void owritel(this string msg, col color = col.gray, col bgcol = col.black)
		{
			Console.ForegroundColor = col2Color(color);
			Console.Out.WriteLine(msg);
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		public static void owritel(this string msg, string color = "gray", string bgcol = "black")
		{
			Console.ForegroundColor = col2Color(color);
			Console.Out.WriteLine(msg);
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		/// <summary>
		/// Writes colored line to Console standard out. (With line break.)
		/// </summary>
		/// <param name="msg">Message to write</param>
		/// <param name="color">Color of message (defaults to gray)</param>
		/// <param name="bgcol">Background color of message (defaults to black)</param>
		public static void coWL(this string msg, col color = col.gray, col bgcol = col.black) { owritel(msg, color, bgcol); }

		public static void coWL(this string msg, string color = "gray", string bgcol = "black")
		{
			owritel(msg, color, bgcol);
		}

		/// <summary>
		/// Writes colored string to Console standard error
		/// </summary>
		/// <param name="msg">Message to write</param>
		/// <param name="color">Color of message (defaults to gray)</param>
		/// <param name="bgcol">Background color of message (defaults to black)</param>
		public static void ewrite(this string msg, col color = col.gray, col bgcol = col.black)
		{
			Console.ForegroundColor = col2Color(color);
			Console.Error.Write(msg);
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		public static void ewrite(this string msg, string color = "gray", string bgcol = "black")
		{
			Console.ForegroundColor = col2Color(color);
			Console.Error.Write(msg);
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		/// <summary>
		/// Writes colored string to Console standard error
		/// </summary>
		/// <param name="msg">Message to write</param>
		/// <param name="color">Color of message (defaults to gray)</param>
		/// <param name="bgcol">Background color of message (defaults to black)</param>
		public static void ceW(this string msg, col color = col.gray, col bgcol = col.black) { ewrite(msg, color, bgcol); }

		public static void ceW(this string msg, string color = "gray", string bgcol = "black")
		{
			ewrite(msg, color, bgcol);
		}

		/// <summary>
		/// Writes colored string to Console
		/// </summary>
		/// <param name="msg">Message to write</param>
		/// <param name="color">Color of message (defaults to gray)</param>
		/// <param name="bgcol">Background color of message (defaults to black)</param>
		public static void write(this string msg, col color = col.gray, col bgcol = col.black)
		{
			Console.ForegroundColor = col2Color(color);
			Console.Write(msg);
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		public static void write(this string msg, string color = "gray", string bgcol = "black")
		{
			Console.ForegroundColor = col2Color(color);
			Console.Write(msg);
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		/// <summary>
		/// Writes colored string to Console
		/// </summary>
		/// <param name="msg">Message to write</param>
		/// <param name="color">Color of message (defaults to gray)</param>
		/// <param name="bgcol">Background color of message (defaults to black)</param>
		public static void cW(this string msg, col color = col.gray, col bgcol = col.black) { write(msg, color, bgcol); }

		public static void cW(this string msg, string color = "gray", string bgcol = "black")
		{
			write(msg, color, bgcol);
		}

		/// <summary>
		/// Writes colored string to Console standard out
		/// </summary>
		/// <param name="msg">Message to write</param>
		/// <param name="color">Color of message (defaults to gray)</param>
		/// <param name="bgcol">Background color of message (defaults to black)</param>
		public static void owrite(this string msg, col color = col.gray, col bgcol = col.black)
		{
			Console.ForegroundColor = col2Color(color);
			Console.Out.Write(msg);
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		public static void owrite(this string msg, string color = "gray", string bgcol = "black")
		{
			Console.ForegroundColor = col2Color(color);
			Console.Out.Write(msg);
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		/// <summary>
		/// Writes colored string to Console standard out
		/// </summary>
		/// <param name="msg">Message to write</param>
		/// <param name="color">Color of message (defaults to gray)</param>
		/// <param name="bgcol">Background color of message (defaults to black)</param>
		public static void coW(this string msg, col color = col.gray, col bgcol = col.black) { owrite(msg, color, bgcol); }

		public static void coW(this string msg, string color = "gray", string bgcol = "black")
		{
			owrite(msg, color, bgcol);
		}

		/// <summary>
		/// Color enum
		/// </summary>
		public enum col
		{
			black,
			blue,
			cyan,
			darkBlue,
			darkCyan,
			darkGray,
			darkGreen,
			darkMagenta,
			darkRed,
			darkYellow,
			gray,
			green,
			magenta,
			red,
			white,
			yellow
		}

		#endregion Console.WriteLine replacement and colors

		#endregion String extensions
	}
}