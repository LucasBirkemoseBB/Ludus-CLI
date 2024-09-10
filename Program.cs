using System;
using cli;
using test;

namespace Program
{
	internal class Program 
	{
		// Main entry
		static void Main(string[] args)
		{
			// Write all code here.
			List<DrawMethod> draw_methods = new List<DrawMethod>();

			CLI cli = new CLI();
			CLS	screen = new Test();

			screen.Draw(ref draw_methods);

			cli.Render(draw_methods);
		}
	}
}
