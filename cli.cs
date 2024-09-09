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

	public delegate void DrawMethod();
	// using MethodBuffer = List<DrawMethod>;

	public class CLI 
	{
		public CLI()
		{

		}

		public void Render(List<DrawMethod> buffer)
		{
			Console.Clear();
			// Loop through each and every method in list and render all of the draw calls in the screen
			foreach(var dr in buffer)
			{
				dr();	
			}
		}
	}

	public abstract class CLS
	{
		public abstract void Initialize();
		public abstract void Draw(ref List<DrawMethod> buffer);
		protected void WriteText(string str, CursorPosition position, ref List<DrawMethod> buffer)
		{
			
			buffer.Add(() => {
				Console.SetCursorPosition(position.x, position.y);
				Console.WriteLine(str);
			});
		}
	}
}
