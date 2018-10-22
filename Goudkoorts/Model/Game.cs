using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace Goudkoorts.Model
{
	public class Game
	{
		public FieldDDLL FieldDDLL { get; set; }
		public List<Cart> Carts { get; set; }
		public List<SideRail> SideRails { get; set; }
		public Ship Ship { get; set; }

		private int time = 5;
		private int score = 0;
		private int NumberOfWareHouses;
		private bool play = true;

		public Game(int capacity)
		{
			Carts = new List<Cart>();
			SideRails = new List<SideRail>();
			FieldDDLL = new FieldDDLL
			{
				RowFirst = new Field[capacity],
				WareHouses = new Field[3]
			};
		}

		public void Play()
		{
			Ship = new Ship
			{
				Current = FieldDDLL.RowFirst[2]
			};

			int moves = 1;

			while (play)
			{
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey(true);
					switch (key.Key)
					{
						case ConsoleKey.D1:
							SideRails.ElementAt(0).SwitchRails();
							break;
						case ConsoleKey.D2:
							SideRails.ElementAt(1).SwitchRails();
							break;
						case ConsoleKey.D3:
							SideRails.ElementAt(2).SwitchRails();
							break;
						case ConsoleKey.D4:
							SideRails.ElementAt(3).SwitchRails();
							break;
						case ConsoleKey.D5:
							SideRails.ElementAt(4).SwitchRails();
							break;
						default:
							break;
					}
				}
				Move(moves);
				PrintGame();

				Thread.Sleep(1000);
				moves++;
			}
			Console.WriteLine("YOU DIED!!");
		}

		private void Move(int move)
		{
			if (move % 5 == 0)
			{
				Random random = new Random();
				int randomNumber = random.Next(3);

				Cart cart = new Cart
				{
					Current = FieldDDLL.WareHouses[randomNumber]
				};
				Carts.Add(cart);
			}
			if (time == -1)
			{
				foreach (Cart c in Carts.Reverse<Cart>())
				{
					if (!c.Move())
					{
						play = false;
						return;
					}

					if (c.Current == null) Carts.Remove(c);
					else if (c.Current.Up.GetType() == typeof(Wharf) && !Ship.IsFull() && Ship.IsAtDock())
					{
						Ship.AddCargo();
						c.RemoveCargo();
					}
				}
				// moved past last water
				if (Ship.Move())
				{
					score += 10;
					Ship = null;
					Ship = new Ship
					{
						Current = FieldDDLL.RowFirst[2]
					};
				}

			}
		}

		public void PrintGame()
		{
			if (time == -1)
				time = 5;
			Console.Clear();
			Console.Write("\rTime before next movement: {0} | Score: {1} ", time--, score);
			Console.WriteLine();
			Console.WriteLine();

			string[] values = new string[FieldDDLL.RowFirst.Length];
			for (int i = 0; i < values.Length; i++)
			{
				var item = FieldDDLL.RowFirst[i];

				while (item != null)
				{
					item.PrintField();


					Console.Write(" ");

					item = item.Next;
				}
				Console.WriteLine();
			}
		}

		public void AddWareHouse(Field wareHouse)
		{
			FieldDDLL.WareHouses[NumberOfWareHouses++] = wareHouse;
		}


		public void AddField(Field field, int row)
		{
			if (FieldDDLL.RowFirst[row] == null)
			{
				if (row == 0)
				{
					FieldDDLL.RowFirst[row] = field;
					FieldDDLL.Last = field;
				}
				else
				{
					FieldDDLL.RowFirst[row] = field;
					FieldDDLL.RowFirst[row - 1].Down = field;
					field.Up = FieldDDLL.RowFirst[row - 1];
					FieldDDLL.Last = field;
				}
			}
			else if (row == 0 && FieldDDLL.RowFirst[row] != null)
			{
				field.Previous = FieldDDLL.Last;
				FieldDDLL.Last.Next = field;
				FieldDDLL.Last = field;
			}
			else
			{
				field.Previous = FieldDDLL.Last;
				FieldDDLL.Last.Up.Next.Down = field;
				field.Up = FieldDDLL.Last.Up.Next;
				FieldDDLL.Last.Next = field;
				FieldDDLL.Last = field;
			}
		}
	}
}
