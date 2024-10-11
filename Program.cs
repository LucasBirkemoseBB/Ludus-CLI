using System;
using cli;
using SkemaSystem;
using LoginSystem;

using InputHandler;
using SkemaKlasseSystem; 
using LektierHandler;

using ScreenHandler;
using StudentSystem;

using Constants;

namespace Program
{
	internal class Program 
	{
		// Main entry
		static void Main(string[] args)
		{
			// Clears the screen before rendering anything at all
			Console.Clear();
			List<DrawMethod> draw_methods = new List<DrawMethod>();

			// Defines everything
			CLI cli = new CLI();
			Screens.currentScreen.Initialize();

			Screens.currentScreen.Draw(ref draw_methods);
			cli.Render(draw_methods);	

			for(;;)
			{
				Screens.currentScreen.Update();
				if(Screens.currentScreen.ReRender()) 
				{
					Screens.currentScreen.Draw(ref draw_methods);
					cli.Render(draw_methods);	
				}

				continue;
			}
		}
	}
}
