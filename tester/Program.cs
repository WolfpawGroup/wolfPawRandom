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
			WRandom wr = new WRandom();
			int i1 = wr.getRandomInt(10);
			int i2 = wr.getRandomInt(10);
			int i3 = wr.getRandomInt(10);
			int i4 = wr.getRandomInt(10);
			int i5 = wr.getRandomInt(10);
			int i6 = wr.getRandomInt(10);
			int i7 = wr.getRandomInt(10);
			int i8 = wr.getRandomInt(10);
			int i9 = wr.getRandomInt(10);

			Console.WriteLine(i1);
			Console.WriteLine(i2);
			Console.WriteLine(i3);
			Console.WriteLine(i4);
			Console.WriteLine(i5);
			Console.WriteLine(i6);
			Console.WriteLine(i7);
			Console.WriteLine(i8);
			Console.WriteLine(i9);
			Console.Read();
		}
	}
}
