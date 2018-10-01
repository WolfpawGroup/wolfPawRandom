using System;
using System.Collections.Generic;

namespace wolfPawRandom
{
	public class RandomMatrix
	{
		private readonly int _initialWidth = 0;
		private readonly int _initialHeight = 0;
		private static int[][] _matrix = null;

		/// <summary>
		/// Matrix object used to randomize data
		/// </summary>
		public int[][] Matrix { get => _matrix; }

		/// <summary>
		/// RandomCollection used by the matrix to fill with initial randomization vectors
		/// </summary>
		public RandomCollection Collection = new RandomCollection();

		/// <summary>
		/// Initializes new RandomMatrix object.
		/// <para>Sets width and height of matrix</para>
		/// initializes main inner history List&lt;int&gt; variable
		/// <para>Starts matrix initialization</para>
		/// </summary>
		/// <param name="width">Width of matrix. 50 by default</param>
		/// <param name="height">Height of matrix. 50 by default</param>
		public RandomMatrix(int width = 50, int height = 50)
		{
			this._initialWidth = width;
			this._initialHeight = height;

			List<int> history = new List<int>();
			initializeMatrix(history);

#if DEBUG
			drawMatrix();
#endif
		}

		/// <summary>
		/// Initializes a new matrix filling it with randomData
		/// </summary>
		/// <param name="history">The List&lt;int&gt; used to keep values inside the matrix unique</param>
		public void initializeMatrix(List<int> history)
		{
			if ((~_initialWidth | ~_initialHeight) == -1)
			{ "Width or Height not initialized! Returning!".ewritel(Extensions.col.red); return; }

			_matrix = new int[_initialHeight][];

			for (int h = 0; h < _initialHeight; h++)
			{
				int[] arr = new int[_initialWidth];

				for (int w = 0; w < _initialWidth; w++)
				{
					int i = w % 10;
					int ii = -1;
					while (ii == -1 || history.Contains(ii))
					{
						ii = (int)(Collection.getRandom(i) * (11 * (Math.PI + ((int)Math.E * ((w * 1.0d) / Math.PI)))));
					}
					history.Add(ii);
					arr[w] = ii;
				}

				Matrix[h] = arr;
			}
		}

		/// <summary>
		/// Draws generated matrix on screen
		/// </summary>
		public void drawMatrix()
		{
			Console.BufferWidth = 300;
			Console.Write("".PadRight(5) + "-   ");

			for (int w = 0; w < Matrix[0].Length; w++)
			{
				Console.Write(w.ToString().PadRight(6));
			}

			Console.WriteLine();

			for (int h = 0; h < Matrix.Length; h++)
			{
				Console.Write(h.ToString().PadRight(5) + "|  ");

				for (int w = 0; w < Matrix[h].Length; w++)
				{
					Console.Write(Matrix[h][w].ToString().PadRight(6));
				}

				Console.WriteLine();
			}
		}

		/// <summary>
		/// Returns width of the randomMatrix
		/// </summary>
		public int getWidth()
		{
			return Matrix[0].Length;
		}

		/// <summary>
		/// Returns height of the randomMatrix
		/// </summary>
		public int getHeight()
		{
			return Matrix.Length;
		}
	}
}