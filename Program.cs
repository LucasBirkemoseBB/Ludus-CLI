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
			Console.Clear();
			// Write all code here.
			List<DrawMethod> draw_methods = new List<DrawMethod>();

			// Consts.lektierHandler.addLektier(new Lektier("Modul", "opgabe", "lærer", "frist", "elevtimer", "rettet"));
			

			// Consts.messageHandler.sendMessage(56798, 32349, "This is a test message this is al ofisdjjiofjiodsjifidjosjiofjidsfj");
			// Consts.messageHandler.sendMessage(43264, 31961, "Hej lille dreng, vil du have noget slik ;)");

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
