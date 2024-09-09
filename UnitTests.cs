using System;

namespace UnitTests
{
	public class UnitTests<T>
	{
		public delegate bool CompareFunc(T a, T b);
		public static bool Test(T input, T expected, CompareFunc compare) 
		{
			return compare(input, expected);
		}
	}

	//------------------ EXAMPLE
	public class UnitExample 
	{
		public void doTest()
		{
			UnitTests<int>.Test(Add(3,4), 7, (a, b) => { return a==b; });
		}

		public int Add(int a, int b)
		{
			return a+b;
		}
	}
}
