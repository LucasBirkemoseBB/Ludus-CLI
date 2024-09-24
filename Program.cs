using System;
using cli;
using SkemaSystem;
using LoginSystem;

using InputHandler;
using SkemaKlasseSystem; 

namespace Program
{
	internal class Program 
	{
		// Main entry
		static void Main(string[] args)
		{
			SkemaHandler handler = new SkemaHandler();
			handler.addKlasse(new Klasse(0, 0, 45, 0, "G214", "Idehistorie B", "2D Idehistorie B"));
			handler.addKlasse(new Klasse(0, 1, 45, 0, "G214", "Idehistorie B", "2D Idehistorie B"));
			handler.addKlasse(new Klasse(0, 2, 45, 0, "G214", "Idehistorie B", "2D Idehistorie B"));

			handler.addKlasse(new Klasse(0, 3, 45, 0, "G214", "Teknologi B", "2D Teknologi B"));

			handler.addKlasse(new Klasse(0, 4, 45, 0, "G214", "Programmering B", "2D Programmering B"));
			handler.addKlasse(new Klasse(0, 5, 45, 0, "G214", "Programmering B", "2D Programmering B"));

			handler.addKlasse(new Klasse(0, 6, 45, 0, "G214", "Datalogi OL", "Datalogi OL puljetid"));
			handler.addKlasse(new Klasse(0, 7, 45, 0, "G214", "Datalogi OL", "Datalogi OL puljetid"));

			handler.saveToFile("skema1.json");

			Console.Clear();
			// Write all code here.
			List<DrawMethod> draw_methods = new List<DrawMethod>();

			CLI cli = new CLI();
			CLS	screen = new Skema();
			screen.Initialize();
		
			// Console.Clear();
			screen.Draw(ref draw_methods);
			cli.Render(draw_methods);	

			// Aomng comment

			for(;;)
			{
				screen.Update();
				if(screen.ReRender()) 
				{
					screen.Draw(ref draw_methods);
					cli.Render(draw_methods);	
				}

				continue;
				// cli.Update();
			}
			// Console.Read();			
		}
	}
}
