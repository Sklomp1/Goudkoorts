using System;
using System.Collections.Generic;
using System.Text;

namespace Goudkoorts.Model
{
	public class RightDownTurnRails : TurnRail
	{
		public RightDownTurnRails(string direction)
		{
			Direction = direction;
		}

		public override bool CanMoveTo(Cart cart)
		{
			return true;
		}

		public override bool MoveCart(Cart cart)
		{
			Field temp;
			if (Direction == "Right")
				temp = Down;
			else
				temp = Previous;

			if (!temp.CanMoveTo(cart)) return true;
			if (temp.Cart != null) return false;

			Cart = null;
			temp.Cart = cart;
			cart.Current = temp;
			return true;
		}

		public override Field MoveShip(Ship Ship)
		{
			return null;
		}

		public override void PrintField()
		{
			if (Cart != null)
				Console.Write("╚████╝");
			else
				Console.Write("═══╗  ");
		}
	}
}
