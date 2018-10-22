using System;
using System.Collections.Generic;
using System.Text;

namespace Goudkoorts.Model
{
	public class Water : DriveAble
	{
		public override bool CanMoveTo(Cart cart)
		{
			return false;
		}

		public override bool MoveCart(Cart cart)
		{
			throw new NotImplementedException();
		}

		public override Field MoveShip(Ship ship)
		{
			Ship = null;

			if (Next == null)
				return null;

			Next.Ship = ship;

			return Next;
		}

		public override void PrintField()
		{
			int cargo = 0;

			if (Ship != null)
			{
				cargo = Ship.Cargo;

				switch (cargo)
				{
					case 2:
						Console.Write("╚■═══╝");
						break;
					case 3:
						Console.Write("╚■═══╝");
						break;
					case 4:
						Console.Write("╚■■══╝");
						break;
					case 5:
						Console.Write("╚■■══╝");
						break;
					case 6:
						Console.Write("╚■■■═╝");
						break;
					case 7:
						Console.Write("╚■■■═╝");
						break;
					case 8:
						Console.Write("╚■■■■╝");
						break;
					default:
						Console.Write("╚════╝");
						break;
				}
			}
			else if (Down.Ship != null)
			{
				cargo = Down.Ship.Cargo;
				switch (cargo)
				{
					case 0:
						Console.Write("╔════╗");
						break;
					case 1:
						Console.Write("╔■═══╗");
						break;
					case 2:
						Console.Write("╔■═══╗");
						break;
					case 3:
						Console.Write("╔■■══╗");
						break;
					case 4:
						Console.Write("╔■■══╗");
						break;
					case 5:
						Console.Write("╔■■■═╗");
						break;
					case 6:
						Console.Write("╔■■■═╗");
						break;
					default:
						Console.Write("╔■■■■╗");
						break;
				}
			}
			else
				Console.Write("▒▒▒▒▒▒");
		}
	}
}
