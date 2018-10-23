using System;
using System.Collections.Generic;
using System.Text;

namespace Goudkoorts.Model
{
	public class SideRail : Rails
	{
		private readonly char curve;
		private bool switched = false;

		public SideRail(char c)
		{
			curve = c;
		}

		public override bool MoveCart(Cart cart)
		{
			Field temp;

			switch (curve)
			{
				case ']':
					if (switched)
						temp = Up;
					else
						temp = Down;
					break;
				default:
					temp = Next;
					break;
			}

			if (!temp.CanMoveTo(cart)) return true;
			if (temp.Cart != null) return false;

			Cart = null;
			temp.Cart = cart;
			cart.Current = temp;
			return true;
		}

		public void SwitchRails()
		{
			if(Cart == null)
			switched = !switched;
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
			{
				Console.BackgroundColor = ConsoleColor.Green;
				Console.ForegroundColor = ConsoleColor.Black;
				switch (curve)
				{
					case ']':
						if (switched)
							Console.Write("═══╝  ");
						else
							Console.Write("═══╗  ");
						break;
					case '[':
						if(switched)
							Console.Write("   ╚══");
						else
							Console.Write("   ╔══");
						break;
				}
				Console.ResetColor();
			}
		}

		public override bool CanMoveTo(Cart cart)
		{
			if (curve == ']')
				return true;
			else
			{
				if (switched)
				{
					if (Up.Cart == cart)
						return true;
				}
				else if (!switched && Down.Cart == cart)
					return true;
			}
			return false;
		}
	}
}
