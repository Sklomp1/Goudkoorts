using Goudkoorts.Model;
using Goudkoorts.Presentation_Layer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Proces_Layer
{
	public class Controller
	{
		#region properties

		private readonly InputView inputView;
		private readonly OutputView outputView;
		private readonly Parser parser;
		private Game game;
		private bool play = true;

		#endregion

		public Controller()
		{
			parser = new Parser();
			inputView = new InputView();
			outputView = new OutputView();
		}

		public void StartGame()
		{
			game = parser.SetUpGame(game);
			Play();
		}

		private void Play()
		{
			game.AddShip();
			while (play)
			{
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = inputView.ReadKey();

					switch (key.Key)
					{
						case ConsoleKey.D1:
							game.SwitchRails(0);
							break;
						case ConsoleKey.D2:
							game.SwitchRails(1);
							break;
						case ConsoleKey.D3:
							game.SwitchRails(2);
							break;
						case ConsoleKey.D4:
							game.SwitchRails(3);
							break;
						case ConsoleKey.D5:
							game.SwitchRails(4);
							break;
						default:
							break;
					}
				}
				play = game.MoveCarts();
				outputView.PrintGame(game.FieldDDLL, game.Time, game.Score, game.MoveSpeed, game.CartSpeed);
				game.Time--;
			}
			Console.WriteLine("You lost, Press any key to close this game");
		}
	}
}
