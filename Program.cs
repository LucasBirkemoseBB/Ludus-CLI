using System;
using cli;
using LoginSystem;

using InputHandler;
using StudentSystem;

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

			StudentHandler studentHandler = new StudentHandler();
			studentHandler.addStudent(studentHandler.getExampleStudent());
			studentHandler.saveToFile("studenter.xml");

			CLI cli = new CLI();
			CLS	screen = new Login();
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
