using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using wolfPawRandom;

namespace tester
{
	class Program
	{
		static void Main(string[] args)
		{
			int i = WRandom.getRandomInt(4);

			

			Console.WriteLine(i);
			Console.Read();
		}
	}
}
