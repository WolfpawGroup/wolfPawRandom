using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace wolfPawRandom
{


	public class WRandom
	{
		public RandomMatrix rm = null;
		Stopwatch sw = new Stopwatch();

		public WRandom()
		{
			sw.Start();
			rm = new RandomMatrix();
#if DEBUG
			("Generation done in: " + sw.Elapsed.TotalSeconds + "s...").write(extensions.col.yellow);
#endif
			sw.Stop();
		}

		public int getRandomInt(int length, long initialSeed = 0)
		{
			if(initialSeed == 0)
			{
				int len = rm.collection.randAdditionalTable.Length;
				var v1 = rm.collection.randAdditionalTable[new Random().Next(0, len / 3)];
				var v2 = rm.collection.randAdditionalTable[new Random().Next(len / 3, len / 3 + len / 3)];
				string tmp = "";
				Regex r = new Regex(@"(\d+)", RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.ECMAScript);
				
				foreach(Match m in r.Matches(v1))
				{
					tmp += m.Groups[0].Value;
				}

				foreach (Match m in r.Matches(v2))
				{
					tmp += m.Groups[0].Value;
				}

				string tmp2 = "";

				for(int i = 1; i < tmp.Length; i++)
				{
					if(i % 2 == 0)
					{
						tmp2 += tmp[i];
					}
				}

				//TODO: Fix comparison
				if(tmp2.CompareTo("9223372036854775807") == 1) { tmp2 = tmp2.Substring(0, 18); }

				Int64.TryParse(tmp2, out initialSeed);
			}

			("Initial Seed: " + initialSeed).write(extensions.col.green);
			Console.WriteLine(long.MaxValue);
			

			



			return 0;
		}
	}
	

}
