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
		private Game game;

		#endregion

		public Controller()
		{
			inputView = new InputView();
			outputView = new OutputView();
		}

		public void StartGame()
		{
			Test();

			game.Play();
			//outputView.PrintGame();
		}

		public void Test()
		{
			string[] lines = File.ReadAllLines("../../../GameField/gamefield.txt");
			game = new Game(lines.Count());

			int row = -1;

			foreach (string line in lines)
			{
				row++;
				foreach (char c in line)
				{
					switch (c)
					{
						case 'K':
							Wharf wharf = new Wharf();
							game.AddField(wharf, row);
							break;
						case 'W':
							game.AddField(new Water(), row);
							break;
						case 'T':
							game.AddField(new HorizontalRails("Left"), row);
							break;
						case 'R':
							game.AddField(new HorizontalRails("Right"), row);
							break;
						case 'F':
							game.AddField(new FinishRail(), row);
							break;
						case 'E':
							game.AddField(new Empty(), row);
							break;
						case 'D':
							game.AddField(new VerticalRails("Down"), row);
							break;
						case 'U':
							game.AddField(new VerticalRails("Up"), row);
							break;
						case 'X':
							game.AddField(new ShuntRail(), row);
							break;
						case 'L':
							Warehouse warehouse = new Warehouse();
							game.AddField(warehouse, row);
							game.AddWareHouse(warehouse);
							break;
						case 'P':
							game.AddField(new Direction(), row);
							break;
						case 'Q':
							game.AddField(new Direction(), row);
							break;
						case '[':
							SideRail tempp = new SideRail(c);
							game.SideRails.Add(tempp);

							game.AddField(tempp, row);
							break;
						case ']':
							SideRail temp = new SideRail(c);
							game.SideRails.Add(temp);

							game.AddField(temp, row);
							break;
						case '1':
							game.AddField(new RightDownTurnRails("Right"), row);
							break;
						case '2':
							game.AddField(new RightDownTurnRails("Left"), row);
							break;
						case '3':
							game.AddField(new UpRightTurnRails("Right"), row);
							break;
						case '4':
							game.AddField(new UpRightTurnRails("Left"), row);
							break;
						case '5':
							game.AddField(new DownRightTurnRails("Right"), row);
							break;
						case '6':
							game.AddField(new DownRightTurnRails("Left"), row);
							break;
						case '7':
							game.AddField(new RightUpTurnRails("Right"), row);
							break;
						case '8':
							game.AddField(new RightUpTurnRails("Left"), row);
							break;
					}
				}
			}
		}
	}
}
