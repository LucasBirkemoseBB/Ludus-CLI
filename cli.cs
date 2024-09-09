using System;
using System.Collections.Generic;
using System.Linq;

namespace cli
{
	public readonly struct CursorPosition
	{
		public CursorPosition(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
		public int x{get;}
		public int y{get;}
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
	}
}
