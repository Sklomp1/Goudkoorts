using System;
using System.Collections.Generic;
using System.Text;

namespace Goudkoorts.Model
{
	public class ShuntRail : Rails
	{
		public override bool MoveCart(Cart cart)
		{
			if (!Previous.CanMoveTo(cart)) return true;

			Cart = null;
			Previous.Cart = cart;
			cart.Current = Previous;
			return true;
		}

		public override void PrintField()
		{
			if (Cart != null)
				Console.Write("╚████╝");
			else
				Console.Write("══════");
		}

		public override Field MoveShip(Ship Ship)
		{
			throw new NotImplementedException();
		}

		public override bool CanMoveTo(Cart cart)
		{
			if (GetType() == typeof(Empty)) return false;

			return Cart == null;
		}
	}
}
