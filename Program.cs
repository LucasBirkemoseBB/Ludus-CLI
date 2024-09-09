// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using System;

namespace Program
{
	public class Student 
	{
		public string navn{get}
		public int alder{get}
		public string studieretning{get;set}
		public bool studieaktiv{get;set}

		override public string ToString() 
		{
			return $"{navn} er {alder} år gammel og studere {studieretning}";
		}
	}

	internal class Program 
	{
		static void main(string[] args)
		{

		}

		private void saySike() 
		{
			Console.WriteLine("Sike");
		}
	}
}
