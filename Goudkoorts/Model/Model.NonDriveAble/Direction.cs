using System;
using System.Collections.Generic;
using System.Text;

namespace Goudkoorts.Model
{
	public class Direction : Field
	{
		public override bool CanMoveTo(Cart cart)
		{
			return false;
		}

		public override bool MoveCart(Cart cart)
		{
			throw new NotImplementedException();
		}

		public override Field MoveShip(Ship Ship)
		{
			throw new NotImplementedException();
		}

		public override void PrintField()
		{
			Console.Write(" ---> ");
		}
	}
}
