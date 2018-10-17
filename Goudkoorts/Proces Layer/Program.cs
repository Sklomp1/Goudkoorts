using Goudkoorts.Proces_Layer;
using System;

namespace Goudkoorts
{
	public class Program
	{
		static void Main(string[] args)
		{
			Controller controller = new Controller();
			controller.StartGame();
			Console.ReadKey();
		}
	}
}
