using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace wolfPawRandom
{
	public class WRandom
	{
		private readonly Randomizer _randomizer = null;
		public Randomizer Randomizer => _randomizer;

		public WRandom(ulong InitialSeed = 0)
		{
			_randomizer = new Randomizer(InitialSeed);
		}

		public sbyte getRandomSByte(int length)
		{
			return 0;
		}

		public byte getRandomByte(int length)
		{
			return 0;
		}

		public short getRandomShort(int length)
		{
			return 0;
		}

		//TODO:: EZ MIND!
		#region int

		public int getRandomInt(int length)
		{
			return Randomizer.randomInt();
		}
		
		public int[] getRandomIntArray(int length = 10)
		{
			return null;
		}

		public List<int> getRandomIntList(int length = 10)
		{
			return null;
		}

		public HashSet<int> getRandomIntHashSet(int length = 10)
		{
			return null;
		}

		public Queue<int> getRandomIntQueue(int length = 10)
		{
			return null;
		}

		public Stack<int> getRandomIntStack(int length = 10)
		{
			return null;
		}

		public LinkedList<int> getRandomIntLinkedList(int length = 10)
		{
			return null;
		}

		public ObservableCollection<int> getRandomIntObservableCollection(int length = 10)
		{
			return null;
		}

		public SortedList<int,int> getRandomIntSortedList(int length = 10)
		{
			return null;
		}

		public SortedSet<int> getRandomIntSortedSet(int length = 10)
		{
			return null;
		}

		public IEnumerable<int> getRandomIntIEnumerable(int length = 10)
		{
			return null;
		}


		#endregion

		public uint getRandomUInt(int length)
		{
			return 0;
		}

		public long getRandomLong(int length)
		{
			return 0;
		}

		public ulong getRandomULong(int length)
		{
			return 0;
		}

		public double getRandomDouble(int length)
		{
			return 0;
		}

		public float getRandomFloat(int length)
		{
			return 0;
		}

		public decimal getRandomDecimal(int length)
		{
			return 0;
		}

		public string getRandomString(int length)
		{
			return "";
		}

		

		public string[] getRandomStringArray(int length = 10)
		{
			return null;
		}

		public string[] getRandomStringArray(int min = 5, int max = 50)
		{
			return null;
		}

		public List<T> getRandomList<T>(int length = 10)
		{
			return null;
		}

		public List<T> getRandomList<T>(int min = 5, int max = 50)
		{
			return null;
		}

		public HashSet<T> getRandomHashSet<T>(int length = 10)
		{
			return null;
		}

		public HashSet<T> getRandomHashSet<T>(int min = 5, int max = 50)
		{
			return null;
		}


	}
}