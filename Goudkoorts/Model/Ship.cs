using System;
using System.Collections.Generic;
using System.Text;

namespace Goudkoorts.Model
{
	public class Ship
	{
		public Field Current { get; set; }
		public int Cargo { get; set; }

		public Ship()
		{
			Cargo = 0;
		}

		public bool Move()
		{
			if (IsAtDock() && !IsFull()) return false;

			Current.Ship = null;
			Current = Current.MoveShip(this);

			return Current == null;
		}

		public void AddCargo()
		{
			Cargo++;
		}

		public bool IsAtDock()
		{
			return Current.Down.GetType() == typeof(Wharf);
		}

		public bool IsFull()
		{
			return Cargo == 8;
		}

		public void EmptyShip()
		{
			Cargo = 0;
		}
	}
}
