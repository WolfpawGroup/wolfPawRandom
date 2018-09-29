using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace wolfPawRandom
{
	public class WRandom
	{
		public RandomMatrix rm = null;
		private Stopwatch sw = new Stopwatch();
		private long initialSeed = 0;

		public WRandom(long InitialSeed = 0)
		{
			sw.Start();

			rm = new RandomMatrix();
			
			initialSeed = InitialSeed;

			while (initialSeed == 0)
			{
				initialSeed = generateSeed();
			}

			("Initial Seed: " + initialSeed).writel(Extensions.col.green);

#if DEBUG
			("Generation done in: " + sw.Elapsed.TotalSeconds + "s...").writel(Extensions.col.yellow);
#endif
			sw.Stop();
		}

		public int getRandomInt(int length)
		{
			return 0;
		}

		public void regenerateSeed()
		{
			this.initialSeed = generateSeed();
			("Initial Seed: " + this.initialSeed).writel(Extensions.col.green);
		}

		/// <summary>
		/// Generates random initial seed from initialization vectors from the RandomMatrix
		/// </summary>
		/// <returns></returns>
		public long generateSeed()
		{
			long initialSeed;
			int		len		= rm.collection.randAdditionalTable.Length;
			var		v1		= rm.collection.randAdditionalTable[new Random().Next(0, len / 3)];
			var		v2		= rm.collection.randAdditionalTable[new Random().Next(len / 3, len / 3 + len / 3)];
			string	tmp		= "";
			Regex r = new Regex(@"(\d+)", RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.ECMAScript);

			foreach (Match m in r.Matches(v1))
			{
				tmp += m.Groups[0].Value;
			}

			foreach (Match m in r.Matches(v2))
			{
				tmp += m.Groups[0].Value;
			}

			string tmp2 = "";

			for (int i = 1; i < tmp.Length; i++)
			{
				if (i % 2 == 0)
				{
					tmp2 += tmp[i];
				}
			}

			if (String.Empty.larger(tmp2, "9223372036854775807") == tmp2)
			{ tmp2 = tmp2.Substring(0, 18); }

			Int64.TryParse(tmp2, out initialSeed);
			return initialSeed;
		}
	}
}