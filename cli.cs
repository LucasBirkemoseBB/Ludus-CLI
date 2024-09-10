using System;
using System.Collections.Generic;
using System.Linq;

namespace cli
{
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

		public TextBox(CursorPosition position, int r, int c)
		{
			this.position = position;
			this.r = r;	// rows
			this.c = c;	// collumns
		}

		// Carsten ik bliv sur pls, fordi det er funktionelt programmering med currying
		// Gad sgu bare ikke tænke meget om denne funktion
		// -Mvh Lucas
		public readonly DrawMethod draw(ref string[] strs) {
			var self = this;
			var text = strs;
			return (bool run) => {
				if(!run) return self.position;

				Console.SetCursorPosition(self.position.x, self.position.y);
				Console.Write("╭" + new string('─', self.c) + "╮");
				foreach(var line in text.Select((val, index) => new { index, val }))
				{
					Console.SetCursorPosition(self.position.x, self.position.y + line.index+1);
					Console.Write("│" + line.val.PadRight(self.c) + "│");
				}
				Console.SetCursorPosition(self.position.x, self.position.y + self.r+1);
				Console.Write("╰" + new string('─', self.c) + "╯");

				return self.position;
			};
		}
	};

	public delegate CursorPosition DrawMethod(bool run = false);
	// using MethodBuffer = List<DrawMethod>;

	public class CLI 
	{
		public CLI()
		{

		}

		public void Render(List<DrawMethod> buffer)
		{
			Console.Clear();
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
		public abstract void Initialize();
		public abstract void Draw(ref List<DrawMethod> buffer);
		protected void WriteText(string str, CursorPosition position, ref List<DrawMethod> buffer)
		{
			
			buffer.Add((run) => {
				if(!run) return position;
				Console.SetCursorPosition(position.x, position.y);
				Console.Write(str);

				return position;
			});
		}

		protected void AddBox(TextBox box, ref string[] text, ref List<DrawMethod> buffer)
		{
			buffer.Add(box.draw(ref text));
		}
	}
}
