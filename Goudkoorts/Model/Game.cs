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
		public List<Warehouse> WareHouses { get; set; }

		public int Time { get; set; }
		public int Score { get; set; }
		public int MoveSpeed { get; set; }
		public int CartSpeed { get; set; }

		public Game(int capacity)
		{
			Time = 36000;
			Score = 0;
			MoveSpeed = 1;
			CartSpeed = 3;

			Carts = new List<Cart>();
			SideRails = new List<SideRail>();
			WareHouses = new List<Warehouse>();
			FieldDDLL = new FieldDDLL
			{
				RowFirst = new Field[capacity]
			};
		}

		public void AddShip()
		{
			Ship = new Ship
			{
				Current = FieldDDLL.RowFirst[2]
			};
		}

		public void SwitchRails(int number)
		{
			SideRails.ElementAt(number).SwitchRails();
		}


		public bool MoveCarts()
		{
			if (Time % CartSpeed == 0)
			{
				Random random = new Random();
				int randomNumber = random.Next(3);

				Cart cart = new Cart
				{
					Current = WareHouses.ElementAt(randomNumber)
				};
				Carts.Add(cart);
			}
			if (Time % MoveSpeed == 0)
			{
				//foreach (Cart c in Carts.Reverse<Cart>())
				foreach (Cart c in Carts.ToList())
				{
					if (!c.Move())
					{
						return false;
					}

					if (c.Current == null) Carts.Remove(c);
					else if (c.Current.Up.GetType() == typeof(Wharf) && !Ship.IsFull() && Ship.IsAtDock())
					{
						Ship.AddCargo();
						c.RemoveCargo();
                        Score += 1;
					}
				}
				// moved past last water
				if (Ship.Move())
				{
					Score += 10;
					Ship = new Ship
					{
						Current = FieldDDLL.RowFirst[2]
					};
					EditLevel();
				}
			}
			return true;
		}

		private void EditLevel()
		{
			switch (Score)
			{
				case 18:
					CartSpeed = 12;
					MoveSpeed = 4;
					break;
				case 36:
					CartSpeed = 9;
					MoveSpeed = 3;
					break;
				case 54:
					CartSpeed = 6;
					MoveSpeed = 2;
					break;
				default:
					break;
			}
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
