using System;
using System.Collections.Generic;
using System.Text;

namespace Goudkoorts.Model
{
	public class HorizontalRails : Rails
	{
		public HorizontalRails(string direction)
		{
			Direction = direction;
		}

		public override bool MoveCart(Cart cart)
		{
			Field temp;

			if (Direction == "Right")
				temp = Next;
			else
				temp = Previous;

			if (!temp.CanMoveTo(cart)) return true;
			if (temp.Cart != null) return false;

			Cart = null;
			temp.Cart = cart;
			cart.Current = temp;
			return true;
		}

		public override void PrintField()
		{
			if (Cart != null)
			{
				if(Cart.cargo)
					Console.Write("╚████╝");
				else
					Console.Write("╚════╝");
			}
			else
				Console.Write("══════");
		}

		public override Field MoveShip(Ship Ship)
		{
			throw new NotImplementedException();
		}

		public override bool CanMoveTo(Cart cart)
		{
			return true;
		}
	}
}
