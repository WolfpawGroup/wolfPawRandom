using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wolfPawRandom
{
	public class RandomMatrix
	{
		private int initialWidth = 0;
		private int initialHeight = 0;
		public int[][] matrix = null;

		public RandomCollection collection = new RandomCollection();

		public RandomMatrix(int width = 30, int height = 100)
		{
			this.initialWidth = width;
			this.initialHeight = height;

			List<int> history = new List<int>();
			initializeMatrix(history);

#if DEBUG
			drawMatrix();
#endif
		}

		public void initializeMatrix(List<int> history)
		{
			if ((~initialWidth | ~initialHeight) == -1)
			{ "Width or Height not initialized! Returning!".ewritel(Extensions.col.red); return; }

			matrix = new int[initialHeight][];

			for (int h = 0; h < initialHeight; h++)
			{
				int[] arr = new int[initialWidth];

				for(int w = 0; w < initialWidth; w++)
				{
					int i = w % 10;
					int ii = -1;
					while (ii == -1 || history.Contains(ii)) {
						ii = (int)(collection.getRandom(i) * (11 * (Math.PI + ((int)Math.E * ((w * 1.0d) / Math.PI)))));
					}
					history.Add(ii);
					arr[w] = ii;
				}

				matrix[h] = arr;
			}

		}

		public void drawMatrix()
		{
			Console.BufferWidth = 300;
			Console.Write("".PadRight(5) + "-   " );

			for (int w = 0; w < matrix[0].Length; w++)
			{
				Console.Write(w.ToString().PadRight(6));
			}

			Console.WriteLine();

			for (int h = 0; h < matrix.Length; h++)
			{
				Console.Write(h.ToString().PadRight(5) + "|  ");

				for (int w = 0; w < matrix[h].Length; w++)
				{
					Console.Write(matrix[h][w].ToString().PadRight(6));
				}

				Console.WriteLine();
			}
		}

	}
}
