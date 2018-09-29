using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace wolfPawRandom
{
	public class RandomCollection
	{
		public string[] randAdditionalTable = null;
		public List<double> randCol_0 = new List<double>();
		public List<double> randCol_1 = new List<double>();
		public List<double> randCol_2 = new List<double>();
		public List<double> randCol_3 = new List<double>();
		public List<double> randCol_4 = new List<double>();
		public List<double> randCol_5 = new List<double>();
		public List<double> randCol_6 = new List<double>();
		public List<double> randCol_7 = new List<double>();
		public List<double> randCol_8 = new List<double>();
		public List<double> randCol_9 = new List<double>();

		public RandomCollection()
		{
			int min					= 1;
			int max					= 15;
			int len					= Convert.ToInt32(WMath.getSmallestDivisable(min, max).ToString());
			string additionalRand	= generateLongRandomString(len);
			
			randAdditionalTable		= additionalRand.slice(30, true);
			
			initializeRandomness();
		}

		void initializeRandomness()
		{
			for(int i = 0; i < randAdditionalTable.Length; i++)
			{
				if (i % 50 == 0)
				{
					randCol_0.Add(0);
					randCol_1.Add(0);
					randCol_2.Add(0);
					randCol_3.Add(0);
					randCol_4.Add(0);
					randCol_5.Add(0);
					randCol_6.Add(0);
					randCol_7.Add(0);
					randCol_8.Add(0);
					randCol_9.Add(0);
				}

				randCol_0[randCol_0.Count - 1] += ((double)randAdditionalTable[i][9] / (new Random((int)(Environment.TickCount + 1		/ new Random(new Random().Next()).NextDouble())).Next(20, 88) * 1d));
				randCol_1[randCol_1.Count - 1] += ((double)randAdditionalTable[i][8] / (new Random((int)(Environment.TickCount + 10		/ new Random(new Random().Next()).NextDouble())).Next(21, 89) * 1d));
				randCol_2[randCol_2.Count - 1] += ((double)randAdditionalTable[i][7] / (new Random((int)(Environment.TickCount + 100	/ new Random(new Random().Next()).NextDouble())).Next(22, 90) * 1d));
				randCol_3[randCol_3.Count - 1] += ((double)randAdditionalTable[i][6] / (new Random((int)(Environment.TickCount + 2		/ new Random(new Random().Next()).NextDouble())).Next(23, 91) * 1d));
				randCol_4[randCol_4.Count - 1] += ((double)randAdditionalTable[i][5] / (new Random((int)(Environment.TickCount + 20		/ new Random(new Random().Next()).NextDouble())).Next(24, 92) * 1d));
				randCol_5[randCol_5.Count - 1] += ((double)randAdditionalTable[i][4] / (new Random((int)(Environment.TickCount + 200	/ new Random(new Random().Next()).NextDouble())).Next(25, 93) * 1d));
				randCol_6[randCol_6.Count - 1] += ((double)randAdditionalTable[i][3] / (new Random((int)(Environment.TickCount + 3		/ new Random(new Random().Next()).NextDouble())).Next(26, 94) * 1d));
				randCol_7[randCol_7.Count - 1] += ((double)randAdditionalTable[i][2] / (new Random((int)(Environment.TickCount + 30		/ new Random(new Random().Next()).NextDouble())).Next(27, 95) * 1d));
				randCol_8[randCol_8.Count - 1] += ((double)randAdditionalTable[i][1] / (new Random((int)(Environment.TickCount + 300	/ new Random(new Random().Next()).NextDouble())).Next(28, 96) * 1d));
				randCol_9[randCol_9.Count - 1] += ((double)randAdditionalTable[i][0] / (new Random((int)(Environment.TickCount + 50		/ new Random(new Random().Next()).NextDouble())).Next(29, 97) * 1d));

				randCol_1[randCol_1.Count - 1] += ((double)randAdditionalTable[i][19] / (new Random((int)(Environment.TickCount + 1		/ new Random(new Random().Next()).NextDouble())).Next(20, 88) * 1d));
				randCol_2[randCol_2.Count - 1] += ((double)randAdditionalTable[i][18] / (new Random((int)(Environment.TickCount + 10	/ new Random(new Random().Next()).NextDouble())).Next(21, 89) * 1d));
				randCol_3[randCol_3.Count - 1] += ((double)randAdditionalTable[i][17] / (new Random((int)(Environment.TickCount + 100	/ new Random(new Random().Next()).NextDouble())).Next(22, 90) * 1d));
				randCol_7[randCol_7.Count - 1] += ((double)randAdditionalTable[i][16] / (new Random((int)(Environment.TickCount + 2		/ new Random(new Random().Next()).NextDouble())).Next(23, 91) * 1d));
				randCol_4[randCol_4.Count - 1] += ((double)randAdditionalTable[i][15] / (new Random((int)(Environment.TickCount + 20	/ new Random(new Random().Next()).NextDouble())).Next(24, 92) * 1d));
				randCol_5[randCol_5.Count - 1] += ((double)randAdditionalTable[i][14] / (new Random((int)(Environment.TickCount + 200	/ new Random(new Random().Next()).NextDouble())).Next(25, 93) * 1d));
				randCol_8[randCol_8.Count - 1] += ((double)randAdditionalTable[i][13] / (new Random((int)(Environment.TickCount + 3		/ new Random(new Random().Next()).NextDouble())).Next(26, 94) * 1d));
				randCol_9[randCol_9.Count - 1] += ((double)randAdditionalTable[i][12] / (new Random((int)(Environment.TickCount + 30	/ new Random(new Random().Next()).NextDouble())).Next(27, 95) * 1d));
				randCol_0[randCol_0.Count - 1] += ((double)randAdditionalTable[i][11] / (new Random((int)(Environment.TickCount + 300	/ new Random(new Random().Next()).NextDouble())).Next(28, 96) * 1d));
				randCol_6[randCol_6.Count - 1] += ((double)randAdditionalTable[i][10] / (new Random((int)(Environment.TickCount + 50	/ new Random(new Random().Next()).NextDouble())).Next(29, 97) * 1d));

				randCol_8[randCol_8.Count - 1] += ((double)randAdditionalTable[i][29] / (new Random((int)(Environment.TickCount + 1		/ new Random(new Random().Next()).NextDouble())).Next(20, 88) * 1d));
				randCol_1[randCol_1.Count - 1] += ((double)randAdditionalTable[i][28] / (new Random((int)(Environment.TickCount + 10	/ new Random(new Random().Next()).NextDouble())).Next(21, 89) * 1d));
				randCol_6[randCol_6.Count - 1] += ((double)randAdditionalTable[i][27] / (new Random((int)(Environment.TickCount + 100	/ new Random(new Random().Next()).NextDouble())).Next(22, 90) * 1d));
				randCol_3[randCol_3.Count - 1] += ((double)randAdditionalTable[i][26] / (new Random((int)(Environment.TickCount + 2		/ new Random(new Random().Next()).NextDouble())).Next(23, 91) * 1d));
				randCol_4[randCol_4.Count - 1] += ((double)randAdditionalTable[i][25] / (new Random((int)(Environment.TickCount + 20	/ new Random(new Random().Next()).NextDouble())).Next(24, 92) * 1d));
				randCol_0[randCol_0.Count - 1] += ((double)randAdditionalTable[i][24] / (new Random((int)(Environment.TickCount + 200	/ new Random(new Random().Next()).NextDouble())).Next(25, 93) * 1d));
				randCol_9[randCol_9.Count - 1] += ((double)randAdditionalTable[i][23] / (new Random((int)(Environment.TickCount + 3		/ new Random(new Random().Next()).NextDouble())).Next(26, 94) * 1d));
				randCol_5[randCol_5.Count - 1] += ((double)randAdditionalTable[i][22] / (new Random((int)(Environment.TickCount + 30	/ new Random(new Random().Next()).NextDouble())).Next(27, 95) * 1d));
				randCol_2[randCol_2.Count - 1] += ((double)randAdditionalTable[i][21] / (new Random((int)(Environment.TickCount + 300	/ new Random(new Random().Next()).NextDouble())).Next(28, 96) * 1d));
				randCol_7[randCol_7.Count - 1] += ((double)randAdditionalTable[i][20] / (new Random((int)(Environment.TickCount + 50	/ new Random(new Random().Next()).NextDouble())).Next(29, 97) * 1d));
			}

			randCol_0.shuffle();
			randCol_1.shuffle();
			randCol_2.shuffle();
			randCol_3.shuffle();
			randCol_4.shuffle();
			randCol_5.shuffle();
			randCol_6.shuffle();
			randCol_7.shuffle();
			randCol_8.shuffle();
			randCol_9.shuffle();
		}

		string generateLongRandomString(int length)
		{
			length /= 2;

			StringBuilder			sb		= new StringBuilder(length);
			RandomNumberGenerator	rnd		= RandomNumberGenerator.Create();
			int						minilen	= length / 10;
			byte[]					bytes	= new byte[length];
			byte[]					tmpb	= new byte[10];

			for(int i = 0; i < minilen; i++)
			{
				rnd.GetNonZeroBytes(tmpb);
				tmpb.CopyTo(bytes, i * 10);
				tmpb.Initialize();
			}

			foreach(byte b in bytes)
			{
				sb.Append(b.ToString("X2"));
			}

			return sb.ToString();
		}

		public double getRandom(int i)
		{
			switch (i)
			{
				case 0: randCol_0.shiftLeft(5, true); return randCol_0.getRandom(false);
				case 1: randCol_1.shiftLeft(5, true); return randCol_1.getRandom(false);
				case 2: randCol_2.shiftLeft(5, true); return randCol_2.getRandom(false);
				case 3: randCol_3.shiftLeft(5, true); return randCol_3.getRandom(false);
				case 4: randCol_4.shiftLeft(5, true); return randCol_4.getRandom(false);
				case 5: randCol_5.shiftLeft(5, true); return randCol_5.getRandom(false);
				case 6: randCol_6.shiftLeft(5, true); return randCol_6.getRandom(false);
				case 7: randCol_7.shiftLeft(5, true); return randCol_7.getRandom(false);
				case 8: randCol_8.shiftLeft(5, true); return randCol_8.getRandom(false);
				case 9: randCol_9.shiftLeft(5, true); return randCol_9.getRandom(false);

				default: return randCol_0.getRandom();
			}
		}

	}
}
