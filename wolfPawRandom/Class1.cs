using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace wolfPawRandom
{


	public static class WRandom
	{
		public static int getRandomInt(int length, long initialSeed = 0)
		{
			initialSeed = initialSeed == 0 ? Environment.TickCount + 4 : initialSeed;

			//RandomMatrix r = new RandomMatrix();

			RandomMatrix rm = new RandomMatrix();
			



			return 0;
		}
	}
	

}
