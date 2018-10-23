using System;
using System.Collections.Generic;
using System.Text;

namespace Goudkoorts.Presentation_Layer
{
	public class InputView
	{


		public ConsoleKeyInfo ReadKey()
		{
			return Console.ReadKey(true);
		}
	}
}
