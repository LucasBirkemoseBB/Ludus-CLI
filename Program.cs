using System;
using cli;
using SkemaSystem;
using LoginSystem;

using InputHandler;
using SkemaKlasseSystem; 

using ScreenHandler;

namespace Program
{
	internal class Program 
	{
		// Main entry
		static void Main(string[] args)
		{
			Console.Clear();
			// Write all code here.
			List<DrawMethod> draw_methods = new List<DrawMethod>();

			CLI cli = new CLI();
			Screens.currentScreen.Initialize();
		
			// Console.Clear();
			Screens.currentScreen.Draw(ref draw_methods);
			cli.Render(draw_methods);	

			// Aomng comment

			for(;;)
			{
				Screens.currentScreen.Update();
				if(Screens.currentScreen.ReRender()) 
				{
					Screens.currentScreen.Draw(ref draw_methods);
					cli.Render(draw_methods);	
				}

				continue;
				// cli.Update();
			}
			// Console.Read();			
		}
	}
}
