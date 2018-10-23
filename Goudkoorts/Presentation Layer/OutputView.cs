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
