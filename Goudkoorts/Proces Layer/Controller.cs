using Goudkoorts.Model;
using Goudkoorts.Presentation_Layer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Goudkoorts.Proces_Layer
{
	public class Controller
	{
		#region properties

		private readonly InputView inputView;
		private readonly OutputView outputView;
		private Game game;

		#endregion

		public Controller()
		{
			inputView = new InputView();
			outputView = new OutputView();
			game = new Game();
		}

		public void StartGame()
		{
			Test();
			//outputView.PrintGame();
		}


		public void Test()
		{
			string[] lines = File.ReadAllLines("../../../GameField/gamefield.txt");

			foreach (string line in lines)
			{
				foreach (char c in line)
				{
					FieldDDL FDDL = new FieldDDL();
					game.AddField(FDDL);
					switch (c)
					{
						case 'R':
							FDDL.Field = new Rails();
							break;
						case 'E':
							Console.Write("      ");
							break;
						case 'U':
							Console.Write("   ║  ");
							break;
						case 'L':
							Console.Write("██████");
							break;
						case 'P':
							Console.Write(" ---> ");
							break;
						case 'Q':
							Console.Write(" <--- ");
							break;
						case '[':
							Console.Write("   ╔══");
							break;
						case ']':
							Console.Write("═══╗  ");
							break;
						case '1':
							Console.Write("═══╗  ");
							break;
						case '2':
							Console.Write("   ╔══");
							break;
						case '3':
							Console.Write("   ╚══");
							break;
						case '4':
							Console.Write("═══╝  ");
							break;
					}
					Console.Write(" ");
				}
				Console.WriteLine();
			}
		}
	}
}
