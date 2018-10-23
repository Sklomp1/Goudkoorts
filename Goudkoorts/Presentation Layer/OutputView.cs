using Goudkoorts.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Goudkoorts.Presentation_Layer
{
	public class OutputView
	{
		public void PrintGame(FieldDDLL field, int time, int score, int moveSpeed, int cartSpeed)
		{
			int countDownTime = time % moveSpeed;
			int countDownTimeCart = time % cartSpeed;

			Console.Clear();
            Console.WriteLine("GOLDFEVER - Stephan & Tim");
            Console.WriteLine("use numerical keys 1-5 to control the rail switches, this legenda shows which number controls which switch:");
            Console.WriteLine("--\\      /------\\");
            Console.WriteLine("   1 -- 2       3");
            Console.WriteLine("--/      \\4----5/");
            Console.WriteLine("the goal is to get all gold to the docks (█DOCK█) where you will recieve 1 point for each cart emptied into the ship");
            Console.WriteLine("after ten carts, the ship is full. you will recieve a 10-point bonus for a full ship");
            Console.WriteLine("if the ship is full, you will go to a harder level, in which more carts appear faster");
            Console.WriteLine("you can use the yard (bottom track) to store carts if there is no more place on the rails");
            Console.Write("\rTime before next movement: {0} | Time before next cart: {1} | Score: {2} | Level {3}", countDownTime, countDownTimeCart, score, score / 10);
			Console.WriteLine();
			Console.WriteLine();

			string[] values = new string[field.RowFirst.Length];
			for (int i = 0; i < values.Length; i++)
			{
				var item = field.RowFirst[i];

				while (item != null)
				{
					item.PrintField();


					Console.Write(" ");

					item = item.Next;
				}
				Console.WriteLine();
			}
			Thread.Sleep(1000);
		}
	}
}
