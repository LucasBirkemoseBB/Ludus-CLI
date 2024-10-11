using System;

namespace UnitTests
{
	// Used for unit tests (Testing functions by themselves)
	public class UnitTests<T>
	{
		public delegate bool CompareFunc(params T[] param);
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
			if(!UnitTests<int>.Test(Add(3,4), 7, (a) => { return a[0]==a[1]; }))
				Console.WriteLine("Unit test failed");
			else 
				Console.WriteLine("Unit test passed!");
		}

		public int Add(int a, int b)
		{
			return a+b;
		}
	}
}
