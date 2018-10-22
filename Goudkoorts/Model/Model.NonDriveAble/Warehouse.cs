using System;
using System.Collections.Generic;
using System.Text;

namespace Goudkoorts.Model
{
	class Warehouse : DriveAble
	{
		public override bool CanMoveTo(Cart cart)
		{
			return false;
		}

		public override bool MoveCart(Cart cart)
		{
			Cart = null;
			Next.Cart = cart;
			cart.Current = Next;

			return true;
		}

		public override Field MoveShip(Ship Ship)
		{
			throw new NotImplementedException();
		}

		public override void PrintField()
		{
			Console.Write("██████");
		}
	}
}
