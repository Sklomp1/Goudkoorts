using System;
using System.Collections.Generic;
using System.Text;

namespace Goudkoorts.Model
{
	public class Cart
	{
		public Field Current { get; set; }

		public string Direction { get; set; }

		public bool cargo = true;

		public Cart()
		{
			Direction = "forward";
		}

		public bool Move()
		{
			if (Current == null) return true;

			bool hasMoved = Current.MoveCart(this);

			return hasMoved;
		}

		public void RemoveCargo()
		{
			cargo = false;
		}
	}
}
