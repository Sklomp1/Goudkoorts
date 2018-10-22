using System;
using System.Collections.Generic;
using System.Text;

namespace Goudkoorts.Model
{
	public abstract class Field
	{
		public Cart Cart { get; set; }
		public Ship Ship { get; set; }

		public Field Up { get; set; }
		public Field Down { get; set; }
		public Field Next { get; set; }
		public Field Previous { get; set; }

		public Field()
		{
			Cart = null;
		}

		public abstract void PrintField();

		public abstract bool MoveCart(Cart cart);

		public abstract Field MoveShip(Ship Ship);

		public abstract bool CanMoveTo(Cart cart);
	}
}
