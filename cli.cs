using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace cli
{
	// A struct used by the CLS to know where to start drawing
	public readonly struct CursorPosition
	{
		public int x{get;}
		public int y{get;}

		public CursorPosition(int x, int y)
		{
			this.x = x;
			this.y = y;
		}	

	};
 	public readonly struct TextBox
	{
		private CursorPosition position{get;}
		private int r{get;}
		private int c{get;}

		private bool centeredText{get;}		

		public TextBox(CursorPosition position, int r, int c, bool centeredText = false)
		{
			this.position = position;
			this.r = r;	// rows
			this.c = c;	// collumns
			this.centeredText = centeredText;
		}

		// Carsten ik bliv sur pls, fordi det er funktionelt programmering med currying
		// Gad sgu bare ikke tænke meget om denne funktion
		// -Mvh Lucas

		// Draws a textbox with the strings strs inside on the console
		public readonly DrawMethod draw(ref string[] strs) {
			var self = this;
			var text = strs;
			return (bool run) => {
				if(!run) return self.position;

				Console.SetCursorPosition(self.position.x, self.position.y);
				Console.Write("╭" + new string('─', self.c) + "╮");
				foreach(var line in text.Select((val, index) => new { index, val }))
				{
					if(line.val == null) continue;
					Console.SetCursorPosition(self.position.x, self.position.y + line.index+1);
					if(!self.centeredText) Console.Write("│" + line.val.PadRight(self.c) + "│");
					else 
					{
						Console.Write("│" + line.val.PadLeft(self.c/2+line.val.Length/2).PadRight(self.c) + "│");
					}
				}
				Console.SetCursorPosition(self.position.x, self.position.y + self.r+1);
				Console.Write("╰" + new string('─', self.c) + "╯");

				return self.position;
			};
		}
	};

	public readonly struct InputBox 
	{
		private CursorPosition position{get;}
		private int r{get;}
		private int c{get;}
		private string titl{get;}

		public InputBox(CursorPosition position, string title, int r, int c)
		{
			this.position = position;
			this.titl = title;
			this.r = r;	// rows
			this.c = c;	// collumns
		}

		// Draws a small textbox with the input inside
		public readonly DrawMethod draw(string input) 
		{
			var self = this;
			string text = input;
			string title = titl;
			return (bool run) =>
			{
				if(!run) return self.position;
				if(text.Length > self.c) text = text.Substring(0, self.c);

				Console.SetCursorPosition(self.position.x, self.position.y);
				Console.Write("╭" + title + new string('─', self.c - title.Length) + "╮");
				
				Console.SetCursorPosition(self.position.x, self.position.y + 1);
				Console.Write("│" + text.PadRight(self.c) + "│");
					
				Console.SetCursorPosition(self.position.x, self.position.y + 2);
				Console.Write("╰" + new string('─', self.c) + "╯");


				return self.position;
			};
		}

	}

	public delegate CursorPosition DrawMethod(bool run = false);

	public class CLI 
	{
		public CLI()
		{

		}

		public void Render(List<DrawMethod> buffer)
		{
			// Console.Clear();
			// Fkn sorts so it renders from top to bottom
			buffer = buffer.OrderBy(o=>o().y).ToList();
		
			// Loop through each and every method in list and render all of the draw calls in the screen
			foreach(var dr in buffer)
			{
				dr(true);	
			}
		}

	}

	public abstract class CLS
	{
		protected bool RedoRender = true;
		protected List<string> inputStrings = new List<string>();
		protected int selectedStringIndex = 0;

		public CLS() 
		{
			Initialize();
		}

		// Usually used to clear screen and add inputStrings 
		public abstract void Initialize();
		
		// Adds DrawMethods to the buffer
		public abstract void Draw(ref List<DrawMethod> buffer);
		
		// Decides whether or not to redraw, also handles input
		public abstract void Update();

		// Adds a string to a position on the console (Not used as far as im concerned)
		protected void WriteText(string str, CursorPosition position, ref List<DrawMethod> buffer)
		{
			
			buffer.Add((run) => {
				if(!run) return position;
				Console.SetCursorPosition(position.x, position.y);
				Console.Write(str);

				return position;
			});
		}

		// Adds a textbox to the DrawMethod buffer
		protected void AddBox(TextBox box, ref string[] text, ref List<DrawMethod> buffer)
		{
			buffer.Add(box.draw(ref text));
		}

		// Adds an inputbox to the drawmethods taking in the input text as argument
		protected void AddInputBox(InputBox box, string text, ref List<DrawMethod> buffer) 
		{
			buffer.Add(box.draw(text));
		}

		// Adds an inputbox to the drawmethods using the inputIdx to find the inputString
		protected void AddInputBox(InputBox box, int inputIdx, ref List<DrawMethod> buffer) 
		{
			buffer.Add(box.draw(inputStrings[inputIdx]));
		}

		// Self describing, handles the input and also writes to the inputStrings
		protected void HandleInput(char key) 
		{
			if(inputStrings.Count <= 0) return;

			if(key == '\t') 
			{
				selectedStringIndex = (selectedStringIndex + 1) % inputStrings.Count;
				return;
			}

			if(key == '\0') return; // Because every string ends with a null character to signify that the string is ending...
			string alphabet = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZæøåÆØÅ'*^-.,\"1234567890";
			if(alphabet.Contains(key)) 
			{
				inputStrings[selectedStringIndex] += key;

				RedoRender = true;
			}
			if(key == '\b')
			{
				int len = inputStrings[selectedStringIndex].Length -1;
				if(len < 0) len = 0;
				inputStrings[selectedStringIndex] = inputStrings[selectedStringIndex].Substring(0, len);
				RedoRender = true;
			}

		}

		// Used by the update loop to know whether or not if should redraw
		public bool ReRender() 
		{
			return RedoRender;
		}
	}
}
