using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wolfPawRandom
{
	class RandomMatrix
	{
		private int initialWidth = 0;
		private int initialHeight = 0;
		public int[][] matrix = null;

		RandomCollection collection = new RandomCollection();

		public RandomMatrix(int width = 30, int height = 30)
		{
			this.initialWidth = width;
			this.initialHeight = height;

			initializeMatrix();
		}

		//TODO: Initial shuffle still too slow
		//TODO: add missing stuff 

		public void initializeMatrix()
		{
			if ((~initialWidth | ~initialHeight) == -1)
			{ "Width or Height not initialized! Returning!".ewrite(extensions.col.red); return; }

			matrix = new int[initialWidth][];
			for (int h = 0; h < initialHeight; h++)
			{
				int[] arr = new int[initialWidth];

				for(int w = 0; w < initialWidth; w++)
				{
					int i = w % 10;
					arr[w] = (int)(collection.getRandom(i) * 100);
				}
			}

		}

	}
}
