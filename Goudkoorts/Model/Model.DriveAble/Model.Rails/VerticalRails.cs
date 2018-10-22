using System;
using System.Collections.Generic;
using System.Text;

namespace Goudkoorts.Model
{
	public class VerticalRails : Rails
	{
		public VerticalRails(string direction)
		{
			Direction = direction;
		}

		public override bool MoveCart(Cart cart)
		{
			Cart = null;

			if (Direction == "Up")
			{
				if (!Up.CanMoveTo(cart)) return true;

				Cart = null;
				Up.Cart = cart;
				cart.Current = Up;
				return true;
			}
			else
			{
				if (!Down.CanMoveTo(cart)) return true;

				Cart = null;
				Down.Cart = cart;
				cart.Current = Down;
				return true;
			}
		}

		public override void PrintField()
		{
			if(Cart != null)
				Console.Write("   █  ");
			else
				Console.Write("   ║  ");
		}

		public override Field MoveShip(Ship Ship)
		{
			throw new NotImplementedException();
		}

		public override bool CanMoveTo(Cart cart)
		{
			return false;
		}
	}
}
