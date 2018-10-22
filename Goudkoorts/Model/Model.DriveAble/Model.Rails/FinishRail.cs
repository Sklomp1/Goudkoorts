using System;
using System.Collections.Generic;
using System.Text;

namespace Goudkoorts.Model
{
	public class FinishRail : Rails
	{
		public FinishRail()
		{
			Finish = true;
		}

		public override bool CanMoveTo(Cart cart)
		{
			return true;
		}

		public override bool MoveCart(Cart cart)
		{
			Cart = null;
			cart.Current = null;
			return true;
		}

		public override Field MoveShip(Ship Ship)
		{
			throw new NotImplementedException();
		}

		public override void PrintField()
		{
			if (Cart != null)
				Console.Write("╚████╝");
			else
				Console.Write("══════");
		}
	}
}
