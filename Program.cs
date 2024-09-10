using System;
using cli;
using LoginSystem;

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
			CLS	screen = new Login();

			screen.Draw(ref draw_methods);
			// Aomng comment

			cli.Render(draw_methods);
		}
	}
}
