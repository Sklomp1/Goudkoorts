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
			Field temp;

			if (Direction == "Up")
				temp = Up;
			else
				temp = Down;


			if (!temp.CanMoveTo(cart)) return true;
			if (temp.Cart != null) return false;

			Cart = null;
			temp.Cart = cart;
			cart.Current = temp;
			return true;
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
			return true;
		}
	}
}
