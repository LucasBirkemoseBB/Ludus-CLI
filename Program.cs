using System;
using cli;
using test;

namespace Program
{
	internal class Program 
	{
		static void Main(string[] args)
		{
			// Write all code here.
			List<DrawMethod> draw_methods = new List<DrawMethod>();

			CLI cli = new CLI();
			CLS	screen = new Test();

			screen.Draw(ref draw_methods);

			cli.Render(draw_methods);
		}
<<<<<<< HEAD

		private void saySike() 
		{
			Console.WriteLine("Sike");
		}
=======
>>>>>>> dc639591d2b0111d67327f189e791f2d75480630
	}
}
